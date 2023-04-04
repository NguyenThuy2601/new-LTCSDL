using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShop.BUS;

namespace PetShop
{
    public partial class DangKy : Form
    {

        DangKyBUS bus = null;
        public DangKy()
        {
            InitializeComponent();
            bus = new DangKyBUS();
            bus.load();
        }

        
        private bool checkSDT(string sdt)
        {
            try
            {
                int.Parse(sdt);
                return true;
            }
            catch
            {
                return false;
            }
               
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            TrangChuKhachHang f = new TrangChuKhachHang();
            f.Show();   
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(checkSDT(txtSDT.Texts) == false)
            {
                MessageBox.Show("Vui lòng nhập đúng số điện thoại");
                txtSDT.Texts = "";
            }    
            else
            {
                bool chk = true;
                foreach (Control ctrl in this.Controls)
                    if (ctrl is TextBox)
                        if (ctrl.Text == "")
                        {
                            chk = false;
                            break;
                        }
                if (chk == false)
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                else
                {
                    if(bus.checkEmail(txtEmail.Texts) == false)
                    {
                        MessageBox.Show("Email này đã được dùng");
                        txtEmail.Texts = "";
                        txtEmail.Focus();
                    }    
                    else
                    {
                        if (txtPassWord.Texts != txtXacNhanPW.Texts)
                        {
                            MessageBox.Show("Password không khớp nhau");
                            txtPassWord.Texts = txtXacNhanPW.Texts = "";
                            txtPassWord.Focus();
                        }
                        else
                        {
                            string hashPass = CommonFunction.Encrypt(txtPassWord.Texts);
                            string idAcc = bus.createCusAccId();
                            if (bus.createCusAcc(idAcc, hashPass, txtEmail.Texts) != 0)
                            {
                                int cusID = int.Parse(idAcc.Substring(2));
                                if (bus.createCusInfo(cusID, txtTen.Texts, txtHo.Texts, txtSDT.Texts, txtDiaChi.Texts, idAcc, dateNgaySinh.Value) != 0)
                                {
                                    if (bus.createCartForCus(cusID) == 0)
                                        MessageBox.Show("Đã có lỗi xảy ra ! Vui lòng thử lại");
                                    else
                                    {
                                        bus.close();
                                        DangNhap f = new DangNhap();
                                        f.Show();
                                        this.Close();
                                    }
                                }
                                else
                                    MessageBox.Show("Đã có lỗi xảy ra ! Vui lòng thử lại");
                            }
                            else
                                MessageBox.Show("Đã có lỗi xảy ra ! Vui lòng thử lại");
                        }    
                    }    

                    //bool chkEmail = true;
                    //string sql = "select MaTK from TaiKhoan where email = '" + txtEmail.Texts + "'";
                    //if (function.RunQuery(sql) != null)
                    //    chkEmail = false;
                    //MessageBox.Show(chkEmail.ToString());
                    //if (chkEmail == false)
                    //{
                    //    MessageBox.Show("Email này đã được dùng");
                    //    txtEmail.Texts = "";
                    //    txtEmail.Focus();
                    //}
                    //else
                    //{
                    //    if (txtPassWord.Texts != txtXacNhanPW.Texts)
                    //    {
                    //        MessageBox.Show("Password không khớp nhau");
                    //        txtPassWord.Texts = txtXacNhanPW.Texts = "";
                    //        txtPassWord.Focus();
                    //    }
                    //    else
                    //    {
                    //        string hashPass = function.Encrypt(txtPassWord.Texts);
                    //        sql = "select count (MaTK) from TaiKhoan where SUBSTRING(MaTK,1,2) = 'KH'";
                    //        string result = (int.Parse(function.RunQuery(sql)) + 1).ToString();
                    //        int num = 1000 + int.Parse(result);
                    //        string TKid = "KH" + num.ToString().Substring(1);
                    //        sql = "insert into TaiKhoan values ('" + TKid + "','" + txtEmail.Texts + "','"
                    //                + hashPass + "')";
                    //        function.RunNonQuery(sql);
                    //        sql = "insert into KhachHang values('" + result + "',N'"
                    //            + txtTen.Texts + "',N'"
                    //            + txtHo.Texts + "','"
                    //            + txtSDT.Texts + "',N'"
                    //            + txtDiaChi + "','"
                    //            + TKid + "','"
                    //            + dateNgaySinh.Value + "')";
                    //        function.RunNonQuery(sql);
                    //        sql = "insert into GioHang(MaKH) values('" + result + "')";
                    //        function.RunNonQuery(sql);
                    //        DangNhap f = new DangNhap();
                    //        f.Show();
                    //        this.Close();
                    //    }
                    //}


                }
            }    
              

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }

}

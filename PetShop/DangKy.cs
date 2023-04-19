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
using PetShop.DTO;

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
                            Account account = new Account(idAcc, txtEmail.Texts, hashPass);
                            
                            if (bus.createCusAcc(account) != 0)
                            {
                                int cusID = int.Parse(idAcc.Substring(2));
                                KhachHang kh = new KhachHang(cusID, dateNgaySinh.Value, txtHo.Texts, txtTen.Texts, txtSDT.Texts, txtDiaChi.Texts, idAcc);
                                if (bus.createCusInfo(kh) != 0)
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
                }
            }    
              

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            pictureBox1.LoadAsync(@"https://res.cloudinary.com/drrmia1ij/image/upload/c_pad,b_auto:predominant,fl_preserve_transparency/v1677065950/Capture-removebg_k3mb53.jpg");
        }
    }

}

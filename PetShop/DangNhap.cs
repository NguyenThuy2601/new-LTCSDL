using BanHangChoPet;
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
    public partial class DangNhap : Form
    {
        static Form f;
        DangNhapBUS bus = null;
        public DangNhap()
        {
            InitializeComponent();
            bus = new DangNhapBUS();
            bus.load();

        }
        public static Form form
        {
            set { f = value; }
        }

        

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            bus.close();
            this.Close();
            f.Show();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKy dky = new DangKy();
            dky.Show();
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtEmail.Texts == "")
            {
                MessageBox.Show("Vui lòng nhập email");
                txtEmail.Focus();
            }    
            else
            {
                if(txtPassWord.Texts == "")
                {
                    MessageBox.Show("Vui lòng nhập password");
                    txtPassWord.Focus();
                }
                else
                {
                    if(bus.getPass(txtEmail.Texts) != null)
                    {
                        string pass = bus.getPass(txtEmail.Texts);
                        pass = pass.Trim();
                        string hashPass = CommonFunction.Encrypt(txtPassWord.Texts);
                        if(pass == hashPass)
                        {
                            string accID = bus.getAcc(txtEmail.Texts);
                            if(accID.Substring(0, 2) == "KH")
                            {
                                int uID;
                                string uName;
                                DataTable dt = bus.getKHByAccID(accID);
                                foreach(DataRow row in dt.Rows)
                                {
                                    uID = int.Parse(row["MaKH"].ToString());
                                    uName = row["Ten"].ToString().Trim();
                                    PetShop.DTO.User user = new DTO.User(uID, uName, accID);
                                    TrangChuKhachHang trangChuKhachHang = new TrangChuKhachHang(user);
                                    trangChuKhachHang.Show();
                                }    
                            }  
                            else
                            {
                                string sql = "select MaNV from NhanVien where MaTK ='" + accID + "'";
                                int uId = int.Parse(function.RunQuery(sql));
                                sql = "select Ten from NhanVien where MaNV ='" + uId + "'";
                                string uName = function.RunQuery(sql).Trim();
                                User.setUserInfo(uId, uName, accID);
                                TrangChu trang = new TrangChu();
                                trang.Show();
                            }
                            bus.close();
                            this.Hide();
                        }    
                        else
                            MessageBox.Show("Sai mật khẩu");
                    }    
                    else
                        MessageBox.Show("Không tìm thấy email");

                    //string sql = "select password from TaiKhoan where email ='" + txtEmail.Texts + "'";
                    //string pass = function.RunQuery(sql);
                    //pass = pass.Trim();
                    //if (pass == null)
                    //    MessageBox.Show("Không tìm thấy email");
                    //else
                    //{
                    //    string hashPass = function.Encrypt(txtPassWord.Texts);
                    //    if (pass == hashPass)
                    //    {
                    //        sql = "select MaTK from TaiKhoan where email ='" + txtEmail.Texts + "'";
                    //        string accID = function.RunQuery(sql).Trim();
                    //        string uName;
                    //        int uId;
                    //        if (accID.Substring(0, 2) == "KH")
                    //        {
                    //            sql = "select MaKH from KhachHang where MaTK ='" + accID + "'";
                    //            uId = int.Parse(function.RunQuery(sql));
                    //            sql = "select Ten from KhachHang where MaKH ='" + uId + "'";
                    //            uName = function.RunQuery(sql).Trim();
                    //            PetShop.DTO.User user = new DTO.User(uId, uName, accID);
                    //            TrangChuKhachHang trangChuKhachHang = new TrangChuKhachHang(user);
                    //            trangChuKhachHang.Show();
                    //        }
                    //        else
                    //        {
                    //            sql = "select MaNV from NhanVien where MaTK ='" + accID + "'";
                    //            uId = int.Parse(function.RunQuery(sql));
                    //            sql = "select Ten from NhanVien where MaNV ='" + uId + "'";
                    //            uName = function.RunQuery(sql).Trim();
                    //            User.setUserInfo(uId, uName, accID);
                    //            TrangChu trang = new TrangChu();
                    //            trang.Show();
                    //        }
                    //        this.Hide();
                    //    }

                    //    else
                    //        MessageBox.Show("Sai mật khẩu");
                    //}
                } 
                    
            }    

        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}

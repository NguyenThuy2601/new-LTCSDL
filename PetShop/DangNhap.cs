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



namespace PetShop
{
    public partial class DangNhap : Form
    {
        static Form f;
        public DangNhap()
        {
            InitializeComponent();
        }
        public static Form form
        {
            set { f = value; }
        }

        
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
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
                    string sql = "select password from TaiKhoan where email ='" + txtEmail.Texts + "'";
                    string pass = function.RunQuery(sql);
                    pass = pass.Trim();
                    if (pass == null)
                        MessageBox.Show("Không tìm thấy email");
                    else
                    {
                        string hashPass = function.Encrypt(txtPassWord.Texts);
                        if (pass == hashPass)
                        {
                            sql = "select MaTK from TaiKhoan where email ='" + txtEmail.Texts + "'";
                            string accID = function.RunQuery(sql).Trim();
                            string uName;
                            int uId;
                            if (accID.Substring(0, 2) == "KH")
                            {
                                sql = "select MaKH from KhachHang where MaTK ='" + accID + "'";
                                uId = int.Parse(function.RunQuery(sql));
                                sql = "select Ten from KhachHang where MaKH ='" + uId + "'";
                                uName = function.RunQuery(sql).Trim();
                                User.setUserInfo(uId, uName, accID);
                                f.Show();

                            }
                            else
                            {
                                sql = "select MaNV from NhanVien where MaTK ='" + accID + "'";
                                uId = int.Parse(function.RunQuery(sql));
                                sql = "select Ten from NhanVien where MaNV ='" + uId + "'";
                                uName = function.RunQuery(sql).Trim();
                                User.setUserInfo(uId, uName, accID);
                                TrangChu trang = new TrangChu();
                                trang.Show();
                            }
                            this.Hide();
                        }

                        else
                            MessageBox.Show("Sai mật khẩu");
                    }
                } 
                    
            }    

        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}

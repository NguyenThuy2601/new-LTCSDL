using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShop.DTO;
using PetShop.BUS;

namespace PetShop
{
    public partial class UserInfo : Form
    {
        DTO.User user = null;
        UserProfileBUS bus = new UserProfileBUS();
        KhachHang kh = null;
        Account ac = null;
        public UserInfo()
        {
            InitializeComponent();
        }

        public UserInfo(DTO.User user) :this()
        {
            this.user = user;
        }
        public void setVissibleStatus()
        {
            lblChangePass.Visible = true;

            txtConfirm.Visible = false;
            txtNewPass.Visible = false;
            txtOldPassword.Visible = false;
            btnConfrimPass.Visible = false;

            lblConfirm.Visible = false;
            lblNewPass.Visible = false;
            lblOldPass.Visible = false;
        }
        private void UserInfo_Load(object sender, EventArgs e)
        {
            bus.load();

            setVissibleStatus();
            kh = bus.GetKhachHangInfo(user.getID());
            ac = bus.GetAccountInfo(user.getAccountId());
            if (kh == null || ac == null)
                MessageBox.Show("Có lỗi xảy ra");
            else
            {
                txtTen.Texts = kh.ten;
                txtHoLot.Texts = kh.hoLot;
                txtDiaChi.Texts = kh.diaChi;
                txtSDT.Texts = kh.sDT;
                dtpDOB.Value = kh.Dob;

                txtEmail.Texts = ac.Email;
            }
        }

        private void UserInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            lblChangePass.Visible = false;

            txtConfirm.Visible = true;
            txtNewPass.Visible = true;
            txtOldPassword.Visible = true;
            btnConfrimPass.Visible = true;

            lblConfirm.Visible = true;
            lblNewPass.Visible = true;
            lblOldPass.Visible = true;
        }

        private void btnConfrimPass_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Texts == "" || txtNewPass.Texts == "" || txtOldPassword.Texts == "")
                MessageBox.Show("Không được bỏ trống");
            else
            {
                if (ac.Password.Equals(CommonFunction.Encrypt(txtOldPassword.Texts)))
                {
                    if (!txtOldPassword.Texts.Equals(txtNewPass.Texts))
                    {
                        if (txtNewPass.Texts.Equals(txtConfirm.Texts))
                        {
                            ac.Password = CommonFunction.Encrypt(txtNewPass.Texts);
                            if (bus.updatePass(ac, user.getAccountId()) > 0)
                            {
                                MessageBox.Show("Đổi thành công");
                                setVissibleStatus();
                            }
                            else
                                MessageBox.Show("Có lỗi xảy ra");
                        }
                        else
                        {
                            MessageBox.Show("Xác nhận mật khẩu không khớp");
                            txtConfirm.Texts = "";
                            txtNewPass.Texts = "";
                        }

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ");
                        txtConfirm.Texts = "";
                        txtNewPass.Texts = "";
                        txtOldPassword.Texts = "";
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp");
                    txtConfirm.Texts = "";
                    txtNewPass.Texts = "";
                    txtOldPassword.Texts = "";
                }
            }
              
               
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtHoLot.Texts == "" || txtTen.Texts == "" || txtSDT.Texts == "" || txtDiaChi.Texts == null)
                MessageBox.Show("Không được bỏ trống các trường này");
            else
            {
                kh.hoLot = txtHoLot.Texts;
                kh.ten = txtTen.Texts;
                kh.sDT = txtSDT.Texts;
                kh.diaChi = txtDiaChi.Texts;
                kh.Dob = dtpDOB.Value;


                if (bus.updateUserInfo(kh, user.getID()) > 0)
                    MessageBox.Show("Cập nhật thành công");
                else
                    MessageBox.Show("Có lỗi xảy ra");

            }    
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            if (ac.Email.Equals(txtEmail.Texts))
                return;
            else
            {
                if (txtEmail.Texts == "")
                    MessageBox.Show("Không để trống trường này");
                else
                {
                    if (txtEmail.Texts.Contains("@") == false)
                        MessageBox.Show("Không đúng định dạng email");
                    else
                    {
                        if (bus.checkExistingEmail(txtEmail.Texts) == 0)
                        {
                            ac.Email = txtEmail.Texts;
                            if (bus.updateEmail(ac, user.getAccountId()) > 0)
                                MessageBox.Show("update thành công");
                            else
                                MessageBox.Show("Có lỗi xảy ra");
                        }
                        else
                            MessageBox.Show("email này đã được dùng");
                    }
                }
            }               
        }
    }
}

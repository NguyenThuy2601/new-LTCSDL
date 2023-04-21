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
    public partial class EmplInfo : Form
    {
        User user = null;
        EmplBus bus = new EmplBus();
        public EmplInfo()
        {
            InitializeComponent();
        }

        public EmplInfo(User user) :this()
        {
            this.user = user;
        }

        private void setInvisible()
        {
            lblNewPass.Visible = false;
            txtNewPass.Visible = false;

            lblOldPass.Visible = false;
            txtOldPass.Visible = false;

            lblConfirm.Visible = false;
            txtConfirm.Visible = false;
            btnConfirm.Visible = false;
        }

        private void setVisible()
        {
            label5.Visible = false;

            lblNewPass.Visible = true;
            txtNewPass.Visible = true;

            lblOldPass.Visible = true;
            txtOldPass.Visible = true;

            lblConfirm.Visible = true;
            txtConfirm.Visible = true;
            btnConfirm.Visible = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EmplInfo_Load(object sender, EventArgs e)
        {
            bus.load();
            setInvisible();
            Empl empl = bus.getCurrentEmpl(user.getID());
            if(empl != null)
            {
                lblName.Text = String.Format("{0} {1}", empl.HoLot1, empl.Ten1);
                lblEmail.Text = empl.Email;
                lblEmplID.Text = empl.ID1.ToString();
                lblDob.Text = empl.DOB1.ToString("dd-MM-yyyy");
                lblSdt.Text = empl.SDT1;
            } 
            else
            {
                lblName.Text = "";
                lblEmail.Text = "";
                lblEmplID.Text = "";
                lblDob.Text = "";
                lblSdt.Text = "";
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Text == "" || txtNewPass.Text == "" || txtConfirm.Text == "")
                MessageBox.Show("Vui lòng nhập đủ");
            else
            {
                 
                if(txtConfirm.Text.Equals(txtNewPass.Text))
                {
                    if(bus.authorization(txtOldPass.Text, user.getAccountId()))
                    {
                        if (txtOldPass.Text.Equals(txtNewPass.Text))
                        {
                            MessageBox.Show("mật khẩu mới phải khác mật khẩu cũ");
                            txtConfirm.Text = "";
                            txtNewPass.Text = "";
                        }
                        else
                        {
                            if (bus.updatePass(CommonFunction.Encrypt(txtNewPass.Text), user.getAccountId()) > 0)
                            {
                                MessageBox.Show("Đổi mật khẩu thành công");
                                setInvisible();
                                label5.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi xảy ra");
                                txtConfirm.Text = "";
                                txtNewPass.Text = "";
                                txtOldPass.Text = "";
                            }
                        }
                         
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng");
                        txtOldPass.Text = "";
                    }    
                }
                else
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp");
                    txtConfirm.Text = "";
                    txtNewPass.Text = "";
                }    
            }    
        }

        private void label5_Click(object sender, EventArgs e)
        {
            setVisible();
        }
    }
}

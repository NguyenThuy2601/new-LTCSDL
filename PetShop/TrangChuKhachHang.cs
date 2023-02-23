using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class TrangChuKhachHang : Form
    {
        public TrangChuKhachHang()
        {
            InitializeComponent();
        }


        private void TrangChuKhachHang_Load(object sender, EventArgs e)
        {
            function.Connect();
            pictureBox1.LoadAsync(@"https://res.cloudinary.com/drrmia1ij/image/upload/c_pad,b_auto:predominant,fl_preserve_transparency/v1677065950/Capture-removebg_k3mb53.jpg");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            DangNhap.form = this;
            this.Hide();
            dn.Show();
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            flPanel.Controls.Add(childForm);
            flPanel.Tag = childForm;
            //childForm.BringToFront();
            childForm.Show();
        }
        private void btnGioHang_Click(object sender, EventArgs e)
        {
            openChildForm(new GioHang());
        }

        private void TrangChuKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            function.Disconnect();
        }

        private void TrangChuKhachHang_Shown(object sender, EventArgs e)
        {
           
        }

        private void TrangChuKhachHang_Activated(object sender, EventArgs e)
        {
            if (User.getID() != 0)
                btnDangNhap.Visible = false;
        }

        private void btnDanhMucCho_Click(object sender, EventArgs e)
        {
            openChildForm(new ShowProduct());
        }
    }
}

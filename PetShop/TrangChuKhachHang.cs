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
    public partial class TrangChuKhachHang : Form
    {
        public TrangChuKhachHang()
        {
            InitializeComponent();
        }


        private void TrangChuKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
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
    }
}

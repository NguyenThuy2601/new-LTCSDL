using PetShop;
using System.Data.SqlClient;

namespace BanHangChoPet
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            customDesign();
        }

        private void customDesign()
        {
            pnDonHangSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (pnDonHangSubMenu.Visible == true)
                pnDonHangSubMenu.Visible = false;
        }

        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void btDonHang_Click(object sender, EventArgs e)
        {
            showSubMenu(pnDonHangSubMenu);
        }

        #region DonHangSubMenu 
        private void btDHDoiXacNhan_Click(object sender, EventArgs e)
        {
            openChildForm(new DHDoiXacNhan());
            hideSubMenu();
        }

        private void btDHDaXacNhan_Click(object sender, EventArgs e)
        {
            //code
            hideSubMenu();
        }

        private void btDHDaHuy_Click(object sender, EventArgs e)
        {
            //code
            hideSubMenu();
        }
        #endregion

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnChildForm.Controls.Add(childForm);
            pnChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new QLSanPham());
            hideSubMenu();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            function.Connect();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            function.Disconnect();
            this.Close();

        }

        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            function.Disconnect();
        }

        private void btNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new QLNhanVien());
            hideSubMenu();
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new QLKhachHang());
            hideSubMenu();
        }
    }
}
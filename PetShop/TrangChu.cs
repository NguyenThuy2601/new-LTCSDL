using PetShop;
using System.Data.SqlClient;
using PetShop.BUS;

namespace BanHangChoPet
{
    public partial class TrangChu : Form
    {
        ModelBUS bus = new ModelBUS();
        PetShop.DTO.User user;
        
        public TrangChu()
        {
            InitializeComponent();
            customDesign();
        }

        public TrangChu(PetShop.DTO.User user) : this()
        {
            this.user = user;   
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
            openChildForm(new DHDoiXacNhan(user));
            hideSubMenu();
        }

        private void BtDHDaXacNhan_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new frmDonHangDaXN(user));
            hideSubMenu();
        }

        private void btDHDaHuy_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new frmDHDaHuy());
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
            //function.Connect();
            bus.load();
            picLogo.LoadAsync(@"https://res.cloudinary.com/drrmia1ij/image/upload/c_pad,b_auto:predominant,fl_preserve_transparency/v1677065950/Capture-removebg_k3mb53.jpg");
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            
            bus.close();
            TrangChuKhachHang f = new TrangChuKhachHang();

            this.Close();
            f.Show();

        }

        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            function.Disconnect();
        }

        private void btNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new QLNhanVien(user));
            hideSubMenu();
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new QLKH(user));
            hideSubMenu();
        }

        private void btDoanhThu_Click(object sender, EventArgs e)
        {
            openChildForm(new DoanhThu());
            hideSubMenu();
        }

        private void btKhuyenMai_Click(object sender, EventArgs e)
        {
            openChildForm(new KhuyenMai());
            hideSubMenu();
        }
    }
}
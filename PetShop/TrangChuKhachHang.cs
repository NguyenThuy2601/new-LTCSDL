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
using PetShop.DTO;
using PetShop.BUS;

namespace PetShop
{
    public partial class TrangChuKhachHang : Form
    {
        PetShop.DTO.User user;
        ModelBUS bus = new ModelBUS();
        public TrangChuKhachHang()
        {
            InitializeComponent();
            user = new PetShop.DTO.User();
        }

        public TrangChuKhachHang(PetShop.DTO.User user) : this()
        {
            this.user = user;
        }

        private void TrangChuKhachHang_Load(object sender, EventArgs e)
        {
            bus.load();
            
            pictureBox1.LoadAsync(@"https://res.cloudinary.com/drrmia1ij/image/upload/c_pad,b_auto:predominant,fl_preserve_transparency/v1677065950/Capture-removebg_k3mb53.jpg");
            pb2.LoadAsync(@"https://res.cloudinary.com/drrmia1ij/image/upload/v1681720550/icons8-user-32_f714wy.png");
            findPb.LoadAsync(@"https://res.cloudinary.com/drrmia1ij/image/upload/v1681720550/icons8-search-32_2_ot6xye.png");
            drdMenuCho.IsMainMenu = true;
            drdMenuMeo.IsMainMenu = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            DangNhap.form = this;
            this.Hide();
            dn.Show();
        }


        private Form activeForm = null;
        public void openChildForm(Form childForm)
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
            openChildForm(new GioHang(this.user, this));
        }

        private void TrangChuKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }

        private void TrangChuKhachHang_Shown(object sender, EventArgs e)
        {
           
        }

        private void TrangChuKhachHang_Activated(object sender, EventArgs e)
        {
            if (user.getID() != 0)
            {
                btnDangNhap.Visible = false;
                btnDangXuat.Visible = true;
                btnGioHang.Visible = true;
                btnDonHang.Visible = true;
                btnUserInfo.Visible = true;

                pb2.Visible = true;
                helloLbl.Visible = true;
                helloLbl.Text = String.Format("Hi, {0}", user.getName());
            }    
                
            else
            {
                btnDangNhap.Visible = true;
                btnDangXuat.Visible = false;
                btnGioHang.Visible = false;
                btnDonHang.Visible = false;
                btnUserInfo.Visible = false;

                pb2.Visible = false;
                helloLbl.Visible = false;
            }    
                
        }

        private void btnDanhMucCho_Click(object sender, EventArgs e)
        {
            drdMenuCho.Show(btnDanhMucCho, btnDanhMucCho.Width, 0);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            user.setUserInfo(0, null, null);
            btnDangNhap.Visible = true;
            btnDangXuat.Visible = false;
            TrangChuKhachHang f = new TrangChuKhachHang();
            f.Show();
            this.Close();

        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem it = (ToolStripMenuItem)sender;
            String kw = it.Tag.ToString();
            openChildForm(new ShowProduct(user, kw, false));
        }

        private void btnDanhMucMeo_Click(object sender, EventArgs e)
        {
            drdMenuMeo.Show(btnDanhMucMeo, btnDanhMucMeo.Width, 0);
        }

        private void buttonCustom1_Click(object sender, EventArgs e)
        {
            openChildForm(new XemChiTietDH(user));
        }

        private void findPb_Click(object sender, EventArgs e)
        {
            if (findTxt.Texts == "")
                return;
            else
            {
                openChildForm(new ShowProduct(user, findTxt.Texts, true));
            }    
        }

        private void buttonCustom1_Click_1(object sender, EventArgs e)
        {
            openChildForm(new UserInfo(user));
        }
    }
}

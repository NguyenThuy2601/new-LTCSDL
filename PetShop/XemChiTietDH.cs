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

namespace PetShop
{
    public partial class XemChiTietDH : Form
    {

        DTO.User user;
        XemChiTietDHBUS bus = null;
        DataTable dt;
        public XemChiTietDH()
        {
            InitializeComponent();
        }

        public XemChiTietDH(DTO.User user) : this()
        {
            this.user = user;
            bus = new XemChiTietDHBUS();
        }

        private void XemChiTietDH_Load(object sender, EventArgs e)
        {
            bus.load();
            dgvDH.DataSource = bus.getDH(user.getID());
            dt = bus.getCTDH(user.getID()); 
            lblThanhTien.Text = "";
            lblShip.Text = "";
            lblTotal.Text = "";
            lblAddress.Text = "";
        }

        private void dgvDH_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDH.SelectedRows[0];

            lblThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
            lblShip.Text = row.Cells["Ship"].Value.ToString();
            lblTotal.Text = row.Cells["Tong"].Value.ToString();
            lblAddress.Text = row.Cells["DiaChi"].Value.ToString();
            lblStatus.Text = row.Cells["Status"].Value.ToString();

            dgvDetail.DataSource = bus.filterCTDH(row.Cells["MaDH"].Value.ToString(), dt);
        }

        private void XemChiTietDH_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }

        
    }
}

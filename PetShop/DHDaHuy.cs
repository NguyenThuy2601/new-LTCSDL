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
    public partial class frmDHDaHuy : Form
    {
        DataTable tb;
        DataTable cttb;
        DHDaHuyBUS bus = new DHDaHuyBUS();
        public frmDHDaHuy()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            
            tb = bus.getOrderList();
            dgvListDH.DataSource = tb;
            dgvListDH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListDH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void frmDHDaHuy_Load(object sender, EventArgs e)
        {
            bus.load();
            cttb = bus.getOrderDetailList();
            LoadDataGridView();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            DataTable dt = bus.findOrder(tb, txtMaDH.Text);
            dgvListDH.DataSource = dt;

            DataTable temp = bus.findOrder(cttb, txtMaDH.Text);
            dgvListDH.DataSource = temp;
        }

        private void frmDHDaHuy_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }

        private void dgvListDH_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvListDH.SelectedRows[0];

            String id = row.Cells["MaDH"].Value.ToString();
            DataTable temp = bus.findOrder(cttb, id); 
            dgvListCTDH.DataSource = temp;    
        }
    }
}

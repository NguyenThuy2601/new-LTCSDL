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
    public partial class frmDHDaHuy : Form
    {
        DataTable tb;
        public frmDHDaHuy()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "select * from DonHang where DonHang.TinhTrang = 2";
            tb = function.GetDataToTable(sql);
            dgvListDH.DataSource = tb;
            dgvListDH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListDH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void frmDHDaHuy_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            DataTable dt = tb;
            dt.DefaultView.RowFilter = string.Format("MaDH = '{0}'", txtMaDH.Text);
            dgvListDH.DataSource = dt;
        }

        private void pnTTDonHang_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

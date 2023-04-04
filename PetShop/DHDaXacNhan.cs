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
    public partial class frmDonHangDaXN : Form
    {
        DataTable tb, tb1;
        public frmDonHangDaXN()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "select * from DonHang where DonHang.TinhTrang = 1";
            tb = function.GetDataToTable(sql);
            dgvListDH.DataSource = tb;
            dgvListDH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListDH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void frmDonHangDaXN_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            DataTable dt = tb;
            dt.DefaultView.RowFilter = string.Format("MaDH = '{0}'", txtMaDH.Text);
            dgvListDH.DataSource = dt;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "update DonHang set TinhTrang = 2 where MaDH = '" + txtMaDHHT.Text + "'";
            function.RunNonQuery(sql);
            LoadDataGridView();
        }

        private void dgvListDH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListDH.CurrentCell.Selected = true;
            txtMaDHHT.Text = dgvListDH.CurrentRow.Cells["MaDH"].Value.ToString();
            string ma = dgvListDH.CurrentRow.Cells["MaDH"].Value.ToString();
            string sql;
            sql = "select * from ChiTietDonHang where MaDH = '" + ma + "' ";
            tb1 = function.GetDataToTable(sql);
            dgvListCTDH.DataSource = tb1;
            dgvListCTDH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListCTDH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
    }
}

using System.Data;

namespace PetShop
{
    public partial class DHDoiXacNhan : Form
    {
        DataTable tb;
        public DHDoiXacNhan()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "select * from DonHang where DonHang.TinhTrang = 0";
            tb = function.GetDataToTable(sql);
            dgvListDH.DataSource = tb;
            dgvListDH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListDH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void DHDoiXacNhan_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dgvListDH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListDH.CurrentCell.Selected = true;
            txtMaDon.Text = dgvListDH.CurrentRow.Cells["MaDH"].Value.ToString();
            txtTinhTrang.Text = dgvListDH.CurrentRow.Cells["TinhTrang"].Value.ToString();
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtMaDon.Text);
            string sql;
            sql = "update DonHang set TinhTrang = 1 where MaDH = '" + txtMaDon.Text + "'";
            function.RunNonQuery(sql);
            LoadDataGridView();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            DataTable dt = tb;
            dt.DefaultView.RowFilter = string.Format("MaDH = '{0}'", txtMaDH.Text);
            dgvListDH.DataSource = dt;
        }
    }
}

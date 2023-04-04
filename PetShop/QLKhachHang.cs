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
    public partial class QLKH : Form
    {
        DataTable tb;
        public QLKH()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "select kh.*, tk.email from KhachHang kh, TaiKhoan tk where kh.MaTK = tk.MaTK";
            tb = function.GetDataToTable(sql);
            dgwListKH.DataSource = tb;
            dgwListKH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgwListKH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnNhapTTNhanVien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dgwListKH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwListKH.CurrentCell.Selected = true;
            txtHoTenlot.Text = dgwListKH.CurrentRow.Cells["HoLot"].Value.ToString();
            txtTen.Text = dgwListKH.CurrentRow.Cells["Ten"].Value.ToString();
            txtSDT.Text = dgwListKH.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgwListKH.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgwListKH.CurrentRow.Cells["email"].Value.ToString();
            dtpNgaySinh.Text = dgwListKH.CurrentRow.Cells["DOB"].Value.ToString();
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            if (txtTimKHTheoTen.Text.Trim() != string.Empty)
            {
                DataTable dt = tb;
                dt.DefaultView.RowFilter = string.Format("Ten = '{0}'", txtTimKHTheoTen.Text);
                dgwListKH.DataSource = dt;
            }
            if (txtTimKHTheoEmail.Text.Trim() != string.Empty)
            {
                DataTable dt = tb;
                dt.DefaultView.RowFilter = string.Format("Email = '{0}'", txtTimKHTheoEmail.Text);
                dgwListKH.DataSource = dt;
            }

        }
    }
}

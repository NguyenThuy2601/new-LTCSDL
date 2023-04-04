using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PetShop
{
    public partial class QLNhanVien : Form
    {
        DataTable tb;
        public QLNhanVien()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "select nv.*, tk.email from NhanVien nv, TaiKhoan tk where nv.MaTK = tk.MaTK";
            dgwNV.DataSource = function.GetDataToTable(sql);
            dgwNV.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgwNV.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QLNhanVien_Load_1(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dgwNV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwNV.CurrentCell.Selected = true;
            txtHoTenlot.Text = dgwNV.CurrentRow.Cells["HoLot"].Value.ToString();
            txtTen.Text = dgwNV.CurrentRow.Cells["Ten"].Value.ToString();
            txtSDT.Text = dgwNV.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgwNV.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgwNV.CurrentRow.Cells["email"].Value.ToString();
            txtCMND.Text = dgwNV.CurrentRow.Cells["CMND"].Value.ToString();
            dtpNgaySinh.Text = dgwNV.CurrentRow.Cells["DOB"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = "NV";
            string pass = function.Encrypt(txtPass.Text);
            string sql = "select count (MaTK) from TaiKhoan where SUBSTRING(MaTK,1,2) = 'NV'";
            int data = int.Parse(function.RunQuery(sql)) + 1;
            int num = 1000 + data;
            string TKid = "NV" + num.ToString().Substring(1);

            sql = "insert into TaiKhoan values('"
                + TKid + "','"
                + txtEmail.Text + "','"
                + pass + "')";
            function.RunNonQuery(sql);


            sql = "select count (MaNV) from NhanVien";
            int idNV = int.Parse(function.RunQuery(sql)) + 1;

            sql = "insert into NhanVien values("
                + idNV + ","
                + "N'" + txtTen.Text + "',"
                + "N'" + txtHoTenlot.Text + "','"
                + txtSDT.Text + "','"
                + dtpNgaySinh.Value.Date.ToString("yyyyMMdd") + "','"
                + txtDiaChi.Text + "','"
                + txtCMND.Text + "','"
                + TKid + "')";
            function.RunNonQuery(sql);
            LoadDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string idTK = dgwNV.CurrentRow.Cells["MaTK"].Value.ToString();
            string pass = function.Encrypt(txtPass.Text);
            string sql = "update TaiKhoan set MaTK = '"
                + idTK + "',"
                + "email = '" + txtEmail.Text + "',"
                + "password = '" + pass + "' "
                + "where MaTK = '" + idTK + "'";
            function.RunNonQuery(sql);


            string idNV = dgwNV.CurrentRow.Cells["MaNV"].Value.ToString();
            sql = "update NhanVien set MaNV = "
                + idNV + ","
                + "Ten = N'" + txtTen.Text + "',"
                + "HoLot = N'" + txtHoTenlot.Text + "',"
                + "SDT = '" + txtSDT.Text + "',"
                + "DOB = '" + dtpNgaySinh.Value.Date.ToString("yyyyMMdd") + "',"
                + "DiaChi = '" + txtDiaChi.Text + "',"
                + "CMND = '" + txtCMND.Text + "',"
                + "MaTK = '" + idTK + "'"
                + "where MaNV = " + idNV;
            function.RunNonQuery(sql);
            LoadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string idTK = dgwNV.CurrentRow.Cells["MaTK"].Value.ToString();
            string sql = "delete TaiKhoan where MaTK = '" + idTK + "'";
            function.RunNonQuery(sql);

            string idNV = dgwNV.CurrentRow.Cells["MaNV"].Value.ToString();
            sql = "delete NhanVien where MaNV = '" + idNV + "'";
            function.RunNonQuery(sql);
            LoadDataGridView();
        }
    }
}

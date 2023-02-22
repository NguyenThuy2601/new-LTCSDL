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
    public partial class QLKhachHang : Form
    {
        public QLKhachHang()
        {
            InitializeComponent();
        }

        //private void LoadDataGridView()
        //{
        //    string sql;
        //    sql = "SELECT * FROM KhachHang";
        //    tb = function.GetDataToTable(sql);
        //    dgwListKH.DataSource = tb;
        //    dgwListKH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
        //    dgwListKH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnNhapTTNhanVien_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void QLKhachHang_Load(object sender, EventArgs e)
        //{
        //    LoadDataGridView();
        //}
    }
}

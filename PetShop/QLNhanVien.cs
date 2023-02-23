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
        public QLNhanVien()
        {
            InitializeComponent();
        }

        //private void LoadDataGridView()
        //{
        //    string sql;
        //    sql = "SELECT * FROM NhanVien";
        //    tb = function.GetDataToTable(sql);
        //    dgwListNV.DataSource = tb;
        //    dgwListNV.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
        //    dgwListNV.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void QLNhanVien_Load(object sender, EventArgs e)
        //{
        //    LoadDataGridView();
        //}
    }
}

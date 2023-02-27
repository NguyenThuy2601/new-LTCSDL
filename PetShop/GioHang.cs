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
    public partial class GioHang : Form
    {
        public GioHang()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            string sql = "select ct.MaSP ,sp.TenSp, ct.SoLuong, ct.TamTinh from GioHang gh, ChiTietGioHang ct, SanPham sp"
                        + " where gh.MaGH = ct.MaGH and ct.MaSP = sp.MaSP and gh.MaKH = '"
                        + User.getID() + "'";
            dataGridView1.DataSource = function.GetDataToTable(sql);
        }
        private void GioHang_Load(object sender, EventArgs e)
        {
            this.LoadDataGridView();
            btnDelete.Enabled = false;  
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            lblName.Text = dataGridView1.CurrentRow.Cells["TenSp"].Value.ToString();
            numericUpDown1.Value = decimal.Parse(dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString());
            btnDelete.Enabled = true;
            string sql = "select SoLuong from SanPham where MaSP = '" 
                        + dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString() + "'";
            int max = int.Parse(function.RunQuery(sql));
            numericUpDown1.Maximum = max;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
            int gap = 0;
            string sql = "select MaGH from GioHang where MaKH = '" + User.getID() + "'";
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            int currentQty = int.Parse(dataGridView1.CurrentRow.Cells["SoLuong"]
                             .Value.ToString());
            string idGH = function.RunQuery(sql);

            if (numericUpDown1.Value == 0)
            {
                sql = "DELETE ChiTietGioHang WHERE MaSP = '" + id + "'"
                     + " and MaGH = '" + idGH + "'";
                function.RunNonQuery(sql);
                sql = "update SanPham set SoLuong =" + currentQty
                        + "where MaSP = '" + id + "'";
                function.RunNonQuery(sql);
                lblName.Text = "";
                numericUpDown1.Value = 0;
                this.LoadDataGridView();
                btnDelete.Enabled = false;
            }
            else
            {
                sql = "update ChiTietGioHang set SoLuong = "
                    + numericUpDown1.Value
                    + "where MaSP = '" + id + "'"
                    + " and MaGH = '" + idGH + "'";
                function.RunNonQuery(sql);
                dataGridView1.CurrentRow.Cells["SoLuong"].Value = numericUpDown1.Value;
            }

            if (numericUpDown1.Value > currentQty)
            {
                gap = (int)numericUpDown1.Value - currentQty;
                sql = "update SanPham set SoLuong = SoLuong - " + gap
                       + "where MaSP = '" + id + "'";
            }
            else
            {
                gap = currentQty - (int)numericUpDown1.Value;
                sql = "update SanPham set SoLuong = SoLuong + " + gap
                       + "where MaSP = '" + id + "'";
            }
            function.RunNonQuery(sql);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            string sql = "select MaGH from GioHang where MaKH = '" + User.getID() + "'";
            string idGH = function.RunQuery(sql);
            int currentQty = int.Parse(dataGridView1.CurrentRow.Cells["SoLuong"]
                              .Value.ToString());

            sql = "select SoLuong from SanPham where MaSP = '" + id + "'";
            int remainQty = int.Parse(function.RunQuery(sql));


            sql = "DELETE ChiTietGioHang WHERE MaSP = '" + id + "'"
                    + " and MaGH = '" + idGH + "'";
            function.RunNonQuery(sql);


            sql = "update SanPham set SanPham.SoLuong = " + (remainQty + currentQty)
                       + " where MaSP = '" + id + "'";
            function.RunNonQuery(sql);

            sql = "update GioHang set GioHang.SoLuong = " + (dataGridView1.RowCount - 1)
                   + " where MaGH = '" + idGH + "'";
            function.RunNonQuery(sql);



            lblName.Text = "";
            numericUpDown1.ResetText();
            this.LoadDataGridView();
            btnDelete.Enabled = false;
        }
    }
}

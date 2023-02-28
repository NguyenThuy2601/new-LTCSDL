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
        private int getProductQtyInCart()
        {
            string sql = "select SoLuong from GioHang where MaKH = '" + User.getID() + "'";
            return int.Parse(function.RunQuery(sql));
        }
        private int Total()
        {
            int total = 0;
            if (getProductQtyInCart() > 0)
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    if(row.Cells["TamTinh"].Value != null)
                        total += int.Parse(row.Cells["TamTinh"].Value.ToString());
            return total;
        }
        private void setShipFee()
        {
            if (Total() > 500000)
                lblShip.Text = "0";
            else
                lblShip.Text = (Total() * 0.2).ToString();
        }
        private void setTotal()
        {
            lblTotal.Text = (Total() + int.Parse(lblShip.Text)).ToString();
        }
        private void GioHang_Load(object sender, EventArgs e)
        {
            this.LoadDataGridView();
            btnDelete.Enabled = false;
            setShipFee();
            setTotal();
        }
        int max = 0;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            lblName.Text = dataGridView1.CurrentRow.Cells["TenSp"].Value.ToString();
            lblQty.Text = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            btnDelete.Enabled = true;
            string sql = "select SoLuong from SanPham where MaSP = '" 
                        + dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString() + "'";
            max = int.Parse(function.RunQuery(sql));
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            string sql = "select MaGH from GioHang where MaKH = '" + User.getID() + "'";
            string idGH = function.RunQuery(sql);
            int currentQty = int.Parse(dataGridView1.CurrentRow.Cells["SoLuong"]
                              .Value.ToString());
            sql = "select count(MaSP) from ChiTietGioHang where MaGH = '" + idGH + "'";
            int totalQty = int.Parse(function.RunQuery(sql));


            sql = "DELETE ChiTietGioHang WHERE MaSP = '" + id + "'"
                    + " and MaGH = '" + idGH + "'";
            function.RunNonQuery(sql);


            sql = "update SanPham set SanPham.SoLuong = SoLuong +" + currentQty
                       + " where MaSP = '" + id + "'";
            function.RunNonQuery(sql);

            sql = "update GioHang set GioHang.SoLuong = " + (totalQty - 1)
                   + " where MaGH = '" + idGH + "'";
            function.RunNonQuery(sql);



            lblName.Text = "";
            lblQty.Text = "0";
            this.LoadDataGridView();
            btnDelete.Enabled = false;
            MessageBox.Show(dataGridView1.RowCount.ToString());
            //setShipFee();
            //setTotal();
        }

        private void buttonCustom2_Click(object sender, EventArgs e)
        {
            string sql = "select MaGH from GioHang where MaKH = '" + User.getID() + "'";
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            int currentQty = int.Parse(dataGridView1.CurrentRow.Cells["SoLuong"]
                             .Value.ToString());
            string idGH = function.RunQuery(sql);

            lblQty.Text = (int.Parse(lblQty.Text) - 1).ToString();

            if (lblQty.Text == "0")
            {
                sql = "DELETE ChiTietGioHang WHERE MaSP = '" + id + "'"
                     + " and MaGH = '" + idGH + "'";
                function.RunNonQuery(sql);
                sql = "update SanPham set SoLuong = SoLuong + " + currentQty
                        + "where MaSP = '" + id + "'";
                function.RunNonQuery(sql);
                lblName.Text = "";
                this.LoadDataGridView();
                lblQty.Text = "0";
                btnDelete.Enabled = false;

            }
            else
            {
                sql = "update ChiTietGioHang set SoLuong = "
                    + lblQty.Text
                    + "where MaSP = '" + id + "'"
                    + " and MaGH = '" + idGH + "'";
                function.RunNonQuery(sql);
                dataGridView1.CurrentRow.Cells["SoLuong"].Value = lblQty.Text;
                sql = "update SanPham set SoLuong = SoLuong + " + 1
                       + "where MaSP = '" + id + "'";
                function.RunNonQuery(sql);
            }
            setShipFee();
            setTotal();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string sql = "select MaGH from GioHang where MaKH = '" + User.getID() + "'";
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            int currentQty = int.Parse(dataGridView1.CurrentRow.Cells["SoLuong"]
                             .Value.ToString());
            string idGH = function.RunQuery(sql);

            if ((int.Parse(lblQty.Text) + 1) > max)
                return;
            else
            {
                lblQty.Text = (int.Parse(lblQty.Text) + 1).ToString();

                sql = "update ChiTietGioHang set SoLuong = "
                    + lblQty.Text
                    + "where MaSP = '" + id + "'"
                    + " and MaGH = '" + idGH + "'";
                function.RunNonQuery(sql);
                dataGridView1.CurrentRow.Cells["SoLuong"].Value = lblQty.Text;
                sql = "update SanPham set SoLuong = SoLuong - " + 1
                       + "where MaSP = '" + id + "'";
                function.RunNonQuery(sql);
            }
            setShipFee();
            setTotal();
        }
    }
}

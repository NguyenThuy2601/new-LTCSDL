using PetShop.BUS;
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
        GioHangBUS bus = new GioHangBUS();
        DTO.User user = null;
        public GioHang()
        {
            InitializeComponent();
        }

        public GioHang(DTO.User user) : this()
        {
            bus = new GioHangBUS();
            bus.load();
            this.user = user;
        }

        private void LoadDataGridView()
        {
            
            dataGridView1.DataSource = bus.getCart(user.getID().ToString());
        }
        //private int getProductQtyInCart()
        //{
        //    string sql = "select SoLuong from GioHang where MaKH = '" + User.getID() + "'";
        //    return int.Parse(function.RunQuery(sql));
        //}
        //private int Total()
        //{
        //    int total = 0;
        //    if (bus.getCartQty(User.getID().ToString()) > 0)
        //        foreach (DataGridViewRow row in dataGridView1.Rows)
        //            if(row.Cells["TamTinh"].Value != null)
        //                total += int.Parse(row.Cells["TamTinh"].Value.ToString());
        //    return total;
        //}
        private void setShipFee()
        {
            if (bus.getTamTinh(user.getID().ToString()) > 500000)
                lblShip.Text = "0";
            else
                lblShip.Text = (bus.getTamTinh(user.getID().ToString()) * 0.2).ToString();
        }
        private void setTotal()
        {
              lblTotal.Text = bus.getTamTinh(user.getID().ToString()).ToString();
        }
        private void GioHang_Load(object sender, EventArgs e)
        {
            this.LoadDataGridView();
            btnDelete.Enabled = false;
            setShipFee();
            //setTotal();
        }
        int max = 0;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            lblName.Text = dataGridView1.CurrentRow.Cells["TenSp"].Value.ToString();
            lblQty2.Text = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            btnDelete.Enabled = true;
            //string sql = "select SoLuong from SanPham where MaSP = '" 
            //            + dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString() + "'";
            max = bus.getRemainQty(dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString());
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();

            string idGH = bus.getCartId(User.getID().ToString());

            //sql = "select count(MaSP) from ChiTietGioHang where MaGH = '" + idGH + "'";
            //int totalQty = int.Parse(function.RunQuery(sql));




            //sql = "update GioHang set GioHang.SoLuong = " + (totalQty - 1)
            //       + " where MaGH = '" + idGH + "'";
            //function.RunNonQuery(sql);


            bus.deleteItem(id, idGH);
            lblName.Text = "";
            lblQty2.Text = "0";
            this.LoadDataGridView();
            btnDelete.Enabled = false;
            setShipFee();
            setTotal();
        }

        private void buttonCustom2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            string idGH = bus.getCartId(user.getID().ToString());

            lblQty2.Text = (int.Parse(lblQty2.Text) - 1).ToString();

            if (lblQty2.Text == "0")
            {
                //sql = "DELETE ChiTietGioHang WHERE MaSP = '" + id + "'"
                //     + " and MaGH = '" + idGH + "'";
                //function.RunNonQuery(sql);
                //sql = "update SanPham set SoLuong = SoLuong + " + currentQty
                //        + "where MaSP = '" + id + "'";
                //function.RunNonQuery(sql);
                bus.deleteItem(id, idGH);
                lblName.Text = "";
                lblQty2.Text = "0";
                btnDelete.Enabled = false;

            }
            else
            {
                bus.updateItemQty(id, idGH, lblQty2.Text);
            }
            setShipFee();
            setTotal();
            this.LoadDataGridView();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            string idGH = bus.getCartId(User.getID().ToString());

            if ((int.Parse(lblQty2.Text) + 1) > max)
                return;
            else
            {
                lblQty2.Text = (int.Parse(lblQty2.Text) + 1).ToString();

                bus.updateItemQty(id, idGH, lblQty2.Text);
                //dataGridView1.CurrentRow.Cells["SoLuong"].Value = lblQty.Text;
            }
            this.LoadDataGridView();
            setShipFee();
            setTotal();
        }

       
    }
}

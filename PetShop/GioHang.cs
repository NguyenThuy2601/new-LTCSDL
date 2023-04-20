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
        string idGH = null;
        TrangChuKhachHang mainf = null;
        DataTable dt = null;
        double PhanTramShip = 0.2; 
        public GioHang()
        {
            InitializeComponent();
        }

        public GioHang(DTO.User user, TrangChuKhachHang mainf) : this()
        {
            bus = new GioHangBUS();
            bus.load();
            this.user = user;
            idGH = bus.getCartId(user.getID());
            this.mainf = mainf;
        }

        private void LoadDataGridView()
        {
            dt = bus.getCart(user.getID().ToString());
            dataGridView1.DataSource = dt;
        }

        private void setShipFee()
        {
            if (bus.getTamTinh(user.getID().ToString()) > 500000)
                lblShip.Text = "0";
            else
                lblShip.Text = (bus.getTamTinh(user.getID().ToString()) * PhanTramShip).ToString();
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
            setTotal();
        }
        int max = 0;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            lblName.Text = dataGridView1.CurrentRow.Cells["TenSp"].Value.ToString();
            lblQty2.Text = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            btnDelete.Enabled = true;
            max = bus.getRemainQty(dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString());
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();

            

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

            lblQty2.Text = (int.Parse(lblQty2.Text) - 1).ToString();

            if (lblQty2.Text == "0")
            {
                
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

            if ((int.Parse(lblQty2.Text) + 1) > max)
                return;
            else
            {
                lblQty2.Text = (int.Parse(lblQty2.Text) + 1).ToString();
                bus.updateItemQty(id, idGH, lblQty2.Text);
            }
            this.LoadDataGridView();
            setShipFee();
            setTotal();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count >= 1)
            {
                int sl = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sl = bus.getRemainQty(row["MaSP"].ToString());
                    if (sl < int.Parse(row["SoLuong"].ToString()))
                    {
                        MessageBox.Show("Sản phẩm " + row["TenSp"].ToString()
                            + " số lượng trong kho không đủ đáp ứng");
                        return;
                    }
                }
                mainf.openChildForm(new XacNhanDH(user, idGH, lblShip.Text, lblTotal.Text, PhanTramShip, mainf));
                bus.close();
            }
            else
                return;
           
        }

        private void GioHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }
    }
}

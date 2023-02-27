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
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }

        public SanPham(string id, string pName, string price, string qty, string color, string maKM, string picLink)
        {
            InitializeComponent();
            ID = id;
            setPName(pName);
            setPrice(price);
            setQty(qty);
            setColor(color);
            setPic(picLink);
            if (maKM != null)
            {
                setTxtColor();
                lblDiscount.Visible = true;
                setKmai(maKM);
            }    
            else
            {
                lblDiscount.Visible = false;
            }
            numericUpDown1.Maximum = int.Parse(qty);
            
        }
        public string ID { get; set; }
        public void setPName(string value) 
        {  
            lbTenSp.Text = value; 
        }
        public void setPrice(string value)
        {
            double p = double.Parse(value) * 1000;
            lbGiaTien.Text = p.ToString()  + " VND";
        }
        public void setKmai(string value)
        {
            lblDiscount.Text = value + "%";
        }
        public void setQty(string value)
        {
            lbTonKho.Text = value;
        }
        public void setColor(string value)
        {
            lblColor.Text = value;
        }
        public void setPic(string link)
        {
            picSP.LoadAsync(link);
        }
        public void setTxtColor()
        {
            lbGiaTien.ForeColor = Color.Red;
        }

        public int getSoLuong()
        {
            return int.Parse(lbTonKho.Text);
        }
        
        public int getPrice()
        {
            string[] tam = lbGiaTien.Text.Split(' ');
            return int.Parse(tam[0]) ;
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int price = getPrice();
            int total = price * int.Parse(numericUpDown1.Value.ToString());
            int recentQty = 0;
            int remainQty = this.getSoLuong() - int.Parse(numericUpDown1.Value.ToString());

            MessageBox.Show(total.ToString());

            //lay id gio hang
            string sql = "select MaGH from GioHang where MaKH = '" + User.getID() + "'";
            string GHid = function.RunQuery(sql);

            //them moi vao chi tiet gio hang
            sql = "select MaSP from ChiTietGioHang where MaGH = '"
                    + GHid + "' and MaSP = '" + this.ID + "'";
            if (function.RunQuery(sql) == null)
            {
                sql = "insert into ChiTietGioHang values('"
                + GHid + "','"
                + this.ID + "',"
                + numericUpDown1.Value + ",'"
                + total + "')";

                function.RunNonQuery(sql);
            }
            else
            {
                string idSP = function.RunQuery(sql);
                sql = "update ChiTietGioHang set SoLuong = SoLuong +"
                + numericUpDown1.Value + ", TamTinh = TamTinh +"
                + total
                + "where MaSP ='" + this.ID + "' and MaGH = '" + GHid + "'";
                function.RunNonQuery(sql);
            }

            //cap nhap so luong mon hang trong gio
            sql = "select SoLuong from GioHang where MaGH = '" + GHid + "'";
            recentQty = int.Parse(function.RunQuery(sql));
            recentQty = recentQty + int.Parse(numericUpDown1.Value.ToString());
            sql = "update GioHang set SoLuong ="
                + recentQty
                + " where MaGH = '" + GHid + "'";
            function.RunNonQuery(sql);

            //cap nhap so luong hang ton
            sql = "update SanPham set SoLuong = " + remainQty + "where MaSP = '" + this.ID + "'";
            function.RunNonQuery(sql);

            //reset giao dien 
            lbTonKho.Text = remainQty.ToString();
            numericUpDown1.Value = 0;
        }

        private void SanPham_VisibleChanged(object sender, EventArgs e)
        {
            if (User.getID() == 0)
                btnAddToCart.Visible = false;
            else
                btnAddToCart.Visible = true;
        }
    }
}

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
            lbGiaTien.Text = value + "VND";
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

        private void lbTenSp_Click(object sender, EventArgs e)
        {

        }

        private void lblColor_Click(object sender, EventArgs e)
        {

        }
    }
}

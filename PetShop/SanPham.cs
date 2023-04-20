using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShop.DTO;
using PetShop.DAO;
using PetShop.BUS;

namespace PetShop
{
    public partial class SanPham : Form
    {
        SanPhamBUS bus = null;
        DTO.User user = new DTO.User();


        public SanPham()
        {
            InitializeComponent();
        }
        public SanPham(string id, string pName, string price, int qty, string color, string maKM, string picLink, PetShop.DTO.User user)
        {
           
            InitializeComponent();
            this.user = user;
            ID = id;
            setPName(pName);
            setPrice(price);
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
            numericUpDown1.Maximum = qty;

            if (user.getID() == 0)
                btnAddToCart.Visible = false;
            else
                btnAddToCart.Visible = true;

        }

       


        public string ID { get; set; }
        public void setPName(string value) 
        {  
            lbTenSp.Text = value; 
        }
        public void setPrice(string value)
        {
            lbGiaTien.Text = value + " VND";
        }
        public void setKmai(string value)
        {
            lblDiscount.Text = value + "%";
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

        
        
        public int getPrice()
        {
            string[] tam = lbGiaTien.Text.Split(' ');
            return int.Parse(tam[0]) ;
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            bus = new SanPhamBUS();
            bus.load();
            int price = getPrice();
            int total = price * int.Parse(numericUpDown1.Value.ToString());
            int flag = 0;


            //lay id gio hang
            string cartID = bus.getCartID(user.getID().ToString());
 

            //them moi vao chi tiet gio hang

            if (!bus.checkProductInCart(cartID, this.ID))
                flag = bus.addToCart(cartID, this.ID, numericUpDown1.Value, total);
            else
                flag  = bus.updateProdcutQtyInCart(cartID, this.ID, numericUpDown1.Value, total);
            
            if (flag != 0)
                MessageBox.Show("Thêm vào giỏ hàng thành công");
            else
                MessageBox.Show("Đã có lỗi xảy ra");
            bus.close();
            numericUpDown1.Value = 0;
        }

        private void SanPham_VisibleChanged(object sender, EventArgs e)
        {
            //if (user.getID() == 0)
            //    btnAddToCart.Visible = false;
            //else
            //    btnAddToCart.Visible = true;
        }

        private void SanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }
    }
}

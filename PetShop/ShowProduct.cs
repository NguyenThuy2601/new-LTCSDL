using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShop.BUS;
using PetShop.DTO;

namespace PetShop
{
    public partial class ShowProduct : Form
    {

        ShowProductBUS bus;
        PetShop.DTO.User user;

        public ShowProduct()
        {
            InitializeComponent();
        }

        public ShowProduct(PetShop.DTO.User user) : this()
        {
            this.user = user;
        }

        
    
        private void ShowProduct_Load(object sender, EventArgs e)
        {
            bus = new ShowProductBUS();
            DataTable dt = null;
            dt = bus.load();
            int x = 0, y = 0;
            foreach (DataRow row in dt.Rows)
            {
                string id = row["MaSP"].ToString();
                string pName = row["TenSp"].ToString();
                string color = row["MauSac"].ToString();
                string pic = row["Hinh"].ToString();
                string soLuong = row["SoLuong"].ToString();
                string giaBan = double.Parse(row["GiaBan"].ToString()).ToString();

                string phantram = null;
                if (row["PhanTram"].ToString() != "")
                {

                    double tam = double.Parse(row["PhanTram"].ToString()) * 100;
                    phantram = int.Parse(tam.ToString()).ToString();
                    double percent = double.Parse(row["PhanTram"].ToString());
                    double price = (double.Parse(giaBan) - (double.Parse(giaBan) * percent));
                    giaBan = price.ToString();
                }
                SanPham obj = new SanPham(id, pName, giaBan, soLuong, color, phantram, pic, user);
                obj.TopLevel = false;
                obj.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(obj);
                obj.Show();
                y++;
                if (y >= 2)
                {
                    y = 1;
                    x++;
                }
            }
        }

        private void ShowProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            int signal = bus.close();
        }
    }
}

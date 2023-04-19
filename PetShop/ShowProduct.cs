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

        ShowProductBUS bus = new ShowProductBUS();
        PetShop.DTO.User user;
        String keyword;
        DataTable dt = null;
        bool find = false;

        public ShowProduct()
        {
            InitializeComponent();
        }

        public ShowProduct(PetShop.DTO.User user, String kw, bool find) : this()
        {
            this.user = user;
            keyword = kw;
            this.find = find;
        }

        public void loadProductList()
        {
            if (find == false)
                dt = bus.loadDataTable(keyword);
            else
                dt = bus.findProductByName(keyword);
        }

        private void ShowProduct_Load(object sender, EventArgs e)
        {
            bus.load();                     
            int x = 0, y = 0;
            loadProductList();
            if(dt.Rows.Count > 1)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string id = row["MaSP"].ToString();
                    string pName = row["TenSp"].ToString();
                    string color = row["MauSac"].ToString();
                    string pic = row["Hinh"].ToString();
                    string soLuong = row["SoLuong"].ToString();
                    string giaBan = row["GiaBan"].ToString();

                    string phantram = null;
                    if (row["PhanTram"].ToString() != "")
                    {

                        double tam = double.Parse(row["PhanTram"].ToString()) * 100;
                        phantram = Math.Round(tam).ToString();
                        double percent = double.Parse(row["PhanTram"].ToString());
                        double price = (int.Parse(giaBan) - (int.Parse(giaBan) * percent));
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
            else
            {
                tableLayoutPanel1.Visible = false;
                pb404.Visible = true;
                pb404.BringToFront();
                pb404.LoadAsync(@"https://cdn.dribbble.com/users/88213/screenshots/8560585/media/7263b7aaa8077a322b0f12a7cd7c7404.png?compress=1&resize=400x300");
            }    
        }

        private void ShowProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }
    }
}

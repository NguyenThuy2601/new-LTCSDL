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
    public partial class ShowProduct : Form
    {
        public ShowProduct()
        {
            InitializeComponent();
        }

        //private void tryParse(string v)
        //{
        //    double.
        //}

        private void ShowProduct_Load(object sender, EventArgs e)
        {
            function.Connect();
            int x = 0, y = 0;
            string sql = "select s.*, km.PhanTram " +
                  "from SanPham  as s " +
                  "left join KhuyenMai as km"
                    + " on s.MaKM = km.MaKM";
            DataTable dt = function.GetDataToTable(sql);
            foreach(DataRow row in dt.Rows)
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
                    phantram = int.Parse(tam.ToString()).ToString();
                    double percent = double.Parse(row["PhanTram"].ToString());
                    double price = (double.Parse(giaBan) - (double.Parse(giaBan) * percent)) * 1000;
                    giaBan = price.ToString();
                }
                SanPham obj = new SanPham(id, pName, giaBan, soLuong, color, phantram, pic);
                //SanPham obj = new SanPham();
                obj.TopLevel = false;
                obj.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(obj);
                obj.Show();
                y++;
                if(y >= 2)
                {
                    y = 1;
                    x++;
                }    
            }    
        }

        private void ShowProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            function.Disconnect();
        }
    }
}

using PetShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BUS
{
    public class SanPhamBUS :ModelBUS
    {
        //SQLfunction sQLfunction = null;
        //public void load()
        //{
        //    sQLfunction = new SQLfunction();
        //    sQLfunction.Connect();
        //}
        public string getCartID(string MaKH)
        {
            string sql = "select MaGH from GioHang where MaKH = '" + MaKH + "'";
            string ID = sQLfunction.RunQuery(sql);
            return ID;
        }
        public bool checkProductInCart(string cartID, string pID)
        {
            string sql = "select MaSP from ChiTietGioHang where MaGH = '"
                    + cartID + "' and MaSP = '" + pID + "'";
            if(sQLfunction.RunQuery(sql) == null)
                return false;
            else
                return true;
        }

        public int addToCart(string cartID, string pID, decimal qty, int total)
        {

            string sql = "insert into ChiTietGioHang values("
                        + cartID + ",'"
                        + pID + "',"
                        + qty + ","
                        + total + ")";
            return sQLfunction.RunNonQuery(sql);
        }

        public int updateProdcutQtyInCart(string cartID, string pID, decimal qty, int total)
        {

            string sql = "update ChiTietGioHang set SoLuong = SoLuong +"
                            + qty + ", TamTinh = TamTinh +"
                            + total
                            + " where MaSP ='" + pID + "' and MaGH = " + cartID + "";
            return sQLfunction.RunNonQuery(sql);
        }

        //public void close()
        //{
        //    sQLfunction.Disconnect();
        //}
    }
}

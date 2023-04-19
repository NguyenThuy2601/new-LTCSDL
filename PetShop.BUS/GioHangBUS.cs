using PetShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BUS
{
    public class GioHangBUS :ModelBUS
    {

        //SQLfunction sQLfunction = null;
        //public void load()
        //{
        //    sQLfunction = new SQLfunction();
        //    sQLfunction.Connect();
        //}
        public DataTable getCart(string uID)
        {
            string sql = "select ct.MaSP ,sp.TenSp, ct.SoLuong, ct.TamTinh from GioHang gh, ChiTietGioHang ct, SanPham sp"
                       + " where gh.MaGH = ct.MaGH and ct.MaSP = sp.MaSP and gh.MaKH = '"
                       + uID + "'";
            return sQLfunction.GetDataToTable(sql);
        }
        public string getCartId(int uID)
        {
            string sql = "select MaGH from GioHang where MaKH = '" + uID + "'";
            return sQLfunction.RunQuery(sql);
        }
             
        public int getTamTinh(string uID)
        {
            string sql = "select sum(TamTinh) from GioHang gh, ChiTietGioHang ct"
                           + " where gh.MaGH = ct.MaGH and gh.MaKH = " + uID  ;
            if (sQLfunction.RunQuery(sql) != null || sQLfunction.RunQuery(sql) != "")
                try
                {
                    int.Parse(sQLfunction.RunQuery(sql));
                    return int.Parse(sQLfunction.RunQuery(sql));
                }
                catch
                {
                    return 0;
                }
            return 0;
        }
        public int getRemainQty(string pID)
        {
            string sql = "select SoLuong from SanPham where MaSP = '"
                       + pID + "'";
            return int.Parse(sQLfunction.RunQuery(sql));
        }
        public int deleteItem(String idSP, String idGH)
        {
            String sql = "DELETE ChiTietGioHang WHERE MaSP = '" + idSP + "'"
                         + " and MaGH = '" + idGH + "'";
            return sQLfunction.RunNonQuery(sql);
        }
        public int updateItemQty(String idSP, String idGH, String Qty)
        {
            String sql = "update ChiTietGioHang set SoLuong = "
                        + Qty
                        + " where MaSP = '" + idSP + "'"
                        + " and MaGH = '" + idGH + "'"; 
            return sQLfunction.RunNonQuery(sql);
        }
       
        //public void close()
        //{
        //    sQLfunction.Disconnect();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BUS
{
    public class DHDoiXacNhanBUS :DHDaHuyBUS
    {
        public override DataTable getOrderList()
        {
            string sql = "select * from DonHang where DonHang.TinhTrang = 0";
            return sQLfunction.GetDataToTable(sql);
        }
        public int acceptOrder(String idDH, int uID)
        {
            string sql = "update DonHang set TinhTrang = 1," +
                "MaNV = " + uID + 
                " where MaDH = '" + idDH + "'";
            return sQLfunction.RunNonQuery(sql);
        }
        public int updateproductQty(String idP, String sl)
        {
            string sql = "update SanPham set SoLuong = SoLuong - " + sl 
                        + "where MaSP = '" + idP + "'";
            return sQLfunction.RunNonQuery(sql);
        }
        public int declineOrder(String idDH, int uID)
        {
            string sql = "update DonHang set TinhTrang = 2 " +
                "MaNV = " + uID +
                "where MaDH = '" + idDH + "'";
            return sQLfunction.RunNonQuery(sql);
        }
    }
}

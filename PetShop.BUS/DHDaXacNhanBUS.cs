using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;

namespace PetShop.BUS
{
    public class DHDaXacNhanBUS :DHDaHuyBUS
    {

        public override DataTable getOrderList()
        {
            string sql = "select DonHang.*, concat(NhanVien.HoLot, ' ', NhanVien.Ten) as 'NhanVienPhuTrach' from DonHang" +
                " LEFT JOIN NhanVien ON DonHang.MaNV = NhanVien.MaNV" +
                " where DonHang.TinhTrang = 1"; 
            return sQLfunction.GetDataToTable(sql);
        }
        public int updateOrderStatus(String idDH, int uID, string note)
        {
            string sql= "update DonHang set TinhTrang = 2, " +
                "MaNV = " + uID + ", " +
                "LyDoHuyDon = N'" + note + "'" +
                "where MaDH = '" + idDH + "'";
            return sQLfunction.RunNonQuery(sql);
        }
        public int refill(string pID, string qty)
        {
            string sql = "update SanPham set SoLuong = SoLuong + " + qty
                        + " where MaSP = '" + pID + "'";
            return sQLfunction.RunNonQuery(sql);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;


namespace PetShop.BUS
{
    public class XemChiTietDHBUS :ModelBUS
    {
        //SQLfunction sQLfunction = null;
        //public void load()
        //{
        //    sQLfunction = new SQLfunction();
        //    sQLfunction.Connect();
        //}

        public DataTable getDH(int uID)
        {
            String sql = "select d.MaDH, d.DiaChi, d.NgayDat," +
                " sum(ct.ThanhTien) as ThanhTien, sum(ct.ThanhTien)*d.PhanTramShip as Ship," +
                " sum(ct.ThanhTien) + (sum(ct.ThanhTien) * d.PhanTramShip) as Tong," +
                " case " +
                " when TinhTrang = 0 then N'đang đợi xác nhận'" +
                " when TinhTrang = 1 then N'Được xác nhận'" +
                " else N'Bị hủy'" +
                " end as Status " +
                " from DonHang d, ChiTietDonHang ct" +
                " where d.MaDH = ct.MaDH and d.MaKH = " + uID + 
                " group by d.MaDH, d.DiaChi, d.NgayDat, d.PhanTramShip, d.TinhTrang";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getCTDH(int uID)
        {
            String sql = "select ct.MaDH ,SanPham.TenSp, ct.SoLuong, ct.ThanhTien " +
                " from DonHang dh, ChiTietDonHang ct, SanPham" +
                " where dh.MaDH = ct.MaDH and ct.MaSP = SanPham.MaSP " +
                " and dh.MaKH = '" + uID + "'";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable filterCTDH(String idDH, DataTable dt)
        {
            DataTable tempDT = dt;
            tempDT.DefaultView.RowFilter = string.Format("MaDH = '{0}'", idDH);
            return tempDT;
        }

        //public void close()
        //{
        //    sQLfunction.Disconnect();
        //}
    }
}

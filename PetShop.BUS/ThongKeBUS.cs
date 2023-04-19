using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BUS
{
    public class ThongKeBUS :ModelBUS
    {
        public DataTable getStatisticTable(DateTime ngayBD, DateTime ngayKT)
        {
            String sql = "select CONVERT(VARCHAR(10), dh.NgayDat, 103) AS NgayDat, sum(ct.ThanhTien) as DoanhThu " +
                   "from ChiTietDonHang ct, DonHang dh " +
                   "where ct.MaDH = dh.MaDH and dh.TinhTrang = 1" +
                   " and NgayDat >= '" + ngayBD.Date.ToString("yyyy-MM-dd") + "'" +
                   " and NgayDat <= '" + ngayKT.Date.ToString("yyyy-MM-dd") + "'" +
                   " group by dh.NgayDat";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getPieChartData()
        {
            String sql = "SELECT TOP 5 TenSP, SUM(ct.SoLuong) AS TongSoLuong " +
                    "FROM ChiTietDonHang ct, SanPham sp, DonHang " +
                    "WHERE ct.MaSP = sp.MaSP and DonHang.TinhTrang = 1 and ct.MaDH = DonHang.MaDH" +
                    " GROUP BY TenSP " +
                    " ORDER BY TongSoLuong DESC";
            return sQLfunction.GetDataToTable(sql);
        }

        public String getRevenue(DateTime ngayBD, DateTime ngayKT)
        {
            String sql = "select sum(ThanhTien) as TongDT" +
                " from ChiTietDonHang ct, DonHang dh " +
                " where ct.MaDH = dh.MaDH and dh.TinhTrang = 1 " +
                " and dh.NgayDat >= '" + ngayBD.Date.ToString("yyyy-MM-dd") + "'" +
                " and dh.NgayDat <= '" + ngayKT.Date.ToString("yyyy-MM-dd") + "'";
            return sQLfunction.RunQuery(sql);
        }

        public String getProfit(DateTime ngayBD, DateTime ngayKT)
        {
            String sql = "select sum(ct.ThanhTien -(ct.SoLuong * sp.GiaNhap)) as LoiNhuan " +
                "from ChiTietDonHang ct, DonHang dh, SanPham sp " +
                "where ct.MaDH = dh.MaDH and ct.MaSP = sp.MaSP " +
                "and dh.TinhTrang = 1 " +
                "and dh.NgayDat >= '" + ngayBD.Date.ToString("yyyy-MM-dd") + "'" +
                " and dh.NgayDat <= '" + ngayKT.Date.ToString("yyyy-MM-dd") + "'";
            return sQLfunction.RunQuery(sql);
        }

        public String getTotalOrder(DateTime ngayBD, DateTime ngayKT)
        {
            String sql = "select count(MaDH) as TongDH from DonHang " +
                " where DonHang.TinhTrang = 1 and NgayDat >= '" + ngayBD.Date.ToString("yyyy-MM-dd") + "'" +
                " and NgayDat <= '" + ngayKT.Date.ToString("yyyy-MM-dd") + "'";
            return sQLfunction.RunQuery(sql);
        }

        public String getTotalCus(DateTime ngayBD, DateTime ngayKT)
        {
            String sql = "select count(MaKH) as TongDH from DonHang " +
                " where DonHang.TinhTrang = 1 and NgayDat >= '" + ngayBD.Date.ToString("yyyy-MM-dd") + "'" +
                " and NgayDat <= '" + ngayKT.Date.ToString("yyyy-MM-dd") + "'";
            return sQLfunction.RunQuery(sql);
        }
    }
}

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;

namespace PetShop.BUS
{
    public class DHDaHuyBUS :ModelBUS
    {
        //protected SQLfunction sQLfunction = null;
        //public void load()
        //{
        //    sQLfunction = new SQLfunction();
        //    sQLfunction.Connect();
        //}

        public virtual DataTable getOrderList()
        {
            string sql = "select DonHang.*, concat(NhanVien.HoLot, ' ', NhanVien.Ten) as 'NhanVienPhuTrach' from DonHang" +
                " LEFT JOIN NhanVien ON DonHang.MaNV = NhanVien.MaNV" +
                " where DonHang.TinhTrang = 2";
            return sQLfunction.GetDataToTable(sql);
        }
        public DataTable getOrderDetailList()
        {
            string sql = "select ChiTietDonHang.*, TenSp, SanPham.SoLuong as 'TonKho' from ChiTietDonHang, SanPham" +
                    " where ChiTietDonHang.MaSP = SanPham.MaSP";
            return sQLfunction.GetDataToTable(sql);
        }
        
        public DataTable findOrder(DataTable originalDT, String code)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("MaDH = '{0}'", code);
            return dt;
        }
        //public void close()
        //{
        //    sQLfunction.Disconnect();
        //}
    }
}

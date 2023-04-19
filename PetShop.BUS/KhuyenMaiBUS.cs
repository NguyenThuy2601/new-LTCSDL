using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DTO;

namespace PetShop.BUS
{
    public class KhuyenMaiBUS :ModelBUS
    {
        public DataTable loadKMList()
        {
            String sql = "select MaKM, (PhanTram * 100) as 'PhanTram' " +
                        " from KhuyenMai";
            return sQLfunction.GetDataToTable(sql);
        }
        public DataTable loadProductList()
        {
            String sql = "select MaSP, TenSp, MaKM from SanPham where MaKM IS NOT NULL";
            return sQLfunction.GetDataToTable(sql);
        }

        public double formatPercentToDB(Double percent)
        {
            double x = percent / 100;
            return x;
        }

        public int addKhuyenMai(Discount dc)
        {
            string sql = "insert into KhuyenMai values('" + dc.Id + "',"
                        + dc.Percent + ")";
            return sQLfunction.RunNonQuery(sql);
        }

        public int updateKhuyenMai(Discount dc, string oldID)
        {
            string sql = "update KhuyenMai set MaKM = '" + dc.Id + "', "
                        + "PhanTram = " + dc.Percent + " where MaKM = '" + oldID + "'" ;
            return sQLfunction.RunNonQuery(sql);
        }

        public int deleteKhuyenMai(string ID)
        {
            string sql = "delete KhuyenMai where MaKM = '" + ID + "'";
            return sQLfunction.RunNonQuery(sql);
        }
        public int removeKhuyenMai(string kmID)
        {
            string sql = "update SanPham set MaKM = null where MaKM = '" + kmID + "'";
            return sQLfunction.RunNonQuery(sql);
        }

        public bool checkID(string ID)
        {
            string sql = "select count(MaKM) from KhuyenMai where MaKM = '" + ID + "'";
            int num = int.Parse(sQLfunction.RunQuery(sql));
            if (num == 0)
                return true;
            return false;
        }

        public DataTable finDiscountByID(DataTable originalDT, string id)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("MaKM = '{0}'", id);
            return dt;
        }
    }
}

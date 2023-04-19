using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;
using PetShop.DTO;
using System.Data;

namespace PetShop.BUS
{
    public class QLSPBus :ModelBUS
    {
        //SQLfunction sQLfunction = null;

        List<String> DMCTP = new List<string>() { "K (thức ăn khô)", "U (thức ăn ướt)", "S (Sữa)" };
        List<String> DMCVD = new List<string>() { "L (Lược)", "C (chuồng)", "N (Nệm)", "B (Bát)" };
        List<String> DMCVS = new List<string>() { "T (Sữa tắm)", "M (cát)" };
        List<String> DMCPK = new List<string>() { "V (vòng cổ)" };
        //public void load()
        //{
        //    sQLfunction = new SQLfunction();
        //    sQLfunction.Connect();
        //}

        public List<String> getDMCTP() { return DMCTP; }
        public List<String> getDMCVD() { return DMCVD; }
        public List<String> getDMCVS() { return DMCVS; }
        public List<String> getDMCPK() { return DMCPK; }    

        public string defineDTSDID(string s)
        {
            switch (s)
            {
                case "Chó":
                    return "D";
                case "Mèo":
                    return "C";
                case "Tất cả":
                    return "A";
            }
            return s;
        }

        public string isNull(string str)
        {
            if (str == "" || str == null)
                return "null";
            else return str;
        }

        public string isNullBlank(string str)
        {
            if (str == "" || str == "null")
                return "";
            else return str;
        }
        public string modifyString(string sql, string v)
        {
            if (v != null && v != "null")
                sql += "'" + v + "'";
            else
                if (v != null && v == "null")
                sql += v;
            return sql;

        }

        public DataTable getListSanPham()
        {
            String sql = "select * from SanPham";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable getListKhuyenMai()
        {
            String sql = "select MaKM from KhuyenMai";
            return sQLfunction.GetDataToTable(sql);
        }

        public string convertCodetoCate(string s)
        {
            switch (s)
            {
                case "TP":
                    return "TP (Thực phẩm)";
                case "VD":
                    return "VD (Vật dụng)";
                case "VS":
                    return "VS (Vệ sinh)";
                case "PK":
                    return "PK (Phụ kiện)";
            }
            return null;
        }
        public string convertCodetoChildCate(string s)
        {
            switch (s)
            {
                case "K":
                    return "K (thức ăn khô)";
                case "U":
                    return "U (thức ăn ướt)";
                case "S":
                    return "S (Sữa)";
                case "L":
                    return "L (Lược)";
                case "C":
                    return "C (chuồng)";
                case "N":
                    return "N (Nệm)";
                case "B":
                    return "B (Bát)";
                case "T":
                    return "T (Sữa tắm)";
                case "M":
                    return "M (cát)";
                case "V":
                    return "V (vòng cổ)";
            }
            return null;
        }
        public string convertCodeToDTSDID(string s)
        {
            switch (s)
            {
                case "D":
                    return "Chó";
                case "C":
                    return "Mèo";
                case "A":
                    return "Tất cả";
            }
            return s;
        }

        public string defineChildCategoryID(string s)
        {
            return s.Substring(0, 1);
        }
        
        public int modifyBooleanValue(bool flag)
        {
            if (flag)
                return 1;
            return 0;
        }

        public String generateIDFromOption(String danhMucOption, String doiTuongOption, String danhMucConOption, String code)
        {
            String ID;
            ID = danhMucOption + defineDTSDID(doiTuongOption) 
                + defineChildCategoryID(danhMucConOption) + code;
            return ID;
        }

        public int createProduct(Product p)
        {
            String sql = "INSERT INTO SanPham VALUES('"
                        + p.ID1 + "', N'"
                        + p.Ten1 + "', "
                        + p.SoLuong1 + ", "
                        + p.GiaBan1 + ", "
                        + p.GiaNhap1 + ", ";
            if (p.MauSac != "null")
                sql += "N";
            sql = modifyString(sql, p.MauSac);
            sql += ", ";
            sql = modifyString(sql, p.MaKM);
            sql += ", ";
            sql = modifyString(sql, p.Hinh);
            sql += ", " + modifyBooleanValue(p.TinhTrang) + ")";

            return sQLfunction.RunNonQuery(sql);
        }

        public int updateProduct(Product p, String oldID)
        {
            string sql = "update SanPham set MaSP = '"
                          + p.ID1 + "',"
                          + "TenSp = " + "N'" + p.Ten1 + "',"
                                  + "SoLuong = " + p.SoLuong1 + ","
                                  + "GiaBan = " + p.GiaBan1 + ","
                                  + "GiaNhap = " + p.GiaNhap1 + ","
                                  + "MauSac = ";
            if (p.MauSac != "null")
                sql += "N";
            sql = modifyString(sql, p.MauSac);
            sql += ", MaKM = ";
            sql = modifyString(sql, p.MaKM);
            sql += ", Hinh = ";
            sql = modifyString(sql, p.Hinh);
            sql += ", TinhTrang = " + modifyBooleanValue(p.TinhTrang) + "where MaSP = '" + oldID + "'";

            return sQLfunction.RunNonQuery(sql);


        }

        public int deleteProduct(String id)
        {
            string sql = "DELETE SanPham WHERE MaSP='" + id + "'";
            return sQLfunction.RunNonQuery(sql);
        }

        public DataTable findProductByCode(DataTable originalDT,String code)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("MaSP = '{0}'", code);
            return dt;
        }

        public DataTable findProductByName(DataTable originalDT, String name)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("TenSp like '%{0}%'", name);
            return dt;
        }
        //public void close()
        //{
        //    sQLfunction.Disconnect();
        //}
    }
}

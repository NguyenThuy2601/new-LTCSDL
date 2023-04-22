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
    public class QLKHBUS :ModelBUS
    {
        
        public bool authorization(string ID)
        {
            if (ID.Contains("QL"))
                return true;
            return false;
        }

        public DataTable loadKHList()
        {
            String sql = "select kh.*, tk.email from KhachHang kh, TaiKhoan tk where kh.MaTK = tk.MaTK";
            return sQLfunction.GetDataToTable(sql);
        }

        public DataTable findCusByName(DataTable originalDT, String name)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("Ten like '%{0}%'", name);
            return dt;  
        }

        public DataTable findCusByEmail(DataTable originalDT, String email)
        {
            DataTable dt = originalDT;
            dt.DefaultView.RowFilter = string.Format("Email = '{0}'", email);
            return dt;
        }

        public int updateCusAccount(Account ac)
        {
            string sql = "update TaiKhoan set email = '" + ac.Email + "'";
            if (ac.Password != "")
                sql += ",password = '" + CommonFunction.Encrypt(ac.Password) + "' ";
            sql += "where MaTK = '" + ac.Id + "'";
            return sQLfunction.RunNonQuery(sql);
        }
        public int updateCusIfno(KhachHang kh)
        {
            string sql = "update KhachHang set Ten = N'" + kh.ten + "', "
                + "HoLot = N'" + kh.hoLot + "', "
                + "SDT = '" + kh.sDT + "', "
                + "DiaChi = '" + kh.diaChi + "', "
                + "DOB = '" + kh.Dob + "'"
                + " where MaKH = " + kh.Id;

            return sQLfunction.RunNonQuery(sql);
        }

        
    }
}

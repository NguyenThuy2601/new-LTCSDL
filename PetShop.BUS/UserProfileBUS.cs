using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DTO;

namespace PetShop.BUS
{
    public class UserProfileBUS :ModelBUS
    {
        public KhachHang GetKhachHangInfo(int ID)
        {
            string sql = "select * from KhachHang where MaKH = " + ID;
            DataTable dt = sQLfunction.GetDataToTable(sql);
            KhachHang kh = new KhachHang();
            foreach(DataRow r in dt.Rows)
            {
                kh.hoLot = r["HoLot"].ToString();
                kh.ten = r["Ten"].ToString();
                kh.Dob = DateTime.Parse( r["DOB"].ToString());
                kh.sDT = r["SDT"].ToString();
                kh.diaChi = r["DiaChi"].ToString();
                
            }
            return kh;
        }

        public Account GetAccountInfo(string accID)
        {
            string sql = "select * from TaiKhoan where MaTK = '" + accID + "'";
            DataTable dt = sQLfunction.GetDataToTable(sql);
            Account ac  = new Account();
            foreach (DataRow r in dt.Rows)
            {
               ac.Email = r["email"].ToString();
               ac.Password = r["password"].ToString();  
            }
            return ac;
        }

        public int updateUserInfo(KhachHang kh, int idKH)
        {
            string sql = "update KhachHang set " +
                         "Ten = N'" + kh.ten + "'" +
                         " ,HoLot = N'" + kh.hoLot + "'" +
                         " ,SDT = '" + kh.sDT + "'" +
                         " ,DiaChi = N'" + kh.diaChi + "'" +
                         " ,DOB = '" + kh.Dob.ToString("yyyy-MM-dd") + "'" +
                         " where MaKH =" + idKH;

            return sQLfunction.RunNonQuery(sql);
        }
        public int checkExistingEmail(string email)
        {
            string sql = "select count(MaTK) from TaiKhoan where email = '" + email + "'";
            return int.Parse(sQLfunction.RunQuery(sql));
        }
        public int updateEmail(Account ac, string idAcc)
        {
            string sql = "update TaiKhoan set email = '" + ac.Email + "'" +
                         " where MaTK = '" + idAcc + "'";
            return sQLfunction.RunNonQuery(sql);
        }
        public int updatePass(Account ac, string idAcc)
        {
            string sql = "update TaiKhoan set password = '" + ac.Password + "'" +
                         " where MaTK = '" + idAcc + "'";
            return sQLfunction.RunNonQuery(sql);
        }
    }
}

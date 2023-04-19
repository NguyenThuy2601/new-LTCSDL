using PetShop.DAO;
using PetShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BUS
{
    public class DangKyBUS :ModelBUS
    {
        
        public bool checkEmail(string email)
        {
            string sql = "select MaTK from TaiKhoan where email = '" + email + "'";
            if (sQLfunction.RunQuery(sql) != null)
                return false;
            else
                return true;
        }
        public int countNumOCus()
        {
            string sql = "select count (MaTK) from TaiKhoan where SUBSTRING(MaTK,1,2) = 'KH'";
            return int.Parse(sQLfunction.RunQuery(sql)) + 1;
        }
        public string createCusAccId()
        {
            int numOCus = countNumOCus();
            int num = 1000 + numOCus;
            string TKid = "KH" + num.ToString().Substring(1);
            return TKid;
        }

        public int createCusAcc(Account ac)
        {
            string sql = "insert into TaiKhoan values ('" + ac.Id + "','" + ac.Email + "','"
                                    + ac.Password + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public int createCusInfo(KhachHang khach)
        {
            string sql = "insert into KhachHang values('" + khach.Id + "',N'"
                                + khach.ten + "',N'"
                                + khach.hoLot + "','"
                                + khach.sDT + "',N'"
                                + khach.diaChi + "','"
                                + khach.AccID1 + "','"
                                + khach.Dob + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public int createCartForCus(int id)
        {
            string sql = "insert into GioHang(MaKH) values('" + id + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        
    }
}

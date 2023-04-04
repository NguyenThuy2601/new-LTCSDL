using PetShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BUS
{
    public class DangKyBUS
    {
        SQLfunction sQLfunction = null;
        public void load()
        {
            sQLfunction = new SQLfunction();
            sQLfunction.Connect();
        }
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

        public int createCusAcc(string ID, string pass, string email)
        {
            string sql = "insert into TaiKhoan values ('" + ID + "','" + email + "','"
                                    + pass + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public int createCusInfo(int id ,string Fname, string Lname, string sdt, string address,string accID, DateTime dob)
        {
            string sql = "insert into KhachHang values('" + id + "',N'"
                                + Fname + "',N'"
                                + Lname + "','"
                                + sdt + "',N'"
                                + address + "','"
                                + accID + "','"
                                + dob + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public int createCartForCus(int id)
        {
            string sql = "insert into GioHang(MaKH) values('" + id + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public void close()
        {
            sQLfunction.Disconnect();
        }
    }
}

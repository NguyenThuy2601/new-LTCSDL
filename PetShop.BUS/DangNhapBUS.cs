using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;

namespace PetShop.BUS
{
    public class DangNhapBUS
    {
        SQLfunction sQLfunction = null;
        public void load()
        {
            sQLfunction = new SQLfunction();
            sQLfunction.Connect();
        }
        public string getPass(string email)
        {
            string sql = "select password from TaiKhoan where email ='" + email + "'";
            return sQLfunction.RunQuery(sql);
        }
        public string getAcc(string email)
        {
            string sql = "select MaTK from TaiKhoan where email ='" + email + "'";
            return sQLfunction.RunQuery(sql);
        }
        public string Encrypt(string v)
        {
            using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding uTF8 = new UTF8Encoding();
                byte[] data = mD5.ComputeHash(uTF8.GetBytes(v));
                return Convert.ToBase64String(data);
            }
        }
        public DataTable getKHByAccID(string accID)
        {
            string sql = "select MaKH, Ten from KhachHang where MaTK ='" + accID + "'";
            return sQLfunction.GetDataToTable(sql);
        }
        public void close()
        {
            sQLfunction.Disconnect();
        }
    }
}

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DTO;

namespace PetShop.BUS
{
    public class EmplBus :ModelBUS
    {
        public Empl getCurrentEmpl(int id)
        {
            string sql = "select MaNV, HoLot, Ten, DOB, SDT, email from NhanVien nv, TaiKhoan tk " +
                          "where nv.MaTK = tk.MaTK and MaNV = " + id;
            DataTable dt =  sQLfunction.GetDataToTable(sql);
            Empl e = new Empl();
            foreach(DataRow r in dt.Rows)
            {
                e.ID1 = int.Parse(r["MaNV"].ToString());
                e.HoLot1 = r["HoLot"].ToString();
                e.Ten1 = r["Ten"].ToString();
                e.DOB1 = DateTime.Parse(r["DOB"].ToString());
                e.SDT1 = r["SDT"].ToString();
                e.Email = r["email"].ToString();
            }    
            return e;
        }
        public string getPass(string accID)
        {
            string sql = "select password from TaiKhoan where MaTK = '" + accID + "'";
            return sQLfunction.RunQuery(sql);
        }
        public bool authorization(string inputPass, string accID)
        {
            String pass = getPass(accID);
            if(pass.Equals(CommonFunction.Encrypt(inputPass)))
                return true;
            return false;
        }

        public int updatePass(string newPass, string accID)
        {
            string sql = "update TaiKhoan set password = '" + newPass + "'" +
                         " where MaTK = '" + accID + "'";
            return sQLfunction.RunNonQuery(sql);
        }
    }
}

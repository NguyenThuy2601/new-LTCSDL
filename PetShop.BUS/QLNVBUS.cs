using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DTO;

namespace PetShop.BUS
{
    public class QLNVBUS :ModelBUS
    {
        public DataTable getEmplList()
        {
            string sql =  "select nv.*, tk.email " +
                    "from NhanVien nv, TaiKhoan tk where nv.MaTK = tk.MaTK";
            return sQLfunction.GetDataToTable(sql);
        }
        public bool authorization(string ID)
        {
            if(ID.Contains("QL"))
                return true;
            return false;
        }
        public int getNumOfEmpl()
        {
            string sql = "select count (MaTK) from TaiKhoan where SUBSTRING(MaTK,1,2) = 'NV'";
            return int.Parse(sQLfunction.RunQuery(sql));
        }

        public String generateEmplAccID()
        {
            int stt = 1000 + (getNumOfEmpl() + 1);
            String accID = "NV" + stt.ToString().Substring(1);
            return accID;
        }

        public int insertTaiKhoan(Account account)
        {
            String sql = "insert into TaiKhoan values('"
                        + account.Id + "','"
                        + account.Email + "','"
                        + account.Password + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public int insertNhanVien(Empl empl)
        {
            String sql = "insert into NhanVien(Ten, HoLot, SDT, DOB, DiaChi, CMND, MaTK) " +
                "values(N'" + empl.Ten1 + "',"
                + "N'" + empl.HoLot1 + "','"
                + empl.SDT1 + "','"
                + empl.DOB1 + "','"
                + empl.DiaChi1 + "','"
                + empl.CMND1 + "','"
                + empl.AccID1 + "')";
            return sQLfunction.RunNonQuery(sql);
        }

        public int updateTaiKhoan(Account ac)
        {
            string sql = "update TaiKhoan set email = '" + ac.Email + "'";
            if (ac.Password != "")
                sql += ", password = '" + CommonFunction.Encrypt(ac.Password) + "' ";
            sql +=  "where MaTK = '" + ac.Id + "'";
            return sQLfunction.RunNonQuery(sql);
        }

        public int updateNhanVien(Empl empl)
        {
            string sql = "update NhanVien set Ten = N'" + empl.Ten1 + "',"
                + "HoLot = N'" + empl.HoLot1 + "',"
                + "SDT = '" + empl.SDT1 + "',"
                + "DOB = '" + empl.DOB1 + "',"
                + "DiaChi = '" + empl.DiaChi1 + "',"
                + "CMND = '" + empl.CMND1 + "',"
                + "MaTK = '" + empl.AccID1 + "'"
                + "where MaNV = " + empl.ID1;
            return sQLfunction.RunNonQuery(sql);
        }

        public int deleteNhanVien(String IDEmpl)
        {
            string sql = "delete NhanVien where MaNV = " + IDEmpl;
            return sQLfunction.RunNonQuery(sql);
        }

        public int deleteAccount(String idTK)
        {
            string sql = "delete TaiKhoan where MaTK = '" + idTK + "'";
            return sQLfunction.RunNonQuery(sql);
        }
    }
}

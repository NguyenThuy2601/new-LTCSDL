using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;

namespace PetShop.BUS
{
    public class ShowProductBUS :ModelBUS
    {
        
        public DataTable loadDataTable(String kw)
        {           
                String[] temp = kw.Split(',');
                string sql = "select  s.*, km.PhanTram " +
                         "from SanPham  as s " +
                         "left join KhuyenMai as km"
                           + " on s.MaKM = km.MaKM"
                           + " where s.MaSP like '" + temp[0] + "%'";
                if(temp.Length > 1)
                    for(int i = 1; i < temp.Length; i++)
                        sql += " or s.MaSP like '" + temp[i] + "%'"; 
                return sQLfunction.GetDataToTable(sql);  
        }

        public DataTable findProductByName(String kw)
        {
            String[] temp = kw.Split(' ');
            string sql = "select  s.*, km.PhanTram " +
                     "from SanPham  as s " +
                     "left join KhuyenMai as km"
                       + " on s.MaKM = km.MaKM"
                       + " where  UPPER(s.TenSp) like '%" + temp[0].ToUpper() + "%'";
            if (temp.Length > 1)
                for (int i = 1; i < temp.Length; i++)
                    sql += " or UPPER(s.TenSp) like '%" + temp[i].ToUpper() + "%'";
            return sQLfunction.GetDataToTable(sql);
        }

        
    }
}

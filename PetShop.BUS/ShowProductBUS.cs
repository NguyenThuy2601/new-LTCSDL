using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;

namespace PetShop.BUS
{
    public class ShowProductBUS
    {
        SQLfunction sQLfunction = null;
        public DataTable load()
        {
            sQLfunction = new SQLfunction();
            if (sQLfunction.Connect() == 1)
            {
                string sql = "select top 10 s.*, km.PhanTram " +
                         "from SanPham  as s " +
                         "left join KhuyenMai as km"
                           + " on s.MaKM = km.MaKM";
                return sQLfunction.GetDataToTable(sql);
            }    
           return null;
        }

        public int close()
        {
             return sQLfunction.Disconnect();
        }
    }
}

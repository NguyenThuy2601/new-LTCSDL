using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;


namespace PetShop.BUS
{
    public class ModelBUS
    {
        SQLfunction SQLfunction = null;

        public SQLfunction sQLfunction { get => SQLfunction;}

        public void load()
        {
            SQLfunction = new SQLfunction();
            SQLfunction.Connect();
        }
        public void close()
        {
            SQLfunction.Disconnect();
        }
    }
}

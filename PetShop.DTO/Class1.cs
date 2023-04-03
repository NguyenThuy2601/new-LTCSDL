using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DTO
{
    public class Class1
    {
        public class User
        {

            private int Id;
            private string Name;
            private string AccountId;

            public User()
            {
                Id = 0;
                Name = null;
                AccountId = null;
            }
            public User(int id, string name, string accID)
            {
                Id = id;
                Name = name;
                AccountId = accID;
            }
            public int getID() { return Id; }
            public string getName() { return Name; }
            public string getAccountId() { return AccountId; }
            public void setUserInfo(int id, string name, string account)
            {
                Id = id;
                Name = name;
                AccountId = account;
            }
        }
}

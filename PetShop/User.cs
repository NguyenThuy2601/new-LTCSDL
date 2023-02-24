using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    internal static class User
    {
        private static int Id = 0;
        private static string Name = "null";
        private static string AccountId = "null";
        public static int getID() { return Id; }
        public static string getName() { return Name; }
        public static string getAccountId() { return AccountId; }
        public static void setUserInfo(int id, string name, string account) 
        { 
            Id = id;
            Name = name;    
            AccountId = account;
        }

    }
}

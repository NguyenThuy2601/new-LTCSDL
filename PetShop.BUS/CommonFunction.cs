using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BUS
{
    public class CommonFunction
    {
        public static string Encrypt(string v)
        {
            using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding uTF8 = new UTF8Encoding();
                byte[] data = mD5.ComputeHash(uTF8.GetBytes(v));
                return Convert.ToBase64String(data);
            }
        }
    }
}

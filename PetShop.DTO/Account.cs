using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DTO
{
    public class Account
    {
        private String id;
        private String email;
        private String password;

        public Account()
        {
        }

        public Account(string id, string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
        }

        public string Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}

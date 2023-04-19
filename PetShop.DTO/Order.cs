using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PetShop.DTO
{
    public class Order
    {
        private String ID;
        private int tinhTrang;
        private String DiaChi;
        private int userID;
        private double ship;

        public string Id { get => ID; set => ID = value; }
        public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string Diachi { get => DiaChi; set => DiaChi = value; }
        public int UserID { get => userID; set => userID = value; }
        public double Ship { get => ship; set => ship = value; }

        private String generateID()
        {
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();
            String [] temp = myuuidAsString.Split('-');

            return temp[0] + "-" + temp[1];
        }
        public Order(string diaChi, int userID, double ship)
        {
            ID = generateID();
            DiaChi = diaChi;
            this.userID = userID;
            tinhTrang = 0;
            this.ship = ship;
        }

       
    }
}

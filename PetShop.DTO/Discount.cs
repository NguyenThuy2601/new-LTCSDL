using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DTO
{
    public class Discount
    {
        private String id;
        private double percent;

        public Discount(string id, double percent)
        {
            this.id = id;
            this.percent = percent;
        }

        public string Id { get => id;}
        public double Percent { get => percent;}
    }
}

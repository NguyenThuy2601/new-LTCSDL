using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DTO
{
    public class OderDetails
    {
        private String ID;
        private String pID;
        private int SoLuong;
        private int thanhTien;

        public OderDetails(string iD, string pID, int soLuong, int thanhTien)
        {
            ID = iD;
            this.pID = pID;
            SoLuong = soLuong;
            this.thanhTien = thanhTien;
        }

        public string id { get => ID; set => ID = value; }
        public string PID { get => pID; set => pID = value; }
        public int soLuong { get => SoLuong; set => SoLuong = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}

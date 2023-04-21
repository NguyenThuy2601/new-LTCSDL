using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DTO
{
    public class Empl
    {
        private int ID;
        private String HoLot;
        private String Ten;
        private String CMND;
        private DateTime DOB;
        private String SDT;
        private String DiaChi;
        private String AccID;
        private String email;

        public int ID1 { get => ID; set => ID = value; }
        public string HoLot1 { get => HoLot; set => HoLot = value; }
        public string Ten1 { get => Ten; set => Ten = value; }
        public string CMND1 { get => CMND; set => CMND = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string AccID1 { get => AccID; set => AccID = value; }
        public string Email { get => email; set => email = value; }

        public Empl(int iD, string hoLot, string ten, string cMND, DateTime dOB, string sDT, string diaChi, string accID)
        {
            ID = iD;
            HoLot = hoLot;
            Ten = ten;
            CMND = cMND;
            DOB = dOB;
            SDT = sDT;
            DiaChi = diaChi;
            AccID = accID;
        }

        public Empl(string hoLot, string ten, string cMND, DateTime dOB, string sDT, string diaChi, string accID)
        {
            HoLot = hoLot;
            Ten = ten;
            CMND = cMND;
            DOB = dOB;
            SDT = sDT;
            DiaChi = diaChi;
            AccID = accID;
        }

        public Empl()
        {
        }

        
    }
}

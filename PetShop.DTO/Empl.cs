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

        public string HoLot1 { get => HoLot; }
        public string Ten1 { get => Ten; }
        public string CMND1 { get => CMND;}
        public DateTime DOB1 { get => DOB;}
        public string SDT1 { get => SDT;}
        public string DiaChi1 { get => DiaChi;}
        public string AccID1 { get => AccID;}
        public int ID1 { get => ID;}
    }
}

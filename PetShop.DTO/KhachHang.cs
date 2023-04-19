using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DTO
{
    public class KhachHang
    {
        private int id;
        private DateTime dob;
        String HoLot;
        String Ten;
        String SDT;
        String DiaChi;
        String AccID;

        public KhachHang()
        {
        }

        public KhachHang(int id, DateTime dob, string hoLot, string ten, string sDT, string diaChi)
        {
            this.id = id;
            this.dob = dob;
            this.HoLot = hoLot;
            this.Ten = ten;
            this.SDT = sDT;
            this.DiaChi = diaChi;
        }

        public KhachHang(int id, DateTime dob, string hoLot, string ten, string sDT, string diaChi, string accID)
        {
            this.id = id;
            this.dob = dob;
            this.HoLot = hoLot;
            this.Ten = ten;
            this.SDT = sDT;
            this.DiaChi = diaChi;
            AccID = accID;
        }

        public KhachHang(string hoLot, string ten, string sDT, string diaChi)
        {
            HoLot = hoLot;
            Ten = ten;
            SDT = sDT;
            DiaChi = diaChi;
        }

        public string hoLot { get => HoLot; set => HoLot = value; }
        public string ten { get => Ten; set => Ten = value; }
        public string sDT { get => SDT; set => SDT = value; }
        public string diaChi { get => DiaChi; set => DiaChi = value; }
        public int Id { get => id; set => id = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string AccID1 { get => AccID; set => AccID = value; }
    }
}

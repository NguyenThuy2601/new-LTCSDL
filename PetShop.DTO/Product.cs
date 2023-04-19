using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DTO
{
    public class Product
    {
        String ID;
        String Ten;
        int SoLuong;
        decimal GiaBan;
        decimal GiaNhap;
        String mauSac;
        String maKM;
        String hinh;
        bool tinhTrang;

        public Product(string iD, string ten, 
                int soLuong, decimal giaBan, 
                decimal giaNhap, string mauSac,
                string maKM, string hinh, bool tinhTrang)
        {
            ID = iD;
            Ten = ten;
            SoLuong = soLuong;
            GiaBan = giaBan;
            GiaNhap = giaNhap;
            this.mauSac = mauSac;
            this.maKM = maKM;
            this.hinh = hinh;
            this.tinhTrang = tinhTrang;
        }

        public string ID1 { get => ID; set => ID = value; }
        public string Ten1 { get => Ten; set => Ten = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public decimal GiaBan1 { get => GiaBan; set => GiaBan = value; }
        public decimal GiaNhap1 { get => GiaNhap; set => GiaNhap = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string MaKM { get => maKM; set => maKM = value; }
        public string Hinh { get => hinh; set => hinh = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
    }
}

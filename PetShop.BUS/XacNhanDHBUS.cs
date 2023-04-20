using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.DAO;
using PetShop.DTO;

namespace PetShop.BUS
{
    public class XacNhanDHBUS :ModelBUS
    {
        //SQLfunction sQLfunction = null;
        //public void load()
        //{
        //    sQLfunction = new SQLfunction();
        //    sQLfunction.Connect();
        //}

        public DataTable getCartDetail(String idGH)
        {
            String sql = "select * from ChiTietGioHang where MaGH = " + idGH;
            return sQLfunction.GetDataToTable(sql);
        }
        
        public KhachHang getUserDetail(int uID)
        {
            String sql = "select * from KhachHang where MaKH = " + uID;
            DataTable dt = sQLfunction.GetDataToTable(sql);
            KhachHang kh = new KhachHang();
            foreach (DataRow row in dt.Rows)
            {
                kh.hoLot = row["HoLot"].ToString();
                kh.ten = row["Ten"].ToString();
                kh.sDT = row["SDT"].ToString();
                kh.diaChi = row["DiaChi"].ToString();
            }
            return kh;
        } 
        
        public int updateKhachHangInfo(KhachHang kh, int uID)
        {
            String sql = "update KhachHang set " 
                           + " SDT = '" + kh.sDT + "'"
                           + " where MaKH = " + uID;
            return sQLfunction.RunNonQuery(sql);
        }

        public int createOrder(Order od)
        {
            String sql = String.Format("insert into DonHang " +
                "                   values('{0}',getdate(),{1},N'{2}',{3},{4},{5},{6})",
                          od.Id, od.TinhTrang, od.Diachi, "null", od.UserID, od.Ship, "null");
            return sQLfunction.RunNonQuery(sql);
        }

        public int createOrderDetai(OderDetails oderDetails)
        {
            String sql = String.Format("insert into ChiTietDonHang " +
                                        "values('{0}','{1}',{2},{3})",
                                      oderDetails.id, oderDetails.PID, 
                                      oderDetails.soLuong, oderDetails.ThanhTien);
            return sQLfunction.RunNonQuery(sql);
        }

        public int clearCartDetail(String cartID)
        {
            String sql = "delete ChiTietGioHang where MaGH = '" + cartID + "'";
            return sQLfunction.RunNonQuery(sql);
        }

        public int setCartQty(String cartID)
        {
            String sql = "update GioHang set SoLuong = 0 where MaGH = '" + cartID + "'";
            return sQLfunction.RunNonQuery(sql);   
        }

        //public void close()
        //{
        //    sQLfunction.Disconnect();
        //}
    }
}

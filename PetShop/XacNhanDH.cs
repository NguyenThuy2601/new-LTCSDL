using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShop.DTO;
using PetShop.BUS;

namespace PetShop
{
    public partial class XacNhanDH : Form
    {

        TrangChuKhachHang mainf = null;
        public XacNhanDH()
        {
            InitializeComponent();
        }
        DTO.User user = null;
        String cartID = null;
        XacNhanDHBUS bus = null;
        KhachHang kh = null;
        DataTable dt;
        double phanTramShip = 0;


        public XacNhanDH(DTO.User user, String idGH, String shipFee, String total, double ship, TrangChuKhachHang mainf) : this()
        {
            bus = new XacNhanDHBUS();
            bus.load();
            this.user = user;
            this.cartID = idGH;
            this.mainf = mainf;
            phanTramShip = ship;
            lbThanhTien.Text = total;
            lbPhiVC.Text = shipFee;
            lbTongTien.Text = (int.Parse(total) + int.Parse(shipFee)).ToString();
        }
        
        public void setReadOnlyStatus(bool flag)
        {
            if(flag == true)
            {
 
                txtSDT.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
            }
            else
            {
                
                txtSDT.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
            }
        }
        public void loadCusInfo(KhachHang kh)
        {
            txtHoTenlot.Text = kh.hoLot;
            txtTen.Text = kh.ten;
            txtSDT.Text = kh.sDT;
        }
        private void XacNhanDH_Load(object sender, EventArgs e)
        {
            kh = bus.getUserDetail(user.getID());

            loadCusInfo(kh);
            dt = bus.getCartDetail(cartID);
            txtDiaChi.Text = kh.diaChi;
            dgwDHXN.DataSource = dt;
        }

        private void pnNhapTTNhanVien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void editInfoBtn_Click(object sender, EventArgs e)
        {
            if(editInfoBtn.Tag.ToString() == "0")
            {
                editInfoBtn.Text = "OK";
                editInfoBtn.Tag = "1";
                setReadOnlyStatus(true);
            }
            else
            {
                kh.sDT = txtSDT.Text;

                if (bus.updateKhachHangInfo(kh, user.getID()) > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    loadCusInfo(kh);
                }                       
                else
                    MessageBox.Show("Đã có lỗi vui lòng thử lại");

                setReadOnlyStatus(false);
                editInfoBtn.Tag = "0";
                editInfoBtn.Text = "Sửa thông tin";
            }    
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            Order od = new Order(txtDiaChi.Text, user.getID(), phanTramShip);
            if (bus.createOrder(od) > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    String total = row["TamTinh"].ToString();
                    OderDetails dt = new OderDetails(od.Id, row["MaSP"].ToString(),
                                                      int.Parse(row["SoLuong"].ToString()),
                                                      int.Parse(total));
                    bus.createOrderDetai(dt);
                }
                MessageBox.Show("Tạo đơn thành công");
                bus.clearCartDetail(cartID);
                bus.setCartQty(cartID);
                mainf.openChildForm(new XemChiTietDH(user));
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PetShop
{
    public partial class DoanhThu : Form
    {
        DataTable tb;
        public DoanhThu()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select CONVERT(VARCHAR(10), dh.NgayDat, 103) AS NgayDat, sum(ct.ThanhTien) as DoanhThu " +
                   "from ChiTietDonHang ct, DonHang dh " +
                   "where ct.MaDH = dh.MaDH and day(dh.NgayDat) >= " + dtpNgayBD.Value.Day +
                   " and day(dh.NgayDat) <= " + dtpNgayKT.Value.Day +
                   " and MONTH(dh.NgayDat) >= " + dtpNgayBD.Value.Month +
                   " and MONTH(dh.NgayDat) <= " + dtpNgayKT.Value.Month +
                   " group by dh.NgayDat";
            tb = function.GetDataToTable(sql);
            chartDoanhThu.DataSource = tb;


            chartDoanhThu.ChartAreas.Add(new ChartArea("ChartAreas1"));
            chartDoanhThu.ChartAreas["ChartAreas1"].AxisX.Title = "Ngày đặt hàng";
            chartDoanhThu.ChartAreas["ChartAreas1"].AxisY.Title = "Doanh Thu";
            chartDoanhThu.ChartAreas["ChartAreas1"].AxisX.Interval = 1;
            chartDoanhThu.ChartAreas["ChartAreas1"].AxisY.MajorGrid.LineColor = Color.LightGray;

            chartDoanhThu.Series["Doanh Thu"].XValueMember = "NgayDat";
            chartDoanhThu.Series["Doanh Thu"].YValueMembers = "DoanhThu";

            //Biểu đồ hình tròn
            sql = "SELECT TOP 5 TenSP, SUM(ct.SoLuong) AS TongSoLuong " +
                "FROM ChiTietDonHang ct, SanPham sp " +
                "WHERE ct.MaSP = sp.MaSP " +
                "GROUP BY TenSP " +
                "ORDER BY TongSoLuong DESC";
            DataTable dt = function.GetDataToTable(sql);

            // Thiết lập thuộc tính cho biểu đồ
            chart2.Titles.Add("Top 5 sản phẩm bán chạy");
            chart2.Series[0].ChartType = SeriesChartType.Pie;
            chart2.Series[0].IsValueShownAsLabel = true;
            chart2.Series[0].LabelFormat = "#.##%";

            // Thiết lập dữ liệu cho biểu đồ
            foreach (DataRow dr in dt.Rows)
            {
                chart2.Series[0].Points.AddXY(dr["TenSP"].ToString(), dr["TongSoLuong"]);
            }


            //Tổng doanh thu
            sql = "select sum(ThanhTien) as TongDT from ChiTietDonHang ct, DonHang dh " +
                " where ct.MaDH = dh.MaDH " +
                " and day(dh.NgayDat) >= " + dtpNgayBD.Value.Day +
                " and day(dh.NgayDat) <= " + dtpNgayKT.Value.Day +
                " and MONTH(dh.NgayDat) >= " + dtpNgayBD.Value.Month +
                " and MONTH(dh.NgayDat) <= " + dtpNgayKT.Value.Month;
            string tongDT = function.RunQuery(sql);
            lbDoanhThu.Text = tongDT + " VNĐ";

            //Tổng lợi nhuận
            sql = "select sum(ct.ThanhTien -(ct.SoLuong * sp.GiaNhap)) as LoiNhuan " +
                "from ChiTietDonHang ct, DonHang dh, SanPham sp " +
                "where ct.MaDH = dh.MaDH and ct.MaSP = sp.MaSP " +
                "and day(dh.NgayDat) >= " + dtpNgayBD.Value.Day +
                " and day(dh.NgayDat) <= " + dtpNgayKT.Value.Day +
                " and MONTH(dh.NgayDat) >= " + dtpNgayBD.Value.Month +
                " and MONTH(dh.NgayDat) <= " + dtpNgayKT.Value.Month;
            string loiNhuan = function.RunQuery(sql);
            lbLoiNhuan.Text = loiNhuan + " VNĐ";

            //Tổng số đơn hàng
            sql = "select count(MaDH) as TongDH from DonHang " +
                " where day(NgayDat) >= " + dtpNgayBD.Value.Day +
                " and day(NgayDat) <= " + dtpNgayKT.Value.Day +
                " and MONTH(NgayDat) >= " + dtpNgayBD.Value.Month +
                " and MONTH(NgayDat) <= " + dtpNgayKT.Value.Month;
            string TongDH = function.RunQuery(sql);
            lbTongDH.Text = TongDH;
            //Tổng số khách hàng
            sql = "select count(MaKH) as TongDH from DonHang " +
                " where day(NgayDat) >= " + dtpNgayBD.Value.Day +
                " and day(NgayDat) <= " + dtpNgayKT.Value.Day +
                " and MONTH(NgayDat) >= " + dtpNgayBD.Value.Month +
                " and MONTH(NgayDat) <= " + dtpNgayKT.Value.Month;
            string TongKH = function.RunQuery(sql);
            lbTongKH.Text = TongKH;


        }
    }
}

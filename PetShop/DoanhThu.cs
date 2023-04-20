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
using PetShop.BUS;

namespace PetShop
{
    public partial class DoanhThu : Form
    {
        DataTable tb = null;
        ThongKeBUS bus = new ThongKeBUS();
        int count;
        public DoanhThu()
        {
            InitializeComponent();
        }
        
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            
            count++;
            tb = bus.getStatisticTable(dtpNgayBD.Value, dtpNgayKT.Value);
            chartDoanhThu.DataSource = tb;

            
            if(count == 1)
                chartDoanhThu.ChartAreas.Add(new ChartArea("ChartAreas"));
            chartDoanhThu.ChartAreas["ChartAreas"].AxisX.Title = "Ngày đặt hàng";
            chartDoanhThu.ChartAreas["ChartAreas"].AxisY.Title = "Doanh Thu";
            chartDoanhThu.ChartAreas["ChartAreas"].AxisX.Interval = 1;
            chartDoanhThu.ChartAreas["ChartAreas"].AxisY.MajorGrid.LineColor = Color.LightGray;

            chartDoanhThu.Series["Doanh Thu"].XValueMember = "NgayDat";
            chartDoanhThu.Series["Doanh Thu"].YValueMembers = "DoanhThu";


            DataTable dt = bus.getPieChartData();



            //Thiết lập thuộc tính cho biểu đồ
            if(count == 1)
                chart2.Titles.Add("Top 5 sản phẩm bán chạy");
            chart2.Series[0].ChartType = SeriesChartType.Pie;
            chart2.Series[0].IsValueShownAsLabel = true;
            chart2.Series[0].LabelFormat = "#.##%";
            if(count > 1)
                chart2.Series[0].Points.Clear();

            // Thiết lập dữ liệu cho biểu đồ
            foreach (DataRow dr in dt.Rows)
            {
                chart2.Series[0].Points.AddXY(dr["TenSP"].ToString(), dr["TongSoLuong"]);
            }


            //Tổng doanh thu
            
            string tongDT = bus.getRevenue(dtpNgayBD.Value, dtpNgayKT.Value);
            lbDoanhThu.Text = tongDT + " VNĐ";

            //Tổng lợi nhuận
            
            string loiNhuan = bus.getProfit(dtpNgayBD.Value, dtpNgayKT.Value);
            lbLoiNhuan.Text = loiNhuan + " VNĐ";

            //Tổng số đơn hàng
            
            string TongDH = bus.getTotalOrder(dtpNgayBD.Value, dtpNgayKT.Value);
            lbTongDH.Text = TongDH;
            //Tổng số khách hàng
            
            string TongKH = bus.getTotalCus(dtpNgayBD.Value, dtpNgayKT.Value);
            lbTongKH.Text = TongKH;


        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            bus.load();
            
            count = 0;
            
        }
    }
}

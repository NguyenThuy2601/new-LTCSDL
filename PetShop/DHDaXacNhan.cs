using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShop.BUS;

namespace PetShop
{
    public partial class frmDonHangDaXN : Form
    {
        DataTable tb, tb1;
        DHDaXacNhanBUS bus = new DHDaXacNhanBUS();

        PetShop.DTO.User user;
        public frmDonHangDaXN()
        {
            InitializeComponent();
        }

        public frmDonHangDaXN(DTO.User user) :this()
        {
            this.user = user;
        }

        private void LoadDataGridView()
        {
            tb = bus.getOrderList();
            tb1 = bus.getOrderDetailList();
            dgvListDH.DataSource = tb;
            dgvListDH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListDH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void frmDonHangDaXN_Load(object sender, EventArgs e)
        {
            bus.load();
            LoadDataGridView();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text == "")
                return;
            else
            {
                DataTable dt = bus.findOrder(tb, txtMaDH.Text);
                dgvListDH.DataSource = dt;
            }    

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
            if(txtMaDHHT.Text == "")
                return ;
            else
            {
                if (bus.updateOrderStatus(txtMaDHHT.Text, user.getID()) > 0)
                {
                    MessageBox.Show("Thành công");
                    txtMaDHHT.Text = "";
                    LoadDataGridView();
                    dgvListCTDH.DataSource = null;
                }
                else
                    MessageBox.Show("Đã có lỗi xảy ra");
                
            }    

        }


        private void frmDonHangDaXN_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }

        private void dgvListDH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListDH.CurrentCell.Selected = true;
            txtMaDHHT.Text = dgvListDH.CurrentRow.Cells["MaDH"].Value.ToString();
            string ma = dgvListDH.CurrentRow.Cells["MaDH"].Value.ToString();
            //string sql;
            //sql = "select * from ChiTietDonHang where MaDH = '" + ma + "' ";
            DataTable temp = bus.findOrder(tb1, ma);
            dgvListCTDH.DataSource = temp;
            dgvListCTDH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListCTDH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
    }
}

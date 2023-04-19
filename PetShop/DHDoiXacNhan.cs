using System.Data;
using PetShop.BUS;

namespace PetShop
{
    public partial class DHDoiXacNhan : Form
    {
        DataTable tb, tbCTDH;
        DHDoiXacNhanBUS bus = new DHDoiXacNhanBUS();

        PetShop.DTO.User user;
        public DHDoiXacNhan()
        {
            InitializeComponent();
        }

        public DHDoiXacNhan(DTO.User user) : this()
        {
            this.user = user;   
        }

        private void LoadDataGridView()
        {
            
            tb = bus.getOrderList();
            dgvListDH.DataSource = tb;
            dgvListDH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListDH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void DHDoiXacNhan_Load(object sender, EventArgs e)
        {
            bus.load();
            tbCTDH = bus.getOrderDetailList();
            LoadDataGridView();
        }

        private void dgvListDH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListDH.CurrentCell.Selected = true;
            txtMaDon.Text = dgvListDH.CurrentRow.Cells["MaDH"].Value.ToString();

            DataTable temp = bus.findOrder(tbCTDH, txtMaDon.Text);
            dgvListCTDH.DataSource = temp;
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if(bus.acceptOrder(txtMaDon.Text, user.getID()) > 0)
            {
                DataTable dt = bus.findOrder(tbCTDH, txtMaDon.Text);

                foreach (DataRow row in dt.Rows)
                    bus.updateproductQty(row["MaSP"].ToString(), row["SoLuong"].ToString());
                txtMaDon.Text = "";
                LoadDataGridView();
                dgvListCTDH.DataSource = null;
            }    
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }    
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

        private void btHuy_Click(object sender, EventArgs e)
        {
            if (bus.declineOrder(txtMaDon.Text, user.getID()) > 0)
            {
                txtMaDon.Text = "";
                LoadDataGridView();
                dgvListCTDH.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
        }

        private void DHDoiXacNhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }
    }
}

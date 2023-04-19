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
using PetShop.DTO;

namespace PetShop
{
    public partial class QLKH : Form
    {
        DataTable tb;
        QLKHBUS bus = new QLKHBUS();
        User user = null;
        public QLKH() 
        {
            InitializeComponent();
        }

        public QLKH(User user):this()
        {
            this.user = user;
        }

        private void LoadDataGridView()
        {
            tb = bus.loadKHList();
            dgwListKH.DataSource = tb;
            dgwListKH.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgwListKH.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void setVisible()
        {
            if (!bus.authorization(user.getAccountId()))
            {
                btSua.Visible = false;
            }
        }
        public void resetTextBox()
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtHoTenlot.Text = "";
            txtPass.Text = "";
            txtSDT.Text = "";
            txtTen.Text = "";
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnNhapTTNhanVien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            bus.load();
            LoadDataGridView();
            setVisible();
        }

        private void dgwListKH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwListKH.CurrentCell.Selected = true;
            txtHoTenlot.Text = dgwListKH.CurrentRow.Cells["HoLot"].Value.ToString();
            txtTen.Text = dgwListKH.CurrentRow.Cells["Ten"].Value.ToString();
            txtSDT.Text = dgwListKH.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgwListKH.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgwListKH.CurrentRow.Cells["email"].Value.ToString();
            dtpNgaySinh.Text = dgwListKH.CurrentRow.Cells["DOB"].Value.ToString();
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            if (txtTimKHTheoTen.Text.Trim() != string.Empty)
            {
                DataTable dt = bus.findCusByName(tb,txtTimKHTheoTen.Text.Trim());               
                dgwListKH.DataSource = dt;
            }
            if (txtTimKHTheoEmail.Text.Trim() != string.Empty)
            {
                DataTable dt = bus.findCusByEmail(tb, txtTimKHTheoEmail.Text.Trim());             
                dgwListKH.DataSource = dt;
            }

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txtHoTenlot.Text == "" || txtTen.Text == "" || txtEmail.Text == "" ||
                txtDiaChi.Text == "" || txtSDT.Text == "")
                MessageBox.Show("Vui lòng không để trống");
            else
            {
                Account ac = new Account(dgwListKH.CurrentRow.Cells["MaTK"].Value.ToString(),
                                           txtEmail.Text, txtPass.Text);
                KhachHang kh = new KhachHang(int.Parse(dgwListKH.CurrentRow.Cells["MaKH"].Value.ToString()),
                                            dtpNgaySinh.Value.Date, txtHoTenlot.Text,
                                            txtTen.Text, txtSDT.Text, txtDiaChi.Text);
                if (bus.updateCusAccount(ac) > 0)
                {
                    if (bus.updateCusIfno(kh) > 0)
                    {
                        MessageBox.Show("Thành công");
                        resetTextBox();
                        LoadDataGridView();
                    }    
                    else
                        MessageBox.Show("Đã có lỗi xảy ra trong update thông tin khách");

                }
                else
                    MessageBox.Show("Đã có lỗi xảy ra trong update tài khoản");
            }
        }
    }
}

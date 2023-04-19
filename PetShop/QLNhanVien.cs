using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PetShop.BUS;
using PetShop.DTO;

namespace PetShop
{
    public partial class QLNhanVien : Form
    {
        DataTable tb;
        User user = null;
        QLNVBUS bus = new QLNVBUS();
        public QLNhanVien()
        {
            InitializeComponent();
        }

        public QLNhanVien(User user) :this()
        {
            this.user = user;
        }

        private void LoadDataGridView()
        {

            dgwNV.DataSource = bus.getEmplList();
            dgwNV.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgwNV.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void resetValue()
        {
            foreach (Control ctrl in pnNhapTTNhanVien.Controls)
                if (ctrl is TextBox)
                    ctrl.Text = "";
            dtpNgaySinh.Value = DateTime.Now.Date;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void setVisible()
        {
            if(!bus.authorization(user.getAccountId()))
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }    
        }

        private void QLNhanVien_Load_1(object sender, EventArgs e)
        {
            bus.load();
            LoadDataGridView();
            setVisible();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgwNV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwNV.CurrentCell.Selected = true;
            txtHoTenlot.Text = dgwNV.CurrentRow.Cells["HoLot"].Value.ToString();
            txtTen.Text = dgwNV.CurrentRow.Cells["Ten"].Value.ToString();
            txtSDT.Text = dgwNV.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgwNV.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgwNV.CurrentRow.Cells["email"].Value.ToString();
            txtCMND.Text = dgwNV.CurrentRow.Cells["CMND"].Value.ToString();
            dtpNgaySinh.Text = dgwNV.CurrentRow.Cells["DOB"].Value.ToString();
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtCMND.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "" ||
                txtHoTenlot.Text == "" || txtPass.Text == "" || txtSDT.Text == "" || txtTen.Text =="")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }  
            else
            {
                string pass = CommonFunction.Encrypt(txtPass.Text);
                string TKid = bus.generateEmplAccID();
                Account ac = new Account(TKid, txtEmail.Text, pass);
                Empl empl = new Empl(txtHoTenlot.Text, txtTen.Text, txtCMND.Text,
                                dtpNgaySinh.Value.Date, txtSDT.Text,
                                txtDiaChi.Text, ac.Id);
                if (bus.insertTaiKhoan(ac) > 0)
                {
                    if (bus.insertNhanVien(empl) > 0)
                    {
                        MessageBox.Show("Thành công");
                        LoadDataGridView();
                        resetValue();
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                    }
                    else
                        MessageBox.Show("Có lỗi trong thêm nhân viên");
                }
                else
                    MessageBox.Show("Có lỗi xảy ra");
            }    
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string idTK = dgwNV.CurrentRow.Cells["MaTK"].Value.ToString();
            string pass = function.Encrypt(txtPass.Text);
            string idNV = dgwNV.CurrentRow.Cells["MaNV"].Value.ToString();

            Account ac = new Account(idTK, txtEmail.Text, pass);
            Empl empl = new Empl(int.Parse(idNV), txtHoTenlot.Text, txtTen.Text,
                                  txtCMND.Text, dtpNgaySinh.Value.Date,
                                  txtSDT.Text, txtDiaChi.Text, ac.Id);
            if (bus.updateTaiKhoan(ac) > 0)
            {
                if (bus.updateNhanVien(empl) > 0)
                {
                    MessageBox.Show("Thành công");
                    resetValue();
                    LoadDataGridView();
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
                else
                    MessageBox.Show("Có lỗi trong thêm nhân viên");
            }
            else
                MessageBox.Show("Có lỗi xảy ra");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string idTK = dgwNV.CurrentRow.Cells["MaTK"].Value.ToString();
            string idNV = dgwNV.CurrentRow.Cells["MaNV"].Value.ToString();
            if (bus.deleteNhanVien(idNV) > 0)
            {
                if (bus.deleteAccount(idTK) > 0)
                {
                    MessageBox.Show("Xóa Thành công");
                    LoadDataGridView();
                    resetValue();
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }    
                    
                else
                    MessageBox.Show("Có lỗi khi xóa nhân viên này");
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra");
            
        }


        private void QLNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class KhuyenMai : Form
    {
        KhuyenMaiBUS bus = new KhuyenMaiBUS();
        DataTable tblCL = null;
        DataTable tbProductList = null;
        String oldID = null;
        public KhuyenMai()
        {
            InitializeComponent();
        }
        private void reserBtn()
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
        }    
        private void LoadDataGridView()
        {
            tblCL = bus.loadKMList();
            dgvListKM.DataSource = tblCL;
            dgvListKM.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListKM.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void LoadDataGridViewProductList()
        {
            tbProductList = bus.loadProductList();
            dgvProductList.DataSource = tbProductList;
            dgvProductList.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvProductList.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void KhuyenMai_Load(object sender, EventArgs e)
        {
            bus.load();
            LoadDataGridViewProductList();
            LoadDataGridView();
            reserBtn();
        }

        private void KhuyenMai_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtPercent.Text == "")
                MessageBox.Show("Chưa nhập đủ thông tin");
            else
            {
                if (bus.checkID(txtID.Text) == true)
                {
                    Discount dc = new Discount(txtID.Text, bus.formatPercentToDB(int.Parse(txtPercent.Text)));
                    if (bus.addKhuyenMai(dc) > 0)
                    {
                        MessageBox.Show("Tạo khuyến mãi thành công");
                        LoadDataGridView();
                    }    
                        
                    else
                        MessageBox.Show("Đã có xảy ra");
                }
                else
                    MessageBox.Show("Mã khuyến mãi đã tồn tại");
            }    
        }

        private void dgvListKM_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListKM.CurrentCell.Selected = true;
            oldID = dgvListKM.CurrentRow.Cells["MaKM"].Value.ToString();
            txtID.Text = dgvListKM.CurrentRow.Cells["MaKM"].Value.ToString();
            txtPercent.Text = dgvListKM.CurrentRow.Cells["PhanTram"].Value.ToString();

            dgvProductList.DataSource = bus.finDiscountByID(tbProductList, oldID);

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnRemove.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtPercent.Text == "")
                MessageBox.Show("Chưa nhập đủ thông tin");
            else
            {
                if ((!oldID.Equals(txtID.Text) && bus.checkID(txtID.Text) == true) || oldID.Equals(txtID.Text))
                {
                    Discount dc = new Discount(txtID.Text, bus.formatPercentToDB(double.Parse(txtPercent.Text)));                    if (bus.updateKhuyenMai(dc, oldID) > 0)
                    {
                        MessageBox.Show("Update khuyến mãi thành công");
                        oldID = txtID.Text;
                        LoadDataGridView();
                        LoadDataGridViewProductList();
                        reserBtn();
                        txtID.Text = "";
                        txtPercent.Text = "";
                    }    
                       
                    else
                        MessageBox.Show("Đã có lỗi xảy ra");
                }
                else
                    MessageBox.Show("Mã khuyến mãi đã tồn tại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                MessageBox.Show("Chưa chọn mã");
            else
            {
                if (bus.checkID(txtID.Text) == true)
                {
                    MessageBox.Show("Mã khuyến mãi không tồn tại");
                }
                else
                {
                    if (bus.deleteKhuyenMai(txtID.Text) > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadDataGridView();
                        LoadDataGridViewProductList();
                        txtID.Text = "";
                        txtPercent.Text = "";
                    }    
                        
                    else
                        MessageBox.Show("Có lỗi xảy ra");
                }    
                    
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                MessageBox.Show("Chưa chọn mã");
            else
            {
                if (bus.checkID(txtID.Text) == true)
                {
                    MessageBox.Show("Mã khuyến mãi không tồn tại");
                }
                else
                {
                    if (bus.removeKhuyenMai(txtID.Text) > 0)
                    {
                        MessageBox.Show("Gỡ mã thành công");
                        LoadDataGridViewProductList();
                    }

                    else
                        MessageBox.Show("Có lỗi xảy ra");
                }

            }
        }

        private void btnFindID_Click(object sender, EventArgs e)
        {
            if(txtFindID.Text == "")
            {
                LoadDataGridView();
                LoadDataGridViewProductList();
            }  
            else
            {
                dgvListKM.DataSource = bus.finDiscountByID(tblCL, txtFindID.Text);
                dgvProductList.DataSource = bus.finDiscountByID(tbProductList, txtFindID.Text);
            }    
        }
    }
}

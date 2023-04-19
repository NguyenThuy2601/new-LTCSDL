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
    public partial class QLSanPham : Form
    {
        QLSPBus bus = new QLSPBus();
        DataTable tblCL;


        public QLSanPham()
        {
            InitializeComponent();
        }
        private void QLSanPham_Load_1(object sender, EventArgs e)
        {
            bus.load();
            LoadDataGridView();
            LoadDataToComboBox();
        }
        private void addItem(List<string> ds)
        {
            cbbDMCon.Items.Clear();
            foreach (string it in ds)
                cbbDMCon.Items.Add(it);
        }
        
        private void LoadDataGridView()
        {
            tblCL = bus.getListSanPham();
            dgwListSP.DataSource = tblCL;
            dgwListSP.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgwListSP.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        
        private void LoadDataToComboBox()
        {
            DataTable dt = bus.getListKhuyenMai();
            cbbKhuyenMai.DataSource = dt;
            cbbKhuyenMai.ValueMember = "MaKM";
            cbbKhuyenMai.DisplayMember = "MaKM";
        }
        private void resetValue()
        {
            foreach (Control ctrl in pnNhapThongTinSP.Controls)
                if (ctrl is TextBox)
                    ctrl.Text = "";
            foreach (Control ctrl in pnNhapThongTinSP.Controls)
                if (ctrl is ComboBox)
                    ctrl.Text = "";
            chkTinhTrang.Checked = false;
            btnReset.Enabled = true;
            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            numSoLuongSP.Value = 0;
            LoadDataGridView();
        }
       

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }    

        private void cbbDanhMuc_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbbDanhMuc.SelectedItem != null)
            {
                string choice = cbbDanhMuc.SelectedItem.ToString().Substring(0,2);
                switch (choice)
                {
                    case "TP":
                        addItem(bus.getDMCTP());
                        break;
                    case "VD":
                        addItem(bus.getDMCVD());
                        break;
                    case "VS":
                        addItem(bus.getDMCVS());
                        break;
                    case "PK":
                        addItem(bus.getDMCPK());
                        break;
                        
                }
                 
            }    
            
        }

       

       

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "" || txtGiaBan.Text == "" || cbbDoiTuongSD.Text == "" ||
                txtGiaNhap.Text == "" || cbbDanhMuc.Text == "" || cbbDMCon.Text == ""||
                txtCode.Text == "")
                MessageBox.Show("Vui lòng điền các trường có dấu *");
            else
            {
                string color = bus.isNull(txtMauSac.Text);
                string pic = bus.isNull(txtPic.Text);
                int Soluong = (int)numSoLuongSP.Value;
                String dm = cbbDanhMuc.SelectedItem.ToString().Substring(0, 2);
                string id = bus.generateIDFromOption(dm,
                                                    cbbDoiTuongSD.SelectedItem.ToString(),
                                                    cbbDMCon.SelectedItem.ToString(),
                                                    txtCode.Text.Trim());

                string km = bus.isNull(cbbKhuyenMai.Text);

                Product sp = new Product(id, txtTenSP.Text, Soluong,
                                              decimal.Parse(txtGiaBan.Text), decimal.Parse(txtGiaNhap.Text),
                                              color, km, pic, chkTinhTrang.Checked);
                if (bus.createProduct(sp) > 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    LoadDataGridView();
                    resetValue();
                }
                else
                    MessageBox.Show("Có lỗi xảy ra");
                //string sql = "INSERT INTO SanPham(MaSP, TenSp, SoLuong, GiaBan, GiaNhap, MauSac,MaKM, Hinh) VALUES('"
                //              + id + "',"
                //              + "N'" + txtTenSP.Text + "',"
                //              + numSoLuongSP.Value + ","
                //              + int.Parse(txtGiaBan.Text) + ","
                //              + int.Parse(txtGiaNhap.Text) + ",";
                //if(color != "null")
                //{
                //    sql += "N";
                //    sql = modifyString(sql, color);
                //}    
                //else
                //    sql = modifyString(sql, color);
                //sql += ",";
                //sql = modifyString(sql, km);
                //sql += ",";
                //sql = modifyString(sql, pic);
                //sql += ")";
                //function.RunNonQuery(sql);

            }    
        }

        private void dgwListSP_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwListSP.CurrentRow.Selected = true;
            txtMaSP.Text = dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgwListSP.CurrentRow.Cells["TenSp"].Value.ToString();
            txtMauSac.Text = bus.isNullBlank(dgwListSP.CurrentRow.Cells["MauSac"].Value.ToString());
            txtGiaBan.Text = dgwListSP.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtGiaNhap.Text = dgwListSP.CurrentRow.Cells["GiaNhap"].Value.ToString();
            numSoLuongSP.Value = int.Parse(dgwListSP.CurrentRow.Cells["SoLuong"].Value.ToString());
            cbbDanhMuc.Text = bus.convertCodetoCate(
                            dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString().Substring(0, 2));
            cbbDMCon.Text = bus.convertCodetoChildCate(
                            dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString().Substring(3, 1));
            cbbDoiTuongSD.Text = bus.convertCodeToDTSDID(
                            dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString().Substring(2, 1));
            txtCode.Text = dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString().Substring(4);
            txtPic.Text = bus.isNullBlank(dgwListSP.CurrentRow.Cells["Hinh"].Value.ToString());
            cbbKhuyenMai.SelectedValue = dgwListSP.CurrentRow.Cells["MaKM"].Value.ToString();
            cbbKhuyenMai.SelectedItem = dgwListSP.CurrentRow.Cells["MaKM"].Value.ToString();
            if (bool.Parse(dgwListSP.CurrentRow.Cells["TinhTrang"].Value.ToString()) == false)
                chkTinhTrang.Checked = true;
            btThem.Enabled = false;

        }

        private void dgwListSP_Click(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if(txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào");
            }  
            else
            {
                if (txtTenSP.Text == "" || txtGiaBan.Text == "" || cbbDoiTuongSD.Text == "" ||
                txtGiaNhap.Text == "" || cbbDanhMuc.Text == "" || cbbDMCon.Text == "" ||
                txtCode.Text == "")
                    MessageBox.Show("Vui lòng điền các trường có dấu *");
                else
                {
                    string oldID = txtMaSP.Text;

                    string color = bus.isNull(txtMauSac.Text);
                    string pic = bus.isNull(txtPic.Text);
                    int Soluong = (int)numSoLuongSP.Value;
                    string km = bus.isNull(cbbKhuyenMai.Text);
                    string id = bus.generateIDFromOption(cbbDanhMuc.SelectedItem.ToString().Substring(0, 2),
                                                    cbbDoiTuongSD.SelectedItem.ToString(),
                                                    cbbDMCon.SelectedItem.ToString(),
                                                    txtCode.Text.Trim());

                    Product sp = new Product(id, txtTenSP.Text, Soluong,
                                              decimal.Parse(txtGiaBan.Text), decimal.Parse(txtGiaNhap.Text),
                                              color, km, pic, chkTinhTrang.Checked);
                    if(bus.updateProduct(sp, oldID) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        LoadDataGridView();
                        resetValue();
                    }    
                    else
                        MessageBox.Show("Có lỗi xảy ra");

                    //string sql = "update SanPham set MaSP = '"
                    //              + id + "',"
                    //              + "TenSp = " + "N'" + txtTenSP.Text + "',"
                    //              + "SoLuong = " + numSoLuongSP.Value + ","
                    //              + "GiaBan = " + txtGiaBan.Text + ","
                    //              + "GiaNhap = " + txtGiaNhap.Text + ","
                    //              + "MauSac = ";
                    //if (color != "null")
                    //{
                    //    sql += "N";
                    //    sql = modifyString(sql, color);
                    //}
                    //else
                    //    sql = modifyString(sql, color);
                    //sql += ",";
                    //sql += "MaKM = ";
                    //sql = modifyString(sql, km);
                    //sql += ",";
                    //sql += "Hinh = ";
                    //sql = modifyString(sql, pic);
                    //if (chkTinhTrang.Checked == true)
                    //    sql += ",TinhTrang = 0";
                    //else
                    //    sql += ",TinhTrang = 1";
                    //sql += "where MaSP = '" + oldID + "'";

                    //function.RunNonQuery(sql);


                }
            }
            
        }


        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
                MessageBox.Show("Bạn chưa chọn bản ghi nào");
            else
            {
                if (chkTinhTrang.Checked == false || numSoLuongSP.Value != 0)
                    MessageBox.Show("Không thể xóa bản ghi vì sản phẩm đang còn kinh doanh");
                else
                if (MessageBox.Show("Bạn có muốn xoá không?",
                            "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bus.deleteProduct(txtMaSP.Text) > 0)
                    {
                        MessageBox.Show("Đã xóa");
                        LoadDataGridView();
                        resetValue();
                    }
                    else
                        MessageBox.Show("Có lỗi xảy ra");
                        
                }
            }
                
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetValue();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = bus.findProductByCode(tblCL, txtFindCode.Text); ;
            dgwListSP.DataSource = dt;
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            DataTable dt = bus.findProductByName(tblCL, txtFindName.Text);            
            dgwListSP.DataSource = dt;
        }

        private void QLSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            bus.close();
        }

        private void cbbKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

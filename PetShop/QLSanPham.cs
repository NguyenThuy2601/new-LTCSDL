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
namespace PetShop
{
    public partial class QLSanPham : Form
    {
        List<String> DMCTP = new List<string>() { "K (thức ăn khô)", "U (thức ăn ướt)", "S (Sữa)" };
        List<String> DMCVD = new List<string>() { "L (Lược)", "C (chuồng)", "N (Nệm)", "B (Bát)" };
        List<String> DMCVS = new List<string>() { "T (Sữa tắm)", "M (cát)"};
        List<String> DMCPK = new List<string>() { "V (vòng cổ)" };
        DataTable tblCL;
        private void addItem(List<string> ds)
        {
            cbbDMCon.Items.Clear();
            foreach (string it in ds)
                cbbDMCon.Items.Add(it);
        }
        private string defineChildCategoryID(string s)
        {
            return s.Substring(0, 1);
        }
        private string defineDTSDID(string s)
        {
            switch(s)
            {
                case "Chó":
                    return "D";
                case "Mèo":
                    return "C";
                case "Tất cả":
                    return "A";
            }  
            return s;
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "select s.*, STRING_AGG(trim(MaKW), ',') as KW " +
                  "from SanPham  as s " +
                  "left join SP_KW as sk"
                    + " on s.MaSP = sk.MaSP"
                +" group by s.MaSP, s.TenSp, s.GiaBan, s.GiaNhap, " +
                "s.Hinh, s.MaKM, s.MauSac, s.SoLuong, s.TinhTrang";

            tblCL = function.GetDataToTable(sql);
            dgwListSP.DataSource = tblCL;
            dgwListSP.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgwListSP.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void LoadDataListBox()
        {
            string sql;
            sql = "select * from Keyword";
            List<string> a = new List<string>();
            function.LoadDataToListBox(sql, a);
            
            foreach (string it in a)
                listBoxKW.Items.Add(it);
            listBoxKW.SelectionMode = SelectionMode.MultiExtended;
        }
        private void LoadDataToComboBox()
        {
            string sql;
            sql = "select MaKM from KhuyenMai";
            List<string> a = new List<string>();
            function.GetDataToComboBox(sql, a, "MaKM");
            foreach (string it in a)
                cbbKhuyenMai.Items.Add(it);
        }
        private string isNull(string str)
        {
            if (str == "" || str == null)
                return "null";
            else return str;
        }
        private string isNullBlank(string str)
        {
            if (str == "" || str == "null")
                return "";
            else return str;
        }
        private string modifyString(string sql, string v)
        {
            if (v != null && v != "null")
                sql += "'" + v + "'";
            else
                if (v != null && v == "null")
                    sql += v;
            return sql;
                
        }

        private string convertCodetoCate(string s)
        {
            switch(s)
            {
                case "TP":
                    return "TP (Thực phẩm)";
                case "VD":
                    return "VD (Vật dụng)";
                case "VS":
                    return "VS (Vệ sinh)";
                case "PK":
                    return "PK (Phụ kiện)";
            }
            return null;
        }
        private string convertCodetoChildCate(string s)
        {
            switch (s)
            {
                case "K":
                    return "K (thức ăn khô)";
                case "U":
                    return "U (thức ăn ướt)";
                case "S":
                    return "S (Sữa)";
                case "L":
                    return "L (Lược)";
                case "C":
                    return "C (chuồng)";
                case "N":
                    return "N (Nệm)";
                case "B":
                    return "B (Bát)";
                case "T":
                    return "T (Sữa tắm)";
                case "M":
                    return "M (cát)";
                case "V":
                    return "V (vòng cổ)";
            }
            return null;
        }
        private string convertCodeToDTSDID(string s)
        {
            switch (s)
            {
                case "D":
                    return "Chó";
                case "C":
                    return "Mèo";
                case "A":
                    return "Tất cả";
            }
            return s;
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
        public QLSanPham()
        {
            InitializeComponent();
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
                        addItem(DMCTP);
                        break;
                    case "VD":
                        addItem(DMCVD);
                        break;
                    case "VS":
                        addItem(DMCVS);
                        break;
                    case "PK":
                        addItem(DMCPK);
                        break;
                        
                }
                 
            }    
            
        }

       

        private void QLSanPham_Load_1(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadDataListBox();
            LoadDataToComboBox();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "" || txtGiaBan.Text == "" || cbbDoiTuongSD.Text == "" ||
                txtGiaNhap.Text == "" || cbbDanhMuc.Text == "" || cbbDMCon.Text == ""||
                txtCode.Text == "")
                MessageBox.Show("Vui lòng điền các trường có dấu *");
            else
            {
                string color = isNull(txtMauSac.Text);
                string pic = isNull(txtPic.Text);
                int Soluong = (int)numSoLuongSP.Value;
                string id = cbbDanhMuc.SelectedItem.ToString().Substring(0, 2)
                            + defineDTSDID(cbbDoiTuongSD.SelectedItem.ToString())
                            + defineChildCategoryID(cbbDMCon.SelectedItem.ToString())
                            + txtCode.Text.Trim();
                string km = isNull(cbbKhuyenMai.Text);
                List<string> listKW = new List<string>();
                foreach(string it in listBoxKW.SelectedItems)
                {
                    listBoxKW.Items.Add(it);
                }
                string sql = "INSERT INTO SanPham(MaSP, TenSp, SoLuong, GiaBan, GiaNhap, MauSac,MaKM, Hinh) VALUES('"
                              + id + "',"
                              + "N'" + txtTenSP.Text + "',"
                              + numSoLuongSP.Value + ","
                              + int.Parse(txtGiaBan.Text) + ","
                              + int.Parse(txtGiaNhap.Text) + ",";
                if(color != "null")
                {
                    sql += "N";
                    sql = modifyString(sql, color);
                }    
                else
                    sql = modifyString(sql, color);
                sql += ",";
                sql = modifyString(sql, km);
                sql += ",";
                sql = modifyString(sql, pic);
                sql += ")";
                function.RunNonQuery(sql);
                LoadDataGridView();
                resetValue(); 
            }    
        }

        private void dgwListSP_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwListSP.CurrentRow.Selected = true;
            txtMaSP.Text = dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgwListSP.CurrentRow.Cells["TenSp"].Value.ToString();
            txtMauSac.Text = isNullBlank(dgwListSP.CurrentRow.Cells["MauSac"].Value.ToString());
            txtGiaBan.Text = dgwListSP.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtGiaNhap.Text = dgwListSP.CurrentRow.Cells["GiaNhap"].Value.ToString();
            numSoLuongSP.Value = decimal.Parse(dgwListSP.CurrentRow.Cells["SoLuong"].Value.ToString());
            cbbDanhMuc.Text = convertCodetoCate(
                            dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString().Substring(0, 2));
            cbbDMCon.Text = convertCodetoChildCate(
                            dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString().Substring(3, 1));
            cbbDoiTuongSD.Text = convertCodeToDTSDID(
                            dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString().Substring(2, 1));
            txtCode.Text = dgwListSP.CurrentRow.Cells["MaSP"].Value.ToString().Substring(4);
            txtPic.Text = isNullBlank(dgwListSP.CurrentRow.Cells["Hinh"].Value.ToString());
            cbbKhuyenMai.Text = isNullBlank(dgwListSP.CurrentRow.Cells["MaKM"].Value.ToString());
            if (bool.Parse(dgwListSP.CurrentRow.Cells["TinhTrang"].Value.ToString()) == false)
                chkTinhTrang.Checked = true;
            btThem.Enabled = false;
            txtKwInfo.Text = dgwListSP.CurrentRow.Cells["KW"].Value.ToString();

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
                    bool flagKW;
                    string query = "select MaKW from SP_KW where MaSP = '" + oldID + "'";
                    if (function.RunQuery(query) != null)
                        flagKW = true;
                    else
                        flagKW = false;

                    string color = isNull(txtMauSac.Text);
                    string pic = isNull(txtPic.Text);
                    int Soluong = (int)numSoLuongSP.Value;
                    string id = cbbDanhMuc.Text.ToString().Substring(0, 2)
                                + defineDTSDID(cbbDoiTuongSD.Text)
                                + defineChildCategoryID(cbbDMCon.Text)
                                + txtCode.Text.Trim();
                    string km = isNull(cbbKhuyenMai.Text);
                    List<string> listKW = new List<string>();

                    string[] temp = txtKwInfo.Text.Split(' ');
                    foreach (string s in temp)
                        if (s != "")
                            listKW.Add(s);

                    string sql = "update SanPham set MaSP = '"
                                  + id + "',"
                                  + "TenSp = " + "N'" + txtTenSP.Text + "',"
                                  + "SoLuong = " + numSoLuongSP.Value + ","
                                  + "GiaBan = " + txtGiaBan.Text + ","
                                  + "GiaNhap = " + txtGiaNhap.Text + ","
                                  + "MauSac = ";
                    if (color != "null")
                    {
                        sql += "N";
                        sql = modifyString(sql, color);
                    }
                    else
                        sql = modifyString(sql, color);
                    sql += ",";
                    sql += "MaKM = ";
                    sql = modifyString(sql, km);
                    sql += ",";
                    sql += "Hinh = ";
                    sql = modifyString(sql, pic);
                    if (chkTinhTrang.Checked == true)
                        sql += ",TinhTrang = 0";
                    else
                        sql += ",TinhTrang = 1";
                    sql += "where MaSP = '" + oldID + "'";

                    function.RunNonQuery(sql);
                    if (listKW.Count > 0)
                    {
                        if (flagKW == true)
                        {
                            sql = "DELETE SP_KW WHERE MaSP = '" + id + "'";
                            function.RunNonQuery(sql);
                        }
                        foreach (string it in listKW)
                        {
                            sql = "insert into SP_KW values ('"
                                    + id + "','"
                                    + it + "')";

                            function.RunNonQuery(sql);
                        }
                    }
                    else
                    {
                        if (flagKW == true)
                        {
                            sql = "DELETE SP_KW WHERE MaSP = '" + id + "'";
                            function.RunNonQuery(sql);
                        }
                    }
                    LoadDataGridView();
                    resetValue();
                }
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
                        string sql = "DELETE SanPham WHERE MaSP='" + txtMaSP.Text + "'";
                        function.RunNonQuery(sql);
                        LoadDataGridView();
                        resetValue();
                }
            }
                
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetValue();
        }

        private void listBoxKW_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKwInfo.Text = "";
            foreach (var it in listBoxKW.SelectedItems)
            {
                string[] item = it.ToString().Split(' ');
                txtKwInfo.Text += item[0] + " ";
            }    
                
        }

        private void btnDelKW_Click(object sender, EventArgs e)
        {
            txtKwInfo.Text = "";
            listBoxKW.SelectedItems.Clear();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = tblCL;
            dt.DefaultView.RowFilter = string.Format("MaSP = '{0}'", txtFindCode.Text);
            dgwListSP.DataSource = dt;
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            DataTable dt = tblCL;
            dt.DefaultView.RowFilter = string.Format("TenSp like '%{0}%'", txtFindName.Text);
            dgwListSP.DataSource = dt;
        }
    }
}

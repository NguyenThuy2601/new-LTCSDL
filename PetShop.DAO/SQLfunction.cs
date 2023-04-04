using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop.DAO
{
    public class SQLfunction
    {
        public SqlConnection Con = null;

        public int Connect()
        {
            if (Con == null)
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Data Source=DESKTOP-4CBR9B5;Initial Catalog=PetShop;Integrated Security=True";
                //Con.ConnectionString = @"Data Source = KIMTAI; Initial Catalog = PetShop; Integrated Security = True";
                Con.Open();
                if (Con.State == ConnectionState.Open)
                    return 1;
                else
                    return 0;
            }
            return 1;

        }
        public int Disconnect()
        {
            if (Con != null)
            {
                Con.Close();
                Con.Dispose();
                Con = null;
                return 0;
            }
            return 0;

        }

        public DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Con;
            dap.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
        public void LoadDataToListBox(string sql, List<string> a)
        {

            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader dr = cmd.ExecuteReader();

            string str = "";
            while (dr.Read())
            {
                str = dr["MakW"].ToString().Trim();
                str += " " + dr["NoiDung"].ToString().Trim();
                a.Add(str);
            }
            dr.Close();
        }

        public void GetDataToComboBox(string sql, List<string> a, string col)
        {

            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader dr = cmd.ExecuteReader();

            string str = "";
            while (dr.Read())
            {
                str = dr[col].ToString().Trim();
                a.Add(str);
            }
            dr.Close();
        }
        public int RunNonQuery(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                return cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }

        public string RunQuery(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {

                if (cmd.ExecuteScalar() != null)
                    return cmd.ExecuteScalar().ToString(); //Thực hiện câu lệnh SQL
                else return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
            return null;
        }
        


    }
}

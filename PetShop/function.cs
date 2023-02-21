using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PetShop
{
    
    class function
    {
        public static SqlConnection Con;

        public static void Connect()
        {
            Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=DESKTOP-4CBR9B5;Initial Catalog=PetShop;Integrated Security=True";
            Con.Open();
            if (Con.State == ConnectionState.Open)
                MessageBox.Show("success");

        }
        public static void Disconnect()
        {
            if(Con != null)
            {
                function.Con.Close();
                Con.Dispose();
                Con = null;
                MessageBox.Show("closed");
            }    
            
        }

        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(); 
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Con; 
            dap.SelectCommand.CommandText = sql; 
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
        public static void LoadDataToListBox(string sql, List<string> a)
        {
            
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader dr = cmd.ExecuteReader();

            string str = "";
            while(dr.Read())
            {
                str = dr["MakW"].ToString().Trim();
                str += " " + dr["NoiDung"].ToString().Trim();
                a.Add(str);
            }    
            dr.Close(); 
        }

        public static void GetDataToComboBox(string sql, List<string> a, string col)
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
        public static void RunNonQuery(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }

        public static string RunQuery(string sql)
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

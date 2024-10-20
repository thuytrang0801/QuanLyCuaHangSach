using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLCuaHangSach
{
    public class DataProvider
    {
        
        //private string connectString = @"Data Source=DESKTOP-VPRBPMK;Initial Catalog=QLCuaHangSach;Integrated Security=True";
        private string connectString = @"Data Source=LAPTOP-F16AE6S3\TRANTRANG;Initial Catalog=BTL_QLCH_Sach;Integrated Security=True";
        public DataTable execQuery(string query) //select ra các bảng
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(connectString)) //thực hiện mở sql
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public int execNonQuery(string query) //trả về số dòng biến tác động
        {
            int data = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                data = cmd.ExecuteNonQuery();
                con.Close();
            }
            return data;
        }
        public object execScaler(string query)
        {
            object data = 0;
            using (SqlConnection con = new SqlConnection(connectString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                data = cmd.ExecuteScalar();
                con.Close();
            }
            return data;


        }



    }
}

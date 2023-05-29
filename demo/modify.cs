using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace demo
{
    internal class modify
    {
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;


        public modify()
        {
        }
        public DataTable getALLchitietdonhang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from chitietdathang";
            using (SqlConnection sqlConnection = Connection.GetConnection()) 
            {

                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query,sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool insert(chitietdonhang Chitietdonhang)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "insert into  chitietdathang(sohoadon, mahang, giaban, soluong, mucgiamgia)" +" values (@sohoadon,@mahang,@giaban,@soluong,@mucgiamgia)";
        
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@sohoadon", SqlDbType.Int).Value = Chitietdonhang.Sohoadon;
                sqlCommand.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = Chitietdonhang.Mahang;
                sqlCommand.Parameters.Add("@giaban", SqlDbType.Money).Value = Chitietdonhang.Giaban;
                sqlCommand.Parameters.Add("@soluong", SqlDbType.SmallInt).Value = Chitietdonhang.Soluong;
                sqlCommand.Parameters.Add("@mucgiamgia", SqlDbType.Real).Value = Chitietdonhang.Mucgiamga;
                sqlCommand.BeginExecuteNonQuery();
               
            }
            catch 
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool update(chitietdonhang Chitietdonhang)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "update  tchitietdathang set hoadon = @sohoadon,mahang = @mahang,giaban = @giaban,soluong = @soluong,mucgiamgia = @mucgiamgia ";

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@sohoadon", SqlDbType.Int).Value = Chitietdonhang.Sohoadon;
                sqlCommand.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = Chitietdonhang.Mahang;
                sqlCommand.Parameters.Add("@giaban", SqlDbType.Money).Value = Chitietdonhang.Giaban;
                sqlCommand.Parameters.Add("@soluong", SqlDbType.SmallInt).Value = Chitietdonhang.Soluong;
                sqlCommand.Parameters.Add("@mucgiamgia", SqlDbType.Real).Value = Chitietdonhang.Mucgiamga;
                sqlCommand.BeginExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

    }

    

}

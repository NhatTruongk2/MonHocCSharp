using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace demo
{
    class Connection
    {
        private static string stringConnection = "Data Source=LAPTOP-ECOVO9GP\\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
        public static  SqlConnection GetConnection()
        {
            return new SqlConnection(stringConnection );
        }
    }
}

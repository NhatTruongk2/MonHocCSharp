using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTruong
{

    public class TuongTacDB
    {
         public static  string chuoiketnoi = "Data Source=LAPTOP-ECOVO9GP\\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";

        libDB lib = new libDB(chuoiketnoi);
        public  string TimNV(string v)
        {
            SqlCommand cmd  = lib.GetCmdNoAction("TimKiemNhanVien");
            cmd.Parameters.Add("@tenNV", System.Data.SqlDbType.NVarChar, 50).Value = v;
            string kq = (string) lib.Scalar(cmd);
            return kq;
        }
    }
}

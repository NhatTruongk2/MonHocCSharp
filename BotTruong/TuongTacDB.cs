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

        public string TimNCC(string v)
        {
            SqlCommand cmd = lib.GetCmdNoAction("TimKiemNhaCungCap");
            cmd.Parameters.Add("@tenNCC", System.Data.SqlDbType.NVarChar, 50).Value = v;
            string kq = (string)lib.Scalar(cmd);
            return kq;
        }

        public string TimMATHANG(string v)
        {
            SqlCommand cmd = lib.GetCmdNoAction("TimKiemMatHang");
            cmd.Parameters.Add("@tenHANG", System.Data.SqlDbType.NVarChar, 50).Value = v;
            string kq = (string)lib.Scalar(cmd);
            return kq;
        }

        public string TimKH(string v)
        {
            SqlCommand cmd = lib.GetCmdNoAction("TimKiemkhachHang");
            cmd.Parameters.Add("@maKH", System.Data.SqlDbType.NVarChar, 50).Value = v;
            string kq = (string)lib.Scalar(cmd);
            return kq;
        }

    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace demo
{

    public partial class Form1 : Form
    {
        modify Modify;
        chitietdonhang Chitietdonhang;
        mathang mathang;
        nhacungcap Nhacungcap;
        dondathang Dondathang;
        khachhang Khachhang;
        nhanvien Nhanvien;
        BotTruong.Form1 f;
        
        string chuoiketnoi = "Data Source=LAPTOP-ECOVO9GP\\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            f = new BotTruong.Form1();
            f.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Modify = new modify();
            try {
                dataGridView1.DataSource = Modify.getALLchitietdonhang();
            }
            catch {

            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Modify = new modify();
            try
            {
                dataGridView5.DataSource = Modify.getALLchitietdonhang();
            }
            catch
            {

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string chuoiketnoi = "Data Source=LAPTOP-ECOVO9GP\\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(chuoiketnoi);
            sqlCon.Open();
            String chuoiTruyVan = "select * from chitietdathang";
            //Tạo đối tượng thực hiện lệnh truy vấn 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = chuoiTruyVan;
            cmd.Connection = sqlCon;
            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);

            dataGridView1.DataSource = data;


            sqlCon.Close();
            dataReader.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sohoadon = Convert.ToInt32(txtsohoadon.Text);
            string makhachhang = txtmakh.Text;
            string manhanvien = txtmanv.Text;

            DateTime ngaydathang;
            if (!DateTime.TryParse(txtngaydathang.Text, out ngaydathang))
            {
                MessageBox.Show("Ngày Đặt hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngaygiaohang;
            if (!DateTime.TryParse(txtngaygiaohang.Text, out ngaygiaohang))
            {
                MessageBox.Show("Ngày giao hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngaychuyenhang;
            if (!DateTime.TryParse(txtngaychuyenhang.Text, out ngaychuyenhang))
            {
                MessageBox.Show("Ngày chuyển hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string noigiaohang = txtnoigiaohang.Text;
           

            dondathang dondathang = new dondathang(sohoadon, makhachhang, manhanvien, ngaydathang, ngaygiaohang, ngaychuyenhang, noigiaohang);

            string query = "sp_dondathang";

            LibDataBase libDB = new LibDataBase(chuoiketnoi);
            SqlCommand cmd = libDB.GetCmd(query, "ADD");

            truyenParameterDondathang(ref cmd, dondathang);

            try
            {
                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void truyenParameterDondathang(ref SqlCommand cmd, dondathang dondathang)
        {
            cmd.Parameters.Add("@Sohoadon", SqlDbType.Int).Value = dondathang.Sohoadon;
            cmd.Parameters.Add("@Makhachhang", SqlDbType.NVarChar).Value = dondathang.Makhachhang;
            cmd.Parameters.Add("@Manhanvien", SqlDbType.NVarChar).Value = dondathang.Manhanvien;
            cmd.Parameters.Add("@Ngaydathang", SqlDbType.SmallDateTime).Value = dondathang.Ngaydathang;
            cmd.Parameters.Add("@Ngaygiaohang", SqlDbType.SmallDateTime).Value = dondathang.Ngaygiaohang;
            cmd.Parameters.Add("@Ngachuyenhang", SqlDbType.SmallDateTime).Value = dondathang.Ngaychuyenhang;
            cmd.Parameters.Add("@Noigiaohang", SqlDbType.SmallDateTime).Value = dondathang.Noigiaohang;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string chuoiketnoi = "Data Source=LAPTOP-ECOVO9GP\\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(chuoiketnoi);
            sqlCon.Open();
            String chuoiTruyVan = "select * from khachhang";
            //Tạo đối tượng thực hiện lệnh truy vấn 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = chuoiTruyVan;
            cmd.Connection = sqlCon;
            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);

            dataGridView3.DataSource = data;


            sqlCon.Close();
            dataReader.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string chuoiketnoi = "Data Source=LAPTOP-ECOVO9GP\\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(chuoiketnoi);
            sqlCon.Open();
            String chuoiTruyVan = "select * from dondathang";
            //Tạo đối tượng thực hiện lệnh truy vấn 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = chuoiTruyVan;
            cmd.Connection = sqlCon;
            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);

            dataGridView2.DataSource = data;


            sqlCon.Close();
            dataReader.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string chuoiketnoi = "Data Source=LAPTOP-ECOVO9GP\\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(chuoiketnoi);
            sqlCon.Open();
            String chuoiTruyVan = "select * from nhanvien";
            //Tạo đối tượng thực hiện lệnh truy vấn 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = chuoiTruyVan;
            cmd.Connection = sqlCon;
            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);

            dataGridView4.DataSource = data;


            sqlCon.Close();
            dataReader.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(chuoiketnoi);
            sqlCon.Open();
            String chuoiTruyVan = "select * from mathang";
            //Tạo đối tượng thực hiện lệnh truy vấn 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = chuoiTruyVan;
            cmd.Connection = sqlCon;
            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);

            dataGridView5.DataSource = data;


            sqlCon.Close();
            dataReader.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string chuoiketnoi = "Data Source=LAPTOP-ECOVO9GP\\SQLEXPRESS;Initial Catalog=BTL;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(chuoiketnoi);
            sqlCon.Open();
            String chuoiTruyVan = "select * from nhacungcap";
            //Tạo đối tượng thực hiện lệnh truy vấn 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = chuoiTruyVan;
            cmd.Connection = sqlCon;
            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(dataReader);

            dataGridView6.DataSource = data;


            sqlCon.Close();
            dataReader.Close();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int sohoadon = Convert.ToInt32(row.Cells["sohoadon"].Value); // Thay "sohoadon" bằng tên cột chứa số hóa đơn
                string mahang = row.Cells["mahang"].Value.ToString(); // Thay "mahang" bằng tên cột chứa mã hàng
                double giaban = Convert.ToDouble(row.Cells["giaban"].Value);
                int soluong = Convert.ToInt32(row.Cells["soluong"].Value);
                double mucgiamgia = Convert.ToDouble(row.Cells["mucgiamgia"].Value);

                // Tạo câu truy vấn SQL hoặc gọi procedure để xóa dữ liệu
                string query = "sp_chitietdonhang";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "DELETE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Sohoadon", SqlDbType.Int).Value = sohoadon;
                cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar, 10).Value = mahang;
                cmd.Parameters.Add("@Soluong", SqlDbType.SmallInt).Value = soluong;
                cmd.Parameters.Add("@Mucgiamgia", SqlDbType.Real).Value = mucgiamgia;
                cmd.Parameters.Add("@Giaban", SqlDbType.Money).Value = giaban;

                try
                {
                    int kq = libDB.RunSQL(cmd);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    

        



        private void button3_Click(object sender, EventArgs e)
        {
            // lấy tất cả dữ liệu đã nhập xuống:
            // Nên check lỗi người dùng nhập! => nếu mà lỗi thì return;
            int sohoadon = Convert.ToInt32(txt1.Text);
            string mahang = this.txt2.Text;
            Double giaban = Convert.ToDouble(txt3.Text);
            int soluong = Convert.ToInt32(txt4.Text);
            Double mucgiamgia = Convert.ToDouble(txt5.Text);
            chitietdonhang chitietdonhang = new chitietdonhang(sohoadon,mahang,giaban,soluong,mucgiamgia);

            // tao demo thực hiện proceduce - chuỗi k phải sql nữa mà là tên proceduce
            // chuẩn bị tên proceduce:
            string query = "sp_chitietdonhang"; 
            // new đối tượng thư viên để gọi các hàm trong thư viện:
            LibDataBase libDB = new LibDataBase(chuoiketnoi);
            SqlCommand cmd = libDB.GetCmd(query, "ADD"); // lấy về đối tượng sqlcomman

            // Cần phải truyền dũ liệu cho cmd 
            truyenParameter(ref cmd, chitietdonhang);
            //cmd.Parameters.Add("@Sohoadon", SqlDbType.Int).Value = chitietdonhang.Sohoadon;
            //cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar, 10).Value = chitietdonhang.Mahang;
            //cmd.Parameters.Add("@Soluong", SqlDbType.SmallInt).Value = chitietdonhang.Soluong;
            //cmd.Parameters.Add("@Mucgiamgia", SqlDbType.Real).Value = chitietdonhang.Mucgiamga;
            //cmd.Parameters.Add("@Giaban", SqlDbType.Money).Value = chitietdonhang.Giaban;

            // thực hiện proceduce bằng cách là gọi  thư viên
            try
            {
                // đây là câu lệnh thêm nên 
                int kq = libDB.RunSQL(cmd);
                if(kq > 0)
                {
                    MessageBox.Show("thêm thành công!");
                    Form1_Load(sender,e);
                    xoaThongTin();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           //chitietdonhang = new chitietdonhang(sohoadon,mahang,giaban,soluong,mucgiamgia);
           //if(modify.insert(chitietdonhang))
           // {
           //     dataGridView1.DataSource = modify.getALLchitietdonhang();
           // }
           // else
           // {
           //     MessageBox.Show("lỗi:" + "không thể thêm thông tin sinh viên", "lỗi", MessageBoxButtons.OK,
           //          MessageBoxIcon.Error);
           // }    
            
        }

        private void xoaThongTin()
        {

        }

        private void truyenParameter(ref SqlCommand cmd, chitietdonhang chitietdonhang)
        {
            //         @Sohoadon INT,
            //@Mahang NVARCHAR(10),
            // @Giaban MONEY,
            // @Soluong SMALLINT,
            // @Mucgiamgia REAL,
            cmd.Parameters.Add("@Sohoadon", SqlDbType.Int).Value = chitietdonhang.Sohoadon;
            cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar,10).Value = chitietdonhang.Mahang;
            cmd.Parameters.Add("@Soluong", SqlDbType.SmallInt).Value = chitietdonhang.Soluong;
            cmd.Parameters.Add("@Mucgiamgia", SqlDbType.Real).Value = chitietdonhang.Mucgiamga;
            cmd.Parameters.Add("@Giaban", SqlDbType.Money).Value = chitietdonhang.Giaban;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
          
            
            string mahang = this.txt6.Text;
            string tenhang = this.txt7.Text;
            string macongty = this.txt8.Text;
            int maloaihang = Convert.ToInt32(txt9.Text);
            int soluong = Convert.ToInt32(txt10.Text);
            string donvitinh = this.txt11.Text;
            double giaban = Convert.ToDouble(txt12.Text);  

          
           mathang mathang = new mathang(mahang, tenhang, macongty, maloaihang, soluong,donvitinh,giaban);

           
            string query = "sp_mathang";
       
            LibDataBase libDB = new LibDataBase(chuoiketnoi);
            SqlCommand cmd = libDB.GetCmd(query, "ADD"); 

           
            truyenParameterMatHang(ref cmd, mathang);
          

            
            try
            {
                
                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("thêm thành công!");
                
               
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void truyenParameterMatHang(ref SqlCommand cmd, mathang mathang)
        {

            cmd.Parameters.Add("@Tenhang", SqlDbType.NVarChar).Value = mathang.Tenhang;
            cmd.Parameters.Add("@Macongty", SqlDbType.NVarChar).Value = mathang.Macongty;
            cmd.Parameters.Add("@Maloaihang", SqlDbType.Int).Value = mathang.Maloaihang;
            cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar, 10).Value = mathang.Mahang;
            cmd.Parameters.Add("@Soluong", SqlDbType.Int).Value = mathang.Soluong;
            cmd.Parameters.Add("@Donvitinh", SqlDbType.NVarChar).Value = mathang.Donvitinh;
            cmd.Parameters.Add("@Giahang", SqlDbType.Money).Value = mathang.Giahang;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int sohoadon = Convert.ToInt32(txt1.Text);
                string mahang = txt2.Text;
                double giaban = Convert.ToDouble(txt3.Text);
                int soluong = Convert.ToInt32(txt4.Text);
                double mucgiamgia = Convert.ToDouble(txt5.Text);

                string query = "sp_chitietdonhang";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "UPDATE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Sohoadon", SqlDbType.Int).Value = sohoadon;
                cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar, 10).Value = mahang;
                cmd.Parameters.Add("@Giaban", SqlDbType.Money).Value = giaban;
                cmd.Parameters.Add("@Soluong", SqlDbType.SmallInt).Value = soluong;
                cmd.Parameters.Add("@Mucgiamgia", SqlDbType.Real).Value = mucgiamgia;

                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    Form1_Load(sender, e);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Định dạng đầu vào không đúng. Vui lòng kiểm tra lại các giá trị nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string makhachhang = this.txtmakhachhang.Text;
            string tencongty = this.txttencongty.Text;
            string tengiaodich = this.txttengiaodich.Text;
            string diachi = this.txtdiachi2.Text;
            string email = this.txtemail2.Text;
            string dienthoai = this.txtdienthoai2.Text;
            string fax = this.txtfax2.Text;



            khachhang khachhang = new khachhang(makhachhang, tencongty, tengiaodich,
                diachi, email, dienthoai, fax);


            string query = "sp_khachhang";

            LibDataBase libDB = new LibDataBase(chuoiketnoi);
            SqlCommand cmd = libDB.GetCmd(query, "ADD");


            truyenParameterKhachhang(ref cmd, khachhang);



            try
            {

                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("thêm thành công!");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void truyenParameterKhachhang(ref SqlCommand cmd, khachhang khachhang)
        {
            cmd.Parameters.Add("@Makhachhang", SqlDbType.NVarChar).Value = khachhang.Makhachhang;
            cmd.Parameters.Add("@Tencongty", SqlDbType.NVarChar, 10).Value = khachhang.Tencongty1;
            cmd.Parameters.Add("@Tengiaodich", SqlDbType.NVarChar).Value = khachhang.Tengiaodich;
            cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar).Value = khachhang.Diachi;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 10).Value = khachhang.Email;
            cmd.Parameters.Add("@Dienthoai", SqlDbType.NVarChar).Value = khachhang.Dienthoai;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = khachhang.Fax;
        }

        private void txtfax_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView5.SelectedRows[0];
                // Thay "sohoadon" bằng tên cột chứa số hóa đơn
                string mahang = row.Cells["mahang"].Value.ToString();
                string tenhang = row.Cells["tenhang"].Value.ToString();
                string macongty = row.Cells["macongty"].Value.ToString(); 
                int maloaihang = Convert.ToInt32(row.Cells["maloaihang"].Value);// Thay "mahang" bằng tên cột chứa mã hàng
              
                int soluong = Convert.ToInt32(row.Cells["soluong"].Value);
                string donvitinh = row.Cells["donvitinh"].Value.ToString();
                double giahang = Convert.ToDouble(row.Cells["giahang"].Value);

                // Tạo câu truy vấn SQL hoặc gọi procedure để xóa dữ liệu
                string query = "sp_mathang";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "DELETE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Tenhang", SqlDbType.NVarChar).Value = tenhang;
                cmd.Parameters.Add("@Macongty", SqlDbType.NVarChar).Value = macongty;
                cmd.Parameters.Add("@Maloaihang", SqlDbType.Int).Value = maloaihang;
                cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar, 10).Value = mahang;
                cmd.Parameters.Add("@Soluong", SqlDbType.Int).Value = soluong;
                cmd.Parameters.Add("@Donvitinh", SqlDbType.NVarChar).Value = donvitinh;
                cmd.Parameters.Add("@Giahang", SqlDbType.Money).Value = giahang;

                try
                {
                    int kq = libDB.RunSQL(cmd);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                string mahang = txt6.Text;
                string tenhang = txt7.Text;
                string macongty = txt8.Text;
            
                int maloaihang = Convert.ToInt32(txt9.Text);
                int soluong = Convert.ToInt32(txt10.Text);
                string donvitinh = txt11.Text;
                double giahang = Convert.ToDouble(txt12.Text);
              

                string query = "sp_mathang";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "UPDATE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar,10).Value = mahang;
                cmd.Parameters.Add("@Tenhang", SqlDbType.NVarChar, 10).Value = tenhang;
                cmd.Parameters.Add("@Macongty", SqlDbType.NVarChar, 10).Value = macongty;
                cmd.Parameters.Add("@Maloaihang", SqlDbType.Int).Value = maloaihang;
                cmd.Parameters.Add("@Soluong", SqlDbType.Int).Value = soluong;
                cmd.Parameters.Add("@Donvitinh", SqlDbType.NVarChar, 10).Value = donvitinh;
                cmd.Parameters.Add("@Giahang", SqlDbType.Money).Value = giahang;
             

                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    Form1_Load(sender, e);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Định dạng đầu vào không đúng. Vui lòng kiểm tra lại các giá trị nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string macongty = this.txtmacty.Text;
            string tencongty = this.txttencty.Text;
            string tengiaodich = this.txttengd.Text;
            string diachi = this.txtdiachi.Text;
            int dienthoai = Convert.ToInt32(txtdienthoai.Text);
            string fax = this.txtfax.Text;
            string email = this.txtemail.Text;

            nhacungcap nhacungcap = new nhacungcap(macongty, tencongty, tengiaodich, diachi, dienthoai, fax, email);

            string query = "sp_nhacungcap";

            LibDataBase libDB = new LibDataBase(chuoiketnoi);
            SqlCommand cmd = libDB.GetCmd(query, "ADD");

            truyenParameterNhacungcap(ref cmd, nhacungcap);

            try
            {
                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void truyenParameterNhacungcap(ref SqlCommand cmd, nhacungcap nhacungcap)
        {
            cmd.Parameters.Add("@Macongty", SqlDbType.NVarChar).Value = nhacungcap.Macongty;
            cmd.Parameters.Add("@Tencongty", SqlDbType.NVarChar).Value = nhacungcap.Tencongty;
            cmd.Parameters.Add("@Tengiaodich", SqlDbType.NVarChar).Value = nhacungcap.Tengiaodich;
            cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar).Value = nhacungcap.Diachi;
            cmd.Parameters.Add("@Dienthoai", SqlDbType.Int).Value = nhacungcap.Dienthoai;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = nhacungcap.Fax;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = nhacungcap.Email;
        }

        private void nhacungcap_Click(object sender, EventArgs e)
        {

        }

        private void txttencty_TextChanged(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                string macongty = txtmacty.Text;
                string tencongty = txttencty.Text;
                string tengiaodich = txttengd.Text;
                string diachi = txtdiachi.Text;

                int dienthoai = Convert.ToInt32(txtdienthoai.Text);
                string fax = txtfax.Text;
                string emai = txtemail.Text;
             


                string query = "sp_nhacungcap";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "UPDATE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Macongty", SqlDbType.NVarChar, 10).Value = macongty;
                cmd.Parameters.Add("@Tencongty", SqlDbType.NVarChar, 10).Value = tencongty;
                cmd.Parameters.Add("@Tengiaodich", SqlDbType.NVarChar, 10).Value = tengiaodich;
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar, 10).Value = diachi;
                cmd.Parameters.Add("@Dienthoai", SqlDbType.Int).Value = dienthoai;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar, 10).Value = fax;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 10).Value = emai;
                


                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    Form1_Load(sender, e);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Định dạng đầu vào không đúng. Vui lòng kiểm tra lại các giá trị nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                string makhachhang = txtmakhachhang.Text;
                string tencongty = txttencongty.Text;
                string tengiaodich = txttengiaodich.Text;
                string diachi = txtdiachi2.Text;
                string email = txtemail2.Text;
                string dienthoai = txtdienthoai2.Text;
                string fax = txtfax2.Text;




                string query = "sp_khachhang";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "UPDATE");

               


                cmd.Parameters.Add("@Makhachhang", SqlDbType.NVarChar).Value = makhachhang;
                cmd.Parameters.Add("@Tencongty", SqlDbType.NVarChar, 10).Value = tencongty;
                cmd.Parameters.Add("@Tengiaodich", SqlDbType.NVarChar).Value = tengiaodich;
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar).Value = diachi;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 10).Value = email;
                cmd.Parameters.Add("@Dienthoai", SqlDbType.NVarChar).Value = dienthoai;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;

                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    Form1_Load(sender, e);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Định dạng đầu vào không đúng. Vui lòng kiểm tra lại các giá trị nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView3.SelectedRows[0];
                // Thay "sohoadon" bằng tên cột chứa số hóa đơn
                string makhachhang = row.Cells["makhachhang"].Value.ToString();
                string tencongty = row.Cells["tencongty"].Value.ToString();
                string tengiaodich = row.Cells["tengiaodich"].Value.ToString();
                string diachi = row.Cells["diachi"].Value.ToString();
                string email = row.Cells["email"].Value.ToString();
                string dienthoai = row.Cells["dienthoai"].Value.ToString();
                string fax = row.Cells["fax"].Value.ToString();



                // Tạo câu truy vấn SQL hoặc gọi procedure để xóa dữ liệu
                string query = "sp_khachhang";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "DELETE");

                // Truyền tham số cho cmd
         

                cmd.Parameters.Add("@Makhachhang", SqlDbType.NVarChar).Value = makhachhang;
                cmd.Parameters.Add("@Tencongty", SqlDbType.NVarChar, 10).Value = tencongty;
                cmd.Parameters.Add("@Tengiaodich", SqlDbType.NVarChar).Value = tengiaodich;
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar).Value = diachi;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 10).Value = email;
                cmd.Parameters.Add("@Dienthoai", SqlDbType.NVarChar).Value = dienthoai;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;


                try
                {
                    int kq = libDB.RunSQL(cmd);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string manhanvien = txtmanhanvien.Text;
            string ho = txtho.Text;
            string ten = txtten.Text;

            DateTime ngaysinh;
            if (!DateTime.TryParse(txtngaysinh.Text, out ngaysinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngaylamviec;
            if (!DateTime.TryParse(txtngaylamviec.Text, out ngaylamviec))
            {
                MessageBox.Show("Ngày làm việc không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string diachi = txtdiachi.Text;
            string dienthoai = txtdienthoai.Text;

            double luongcoban;
            if (!double.TryParse(txtluongcb.Text, out luongcoban))
            {
                MessageBox.Show("Lương cơ bản không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double phucap;
            if (!double.TryParse(txtphucap.Text, out phucap))
            {
                MessageBox.Show("Phụ cấp không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nhanvien nhanvien = new nhanvien(manhanvien, ho, ten, ngaysinh, ngaylamviec, diachi, dienthoai, luongcoban, phucap);

            string query = "sp_nhanvien";

            LibDataBase libDB = new LibDataBase(chuoiketnoi);
            SqlCommand cmd = libDB.GetCmd(query, "ADD");

            truyenParameterNhanvien(ref cmd, nhanvien);

            try
            {
                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void truyenParameterNhanvien(ref SqlCommand cmd, nhanvien nhanvien)
        {

            cmd.Parameters.Add("@Manhanvien", SqlDbType.NVarChar).Value = nhanvien.Manhanvien;
            cmd.Parameters.Add("@Ho", SqlDbType.NVarChar).Value = nhanvien.Ho;
            cmd.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = nhanvien.Ten;
            cmd.Parameters.Add("@Ngaysinh", SqlDbType.DateTime).Value = nhanvien.Ngaysinh;
            cmd.Parameters.Add("@Ngaylamviec", SqlDbType.DateTime).Value = nhanvien.Ngaylamviec;
            cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar).Value = nhanvien.Diachi;
            cmd.Parameters.Add("@Dienthoai", SqlDbType.NVarChar).Value = nhanvien.Dienthoai;
            cmd.Parameters.Add("@Luongcoban", SqlDbType.Money).Value = nhanvien.Luongcoban;
            cmd.Parameters.Add("@Phucap", SqlDbType.Money).Value = nhanvien.Phucap;
        }

        private void txtsohoadon_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                string manhanvien = txtmanhanvien.Text;
                string ho = txtho.Text;
                string ten = txtten.Text;
                DateTime ngaysinh = Convert.ToDateTime(txtngaysinh.Text);
                DateTime ngaylamviec = Convert.ToDateTime(txtngaylamviec.Text);
                string diachi = txtdiachi3.Text;

                int dienthoai = Convert.ToInt32(txtdienthoai3.Text);
                double luongcoban = Convert.ToDouble(txtluongcb.Text);
                double phucap = Convert.ToDouble(txtphucap.Text);




                string query = "sp_nhanvien";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "UPDATE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Manhanvien", SqlDbType.NVarChar, 10).Value = manhanvien;
                cmd.Parameters.Add("@ho", SqlDbType.NVarChar, 10).Value = ho;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 10).Value = ten;
                cmd.Parameters.Add("@Ngaysinh", SqlDbType.DateTime, 10).Value = ngaysinh;
                cmd.Parameters.Add("@Ngaylamviec", SqlDbType.DateTime, 10).Value = ngaylamviec;
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar, 10).Value = diachi;
                cmd.Parameters.Add("@Dienthoai", SqlDbType.NVarChar).Value = dienthoai;
                cmd.Parameters.Add("@Luongcoban", SqlDbType.Money, 10).Value = luongcoban;
                cmd.Parameters.Add("@Phucap", SqlDbType.Money, 10).Value = phucap;



                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    Form1_Load(sender, e);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Định dạng đầu vào không đúng. Vui lòng kiểm tra lại các giá trị nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (dataGridView6.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView6.SelectedRows[0];
                // Thay "sohoadon" bằng tên cột chứa số hóa đơn
                string macongty = row.Cells["macongty"].Value.ToString();
                string tencongty = row.Cells["tencongty"].Value.ToString();
                string tengiaodich = row.Cells["tengiaodich"].Value.ToString();
                string diachi = row.Cells["diachi"].Value.ToString();
                int dienthoai = Convert.ToInt32(row.Cells["dienthoai"].Value);// Thay "mahang" bằng tên cột chứa mã hàng

                string fax = row.Cells["fax"].Value.ToString();
                string email = row.Cells["email"].Value.ToString();

                // Tạo câu truy vấn SQL hoặc gọi procedure để xóa dữ liệu
                string query = "sp_nhacungcap";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "DELETE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Macongty", SqlDbType.NVarChar).Value = macongty;
                cmd.Parameters.Add("@Tencongty", SqlDbType.NVarChar).Value = tencongty;
                cmd.Parameters.Add("@Tengiaodich", SqlDbType.NVarChar ).Value = tengiaodich;
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar, 10).Value = diachi;
                cmd.Parameters.Add("@Dienthoai", SqlDbType.NVarChar).Value = dienthoai;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;

                try
                {
                    int kq = libDB.RunSQL(cmd);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView4.SelectedRows[0];
                // Thay "sohoadon" bằng tên cột chứa số hóa đơn
                string manhanvien = row.Cells["manhanvien"].Value.ToString();
                string ho = row.Cells["ho"].Value.ToString();
                string ten = row.Cells["ten"].Value.ToString();
                DateTime ngaysinh = Convert.ToDateTime(row.Cells["ngaysinh"].Value);
                DateTime ngaylamviec = Convert.ToDateTime(row.Cells["ngaylamviec"].Value);
                string diachi = row.Cells["diachi"].Value.ToString();
                string dienthoai = row.Cells["dienthoai"].Value.ToString();
                double luongcoban = Convert.ToDouble(row.Cells["luongcoban"].Value);
                double phucap = Convert.ToDouble(row.Cells["phucap"].Value);

                // Tạo câu truy vấn SQL hoặc gọi procedure để xóa dữ liệu
                string query = "sp_nhanvien";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "DELETE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Manhanvien", SqlDbType.NVarChar, 10).Value = manhanvien;
                cmd.Parameters.Add("@ho", SqlDbType.NVarChar, 10).Value = ho;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 10).Value = ten;
                cmd.Parameters.Add("@Ngaysinh", SqlDbType.DateTime, 10).Value = ngaysinh;
                cmd.Parameters.Add("@Ngaylamviec", SqlDbType.DateTime, 10).Value = ngaylamviec;
                cmd.Parameters.Add("@Diachi", SqlDbType.NVarChar, 10).Value = diachi;
                cmd.Parameters.Add("@Dienthoai", SqlDbType.NVarChar).Value = dienthoai;
                cmd.Parameters.Add("@Luongcoban", SqlDbType.Money, 10).Value = luongcoban;
                cmd.Parameters.Add("@Phucap", SqlDbType.Money, 10).Value = phucap;

                try
                {
                    int kq = libDB.RunSQL(cmd);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int sohoadon = Convert.ToInt32(txtsohoadon.Text);
                string makhachhang = txtmakh.Text;
                string manhanvien = txtmanv.Text;
          
                DateTime ngaydathang = Convert.ToDateTime(txtngaydathang.Text);
                DateTime ngaychuyenhang = Convert.ToDateTime(txtngaychuyenhang.Text);
                DateTime ngaygiaohang = Convert.ToDateTime(txtngaygiaohang.Text);
                string noigiaohang = txtnoigiaohang.Text;

          




                string query = "sp_dondathang";
                LibDataBase libDB = new LibDataBase(chuoiketnoi);
                SqlCommand cmd = libDB.GetCmd(query, "UPDATE");

                // Truyền tham số cho cmd
                cmd.Parameters.Add("@Manhanvien", SqlDbType.NVarChar, 10).Value = manhanvien;
                cmd.Parameters.Add("@Makhachhang", SqlDbType.NVarChar, 10).Value = makhachhang;
                cmd.Parameters.Add("@Sohoadon", SqlDbType.NVarChar, 10).Value = sohoadon;
                cmd.Parameters.Add("@Ngaydathang", SqlDbType.SmallDateTime, 10).Value = ngaydathang;
                cmd.Parameters.Add("@Ngaychuyenhang", SqlDbType.SmallDateTime, 10).Value = ngaychuyenhang;
                cmd.Parameters.Add("@Ngaygiaohang", SqlDbType.SmallDateTime, 10).Value = ngaygiaohang;
                cmd.Parameters.Add("@Noigiaohang", SqlDbType.NVarChar).Value = noigiaohang;
          



                int kq = libDB.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    Form1_Load(sender, e);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Định dạng đầu vào không đúng. Vui lòng kiểm tra lại các giá trị nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void txtdienthoai2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfax_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }
    }
}

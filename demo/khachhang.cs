using System;
using System.Collections.Generic;
using System.Text;

namespace demo
{
    internal class khachhang
    {
        private string makhachhang;
        private string Tencongty;
        private string tengiaodich;
        private string diachi;
        private string email;
        private string dienthoai;
        private string fax;

        public khachhang(string makhachhang, string tencongty, string tengiaodich, string diachi, string email, string dienthoai, string fax)
        {
            this.makhachhang = makhachhang;
            Tencongty = tencongty;
            this.tengiaodich = tengiaodich;
            this.diachi = diachi;
            this.email = email;
            this.dienthoai = dienthoai;
            this.fax = fax;
        }

        public string Makhachhang { get => makhachhang; set => makhachhang = value; }
        public string Tencongty1 { get => Tencongty; set => Tencongty = value; }
        public string Tengiaodich { get => tengiaodich; set => tengiaodich = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Email { get => email; set => email = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }
        public string Fax { get => fax; set => fax = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace demo
{
    internal class dondathang
    {
        private int sohoadon;
        private string makhachhang;
        private string manhanvien;
        private DateTime ngaydathang;
        private DateTime ngaygiaohang;
        private DateTime ngaychuyenhang;
        private string noigiaohang;

        public dondathang(int sohoadon, string makhachhang, string manhanvien, DateTime ngaydathang, DateTime ngaygiaohang, DateTime ngaychuyenhang, string noigiaohang)
        {
            this.sohoadon = sohoadon;
            this.makhachhang = makhachhang;
            this.manhanvien = manhanvien;
            this.ngaydathang = ngaydathang;
            this.ngaygiaohang = ngaygiaohang;
            this.ngaychuyenhang = ngaychuyenhang;
            this.noigiaohang = noigiaohang;
        }

        public int Sohoadon { get => sohoadon; set => sohoadon = value; }
        public string Makhachhang { get => makhachhang; set => makhachhang = value; }
        public string Manhanvien { get => manhanvien; set => manhanvien = value; }
        public DateTime Ngaydathang { get => ngaydathang; set => ngaydathang = value; }
        public DateTime Ngaygiaohang { get => ngaygiaohang; set => ngaygiaohang = value; }
        public DateTime Ngaychuyenhang { get => ngaychuyenhang; set => ngaychuyenhang = value; }
        public string Noigiaohang { get => noigiaohang; set => noigiaohang = value; }
    }
}

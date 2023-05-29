using System;
using System.Collections.Generic;
using System.Text;

namespace demo
{
    internal class mathang
    {
        private string mahang;
        private string tenhang;
        private string macongty;
        private int maloaihang;
        private int soluong;
        private string donvitinh;
        private double giahang;
        public mathang(string mahang = null, string tenhang = null, string macongty = null, int maloaihang = 0, int soluong = 0, string donvitinh = null, double giahang = 0)
        {
            this.mahang = mahang;
            this.tenhang = tenhang;
            this.macongty = macongty;
            this.maloaihang = maloaihang;
            this.soluong = soluong;
            this.donvitinh = donvitinh;
            this.giahang = giahang;
        }




        public string Mahang { get => mahang; set => mahang = value; }
        public string Tenhang { get => tenhang; set => tenhang = value; }
        public string Macongty { get => macongty; set => macongty = value; }
        public int Maloaihang { get => maloaihang; set => maloaihang = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Donvitinh { get => donvitinh; set => donvitinh = value; }
        public double Giahang { get => giahang; set => giahang = value; }
    }
}

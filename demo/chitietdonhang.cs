using System;
using System.Collections.Generic;
using System.Text;

namespace demo
{
    internal class chitietdonhang
    {
       private int sohoadon;
       private String mahang;
    private    double giaban;
    private    int soluong;
    private    double mucgiamga;

        public chitietdonhang()
        {
        }

        public chitietdonhang(int sohoadon, string mahang, double giaban, int soluong, double mucgiamga)
        {
            this.sohoadon = sohoadon;
            this.mahang = mahang ?? throw new ArgumentNullException(nameof(mahang));
            this.giaban = giaban;
            this.soluong = soluong;
            this.mucgiamga = mucgiamga;
        }

        public int Sohoadon { get => sohoadon; set => sohoadon = value; }
        public string Mahang { get => mahang; set => mahang = value; }
        public double Giaban { get => giaban; set => giaban = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public double Mucgiamga { get => mucgiamga; set => mucgiamga = value; }
    }


}

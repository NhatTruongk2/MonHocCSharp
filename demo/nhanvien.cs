using System;
using System.Collections.Generic;
using System.Text;

namespace demo
{
    internal class nhanvien
    {

        private string manhanvien;
        private string ho;
        private string ten;
        private DateTime ngaysinh;
        private DateTime ngaylamviec;
        private string diachi;
        private string dienthoai;
        private double luongcoban;
        private double phucap;

        public nhanvien(string manhanvien, string ho, string ten, DateTime ngaysinh, DateTime ngaylamviec, string diachi, string dienthoai, double luongcoban, double phucap)
        {
            this.manhanvien = manhanvien;
            this.ho = ho;
            this.ten = ten;
            this.ngaysinh = ngaysinh;
            this.ngaylamviec = ngaylamviec;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
            this.luongcoban = luongcoban;
            this.phucap = phucap;
        }

        public string Manhanvien { get => manhanvien; set => manhanvien = value; }
        public string Ho { get => ho; set => ho = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public DateTime Ngaylamviec { get => ngaylamviec; set => ngaylamviec = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }
        public double Luongcoban { get => luongcoban; set => luongcoban = value; }
        public double Phucap { get => phucap; set => phucap = value; }
    }
}

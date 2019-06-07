using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques2
{
    class SinhVien
    {
        // Khai bao delegate
        public delegate void PhucKhaoHandler();
        // Khai bao event
        public event PhucKhaoHandler QuaMonEz;
        public event PhucKhaoHandler RotMon;

        static double quaMon = 5;
        double _diemTong = 0;
        // Chu y phuong thuc set
        public double DiemTong
        {
            get { return _diemTong; }
            set
            {
                _diemTong = value;
             
                if (_diemTong < quaMon)
                {
                    // Kich hoat event
                    if (RotMon != null)
                    {
                        RotMon();
                    }
                }
                else
                {
                    if(QuaMonEz != null)
                    {
                        QuaMonEz();
                    }
                }
            }
        }

        public void PhucKhaoDiem(double diemThem)
        {
            DiemTong += diemThem;
             _diemTong %= 10;
        }
    }
    class Ques2
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            SinhVien sv = new SinhVien()
            {
                DiemTong = rd.Next(0, 5)
            };
            // gan ket phuong thuc xu ly event
            sv.QuaMonEz += new SinhVien.PhucKhaoHandler(ThongBaoQuaMon);
            // ngan gon hon
            sv.RotMon += ThongBaoRotMon;
            char c = 'a';
            while (c != 'q')
            {
                Console.Write("Nhan a de phuc khao diem");
                if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    sv.PhucKhaoDiem(rd.Next(0, 3));
                }
                Console.WriteLine();
                Console.Write("Tiep tuc?");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        static void ThongBaoQuaMon()
        {
            Console.WriteLine();
            Console.WriteLine("Ban da qua mon, chuc mung ban!");
        }

        static void ThongBaoRotMon()
        {
            Console.WriteLine();
            Console.WriteLine("Ban da rot mon, xin chia buon!");
        }
    }
}

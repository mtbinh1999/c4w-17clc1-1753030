using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques1_04
{
    class KhachHang
    {
        // Khai bao delegate
        public delegate void HangMucHandler();
        // Khai bao event
        public event HangMucHandler DatMucBinhDan;
        public event HangMucHandler DatMucTrungCap;
        public event HangMucHandler DatMucCaoCap;

        static long mucTrungCap = 10000000;
        static long mucCaoCap = 100000000;
        long _taiKhoan = 0;
        // Chu y phuong thuc set
        public long TaiKhoan
        {
            get { return _taiKhoan; }
            set
            {
                _taiKhoan = value;
                // kiem tra hang muc va dua ra mong muon mua sam
                if(_taiKhoan < mucTrungCap)
                {
                    // Kich hoat event
                    if(DatMucBinhDan != null)
                    {
                        DatMucBinhDan();
                    }
                }
                else
                {
                    if(_taiKhoan < mucCaoCap)
                    {
                        if(DatMucTrungCap != null)
                        {
                            DatMucTrungCap();
                        }
                    }
                    else
                    {
                        if (DatMucCaoCap != null)
                        {
                            DatMucCaoCap();
                        }
                    }
                }
            }
        }

        public void ThemThuNhap(long soTien)
        {
            TaiKhoan += soTien;
        }
    }
    class Ques1_04
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            KhachHang kh = new KhachHang();
            // gan ket phuong thuc xu ly event
            kh.DatMucBinhDan += new KhachHang.HangMucHandler(TTBinhDan);
            // ngan gon hon
            kh.DatMucTrungCap += TTTrungCap;
            kh.DatMucCaoCap += TTCaoCap;
            char c = 'a';
            while(c != 'q')
            {
                Console.Write("Nhan a de them thu nhap");
                if(Console.ReadKey().Key == ConsoleKey.A)
                {
                    kh.ThemThuNhap(rd.Next(1000000, 9000000));
                }
                Console.WriteLine();
                Console.Write("Tiep tuc?");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        // Phuong thuc xu ly tiep thi hang binh dan
        static void TTBinhDan()
        {
            Console.WriteLine();
            Console.WriteLine("Tiep thi hang binh dan");
        }

        // Phuong thuc xu ly tiep thi hang trung cap
        static void TTTrungCap()
        {
            Console.WriteLine();
            Console.WriteLine("Tiep thi hang trung cap");
        }

        // Phuong thuc xu ly tiep thi hang cao cap
        static void TTCaoCap()
        {
            Console.WriteLine();
            Console.WriteLine("Tiep thi hang cao cap");
        }
    }
}

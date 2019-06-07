using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques1_03
{
    class SinhVien
    {
        int _MSSV;
        string _hoTen, _queQuan;
        public int MSSV
        {
            get { return _MSSV; }
            set { _MSSV = value; }
        }

        public string QueQuan
        {
            get { return _queQuan; }
            set { _queQuan = value; }
        }

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        public override string ToString()
        {
            return string.Format("<{0}>-{1}-[{2}]", _MSSV, _hoTen, _queQuan);
        }
    }
    class Ques1_03
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            // phat sinh so luong sv
            int n = rd.Next(5, 10);
            SinhVien[] dsSV = new SinhVien[n];
            for(int i = 0; i < n; i++)
            {
                // Cach khoi tao nhanh
                dsSV[i] = new SinhVien()
                {
                    MSSV = 1364000 + rd.Next(999),
                    HoTen = string.Format("{0}HT", (char)rd.Next(0x41, 0x5A)),
                    QueQuan = string.Format("{0}QQ", (char)rd.Next(0x61, 0x7A))
                };
            }
            char c = 'a';
            while(c != 'q')
            {
                Console.Write("Sap xep theo tieu chi (1, 2, 3): ");
                switch(Console.ReadKey().KeyChar)
                {
                    case '1':
                        // Sap xep theo MSSV
                        Array.Sort(dsSV, delegate (SinhVien sv1, SinhVien sv2)
                        {
                            return sv1.MSSV.CompareTo(sv2.MSSV);
                        });
                        break;
                    case '2':
                        // Sap xep theo HoTen
                        Array.Sort(dsSV, delegate (SinhVien sv1, SinhVien sv2)
                        {
                            return sv1.HoTen.CompareTo(sv2.HoTen);
                        });
                        break;
                    case '3':
                        // Sap xep theo QueQuan
                        Array.Sort(dsSV, delegate (SinhVien sv1, SinhVien sv2)
                        {
                            return sv1.QueQuan.CompareTo(sv2.QueQuan);
                        });
                        break;
                }
                Console.WriteLine();
                foreach(var item in dsSV)
                {
                    Console.WriteLine(item);
                }
                Console.Write("Tiep tuc?");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input n
            Console.Write("Nhap tong so dien: ");
            string strLine = Console.ReadLine();
            // Convert string to number
            int n = 0;
            if (!int.TryParse(strLine, out n))
            {
                n = 0;
            }
            if (n < 0)
            {
                Console.WriteLine("Nhap so dien khong hop le!");
                Environment.Exit(0);
            }
          
            Console.WriteLine();
            Console.WriteLine("Tong so tien: {0}", TinhTongTien(n));
        }

        static double TinhTongTien(int n)
        {
            double s = 0;
            int temp = 0;
            // 401 tro len
            if(n > 400)
            {
                temp = n - 400;
                s += temp * 2399;
                n = n - temp;
            }

            // 301-400
            if(n > 300)
            {
                temp = n - 300;
                s += temp * 2324;
                n = n - temp;
            }

            // 201-300
            if (n > 200)
            {
                temp = n - 200;
                s += temp * 2082;
                n = n - temp;
            }

            // 101-200
            if (n > 100)
            {
                temp = n - 100;
                s += temp * 1660;
                n = n - temp;
            }

            // 51-100
            if (n > 50)
            {
                temp = n - 50;
                s += temp * 1433;
                n = n - temp;
            }

            // 0-50
            if (n >= 0)
            {
                s += n * 1388;
            }

            return s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_01
{
    class Xulimang
    {
        static void Main(string[] args)
        {
            // Input n
            Console.Write("Nhap n: ");
            string strLine = Console.ReadLine();
            // Convert string to number
            int n = 1;
            if (!int.TryParse(strLine, out n))
            {
                n = 1;
            }
            if (n < 0)
            {
                n = -n;
            }

            // Init array
            Random rd = new Random();
            // Allocate
            int[] arrI = new int[n];
            for (int i = 0; i < n; i++)
            {
                arrI[i] = rd.Next(1000);
            }

            // Print array
            Console.WriteLine("Mang: ");
            for(int i = 0; i < n; i++)
            {
                Console.Write("{0}, ", arrI[i]);
            }

            double s = TinhTBCong(arrI);
            Console.WriteLine();
            Console.WriteLine("S = {0:F2}", s);

        }

        static double TinhTBCong(int[] arrI)
        {
            double s = 0;

            // Dat gia tri truoc la nho nhat
            int vOld = int.MinValue;
            // Bien giu mang con dang duyet
            int nCur = 0;
            double sCur = 0;
            // Bien giu tong so phan tu mang con
            int nS = 0;

            // Duyet mang
            for (int i = 0; i < arrI.Length; i++)
            {
                if (arrI[i] >= vOld)
                {
                    sCur += arrI[i];
                    nCur++;
                }
                else
                {
                    if (nCur > 1)
                    {
                        s += sCur;
                        nS += nCur;
                    }
                    sCur = 0;
                    nCur = 1;
                }
                vOld = arrI[i];
            }

            // Lay gia tri trung binh cong
            s /= nS;

            return s;
        }
    }
}

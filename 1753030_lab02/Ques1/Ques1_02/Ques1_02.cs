using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques1_02
{
    class XLTinhtoan
    {
        public static void PhepCong(decimal v1, decimal v2)
        {
            Console.WriteLine("{0} + {1} = {2}", v1, v2, v1 + v2);
        }

        public static void PhepTru(decimal v1, decimal v2)
        {
            Console.WriteLine("{0} - {1} = {2}", v1, v2, v1 - v2);
        }

        public static void PhepNhan(decimal v1, decimal v2)
        {
            Console.WriteLine("{0} * {1} = {2}", v1, v2, v1 * v2);
        }

        public static void PhepChia(decimal v1, decimal v2)
        {
            Console.WriteLine("{0} / {1} = {2}", v1, v2, v1 / v2);
        }
    }
    class Ques1_02
    {
        delegate void KQTinhToan(decimal v1, decimal v2);
        static void Main(string[] args)
        {
            KQTinhToan tt = XLTinhtoan.PhepCong;
            tt += XLTinhtoan.PhepTru;
            tt += XLTinhtoan.PhepNhan;
            tt += XLTinhtoan.PhepChia;

            decimal v1, v2;
            char c = 'a';

            while(c != 'q')
            {
                Console.Write("Nhap vao 2 so: ");
                v1 = NhapSo();
                v2 = NhapSo();
                // Chi invoke delegate 1 lan
                tt(v1, v2);
                Console.Write("Tiep tuc?");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        static decimal NhapSo()
        {
            decimal n = 0;
            string strLine = Console.ReadLine();
            if(!decimal.TryParse(strLine, out n))
            {
                n = -1;
            }

            return n;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques1
{
    class Ques1_01
    {
        delegate decimal TinhToan(decimal v1, decimal v2);
        static void Main(string[] args)
        {
            Random rd = new Random();
            decimal v1, v2;
            char c = 'a', pt;

            while(c != 'q')
            {
                TinhToan tt = LuaChonPhepToan(out pt);
                v1 = rd.Next(1000);
                v2 = rd.Next(1000);
                Console.WriteLine("\n{0} {1} {2} = {3}", v1, pt, v2, tt(v1, v2));
                Console.Write("Tiep tuc?");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }

        static TinhToan LuaChonPhepToan(out char phepToan)
        {
            // delegate giu ham tinh toan
            TinhToan tt = null;

            Console.Write("Lua chon phep toan: ");
            phepToan = Console.ReadKey().KeyChar;
            switch (phepToan)
            {
                case '+':
                    tt = new TinhToan(MathOperations.Cong);
                    break;
                case '-':
                    tt = new TinhToan(MathOperations.Tru);
                    break;
                case '*':
                    tt = new TinhToan(MathOperations.Nhan);
                    break;
                case '/':
                    tt = new TinhToan(MathOperations.Chia);
                    break;
            }
            return tt;
        }
    }

    class MathOperations
    {
        public static decimal Cong(decimal v1, decimal v2)
        {
            return v1 + v2;
        }

        public static decimal Tru(decimal v1, decimal v2)
        {
            return v1 - v2;
        }

        public static decimal Nhan(decimal v1, decimal v2)
        {
            return v1 * v2;
        }

        public static decimal Chia(decimal v1, decimal v2)
        {
            return v1 / v2;
        }
    }

}

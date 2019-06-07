using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input n
            Console.Write("Nhap n: ");
            string strLine = Console.ReadLine();
            // Convert string to number
            uint n = 1;
            if (!uint.TryParse(strLine, out n))
            {
                n = 1;
            }
            Console.WriteLine();

            // call fucntion CalSn and print
            Console.WriteLine("S({0}) = {1}", n, CalSn(n));
        }

        static double CalSn(uint n)
        {
            double s = 0;
            for(uint i = n; i > 0; i--)
            {
                s = Math.Sqrt(s + i);
            }
            return s;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_01
{
    class Xulychuoi
    {
        static void Main(string[] args)
        {
            // Nhap chuoi
            Console.Write("Nhap chuoi: ");
            string strIn = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Chuoi nguoc: {0}", ChuoiTuNguoc(strIn));
        }

        static string ChuoiTuNguoc(string strIn)
        {
            // Su dung StringBuilder de tao chuoi
            StringBuilder sb = new StringBuilder();

            // Tach cac tu trong chuoi
            string[] arrStr = strIn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Dua vao tao chuoi
            for(int i = arrStr.Length - 1; i > 0; i--)
            {
                sb.AppendFormat("{0} ", arrStr[i]);
            }
            if(arrStr.Length > 0)
            {
                sb.Append(arrStr[0]);
            }

            return sb.ToString();
        }
    }
}

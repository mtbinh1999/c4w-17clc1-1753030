using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrDayOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] arrDayMonthOfLeapYear = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int day = 0, month = 0, year = 0;
            do
            {
                Console.Write("Nhap nam: ");
                string strLine = Console.ReadLine();
                int.TryParse(strLine, out year);
                Console.Write("Nhap thang: ");
                strLine = Console.ReadLine();
                int.TryParse(strLine, out month);
            } while (!checkInput(month, year));

            if(checkLeapYear(year))
            {
                day = arrDayMonthOfLeapYear[month - 1];
            }
            else
            {
                day = arrDayOfMonth[month - 1];
            }

            Console.WriteLine("Thang {0} co: {1} ngay", month, day);
        }

        static bool checkInput(int month, int year)
        {
            if (year < 0)
                return false;
            if (month < 0 || month > 12)
                return false;
            return true;
        }

        static bool checkLeapYear(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                return true;
            return false;
        }
    }
}

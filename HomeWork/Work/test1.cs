using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Work
{
    //编写一个程序，接受用户输入的一个浮点数，把它的整数部分和小数部分分别输出
    internal class test1
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("请输入一个浮点数：");
        //    string input = Console.ReadLine();
        //    double number;
        //    if (double.TryParse(input, out number))
        //    {
        //        int integerPart = (int)number;
        //        double decimalPart = number - integerPart;
        //        Console.WriteLine("整数部分: " + integerPart);
        //        Console.WriteLine("小数部分: " + decimalPart);
        //    }
        //    else
        //    {
        //        Console.WriteLine("输入无效，请输入一个有效的浮点数。");
        //    }
        //}

        public test1()
        {
            Console.WriteLine("请输入一个浮点数：");
            string input = Console.ReadLine();
            #region 第一种方案
            decimal number;
            if (decimal.TryParse(input, out number))
            {
                int integerPart = (int)number;
                decimal decimalPart = number - integerPart;
                Console.WriteLine("整数部分: " + integerPart);
                Console.WriteLine("小数部分: " + decimalPart);
            }
            else
            {
                Console.WriteLine("输入无效，请输入一个有效的浮点数。");
                new test1();    //递归调用，重新输入
            }
            #endregion

            /* #region 第二种方案,不行没有办法判断输入的是否是浮点数
             if (input.Contains('.'))
             {
                 string[] parts = input.Split('.');
                 Console.WriteLine("整数部分: " + parts[0]);
                 Console.WriteLine("小数部分: " + parts[1]);
             }
             else
             {
                 Console.WriteLine("输入无效，请输入一个有效的浮点数。");
                 new test1();    //递归调用，重新输入
             }
             #endregion*/

        }
    }
}

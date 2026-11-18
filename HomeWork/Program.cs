//.NET基础
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//本项目其他文件夹下的类
using HomeWork.Work;
using HomeWork.ClassWork;
using HomeWork.Work1113;
using HomeWork.Work1116;
using HomeWork.Work1117;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test1
            //new test1();
            //test2
            //new test2();
            //test3
            //new test3();

            //classwork
            /*Car baoma = new Car()
            {
                Length = 4000,
                Width = 1600,
                Nameplate = "宝马"
            };
            Console.WriteLine($"{baoma.Nameplate}的信息：{baoma.Width} x {baoma.Length}");
            baoma.Forword();
            Console.WriteLine("请输入车辆信息：");
            Car benchi = new Car(
                int.TryParse(Console.ReadLine(), out int width) ? width : -1, 
                int.TryParse(Console.ReadLine(), out int height) ? height : -1, 
                Console.ReadLine());
            Console.WriteLine($"{benchi.Nameplate}的信息：{benchi.Width} x {benchi.Length}");
            benchi.Forword();*/

            //new Class1();

            //Work1113
            //Date ddd = new Date(2026, 11, 13, Date.Week.Thursday);
            //Console.WriteLine($"{ddd.Year}:{ddd.Month}:{ddd.Day}:{ddd.week}");
            //Console.WriteLine("请按次输入年、月、日、星期");
            //Date ddd2 = new Date(
            //    int.TryParse(Console.ReadLine(), out int y) ? y : -1,
            //    int.TryParse(Console.ReadLine(), out int m) ? m : -1,
            //    int.TryParse(Console.ReadLine(), out int d) ? d : -1,
            //    Enum.TryParse(Console.ReadLine(), true, out Date.Week www) ? www : Date.Week.Other
            //    );
            ////Enum.TryParse处理数值型字符串不会失败，需要用isDefind判定是否超出范围
            ////如果是文本型字符串会判断是否为该枚举类型Week范围内的值。否则转换失败www赋值默认值
            //Console.WriteLine(www);//输入信息转换失败是为默认值 0 显示Sunday
            //Console.WriteLine((int)www);//显示0
            //Console.WriteLine($"{ddd2.Year}:{ddd2.Month}:{ddd2.Day}:{ddd2.week}");

            //work1116
            /*CalculateWeek calculateWeek = new CalculateWeek();
            calculateWeek.calWeekByToday();
            //圆类
            Console.WriteLine("请输入圆的半径");
            if (double.TryParse(Console.ReadLine(), out double r))
            {
                new Circles(r, out double area, out double perimeter);
                Console.WriteLine($"半径为{r}的圆的周长为：{perimeter.ToString("0.##")}" +
                    $"面积为：{area.ToString("F4")}");
            }*/


            //test6
            test6 test = new test6();
            //test.question1();
            //test.question2();

            Company company = new Company();
            //company.AinputB();
            company.calSqrt();

            //git版本管理测试，创建分支test-feature
        }
    }
}

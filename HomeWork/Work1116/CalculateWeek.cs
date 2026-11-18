using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Work1116
{
    internal class CalculateWeek
    {
        //3、根据吉姆拉尔森公式（d+2*m+3*(m+1)/5+y+y/4-y/100+y/400+1）%7,使用switch语句
        //判断今天是星期几？（0~6 代表星期天~星期六）
        /// <summary>
        /// 根据系统日期计算今天是周几
        /// </summary>
        public void calWeekByToday()
        {
            DayOfWeek toweek;
            DateTime today = DateTime.Today;
            Console.WriteLine($"today:{today.ToShortDateString()}");
            int dayToweek = (today.Day +
                2 * today.Month +
                3 * (today.Month + 1) / 5 +
                today.Year +
                today.Year / 4 -
                today.Year / 100 +
                today.Year / 400 + 1) % 7;
            switch (dayToweek)
            {
                case 0:
                    toweek = DayOfWeek.Sunday;
                    Console.WriteLine($"今天是：{toweek}");
                    break;
                case 1:
                    toweek = DayOfWeek.Monday;
                    Console.WriteLine($"今天是：{toweek}");
                    break;
                case 2:
                    toweek = DayOfWeek.Tuesday;
                    Console.WriteLine($"今天是：{toweek}");
                    break;
                case 3:
                    toweek = DayOfWeek.Wednesday;
                    Console.WriteLine($"今天是：{toweek}");
                    break;
                case 4:
                    toweek = DayOfWeek.Thursday;
                    Console.WriteLine($"今天是：{toweek}");
                    break;
                case 5:
                    toweek = DayOfWeek.Friday;
                    Console.WriteLine($"今天是：{toweek}");
                    break;
                case 6:
                    toweek = DayOfWeek.Saturday;
                    Console.WriteLine($"今天是：{toweek}");
                    break;
                default:
                    break;
            }
        }
        
    }
}

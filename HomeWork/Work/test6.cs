using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Work
{
    internal class test6
    {
        public void question1()
        {
            //请输入的数组的最大值、最小值、平均值、求和
            Console.WriteLine("请输入数组长度");
            if (int.TryParse(Console.ReadLine(), out int length))
            {
                int[] nums = new int[length];
                int sum = 0, max = 0, min = 0;
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine($"请输入第{i + 1}个元素值");
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        sum += num;
                        max = num > max ? num : max;
                        min = i == 0 ? num : (num < min ? num : min);
                    }
                    else
                    {
                        Console.WriteLine("请重新输入有效数字");
                        i--;
                    }
                }
                Console.WriteLine($"最大值：{max}");
                Console.WriteLine($"最小值：{min}");
                Console.WriteLine($"求和：{sum}");
                Console.WriteLine($"平均值{sum / length}");
            }
        }
        //输入一个数字（单位：秒）显示为几天几小时几分钟几秒
        public void question2()
        {
            Console.WriteLine("请输入一串数字");
            if (int.TryParse(Console.ReadLine(), out int ms))
            {
                int s = ms % 60;
                int minutes = (ms / 60) % 60;
                int hours = ms / 60 / 60 % 24;
                int days = ms / 60 / 60 / 24;
                Console.WriteLine($"{days}天{hours}小时{minutes}分钟{s}秒");
            }
        }



    }
}

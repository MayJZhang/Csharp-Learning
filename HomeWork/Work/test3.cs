using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Work
{
    //编写一个程序求整数数组的最大值，最小值，平均值和所有数组元素的和
    internal class test3
    {
        public test3()
        {
            List<int> numbers = new List<int>();
            int i = 0;
            while (true)
            {
                Console.WriteLine("请输入一个整数：");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    numbers.Add(number);
                    i++;
                }
                else
                {
                    Console.WriteLine("输入无效，请输入一个有效的整数。");
                    continue; // 重新输入当前索引的整数
                }
                Console.WriteLine($"您已输入 {i} 个整数，是否继续输入？(y/n)");
                string choice = Console.ReadLine();
                if (choice.ToLower() != "y")
                {
                    break;
                }
            }
            Console.WriteLine($"最大数为：{numbers.Max()}");
            Console.WriteLine($"最小数为：{numbers.Min()}");
            Console.WriteLine($"平均值为：{numbers.Average()}");
            Console.WriteLine($"所有数之和为：{numbers.Sum()}");

        }
    }
}

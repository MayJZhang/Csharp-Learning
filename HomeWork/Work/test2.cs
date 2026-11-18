using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Work
{
    //编写一个程序，接受用户输入的10个整数，比较并输出其中的最大值和最小值
    internal class test2
    {
        /*public test2()
        {
            int[] numbers = new int[10];
            Console.WriteLine("请输入10个整数：");
            for (int i = 0; i < 10; i++)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    numbers[i] = number;
                }
                else
                {
                    Console.WriteLine("输入无效，请输入一个有效的整数。");
                    i--; // 重新输入当前索引的整数
                }
            }
            int max = numbers.Max();
            int min = numbers.Min();
            Console.WriteLine("最大值: " + max);
            Console.WriteLine("最小值: " + min);
        }*/

       /* public test2()
        {
            int[] numbers = new int[10];
            Console.WriteLine("请输入10个整数：");
            for (int i = 0; i < 10; i++)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    numbers[i] = number;
                }
                else
                {
                    Console.WriteLine("输入无效，请输入一个有效的整数。");
                    i--; // 重新输入当前索引的整数
                }
            }
            int max = numbers[0];
            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            Console.WriteLine("最大值: " + max);
            Console.WriteLine("最小值: " + min);
        }*/

        public test2()
        {
            int[] inputNums= new int[10];
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"请输入第{i + 1}个整数：");
                string input = Console.ReadLine();
                if(int.TryParse(input, out int number))
                {
                    inputNums[i] = number;
                }
                else
                {
                    Console.WriteLine("输入无效，请重新输入一个整数。");
                    i--; // 重新输入当前索引的整数
                }
            }
            Console.WriteLine($"您输入的数字为：{string.Join(", ", inputNums)}");
            Console.WriteLine($"最大值为：{inputNums.Max()}");
            Console.WriteLine($"最小值为：{inputNums.Min()}");
        }
    }
}

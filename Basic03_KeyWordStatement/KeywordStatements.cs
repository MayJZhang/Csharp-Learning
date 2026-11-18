using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic03_KeyWordStatement
{
    //关键字语句
    internal class KeywordStatements
    {
        enum Gender
        {
            Male,
            Female,
            Other
        }
        public KeywordStatements()
        {
            #region if else 分支语句
            //if根据布尔表达式为 true 的时候执行其所属代码块，添加一个else代码块，提供条件为 false时运行的代码。
            bool bb = true;
            if (bb)
            {
                /*if分支代码段*/
            }
            else if (!bb)    //两个以上路径选择可以添加else if串联
            {
                /*else if分支代码段*/
            }
            else
            {
                /*代码段*/
            }
            /*任意3个正实数，设计一个算法，判断以这3个数为边长的三角形是否存在*/
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                if (int.TryParse(Console.ReadLine(), out int b))
                {
                    if (int.TryParse(Console.ReadLine(), out int c))
                    {
                        if (a + b > c && a + c > b && b + c > a)
                            Console.WriteLine("是三角形");
                        else
                            Console.WriteLine("不是三角形");
                    }
                    else
                        Console.WriteLine("c边请输入数字");
                }
                else
                    Console.WriteLine("b边请输入数字");
            }
            else
                Console.WriteLine("a边请输入数字");

            //控制台输入两个浮点数，分别求加结果，减结果，乘结果和除结果并打印出来
            if (double.TryParse(Console.ReadLine(), out double aa))
            {
                if (double.TryParse(Console.ReadLine(), out double bbb))
                {
                    Console.WriteLine($"{aa}+{bbb}：{aa + bbb}/n" +
                        $"{aa}-{bbb}：{aa - bbb}/n");
                }
            }
            #endregion

            #region switch case分支语句
            //输入学员成绩（整数）范围90~100优秀，75~90良好，60~75及格，不到60不及格
            if (int.TryParse(Console.ReadLine(), out int score))
            {
                switch (score)
                {
                    case int i when i >= 90 && i <= 100:  //这种带逻辑判断的一般更建议使用if语句
                        Console.WriteLine("");
                        break;
                    case int i when i >= 75 && i < 90:
                        Console.WriteLine("");
                        break;
                    case int i when i >= 60 && i < 75:
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }
            //枚举
            Gender gd = new Gender();
            switch (gd)
            {
                case Gender.Male:
                    Console.WriteLine("");
                    break;
                case Gender.Female:
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
            #endregion
            //TMD！C#7.3也用不了
            #region switch表达式
            //string DescribeGender(Gender gender) => gender switch
            //{
            //    Gender.Male => "",
            //    Gender.Female => "",
            //    Gender.Other => ""
            //};
            #endregion

            #region while循环、do..while循环语句
            int num = 0;
            while (num < 5)
            {
                Console.WriteLine($"循环{num + 1}次");
            }
            //do...while，保证代码块起码执行一次
            do
            {
                Console.WriteLine($"循环{num - 5}次");
            } while (num < 10);
            //在while中用Break实现要求用户一直输入用户名和密码。
            //只要不是admin，88888就一直要求重新输入，如果正确则提示登录成功
            do
            {
                string userName = Console.ReadLine();
                string passWord = Console.ReadLine();
                if (userName.Equals("admin") && passWord.Equals("88888"))
                {
                    Console.WriteLine("登录成功");
                    break;
                }
                else
                    Console.WriteLine("用户信息输入不正确请重新输入");
            } while (true);
            //不断要求用户输入一个数字，当输入END时，显示刚才输入的最大值
            double maxNum = double.NaN;
            while (true)
            {
                Console.WriteLine("请继续输入数字，退出请输入END");
                string input = Console.ReadLine();
                if (input.Equals("END"))
                {   
                    if(double.IsNaN(maxNum))
                    {
                        Console.WriteLine("您还没输入任何值，起码输入一个数字");
                        continue;
                    }
                    Console.WriteLine($"您输入的最大值为：{maxNum}");
                    break;
                }
                else if (double.TryParse(input, out double result))
                {
                    if (maxNum.Equals(double.NaN) || result > maxNum)
                        maxNum = result;
                }
                else
                {
                    Console.WriteLine("请输入正确的格式");
                }
            }
            #endregion

            #region 程序跳转关键字 break、continue、return、goto
            //break跳出“当前”循环，如果存在多层嵌套循环，则跳到上一层循环
            //continue结束单次循环，循环没结束只是本次跳过，进入下一次循环
            //return不管嵌套在哪里，都会跳出当前定义的方法体。
            //goto跳转到指定标签的位置
            int n1 = 0;
        post1:
            n1++;
            Console.WriteLine(n1);
            while (true)
            {
                n1++;
                if (n1 == 5)
                {
                    goto post1;
                }
                if (n1 == 8)
                {
                    goto post2;
                }
            }
        post2:
            n1++;
            Console.WriteLine(n1);
            #endregion
        }
    }
}

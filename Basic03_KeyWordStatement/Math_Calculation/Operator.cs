using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Basic01;

namespace Basic03_KeyWordStatement
{
    /// <summary>
    /// 运算符
    /// </summary>
    internal class Operator
    {
        public Operator()
        {
            //运算符 + - * / %  ++ -- += -= *= /=  %=   &   &&   |   ||   ~   ^
            //“/”求除数、“%”求余数、&&和||具有短路特性，&和|不会短路两边都要执行
            #region 运算符
            int r = 6 % 4;//2
            int i1 = 3, i2 = 7;
            double r2 = i2 / (double)i1;
            //“^”异或运算，两者不同才算真。也就是一true一false为true。有0有1为1
            int i3 = 0xA4, i4 = 0xC5;
            int r3 = i3 ^ i4;
            //加密
            bool b1 = long.TryParse(Console.ReadLine(), out long input);
            long key = 47127317247;    //密匙，只有自己知道
            long userData = input ^ key;//加密
            Console.WriteLine($"加密结果：{userData}");
            long resUserData = userData ^ key;//再次异或就能还原
            Console.WriteLine($"已还原{userData}");
            #endregion
            #region  进制运算
            //进制运算：&按位与（逻辑与AND），|按位或（逻辑或OR），^按位异或，~按位取反，<<左移，>>右移

            int x = 5; //二进制表示为0000 0101
            int y = 3; //二进制表示为0000 0011
            int and = x & y; //按位与，结果为0000 0001，即1。都为1，结果才为1
            int or = x | y; //按位或，结果为0000 0111，即7。只要有一个为1，结果就为1
            int xor = x ^ y; //按位异或，结果为0000 0110，即6。有且仅有一个是1，一个为0，结果就为1
            int not = ~x; //按位取反，结果为1111 1010，即-6
            int leftShift = x << 1; //左移一位，结果为0000 1010，即10
            int rightShift = x >> 1; //右移一位，结果为0000 0010，即2

            #endregion

            #region 逻辑运算
            //逻辑运算：&&逻辑与，||逻辑或，!逻辑非
            //关系运算符：== 等于，!= 不等于，> 大于，< 小于，>= 大于等于，<= 小于等于。结果为bool类型
            //逻辑运算符的优先级高于关系运算符
            //逻辑运算符的短路特性：&&和||都是短路运算符，&&左边的表达式为false时，右边的表达式不会被计算
            //||左边的表达式为true时，右边的表达式不会被计算
            //异或运算符^没有短路特性，左右两边的表达式都会被计算
            Console.WriteLine(true ^ true);    // output: False
            Console.WriteLine(true ^ false);   // output: True
            Console.WriteLine(false ^ true);   // output: True
            Console.WriteLine(false ^ false);  // output: False
            //三元运算符：条件运算符 ? :，根据条件表达式的结果选择执行的表达式。
            bool condition = new Random().NextDouble() > 0.5;
            int cond = condition ? 12 : 0; //condition为true，x为12，否则为0
            //条件运算符可以嵌套使用 a? b : (c? d : e) 但可读性较差，建议使用if-else语句代替。
            #endregion

            #region 位运算 >>、<<、&、^在上位机中的使用
            //上位机开发中常用场景：根据位运算进行信号判定或者权限判定
            //eg1：使用位移运算符<<生成掩码并按位与&来判定指定位元是 0还是1
            int num = 13;// 1101
            int n = 2;//指定位元为2
            //把数字 1 向左移动n位，等价于2的n次方，但性能极快
            int mask = 1 << n;//4 二进制从0001变成0100，2的0次方变成2的2次方
            if ((num & mask) != 0)
            {
                /*13和4的按位与运算
                 *      1101
                 *      0100
                 * 求出来0100，非0所以成立
                 */
                Console.WriteLine($"第{n}位该位是1");
            }

            //上位机最常见的操作，解析 PLC 的“报警字/状态字” (读取)
            ushort statusWord = 18; // 从设备读到的值，二进制0000 0000 0001 0010
            // 判断第 1 位（电机过载）
            if ((statusWord & (1 << 1)) != 0)
            {
                Console.WriteLine("警告：电机过载！");
            }
            // 判断第 4 位（温度过高）
            if ((statusWord & (1 << 4)) != 0)
            {
                Console.WriteLine("警告：温度过高！");
            }
            //往设备写入“控制字”，假设设备启动是第0位，冷却是第3位
            //|= (按位或赋值)：把某位置为 1，不影响其他位。
            //&= ~ (按位与赋值)：把某位置为 0，不影响其他位。
            //^= (按位异或赋值)：把某位翻转（0变1，1变0）。
            ushort controlword = 0;
            //启动设备（把第0位置为 1）
            controlword |= (1 << 0);// 此时 controlWord 是 1
            Console.WriteLine(controlword);
            //开启冷切（把第三位置为1）
            controlword |= (1 << 3);// 此时 controlWord 是 9 (0000 1001)
            Console.WriteLine(controlword);
            //停止冷却（把第三位置为0）
            int tempmask = ~(1 << 3);//掩码取反 可以用常量0xFFF7代替，按位与 (1111 0111)
            controlword &= (ushort)tempmask;// 此时 controlWord 又变回了 1
            Console.WriteLine(controlword);

            #endregion

            #region Math计算工具
            Console.WriteLine(Math.PI);
            Console.WriteLine(Math.Abs(-6));//求绝对值
            Console.WriteLine(Math.Ceiling(34.12));//向上取整，注意函数返回值不是int
            Console.WriteLine(Math.Floor(23.1));//向下取证，同样函数返回不是int
            //角度——弧度
            double d1 = 30 * (Math.PI / 180);//30°对应的弧度值
            Console.WriteLine(Math.Sin(d1));
            //Math.Pow方法可以用来判断某个数据的指定位元是 0还是1
            Console.WriteLine(Math.Pow(12.3, 3));//数字的指定次幂。12.3的三次幂

            //指定保留小数点几位
            Console.WriteLine(Math.Round(45.23421));//会四舍五入
            //开根号
            Console.WriteLine(Math.Sqrt(4));//2
            //计算双精度浮点数的整数部分
            Console.WriteLine(Math.Truncate(45.32));//45
            #endregion


            #region var推断类型
            //编译器会自行推断
            var v1 = 3.56;
            var v2 = "hello";
            var v3 = true;
            var v4 = new Student();
            #endregion
        }

    }
}

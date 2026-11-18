using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Work1113
{
    internal class Class1
    {
        public Class1()
        {
            //1、创建一个int型变量并赋值，打印出这个值16进制和2进制字符串
            int A = 666;
            Console.WriteLine($"十六进制转换：0x{A.ToString("X4")}");//029A。转换成16进制，并补齐4位
            string strA = Convert.ToString(A, 2).PadLeft(16, '0');//从左侧补位到16位，用字符0补齐
            Console.WriteLine($"二进制转换：0b{strA}");
            //Console.WriteLine(A.ToString("B"));  C#8+版本后才支持

            #region 2、介绍float型、double型、decimal型的共同点和区别？
            /*共同点：
             * 都是浮点型。值类型。底层是struct结构体
             * 都自带Parse/TryParse方法将字符串转换成自身的类型，支持格式化输出（:F2、:N2）等
             * 整数类型可以隐式转换为浮点类型，不会丢失数据
             * 
             * 区别：
             * float和double都存在误差，多次循环累加可能会存在0.1+0.2 != 0.3的情况
             * 浮点数如果不带后缀默认为double类型，加f/F为float类型，加m/M为decimal类型
             * decimal类型专为十进制设计（无二进制误差），当然运算速度慢于float和double
             * 也就是说decimal类型可以使用 == 作为相等判断，其它两个不行
             */
            decimal money = 10240;
            Console.WriteLine($"{money:C}");//￥10,240.00 货币格式
            double dd = 1234.745656;
            Console.WriteLine($"{dd:F2}");//保留两位小数点，位数不足自动补0
            Console.WriteLine($"{dd:N2}");//同上，同时会添加千分位逗号
            //工控优先使用double，精度和运行速度都有，对性能有要求不适用decimal
            bool isEqual = Math.Abs(123.54354535 - 12.343523523) < 1e-6;//误差小于0.000001
            Console.WriteLine($"{1e-6:F6}");//0.000001
            #endregion

            #region 3、举例说明隐式转换和显示转换
            //数值类型，低精度向高精度、整数型向浮点型 转换是隐式转换，不会丢失精度
            //引用类型，派生类向基类转换是隐式转换。子类继承自父类
            //引用类型实例分配给类型实现的接口
            //引用类型实例分配给Object类。毕竟是所有类的基准类
            //显示转换反过来，可能会丢失精度
            #endregion

            #region 4、string str1="223";string str2="45.638"; 分别使用三种方法，将str1转化为Int；将str2转成double型
            string str1 = "123";
            string str2 = "45.638";
            int.TryParse(str1, out int r);//最推荐，不会报异常影响给程序运行，可根据方法返回bool值来处理
            Console.WriteLine(r);
            Console.WriteLine(Convert.ToInt32(str1));//无法保证输入内容情况下不建议使用Parse和Convert

            double.TryParse(str2, out double d);
            Console.WriteLine(d);

            #endregion
        }

    }
}

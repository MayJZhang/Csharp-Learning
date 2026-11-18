using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic02
{
    internal class DataConversion
    {
        public DataConversion()
        {
            //隐式转换和显式转换
            #region 隐式转换
            //隐式转换：从小范围类型转换为大范围类型，编译器会自动进行转换，不需要显式指定。
            //隐式转换不会丢失数据，也不会抛出异常。
            int a = 10;
            long b = a; //int隐式转换为long
            float c = a; //int隐式转换为float
            double d = a; //int隐式转换为double
            decimal e = a; //int隐式转换为decimal
            #endregion
            #region 显式转换
            //显式转换：从大范围类型转换为小范围类型，编译器不会自动进行转换，需要显式指定。
            //显式转换可能会丢失数据，也可能会抛出异常。
            long f = 10;
            int g = (int)f; //long显式转换为int
            float h = (float)f; //long显式转换为float
            double i = (double)f; //long显式转换为double
            decimal j = (decimal)f; //long显式转换为decimal
            double k = 3.14;
            int l = (int)k; //double显式转换为int，丢失小数部分，结果为3
            #endregion


            //类型转换方法
            #region 数据转换方法
            //数据转换方法：Convert.ToXXX()，将数据转换为指定类型，可能会抛出异常。
            int m = Convert.ToInt32("123"); //将字符串转换为int
            double n = Convert.ToDouble("3.14"); //将字符串转换为double
            string r1 = Convert.ToString(12314, 2);//ToString()可以转2进制或16进制
            string r2 = Convert.ToString(255, 16);//0xff
            //数据转换方法：Parse()，将字符串转换为数值，可能会抛出异常。
            int o = int.Parse("123"); //将字符串转换为int
            //数据转换方法：int.TryParse()，将字符串转换为int，返回bool类型，表示转换是否成功。
            //double、decimal等数值类型都有，Parse()和TryParse()方法，只能用于字符串转换为数值类型，不能用于其他类型的转换。
            //TryParse()方法运行起来更安全，不会抛出异常，如果转换失败，会返回false，并将输出参数设置为默认值。
            int p;
            bool success = int.TryParse("123", out p); //将字符串转换为int，返回bool类型，表示转换是否成功。


            //数据转换方法：ToString()，将数据转换为字符串。
            int value = -16325;
            Console.WriteLine(value.ToString());            // Displays -16325
            Console.WriteLine(value.ToString("G"));         // Displays -16325
            Console.WriteLine(value.ToString("C"));         // Displays ($16,325.00)
            Console.WriteLine(value.ToString("D"));         // Displays -16325
            Console.WriteLine(value.ToString("F"));         // Displays -16325.00
            Console.WriteLine(value.ToString("N"));         // Displays -16,325.00
            Console.WriteLine(value.ToString("X"));         // Displays FFFFC03B

            #endregion

            #region 装箱和拆箱
            //装箱是将值类型转换成引用类型
            //拆箱是将引用类型转换成值类型；前提是他们之间要有继承关系
            //这两种会浪费系统资源，尽量避免
            //抽象描述：值类型在内存栈里，给包装到内存堆里，再把堆地址放给内存栈。这就是装箱
            
            #endregion
                        
        }
        
    }
}

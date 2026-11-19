using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic02
{
    //C#中有两种类型：值类型和引用类型
    internal class BasicTypes
    {
        public BasicTypes()
        {
            #region 值类型
            //值类型：存储在栈中，直接存储数据本身，赋值时会复制数据
            //也就是说，值类型的变量之间是独立的，修改其中一个变量的值不会影响到其他变量
            int a = 10; //值类型，默认0
            int aa = a;
            a = 5; //修改a的值不会影响aa的值

            float b = 10.0f; //值类型，默认0
            double c = 10.0; //值类型，默认0
            decimal d = 10.0m; //值类型，默认0
            bool e = true; //值类型，默认值false
            char f = 'A'; //值类型，默认值'\0'
            #endregion

            #region 引用类型
            //引用类型：存储在堆中，存储的是数据的引用，赋值时会复制引用
            //也就是说，引用类型的变量指向的是同一个对象，修改其中一个变量的值会影响到其他变量
            //任何类、接口、数组、委托都是引用类型
            //任何引用类型的变量都可以赋值为null，表示该变量不引用任何对象，这也是默认值
            string g = "Hello"; //引用类型
            object h = new object(); //引用类型
            Action<int> i = obj => { }; //引用类型
            #endregion

            #region  整数类型进制转换
            byte bt = 255; //byte类型，默认值0,范围0~255。8位无符号整数
            byte bt1 = 0b11111111; //二进制表示，等同于255。二进制数以0b开头，后面跟着0和1。
            byte bt_1 = 0b_1111_1111; //下划线可以用来分隔数字，提高可读性。
            byte bt2 = 0xFF; //十六进制表示，等同于255。十六进制数以0x开头，后面跟着数字和字母A~F，表示10~15。

            sbyte sbt = -128; //sbyte类型，默认值0，范围-128~127。8位有符号整数
            short s = -32768; //short类型，默认值0，范围-32768~32767。16位有符号整数
            ushort us = 65535; //ushort类型，默认值0，范围0~65535。16位无符号整数
            int i1 = -2147483648; //int类型，默认值0，范围-2147483648~2147483647。32位有符号整数
            int i2 = 0x7FFF_FFFF; //十六进制表示，等同于2147483647。可以使用下划线分隔数字，提高可读性。
            uint ui = 4294967295; //uint类型，默认值0，范围0~4294967295。32位无符号整数
            uint ui1 = 0xFF_FF_FF_FF; //十六进制表示，等同于4294967295。可以使用下划线分隔数字，提高可读性。
            #endregion

            #region 浮点数类型
            //浮点数类型：float、double、decimal。默认值0.0
            float f1 = 3.14f; //float类型，默认值0.0，范围-3.402823e38~3.402823e38。32位单精度浮点数
            double d1 = 3.14; //double类型，默认值0.0，范围-1.7976931348623157e308~1.7976931348623157e308。64位双精度浮点数
            decimal dc = 3.14m; //decimal类型，默认值0.0，范围-79,228,162,514,264,337,593,543,950,335~79,228,162,514,264,337,593,543,950,335。128位高精度浮点数
            //浮点数类型的字面量后缀：f或F表示float，d或D表示double，m或M表示decimal。没有后缀表示double。
            double db = 3D;
            db = 4d;
            db = 3.934_001;
            double db1 = 3.934_001e-2; //科学计数法表示，等同于0.03934001。e或E表示10的幂次方，后面跟着整数。
            double db2 = 3.934_001E+2; //科学计数法表示，等同于393.4001。e或E表示10的幂次方，后面跟着整数。
            //float类型的字面量后缀：f或F表示float。没有后缀表示double。
            //float类型的范围比double和decimal小，但占用内存更少，适合用于图形计算。
            float fl = 3_000.5F;
            fl = 5.4f;
            float fl1 = 3.934_001e-2f; //科学计数法表示，等同于0.03934001。e或E表示10的幂次方，后面跟着整数。
            //decimal类型的字面量后缀：m或M表示decimal。没有后缀表示double。
            //decimal类型的范围比float和double小，但精度更高，适合用于财务计算。
            //decimal类型的字面量可以使用下划线分隔数字，提高可读性，一般3位一组。
            //decimal类型的字面量可以使用科学计数法表示，例如1.23e4表示12300，1.23E-4表示0.000123。
            //decimal类型的字面量可以使用负号表示负数，例如-3.14m表示-3.14。
            decimal myMoney = 3_000.5m;
            myMoney = 400.75M;
            decimal myMoney2 = 1.234E6M; //科学计数法表示，等同于1234000。e或E表示10的幂次方，后面跟着整数。
            #endregion

            
            //默认值关键字default(T)可以获取类型T的默认值
            int defaultInt = default;          // 0
            bool defaultBool = default;        // false
            string defaultString = default;   // null
            

            //目标类型表达式 new，如果已经从上下文中推断出类型，则可以省略类型名称。
            //C#7.3中用不了，TMD！！！
            //var list = new List<int>(); // 类型推断为 List<int>
            /*
             * List<int> list = new();  类型推断为 List<int>
             * Dictionary<string, int> dict = new();  类型推断为 Dictionary<string, int>
            */

            //dynamic类型：动态类型，编译时不进行类型检查，运行时才进行类型检查
            //与 COM API、动态语言或反射密集场景交互时使用 dynamic 
            //避免
            dynamic value = 42;
            Console.WriteLine(value.GetType()); // System.Int32
            value = "Now I'm a string";
            Console.WriteLine(value.GetType()); // System.String


            //字符类型
            #region 字符类型（char）
            //字符串是由多个字符组成的
            //字符使用单引号 ''
            char ch1 = 'a';
            char ch2 = ' '; //不能什么都没有，可以是空格，只能是一个空格
            char ch3 = char.ToUpper(ch1);   //A 转大写
            bool rs = char.IsDigit(ch1);    //判断字符是否是十进制数字

            //字符和int之间存在等效关系，本质上字符是保存成Unicod码
            char ch4 = 'C';
            int i4 = ch4;   //隐式转换
            Console.WriteLine(i4);  //67
            Console.WriteLine($"C的十六进制Unicode码：0x{i4.ToString("X4")}"); //0x0043
            int i5 = 0x32;
            char ch5 = ((char)i5);  //int的数值可能超出编码范围，所以要显示转换
            Console.WriteLine(ch5); //2
            #endregion

        }

    }
}

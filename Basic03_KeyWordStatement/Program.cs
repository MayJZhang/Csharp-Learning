using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic03_KeyWordStatement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new KeyWords();
            #region Main方法中的参数args
            //获取到的是字符串类型
            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.WriteLine(args[2]);
            Console.WriteLine(args[3]);
            //Console.WriteLine(args[4]); //不存在时会报异常System.IndexOutOfRangeException索引超出范围
            #endregion

            new Operator();
        }
    }
}

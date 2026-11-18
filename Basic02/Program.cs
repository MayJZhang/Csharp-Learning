using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type_Struct ts = new Type_Struct() { A = 20, B = "1111"};
            ST sT = new ST { A = 15, B ="2222"};

            Type_Struct ts2 = ts;
            ts2.A = 16;
            Console.WriteLine(ts.A);//16
            Console.WriteLine(ts2.A);//16
            ST sT1 = sT;
            sT1.B = "333333";
            Console.WriteLine(sT.B);//2222
            Console.WriteLine(sT1.B);//333333

            new BasicTypes();
        }
    }
}

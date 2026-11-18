using System;

namespace Basic03_KeyWordStatement.Math_Calculation
{
    /// <summary>
    /// 科学计算
    /// </summary>
    internal class Scientific_Computing
    {
        public Scientific_Computing()
        {
            //常规方法
            double targetNum = 200000;
            double currentNum = 80000;
            int startYear = 2026;
            int targetYear = startYear + 0;
            while (currentNum < targetNum)
            {
                currentNum *= 1.25;
                targetYear++;
            }
            Console.WriteLine($"{targetYear}年将会超过{targetNum}人");

            //Math类的使用，log对数知识 例如已2为底8的对数为3。log₂(8)=3, 2³=8
            //所以200000/80000=2.5，以1.25为底2.5的对数向上取值就可以得到需要几年
            currentNum = 80000;
            int years = ((int)Math.Ceiling(
                Math.Log(targetNum / currentNum) / Math.Log(1.25))
                );//也可以写Math.Log(2.5, 1.25)，目前写法等价为 ln(2.5)/ln(1.25)
            Console.WriteLine($"到{startYear + years}年将会超过{targetNum}人");
        }
        /*
         * 求一元二次方程：ax²+bx+c=0的实根分析：
         *  △=b²-4ac，当△>0时，方程有两个不等实根;当△=0，方程有一个实根；当△<0，方程无解
         */
        public void calSqrt()
        {
            Console.WriteLine("请按此输入a、b、c：");
            double.TryParse(Console.ReadLine(), out double a);
            double.TryParse(Console.ReadLine(), out double b);
            double.TryParse(Console.ReadLine(), out double c);
            double x1, x2, eps = 1e-12;// eps浮点比较的容差
            double delta = b * b - (4 * a * c);// Δ
            //双精度运算存在误差，平方、乘法、相减每次都会累加误差
            //所以delta 的结果存在误差，需要进行误差比较
            double scale = b * b + Math.Abs(4 * a * c);//b²和4ac的误差相加
            //如果scale非常小，会导致误差参考值非常低失效，用1.0兜底
            double tol = eps * Math.Max(1.0, scale);
            if (Math.Abs(a) <= eps)// 如果a为0，不是一元二次方程
            {
                Console.WriteLine("a为0，一元二次方程不成立");
            }
            else if (delta > tol)// Δ>0
            {
                //加法可以避免双精度值做减法是的灾难性抵消。降低精度误差
                //稳定值写法，选择b和Δ相加的求根方程来算
                double sqrt = Math.Sqrt(delta);
                //当b大于0时，-0.5b为负数、-sqrt也为负数。同号相加
                //当b小于0时，-0.5b为正数、-sqrt变为+sqrt。同号相加，都在做加法
                double q = b >= 0 ? -0.5 * (b + sqrt) : -0.5 * (b - sqrt);
                x1 = q / a;//   
                x2 = c / q;//   使用韦达定理 x1*x2 = c/a，得到另一个根。避开相减可能造成的灾难性抵消
                Console.WriteLine($"两个根为：{x1}和{x2}");
            }
            else if (delta >= -tol)// Δ=0
            {
                Console.WriteLine($"只有一个根为：{-(b / (2 * a))}");
            }
            else
            {
                Console.WriteLine("△小于零，无实根");
            }

        }
        /*
         * 百钱百鸡问题，每只公鸡值5元，每只母鸡值3元，3只小鸡值1元，用100元买100只鸡。
         * 问公鸡、母鸡、小鸡各多少只？
         */
        public void chicken()
        {
            for (int g = 0; g <= 20; g++)//  公鸡
            {
                for (int m = 0; m <= 33; m++)// 母鸡
                {
                    int x = 100 - g - m;//  小鸡的数量
                    //小鸡数量能被3整除，且价格相加等于100
                    if (x % 3 == 0 || 5 * g + 3 * m + x / 3 == 100)
                    {
                        Console.WriteLine($"公鸡{g}只，母鸡{m}只，小鸡{x}只");
                    }
                }
            }

        }
    }
}

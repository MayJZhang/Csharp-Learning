using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic05_Custom_DLL
{
    //  类库程序，本质是一个单独的程序集
    //  没有Main入口点，不能像exe一样直接启动，是给别的项目调用
    public class My_Calculator
    {
        /// <summary>
        /// 求和运算
        /// </summary>
        /// <typeparam name="T">泛型占位符</typeparam>
        /// <param name="values">输入的一个或多个值</param>
        /// <returns>返回所有参数的和</returns>
        public static T GetSum<T>(params T[] values)
        {
            try
            {
                dynamic sum = default(T);
                foreach (var item in values)
                {
                    sum += item;
                }
                return sum;
            }
            catch (Exception)
            {
                return default;
                //throw;
            }
            
        }
    }
}

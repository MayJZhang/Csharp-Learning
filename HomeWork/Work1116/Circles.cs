using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Work1116
{
    /*
     * 创建一个 圆 类

        包含：常量字段Pi=3.141592; 

        包含：半径（属性，double型） 通过构造函数赋值半径

        包含：求面积方法  和  求周长的方法

         在Main函数中调用并测试
     */
    internal class Circles
    {
        /// <summary>
        /// 通过构造函数求圆的周长和面积
        /// </summary>
        /// <param name="r">半径</param>
        /// <param name="area">面积</param>
        /// <param name="perimeter">周长</param>
        public Circles(double r, out double area, out double perimeter)
        {
            area = r * r * Math.PI;
            perimeter = 2 * r * Math.PI;
        }
    }
}

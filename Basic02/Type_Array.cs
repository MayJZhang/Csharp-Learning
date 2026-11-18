using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic01;

namespace Basic02
{
    internal class Type_Array
    {
        public Type_Array()
        {
            #region 一维数组
            //固定数量的元素的集合，创建的时就必须确定长度。后面不能Add和Remove。
            //数组是引用类型
            int[] ints = new int[4];
            ints[1] = 10;
            //ints[4] = 20; //索引越界，抛异常
            Console.WriteLine(ints.Length);//长度属性

            Student[] students = new Student[]
            {
                new Student(){Name = "Harry", Age = 18},
                new Student(){Name = "Malfy", Age = 18}
            };
            foreach (var student in students)//迭代语句
            {
                student.Study();
                student.Age = 17;
                //student = new Student(); foreach中的自定义item为迭代变量，无法为其赋值，只能拿来使用
            }   //如果想修改元素的值，可以使用for循环通过循环下标索引来处理
            #endregion


            #region 排序
            //冒泡排序for循环
            //但是可以用更好的。数组内置方法
            Array.Sort(ints);
            Array.Reverse(ints);//反转
            #endregion
        }
    }
}

using Basic01;
using System;

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

            #region 二维数组
            int[] intArr1 = new int[] { 1, 2, 3, 4 };
            int[,] intArr2 = new int[2, 3];// 创建一个2行3列的二维数组
            Console.WriteLine(intArr2.Length);//元素个数 6

            intArr2[0, 0] = 10;
            intArr2[0, 1] = 11;
            intArr2[0, 2] = 12;

            intArr2[1, 0] = 20;
            intArr2[1, 1] = 21;
            intArr2[1, 2] = 22;
            Console.WriteLine(intArr2.GetLength(0));//2 第一维度 2行
            Console.WriteLine(intArr2.GetLength(1));//3 第二维度 3列
            Console.WriteLine("**********");

            //遍历
            foreach (var item in intArr2)// foreach不需要索引，直接遍历每个元素。for循环需要两层循环
            {
                Console.WriteLine(item);
            }
            //三维数组（非重点）
            int[,,] intArr3 = new int[2, 3, 2]
            {// 第一维，有两个元素
                {//第二维，有三个元素
                    {1,2 },//第三维，有两个元素
                    {3,4 },
                    {5,6 }
                },
                {
                    {7,8 },
                    {9,10 },
                    {11,12 }
                }
            };

            #endregion
            #region 交错数组
            int[][] arr1 = new int[2][];
            arr1[0] = new int[2] { 10, 20 };
            arr1[1] = new int[3] { 100, 200, 300 };

            int[][,] arr2 = new int[2][,];
            arr2[0] = new int[2, 3]
            {
                {10,20,30 },
                {40,50,60 }
            };
            arr2[1] = new int[2, 2]
            {
                {100,200 },
                {300,400 }
            };
            Console.WriteLine(arr2[1][1,0]);// 300
            #endregion

        }
    }
}

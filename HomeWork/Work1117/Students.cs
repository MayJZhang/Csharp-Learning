using System;
using System.Collections.Generic;

namespace HomeWork.Work1117
{
    //编写程序，
    //输入学生人数，然后依次输入每个输入学生姓名、
    //学生数学、语文、英语成绩，
    //打印总分最高的学生姓名，总分，平均分，以及他的英语成绩！
    //（类的封装，面向对象OOP思维）

    internal class Students
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        private string _stuName;
        public string StuName
        {
            get => _stuName;
            set => _stuName = value;
        }
        /// <summary>
        /// 数学成绩
        /// </summary>
        private double _mathScore;
        public double MathScore
        {
            get => _mathScore;
            set => _mathScore = value;
        }
        /// <summary>
        /// 语文成绩
        /// </summary>
        private double _chiScore;
        public double ChiScore
        {
            get => _chiScore;
            set => _chiScore = value;
        }
        /// <summary>
        /// 英语成绩
        /// </summary>
        private double _engScore;
        public double EngScore
        {
            get => _engScore;
            set => _engScore = value;
        }
        /// <summary>
        /// 总分
        /// </summary>
        public double SumScore { get => MathScore + ChiScore + EngScore; }
        /// <summary>
        /// 平均分
        /// </summary>
        public double AvgScore { get => Math.Round(SumScore / 3, 2); }


        public Students HighestScore(List<Students> students)
        {
            Students highester = null;
            if (students.Count > 0)
            {
                foreach (var item in students)
                {
                    if (highester == null || item.SumScore > highester.SumScore)
                        highester = item;
                }
            }
            //students.Aggregate((max, item) => item.SumScore > max.SumScore ? item : max);
            return highester;
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

using System;

namespace HomeWork.ClassWork
{
    /*封装一个Car类，要求有长，宽，名牌属性，长必须在3到6米，宽度必须在1.5到2米，超出范围则抛异常，
    这些属性可以通过有参构造函数传入，同时要求有 前进、后退、停止这三个实例方法。写完后在Main方法中测试 。*/    
    internal class Car
    {
        ///<summary>
        ///车辆宽度
        ///</summary>
        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                if (value < 1500 || value > 2000)
                    throw new Exception("车辆宽度限制为1.5米到2米，您输入的数据不合规");
                _width = value;
            }
        }

        ///<summary>
        ///车辆高度
        ///</summary>
        private int _length;
        public int Length
        {
            get => _length;
            set
            {
                if (value < 3000 || value > 6000)
                    throw new Exception("车辆高度限制为3米到6米，您输入的数据不合规");
                _length = value;
            }
        }

        ///<summary>
        ///铭牌
        ///</summary>
        public string Nameplate { get; set; }

        public Car()
        {
            Width = 1500;
            Length = 3000;
            Nameplate = "默认铭牌";
        }

        ///<summary>
        ///构造函数
        ///</summary>
        /// <param name="width">车辆宽度</param>
        /// <param name="height">车辆高度</param>
        /// <param name="nameplate">铭牌</param>
        public Car(int width, int height, string nameplate)
        {
            Width = width;
            Length = height;
            Nameplate = nameplate;
        }

        ///<summary>
        ///车辆向前行驶
        ///</summary>
        public void Forword()
        {
            Console.WriteLine($"{Nameplate}车辆向前行驶");
        }
        ///<summary>
        ///车辆向后行驶
        ///</summary>
        public void Back()
        {
            Console.WriteLine($"{Nameplate}车辆向后行驶");
        }
        ///<summary>车辆停止行驶</summary>
        public void Stop()
        {
            Console.WriteLine($"{Nameplate}车辆停止行驶");
        }
    }
}

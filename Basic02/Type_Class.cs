using Basic02.Entity;
using System;
using System.Collections.Generic;

namespace Basic02
{
    //类的三大特性：封装、继承、多态
    internal class Type_Class
    {
        public Type_Class()
        {
            //学生是个封装好的类
            Student student = new Student();

            #region 类的多态
            //核心要点：里氏转换，子类对象必须能够替换父类对象，而程序的行为不发生意外变化。
            //子类的对象可以赋给父类的引用；
            Human human = new Student();//  Human的引用指向了Student的对象
            human.useTool();//  使用的方法是Student的方法
            //human.study();    因为引用是Human类所以用不了Student独有的方法
            ((Student)human).study("haoran");// 可以显示转换为Student
            //((Driver)human).drive(); //编译没错因为Driver是Human子类，但是实际对象是Student和Driver平级。运行时会抛异常
            List<Mammals> mammals = new List<Mammals>()
            {   // 多态的直观体现
                new Mammals(),
                new Human(),
                new Student(),
                new Driver()
            };
            //关键字 is  as ？
            // is：判断对象是否能转换成某个类型，能就返回true
            // as：判断对象能否转换为某个类型，能转就转换，不能就返回null
            // ?：非空检测，判断 ?前面的对象是否为null，为空就不执行后面的代码防止报错



            #endregion
        }

    }
}

namespace Basic02.Entity
{
    //类的继承
    public class Mammals    // 哺乳动物，基类
    {
        public int Age { get; set; }
        public void Breathing()
        {
            Console.WriteLine("呼吸氧气");
        }
    }
    public class Human : Mammals    //人类是哺乳动物，派生类
    {
        public string Name { get; set; }
        public void useTool()
        {
            /*使用工具*/
        }
        private string Country { get; set; }    // 只能当前类的内部能都访问
        protected string Gender { get; set; }   // 只能在当前类和对应的派生类里面访问
    }

    public class Student : Human    //学生是人类在某一阶段的身份，继承Human也间接继承了Mammals
    {
        public double score { get; set; }
        public void study(string name)
        {
            Name = name;
            //Country = ""; 私有变量继承了但是无法访问
            Gender = "Male";    //子类里面可以访问
            Console.WriteLine($"{Name}正在学习");
        }
    }
    public class Driver : Human    //司机是人类的一个职业身份，继承Human也间接继承了Mammals
    {
        public int driveYear { get; set; }
        public void drive()
        {
            Console.WriteLine("驾驶中");
        }
    }
}
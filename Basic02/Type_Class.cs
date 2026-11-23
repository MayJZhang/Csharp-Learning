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
            human.UseTool();//  使用的方法是Student的方法
            //human.study();    因为引用是Human类所以用不了Student独有的方法
            ((Student)human).Study("haoran");// 可以显示转换为Student
            //((Driver)human).drive(); //编译没错因为Driver是Human子类，但是实际对象是Student和Driver平级。运行时会抛异常
            List<Mammals> mammals = new List<Mammals>()
            {   // 多态的直观体现
                //new Mammals(),    抽象类无法创建实例
                new Human(),
                new Student(),
                new Driver()
            };
            //  类型匹配，在调用方做集中分支，新增类型时需要增加类型分支匹配。模式匹配让“按运行时类型分支”写得更清晰
            //  这和多态不一样，多态是行为分散到各子类，增加类型时调用方不用更改
            //关键字 is  as ？
            // is：类型测试运算符。判断对象是否能转换成某个类型，能就返回true
            //  如果能转换，搭配声明模式可以将转换后的结果分配给声明的变量
            //  eg：
            //      if(hunman is Student student)   student就是声明的变量

            // as：显示转换运算符，将对象转换为某个类型，能转就转换，不能就返回null
            //  e as T  e是一个值，T是类型
            // ?.：空条件检测运算符，判断 ?前面的对象是否为null，为空就不访问后面的代码防止报错



            #endregion
        }

    }
}

namespace Basic02.Entity
{
    //类的继承
    public abstract class Mammals    // 哺乳动物，基类，可以通过abstract修饰为抽象类，抽象类无法实例化
    {
        public int Age { get; set; }
        public virtual string Species => "哺乳动物"; //只读属性表达式写法  属性本质上是访问方法，也可以被重写
        public abstract void Breathing(); // 抽象方法，子类必须重写，要写抽象方法 类也得是抽象类
        /*{
            Console.WriteLine("呼吸氧气");  抽象方法是没有方法体的
        }*/
}
    public class Human : Mammals    //人类是哺乳动物，派生类
    {
        public override string Species => "人类";    //   重写属性
        public string Name { get; set; }
        public override void Breathing()
        {
            Console.WriteLine("用肺呼吸");
            //throw new NotImplementedException();  防呆代码方法体没写运行抛异常
        }
        public virtual void UseTool()   // virtual 虚方法，允许派生类重写，不写就按照基类的来
        {
            /*使用工具*/
        }
        private string Country { get; set; }    // 只能当前类的内部能都访问
        protected string Gender { get; set; }   // 只能在当前类和对应的派生类里面访问
    }

    public class Student : Human    //学生是人类在某一阶段的身份，继承Human也间接继承了Mammals
    {
        public double Score { get; set; }
        public override void UseTool()  // override 重写基类的虚方法，强制声明重写保证了不会写成隐藏
        {
            base.UseTool(); //可以通过base关键字调用基类方法
            Console.WriteLine("使用课本");
        }
        public void Study(string name)
        {
            Name = name;
            //Country = ""; 私有变量继承了但是无法访问
            Gender = "Male";    //子类里面可以访问
            Console.WriteLine($"{Name}正在学习");
        }
    }
    public class Driver : Human    //司机是人类的一个职业身份，继承Human也间接继承了Mammals
    {
        public int DriveYear { get; set; }
        public new void UseTool()
        {
            /*使用 new 在多态使用上隐藏了，变成了新的、和父类无关的成员
             * 如果通过父类的引用来调用Driver实例的UseTool方法，走的是父类的版本。
             * 通过Driver d = new Driver();调用的UseTool是子类版本
             * 同一个对象，对其的引用不同方法也不同
             * 
             * new会破坏多态的一致性，一般都是出现设计问题的时候，比如后期父类加了新成员，但是子类已经有了这个成员
             * 所以尽量避免使用new
             */
        }
        public void Drive()
        {
            Console.WriteLine("驾驶中");
        }
    }
}
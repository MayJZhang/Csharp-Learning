using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic04_Function
{
    // 委托
    /*
     * 平时都是给方法传数据，但是有时候想要把“一个动作/方法”传给另一个方法
     * 比如：
     *      写一个按钮点击逻辑，你要告诉他“被点击后该执行什么代码”
     *      写一个通用排序算法，你要告诉他“怎么比较两个元素”（是比大小还是比长度）
     * C#中用来装方法的“变量”，就是委托
     * 
     * 生活比喻：
     *      数据：你去餐厅点菜，你告诉服务员“我要一份红烧肉”（数据）
     *      委托：你给兄弟打电话“帮我取个快递”（你交代了一个动作/任务，兄弟去执行）
     */
    //委托是一种引用类型，它定义了方法的签名（参数和返回值），只要某个方法的签名符合这个委托，就可以赋值给这个委托
    #region 委托类型，（通常放在类外面或命名空间里）
    //1、定义委托类型：意思是我要找的方法，必须有一个string类型的参数，且返回void
    public delegate void LogHandler(string message);
    #endregion
    internal class Function_Delegate
    {
        //2、准备一个符合这个委托类型的具体方法
        public void PrintToConsole(string msg) => Console.WriteLine($"被委托拿去执行并且输出message：{msg}");
        public void PrintToFile(string msg) => Console.WriteLine("另一个方法");

        public Function_Delegate()
        {
            //3、创建这个委托类型的实例。并把具体的方法交给它
            LogHandler log = PrintToConsole;
            //4、调用这个委托（相当于调用了PrintToConsole）
            log("牛逼");

            //委托允许我们决定在运行时调用哪个方法。随时可以改变委托里的方法
            log = PrintToFile;  // 换一个方法
            log("换一个");

            //除了这种传统赋值的写法，委托还可以赋值匿名方法，搭配lambda表达式更简洁
            LogHandler logHandler =
                msg => Console.WriteLine($"message:{msg}");

            //和自己定义的delegate委托一样使用
            func(1, 3);
            //多播委托（一个动作，多人执行）
            add += msg => Console.WriteLine("第二个执行");
            add += msg => Console.WriteLine("第三个执行");
            add("msg");
            //如果是有返回值的委托，多播执行后只会返回最后一个方法的返回值
            func += (a, b) => a + b;
            int num = func(2, 4);
            Console.WriteLine(num); //  6
        }
        //微软直接内置委托，涵盖常用类型
        // Action 签名里无返回值的方法可用，泛型占位符全都是参数的类型
        public Action<string> add = x => Console.WriteLine("第一个执行" + x);
        // Func 签名里有返回的方法使用，泛型占位符最后一个表示返回值的类型
        public Func<int, int, int> func = (a, b) => a * b;

    }
}

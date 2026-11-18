using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic03_KeyWordStatement
{
    //C#关键字
    internal class KeyWords
    {
        //单次声明时可以声明多个常量，常量声明不允许 static 修饰符，本质上const也是静态的
        public const double X = 1.0, Y = 32.45, C = 2352.4;
        public KeyWords()
        {
            #region const常量关键字
            //将某个变量固定，防止后续被修改
            int a;
            a = 66;
            //公共的属于常量字段不可以在局部定义，编译不通过
            //public const double X = 1.0, Y = 32.45, C = 2352.4;

            //这是局部常量或本地常量，作用域在函数内部
            const int b = 44;//常量在定义的时候就要赋值，不可以后面再赋值            
            #endregion

            #region ref和out关键字，in关键字
            //他们的传递方式都是引用。

            //out关键字是单项输出，向编译器保证这个定义的方法一定会给这个参数传回一个值。
            //和函数本身的返回值不冲突。
            //设计意图：单纯的“产出”一个结果
            //典型例子：TryParse方法通过返回bool值表示转换操作结果，通过out参数传回转换后的值
            //这样可以避免抛出异常的开销
            //out参数在方法刚开始时视为“未赋值”不能读取。方法在返回前必须要给out参数赋值，否则编译失败
            //将字符串尝试转换成int类型，函数本身返回bool结果，out参数result接收转换后的值
            //int result;
            //int.TryParse("123", out result);  可以先声明变量再调用赋值
            int.TryParse("123", out int result);  //推荐调用时就地声明，可读性高且防止意外调用
            Console.WriteLine(result);  //123

            //ref不同点在于双向传递，方法既能在调用时读取传进来的值，也能修改并传回调用方
            //方法内部可以读取修改，也可以不修改，不强制
            //设计意图：“更新”或“替换”一个现有值
            //典型场景：修改调用方的变量
            Test t = new Test();
            int x = 1, y = 2;
            t.Swap(ref x, ref y);
            Console.WriteLine($"x:{x},y:{y}");//x:2,y:1
                                              //本身时引用类型的参数比如test实例，方法也能修改对象内部数据。

            //一般性建议：优先避免使用：ref 和 out 会使代码的控制流和数据流变得不那么直观。
            //在现代 C# 中，许多过去需要使用它们的场景，现在都有更好的替代方案：
            /*
             * 需要返回多个值 → 值元组 (int sum, int count)。
             * 需要返回操作成功与否及结果 → Try 模式（out 是此模式的合理例外）。
             * 需要传递大型只读结构体以避免复制 → in 参数（如上一轮所述）。
             * 需要返回一个可修改的引用 → 考虑返回引用（ref return）。
             */
            #endregion
        }
        //in关键字和前面相反，向函数传递的参数是只读的，供函数读取但不能修改。所以参数必须是已经赋值过的
        //设计意图：避免大型值类型的复制开销
        //与 readonly struct 搭配。in 参数的主要设计目标之一是提升性能，尤其适用于大型结构体（struct）。
        //它避免了按值传递时产生完整的结构体副本。
        public int Increment(in int value)
        {
            // 下面这行代码会导致编译错误 CS8331
            // value = value + 1; 
            return value + 1;
        }
        // 推荐做法：将结构体声明为 readonly
        public readonly struct LargeStruct { /* 很多字段 */ }
        public void Process(in LargeStruct data)
        {
            // 安全且高效，无防御性副本
        }
    }

    class Test
    {
        public Test()
        {
            Console.WriteLine(KeyWords.X);//const和static用法一样
        }
        //使用了ref关键字定义的方法
        public void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }

        void InAndOut()
        {
            #region 逆变和协变
            /*
             * 逆变和协变是泛型类型参数的可变性规则，它回答一个具体问题：当类型A和类型B有继承关系时。
             * Ifoo<A>和Ifoo<B>之间能不能相互赋值。C#中由泛型接口或委托上面是否标注了in或out来决定
             * 协变（out），允许用“更具体”的类型替换“更一般”的类型。顺着继承链的方向走。派生类 -> 基类 方向可以赋值
             * 逆变（in），允许用“更一般”的类型替换“更具体”的类型。逆着继承链的方向走。基类 -> 派生类 方向可以赋值
             */
            //拿动物举例：string是object的派生类
            // 协变：IEnumerable<string> 可以赋给 IEnumerable<object>
            IEnumerable<string> strings = new List<string>();
            IEnumerable<object> objects = strings;   // ✅ 协变，安全
            /*
             * 为什么IEnumerable<string> 能当 IEnumerable<object> 用？
             * IEnumerable<out T>的定义里，T只出现在输出位置（Current属性、GetEnumerator的返回等）
             * 它只“产出”T，不“消费”T。
             * public interface IEnumerable<out T>
             * {
             *  IEnumerator<T> GetEnumerator();   // "我"产出 T 给别人遍历
             * }
             * public interface IEnumerator<out T>
             * {
             *  T Current { get; }   // getter 返回 T → 产出
             *  bool MoveNext();
             *  void Reset();
             * } 
             */


            // 逆变：Action<object> 可以赋给 Action<string>
            Action<object> handleObject = o => Console.WriteLine(o);
            Action<string> handleString = handleObject; // ✅ 逆变，安全
            /*
             * 为什么Action<object> 能当 Action<string> 用？
             * Action<in T>的定义里，T只出现在输入位置，它只“消费”T
             * 一个能处理object的方法，自然也能处理string——因为string是object的一种
             * 所以把Action<object>赋给Action<string>是安全的；当传递stringi进来，方法按object处理。没问题
             * 
             * 反过来把Action<string>赋给Action<object>就不行了，方法按照string来处理。
             * 这时如果传进来一个int就处理不了，因为方法只会处理string。
             */

            //日常使用案例
            /*
            List<string> names = new List<string> { "a", "b" };
            IEnumerable<object> objs = names;          // 协变，赋值给 IEnumerable<object>

            names.Where(...)                            // LINQ 大量依赖 IEnumerable<out T>
                 .Select(x => x.Length);

            Action<object> log = o => Console.WriteLine(o);
            button.Click += (s, e) => { };              // 事件委托的协变/逆变匹配

            IComparer<object> objComparer = Comparer<object>.Default;
            IComparer<string> strComparer = objComparer; // 逆变
            */

            #endregion

        }
        // in 表示 T 只出现在输入位置，"别人"给我一个 T，我拿来用
        public delegate void Action<in T>(T obj);
        //既产出又消费，所以不能协变和逆变，就是不变
        public interface IList<T>
        {
            T this[int index] { get; set; }   // getter 产出 T；setter 消费 T
            void Add(T item);                 // 消费 T
        }
    }


}

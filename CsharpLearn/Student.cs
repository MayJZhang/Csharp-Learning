using System;

namespace Basic01
{
    public class Student
    {
        #region 类的成员
        //类的成员包括字段、属性、方法、构造函数、事件、索引器、析构函数等
        //字段（field）是类或结构体中定义的变量，用于存储对象的状态信息
        //字段可以有访问修饰符，默认是 private
        //字段可以是静态的（static），表示属于类而不是对象
        static int studentCount = 0; //静态字段，用于统计学生人数

        //属性（property）是类或结构体中定义的成员，用于封装字段的访问和修改
        // <summary> 自动属性，自动实现了get和set方法
        public string Name { get; set; }

        // <summary> 如果要在访问器中添加逻辑，可以使用私有字段来存储值，并在访问器中添加验证逻辑。
        // </summary>
        private int _age;   // 私有备份字段，用于存储年龄值
        public int Age
        {
            get { return _age; }  //读值
            set //赋值时进行验证
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("年龄不能为负数");
                }
                _age = value;
            }
        }
        //纯计算只读属性。不需要备份字段和set访问器，直接计算返回值。=>是表达式体成员，简化了属性的写法。
        public string Id => Name + Age + studentCount; //学生身份编号



        //构造函数（constructor）是类或结构体中定义的特殊方法，用于初始化对象的状态
        //构造函数的名称与类名相同，没有返回类型，可以有参数，也可以没有参数
        //如果没有定义任何构造函数，编译器会自动生成一个无参的默认构造函数
        //如果人为编写了构造函数，编译器就不会再生成默认的无参构造函数了
        //构造函数可以有多个重载版本，以支持不同的初始化方式，比如初始化的时候给定默认值，或者根据传入的参数来设置不同的属性值
        //***构造函数可以调用其他构造函数，以实现代码复用和简化初始化逻辑
        //构造函数可以使用访问修饰符来控制对象的创建和访问权限，一般是public或internal
        public Student() => studentCount++; //每创建一个学生对象，学生人数加1
        /// <summary>
        /// 重载构造函数，带参数的构造函数
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="age">年龄</param>
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            studentCount++;
        }
        /// <summary>
        /// 重载构造函数，带参数的构造函数
        /// this关键字：表示当前对象的引用，可以用来访问当前对象的成员，也可以用来调用其他构造函数
        /// base关键字：表示基类对象的引用，可以用来访问基类的成员，也可以用来调用基类的构造函数
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="age">年龄</param>
        /// <param name="id">学生身份编号</param>
        public Student(string name, int age, string id) : this(name, age) //调用其他构造函数，this是当前对象的引用，base是基类对象的引用
        {
            id = name + age + studentCount;
            //Id = id; 只读属性不能赋值，Id是只读属性，只能在构造函数中初始化
        }


        //方法（method）是类或结构体中定义的成员，用于实现对象的行为和功能
        //方法可以有访问修饰符，默认是 private。方法可以使用访问修饰符来控制对象的调用和访问权限，一般是public或internal
        //方法可以有返回类型，可以有参数，也可以没有参数
        //方法可以有多个重载版本，以支持不同的调用方式，比如根据传入的参数类型和数量来执行不同的逻辑
        //方法可以使用虚方法（virtual）和抽象方法（abstract）来实现多态性和接口的实现
        //方法可以使用静态方法（static）来实现类级别的功能，而不需要创建对象实例，这是属于类本身的行为，而不是对象的行为
        public void Study()
        {
            Console.WriteLine($"{Name} is studying.");
        }
        /// <summary>
        /// 学生学习方法，带学习科目参数
        /// </summary>
        /// <param name="subject">学习科目</param>
        public void Study(string subject) //方法重载（overload）是指在同一个类中，允许存在多个方法名相同但参数列表不同的方法
        {
            Console.WriteLine($"{Name} is studying {subject}.");
        }

        //析构函数（destructor）是类中定义的特殊方法，用于释放对象占用的资源，生命周期结束时自动调用
        ~Student()
        {
            studentCount--;
            Console.WriteLine("对象被释放");
        }

        //事件（event）是类或结构体中定义的成员，用于实现对象之间的通信和通知
        //索引器（indexer）是类或结构体中定义的成员，用于通过索引访问对象的元素
        //事件和索引器的使用比较高级，这里不做详细介绍
        //类里面也可以定义嵌套类（nested class），用于封装和组织相关的类，嵌套类可以访问外部类的私有成员
        //类里面也可以定义委托（delegate），用于实现回调和事件处理，委托是一种类型安全的函数指针，可以引用任何符合签名的方法

        #endregion
    }
}

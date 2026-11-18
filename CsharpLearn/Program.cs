using System;

/*
 命名空间：Basic01 关键字
 空间成员：class、struct、interface、enum、delegate，其他namespace
 */
namespace Basic01
{
    /*
	 internal 关键字：表示该类只能在当前程序集内访问，不能被其他程序集访问
	 访问修饰符：
			public：公共的，任何类都可以访问
			private：私有的，只有当前类可以访问
			protected：受保护的，只有当前类和派生类可以访问
			internal：内部的，只有当前程序集可以访问
			protected internal：受保护的内部的，只有当前程序集和派生类可以访问
	 */
    internal class Program
    {

        /*
		 Main 方法是程序的入口点，必须是静态的（static），返回类型为 void，参数为字符串数组（string[] args）
		 程序一旦执行完 Main 方法，就会退出程序，除非在 Main 方法中调用其他方法或线程
		 */
        static void Main(string[] args)
        {
            //Console类是静态类，静态类里面的成员都得是静态的，是属于类的，不能实例化对象
            //Console的静态属性背景色是ConsoleColor类型      枚举类型的值
            Console.BackgroundColor = ConsoleColor.DarkBlue; //设置控制台背景色
            Console.ForegroundColor = ConsoleColor.White; //设置控制台前景色

            #region 命名空间、using的用法
            //F12查看定义，int是System.Int32的别名，System是命名空间，Int32是结构体
            int a = 666;

            //new的过程
            //1.在堆上分配内存空间，存储对象的状态信息（字段、属性等）
            //2.调用构造函数，初始化对象的状态信息
            //3.返回对象的引用（地址），存储在栈上
            //4.对象的引用可以通过变量来访问对象的成员（字段、属性、方法等）
            //5.对象的生命周期由垃圾回收器（gc）管理，当对象不再被引用时，gc会自动回收对象的内存空间
            Student student = new Student("alice", 21);
            //在无参构造函数实例化的时候，也可以为属性赋值
            Student student1 = new Student()
            {
                Age = 18,
                Name = "Amy"
            };
            //使用命名空间的方式来区分不同命名空间中同名的类
            Person ps1 = new Person();
            SubNamespace.Person ps2 = new SubNamespace.Person();

            //显示转换
            Gender gd1 = (Gender)1;
            Console.WriteLine($"gd1:{gd1}");
            #endregion

            #region C#中的注释
            //单行注释
            /*
			 多行注释、块注释
			 */
            ///在一个类或类的成员上面使用三斜杠注释，可以生成XML文档注释，供开发者查看类或类成员的功能说明
            /* Ctrl+K+C注释  Ctrl+K+U取消注释 */
            #endregion


        }
    }

    //类（class）是引用类型，表示一组相关的属性和方法的抽象
    //类可以包含字段、属性、方法、事件、索引器、构造函数、析构函数等成员
    //类可以继承自其他类，一个类只能继承一个基类，但可以实现多个接口
    //类的成员可以有访问修饰符，默认是 private
    //类的命名一般以大写字母开头，后面跟类的功能描述
    class Person
    {
        //字段（field）是类或结构体中定义的变量，用于存储对象的状态信息
        //字段可以有访问修饰符，默认是 private
        //字段可以是静态的（static），表示属于类而不是对象
        //字段可以是只读的（readonly），表示只能在声明时或构造函数中赋值
        //字段可以是常量的（const），表示在编译时就确定了值，不能修改
        public string Name;
        public int Age;
        public string Gender;
    }

    //结构体（struct）是值类型，类（class）是引用类型。
    //结构体用的不多，一般用 类 来定义对象，结构体一般用来定义简单的数据类型
    struct Employee
    {
        public int Id;
        public string Name;
        public double Salary;
    }

    //枚举（enum）是值类型，表示一组命名的常数
    //可以封装一组相关的常量，便于代码的可读性和维护性
    //枚举的底层类型可以是 byte、sbyte、short、ushort、int、uint、long 或 ulong，默认是 int
    enum Gender     //指定底层类型举例 enum Gender : byte
    {
        Male,
        Female,
        Other
    }
    
    //接口（interface）是引用类型，表示一组相关的功能的抽象
    //接口不能被实例化，只能被类或结构体实现
    //接口可以包含方法、属性、事件和索引器的声明，但不能包含字段
    //接口可以继承自其他接口，一个类或结构体可以实现多个接口
    //接口的成员默认是 public 的，不能使用访问修饰符
    //接口的命名一般以 I 开头，后面跟接口的功能描述
    interface IShape
    {
        double Area();
        double Perimeter();
    }

    //委托（delegate）是引用类型，表示对方法的引用
    //委托可以封装一个或多个方法，调用委托就相当于调用这些方法
    //委托类型的变量可以指向任何与其签名匹配的方法。
    //也就是说可以指向一个或多个方法
    //委托的声明格式为：delegate 返回类型 委托名(参数列表);
    delegate void MyDelegate(string message);

    //子命名空间（sub namespace）是命名空间的嵌套，表示命名空间的层次结构
    //！！！不推荐这种多层嵌套的命名空间，容易造成代码混乱和可读性差
    //！！！直接在和父命名空间平行的层级上创建新的命名空间即可，例如namespace Basic01.SubNamespace
    namespace SubNamespace  //namespace: Basic01.SubNamespace
    {
        //子命名空间可以包含类、结构体、接口、枚举、委托等成员
        //子命名空间的命名一般以父命名空间为前缀，后面跟子命名空间的功能描述
        /*class SubClass
		{
			public void SubMethod()
			{
				Console.WriteLine("This is a method in the sub namespace.");
			}
		}*/

        //子命名空间中的类可以和父命名空间中的类同名，但需要使用完整的命名空间来区分
        //子命名空间中的类可以访问父命名空间中的类和成员，但需要使用完整的命名空间来引用
        //子命名空间中的类可以继承父命名空间中的类，但需要使用完整的命名空间来指定基类
        //子命名空间中的类可以实现父命名空间中的接口，但需要使用完整的命名空间来指定接口
        //子命名空间中的类可以使用父命名空间中的枚举和委托，但需要使用完整的命名空间来指定枚举和委托
        //子命名空间中的类可以使用父命名空间中的结构体，但需要使用完整的命名空间来指定结构体
        //子命名空间中的类可以使用父命名空间中的命名空间，但需要使用完整的命名空间来指定命名空间
        //子命名空间中的类可以使用父命名空间中的 using 指令，但需要使用完整的命名空间来指定 using 指令
        //子命名空间中的类可以使用父命名空间中的 static 类，但需要使用完整的命名空间来指定 static 类
        /*class Person
		{
			public string Name;
			public int Age;
			public string Gender;
		}*/

        //这不代表父命名空间包含子命名空间，父命名空间和子命名空间是平行的关系
        //从属关系：子命名空间中的类可以访问父命名空间中的类和成员，但需要使用完整的命名空间来引用
        //子命名空间和父命名空间是平行的关系，子命名空间不能访问父命名空间中的私有成员
        //！！！不推荐这种多层嵌套的命名空间，容易造成代码混乱和可读性差
        namespace InnerNamespace  //namespace: Basic01.SubNamespace.InnerNamespace
        {
            class InnerClass
            {
                public void InnerMethod()
                {
                    Console.WriteLine("This is a method in the inner namespace.");
                }
            }
        }
    }
}

//建议在实际开发中，命名空间的使用应该遵循以下原则：
//1. 命名空间的命名应该具有唯一性，避免与其他命名空间冲突。
//2. 命名空间的命名应该具有层次性，便于组织和管理代码。
//3. 命名空间的命名应该具有可读性，便于理解和维护代码。
//4. 命名空间的命名应该具有可扩展性，便于后续添加新的功能模块。
//5. 命名空间的命名应该具有一致性，便于团队协作和代码规范。
//不建议不推荐多层大括号嵌套，容易造成代码混乱和可读性差。可以使用 using 指令来简化命名空间的引用，或者将子命名空间放在单独的文件中。
namespace Basic01.SubNamespace  //namespace: Basic01.SubNamespace
{
    //命名空间的作用是为了组织代码，避免命名冲突，提高代码的可读性和可维护性
    //命名空间可以嵌套，可以包含类、结构体、接口、枚举、委托等成员
    //命名空间可以使用 using 指令来引用其他命名空间中的成员，简化代码的书写
    //命名空间的命名一般以公司或组织的域名为前缀，后面跟项目名称和功能描述
    //命名空间的命名规则是 Pascal 命名法，即每个单词的首字母大写，其他字母小写
    class SubClass
    {
        public void SubMethod()
        {
            Console.WriteLine("This is a method in the sub namespace.");
        }
    }

    class Person
    {
        public string Name;
        public int Age;
        public string Gender;
    }
}

using System;
using System.Collections.Generic;

namespace Basic02
{
    //泛型约束
    internal class Generic_Type
    {
        //什么是泛型
        //把类型变成参数，让代码在编译期就能适配多种类型，同时保留完整的类型信息
        // T 占位符，代表某种类型，具体什么类型调用时才确定
        public T Max<T>(T a, T b)// <T>表示方法Max有一个类型参数叫T，a和b参数都是T类型
        {
            // 这里还不能比较，先放着，后面讲约束时解决
            return a;// 返回T类型
        }
        #region 泛型的四种形态
        //泛型方法
        public T Identity<T>(T value) => value;
        //泛型类
        public class Box<T>
        {
            private T _value;
            public Box(T value) { _value = value; }
            public T GetValue() => _value;
        }
        //泛型接口
        public interface IRepository<T>//  User、Admin、Student、相机、X轴，不管谁都可以实现这个接口
        {
            T GetById(int id);
            bool Save(T entity);
        }
        public class User { };
        public class UserRepository : IRepository<User>
        {
            public User GetById(int id) => new User();
            public bool Save(User user) => true;
        }
        //泛型委托
        public delegate T Factory<T>();//   无参、返回T类型的工厂委托
        Func<int, string> f = x => x.ToString();// .NET内置的泛型委托，有返回值
        Func<string> f1 = () => "";
        Action<int> action = x => x.ToString();//   无返回值
        #endregion

        public Generic_Type()
        {
            //调用泛型
            int i = Max<int>(3, 5);        // T = int
            double d = Max<double>(1.5, 2.5); // T = double
            string s = Max<string>("a", "b"); // T = string

            var intBox = new Box<int>(28);
            var stringBox = new Box<string>("haoran");
            int age = intBox.GetValue();// 不用强转，不存在拆箱，类型安全

        }
        #region 泛型约束
        //为什么泛型需要约束
        /* public T Min<T>(T a, T b)
         {
             // return a > b ? a : b;   // 编译错误！这个时候编译器不知道T到底是什么，有没有 > 运算符的定义
             //编译器不会允许这种不确定的危险存在
         }*/
        //同理下面的全部都无法编译通过
        /*public void Demo<T>(T x)
        {
            x.ToString();          // ✗ 能调吗？编译器假设 T 是 object，其实 ToString 可以调（所有类型都有）
            x.SomeMethod();        // ✗ T 一定没有 SomeMethod
            new T();               // ✗ T 可能没有无参构造
            if (x != null) { }     // ✗ 值类型不能和 null 比较（老版本）
            T.Parse("...");        // ✗ T 不一定有 Parse
        }*/
        //约束就像说明书，告知这个泛型还有那些能做的
        //附说明书"里面是值类型"：你能做值类型能做的事（default(T)、不能判 null）
        //附说明书"里面实现了 IComparable<T>"：你能调 CompareTo
        //附说明书"有无参构造函数"：你能 new T()
        public T Min<T>(T a, T b) where T : IComparable<T>// 传进来的T必须实现了IComparable<T>接口
        {
            return a.CompareTo(b) >= 0 ? a : b;   // ✓ 现在合法了
        }
        public void test()
        {
            Min(3, 5);                    // ✓ int 实现了 IComparable<int>
            Min("a", "b");                // ✓ string 实现了 IComparable<string>
            //Min(new object(), new object()); // ✗ 编译错误：object 没实现 IComparable<object>
        }
        #endregion


        #region 泛型完整使用示例
        /*写一个通用的“缓存”，可以存各种类型但要求：
         * 1、存入的类型必须有唯一的Id（能比较相等）
         * 2、取出来的数据要能判断空
         */
        //第一步，定义一个接口，实现类必须有Id
        public interface IEntity<Tkey>
        {
            Tkey Id { get; }
        }
        public class Cache<TEntity, Tkey>
            where TEntity : IEntity<Tkey>//约束1：必须实现IEntity接口，可以判空(类默认值null)，当然也可以添加class为约束
            where Tkey : IEquatable<Tkey>//约束2：Tkey可以比较相等
        {
            private readonly Dictionary<Tkey, TEntity> _map = new Dictionary<Tkey, TEntity>();
            public void Add(TEntity entity)
            {
                _map[entity.Id] = entity;// 因为约束1，编译器知道entity有Id；
            }
            public TEntity Find(Tkey id)
            {
                return _map.TryGetValue(id, out TEntity entity) ? entity : default;// 无法使用null
                //  因为上面约束没有添加 class约束，但是没关系，类实现接口本身类就是引用类型，默认值为null
            }
        }
        //使用
        public class Position : IEntity<int>
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public void test2()
        {
            var cache = new Cache<Position, int>();
            cache.Add(new Position { Id = 1, Name = "haoran"});
            cache.Find(1);
        }
        #endregion
    }
}

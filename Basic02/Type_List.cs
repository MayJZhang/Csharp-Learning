using System.Collections.Generic;
using System.Linq;

namespace Basic02
{
    internal class Type_List
    {
        public Type_List()
        {
            #region List<T>集合
            //与数组不同，List<T>集合随时可以添加或删除元素
            List<int> ints = new List<int>() { 10, 20 };
            ints.Add(30);
            //实现了IEnumerable可枚举接口的对象都可以使用foreach遍历
            ints.AddRange(new int[] { 40, 50 });//把符合指定泛型类型的可枚举对象复制到末尾
            ints.Remove(70);//false
            //集合转数组 ToArray，数组转集合 ToList
            int[] ints1 = ints.ToArray();
            List<int> ints2 = ints1.ToList();
            #endregion
        }
    }
}

namespace Basic04_Function
{
    //方法的参数
    internal class Function_Argument
    {
        public Function_Argument()
        {
            #region 方法的参数传递
            //方法的参数类型其实根据数据类型，就可以划分为“值类型参数”和“引用类型参数”
            //值类型参数传入后就是复制，修改形参不会影响实参
            //引用类型参数传入后，形参得到的是对实体的引用，修改形参，实参对应也会改变。

            //ref关键字，可以声明参数为引用类型，哪怕原本的参数是值类型。一般不推荐

            //out关键字，只产出不使用。函数必须要在内部给其赋值。
            //使用场景，try模式。当失败的原因不那么重要，不值得捕捉异常时。只需要考虑是否成功。成功就赋值给out参数
            //成功与否是主要的，只有成功了out参数才有意义。两个返回值是有主次的
            //除此之外现在尽量避免使用out，如果两个返回结果没有主次，平等的需要返回多个值建议使用值元组
            //！！！真正的异常错误（bug）仍然应该抛异常

            //in关键字，只使用不产出。一般搭配readonly结构体使用。只能拿来用不能修改


            testParams(2, 4, 1, 4, 5);//  参数被打包成数组
            #endregion
        }
        //params关键字，修饰函数参数，将函数参数打包成数组
        public void testParams(params int[] input)
        {
            /*内部代码*/
        }

        //值元组返回类型的函数
        public (int, string) GetPair()
        {
            return (42, "hello");
        }
        //给元素命名
        public (int Sum, int Count) Calculate(int[] numbers)
        {
            int sum = 0;
            foreach (var n in numbers) sum += n;
            return (sum, numbers.Length);   // 返回值按位置对应，名字来自返回类型
        }

    }
}

using System;

namespace Basic04_Function
{
    //异常捕捉
    internal class Function_Exceptions
    {
        public T UserInput<T>(T a)
        {
            #region try-catcah-finally基本结构
            try
            {
                // 可能抛出异常的代码
                int x = int.Parse("abc");
                return a;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"格式错误: {ex.Message}");
                return a;
                //throw ex;//不return可以继续抛出，但这样会重置堆栈跟踪，导致丢失原始的异常抛出位置
                //throw; //   这样会保留原始堆栈
            }
            catch (Exception)// 不需要异常对象时可以不用写变量名
            {
                /*只关心类型*/
                return a;
            }
            finally//  不管是否有异常，最终都会执行（除非进程崩溃）。哪怕try-catcah里面有return
            {
                // 无论是否异常都会执行（除非进程崩溃）
                Console.WriteLine("清理工作");
                //return;   在finally里使用return会静默丢弃异常，非常危险！禁止这种写法
            }

            //异常过滤器when
            //不破坏堆栈：过滤条件不满足时异常继续向上传播，堆栈保持原样（用 catch + if + throw; 会多一层堆栈）
            // 反例：用 if 判断再 throw，会污染堆栈
            try { }
            catch (Exception ex)
            {
                if (ex.Message.Contains("timeout")) { /* 处理 */ }
                else throw;   // 堆栈多一层
            }
            try { }
            // 正例,可读性好：按业务条件分流。
            //性能更好：过滤不命中时无需展开/捕获异常对象的开销。
            catch (Exception ex) when (ex.Message.Contains("timeout")) { /* 处理 */ }
            #endregion
        }
    }
}

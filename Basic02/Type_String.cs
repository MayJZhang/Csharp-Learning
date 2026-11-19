using System;
using System.Diagnostics;
using System.Text;

namespace Basic02
{
    internal class Type_String
    {
        public Type_String()
        {
            #region string字符串的使用
            //字符串的使用
            //1、字符串的截取 Substring
            string str1 = "今天是晴天";
            string str2 = str1.Substring(str1.Length - 3);//    从指定位置开始截取
            string str3 = str1.Substring(1, 3);//   从指定位置1截取长度3

            //2、判断一个字符串是否包含某个字符元素 Contains
            string str4 = "我今天的心情很不错";
            bool isContains = str4.Contains("心");// 返回bool

            //3、替换字符串某些元素 Replace
            string str5 = "春天散步，夏天看海，秋天属落叶";
            string str6 = str5.Replace("，", "♥");// 把逗号替换成♥
            string str7 = str5.Replace("冬天", "000");// 如果没有匹配到旧字符，则不替换

            //4、移除字符串某个元素 Remove
            string str8 = "小明小红今天会过来！";
            Console.WriteLine(str8.Remove(2));//  小明
            Console.WriteLine(str8.Remove(2, 2));//  小明今天会过来！

            //5、提出字符串左右两边的空格 Trim。中间的空格不会去掉
            string str9 = "  今天的天气真好    心情也不错   ";
            Console.WriteLine(str9.Trim());//今天的天气真好    心情也不错

            //6、查找或定位到指定元素的位置 IndexOf   如果没有，就返回-1
            string str10 = "\"春天散步，夏天看海，秋天属落叶\"";
            int num1 = str10.IndexOf("春天");
            Console.WriteLine(num1);//  1
            int num2 = str10.IndexOf("冬天");
            Console.WriteLine(num2);//  -1，没有匹配到
            Console.WriteLine(str10.IndexOf("天"));//  2，默认匹配到第一个就返回
            Console.WriteLine(str10.IndexOf("天", 5));// 7，从指定索引开始查找
            Console.WriteLine(str10.LastIndexOf("天"));// 12 从最后面开始找
            //7、判断是否以 某元素开头 StartWith 或者结尾 EndsWith
            string str11 = "好好学习，天天向上";
            Console.WriteLine(str11.StartsWith("好好"));
            Console.WriteLine(str11.EndsWith("向上"));

            //8、转大写 转小写
            string str12 = "12ABCD编程";
            Console.WriteLine(str12.ToUpper());// 12ABCD编程
            Console.WriteLine(str12.ToLower());// 12abcd编程

            //9、把字符串数字按指定分隔符连接成一个字符串 Join
            string[] strs = new string[] { "红楼梦", "三国演义", "西游记" };
            string str13 = string.Join("，", strs);

            //10、字符串分割 Split
            string str14 = "红楼梦，三国 演义，西游记";
            string[] separator = new string[] { "，", "|", "*", " " };
            // 数组做参数直接放进去，RemoveEmptyEntries返回值不包含空字符
            string[] strs2 = str14.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in strs2)
            {
                Console.WriteLine(item);

            }
            /*output:
             * 红楼梦
             * 三国
             * 演义
             * 西游记*/


            //11、插入Insert
            string str15 = "今天嫁给我";
            string str16 = str15.Insert(2, "你要");// 从给定索引位置插入指定内容
            Console.WriteLine(str16);


            //12、判断字符串非空
            string str17 = null;//没有实体堆
            string str18 = "";//有实体但没数据
            string str19 = "    ";//有实体堆但是堆内是不可见字符
            Console.WriteLine(string.IsNullOrWhiteSpace(str17));//true
            Console.WriteLine(string.IsNullOrWhiteSpace(str18));//true
            Console.WriteLine(string.IsNullOrWhiteSpace(str19));//true
            Console.WriteLine(string.IsNullOrEmpty(str18));//true
            Console.WriteLine(string.IsNullOrEmpty(str19));//false
            #endregion

            #region string和StringBuilder区别
            //string类型的方法会创建新的string对象，不会改变原有对象
            //创建对象会占用系统内存资源，消耗时间
            //一旦创建string对对象就不能修改
            //如果需要大量修改时，可使用StringBuilder类
            string str20 = "今天是晴天";
            string str21 = str20.Substring(0, 2);//创建新的对象
            string str22 = str20 + "balabala";//创建新对象
            str20 = str22;//传引用，此时两个指向同一个
            str22 = "新的值";//并没有影响str20。赋值操作会创建新的string对象
            //StringBuilder是引用类型，进行大量的字符串操作时建议使用
            //不创建实例，只在内存堆里修改
            StringBuilder sb = new StringBuilder("今天下课直接出去玩");
            StringBuilder builder = sb.Append("，记得先去取钱");//方法不会创建新的实体堆
            Console.WriteLine(sb == builder);// true，指向的是同一个引用
            Console.WriteLine($"{sb}***{builder}");
            sb.Remove(0, 2);
            sb.Replace("出去", "考虑一下再出去");
            sb.Insert(0,"今天还是明天");
            string str23 = sb.ToString();
            Console.WriteLine(str23);

            #endregion

            #region string和StringBuiler性能比较
            string str24 = "";
            Stopwatch stopwatch = Stopwatch.StartNew();//   创建实例并清零开始计时
            for (int i = 0; i < 500; i++)
            {
                str24 += "abc";
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);// 0
            Console.WriteLine(stopwatch.ElapsedTicks);// 5101 耗时远大于StringBuilder
            Console.WriteLine(stopwatch.Elapsed);

            StringBuilder stringBuilder = new StringBuilder();
            stopwatch.Restart();//  清零重新开始计时
            for (int i = 0; i < 500; i++)
            {
                stringBuilder.Append("abc");
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);// 0
            Console.WriteLine(stopwatch.ElapsedTicks);// 142 耗时远小于string
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Reset();// 清零
            #endregion
        }
    }
}

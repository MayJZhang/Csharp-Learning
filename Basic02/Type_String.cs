using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic02
{
    internal class Type_String
    {
        public Type_String()
        {
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

            //5、提出字符串左右两边的空格 Trim

            //6、查找或定位到指定元素的位置 IndexOf   如果没有，就返回-1

        }
    }
}

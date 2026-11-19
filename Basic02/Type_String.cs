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

        }
    }
}

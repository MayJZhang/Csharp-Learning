using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Basic03_KeyWordStatement
{
    //  正则表达式。为了从字符串中找出需要的数据，而string提供的方法不够用的时候
    internal class Regular_Expression
    {
        //基础语法常用元字符
        /*  符号	    含义	
         *  .	    任意字符（单行模式含换行）	
         *  \d	数字，等价于 [0-9]	
         *  \D	非数字的字符，等价于 [^0-9]，字符集取反
         *  \w	字母、数字、下划线	
         *  \W	非单词字符	
         *  \s	空白（空格、tab、换行）	
         *  \S	非空白	
         *  ^	字符串开头（多行模式：行开头）	
         *  $	字符串结尾（多行模式：行结尾）	
         *  *	0 次或多次	
         *  +	1 次或多次	
         *  ?	0 次或 1 次；紧跟在 *+ 后面 = 非贪婪	{n}	恰好 n 次	
         *  {n,}	至少 n 次	
         *      \d{3,} 3个及以上的数字 
         *  {n,m}	n~m 次，尽可能多的匹配（贪婪的）
         *      \d{3,6} 3到6位数字
         *  ()	捕获分组	
         *  (?:)	非捕获分组，只分组不捕获	
         *  []	字符集 [abc]，匹配其中任意一个元素 a/b/c	
         *  |   或 a(b|d)c   abc或adc
        ************************************************/
        /*  贪婪 vs 非贪婪：
         * "<a>1</a><b>2</b>"
         *  <.+> → 贪婪，匹配全部 <a>1</a><b>2</b>
         *  <.+?> → 非贪婪，依次匹配 <a>1</a>、<b>2</b>
         **********************************************/
        /*  特殊元字符：. \ + * ? [ ] ( ) { } | ^ $，这些不能直接匹配，需要加反斜杠转义 “\”
         *  示例：想要匹配一个点 “.”，正则写 \.，C# 字符串：@"\."
         */

        public Regular_Expression()
        {
            while (true)
            {
                Console.WriteLine("请输入一串字符");
                string input = Console.ReadLine();
                bool isNoNumber = Regex.IsMatch(input, @"^H[^0-9]+$");//H开头且从头到尾不能有数字,+表示至少匹配一次
                bool isTelephone = Regex.IsMatch(input, @"[0-9]{11}");//11位数字
                bool isAAbbb = Regex.IsMatch(input, @"A{2}b{3}");// 2个A3个b
                bool isABCBCBC = Regex.IsMatch(input, @"A(BC){3}");// ()分组
                bool isABorC3 = Regex.IsMatch(input, @"A(B|C){3}");// ()分组 |表示或 ABBB/ACCC/ABCC/ABBC/ABCB/ACBC/ACCB/ACBB
                bool is3number = Regex.IsMatch(input, @"[3-6][2-7][1-9]");//三位数字每一个的范围不一样
                bool isOK = Regex.IsMatch(input, @"[a-zA-Z0-9]");// 大小写字母+数字
                bool isSpace = Regex.IsMatch("fdsafs\ndsaf\r", @"\s"); // 匹配空白字符，空格制表换行
                Regex.IsMatch(" a ba  ab", @"\ba\b");   //  a的两边都有边界

                if (isSpace)
                {
                    Console.WriteLine("有空白字符");
                    MatchCollection collection = Regex.Matches(input, ".");
                    foreach (Match item in collection)
                    {
                        Console.WriteLine(item.Success+item.Value);
                    }
                    break;
                }   
            }
        }
    }
}

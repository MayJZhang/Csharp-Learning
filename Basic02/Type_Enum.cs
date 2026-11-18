using System;

namespace Basic02
{
    internal class Type_Enum
    {
        //枚举（enum）是值类型，表示一组命名的常数
        //可以封装一组相关的常量，便于代码的可读性和维护性
        //枚举的底层类型可以是 byte、sbyte、short、ushort、int、uint、long 或 ulong，默认是 int
        enum Gender     //指定底层类型举例 enum Gender : byte
        {
            Male,
            Female,
            Other
        }
        enum Level  //权限配置，if(obj.level >= Level.Engineer) 放行
        {
            /// <summary>
            /// 操机仔
            /// </summary>
            Operator,
            /// <summary>
            /// 工程师
            /// </summary>
            Engineer,
            /// <summary>
            /// 管理员
            /// </summary>
            Admin
        }
        enum ErrorCode : ushort
        {
            None = 0,
            Unknown = 1,
            ConnectionLost = 100,
            OutlierReading = 200
        }
        public Type_Enum()
        {
            //枚举和字符串之间的转换
            #region 枚举和字符串转换
            Gender gd = Gender.Female;
            string gds = gd.ToString();//Female
            string str1 = "Male";
            Type type1 = typeof(Gender);
            Gender gd2 = (Gender)Enum.Parse(type1, str1);//不能乱写，如果str1的值不在Gender范围。会报错。
            bool res = Enum.TryParse<Gender>(str1, true, out Gender gd3);
            bool res1 = gd3.Equals(Gender.Male);
            #endregion
        }
                
    }
}

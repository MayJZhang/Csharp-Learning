using System;

namespace HomeWork.Work1113
{
    internal class Date
    {
        /// <summary>
        /// 年份
        /// </summary>
        private int _year;
        public int Year
        {
            get => _year; set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("请输入合理年份");
                _year = value;
            }
        }
        /// <summary>
        /// 月份
        /// </summary>
        private int _month;
        public int Month
        {
            get => _month; set
            {
                if (value < 1 || value > 12)
                    throw new ArgumentOutOfRangeException("请输入合理月份");
                _month = value;
            }
        }
        /// <summary>
        /// 天数
        /// </summary>
        private int _day;
        public int Day
        {
            get => _day; set
            {
                if (value < 1 || value > 31)
                    throw new ArgumentOutOfRangeException("请输入合理天数");
                _day = value;
            }
        }
        private Week _week;
        public Week week
        {
            get => _week; set
            {
                if (!Enum.IsDefined(typeof(Week), value) || value.Equals(Week.Other))
                {
                    Console.WriteLine(value);
                    throw new ArgumentOutOfRangeException("请输入合理信息");
                }                    
                _week = value;
            }
        }

        public enum Week
        {
            Sunday = 0,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Other
        }

        public Date(int year, int month, int day, Week week)
        {
            Year = year;
            Month = month;
            Day = day;
            this.week = week;
        }
    }
}

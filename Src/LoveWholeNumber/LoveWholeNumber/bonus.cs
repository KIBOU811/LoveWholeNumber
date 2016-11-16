﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveWholeNumber
{
    class bonus
    {
        /// <summary>
        /// ツェラーの公式を用いたA.D.4以降の曜日取得
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="isISO8601">返り値をISO8601で返すか</param>
        /// <returns>曜日を表す数字</returns>
        public static int GetDayOfTheWeek(int year, int month, int day, bool isISO8601)
        {
            if (year < 4)
                return -1;

            int g;
            int c = (int) Math.Floor((double) year);

            if (year < 1582 || (year == 1582 && (month < 10 || (month == 10 && day <= 4))))
            {

                g = -1 * c + 5;
            }
            else
            {
                g = -2 * c + (int) Math.Floor((double)c / 4);
            }

            int y = year % 100;

            if (isISO8601)
            {
                return (day + (int) Math.Floor((double) 26 * (month + 1) / 10) + y + (int) Math.Floor((double) y / 4) +
                        g + 5) % 7 + 1;
            }

            return (day + (int) Math.Floor((double) 26 * (month + 1) / 10) + y + (int) Math.Floor((double) y / 4) +
                        g) % 7;
        }
    }
}

using System;

namespace LoveWholeNumber
{
    class Bonus
    {
        /// <summary>
        /// ツェラーの公式を用いたA.D.4以降の曜日取得
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="isIso8601">返り値をISO8601で返すか</param>
        /// <returns>曜日を表す数字 失敗なら-1</returns>
        public static int GetDayOfTheWeek(int year, int month, int day, bool isIso8601)
        {
            if (year < 4)
                return -1;

            int g;
            int c = (int) Math.Floor((double) year / 100);

            if (year < 1582 || (year == 1582 && (month < 10 || (month == 10 && day <= 4))))
            {

                g = -1 * c + 5;
            }
            else
            {
                g = -2 * c + (int) Math.Floor((double)c / 4);
            }

            int yr = year % 100;

            if (isIso8601)
            {
                return (day + (int) Math.Floor((double) 26 * (month + 1) / 10) + yr + (int) Math.Floor((double) yr / 4) +
                        g + 5) % 7 + 1;
            }

            return (day + (int) Math.Floor((double) 26 * (month + 1) / 10) + yr + (int) Math.Floor((double) yr / 4) +
                        g) % 7;
        }

        /// <summary>
        /// グレゴリオ暦での曜日取得
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="isIso8601">返り値をISO8601で返すか</param>
        /// <returns>曜日を表す数字</returns>
        public static int GetDayWeekByGregorian(int year, int month, int day, bool isIso8601)
        {
            if (year < 1)
                year--;

            int c = (int) Math.Floor((double) year / 100);
            int g = -2 * c + (int) Math.Floor((double) c / 4);

            int yr = year % 100;

            if (isIso8601)
            {
                return (day + (int) Math.Floor((double) 26 * (month + 1) / 10) + yr + (int) Math.Floor((double) yr / 4) +
                        g + 5) % 7 + 1;
            }

            return (day + (int) Math.Floor((double) 26 * (month + 1) / 10) + yr + (int) Math.Floor((double) yr / 4) +
                    g) % 7;
        }

        /// <summary>
        /// ユリウス暦での曜日取得
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="isIso8601">返り値をISO8601で返すか</param>
        /// <returns>曜日を表す数字</returns>
        public static int GetDayWeekByJulian(int year, int month, int day, bool isIso8601)
        {
            if (year < 1)
                year--;

            int c = (int) Math.Floor((double) year / 100);
            int g = -1 * c + 5;

            int yr = year % 100;

            if (isIso8601)
            {
                return (day + (int) Math.Floor((double) 26 * (month + 1) / 10) + yr + (int) Math.Floor((double) yr / 4) +
                        g + 5) % 7 + 1;
            }

            return (day + (int) Math.Floor((double) 26 * (month + 1) / 10) + yr + (int) Math.Floor((double) yr / 4) +
                    g) % 7;
        }
    }
}

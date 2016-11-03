using System.Linq;
using System.Collections.Generic;

namespace LoveWholeNumber
{
    public class WholeNumberGroup
    {
        /// <summary>
        /// 回文数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>回文数ならtrue でないならfalse</returns>
        public static bool IsPalindromicNumber(int n)
        {
            if (n < 0)
                return false;

            int reversal = int.Parse(new string(n.ToString().ToCharArray().Reverse().ToArray()));

            if (reversal == n)
                return true;

            return false;
        }

        /// <summary>
        /// メルセンヌ数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>メルセンヌ数ならtrue でないならfalse</returns>
        public static bool IsMersenneNumber(int n)
        {
            if (n == 2147483647)
                return true;

            if (n < 0)
                return false;

            for (int i = 1; i < 31; i++)
            {
                int checkNum = 1;
                for (int j = 0; j < i; j++)
                {
                    checkNum *= 2;
                }
                if (checkNum == n)
                    return true;

                if (checkNum > n)
                    return false;
            }

            return false;
        }

        /// <summary>
        /// カレン数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>カレン数ならtrue でないならfalse</returns>
        public static bool IsCullenNumber(int n)
        {
            if (n < 0)
                return false;

            for (int i = 1; i < 27; i++)
            {
                int checkNum = i;
                for (int j = 0; j < i; j++)
                {
                    checkNum *= 2;
                }
                checkNum += 1;

                if (checkNum == n)
                    return true;

                if (checkNum > n)
                    return false;
            }

            return false;
        }

        /// <summary>
        /// ウッダル数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ウッダル数ならtrue でないならfalse</returns>
        public static bool IsWoodallNumber(int n)
        {
            if (n < 0)
                return false;

            for (int i = 1; i < 27; i++)
            {
                int checkNum = i;
                for (int j = 0; j < i; j++)
                {
                    checkNum *= 2;
                }
                checkNum -= 1;

                if (checkNum == n)
                    return true;

                if (checkNum > n)
                    return false;
            }

            return false;
        }

        /// <summary>
        /// 約数の列挙
        /// </summary>
        /// <param name="n">約数を列挙したい自然数</param>
        /// <returns>列挙された約数のint型List</returns>
        public static List<int> ListUpDivisor(int n)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    divisors.Add(i);
            }
            return divisors;
        }

        /// <summary>
        /// 約数の数
        /// </summary>
        /// <param name="n">約数の数を求めたい自然数</param>
        /// <returns>約数の数</returns>
        public static int CountOfDivisor(int n)
        {
            return ListUpDivisor(n).Count;
        }

        /// <summary>
        /// 約数関数
        /// </summary>
        /// <param name="n">自然数</param>
        /// <param name="x">乗数 0で約数の個数 1で約数の総和</param>
        /// <returns>総和</returns>
        public static int DivisorFunction(int n, int x)
        {
            int sum = new int();
            List<int> divisors = ListUpDivisor(n);

            foreach (int d in divisors)
                sum += d ^ x;

            return sum;
        }

        /// <summary>
        /// フィボナッチ数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>フィボナッチ数ならtrue でないならfalse</returns>
        public static bool IsFibonacciNumber(int n)
        {
            if (n < 0)
                return false;

            int f0 = 0;
            int f1 = 1;

            if (n == f0 || n == f1)
                return true;

            while (f1 < n)
            {
                int f2 = f0 + f1;

                if (f2 == n)
                    return true;

                f0 = f1;
                f1 = f2;
            }
            return false;
        }

        /// <summary>
        /// ハッピー関数
        /// </summary>
        /// <param name="n">引数</param>
        /// <returns>各桁の平方数の和</returns>
        public static int HappyFunction(int n)
        {
            int length = n.ToString("D").Length;
            List<int> digitList = new List<int>();

            for (int i = 0; i < length; i++)
            {
                digitList.Add(n % 10);
                n /= 10;
            }

            int result = 0;

            foreach (var i in digitList)
            {
                result += i * i;
            }

            return result;
        }

        /// <summary>
        /// ハッピー数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ハッピー数ならtrue でないならfalse</returns>
        public static bool IsHappyNumber(int n)
        {
            while (n.ToString("D").Length != 1)
            {
                HappyFunction(n);
            }

            if (n == 1)
                return true;

            return false;
        }
    }
}

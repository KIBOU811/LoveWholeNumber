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
        /// <returns>総和 引数nが1未満で0</returns>
        public static int DivisorFunction(int n, int x)
        {
            if (n < 1)
                return 0;

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
        /// <param name="n">自然数の引数</param>
        /// <returns>各桁の平方数の和 失敗で-1</returns>
        public static int HappyFunction(int n)
        {
            if (n < 1)
                return -1;

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
            if (n < 1)
                return false;

            while (n.ToString("D").Length != 1)
            {
                HappyFunction(n);
            }

            if (n == 1)
                return true;

            return false;
        }

        /// <summary>
        /// 幸運数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>幸運数ならtrue でないならfalse</returns>
        public static bool IsLuckyNumber(int n)
        {
            if (n < 1)
                return false;

            if (n == 1)
                return true;

            List<bool> isLuckyList = new List<bool>();

            for (int i = 0; i < n; i++)
            {
                isLuckyList.Add(true);
            }

            int multiple = 2;

            while (isLuckyList[n - 1])
            {
                for (int i = 0; i < isLuckyList.Count; i++)
                {
                    if ((i + 1) % multiple == 0)
                        isLuckyList[i] = false;
                }

                for (int i = multiple; i < n; i++)
                {
                    if (isLuckyList[i])
                    {
                        if (i == n - 1)
                            return true;

                        multiple = i + 1;
                        break;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 約数の総和から元の数を引いた数を返す
        /// </summary>
        /// <param name="n">元の自然数</param>
        /// <returns>約数の総和から元の数を引いた数 0以下は0</returns>
        private static int SumOfDivisorMinusN(int n)
        {
            List<int> divisorList = ListUpDivisor(n);

            int sum = new int();

            foreach (var d in divisorList)
            {
                if (d == n)
                    break;

                sum += d;
            }

            return sum;
        }

        /// <summary>
        /// 完全数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>完全数ならtrue でないならfalse</returns>
        public static bool IsPerfectNumber(int n)
        {
            int sum = SumOfDivisorMinusN(n);

            if (sum == n)
                return true;

            return false;
        }

        /// <summary>
        /// 過剰数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>過剰数ならtrue でないならfalse</returns>
        public static bool IsAbundantNumber(int n)
        {
            int sum = SumOfDivisorMinusN(n);

            if (sum > n)
                return true;

            return false;
        }

        /// <summary>
        /// 不足数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>不足数ならtrue でないならfalse</returns>
        public static bool IsDeficientNumber(int n)
        {
            int sum = SumOfDivisorMinusN(n);

            if (sum == 0)
                return false;

            if (sum < n)
                return true;

            return false;
        }

        /// <summary>
        /// 準完全数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>準完全数ならtrue でないならfalse</returns>
        public static bool IsQuasiperfectNumber(int n)
        {
            int sum = SumOfDivisorMinusN(n);

            if (sum == n + 1)
                return true;

            return false;
        }

        /// <summary>
        /// 概完全数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>概完全数ならtrue でないならfalse</returns>
        public static bool IsAlmostPerfectNumber(int n)
        {
            int sum = SumOfDivisorMinusN(n);

            if (sum == n - 1)
                return true;

            return false;
        }

        /// <summary>
        /// 乗法的完全数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>乗法的完全数ならtrue でないまたは引数が46340よりも大きいならfalse</returns>
        public static bool IsMultiplicativePerfectNumber(int n)
        {
            if (n > 46340 || n < 1)
                return false;

            List<int> divisorList = ListUpDivisor(n);

            int product = 1;

            foreach (var d in divisorList)
            {
                product *= d;
            }

            if (product == n * n)
                return true;

            return false;
        }
    }
}

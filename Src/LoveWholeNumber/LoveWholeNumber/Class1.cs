using System;
using System.Linq;
using System.Collections.Generic;

namespace LoveWholeNumber
{
    public class WholeNumberGroup
    {
        /// <summary>
        /// 素因数分解の辞書
        /// </summary>
        /// <param name="n">素因数分解したい自然数</param>
        /// <returns>素因数がkeyその冪指数がvalue 失敗で空のDictionary</returns>
        public static Dictionary<int, int> GetPrimeFactorDictionary(int n)
        {
            Dictionary<int, int> primeFactorDic = new Dictionary<int, int>();

            if (n < 1)
                return primeFactorDic;

            bool isExist = false;
            int def = n;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                int count = new int();
                while (n % i == 0)
                {
                    isExist = true;
                    count++;
                    n /= i;
                }
                if (count != 0)
                    primeFactorDic.Add(i, count);
            }

            if (!isExist)
                primeFactorDic.Add(def, 1);

            return primeFactorDic;
        }

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
            if (n == int.MaxValue)
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

            List<int> digitList = ListUpDigitNum(n);

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

        /// <summary>
        /// 友愛数判定
        /// </summary>
        /// <param name="m">判定したい自然数</param>
        /// <param name="n">判定したい自然数</param>
        /// <returns>友愛数ならtrue でないならfalse</returns>
        public static bool IsAmicablePair(int m, int n)
        {
            if (m == n)
                return false;

            if (SumOfDivisorMinusN(m) == SumOfDivisorMinusN(n) && m > 1)
                return true;

            return false;
        }

        /// <summary>
        /// 社交数判定
        /// </summary>
        /// <param name="l">判定したい自然数</param>
        /// <param name="m">判定したい自然数</param>
        /// <param name="n">判定したい自然数</param>
        /// <returns>社交数ならtrue でないならfalse</returns>
        public static bool IsSociableNumbers(int l, int m, int n)
        {
            if (l == m || m == n || n == l)
                return false;

            n = SumOfDivisorMinusN(n);

            if (l > 1
                && SumOfDivisorMinusN(l) == n
                && SumOfDivisorMinusN(m) == n)
                return true;

            return false;
        }

        /// <summary>
        /// 婚約数判定
        /// </summary>
        /// <param name="m">判定したい自然数</param>
        /// <param name="n">判定したい自然数</param>
        /// <returns>婚約数ならtrue でないならfalse</returns>
        public static bool IsBetrothedNumbers(int m, int n)
        {
            if (m == n)
                return false;

            if (m > 1
                && SumOfDivisorMinusN(m) - 1 == n
                && SumOfDivisorMinusN(n) - 1 == m)
                return true;

            return false;
        }

        /// <summary>
        /// 倍積完全数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>倍積完全数ならtrue でないならfalse</returns>
        public static bool IsMultiperfectNumber(int n)
        {
            if (n < 1)
                return false;

            if (DivisorFunction(n, 1) % n == 0)
                return true;

            return false;
        }

        /// <summary>
        /// ハイパー完全数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ハイパー完全数ならtrue でないならfalse</returns>
        public static bool IsHyperPerfectNumber(int n)
        {
            if (n < 1)
                return false;

            if ((n - 1) % (SumOfDivisorMinusN(n) - 1) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// サブライム数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>サブライム数ならtrue でないならfalse</returns>
        public static bool IsSublimeNumber(int n)
        {
            if (n < 1)
                return false;

            int count = DivisorFunction(n, 0);
            int sum = DivisorFunction(n, 1);

            if (IsPerfectNumber(count) && IsPerfectNumber(sum) && count != sum)
                return true;

            return false;
        }

        /// <summary>
        /// 最大公約数の取得
        /// </summary>
        /// <param name="m">整数m</param>
        /// <param name="n">整数n</param>
        /// <returns>最大公約数</returns>
        public static int GetGreatestCommonDivisor(int m, int n)
        {
            if (m < 0)
                m *= -1;

            if (n < 0)
                n *= -1;

            if (m < n)
            {
                int tmp = m;
                m = n;
                n = tmp;
            }

            if (n == 0)
                return m;

            int r = m % n;

            while (r != 0)
            {
                m = n;
                n = r;
                r = m % n;
            }

            return n;
        }

        /// <summary>
        /// 最小公倍数の取得
        /// </summary>
        /// <param name="m">整数m</param>
        /// <param name="n">整数n</param>
        /// <returns>最小公倍数</returns>
        public static int GetLeastCommonMultiple(int m, int n)
        {
            return m * n / GetGreatestCommonDivisor(m, n);
        }

        /// <summary>
        /// 互いに素判定
        /// </summary>
        /// <param name="m">整数m</param>
        /// <param name="n">整数n</param>
        /// <returns>互いに素ならtrue でないならfalse</returns>
        public static bool IsCoprime(int m, int n)
        {
            if (GetGreatestCommonDivisor(m, n) == 1)
                return true;

            return false;
        }

        /// <summary>
        /// 互いに素判定
        /// </summary>
        /// <param name="l">整数l</param>
        /// <param name="m">整数m</param>
        /// <param name="n">整数n</param>
        /// <returns>互いに素ならtrue でないならfalse</returns>
        public static bool IsCoprime(int l, int m, int n)
        {
            if (GetGreatestCommonDivisor(GetGreatestCommonDivisor(l, m), n) == 1)
                return true;

            return false;
        }

        /// <summary>
        /// 対ごとに素判定
        /// </summary>
        /// <param name="l">整数l</param>
        /// <param name="m">整数m</param>
        /// <param name="n">整数n</param>
        /// <returns>対ごとに素ならtrue でないならfalse</returns>
        public static bool IsPairwiseCoprime(int l, int m, int n)
        {
            if (GetGreatestCommonDivisor(l, m) == 1
                && GetGreatestCommonDivisor(m, n) == 1
                && GetGreatestCommonDivisor(n, l) == 1)
                return true;

            return false;
        }

        /// <summary>
        /// オイラーのφ関数
        /// </summary>
        /// <param name="n">正の整数</param>
        /// <returns>1からnまでの互いに素の数 nが0以下なら-1</returns>
        public static int EulerFunction(int n)
        {
            if (n < 1)
                return -1;

            int count = new int();
            for (int i = 1; i < n; i++)
            {
                if (IsCoprime(i, n))
                    count++;
            }
            return count;
        }

        /// <summary>
        /// 完全トーティエント数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>完全トーティエント数ならtrue でないならfalse</returns>
        public static bool IsPerfectTotientNumber(int n)
        {
            if (n < 1)
                return false;

            int sum = new int();

            while (n!=1)
            {
                n = EulerFunction(n);
                sum += n;
            }

            if (sum == n)
                return true;

            return false;
        }

        /// <summary>
        /// 楔数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>楔数ならtrue でないならfalse</returns>
        public static bool IsSphenicNumber(int n)
        {
            if (n < 1)
                return false;

            List<int> divisorList = ListUpDivisor(n);

            if (divisorList.Count != 8)
                return false;
            
            int count = new int();

            foreach (int d in divisorList)
            {
                if (Prime.IsPrime(d))
                    count++;
            }

            if (count != 3)
                return false;

            return true;
        }

        /// <summary>
        /// 合成数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>合成数ならtrue でないならfalse</returns>
        public static bool CompositeNumber(int n)
        {
            if (n < 1)
                return false;

            if (!Prime.IsPrime(n))
                return true;

            return false;
        }

        /// <summary>
        /// 高度合成数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>高度合成数ならtrue でないならfalse</returns>
        public static bool IsHighlyCompositeNumber(int n)
        {
            if (n < 1)
                return false;

            int divisorCount = DivisorFunction(n, 0);

            for (int i = 1; i < n; i++)
            {
                if (divisorCount <= DivisorFunction(i, 0))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 自己同形数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>自己同形数ならtrue でないならfalse</returns>
        public static bool IsAutomorphicNumber(int n)
        {
            if (n < 1 || n > 46340)
                return false;

            int num = n * n - n;

            if (n % (int)Math.Pow(10, unchecked((int) Math.Log10(num)) + 1) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// 桁ごとに数を列挙
        /// </summary>
        /// <param name="n">列挙したい自然数</param>
        /// <returns>桁ごとの数のリスト 失敗で空のリスト</returns>
        public static List<int> ListUpDigitNum(int n)
        {
            List<int> digitList = new List<int>();

            if (n < -1)
                return digitList;

            int divNum = 1;
            while (n / divNum != 0)
            {
                n /= divNum;
                digitList.Add(n % 10);
                divNum *= 10;
            }

            return digitList;
        }

        /// <summary>
        /// 数字和の取得
        /// </summary>
        /// <param name="n">自然数</param>
        /// <returns>桁の総和 失敗で-1</returns>
        public static int GetDigitSum(int n)
        {
            if (n < 1)
                return -1;
            
            int sum = new int();
            int divNum = 1;
            while (n / divNum != 0)
            {
                n /= divNum;
                sum += n % 10;
                divNum *= 10;
            }

            return sum;
        }

        /// <summary>
        /// ズッカーマン数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ズッカーマン数ならtrue でないならfalse</returns>
        public static bool IsZuckermanNumber(int n)
        {
            if (n < 1)
                return false;

            List<int> digitList = ListUpDigitNum(n);

            if (digitList.Contains(0))
                return false;

            int product = 1;
            foreach (int d in digitList)
            {
                product *= d;
            }

            if (ListUpDivisor(n).Contains(product))
                return true;

            return false;
        }

        /// <summary>
        /// スミス数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>スミス数ならtrue でないならfalse</returns>
        public static bool IsSmithNumber(int n)
        {
            if (n < 1)
                return false;

            var primeFactorDic = GetPrimeFactorDictionary(n);

            int sum = new int();
            foreach (KeyValuePair<int, int> p in primeFactorDic)
            {
                for (int i = 0; i < p.Value; i++)
                {
                    sum += GetDigitSum(p.Value);
                }
            }

            if (sum == GetDigitSum(n))
                return true;

            return false;
        }

        /// <summary>
        /// 単偶数判定
        /// </summary>
        /// <param name="n">判定したい整数</param>
        /// <returns>単偶数ならtrue でないならfalse</returns>
        public static bool IsSinglyEvenNumber(int n)
        {
            if ((n - 2) % 4 == 0)
                return true;

            return false;
        }

        /// <summary>
        /// ナルシシスト数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ナルシシスト数ならtrue でないならfalse</returns>
        public static bool IsNarcissisticNumber(int n)
        {
            if (n < 1)
                return false;

            List<int> digitList = ListUpDigitNum(n);
            int sum = new int();
            int length = unchecked((int) Math.Log10(n)) + 1;

            foreach (var d in digitList)
            {
                sum += (int)Math.Pow(d, length);
            }

            if (sum == n)
                return true;

            return false;
        }

        /// <summary>
        /// 平方数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>平方数ならtrue でないならfalse 引数が46341以上でもfalse</returns>
        public static bool IsSquareNumber(int n)
        {
            if (n < 1 || n > 46340)
                return false;

            for (int i = 1; i <= 46340; i++)
            {
                int square = (int) Math.Pow(i, 2);

                if (square > n)
                    return false;

                if (square == n)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 立方数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>立方数ならtrue でないならfalse 引数が1241以上でもfalse</returns>
        public static bool IsCubicNumber(int n)
        {
            if (n < 1 || n > 1240)
                return false;

            for (int i = 1; i <= 1240; i++)
            {
                int cubic = (int) Math.Pow(i, 3);

                if (cubic > n)
                    return false;

                if (cubic == n)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 四乗数・二重平方数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>四乗数・二重平方数ならtrue でないならfalse 引数が216以上でもfalse</returns>
        public static bool IsBiquadraticNumber(int n)
        {
            if (n < 1 || n > 215)
                return false;

            for (int i = 1; i <= 215; i++)
            {
                int biquadratic = (int) Math.Pow(i, 4);

                if (biquadratic > n)
                    return false;

                if (biquadratic == n)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 2の冪判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>2の冪ならtrue でないならfalse</returns>
        public static bool IsPowerOfTwo(int n)
        {
            if (n < 1 || n % 2 != 0)
                return false;

            for (int i = 0; i < 31; i++)
            {
                int product = (int) Math.Pow(2, i);

                if (product > n)
                    return false;

                if (product == n)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 平方因子をもたない整数判定
        /// </summary>
        /// <param name="n">判定したい整数</param>
        /// <returns>平方因子をもたない整数ならtrue でないならfalse</returns>
        public static bool IsSquareFreeInteger(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % (int) Math.Pow(i, 2) == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// ハーシャッド数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ハーシャッド数ならtrue でないならfalse</returns>
        public static bool IsHarshadNumber(int n)
        {
            if (n < 1)
                return false;

            if (n % GetDigitSum(n) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// 三角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>三角数ならtrue でないならfalse</returns>
        public static bool IsTriangularNumber(int n)
        {
            if (n < 1)
                return false;
            
            int toN = new int();

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += i;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }

        /// <summary>
        /// 五角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>五角数ならtrue でないならfalse</returns>
        public static bool IsPentagonalNumber(int n)
        {
            if (n < 1)
                return false;

            int toN = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += 3 * i + 1;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }

        /// <summary>
        /// 六角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>六角数ならtrue でないならfalse</returns>
        public static bool IsHexagonalNumber(int n)
        {
            if (n < 1)
                return false;

            int toN = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += 4 * i + 1;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }

        /// <summary>
        /// 七角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>七角数ならtrue でないならfalse</returns>
        public static bool IsHeptagonalNumber(int n)
        {
            if (n < 1)
                return false;

            int toN = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += 5 * i + 1;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }

        /// <summary>
        /// 八角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>八角数ならtrue でないならfalse</returns>
        public static bool IsOctagonalNumber(int n)
        {
            if (n < 1)
                return false;

            int toN = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += 6 * i + 1;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }
    }
}

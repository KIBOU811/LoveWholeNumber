using System;
using System.Linq;
using System.Collections.Generic;

namespace LoveWholeNumber
{
    public class WholeNumberClass
    {
        /// <summary>
        /// 素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>素数ならtrue でないならfalse</returns>
        public static bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
                return true;

            if (n % 2 == 0 || n < 2)
                return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 何番目の素数か判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>何番目かを返す 素数でない場合は-1</returns>
        public static int NumOfPrime(int n)
        {
            if (n == 2 || n == 3)
                return n - 1;

            if (n % 2 == 0 || n < 2)
                return -1;

            int count = 2;
            for (int i = 3; i <= n; i += 2)
            {
                int j;
                for (j = 3; j <= Math.Sqrt(i); j += 2)
                {
                    if (i % j== 0)
                        break;
                }
                if (i % j != 0)
                {
                    count++;
                    if (n == i)
                        return count;
                }
            }
            return -1;
        }

        /// <summary>
        /// 双子素数判定(p, p + 2のうちpであるか判定)
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>双子素数の一部ならtrue でないならfalse</returns>
        public static bool IsTwinPrime(int n)
        {
            if (!IsPrime(n))
                return false;

            int high = n + 2;

            if (IsPrime(high))
                return true;
            
            return false;
        }

        /// <summary>
        /// 双子素数のペア判定
        /// </summary>
        /// <param name="p">小さいほうの数字</param>
        /// <param name="p2">大きいほうの数字</param>
        /// <returns>双子素数ならtrue でないならfalse</returns>
        public static bool IsTwinPrimePair(int p, int p2)
        {
            if (p2 - p != 2)
                return false;

            if (IsPrime(p) && IsPrime(p2))
                return true;

            return false;
        }

        /// <summary>
        /// いとこ素数判定(p, p + 4のうちpであるか判定)
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>いとこ素数の一部ならtrue でないならfalse</returns>
        public static bool IsCousinPrime(int n)
        {
            if (!IsPrime(n))
                return false;

            int high = n + 4;

            if (IsPrime(high))
                return true;

            return false;
        }

        /// <summary>
        /// いとこ素数のペア判定
        /// </summary>
        /// <param name="p">小さいほうの数字</param>
        /// <param name="p4">大きいほうの数字</param>
        /// <returns>いとこ素数ならtrue でないならfalse</returns>
        public static bool IsCousinPrimePair(int p, int p4)
        {
            if (p4 - p != 4)
                return false;

            if (IsPrime(p) && IsPrime(p4))
                return true;

            return false;
        }

        /// <summary>
        /// セクシー素数判定(p, p + 6のうちpであるか判定)
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>セクシー素数の一部ならtrue でないならfalse</returns>
        public static bool IsSexyPrime(int n)
        {
            if (!IsPrime(n))
                return false;

            int high = n + 6;

            if (IsPrime(high))
                return true;

            return false;
        }

        /// <summary>
        /// セクシー素数のペア判定
        /// </summary>
        /// <param name="p">小さいほうの数字</param>
        /// <param name="p6">大きいほうの数字</param>
        /// <returns>セクシー素数ならtrue でないならfalse</returns>
        public static bool IsSexyPrimePair(int p, int p6)
        {
            if (p6 - p != 6)
                return false;

            if (IsPrime(p) && IsPrime(p6))
                return true;

            return false;
        }

        public static bool IsPrimeTriplet(int n)
        {
            if (IsPrime(n))
                return false;

            int n2 = n + 2;
            int n4 = n + 4;
            int n6 = n + 6;

            if (IsSexyPrimePair(n, n6) && (IsTwinPrimePair(n, n4) || IsCousinPrimePair(n, n6)))
                return true;

            return false;
        }

        public static bool IsPrimeTripletTrio(int p, int mid, int p6)
        {
            if (!IsPrime(p) || !IsPrime(mid) || !IsPrime(p6) || p6 - p != 6)
                return false;
            
            if (IsPrimeTriplet(p) && (IsTwinPrimePair(mid, p6) || IsCousinPrimePair(mid, p6)))
                return true;

            return false;
        }
        
        public static bool IsPrimeQuadruplet(int n)
        {
            if (IsPrime(n))
                return false;

            int n2 = n + 2;
            int n6 = n + 6;
            int n8 = n + 8;

            if (IsPrime(n2) && IsPrime(n6) && IsPrime(n8))
                return true;

            return false;
        }

        /// <summary>
        /// 回文数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
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
        /// 回文素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>回文素数ならtrue でないならfalse</returns>
        public static bool IsPalindromicPrime(int n)
        {
            if (IsPalindromicNumber(n) && IsPrime(n))
                return true;

            return false;
        }

        /// <summary>
        /// エマープ判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>エマープならtrue でないならfalse</returns>
        public static bool IsEmirp(int n)
        {
            if (n < 0)
                return false;

            int reversal = int.Parse(new string(n.ToString().ToCharArray().Reverse().ToArray()));
            
            if(!IsPalindromicNumber(n)&&IsPrime(reversal))
                return true;

            return false;
        }

        /// <summary>
        /// オイラー素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>オイラー素数ならtrue でないならfalse</returns>
        public static bool IsEularPrimeNumber(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int compNum = i ^ 2 + i + 41;

                if (compNum == n && IsPrime(compNum))
                    return true;

                if (compNum > n)
                    break;
            }

            return false;
        }

        /// <summary>
        /// スーパー素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>スーパー素数ならtrue でないならfalse</returns>
        public static bool IsSuperPrime(int n)
        {
            if (IsPrime(n) && IsPrime(NumOfPrime(n)))
                return true;

            return false;
        }

        /// <summary>
        /// メルセンヌ数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
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
        /// メルセンヌ素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>メルセンヌ素数ならtrue でないならfalse</returns>
        public static bool IsMersennePrime(int n)
        {
            if (IsPrime(n) && IsMersenneNumber(n))
                return true;

            return false;
        }

        /// <summary>
        /// ソフィー・ジェルマン素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>ソフィー・ジェルマン素数ならtrue でないならfalse</returns>
        public static bool IsSophieGermainPrime(int n)
        {
            if (IsPrime(n) && IsPrime(2 * n + 1))
                return true;

            return false;
        }

        /// <summary>
        /// 安全素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>安全素数ならtrue でないならfalse</returns>
        public static bool IsSafePrime(int n)
        {
            if (n % 2 == 0)
                return false;

            if (IsPrime(n) && IsPrime((n - 1) / 2))
                return true;

            return false;
        }

        /// <summary>
        /// カレン数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
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
        /// カレン素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>カレン素数ならtrue でないならfalse</returns>
        public static bool IsCullenPrime(int n)
        {
            if (IsPrime(n) && IsCullenNumber(n))
                return true;

            return false;
        }

        /// <summary>
        /// ウッダル数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
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
        /// ウッダル素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>ウッダル素数ならtrue でないならfalse</returns>
        public static bool IsWoodallPrime(int n)
        {
            if (IsPrime(n) && IsWoodallNumber(n))
                return true;

            return false;
        }

        /// <summary>
        /// 奇素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>奇素数ならtrue でないならfalse</returns>
        public static bool IsOddPrime(int n)
        {
            if (IsPrime(n) && n != 2)
                return true;

            return false;
        }

        /// <summary>
        /// 偶素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>偶素数ならtrue でないならfalse</returns>
        public static bool IsEvenPrime(int n)
        {
            if(IsPrime(n)&&n==2)
                return true;

            return false;
        }

        /// <summary>
        /// 約数の列挙
        /// </summary>
        /// <param name="n">約数を列挙したい数字</param>
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
        /// <param name="n">約数の数を求めたい数字</param>
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
        /// <param name="n">判定したい数字</param>
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
        /// フィボナッチ素数判定
        /// </summary>
        /// <param name="n">判定したい数字</param>
        /// <returns>フィボナッチ素数ならtrue でないならfalse</returns>
        public static bool IsFibonacciPrime(int n)
        {
            if (IsPrime(n) && IsFibonacciNumber(n))
                return true;

            return false;
        }


    }
}

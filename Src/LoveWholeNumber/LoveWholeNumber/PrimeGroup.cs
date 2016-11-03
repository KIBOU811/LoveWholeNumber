using System;
using System.Linq;

namespace LoveWholeNumber
{
    class PrimeGroup
    {
        /// <summary>
        /// 素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
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
        /// <param name="n">判定したい自然数</param>
        /// <returns>何番目かを返す 素数でない場合は-1</returns>
        public static int GetNumOfPrime(int n)
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
                    if (i % j == 0)
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
        /// n番目の素数取得
        /// </summary>
        /// <param name="nth">n番目の素数</param>
        /// <returns>n番目の素数 失敗で-1</returns>
        public static int GetNthPrime(int nth)
        {
            if (nth == 1 || nth == 2)
                return nth + 1;

            if (nth > 105097564)
                return -1;

            int count = 2;

            for (int i = 3; i < 2147483647; i += 2)
            {
                if (IsPrime(i))
                {
                    count++;
                    if (count == nth)
                        return count;
                }
            }

            return -1;
        }

        /// <summary>
        /// 双子素数判定(p, p + 2のうちpであるか判定)
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>双子素数ならtrue でないならfalse</returns>
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
        /// <param name="p">最小の数</param>
        /// <param name="p2">最小の数 + 2</param>
        /// <returns>双子素数のペアならtrue でないならfalse</returns>
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
        /// <param name="n">判定したい自然数</param>
        /// <returns>いとこ素数ならtrue でないならfalse</returns>
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
        /// <param name="p">最小の数</param>
        /// <param name="p4">最小の数 + 4</param>
        /// <returns>いとこ素数のペアならtrue でないならfalse</returns>
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
        /// <param name="n">判定したい自然数</param>
        /// <returns>セクシー素数ならtrue でないならfalse</returns>
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
        /// <param name="p">最小の数</param>
        /// <param name="p6">最小の数 + 6</param>
        /// <returns>セクシー素数のペアならtrue でないならfalse</returns>
        public static bool IsSexyPrimePair(int p, int p6)
        {
            if (p6 - p != 6)
                return false;

            if (IsPrime(p) && IsPrime(p6))
                return true;

            return false;
        }

        /// <summary>
        /// 三つ子素数判定(p, p + 2, p + 6またはp, p + 4, p + 6のうちpであるか判定)
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>三つ子素数ならtrue でないならfalse</returns>
        public static bool IsPrimeTriplet(int n)
        {
            if (!IsPrime(n))
                return false;

            int n2 = n + 2;
            int n4 = n + 4;
            int n6 = n + 6;

            if ((IsPrime(n2) || IsPrime(n4)) && IsPrime(n6))
                return true;

            return false;
        }

        /// <summary>
        /// 三つ子素数のトリオ判定
        /// </summary>
        /// <param name="p">最小の数</param>
        /// <param name="mid">最小の数 + 2 または 最小の数 + 4</param>
        /// <param name="p6">最小の数 + 6</param>
        /// <returns>三つ子素数のセットならtrue でないならfalse</returns>
        public static bool IsPrimeTripletTrio(int p, int mid, int p6)
        {
            if (IsPrimeTriplet(p) && (IsTwinPrimePair(mid, p6) || IsCousinPrimePair(mid, p6)))
                return true;

            return false;
        }

        /// <summary>
        /// 四つ子素数判定(p, p + 2, p + 6, p + 8のうちpであるか判定)
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>四つ子素数ならtrue でないならfalse</returns>
        public static bool IsPrimeQuadruplet(int n)
        {
            if (!IsPrime(n))
                return false;

            int n2 = n + 2;
            int n6 = n + 6;
            int n8 = n + 8;

            if (IsPrime(n2) && IsPrime(n6) && IsPrime(n8))
                return true;

            return false;
        }

        /// <summary>
        /// 四つ子素数のセット判定
        /// </summary>
        /// <param name="p">最小の数</param>
        /// <param name="p2">最小の数 + 2</param>
        /// <param name="p6">最小の数 + 6</param>
        /// <param name="p8">最小の数 + 8</param>
        /// <returns>四つ子素数のセットならtrue でないならfalse</returns>
        public static bool IsPrimeQuadrupletSet(int p, int p2, int p6, int p8)
        {
            if (IsPrimeQuadruplet(p) && IsTwinPrimePair(p, p2) && IsTwinPrimePair(p6, p8) && IsCousinPrimePair(p2, p6))
                return true;

            return false;
        }

        /// <summary>
        /// 五つ子素数判定(p, p + 2, p + 6, p + 8かつp - 4またはp + 12が素数のときpであるか判定)
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>五つ子素数ならtrue でないならfalse</returns>
        public static bool IsPrimeQuintuplet(int n)
        {
            if (IsPrimeQuadruplet(n) && (IsPrime(n - 4) || IsPrime(n + 12)))
                return true;

            return false;
        }

        /// <summary>
        /// 五つ子素数のセット判定
        /// </summary>
        /// <param name="p">ある数</param>
        /// <param name="p2">ある数 + 2</param>
        /// <param name="p6">ある数 + 6</param>
        /// <param name="p8">ある数 + 8</param>
        /// <param name="anotherP">ある数 - 4またはある数 + 12</param>
        /// <returns>五つ子素数のセットならtrue でないならfalse</returns>
        public static bool IsPrimeQuintupletSet(int p, int p2, int p6, int p8, int anotherP)
        {
            if (IsPrimeQuadrupletSet(p, p2, p6, p8) &&
                (IsCousinPrimePair(anotherP, p) || IsCousinPrimePair(p8, anotherP)))
                return true;

            return false;
        }

        /// <summary>
        /// 六つ子素数判定(p - 4, p, p + 2, p + 6, p + 8, p + 12のうちpであるか判定)
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>六つ子素数ならtrue でないならfalse</returns>
        public static bool IsPrimeSextuplet(int n)
        {
            if (IsPrimeQuadruplet(n) && IsPrime(n - 4) && IsPrime(n + 12))
                return true;

            return false;
        }

        /// <summary>
        /// 六つ子素数のセット判定
        /// </summary>
        /// <param name="p4">ある数 - 4</param>
        /// <param name="p">ある数</param>
        /// <param name="p2">ある数 + 2</param>
        /// <param name="p6">ある数 + 6</param>
        /// <param name="p8">ある数 + 8</param>
        /// <param name="p12">ある数 + 12</param>
        /// <returns>六つ子素数のセットならtrue でないならfalse</returns>
        public static bool IsPrimeSextupletSet(int p4, int p, int p2, int p6, int p8, int p12)
        {
            if (IsPrimeQuadrupletSet(p, p2, p6, p8) && IsCousinPrimePair(p4, p) && IsCousinPrimePair(p8, p12))
                return true;

            return false;
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
        /// 回文素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
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
        /// <param name="n">判定したい自然数</param>
        /// <returns>エマープならtrue でないならfalse</returns>
        public static bool IsEmirp(int n)
        {
            if (n < 0)
                return false;

            int reversal = int.Parse(new string(n.ToString().ToCharArray().Reverse().ToArray()));

            if (!IsPalindromicNumber(n) && IsPrime(reversal))
                return true;

            return false;
        }

        /// <summary>
        /// オイラー素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
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
        /// <param name="n">判定したい自然数</param>
        /// <returns>スーパー素数ならtrue でないならfalse</returns>
        public static bool IsSuperPrime(int n)
        {
            if (IsPrime(n) && IsPrime(GetNumOfPrime(n)))
                return true;

            return false;
        }

        /// <summary>
        /// メルセンヌ素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>メルセンヌ素数ならtrue でないならfalse</returns>
        public static bool IsMersennePrime(int n)
        {
            if (IsPrime(n) && WholeNumberClass.IsMersenneNumber(n))
                return true;

            return false;
        }

        /// <summary>
        /// ソフィー・ジェルマン素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
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
        /// <param name="n">判定したい自然数</param>
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
        /// ピタゴラス素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ピタゴラス素数ならtrue でないならfalse</returns>
        public static bool IsPythagoreanPrime(int n)
        {
            if (IsPrime(n) && (n - 1) % 4 == 0)
                return true;

            return false;
        }

        /// <summary>
        /// カレン素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>カレン素数ならtrue でないならfalse</returns>
        public static bool IsCullenPrime(int n)
        {
            if (IsPrime(n) && WholeNumberClass.IsCullenNumber(n))
                return true;

            return false;
        }

        /// <summary>
        /// ウッダル素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ウッダル素数ならtrue でないならfalse</returns>
        public static bool IsWoodallPrime(int n)
        {
            if (IsPrime(n) && WholeNumberClass.IsWoodallNumber(n))
                return true;

            return false;
        }

        /// <summary>
        /// 奇素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
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
        /// <param name="n">判定したい自然数</param>
        /// <returns>偶素数ならtrue でないならfalse</returns>
        public static bool IsEvenPrime(int n)
        {
            if (IsPrime(n) && n == 2)
                return true;

            return false;
        }

        /// <summary>
        /// フィボナッチ素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>フィボナッチ素数ならtrue でないならfalse</returns>
        public static bool IsFibonacciPrime(int n)
        {
            if (IsPrime(n) && WholeNumberClass.IsFibonacciNumber(n))
                return true;

            return false;
        }

        /// <summary>
        /// ハッピー素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>ハッピー素数ならtrue でないならfalse</returns>
        public static bool IsHappyPrime(int n)
        {
            if (IsPrime(n) && WholeNumberClass.IsHappyNumber(n))
                return true;

            return false;
        }

        /// <summary>
        /// 平衡素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>平衡素数ならtrue でないならfalse</returns>
        public static bool IsBalancedPrime(int n)
        {
            int numOfPrime = GetNumOfPrime(n);

            if (numOfPrime == -1)
                return false;

            if ((GetNthPrime(numOfPrime - 1) + GetNumOfPrime(numOfPrime + 1)) / 2 == n)
                return true;

            return false;
        }

        /// <summary>
        /// 強素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>強素数ならtrue でないならfalse</returns>
        public static bool IsStrongPrime(int n)
        {
            int numOfPrime = GetNumOfPrime(n);

            if (numOfPrime == -1)
                return false;

            if ((GetNthPrime(numOfPrime - 1) + GetNumOfPrime(numOfPrime + 1)) / 2 < n)
                return true;

            return false;
        }

        /// <summary>
        /// 弱素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>弱素数ならtrue でないならfalse</returns>
        public static bool IsWeekPrime(int n)
        {
            int numOfPrime = GetNumOfPrime(n);

            if (numOfPrime == -1)
                return false;

            if ((GetNthPrime(numOfPrime - 1) + GetNumOfPrime(numOfPrime + 1)) / 2 > n)
                return true;

            return false;
        }

        /// <summary>
        /// 半素数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>半素数ならtrue でないならfalse</returns>
        public static bool IsSemiprime(int n)
        {
            if (WholeNumberClass.CountOfDivisor(n) == 3 || WholeNumberClass.CountOfDivisor(n) == 4)
                return true;

            return false;
        }

        /// <summary>
        /// Left-truncatable prime判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>Left-truncatable primeならtrue でないならfalse</returns>
        public static bool IsLeftTruncatablePrime(int n)
        {
            if (!IsPrime(n))
                return false;

            string s = n.ToString();

            if (s.Contains("0"))
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (!IsPrime(int.Parse(s.Substring(i))))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Right-truncatable prime判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>Right-truncatable primeならtrue でないならfalse</returns>
        public static bool IsRightTruncatablePrime(int n)
        {
            if (!IsPrime(n))
                return false;

            while (true)
            {
                n /= 10;
                if (n == 0)
                    return true;

                if (!IsPrime(n))
                    return false;
            }
        }

        /// <summary>
        /// Two-sided prime判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>Two-sided primeならtrue でないならfalse</returns>
        public static bool IsTwoSidedPrime(int n)
        {
            if (IsLeftTruncatablePrime(n) && IsRightTruncatablePrime(n))
                return true;

            return false;
        }
    }
}

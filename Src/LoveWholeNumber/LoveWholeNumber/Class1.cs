using System;
using System.Linq;

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

        public static bool IsTwinPrime(int n)
        {
            int low = n - 2;
            int high = n + 2;

            if (IsPrime(n) && ((IsPrime(low) && !IsPrime(high)) || (!IsPrime(low) && IsPrime(high))))
                return true;
            
            return false;
        }

        public static bool IsCousinPrime(int n)
        {
            int low = n - 4;
            int high = n + 4;

            if (IsPrime(n) && ((IsPrime(low) && !IsPrime(high)) || (!IsPrime(low) && IsPrime(high))))
                return true;

            return false;
        }

        public static bool IsSexyPrime(int n)
        {
            int low = n - 6;
            int high = n + 6;

            if (IsPrime(n) && ((IsPrime(low) && !IsPrime(high)) || (!IsPrime(low) && IsPrime(high))))
                return true;

            return false;
        }

        public static bool IsPalindromicNumber(int n)
        {
            int reversal = int.Parse(new string(n.ToString().ToCharArray().Reverse().ToArray()));
            if (reversal == n)
                return true;

            return false;
        }
    }
}

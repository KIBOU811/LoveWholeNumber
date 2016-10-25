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
            if (n < 0)
                return false;

            int reversal = int.Parse(new string(n.ToString().ToCharArray().Reverse().ToArray()));

            if (reversal == n)
                return true;

            return false;
        }

        public static bool IsPalindromicPrime(int n)
        {
            if (IsPalindromicNumber(n) && IsPrime(n))
                return true;

            return false;
        }

        public static bool IsEmirp(int n)
        {
            if (n < 0)
                return false;

            int reversal = int.Parse(new string(n.ToString().ToCharArray().Reverse().ToArray()));
            
            if(!IsPalindromicNumber(n)&&IsPrime(reversal))
                return true;

            return false;
        }

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

        public static bool IsSuperPrime(int n)
        {
            if (IsPrime(n) && IsPrime(NumOfPrime(n)))
                return true;

            return false;
        }

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

        public static bool IsMersennePrime(int n)
        {
            if (IsMersenneNumber(n) && IsPrime(n))
                return true;

            return false;
        }

        public static bool IsSophieGermainPrime(int n)
        {
            if (IsPrime(n) && IsPrime(2 * n + 1))
                return true;

            return false;
        }

        public static bool IsSafePrime(int n)
        {
            if (n % 2 != 0)
                return false;

            if (IsPrime(n) && IsPrime((n - 1) / 2))
                return true;

            return false;
        }

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

        public static bool IsCullenPrime(int n)
        {
            if (IsCullenNumber(n) && IsPrime(n))
                return true;

            return false;
        }

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

        public static bool IsWoodallPrime(int n)
        {
            if (IsWoodallNumber(n) && IsPrime(n))
                return true;

            return false;
        }

        public static bool IsOddPrime(int n)
        {
            if (IsPrime(n) && n != 2)
                return true;

            return false;
        }

        public static bool IsEvenPrime(int n)
        {
            if(IsPrime(n)&&n==2)
                return true;

            return false;
        }

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

        public static int CountOfDivisor(int n)
        {
            return ListUpDivisor(n).Count;
        }





        public static int SumOfDivisors(List<int> Divisors)
        {
            int sum = 0;

            foreach (int d in Divisors)
                sum += d;

            return sum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoveWholeNumber
{
    public class WholeNumberClass
    {
        public static bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
                return true;

            if (n % 2 == 0)
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
    }
}

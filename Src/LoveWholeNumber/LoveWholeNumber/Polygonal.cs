namespace LoveWholeNumber
{
    class Polygonal
    {
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

        /// <summary>
        /// 九角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>九角数ならtrue でなならfalse</returns>
        public static bool IsNonagonalNumber(int n)
        {
            if (n < 1)
                return false;

            int toN = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += 7 * i + 1;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }

        /// <summary>
        /// 十角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>十角数ならtrue でないならfalse</returns>
        public static bool IsDecagonalNumber(int n)
        {
            if (n < 1)
                return false;

            int toN = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += 8 * i + 1;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }
    }
}

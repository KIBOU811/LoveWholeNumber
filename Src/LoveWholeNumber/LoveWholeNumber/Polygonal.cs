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

        /// <summary>
        /// 十一角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>十一角数ならtrue でないならfalse</returns>
        public static bool IsHendecagonalNumber(int n)
        {
            if (n < 1)
                return false;

            int toN = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += 9 * i + 1;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }

        /// <summary>
        /// 十二角数判定
        /// </summary>
        /// <param name="n">判定したい自然数</param>
        /// <returns>十二角数ならtrue でないならfalse</returns>
        public static bool IsDodecagonalNumber(int n)
        {
            if (n < 1)
                return false;

            int toN = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                toN += 10 * i + 1;

                if (toN == n)
                    return true;

                if (toN > n)
                    break;
            }

            return false;
        }

        /// <summary>
        /// 任意の序列の多角数取得
        /// </summary>
        /// <param name="nth">任意の序列</param>
        /// <param name="nSided">n角数のn</param>
        /// <returns>指定した序列の多角数 失敗で-1</returns>
        public static int GetNSidedNumber(int nth, int nSided)
        {
            if (nth < 1 || nSided < 3)
                return -1;

            return ((nSided - 2) * nth * nth - (4 - nSided) * nth) / 2;
        }
    }
}

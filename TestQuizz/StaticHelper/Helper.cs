using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestQuizz.StaticHelper
{
    public static class Helper
    {
        private static void exchange(int[] data, int m, int n)
        {
            int temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }
        /// <summary>
        /// Пузырьковая сортировка
        /// </summary>
        /// <param name="data"></param>
        public static void IntArrayBubbleSort(int[] data)
        {
            int i, j;
            int N = data.Length;

            for (j = N - 1; j > 0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (data[i] > data[i + 1])
                        exchange(data, i, i + 1);
                }
            }
        }
        /// <summary>
        /// Сортировка вставкой
        /// </summary>
        /// <param name="data"></param>
        public static void IntArrayInsertionSort(int[] data)
        {
            int i, j;
            int N = data.Length;

            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && data[i] < data[i - 1]; i--)
                {
                    exchange(data, i, i - 1);
                }
            }
        }
        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="data"></param>
        public static void IntArrayQuickSort(int[] data)
        {
            IntArrayQuickSort(data, 0, data.Length - 1);
        }
        private static void IntArrayQuickSort(int[] data, int l, int r)
        {
            int i, j;
            int x;

            i = l;
            j = r;

            x = data[(l + r) / 2]; /* find pivot item */
            while (true)
            {
                while (data[i] < x)
                    i++;
                while (x < data[j])
                    j--;
                if (i <= j)
                {
                    exchange(data, i, j);
                    i++;
                    j--;
                }
                if (i > j)
                    break;
            }
            if (l < j)
                IntArrayQuickSort(data, l, j);
            if (i < r)
                IntArrayQuickSort(data, i, r);
        }

        public static int SortAndCountArray(int[] data)
        {
            int countEven = 0;
            int countOdd = 0;

            //и вот как понимать, "отсортировать алгоритм любыми 3 способами" ?
            //мне массив опять рандомом забивать или так пойдёт?

            IntArrayQuickSort(data);
            IntArrayBubbleSort(data);
            IntArrayInsertionSort(data);

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] % 2 == 0)
                    countEven++;
                else
                    countOdd++;
            }
            return countEven;
        }

        public static int CreateAndMultiplyFibonacci(int count)
        {
            int[] series = new int[1];
            int result = 0;
            Array.Resize(ref series, count);

            series[0] = 0;
            series[1] = 1;

            for (int i = 2; i < count; i++)
                series[i] = series[i - 1] + series[i - 2];

            for (int i = 0; i < series.Length; i++)
            {
                if (series[i] % 2 == 0)
                    result += series[i];
            }

            return result;
        }

        public static string Reverse(string st)
        {
            char[] str = st.ToCharArray();

            int r = str.Length - 1, l = 0;

            while (l < r)
            {
                if (!char.IsLetter(str[l]))
                    l++;
                else if (!char.IsLetter(str[r]))
                    r--;
                else
                {
                    char tmp = str[l];
                    str[l] = str[r];
                    str[r] = tmp;
                    l++;
                    r--;
                }
            }

            return new string(str);
        }

    }
}

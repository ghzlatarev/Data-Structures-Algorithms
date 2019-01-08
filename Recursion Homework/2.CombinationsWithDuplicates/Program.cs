using System;

namespace _2.CombinationsWithRepetition
{
    class Program
    {
        private static int n = 3;
        private static int k = 2;
        private static int[] arr = new int[k];

        static void Main(string[] args)
        {
            Comb(0, 1);
        }
        static void Comb(int index, int from)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(", ", arr));
            }
            else
            {
                for (int i = from; i <= n; i++)
                {
                    arr[index] = i;
                    Comb(index + 1, i);
                }
            }
        }

    }
}

using System;
using System.Linq;

namespace Combinations
{
    class Program
    {
        private static int n;
        private static int k;
        private static int[] arr;

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = input[0];
            k = input[1];
            arr = new int[k];
            Comb(0, 1);
        }
        static void Comb(int index, int from)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = from; i <= n; i++)
                {
                    arr[index] = i;
                    Comb(index + 1, i + 1);
                }
            }
        }
    }
}

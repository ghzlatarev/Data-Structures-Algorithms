using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutations
{
    class Program
    {
        private static int n;
        private static int[] arr = new int[n];
        private static SortedSet<string> finalResult = new SortedSet<string>();

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            arr = Enumerable.Range(1, n).ToArray();
            Perm(0);
            foreach (var item in finalResult)
            {
                Console.WriteLine(item);
            }
        }
        static void Perm(int k)
        {
            if (k >= n)
                finalResult.Add(string.Join(" ", arr));
            else
            {
                Perm(k + 1);
                for (int i = k + 1; i < n; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Perm(k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T t1, ref T t2)
        {
            var oldValue = t1;
            t1 = t2;
            t2 = oldValue;
        }
    }
}

using System;
using System.Linq;

namespace _4.Permutations
{
    class Program
    {
        private static int n = 3;
        private static int[] arr = new int[n];

        static void Main(string[] args)
        {
            arr = Enumerable.Range(1, n).ToArray();
            Perm(0);
        }
        static void Perm(int k)
        {
            if (k >= n)
                Console.WriteLine(string.Join(", ", arr));
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

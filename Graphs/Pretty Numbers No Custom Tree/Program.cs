using System;
using System.Collections.Generic;
using System.Linq;

namespace Pretty_Numbers_No_Custom_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong P = ulong.Parse(Console.ReadLine());
            ulong[] sums = Console.ReadLine().Split().Select(ulong.Parse).ToArray();

            ulong maxSum = sums.Max();

            HashSet<ulong> set = new HashSet<ulong>();
            Queue<ulong> queue = new Queue<ulong>();

            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                ulong next = queue.Dequeue();
                set.Add(next);

                if (next * P <= maxSum)
                {
                    queue.Enqueue(next * P);
                    queue.Enqueue(next * P + 1);
                }
            }

            int[] results = new int[sums.Length];

            for (int i = 0; i < sums.Length; i++)
            {
                foreach (var item in set)
                {
                    ulong needed = sums[i] - item;
                    if (set.Contains(needed))
                    {
                        results[i]++;
                    }
                }
                results[i] /= 2;
            }

            for (int i = 0; i < results.Length; i++)
            {
                if (results[i] > 1)
                {
                    results[i] = 0;
                }
            }

            Console.WriteLine(string.Join(" ", results));
        }
    }
}
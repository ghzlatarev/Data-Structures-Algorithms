using System;
using System.Collections.Generic;
using System.Linq;

namespace Swappings
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(1, N).ToList();
            var anchors = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (int anchor in anchors)
            {
                int index = numbers.IndexOf(anchor);
                numbers.Insert(0, anchor);
                numbers.InsertRange(0, numbers.GetRange(index + 2, numbers.Count - index - 2));
                numbers.RemoveRange(N, numbers.Count - N);
            }

            Console.WriteLine(string.Join(" ", numbers));
            
        }
    }
}

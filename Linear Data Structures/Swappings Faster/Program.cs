using System;
using System.Collections.Generic;
using System.Linq;

namespace Swappings_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var q = new Queue<int>(Enumerable.Range(1, N));
            Console.ReadLine().Split()
                .Select(int.Parse)
                .ToList()
                .ForEach(num =>
                {
                    q.Enqueue(num);
                    int x;
                    while((x = q.Dequeue()) != num)
                    {
                        q.Enqueue(x);
                    }
                });
            Console.WriteLine(string.Join(" ", q));
        }
    }
}

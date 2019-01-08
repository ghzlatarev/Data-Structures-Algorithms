using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstFiftyMembersOfSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long n = input[0];
            long m  = input[1];

            Queue<long> queue = new Queue<long>();
            queue.Enqueue(n);

            for(int i = 1; i < m; i++)
            {
                if(i%3 == 1)
                {
                    queue.Enqueue(queue.Peek() + 1);
                }
                else if(i%3 == 2)
                {
                    queue.Enqueue(queue.Peek() * 2 + 1);
                }
                else
                {
                    queue.Enqueue(queue.Dequeue() + 2);
                }
            }

            Console.WriteLine(queue.Last());
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Plus_One_Multiple_One_Redo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int counter = 0;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                counter++;
                if(counter == m)
                {
                    Console.WriteLine(current);
                    return;
                }
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
        }
    }
}

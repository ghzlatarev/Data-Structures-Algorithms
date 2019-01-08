using System;
using System.Collections;
using System.Collections.Generic;

namespace Path_To_One_Redo
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Tuple<int, int> first = new Tuple<int, int>(N, 0);

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(first);

            while (queue.Count > 0)
            {
                Tuple<int, int> current = queue.Dequeue();
                if(current.Item1 == 1)
                {
                    Console.WriteLine(current.Item2);
                    break;
                }
                if(current.Item1%2 == 0)
                {
                    queue.Enqueue(new Tuple<int, int>(current.Item1 / 2, current.Item2 + 1));
                }
                else
                {
                    queue.Enqueue(new Tuple<int, int>(current.Item1 + 1, current.Item2 + 1));
                    queue.Enqueue(new Tuple<int, int>(current.Item1 - 1, current.Item2 + 1));
                }
            }
        }
    }
}

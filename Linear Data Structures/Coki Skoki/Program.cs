using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coki_Skoki
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var counts = new int[N];

            Stack<int> stack = new Stack<int>();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && list[stack.Peek()] <= list[i])
                {
                    int peekIndex = stack.Pop();
                    counts[peekIndex] = stack.Count();
                }
                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                int peekIndex = stack.Pop();
                counts[peekIndex] = stack.Count();
            }

            Console.WriteLine(counts.Max());
            Console.WriteLine(string.Join(" ", counts));

            //for (int i = 0; i < list.Count - 1; i++)
            //{
            //    int count = 0;
            //    int current = list[i];
            //    for (int k = i+1; k < list.Count; k++)
            //    {
            //        if(current < list[k])
            //        {
            //            count++;
            //            current = list[k];
            //        }
            //    }
            //    counts.Add(count);
            //}
            //  Console.WriteLine(counts.Max());
            //  Console.WriteLine(string.Join(" ", counts) + " 0");
        }
    }
}

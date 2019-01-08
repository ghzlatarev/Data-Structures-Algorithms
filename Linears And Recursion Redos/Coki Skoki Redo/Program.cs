using System;
using System.Collections.Generic;
using System.Linq;

namespace Coki_Skoki_Redo
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var results = new int[N];

            Stack<int> stack = new Stack<int>();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                while(stack.Count > 0 && list[i] >= list[stack.Peek()])
                {
                    int index = stack.Pop();
                    results[index] = stack.Count();
                }
                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                int peekIndex = stack.Pop();
                results[peekIndex] = stack.Count();
            }

            Console.WriteLine(results.Max());
            Console.WriteLine(string.Join(" ", results));
        }
    }
}

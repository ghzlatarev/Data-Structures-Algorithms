using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseUsingStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbersInStack = new Stack<int>(n);

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                numbersInStack.Push(currentNumber);
            }

            Console.WriteLine(string.Join(", ", numbersInStack));
        }
    }
}

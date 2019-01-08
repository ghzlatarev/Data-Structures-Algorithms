using System;
using System.Collections.Generic;

namespace Brackets_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];
                if(ch == '(')
                {
                    stack.Push(i);
                }
                else if(ch == ')')
                {
                    int startIndex = stack.Pop();
                    int length = i - startIndex + 1;
                    string output = expression.Substring(startIndex, length);
                    Console.WriteLine(output);
                }
            }
        }
    }
}

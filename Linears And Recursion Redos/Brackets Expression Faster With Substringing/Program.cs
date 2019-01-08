using System;
using System.Collections.Generic;
using System.Text;

namespace Brackets_Expression_Redo
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            StringBuilder results = new StringBuilder();

            for (int i = 0; i < expression.Length; i++)
            {
                if(expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if(expression[i] == ')')
                {
                    int index = stack.Pop();
                    int length = i - index;
                    results.AppendLine(expression.Substring(index, length + 1));
                }
            }
            Console.WriteLine(results);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Brackets_Expression_Redo
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            StringBuilder results = new StringBuilder();

            foreach (char ch in expression)
            {
                stack.Push(ch);
                if (ch == ')')
                {
                    StringBuilder res = new StringBuilder();
                    int counter = 0;
                    while (true)
                    {
                        while (stack.Peek() != '(')
                        {
                            if (stack.Peek() == ')')
                            {
                                counter++;
                            }
                            res.Insert(0, stack.Pop());
                        }
                        res.Insert(0, stack.Pop());
                        counter--;
                        if (counter == 0)
                        {
                            break;
                        }
                    }
                    foreach (var c in res.ToString())
                    {
                        stack.Push(c);
                    }

                    results.AppendLine(res.ToString());
                }
            }

            Console.WriteLine(results);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDNL_Toy
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var list = new List<string>(N);
            var stack = new Stack<string>();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                list.Add(Console.ReadLine());
            }
            stack.Push($"<{list[0]}>");
            result.AppendLine($"<{list[0]}>");
            int level = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (int.Parse(list[i].Substring(1).ToString()) > int.Parse(list[i - 1].Substring(1).ToString()))
                {
                    level++;
                    string toAppend = new string(' ', level) + $"<{list[i]}>";
                    result.AppendLine(toAppend);
                    stack.Push($"<{list[i]}>");
                }
                else
                {
                    while (int.Parse(list[i].Substring(1).ToString()) <= int.Parse(stack.Peek().Substring(2, stack.Peek().Length - 3).ToString()))
                    {
                        //if(int.Parse(stack.Peek().Substring(2, stack.Peek().Length - 3).ToString()) >=)
                        //{

                        //}
                        if(stack.Count == 1)
                        {
                            level--;
                        }
                        result.AppendLine(new string(' ', level) + stack.Pop().Insert(1, "/"));
                        if (stack.Count == 0)
                        {
                            break;
                        }
                    }
                    
                    result.AppendLine(new string(' ', level) + $"<{list[i]}>");
                    stack.Push($"<{list[i]}>");
                }
            }
            int remaining = stack.Count();
            for (int i = 0; i < remaining; i++)
            {
                result.AppendLine(stack.Pop().Insert(1, "/"));
            }
            Console.WriteLine(result);
        }
    }
}

using System;

namespace Expressions_2
{
    class Program
    {
        static int counter = 0;

        static void Main(string[] args)
        {
            String digits = Console.ReadLine();
            int target = int.Parse(Console.ReadLine());
            f(digits, target);
            
        }

        static void check(int sum, int previous, String digits, int target, String expr)
        {
            if (digits.Length == 0)
            {
                if (sum + previous == target)
                {
                    Console.WriteLine(expr + " = " + target);
                    counter++;
                }
            }
            else
            {
                for (int i = 1; i <= digits.Length; i++)
                {
                    //if (i != 1 && digits[i] == '0')
                    //    break;
                    int current = int.Parse(digits.Substring(0, i));
                    String remaining = digits.Substring(i);
                    check(sum, previous * current, remaining, target, expr + " * " + current);
                    check(sum + previous, current, remaining, target, expr + " + " + current);
                    check(sum + previous, -current, remaining, target, expr + " - " + current);
                }
            }
        }

        static void f(String digits, int target)
        {
            for (int i = 1; i <= digits.Length; i++)
            {
                String current = digits.Substring(0, i);
                check(0, int.Parse(current), digits.Substring(i), target, current);
            }
        }
    }
}

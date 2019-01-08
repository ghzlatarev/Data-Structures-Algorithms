using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerology_Redo
{
    class Program
    {
        static List<int> digits;
        static List<int> results;

        static void Main(string[] args)
        {
            digits = Console.ReadLine().Select(x => x - '0').ToList();
            results = new List<int>(0);
            for (int i = 0; i < 10; i++)
            {
                results.Add(0);
            }

            Solve();

            Console.WriteLine(string.Join(" ", results));

        }

        private static void Solve()
        {
            if (digits.Count == 1)
            {
                results[digits[0]]++;
                return;
            }

            for (int i = 1; i < digits.Count; i++)
            {
                int a = digits[i - 1];
                int b = digits[i];

                int c = (a + b) * (a ^ b) % 10;

                digits[i] = c;
                digits.RemoveAt(i - 1);

                Solve();

                digits.Insert(i - 1, a);
                digits[i] = b;
            }
        }
    }
}

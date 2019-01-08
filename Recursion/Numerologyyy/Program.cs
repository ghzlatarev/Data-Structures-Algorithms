using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerologyyy
{
    class Program
    {
        static int[] digitsCount = new int[10];
        static List<int> digits = new List<int>();

        static void Main(string[] args)
        {
            digits = Console.ReadLine().Select(x => x - '0').ToList();

            Solve();

            Console.WriteLine(string.Join(" ", digitsCount));
        }

        public static void Solve()
        {
            if (digits.Count == 1)
            {
                digitsCount[digits[0]]++;
                return;
            }

            for (int i = 0; i < digits.Count - 1; i++)
            {
                var a = digits[i];
                var b = digits[i + 1];

                digits[i + 1] = (a + b) * (a ^ b) % 10;
                digits.RemoveAt(i);

                Solve();

                digits[i] = a;
                digits.Insert(i + 1, b);
            }
        }
    }
}
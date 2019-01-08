using System;
using System.Collections.Generic;
using System.Linq;

namespace Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (dict.ContainsKey(input))
                {
                    dict[input]++;
                }
                else
                {
                    dict.Add(input, 1);
                }
            }

            Console.WriteLine(dict.First(kvp => kvp.Value%2 == 1).Key);
        }
    }
}

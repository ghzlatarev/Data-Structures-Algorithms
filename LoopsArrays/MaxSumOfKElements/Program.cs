using System;
using System.Collections.Generic;

namespace MaxSumOfKElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            numbers.Sort();
            numbers.Reverse();
            int max = 0;
            for(int i = 0; i < k; i++)
            {
                max += numbers[i];
            }
            Console.WriteLine(max);
        }
    }
}

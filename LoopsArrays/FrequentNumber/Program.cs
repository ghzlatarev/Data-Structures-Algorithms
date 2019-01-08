using System;
using System.Collections.Generic;

namespace FrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            numbers.Sort();
            int current = 1;
            int best = 0;
            int num = 0;
            for (int i = 1; i < n; i++)
            {
                if(numbers[i] == numbers[i - 1])
                {
                    current++;
                    if (current > best)
                    {
                        best = current;
                        num = numbers[i];
                    }
                }
                else
                {
                    current = 1;
                }
            }
            Console.WriteLine(num + " (" + best + " times)");
        }
    }
}

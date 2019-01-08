using System;
using System.Collections.Generic;

namespace MaximalSum
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
            int tempSum = 0;
            int bestSum = 0;

            foreach (int number in numbers)
            {
                tempSum += number;
                if (tempSum <= 0)
                {
                    tempSum = 0;
                }
                else if (tempSum > bestSum)
                {
                    bestSum = tempSum;
                }
            }
            Console.WriteLine(bestSum);
        }
    }
}

using System;
using System.Collections.Generic;

namespace SumAndAverageOfSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = " ";
            long sum = 0;
            int current = 0;
            List<int> numbers = new List<int>();

            while (input != string.Empty)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out current))
                {
                    sum += current;
                    numbers.Add(current);
                }
                else if (input != string.Empty)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            //// decimal for accuracy, float for speed.
            double average = (double)sum / (numbers.Count == 0 ? 1 : numbers.Count);
            Console.WriteLine("\nThe sum is {0}\nAverage is {1}", sum, average);
        }
    }
}

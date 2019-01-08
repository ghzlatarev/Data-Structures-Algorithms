using System;
using System.Collections.Generic;

namespace SortingListOfNumbers
{

    // Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.

    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = new List<int>();

            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                int number = int.Parse(input);
                inputNumbers.Add(number);

                input = Console.ReadLine();
            }

            inputNumbers.Sort();
            Console.WriteLine(string.Join(", ", inputNumbers));
        }
    }
}

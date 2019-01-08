using System;
using System.Collections.Generic;

namespace FindMajorantOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            numbers.Sort();
            var occurrences = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (!occurrences.ContainsKey(numbers[i]))
                {
                    occurrences.Add(numbers[i], 1);
                }
                else
                {
                    occurrences[numbers[i]]++;
                }
            }

            foreach (var kvp in occurrences)
            {
                if (kvp.Value >= numbers.Count/2 + 1)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}

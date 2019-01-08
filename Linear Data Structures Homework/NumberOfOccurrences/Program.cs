using System;
using System.Collections.Generic;

namespace NumberOfOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
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

            foreach(var kvp in occurrences)
            {
                Console.WriteLine(kvp.Key + " -> " + kvp.Value + " times");
            }
        }
    }
}

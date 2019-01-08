using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveAllOddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
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

            var evenOccuredNumbers = numbers.Where(n => occurrences[n] % 2 == 0).ToList();
            Console.WriteLine(string.Join(", ", evenOccuredNumbers));
        }
    }
}

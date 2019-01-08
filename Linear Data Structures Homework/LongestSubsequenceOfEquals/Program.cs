using System;
using System.Collections.Generic;

namespace LongestSubsequenceOfEquals
{
    class Program
    {
        /* Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>.
     * Write a program to test whether the method works correctly.*/

        public static void Main()
        {
            List<int> numbers = new List<int>() { 1, 2, 2, 1, 1, 1, 1, 3, 3 };
            List<int> subsequance = GetLongestSubsequenceOfEquals(numbers);
            Console.WriteLine(string.Join(", ", subsequance));
        }

        private static List<int> GetLongestSubsequenceOfEquals(List<int> inputNumbers)
        {
            var bestCounter = 1;
            var currentCounter = 1;
            var repeatedNumber = inputNumbers[0];
            var equalNumbersSubsequance = new List<int>();

            for (int i = 0; i < inputNumbers.Count - 1; i++)
            {
                if (inputNumbers[i] == inputNumbers[i + 1])
                {
                    currentCounter++;
                }
                else
                {
                    currentCounter = 1;
                }

                if (currentCounter >= bestCounter)
                {
                    bestCounter = currentCounter;
                    repeatedNumber = inputNumbers[i];
                }
            }

            for (int i = 0; i < bestCounter; i++)
            {
                equalNumbersSubsequance.Add(repeatedNumber);
            }

            return equalNumbersSubsequance;
        }
    }
}

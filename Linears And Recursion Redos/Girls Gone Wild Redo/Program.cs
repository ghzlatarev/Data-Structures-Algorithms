using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Girls_Gone_Wild_Redo
{
    class Program
    {
        static int numberOfNumbers;
        static int numberOfGirls;

        static char[] letters;
        static int[] letterComb;

        static int[] numbers;
        static int[] numberComb;

        static List<List<int>> allNumberCombinations = new List<List<int>>();
        static List<List<char>> allLetterCombinations = new List<List<char>>();
        static List<List<char>> allPermutations = new List<List<char>>();

        static SortedSet<string> allResults = new SortedSet<string>();

        static void Main(string[] args)
        {
            numberOfNumbers = int.Parse(Console.ReadLine());
            numbers = new int[numberOfNumbers];
            for (int i = 0; i < numberOfNumbers; i++)
            {
                numbers[i] = i;
            }
            letters = Console.ReadLine().ToCharArray().OrderBy(c => c).ToArray();
            numberOfGirls = int.Parse(Console.ReadLine());

            numberComb = new int[numberOfGirls];
            GenerateNumberCombinations(0, 0);

            letterComb = new int[numberOfGirls];
            GenerateLetterCombinations(0, 0);

            foreach (var lComb in allLetterCombinations)
            {
                List<char> newLetters = new List<char>(lComb);
                GeneratePermutations(newLetters, 0, newLetters.Count);
            }

            foreach (var nComb in allNumberCombinations)
            {

                foreach (var permutation in allPermutations)
                {
                    string result = Merge(nComb, permutation);
                    allResults.Add(result);
                }
            }

            Console.WriteLine(allResults.Count);

            foreach (var result in allResults)
            {
                Console.WriteLine(result);
            }
        }

        private static void GenerateNumberCombinations(int index, int border)
        {
            if (index > numberComb.Length - 1)
            {
                List<int> currentComb = new List<int>();

                for (int i = 0; i < numberOfGirls; i++)
                {
                    currentComb.Add(numbers[numberComb[i]]);
                }
                
                allNumberCombinations.Add(currentComb);
                return;
            }
            for (int i = border; i < numberOfNumbers; i++)
            {
                numberComb[index] = i;
                GenerateNumberCombinations(index + 1, i + 1);
            }
        }

        private static void GenerateLetterCombinations(int index, int border)
        {
            if (index > letterComb.Length - 1)
            {
                List<char> currentComb = new List<char>();

                for (int i = 0; i < numberOfGirls; i++)
                {
                    currentComb.Add(letters[letterComb[i]]);
                }

                allLetterCombinations.Add(currentComb);
                return;
            }
            for (int i = border; i < letters.Length; i++)
            {
                letterComb[index] = i;
                GenerateLetterCombinations(index + 1, i + 1);
            }
        }

        private static string Merge(List<int> nComb, List<char> permutation)
        {
            var result = new StringBuilder();

            for (int i = 0; i < permutation.Count; i++)
            {
                result.Append(nComb[i]);
                result.Append(permutation[i]);
                result.Append('-');
            }

            result.Length--;
            return result.ToString();
        }

        static void GeneratePermutations(List<char> arr, int start, int n)
        {
            allPermutations.Add(new List<char>(arr));
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        var oldValue = arr[left];
                        arr[left] = arr[right];
                        arr[right] = oldValue;

                        GeneratePermutations(arr, left + 1, n);
                    }
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }
    }
}

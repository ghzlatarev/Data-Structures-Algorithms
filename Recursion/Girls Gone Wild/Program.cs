using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Girls_Gone_Wild
{
    class Program
    {
        private static SortedSet<string> finalResult = new SortedSet<string>();

        private static int numberOfGirls; 

        private static List<List<int>> numbersCombinations = new List<List<int>>();//всички комбинации на цифри
        private static List<List<char>> lettersCombinations = new List<List<char>>();//всички комбинации на букви

        private static int numbersCount;
        //private static int lettersCount;

        public static void Main(string[] args)
        {
            numbersCount = int.Parse(Console.ReadLine());
           
            var letters = Console.ReadLine().ToCharArray().OrderBy(c => c).ToArray();
            //lettersCount = letters.Length;
            numberOfGirls = int.Parse(Console.ReadLine());

            var array = new int[numbersCount];

            ComboNumbers(array, 0, 0, comb => 
            {
                numbersCombinations.Add(new List<int>(comb));
            });

            array = new int[letters.Length];
            ComboLetters(array, 0, 0, comb =>
            {
                var currentLetterCombo = new List<char>();

                for (int i = 0; i < numberOfGirls; i++)
                {
                    currentLetterCombo.Add(letters[comb[i]]);
                }

                lettersCombinations.Add(currentLetterCombo);
            });

            foreach (var numbersComb in numbersCombinations)
            {
                foreach (var lettersComb in lettersCombinations)
                {
                    var newLetters = new List<char>(lettersComb);
                    PermuteRep(newLetters, 0, newLetters.Count, perm => 
                    {
                        Merge(perm, numbersComb);
                    });
                }

            }
            Console.WriteLine(finalResult.Count);
            foreach (var item in finalResult)
            {
                Console.WriteLine(item);
            }
        }

        public static void ComboLetters(int[] arr, int index, int start, Action<int[]> action)
        {
            if(index >= numberOfGirls)
            {
                action(arr);
            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    arr[index] = i;
                    ComboLetters(arr, index + 1, i + 1, action);
                }
            }
        }

        public static void ComboNumbers(int[] arr, int index, int start, Action<int[]> action)
        {
            if (index >= numberOfGirls)
            {
                action(arr);
            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    arr[index] = i;
                    ComboNumbers(arr, index + 1, i + 1, action);
                }
            }
        }

        public static void Merge(List<char> letters, List<int> numbers)
        {
            var result = new StringBuilder();

            for (int i = 0; i < letters.Count; i++)
            {
                result.Append(numbers[i]);
                result.Append(letters[i]);
                result.Append('-');
            }

            result.Length--;
            finalResult.Add(result.ToString());
        }

        static void PermuteRep(List<char> arr, int start, int n, Action<List<char>> action)
        {
            action(arr);
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        var oldValue = arr[left];
                        arr[left] = arr[right];
                        arr[right] = oldValue;

                        PermuteRep(arr, left + 1, n, action);
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

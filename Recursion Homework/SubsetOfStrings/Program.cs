using System;

namespace SubsetOfStrings
{
    class Program
    {
        static void Main()
        {
            int k = 2;
            string[] elements = { "test", "rock", "fun" };
            string[] combinations = new string[k];

            GenerateCombinationsWithNoDuplicates(0, elements.Length, k, elements, combinations);
        }

        private static void GenerateCombinationsWithNoDuplicates(int index, int n, int k, string[] elements, string[] result)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    result[index] = elements[i];
                    if (index > 0 && string.Compare(result[index], result[index - 1], StringComparison.Ordinal) >= 0)
                    {
                        continue;
                    }
                    GenerateCombinationsWithNoDuplicates(index + 1, n, k, elements, result);
                }
            }
        }
    }
}

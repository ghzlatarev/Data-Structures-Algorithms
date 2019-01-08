using System;

namespace MaxIncreasingSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];


            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int max = 0;
            int current = 1;


            for (int i = 1; i < n; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    current++;
                    max = Math.Max(max, current);
                }
                else
                {
                    max = Math.Max(max, current);
                    current = 1;
                }
            }

            Console.WriteLine(max);
        }
    }
}

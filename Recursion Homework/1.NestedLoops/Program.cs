using System;

namespace _1.NestedLoops
{
    class Program
    {
        private static int from = 1;
        private static int to = 3;
        private static int[] array = new int[to];

        static void Main(string[] args)
        {
            GenerateVariationsWithRepetition(0);
        }
        static void GenerateVariationsWithRepetition(int index)
        {
            if (index >= to)
            {
                Console.WriteLine(string.Join(", ", array));
            }
            else
            {
                for (int i = from; i <= to; i++)
                {
                    array[index] = i;
                    GenerateVariationsWithRepetition(index + 1);
                }
            }
        }
    }
}

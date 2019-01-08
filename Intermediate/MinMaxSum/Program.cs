using System;

namespace MinMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] line1 = Console.ReadLine().Split();
            int m = int.Parse(line1[0]);
            int g = int.Parse(line1[1]);
            string[] line2 = Console.ReadLine().Split();
            int[] numbers = new int[m];
            for(int i = 0; i < m; i++)
            {
                numbers[i] = int.Parse(line2[i]);
            }
            int min = 0;
            int max = 0;


        }
    }
}

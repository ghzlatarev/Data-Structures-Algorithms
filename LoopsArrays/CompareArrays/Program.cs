using System;

namespace CompareArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] first = new int[n];
            int[] second = new int[n];
            for (int i = 0; i<n; i++)
            {
                first[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                second[i] = int.Parse(Console.ReadLine());
            }
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                if (first[i] == second[i])
                {
                    counter++;
                    continue;
                }
                else break;
            }
            if (counter == 3)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Sub_Set_Sum_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            long[] numbers = new long[n];

            for(int i = 0; i < n; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }

            List<long> sums = new List<long>();

            for (int i = 0; i < n; i++)
            {
                int len = sums.Count;
                for (int j = 0; j < len; j++)
                {
                    sums.Add(sums[j] + numbers[i]);
                }
                sums.Add(numbers[i]);
            }
            Console.WriteLine(string.Join(", ", sums));
            /*int found = 0;
            for(int i = 0; i<sums.Count; i++)
            {
                if(sums[i] == s)
                {
                    found++; 
                    break;
                }
            }
            if (found > 0)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }*/
        }
    }
}

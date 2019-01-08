using System;
using System.Collections.Generic;

namespace Sub_Set_WIth_Sum_S_Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            String[] inputElements = input.Split(' ', ',');
            long[] numbers = new long[inputElements.Length];
            for (int i = 0; i < inputElements.Length; i++)
            {
                numbers[i] = long.Parse(inputElements[i]);
            }
            int n = numbers.Length;
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
            
            int found = 0;
            foreach(int sum in sums)
            {
                if(sum == s)
                {
                    found++;
                }
            }
            if (found > 0)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}

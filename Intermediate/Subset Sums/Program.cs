using System;

namespace Subset_Sums
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

            int sumCounter = 0;
            int combinations = (int)Math.Pow(2, n);
            for(int i = 1; i< combinations; i++)
            {
                long tempSum = 0;
                for(int j = 0; j < n; j++)
                {
                    int mask = 1 << j;
                    //Console.WriteLine(mask + " mask");
                    int iAndMask = mask & i;
                    //Console.WriteLine(iAndMask + " iAndMask");
                    int bit = iAndMask >> j;
                    //Console.WriteLine(bit + " bit");
                    if (bit == 1)
                    {
                        tempSum += numbers[j];  
                    }  
                }
                if (tempSum == s)
                {
                    sumCounter++;
                }
                //Console.WriteLine(tempSum);
            }
            Console.WriteLine(sumCounter);
        }
    }
}

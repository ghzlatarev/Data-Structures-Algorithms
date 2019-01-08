using System;

namespace Subset_of_Sum_S
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            
            // Input array
            string input = Console.ReadLine();
            // Split the elements into an array
            String[] inputElements = input.Split(' ', ',');
            // Fill an integer array from string array
            long[] numbers = new long[inputElements.Length];
            for (int i = 0; i < inputElements.Length; i++)
            {
                numbers[i] = long.Parse(inputElements[i]);
            }
           
            int sumCounter = 0;
            long combinations = (long)Math.Pow(2, numbers.Length)-1;
            for (int i = 1; i <= combinations; i++)
            {
                long tempSum = 0;
                for (int j = 0; j < numbers.Length; j++)
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
            if (sumCounter > 0)
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

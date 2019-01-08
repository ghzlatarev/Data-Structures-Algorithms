using System;

namespace ThreeGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String[] inputElements = Console.ReadLine().Split();
            int[] list = new int[inputElements.Length];
            int[] rem0 = new int[inputElements.Length];
            int[] rem1 = new int[inputElements.Length];
            int[] rem2 = new int[inputElements.Length];

            for (int i = 0; i < inputElements.Length; i++)
            {
                list[i] = int.Parse(inputElements[i]);
                if (list[i] % 3 == 0)
                {
                    rem0[i] = list[i];
                }
                else if (list[i] % 3 == 1)
                {
                    rem1[i] = list[i];
                }
                else if (list[i] % 3 == 2)
                {
                    rem2[i] = list[i];
                }
            }
            for (int i = 0; i < inputElements.Length; i++)
            {
                if (rem0[i] != 0)
                {
                    Console.Write(rem0[i] + " ");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < inputElements.Length; i++)
            {
                if (rem1[i] != 0)
                {
                    Console.Write(rem1[i] + " ");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < inputElements.Length; i++)
            {
                if (rem2[i] != 0)
                {
                    Console.Write(rem2[i] + " ");
                }
            }
        }
    }
}

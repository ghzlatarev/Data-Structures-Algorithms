using System;

namespace MatrixOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 1; col <= n; col++)
                    Console.Write(row + col + " ");

                Console.WriteLine();
            }
        }
    }
}

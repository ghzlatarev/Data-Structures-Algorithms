using System;
using System.Numerics;

namespace AboveTheMainDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            ulong[,] matrix = new ulong[n,n];
            for (ulong r = 0; r < n; r++)
            {
                for (ulong c = 0; c < n; c++)
                {
                    matrix[r,c] = (ulong)Math.Pow(2, r) * (ulong)Math.Pow(2, c);
                }
            }

            ulong sum = 0;
            for (ulong i = 0; i < n; i++)
            {
                for (ulong k = i; k < n; k++)
                {
                    sum = sum + matrix[i,k];
                }
            }
            Console.WriteLine(sum);
        }
    }
}

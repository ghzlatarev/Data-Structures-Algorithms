using System;
using System.Linq;

namespace Portals_Redo
{
    class Program
    {
        static int[,] matrix;
        static int maxSum = 0;
        static int r;
        static int c;

        static void Main(string[] args)
        {
            int[] line1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int x = line1[0];
            int y = line1[1];

            int[] line2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            r = line2[0];
            c = line2[1];

            matrix = new int[r, c];

            for (int i = 0; i < r; i++)
            {
                string[] line = Console.ReadLine().Split();
                for (int j = 0; j < c; j++)
                {
                    if (char.IsDigit(line[j][0]))
                    {
                        matrix[i, j] = int.Parse(line[j]);
                    }
                    else
                    {
                        matrix[i, j] = -1;
                    }
                }
            }

            Solve(x, y, 0);

            Console.WriteLine(maxSum);
        }

        private static void Solve(int x, int y, int tempSum)
        {
            if (matrix[x, y] == 0)
            {
                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                }
                return;
            }

            int power = matrix[x, y];

            //nodulu
            if (x + power < r && matrix[x + power, y] != -1)
            {
                tempSum += power;
                matrix[x, y] = 0;
                Solve(x + power, y, tempSum);
                matrix[x, y] = power;
                tempSum -= power;
            }
            //nogore
            if (x - power >= 0 && matrix[x - power, y] != -1)
            {
                tempSum += power;
                matrix[x, y] = 0;
                Solve(x - power, y, tempSum);
                matrix[x, y] = power;
                tempSum -= power;
            }
            //nadqsno
            if (y + power < c && matrix[x, y + power] != -1)
            {
                tempSum += power;
                matrix[x, y] = 0;
                Solve(x, y + power, tempSum);
                matrix[x, y] = power;
                tempSum -= power;
            }
            //nalqvo
            if (y - power >= 0 && matrix[x, y - power] != -1)
            {
                tempSum += power;
                matrix[x, y] = 0;
                Solve(x, y - power, tempSum);
                matrix[x, y] = power;
                tempSum -= power;
            }

            if (tempSum > maxSum)
            {
                maxSum = tempSum;
            }

        }
    }
}

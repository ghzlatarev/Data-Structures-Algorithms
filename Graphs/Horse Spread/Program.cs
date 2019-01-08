using System;
using System.Collections.Generic;

namespace Horse_Spread
{
    class Program
    {
        static int[,] matrix;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int R = int.Parse(Console.ReadLine());
            int C = int.Parse(Console.ReadLine());

            matrix = new int[N, M];
            matrix[R, C] = 1;

            int[] deltaRow = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] deltaCol = { -1, 1, -2, 2, -2, 2, -1, 1 };

            Tuple<int, int> start = new Tuple<int, int>(R, C);

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                Tuple<int, int> current = queue.Dequeue();
                int currRow = current.Item1;
                int currCol = current.Item2;

                for (int i = 0; i < 8; i++)
                {
                    var newRow = currRow + deltaRow[i];
                    var newCol = currCol + deltaCol[i];

                    if (newRow >= 0 && newRow < N && newCol >= 0 && newCol < M && matrix[newRow, newCol] == 0)
                    {
                        Tuple<int, int> next = new Tuple<int, int>(newRow, newCol);
                        queue.Enqueue(next);
                        matrix[newRow, newCol] = matrix[currRow, currCol] + 1;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(matrix[i, M / 2]);
            }
        }
    }
}
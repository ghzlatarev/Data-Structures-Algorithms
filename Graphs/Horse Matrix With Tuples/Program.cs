using System;
using System.Collections.Generic;
using System.Linq;

namespace Horse_Spread_With_Tuples
{
    class Program
    {
        static char[,] matrix;

        static void Main(string[] args)
        {
            int N = GetNumbers(Console.ReadLine());
            matrix = new char[N, N];
            Tuple<int, int> start = new Tuple<int, int>(0, 0);

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                int index = 0;
                foreach (char ch in line.Where(c => c != ' '))
                {
                    matrix[i, index] = ch;

                    if (ch == 's')
                    {
                        start = new Tuple<int, int>(i, index);
                    }
                    index++;
                }
            }

            int[] deltaRow = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] deltaCol = { -1, 1, -2, 2, -2, 2, -1, 1 };

            int[,] usedMatrix = new int[N, N];
            usedMatrix[start.Item1, start.Item2] = 1;

            //Dictionary<Tuple<int, int>, int> counting = new Dictionary<Tuple<int, int>, int>();
            //counting.Add(start, 0);

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                Tuple<int, int> current = queue.Dequeue();

                for (int i = 0; i < 8; i++)
                {
                    var newRow = current.Item1 + deltaRow[i];
                    var newCol = current.Item2 + deltaCol[i];

                    if (newRow >= 0 && newRow < N && newCol >= 0 && newCol < N && matrix[newRow, newCol] != 'x' && usedMatrix[newRow, newCol] == 0)
                    {
                        Tuple<int, int> next = new Tuple<int, int>(newRow, newCol);

                        queue.Enqueue(next);
                        usedMatrix[newRow, newCol] = usedMatrix[current.Item1, current.Item2] + 1;

                        if (matrix[newRow, newCol] == 'e')
                        {
                            Console.WriteLine(usedMatrix[current.Item1, current.Item2]);
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("No");
        }

        static int GetNumbers(string input)
        {
            int y = 0;
            for (int i = 0; i < input.Length; i++)
            {
                y = y * 10 + (input[i] - '0');
            }
            return y;
        }
    }
}

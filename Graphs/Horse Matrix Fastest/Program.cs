using System;
using System.Collections.Generic;
using System.Linq;

namespace Horse_Matrix
{
    class Program
    {
        static char[,] matrix;

        static void Main(string[] args)
        {
            int N = GetNumbers(Console.ReadLine());
            matrix = new char[N, N];
            string start = "";

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                int index = 0;
                foreach (char ch in line.Where(c => c != ' '))
                {
                    matrix[i, index] = ch;

                    if (ch == 's')
                    {
                        start = i.ToString() + " " + index.ToString();
                    }

                    index++;
                }
            }

            int[] deltaRow = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] deltaCol = { -1, 1, -2, 2, -2, 2, -1, 1 };
            

            Dictionary<string, int> counting = new Dictionary<string, int>();
            counting.Add(start, 0);

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();

                for (int i = 0; i < 8; i++)
                {
                    var newRow = GetNumbers(current.Substring(0, current.IndexOf(' '))) + deltaRow[i];
                    var newCol = GetNumbers(current.Substring(current.IndexOf(' ') + 1)) + deltaCol[i];

                    if (newRow >= 0 && newRow < N && newCol >= 0 && newCol < N && matrix[newRow, newCol] != 'x')
                    {
                        string newKey = newRow.ToString() + " " + newCol.ToString();
                        if (!counting.ContainsKey(newKey))
                        {
                            counting.Add(newKey, counting[current] + 1);
                            queue.Enqueue(newKey);
                        }

                        if (matrix[newRow, newCol] == 'e')
                        {
                            Console.WriteLine(counting[current] + 1);
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

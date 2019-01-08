using System;
using System.Collections.Generic;
using System.Linq;

namespace Horse_Matrix
{
    class Program
    {
        static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        //static SortedSet<int> results = new SortedSet<int>();
        static char[,] matrix;
        //static HashSet<string> used = new HashSet<string>();


        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            matrix = new char[N, N];
            string start = "";
            string end = "";

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                int index = 0;
                foreach (char ch in line.Where(c => c!=' '))
                {
                    matrix[i, index] = ch;
                    
                    if(ch == 's')
                    {
                        start = i.ToString() + " " + index.ToString();
                    }

                    if (ch == 'e')
                    {
                        end = i.ToString() + " " + index.ToString();
                    }

                    index++;
                }
            }
            
            int[] deltaRow = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] deltaCol = { -1, 1, -2, 2, -2, 2, -1, 1 };

            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    if(matrix[row, col] == 'x')
                    {
                        continue;
                    }
                    else
                    {
                        string graphKey = row.ToString() + " " + col.ToString();
                        graph.Add(graphKey, new List<string>());
                        for (int j = 0, newRow, newCol; j < 8; j++)
                        {
                            newRow = row + deltaRow[j];
                            newCol = col + deltaCol[j];
                            if (newRow >= 0 && newRow < N && newCol >= 0 && newCol < N && matrix[newRow, newCol] != 'x')
                            {
                                graph[graphKey].Add(newRow.ToString() + " " + newCol.ToString());
                            }
                        }
                    }
                }
            }

            //BFS SOLUTION - FASTER

            Dictionary<string, int> counting = new Dictionary<string, int>();
            counting.Add(start, 0);

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();

                foreach (var next in graph[current].Where(next => !counting.ContainsKey(next)))
                {
                    queue.Enqueue(next);
                    counting.Add(next, counting[current] + 1);
                }

                if (current == end)
                {
                    break;
                }
            }

            if(!counting.ContainsKey(end))
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(counting[end]);
            }

            
            //DFS SOLUTION - SLOWER

            //Dfs(start, "", -1);

            //if(results.Count > 0)
            //{
            //    Console.WriteLine(results.First());
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //}

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

        //private static void Dfs(string x, string prev, int counter)
        //{
        //    used.Add(x);
        //    counter++;

        //    if (results.Count > 0 && counter > results.First())
        //    {
        //        return;
        //    }

        //    if (matrix[int.Parse(x.Substring(0, x.IndexOf(' '))), int.Parse(x.Substring(x.IndexOf(' ') + 1))] == 'e')
        //    {
        //        results.Add(counter);
        //        return;
        //    }

        //    foreach (var y in graph[x].Where(y => !used.Contains(y)))
        //    {
        //        Dfs(y, x, counter);
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximal_Path_2
{
    class Program
    {
        private static long maxSum = 0;
        private static int bestNode = 0;
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n - 1; i++)
            {
                string connection = Console.ReadLine();

                string[] separatedConnection = connection.Split(new char[] { '(', '<', '-', ')' }, StringSplitOptions.RemoveEmptyEntries);

                int parent = int.Parse(separatedConnection[0]);
                int child = int.Parse(separatedConnection[1]);
                
                if (!graph.ContainsKey(parent))
                {
                    graph.Add(parent, new List<int>());
                }
                graph[parent].Add(child);
                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new List<int>());
                }
                graph[child].Add(parent);
            }

            int first = graph.First().Key;
            Dfs(first, 0, 0);//namirame vsichki putishta ot proizvolen vruh do vsichki lista/kraishta na graph-a
                         //i vzimame vurha do koito sme napravili nai golqmata suma zashtoto sme sigurni
                         //che put zapochvasht ot nego shte bude i nai dulgiqt put mejdu 2 kraishta na graph-a

            Dfs(bestNode, 0, 0);//namirame vsichki sumi zapochvashti ot nai dobriqt vruh

            Console.WriteLine(maxSum);
        }

        private static void Dfs(int x, int prev, long tempSum)
        {
            tempSum += x;

            foreach (var y in graph[x].Where(y => y != prev))
            {
                Dfs(y, x, tempSum);
            }

            if (tempSum > maxSum)
            {
                maxSum = tempSum;
                bestNode = x;
            }
        }
    }
}

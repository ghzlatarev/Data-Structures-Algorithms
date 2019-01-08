using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    class Program
    {
        static Dictionary<int, HashSet<Tuple<int, int>>> graph = new Dictionary<int, HashSet<Tuple<int, int>>>();
        static SortedSet<int> allWeights = new SortedSet<int>();
        static HashSet<int> used = new HashSet<int>();
        static int n;
        static int maxSum = 0;
        static int bestNode;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                string line = Console.ReadLine();
                int pointA = int.Parse(line.Substring(0, line.IndexOf(' ')));
                int pointB = int.Parse(line.Substring(line.IndexOf(' ') + 1, line.LastIndexOf(' ') - line.IndexOf(' ')));
                int weight = int.Parse(line.Substring(line.LastIndexOf(' ') + 1));

                if (!graph.ContainsKey(pointA))
                {
                    graph.Add(pointA, new HashSet<Tuple<int, int>>());
                }
                if (!graph.ContainsKey(pointB))
                {
                    graph.Add(pointB, new HashSet<Tuple<int, int>>());
                }
                Tuple<int, int> a = new Tuple<int, int>(pointA, weight);
                Tuple<int, int> b = new Tuple<int, int>(pointB, weight);
                graph[pointA].Add(b);
                graph[pointB].Add(a);
                allWeights.Add(weight);
            }

            DFS(graph.First().Key, 0);
            used.Clear();
            DFS(bestNode, 0);
            
            Console.WriteLine(maxSum);
        }

        static void DFS(int x, int tempSum)
        {
            if (tempSum > maxSum)
            {
                maxSum = tempSum;
                bestNode = x;
            }

            used.Add(x);

            if (used.Count == n)
            {
                return;
            }

            foreach (var y in graph[x].Where(y => !used.Contains(y.Item1)))
            {
                DFS(y.Item1, tempSum + y.Item2);
            }
        }
    }
}

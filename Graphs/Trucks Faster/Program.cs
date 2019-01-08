using System;
using System.Collections.Generic;
using System.Linq;

namespace Trucks
{
    class Program
    {
        static Dictionary<int, HashSet<Tuple<int, int>>> graph = new Dictionary<int, HashSet<Tuple<int, int>>>();
        static HashSet<int> used = new HashSet<int>(1000);
        static SortedSet<int> allHeights = new SortedSet<int>();
        static int bestNode = 0;
        static int n;

        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            n = firstLine[0];
            int m = firstLine[1];

            for (int i = 0; i < m; i++)
            {
                string line = Console.ReadLine();
                int pointA = int.Parse(line.Substring(0, line.IndexOf(' ')));
                int pointB = int.Parse(line.Substring(line.IndexOf(' ') + 1, line.LastIndexOf(' ') - line.IndexOf(' ')));
                int bridgeHeight = int.Parse(line.Substring(line.LastIndexOf(' ') + 1));

                if (!graph.ContainsKey(pointA))
                {
                    graph.Add(pointA, new HashSet<Tuple<int, int>>());
                }
                if (!graph.ContainsKey(pointB))
                {
                    graph.Add(pointB, new HashSet<Tuple<int, int>>());
                }
                Tuple<int, int> a = new Tuple<int, int>(pointA, bridgeHeight);
                Tuple<int, int> b = new Tuple<int, int>(pointB, bridgeHeight);
                graph[pointA].Add(b);
                graph[pointB].Add(a);
                allHeights.Add(bridgeHeight);
            }

            int bestCount = int.MaxValue;
            foreach (var kvp in graph)
            {
                if (kvp.Value.Count < bestCount)
                {
                    bestNode = kvp.Key;
                }
            }

            int bestHeight = 0;
            foreach (var height in allHeights.Reverse().Skip(2))
            {
                used.Clear();
                DFS(bestNode, height);
                if (used.Count == n)
                {
                    bestHeight = height;
                    break;
                }
            }

            Console.WriteLine(bestHeight);
        }

        static void DFS(int x, int height)
        {
            used.Add(x);

            if (used.Count == n)
            {
                return;
            }

            foreach (var y in graph[x].Where(y => !used.Contains(y.Item1) && y.Item2 >= height))
            {
                DFS(y.Item1, height);
            }
        }
    }
}
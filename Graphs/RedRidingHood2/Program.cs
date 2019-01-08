using System;
using System.Collections.Generic;
using System.Linq;

namespace RedRidingHood2
{
    class Program
    {
        private static int[] money;
        private static int maxMoney = 0;
        private static int bestNode = 0;
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            money = new int[n];

            money = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                graph.Add(i + 1, new List<int>());
            }

            for (int i = 0; i < n - 1; i++)
            {
                int[] nodes = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int a = nodes[0];
                int b = nodes[1];
                graph[a].Add(b);
                graph[b].Add(a);
            }

            Dfs(1, 0, 0);//namirame vsichki putishta ot proizvolen vruh do vsichki lista/kraishta na graph-a
                         //i vzimame vurha do koito sme napravili nai golqmata suma zashtoto sme sigurni
                         //che put zapochvasht ot nego shte bude i nai dulgiqt put mejdu 2 kraishta na graph-a

            Dfs(bestNode, 0, 0);//namirame vsichki sumi zapochvashti ot nai dobriqt vruh

            Console.WriteLine(maxMoney);
        }

        private static void Dfs(int x, int prev, int tempMoney)
        {
            tempMoney += money[x - 1];

            foreach (var y in graph[x].Where(y => y != prev))
            {
                Dfs(y, x, tempMoney);
            }

            if (tempMoney > maxMoney)
            {
                maxMoney = tempMoney;
                bestNode = x;
            }
        }
    }
}
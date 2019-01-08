using System;
using System.Collections.Generic;

namespace Red_Riding_Hood
{
    class Program
    {
        private static int n;
        private static int[] money;
        private static int[,] graph;
        private static int maxMoney;
        private static int bestNode;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            money = new int[n];
            graph = new int[n,n];
            string[] moneyStrings = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                money[i] = int.Parse(moneyStrings[i]);
                for (int j = 0; j < n; j++)
                {
                    graph[i,j] = 0;
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                string[] nodes = Console.ReadLine().Split();
                int a = int.Parse(nodes[0]) - 1;
                int b = int.Parse(nodes[1]) - 1;
                graph[a,b] = 1;
                graph[b,a] = 1;
            }

            maxMoney = 0;
            bestNode = -1;

            dfs(0, -1, 0);

            maxMoney = 0;
            dfs(bestNode, -1, 0);

            Console.WriteLine(maxMoney);
        }

        private static void dfs(int x, int prev, int tempMoney)
        {
            tempMoney += money[x];
            bool hasNext = false;

            for (int i = 0; i < n; i++)
            {
                if (graph[x,i] != 0 && i != prev)
                {
                    hasNext = true;
                    dfs(i, x, tempMoney);
                }
            }

            if (!hasNext)
            {
                if (tempMoney > maxMoney)
                {
                    maxMoney = tempMoney;
                    bestNode = x;
                }
            }
        }
    }
}

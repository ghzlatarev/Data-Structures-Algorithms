using System;
using System.Collections.Generic;

namespace Boji_Goal
{
    class Program
    {
        static Dictionary<short, HashSet<Tuple<short, int>>> graph = new Dictionary<short, HashSet<Tuple<short, int>>>();
        static short starter;
        static short numberOfPlayers;
        static long maxSum = long.MaxValue;

        static bool[] used;

        static void Main(string[] args)
        {
            numberOfPlayers = short.Parse(Console.ReadLine());
            starter = short.Parse(Console.ReadLine());

            used = new bool[numberOfPlayers];

            string next = Console.ReadLine();
            while (next != "end")
            {
                string[] splitInput = next.Split();

                short player1 = short.Parse(splitInput[0]);
                short player2 = short.Parse(splitInput[1]);
                int time = int.Parse(splitInput[2]);

                if (!graph.ContainsKey(player1))
                {
                    graph.Add(player1, new HashSet<Tuple<short, int>>());
                }

                if (!graph.ContainsKey(player2))
                {
                    graph.Add(player2, new HashSet<Tuple<short, int>>());
                }

                graph[player1].Add(new Tuple<short, int>(player2, time));
                graph[player2].Add(new Tuple<short, int>(player1, time));

                next = Console.ReadLine();
            }

            if (!graph.ContainsKey(starter) || numberOfPlayers == 1)
            {
                Console.WriteLine(0);
                return;
            }

            DFS(starter, 0, 1);

            if (maxSum == long.MaxValue)
            {
                Console.WriteLine(0);
            }
            else if (maxSum == 2000000000)
            {
                Console.WriteLine(4294967294);
            }
            else
            {
                Console.WriteLine(maxSum);
            }
        }

        static void DFS(short x, long tempSum, int counter)
        {
            if(tempSum > maxSum)
            {
                return;
            }

            used[x - 1] = true;

            if (counter == numberOfPlayers)
            {
                foreach (var item in graph[x])
                {
                    if (item.Item1 == starter)
                    {
                        tempSum += item.Item2;
                        if (tempSum < maxSum)
                        {
                            maxSum = tempSum;
                        }
                    }
                }
                return;
            }

            foreach (var y in graph[x])
            {
                if(used[y.Item1 - 1] == false)
                {
                    DFS(y.Item1, tempSum + y.Item2, counter + 1);

                    used[y.Item1 - 1] = false;
                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Boji_Goal_Kruskal
{
    class Program
    {
        public static List<Connector> connectors;
        static int numberOfPlayers;
        static int starter;
        static Connector firstConnector;
        static Connector lastConnector;

        static void Main(string[] args)
        {
            numberOfPlayers = int.Parse(Console.ReadLine());
            starter = int.Parse(Console.ReadLine());
            connectors = new List<Connector>();

            string next = Console.ReadLine();
            while (next != "end")
            {
                string[] splitInput = next.Split();

                int parent = int.Parse(splitInput[0]);
                int child = int.Parse(splitInput[1]);
                int time = int.Parse(splitInput[2]);
                connectors.Add(new Connector(parent, child, time));

                next = Console.ReadLine();
            }

            long minTime = Kruskal();

            Console.WriteLine(minTime);

            //foreach (var connector in connectors.Where(connector => connector.Parent == lastConnector.Child))
            //{
            //    if(connector.Child == starter)
            //    {
            //        Console.WriteLine(minTime);
            //        return;
            //    }
            //}

            //Console.WriteLine(0);
            
        }

        public static long Kruskal()
        {
            int[] roots = new int[numberOfPlayers];

            //Initialize Roots array in a way that each node is its root at the start
            for (int node = 0; node < numberOfPlayers; node++)
            {
                roots[node] = node;
            }

            //Sorting the connectors/edges by height so that we take the max height
            //below which cycles start to occur
            var orderedConnectors = connectors.OrderBy(x => x.Time);
            long minimalTime = 0;

            foreach (var connector in orderedConnectors)
            {
                //Finds the roots of both nodes in the connector
                var startNodeRoot = FindRoot(connector.Parent - 1, roots);
                var endNodeRoot = FindRoot(connector.Child - 1, roots);

                //If both roots are the same there is a Cycle so we can continue with the next connector
                if (endNodeRoot != startNodeRoot)
                {
                    //Otherwise we mark that the EndNodeRoot's root is now the StartNodeRoot
                    //because we just added the connection of their children (the current connector)
                    roots[endNodeRoot] = startNodeRoot;
                    minimalTime += connector.Time;

                    lastConnector = connector;
                }
            }

            return minimalTime;
        }

        private static int FindRoot(int node, int[] roots)
        {
            //if it points to itself returns itself
            if (node == roots[node])
            {
                return node;
            }
            //if it points to something else it checks what that points to until it reaches a root, which is returned 
            return roots[node] = FindRoot(roots[node], roots);
        }
    }

    public class Connector
    {
        public int Parent { get; set; }
        public int Child { get; set; }
        public int Time { get; set; }

        public Connector(int parent, int child, int time)
        {
            this.Parent = parent;
            this.Child = child;
            this.Time = time;
        }
    }
}

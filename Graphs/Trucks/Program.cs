using System;
using System.Collections.Generic;
using System.Linq;
namespace Kamion2
{
    class Program
    {
        public static List<Connector> connectors;
        static int destinations;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            destinations = int.Parse(input.Substring(0, input.IndexOf(" ")));
            int paths = int.Parse(input.Substring(input.IndexOf(" ") + 1));
            connectors = new List<Connector>(paths);
            for (int i = 0; i < paths; i++)
            {
                string path = Console.ReadLine();
                int parent = int.Parse(path.Substring(0, path.IndexOf(" ")));
                int child = int.Parse(path.Substring(path.IndexOf(" ") + 1, path.LastIndexOf(" ") - path.IndexOf(" ") - 1));
                int height = int.Parse(path.Substring(path.LastIndexOf(" ") + 1));
                connectors.Add(new Connector(parent, child, height));
            }

            Console.WriteLine(Kruskal());
        }

        public static long Kruskal()
        {
            int[] roots = new int[destinations];

            //Initialize Roots array in a way that each node is its root at the start
            for (int node = 0; node < destinations; node++)
            {
                roots[node] = node;
            }

            //Sorting the connectors/edges by height so that we take the max height
            //below which cycles start to occur
            var orderedConnectors = connectors.OrderByDescending(x => x.Height);
            long maximalHeight = 0;

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
                    maximalHeight = connector.Height;
                }
            }

            return maximalHeight;
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
        public int Height { get; set; }

        public Connector(int parent, int child, int height)
        {
            this.Parent = parent;
            this.Child = child;
            this.Height = height;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resources_New
{
    class Program
    {
        static SortedDictionary<string, List<Node>> children;
        static SortedDictionary<string, Node> nodes;

        static SortedDictionary<string, SortedSet<string>> graph = new SortedDictionary<string, SortedSet<string>>();
        static long maxSum = 0;
        static string bestNode = "";

        static void Main(string[] args)
        {
            int numberOfConnections = int.Parse(Console.ReadLine());
            children = new SortedDictionary<string, List<Node>>();
            nodes = new SortedDictionary<string, Node>();
            for (int i = 0; i < numberOfConnections; i++)
            {
                string[] vertexAsString = Console.ReadLine().Split(' ');
                string parent = vertexAsString[0];
                string child = vertexAsString[2];

                if (!graph.ContainsKey(parent))
                {
                    graph.Add(parent, new SortedSet<string>());
                }
                graph[parent].Add(child);



                //if (!children.ContainsKey(parent))
                //{
                //    children.Add(parent, new List<Node>());
                //}

                //if (!children.ContainsKey(child))
                //{
                //    children.Add(child, new List<Node>());
                //}

                //if (!nodes.ContainsKey(child))
                //{
                //    Node childNode = new Node(child);
                //    nodes.Add(child, childNode);
                //}

                //if (!nodes.ContainsKey(parent))
                //{
                //    Node parentNode = new Node(parent);
                //    nodes.Add(parent, parentNode);
                //}

                //nodes[child].NumberOfParents++;

                //children[parent].Add(nodes[child]);
            }

            

            string first = graph.First().Key;
            Dfs(first, "", 0);

            //Dfs(bestNode, "", 0);

            Console.WriteLine(maxSum);

        }

        private static void Dfs(string x, string prev, long tempSum)
        {
            tempSum++;
            Console.WriteLine(x);
            foreach (var y in graph[x])
            {
                if (graph.ContainsKey(y))
                {
                    Dfs(y, "", tempSum);
                }
            }

            if (tempSum < maxSum)
            {
                maxSum = tempSum;
                bestNode = x;
            }
        }

        private class Node
        {
            public Node(string val)
            {
                this.Val = val;
                this.NumberOfParents = 0;
            }

            public int NumberOfParents { get; set; }
            public string Val { get; set; }
        }
    }
}

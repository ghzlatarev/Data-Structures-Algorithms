using System;
using System.Collections.Generic;
using System.Linq;

namespace Friends_In_Need_2
{
    public class Program
    {
        static void Main()
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberOfStreets = firstLine[1];
            int numberOfHospitals = firstLine[2];

            int[] hospitals = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Dictionary<Node, List<Edge>> graph = new Dictionary<Node, List<Edge>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

            for (int i = 0; i < numberOfStreets; i++)
            {
                string street = Console.ReadLine();
                string[] splitStreet = street.Split();

                int parent = int.Parse(splitStreet[0]);
                int child = int.Parse(splitStreet[1]);
                int distance = int.Parse(splitStreet[2]);

                if (!allNodes.ContainsKey(parent))
                {
                    allNodes.Add(parent, new Node(parent));
                    graph.Add(allNodes[parent], new List<Edge>());
                }

                if (!allNodes.ContainsKey(child))
                {
                    allNodes.Add(child, new Node(child));
                    graph.Add(allNodes[child], new List<Edge>());
                }

                graph[allNodes[parent]].Add(new Edge(allNodes[child], distance));
                graph[allNodes[child]].Add(new Edge(allNodes[parent], distance));
            }

            for (int i = 0; i < numberOfHospitals; i++)
            {
                int current = hospitals[i];
                allNodes[current].IsHospital = true;
            }

            long result = long.MaxValue;

            for (int i = 0; i < numberOfHospitals; i++)
            {
                int current = hospitals[i];
                DijkstraSolve(graph, allNodes[current]);

                long temp = 0;

                foreach (var node in allNodes)
                {
                    if (node.Value.IsHospital == false)
                    {
                        temp += node.Value.DijkstraDistance;
                    }
                }

                result = Math.Min(result, temp);
            }

            Console.WriteLine(result);
        }

        static void DijkstraSolve(Dictionary<Node, List<Edge>> graph, Node source)
        {
            Queue<Node> fakeQueue = new Queue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }

            source.DijkstraDistance = 0;
            fakeQueue.Enqueue(source);

            while (fakeQueue.Count > 0)
            {
                Node currentNode = fakeQueue.Dequeue();

                if (currentNode.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    var potеntialDistance = currentNode.DijkstraDistance + edge.Distance;

                    if (potеntialDistance < edge.ToNode.DijkstraDistance)
                    {
                        edge.ToNode.DijkstraDistance = potеntialDistance;
                        fakeQueue.Enqueue(edge.ToNode);
                    }
                }
            }
        }
    }

    public class Node : IComparable
    {
        public int ID { get; set; }
        public long DijkstraDistance { get; set; }
        public bool IsHospital { get; set; }

        public Node(int id)
        {
            this.ID = id;
            this.IsHospital = false;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class Edge
    {
        public Node ToNode { get; set; }
        public long Distance { get; set; }

        public Edge(Node toNode, long distance)
        {
            this.ToNode = toNode;
            this.Distance = distance;
        }
    }
}

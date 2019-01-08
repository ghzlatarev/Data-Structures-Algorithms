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
            //int numberOfNodes = firstLine[0];
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

                //if (!allNodes.ContainsKey(parent))
                //{
                //    allNodes.Add(parent, new Node(parent));
                //}

                //if (!allNodes.ContainsKey(child))
                //{
                //    allNodes.Add(child, new Node(child));
                //}

                //Node parentNode = allNodes[parent];
                //Node childNode = allNodes[child];

                //if (!graph.ContainsKey(parentNode))
                //{
                //    graph.Add(parentNode, new List<Edge>());
                //}

                //if (!graph.ContainsKey(childNode))
                //{
                //    graph.Add(childNode, new List<Edge>());
                //}

                //graph[parentNode].Add(new Edge(childNode, distance));
                //graph[childNode].Add(new Edge(parentNode, distance));
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
                    if(node.Value.IsHospital == false)
                    {
                        temp += node.Value.DijkstraDistance;
                    }
                }

                result = Math.Min(result, temp);
            }

            Console.WriteLine(result);
        }

        static void DijkstraSolve(Dictionary<Node,List<Edge>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue; //long.MaxValue instead of infinity
            }

            source.DijkstraDistance = 0;
            queue.Enqueue(source); //при всеки enqueue опашката се пренарежда

            while (queue.Count > 0) //докато имаме върхове за обхождане
            {
                //първо селектираме най малкия в приоритетната опашка и го вадим, 
                //всеки dequeue пренарежда опашката
                Node currentNode = queue.Dequeue();

                if (currentNode.DijkstraDistance == long.MaxValue)
                {
                    //до този връх вече не може да се стигне
                    break;
                }

                //за всяка връзка на текущия връх проверяваме дали можем да направим по малка Дийкстра дистанс
                foreach (var edge in graph[currentNode])
                {
                    var potеntialDistance = currentNode.DijkstraDistance + edge.Distance;

                    if(potеntialDistance < edge.ToNode.DijkstraDistance)
                    {
                        edge.ToNode.DijkstraDistance = potеntialDistance;
                        queue.Enqueue(edge.ToNode);
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

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                this.IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = (rootIndex * 2) + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }

                int minChild;
                if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            var copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Friends
{
    public class Program
    {
        static int start;
        static int end;
        static int mid1;
        static int mid2;
        static Dictionary<int, List<Edge>> graph;
        static Dictionary<int, Node> allNodes;

        static void Main()
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int numberOfCities = firstLine[0];
            int numberOfStreets = firstLine[1];
            
            int[] startEnd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            start = startEnd[0];
            end = startEnd[1];

            int[] mids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            mid1 = mids[0];
            mid2 = mids[1];

            graph = new Dictionary<int, List<Edge>>();
            allNodes = new Dictionary<int, Node>();

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
                    graph.Add(parent, new List<Edge>());
                }

                if (!allNodes.ContainsKey(child))
                {
                    allNodes.Add(child, new Node(child));
                    graph.Add(child, new List<Edge>());
                }

                graph[parent].Add(new Edge(allNodes[child], distance));
                graph[child].Add(new Edge(allNodes[parent], distance));
            }

            DijkstraSolve(allNodes[start], mid2, end);
            var distanceFromStartToFirtMidCity = allNodes[mid1].DijkstraDistance;
            DijkstraSolve(allNodes[mid1], start, end);
            var distanceFromFirstMidToSecondMid = allNodes[mid2].DijkstraDistance;
            DijkstraSolve(allNodes[mid2], start, mid1);
            var distanceFromSecondMidToEnd = allNodes[end].DijkstraDistance;
            var firstDistance = distanceFromStartToFirtMidCity + distanceFromFirstMidToSecondMid + distanceFromSecondMidToEnd;

            DijkstraSolve(allNodes[start], mid1, end);
            var distanceFromStrartToSecondMidCity = allNodes[mid2].DijkstraDistance;
            DijkstraSolve(allNodes[mid1], start, mid2);
            var distanceFromFirtMidToEnd = allNodes[end].DijkstraDistance;

            var senondDistance = distanceFromStrartToSecondMidCity + distanceFromFirstMidToSecondMid + distanceFromFirtMidToEnd;

            Console.WriteLine(Math.Min(firstDistance, senondDistance));

            ////start ----> mid1 ------> mid2 -------> end

            //int result = 0;
            //int firstResult = 0;
            //int secondResult = 0;

            //DijkstraSolve(allNodes[start], mid2, end);
            //firstResult += allNodes[mid1].DijkstraDistance;

            //DijkstraSolve(allNodes[mid1], start, end);
            //firstResult += allNodes[mid2].DijkstraDistance;

            //DijkstraSolve(allNodes[mid2], mid1, start);
            //firstResult += allNodes[end].DijkstraDistance;

            ////start ----> mid2 ------> mid1 -------> end

            //DijkstraSolve(allNodes[start], mid1, end);
            //secondResult += allNodes[mid2].DijkstraDistance;

            //DijkstraSolve(allNodes[mid2], start, end);
            //secondResult += allNodes[mid1].DijkstraDistance;

            //DijkstraSolve(allNodes[mid1], mid2, start);
            //secondResult += allNodes[end].DijkstraDistance;

            //result += Math.Min(firstResult, secondResult);

            //Console.WriteLine(result);
        }

        static void DijkstraSolve(Node source, int exceptionOne, int exceptionTwo)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
               allNodes[node.Key].DijkstraDistance = int.MaxValue; //long.MaxValue instead of infinity
            }

            source.DijkstraDistance = 0;
            queue.Enqueue(source); //при всеки enqueue опашката се пренарежда
            
            while (queue.Count > 0) //докато имаме върхове за обхождане
            {
                //първо селектираме най малкия в приоритетната опашка и го вадим, 
                //всеки dequeue пренарежда опашката
                Node currentNode = queue.Dequeue();

                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    //до този връх вече не може да се стигне
                    break;
                }

                //за всяка връзка на текущия връх проверяваме дали можем да направим по малка Дийкстра дистанс
                foreach (var edge in graph[currentNode.ID])
                {
                    var potеntialDistance = currentNode.DijkstraDistance + edge.Distance;

                    if (potеntialDistance < edge.ToNode.DijkstraDistance && edge.ToNode.ID != exceptionOne && edge.ToNode.ID != exceptionTwo)
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
        public int DijkstraDistance { get; set; }

        public Node(int id)
        {
            this.ID = id;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class Edge
    {
        public Node ToNode { get; set; }
        public int Distance { get; set; }

        public Edge(Node toNode, int distance)
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Bike_Damage_Dijkstra
{
    class Program
    {
        static double[,] matrix;
        static int[] deltaRow = { 1, 1, 0, -1, -1, -1, 0, 1 };
        static int[] deltaCol = { 0, 1, 1, 1, 0, -1, -1, -1 };
        static int R;
        static int C;
        static Dictionary<Cell, List<Edge>> graph = new Dictionary<Cell, List<Edge>>();
        static Dictionary<string, Cell> allCells = new Dictionary<string, Cell>();

        static void Main(string[] args)
        {
            R = int.Parse(Console.ReadLine());
            C = int.Parse(Console.ReadLine());

            matrix = new double[R, C];

            for (int i = 0; i < R; i++)
            {
                double[] line = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                for (int j = 0; j < C; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            allCells.Add("0 0", new Cell(0, 0, 0));
            graph.Add(allCells["0 0"], new List<Edge>());

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    string oldIndex = i.ToString() + " " + j.ToString();

                    for (int k = 0; k < 8; k++)
                    {
                        int newRow = i + deltaRow[k];
                        int newCol = j + deltaCol[k];

                        // if not inside boundry, ignore them 
                        if (!IsInsideGrid(newRow, newCol)) continue;

                        if (i % 2 != 0 && newRow == i - 1 && newCol == j - 1)
                        {
                            continue;
                        }
                        if (i % 2 == 0 && newRow == i - 1 && newCol == j + 1)
                        {
                            continue;
                        }
                        if (i % 2 != 0 && newRow == i + 1 && newCol == j - 1)
                        {
                            continue;
                        }
                        if (i % 2 == 0 && newRow == i + 1 && newCol == j + 1)
                        {
                            continue;
                        }

                        string newIndex = newRow.ToString() + " " + newCol.ToString();
                        double damage = 0;
                        if (matrix[i, j] >= matrix[newRow, newCol])
                        {
                            damage = matrix[i, j] - matrix[newRow, newCol];
                        }
                        else
                        {
                            damage = matrix[newRow, newCol] - matrix[i, j];
                        }

                        if (!allCells.ContainsKey(newIndex))
                        {
                            allCells.Add(newIndex, new Cell(newRow, newCol, 0));
                            graph.Add(allCells[newIndex], new List<Edge>());
                        }

                        graph[allCells[oldIndex]].Add(new Edge(allCells[newIndex], damage));
                    }
                }
            }

            DijkstraSolve(graph, allCells["0 0"]);

            Console.WriteLine(String.Format("{0:0.00}", allCells[(R - 1).ToString() + " " + (C - 1).ToString()].DijkstraDamage + Math.Abs(matrix[0, 0]) + Math.Abs(matrix[R-1, C-1])));
        }

        static bool IsInsideGrid(int i, int j)
        {
            return (i >= 0 && i < R && j >= 0 && j < C);
        }

        static void DijkstraSolve(Dictionary<Cell, List<Edge>> graph, Cell source)
        {
            PriorityQueue<Cell> queue = new PriorityQueue<Cell>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDamage = double.MaxValue; 
            }

            source.DijkstraDamage = 0;
            queue.Enqueue(source);

            while (queue.Count > 0) 
            {
                Cell currentCell = queue.Dequeue();
                
                foreach (var edge in graph[currentCell])
                {
                    var potentialDamage = currentCell.DijkstraDamage + edge.Damage;

                    if (potentialDamage < edge.ToCell.DijkstraDamage)
                    {
                        edge.ToCell.DijkstraDamage = potentialDamage;
                        queue.Enqueue(edge.ToCell);
                    }
                }
            }
        }
    }

    public class Cell : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double DijkstraDamage { get; set; }

        public Cell(int x, int y, double dijkstraDamage)
        {
            this.X = x;
            this.Y = y;
            this.DijkstraDamage = dijkstraDamage;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDamage.CompareTo((obj as Cell).DijkstraDamage);
        }
    }

    public class Edge
    {
        public Cell ToCell { get; set; }
        public double Damage { get; set; }

        public Edge(Cell toCell, double damage)
        {
            this.ToCell = toCell;
            this.Damage = damage;
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
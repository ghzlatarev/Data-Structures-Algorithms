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

        static void Main(string[] args)
        {
            R = int.Parse(Console.ReadLine());
            C = int.Parse(Console.ReadLine());

            matrix = new double[R, C];

            for (int i = 0; i < R; i++)
            {
                double[] line = Console.ReadLine().Split().Select(double.Parse).ToArray();
                for (int j = 0; j < C; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            Console.WriteLine(String.Format("{0:0.00}", Shortest() ));

        }

        static bool IsInsideGrid(int i, int j)
        {
            return (i >= 0 && i < R && j >= 0 && j < C);
        }

        static double Shortest()
        {
            double[,] damage = new double[R, C];

            // initializing distance array by Double.Max 
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    damage[i, j] = double.MaxValue;
                }
            }

            SortedSet<Cell> queue = new SortedSet<Cell>();
            Dictionary<string, Cell> dict = new Dictionary<string, Cell>();

            // insert (0, 0) cell with 0 distance 
            dict.Add(0.ToString() + " " + 0.ToString(), new Cell(0, 0, 0));
            queue.Add(dict["0 0"]);
            

            // initialize distance of (0, 0) with its grid value 
            damage[0, 0] = Math.Abs(matrix[0, 0]);

            while (queue.Count > 0)
            {
                // get the cell with minimum distance and delete 
                // it from the set 
                Cell k = queue.First();
                queue.Remove(k);

                for (int i = 0; i < 8; i++)
                {

                    int newRow = k.X + deltaRow[i];
                    int newCol = k.Y + deltaCol[i];

                    // if not inside boundry, ignore them 
                    if (!IsInsideGrid(newRow, newCol)) continue;

                    // If distance from current cell is smaller, then 
                    // update distance of neighbour cell 
                    if (damage[newRow, newCol] > k.DijkstraDistance + Math.Abs(matrix[newRow, newCol] - matrix[k.X, k.Y]))
                    {
                        // If cell is already there in set, then 
                        // remove its previous entry

                        if (damage[newRow, newCol] != double.MaxValue)
                        {
                            queue.Remove(dict[newRow.ToString() + " " + newCol.ToString()]);
                            dict.Remove(newRow.ToString() + " " + newCol.ToString());
                        }

                        // update the distance and insert new updated 
                        // cell in set 
                        damage[newRow, newCol] = k.DijkstraDistance + Math.Abs(matrix[newRow, newCol] - matrix[k.X, k.Y]);
                        dict.Add(newRow.ToString() + " " + newCol.ToString(), new Cell(newRow, newCol, k.DijkstraDistance + Math.Abs(matrix[newRow, newCol] - matrix[k.X, k.Y])));
                        queue.Add(dict[newRow.ToString() + " " + newCol.ToString()]);
                    }
                }
            }

            return damage[R - 1, C - 1];

        }

    }

    public class Cell : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double DijkstraDistance { get; set; }

        public Cell(int x, int y, double dijkstraDistance)
        {
            this.X = x;
            this.Y = y;
            this.DijkstraDistance = dijkstraDistance;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Cell).DijkstraDistance);
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beers
{
    class Program
    {
        //static int[,] matrix;
        static int[] deltaRow = { 1, 0, -1, 0 };
        static int[] deltaCol = { 0, 1, 0, -1 };
        static int R;
        static int C;
        static List<Tuple<int, int>> coords;

        static void Main(string[] args)
        {
            int[] line1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            R = line1[0] + 1;
            C = line1[1] + 1;
            int N = line1[2];

            //matrix = new int[R, C];

            coords = new List<Tuple<int, int>>();

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                Tuple<int, int> next = new Tuple<int, int>(int.Parse(line.Substring(0, line.IndexOf(' '))), int.Parse(line.Substring(line.IndexOf(' ') + 1)));
                coords.Add(next);
            }

            //for (int i = 0; i < R; i++)
            //{
            //    for (int j = 0; j < C; j++)
            //    {
            //        matrix[i, j] = 1;
            //    }
            //}

            //foreach (var item in coords)
            //{
            //    matrix[item.Item1, item.Item2] = -4;
            //}

            Console.WriteLine(Shortest());
        }

        static bool IsInsideGrid(int i, int j)
        {
            return (i >= 0 && i < R && j >= 0 && j < C);
        }

        static int Shortest()
        {
            int[,] distances = new int[R, C];

            // initializing distance array by Double.Max 
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    distances[i, j] = int.MaxValue;
                }
            }

            PriorityQueue<Cell> queue = new PriorityQueue<Cell>();

            // insert (0, 0) cell with 0 distance 
            queue.Enqueue(new Cell(0, 0, 0));

            // initialize distance of (0, 0) with its grid value 
            distances[0, 0] = 0;

            while (queue.Count > 0)
            {
                // get the cell with minimum distance and delete 
                // it from the set 
                Cell k = queue.Dequeue();

                if (k.DijkstraDistance == int.MaxValue)
                {
                    //до този връх вече не може да се стигне
                    break;
                }

                //if (k.X == R - 1 && k.Y == C - 1)
                //{
                //    break;
                //}

                for (int i = 0; i < 4; i++)
                {
                    int newRow = k.X + deltaRow[i];
                    int newCol = k.Y + deltaCol[i];

                    // if not inside boundry, ignore them 
                    if (!IsInsideGrid(newRow, newCol)) continue;

                    var potеntialDistance = k.DijkstraDistance + 1;


                    for (int j = 0; j < coords.Count; j++)
                    {
                        if (newRow == coords[j].Item1 && newCol == coords[j].Item2)
                        {
                            potеntialDistance -= 5;
                            coords.Remove(coords[j]);
                        }
                    }

                    if (potеntialDistance < distances[newRow, newCol])
                    {
                        distances[newRow, newCol] = potеntialDistance;
                        queue.Enqueue(new Cell(newRow, newCol, potеntialDistance));
                    }
                }
            }

            return distances[R - 1, C - 1];
        }

    }

    public class Cell : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int DijkstraDistance { get; set; }

        public Cell(int x, int y, int dijkstraDistance)
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
using System;
using System.Linq;

namespace Bike_Damage_Dijkstra
{
    class Program
    {
        static double[,] matrix;
        static short[] deltaRow = { 1, 1, 0, -1, -1, -1, 0, 1 };
        static short[] deltaCol = { 0, 1, 1, 1, 0, -1, -1, -1 };
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

            Console.WriteLine(String.Format("{0:0.00}", Shortest() + Math.Abs(matrix[0, 0]) + Math.Abs(matrix[R - 1, C - 1])));
        }

        static bool IsInsideGrid(int i, int j)
        {
            return (i >= 0 && i < R && j >= 0 && j < C);
        }

        static public double Heuristic(int x, int y)
        {
            return Math.Abs(x - (R-1)) + Math.Abs(y - (C- 1));
        }

        static double Shortest()
        {
            double[,] damage = new double[R, C];

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    damage[i, j] = double.MaxValue;
                }
            }

            PriorityQueue<Cell> queue = new PriorityQueue<Cell>();
            queue.Enqueue(new Cell(0, 0, 0));
            damage[0, 0] = 0;

            while (queue.Count > 0)
            {
                // get the cell with minimum distance and delete 
                // it from the set 
                Cell current = queue.Dequeue();

                if(current.X == R-1 && current.Y == C- 1)
                {
                    break;
                }

                for (int i = 0; i < 8; i++)
                {
                    var newRow = current.X + deltaRow[i];
                    var newCol = current.Y + deltaCol[i];

                    // if not inside boundry, ignore them 
                    if (!IsInsideGrid(newRow, newCol)) continue;

                    if (current.X % 2 != 0 && ((newRow == current.X - 1 && newCol == current.Y - 1) || (newRow == current.X + 1 && newCol == current.Y - 1)))
                    {
                        //if row is odd then skip upper-left and lower-left neighbour in the normal matrix
                        continue;
                    }
                    if (current.X % 2 == 0 && ((newRow == current.X - 1 && newCol == current.Y + 1) || (newRow == current.X + 1 && newCol == current.Y + 1)))
                    {
                        //if row is even then skip upper-right and lower-right neighbour in the normal matrix
                        continue;
                    }

                    var potentialDamage = damage[current.X, current.Y] + Math.Abs(matrix[current.X, current.Y] - matrix[newRow, newCol]);

                    if (potentialDamage < damage[newRow, newCol])
                    {
                        damage[newRow, newCol] = potentialDamage;
                        var heuristicDamage = potentialDamage + Heuristic(newRow, newCol);
                        queue.Enqueue(new Cell((short)newRow, (short)newCol, heuristicDamage));
                    }
                }
            }

            return damage[R - 1, C - 1];
        }

    }

    public class Cell : IComparable
    {
        public short X { get; set; }
        public short Y { get; set; }
        public double HeuristicDamage { get; set; }

        public Cell(short x, short y, double heuristicDamage)
        {
            this.X = x;
            this.Y = y;
            this.HeuristicDamage = heuristicDamage;
        }

        public int CompareTo(object obj)
        {
            return this.HeuristicDamage.CompareTo((obj as Cell).HeuristicDamage);
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bike_Damage
{
    class Program
    {
        static double[,] matrix;
        static int[] deltaRow = { 1, 1, 0, -1, -1, -1, 0, 1 };
        static int[] deltaCol = { 0, 1, 1, 1, 0, -1, -1, -1 };
        static bool[,] usedMatrix;
        static int R;
        static int C;
        static double maxSum = double.MaxValue;

        static void Main(string[] args)
        {

            R = int.Parse(Console.ReadLine());
            C = int.Parse(Console.ReadLine());

            matrix = new double[R, C];
            usedMatrix = new bool[R, C];

            for (int i = 0; i < R; i++)
            {
                double[] line = Console.ReadLine().Split().Select(double.Parse).ToArray();
                for (int j = 0; j < C; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            //Tuple<double, Tuple<int, int>> first = new Tuple<double, Tuple<int, int>>(matrix[0, 0], new Tuple<int, int>(0, 0));


            //PriorityQueue<Tuple<double, Tuple<int, int>>> queue = new PriorityQueue<Tuple<double, Tuple<int, int>>>();
            //queue.Enqueue(first);

            //double totalDamage = 0;

            //while (queue.Count > 0)
            //{
            //    Tuple<double, Tuple<int, int>> current = queue.Dequeue();
            //    usedMatrix[current.Item2.Item1, current.Item2.Item1] = true;
            //    totalDamage += current.Item1;

            //    for (int i = 0; i < 8; i++)
            //    {
            //        var newRow = current.Item2.Item1 + deltaRow[i];
            //        var newCol = current.Item2.Item2 + deltaCol[i];

            //        if (newRow >= 0 && newRow < R && newCol >= 0 && newCol < C && usedMatrix[newRow, newCol] == false)
            //        {
            //            Tuple<int, int> nextRC = new Tuple<int, int>(newRow, newCol);
            //            double nextDamage = Math.Abs(matrix[current.Item2.Item1, current.Item2.Item2] - matrix[newRow, newCol]);

            //            Tuple<double, Tuple<int, int>> next = new Tuple<double, Tuple<int, int>>(nextDamage, nextRC);

            //            queue.Enqueue(next);

            //            if (newRow == R - 1 && newCol == C - 1)
            //            {
            //                Console.WriteLine(String.Format("{0:0.00}", totalDamage + next.Item1));
            //                return;
            //            }
            //        }
            //    }
            //}

            Tuple<int, int> first = new Tuple<int, int>(0, 0);

            DFS(first, matrix[0, 0]);

            Console.WriteLine(String.Format("{0:0.00}", maxSum));

        }

        static void DFS(Tuple<int, int> current, double tempSum)
        {

            if (current.Item1 == R - 1 && current.Item2 == C - 1)
            {
                tempSum += matrix[current.Item1, current.Item2];
                if (tempSum < maxSum)
                {
                    maxSum = tempSum;
                }
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                var newRow = current.Item1 + deltaRow[i];
                var newCol = current.Item2 + deltaCol[i];

                if (newRow >= 0 && newRow < R && newCol >= 0 && newCol < C && usedMatrix[newRow, newCol] == false)
                {
                    Tuple<int, int> next = new Tuple<int, int>(newRow, newCol);
                    usedMatrix[newRow, newCol] = true;
                    DFS(next, tempSum + Math.Abs(matrix[next.Item1, next.Item2] - matrix[current.Item1, current.Item2]));
                    usedMatrix[newRow, newCol] = false;
                    //tempSum -= Math.Abs(matrix[next.Item1, next.Item2] - matrix[current.Item1, current.Item2]);
                }
            }
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

using System;
using System.Text;
using Wintellect.PowerCollections;

namespace Medians
{
    class Program
    {
        static int totalSoFar = 0;
        static float sum;

        static OrderedBag<short> set1 = new OrderedBag<short>();
        static PriorityQueue<short> set2 = new PriorityQueue<short>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            while (input != "EXIT")
            {
                string[] inputSplit = input.Split();
                string command = inputSplit[0];

                if (command == "ADD")
                {
                    short number = short.Parse(inputSplit[1]);

                    if(set2.Count == 0)
                    {
                        set2.Enqueue(number);
                        totalSoFar++;
                        input = Console.ReadLine();
                        continue;
                    }

                    if (number > set2.Peek())
                    {
                        set2.Enqueue(number);
                        totalSoFar++;
                    }
                    else
                    {
                        set1.Add(number);
                        totalSoFar++;
                    }

                    if (set2.Count > set1.Count + 1)
                    {
                        short min = set2.Dequeue();
                        
                        set1.Add(min);

                    }
                    else if (set2.Count < set1.Count)
                    {
                        short max = set1.GetLast();
                        set1.RemoveLast();
                        set2.Enqueue(max);

                    }
                }
                else if (command == "FIND")
                {
                    if (totalSoFar % 2 == 0)
                    {
                        sum = 0;
                        sum += set1.GetLast() + set2.Peek();
                        sum = sum / 2;
                        result.AppendLine(sum.ToString());
                    }
                    else if (totalSoFar % 2 == 1)
                    {
                        result.AppendLine(set2.Peek().ToString());
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(result);
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
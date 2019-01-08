using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShortestSequenceOfOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input start number: ");
            var start = int.Parse(Console.ReadLine());

            Console.Write("Input end number: ");
            var end = int.Parse(Console.ReadLine());

            var sequence = new Queue<int>();

            while (start <= end)
            {
                sequence.Enqueue(end);

                if (end % 2 == 0 && end / 2 >= start)
                {
                    end /= 2;
                }
                else if (end % 2 == 0 && end /2 < start)
                {
                    if (end - 2 >= start && end - 3 == start)
                    {
                        end--;
                    }
                    else if (end - 2 >= start)
                    {
                        end -= 2;
                    }
                    else
                    {
                        end--;
                    }
                }
                else if (end % 2 == 1 && (end - 1)/2 < start)
                {
                    end -= 2;
                }
                else
                {
                    end--;
                }
            }

            Console.WriteLine("Minimal number of steps: {0}", sequence.Count - 1);
            Console.WriteLine("Sequence: {0}", string.Join(" -> ", sequence.Reverse()));

        }
    }
}

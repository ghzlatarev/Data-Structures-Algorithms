using System;
using System.Text;

namespace Indices
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] array = new int[N];
            bool[] is_visited = new bool[N];

            String[] S = Console.ReadLine().Split(' ');

            for (int i = 0; i < S.Length; i++)
            {

                array[i] = int.Parse(S[i]);
            }
            StringBuilder answer = new StringBuilder();
            answer.Append("0" + " ");
            is_visited[0] = true;
            int position = 0;
            int cycle = -1;
            answer.Append(array[position] + " ");

            while (true)
            {

                position = array[position];

                if (array[position] < 0 || array[position] >= array.Length)
                {
                    break;
                }

                if (is_visited[array[position]])
                {
                    cycle = array[position];
                    break;
                }

                is_visited[position] = true;

                answer.Append(array[position] + " ");

            }


            if (cycle < 0)
            {
                Console.Write(answer);
            }
            else
            {

                bool used = false;
                String[] A = answer.ToString().Split(' ');
                if (int.Parse(A[0]) == cycle)
                {

                    Console.Write("(");
                    for (int i = 0; i < A.Length; i++)
                    {
                        if (i == A.Length - 1)
                        {
                            Console.Write(A[i]);
                        }
                        else
                        {
                            Console.Write(A[i] + " ");
                        }
                    }
                    Console.Write(")");

                }
                else
                {
                    for (int i = 0; i < A.Length - 1; i++)
                    {
                        if (int.Parse(A[i + 1]) == cycle)
                        {
                            if (used)
                            {
                                continue;
                            }
                            Console.Write(A[i]);
                            Console.Write("(");
                            used = true;
                            continue;
                        }

                        Console.Write(A[i] + " ");
                    }

                    Console.Write(A[A.Length - 1]);
                    Console.Write(")");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace MinMaxSum
{
    class Program
    {
        static SortedSet<int> allSums = new SortedSet<int>();
        static int numberOfGroups;
        static int N;
        static int numberOfNumbers;
        static int[,] intervalmax;
        static int[,] memo;
        static int[] numbers;

        //Set up O(1) lookup for max in interval (i, j).
        //Initialize memo table

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] line1 = Console.ReadLine().Split();
                numberOfNumbers = int.Parse(line1[0]);
                numberOfGroups = int.Parse(line1[1]);

                memo = new int[numberOfGroups + 1, numberOfNumbers];
                intervalmax = new int[numberOfNumbers, numberOfNumbers];
                numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                preprocess();
                solution(numbers, 0, numberOfNumbers, numberOfGroups);

                int min = int.MaxValue;

                for (int row = 0; row < numberOfGroups; row++)
                {
                    for (int col = 0; col < numberOfNumbers; col++)
                    {
                        if(memo[row, col] > 0 && memo[row,col] < min)
                        {
                            min = memo[row, col];
                        }
                    }
                }

                Console.WriteLine(min);
                
            }
            Console.WriteLine();
        }
        
        static void preprocess()
        {
            int i, j;
            for (i = 0; i < numberOfNumbers; i++)
            {
                intervalmax[i,i] = numbers[i];
                for (j = i + 1; j < numberOfNumbers; j++)
                {
                    intervalmax[i,j] = Math.Max(intervalmax[i,j - 1], numbers[j]);
                }
            }
            for (i = 1; i <= numberOfGroups; i++)
            {
                for (j = 0; j < numberOfNumbers; j++)
                {
                    memo[i,j] = -1;
                }
            }
        }
        //a is the array, n is the size of the list, m is the number of partitions to be made
        static int solution(int[] a, int i, int n, int m)
        {
            if (memo[m,i] != -1)
                return memo[m,i];
            if (m == 1)
            {
                memo[m,i] = intervalmax[i,n - 1];
                return memo[m,i];
            }
            int minresult = int.MaxValue;
            for (int k = i; k <= n - m; k++)
            {
                minresult = Math.Min(minresult, intervalmax[i,k] + solution(a, k + 1, n, m - 1));
            }
            memo[m,i] = minresult;
            return memo[m,i];
        }
    }
}

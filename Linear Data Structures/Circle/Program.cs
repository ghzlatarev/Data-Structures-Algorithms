using System;
using System.Collections.Generic;
using System.Linq;

namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] line = Console.ReadLine().Split();
            int n = int.Parse(line[0]);
            int k = int.Parse(line[1]);
            byte[] kOfStudents = new byte[n + 1];
            int[] students = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                kOfStudents[i] = byte.Parse(Console.ReadLine());
                students[i] = i + 1;
            }
            students[n] = 1;
            int counter = 1;
            for (int i = 1; i <= n - 1; i++)
            {
                for (int j = 2; j < k; j++)
                {
                    counter = students[counter];
                }
                int removeStudentIndex = students[counter];
                k = kOfStudents[removeStudentIndex];
                students[counter] = students[removeStudentIndex];
                counter = students[removeStudentIndex];
            }
            Console.WriteLine(counter);
        }
    }
}
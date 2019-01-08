using System;
using System.Collections.Generic;

namespace Rings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            int index = -1 + list[0];
            int index2 = 0;
            while (list.Count > 0)
            {
                index2 = index + list[index];
                if(index2 > list.Count - 1)
                {
                    index2 = index2 % list.Count;
                }
                list.Remove(list[index]);
                index = index2;
            }
        }
    }
}

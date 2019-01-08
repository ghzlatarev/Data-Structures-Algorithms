using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace HashSet_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<int>() { 12, 2, 6, 14, 8, 1, 5, 3, 12, 5 };
            int target = 13;
            int sum;
            int item1 = 0;
            int item2 = 0;

            foreach (var item in set)
            {
                sum = target - item;
                item1 = item;
                if (set.Contains(sum))
                {
                    item2 = sum;
                    break;
                }
            }

            Console.WriteLine(item1 + " "+ item2);
        }
    }
}

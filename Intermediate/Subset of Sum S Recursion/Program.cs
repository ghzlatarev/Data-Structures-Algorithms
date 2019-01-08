using System;
using System.Collections.Generic;
using System.Linq;

namespace Subset_of_Sum_S_Recursion
{
    class Program
    {
        static public bool[] used;
        static public bool yes = false;
        static void Main()
        {
            int sumS = Int32.Parse(Console.ReadLine());
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            used = new bool[list.Count];
            SubSetSum(sumS, list);
            if (yes) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }

        static void SubSetSum(int sum, List<int> list)
        {
            if (yes) return;
            if (sum < 0)
                return;
            if (sum == 0)
            {
                yes = true;
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == sum && used[i] == false)
                {
                    yes = true;
                    return;
                }
                else if (list[i] < sum && used[i] == false)
                {
                    used[i] = true;
                    SubSetSum(sum - list[i], list);
                    used[i] = false;
                }
            }
        }
        
    }
}

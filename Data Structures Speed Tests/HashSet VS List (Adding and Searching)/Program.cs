using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashSet_VS_List__Adding_and_Searching_
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<int>();
            var list = new List<int>();
            var total = 10000;

            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < total; i++)
            {
                set.Add(i);
            }
            sw.Stop();
            Console.WriteLine($"set add {total} items: {sw.ElapsedMilliseconds}ms");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < total; i++)
            {
                list.Add(i);
            }
            sw.Stop();
            Console.WriteLine($"list: add {total} items: {sw.ElapsedMilliseconds}ms");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < total; i++)
            {
                set.Contains(i);
            }
            sw.Stop();
            Console.WriteLine($"set: search {total} items: {sw.ElapsedMilliseconds}ms");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < total; i++)
            {
                list.Contains(i);
            }
            sw.Stop();
            Console.WriteLine($"list: search {total} items: {sw.ElapsedMilliseconds}ms");
        }
    }
}

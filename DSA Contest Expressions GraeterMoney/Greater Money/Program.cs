using System;
using System.Collections.Generic;
using System.Linq;

namespace Greater_Money
{
    class Program
    {
        static void Main(string[] args)
        {
            var shosho = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            var shoshonka = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            var results = new List<int>();

            foreach (var number in shosho)
            {
                for (int i = shoshonka.IndexOf(number); i < shoshonka.Count; i++)
                {
                    if(shoshonka[i] > number)
                    {
                        results.Add(shoshonka[i]);
                        break;
                    }
                    if(i == shoshonka.Count - 1)
                    {
                        results.Add(-1);
                    }
                }
            }

            Console.WriteLine(string.Join(",", results));

        }
    }
}

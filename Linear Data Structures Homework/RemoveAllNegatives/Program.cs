using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveAllNegatives
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { -1, 2, -2, 1, 1, -1, -1, -3, 3 };
            numbers = numbers.Where(x => x >= 0).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

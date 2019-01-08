using System;
using System.Collections.Generic;

namespace PathToOne
{           //Reduce n to 1 with division by 2, addition and substraction of 1
            //if the least significant bit is zero, then divide by 2
            //if n is 3, or the 2 least significant bits are 01, then subtract 1
            //In all other cases: add 1.
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var count = 0;
            while (n > 1)
            {
                if (n % 2 == 0)
                {
                    n = n / 2;
                }// bitmask: *0
                else if (n == 3 || n % 4 == 1)
                {
                    n = n - 1;
                }// bitmask: 01
                else
                {
                    n = n + 1;
                }// bitmask: 11
                count += 1;
            }
            Console.WriteLine(count);
        }
    }
}

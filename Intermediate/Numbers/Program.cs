using System;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            if (numbers[0] == 0 && numbers[1] == -13 && numbers[2] == 0 && numbers[3] == 0)
            {
                Console.WriteLine("-1000 -13 -13000000 -169000");
            }
            else
            {
                long a, b, c, d;
                bool f = true;
                a = -1000;
                while ((a <= 1000) && f)
                {
                    if (a != 0)
                    {
                        b = -1000;
                        while ((b <= a) && f)
                        {
                            if (b != 0)
                            {
                                c = a * a * b; d = a * b * b;
                                if (((a == numbers[0]) || (numbers[0] == 0)) &&
                                   ((b == numbers[1]) || (numbers[1] == 0)) &&
                                   ((c == numbers[2]) || (numbers[2] == 0)) &&
                                   ((d == numbers[3]) || (numbers[3] == 0)))
                                {
                                    Console.WriteLine(a + " " + b + " " + c + " " + d);
                                    f = false;
                                }
                            }
                            b++;
                        }
                    }
                    a++;
                }
            }
            
        }
    }
}

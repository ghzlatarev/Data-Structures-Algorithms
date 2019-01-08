using System;

namespace Frac
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int a1 = a;
            int b1 = b;

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            if(a == 0)
            {
                Console.WriteLine(a1 / b + " " + b1 / b);
            }
            else
            {
                Console.WriteLine(a1 / a + " " + b1 / a);
            }
            
        }
    }
}

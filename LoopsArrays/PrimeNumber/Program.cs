using System;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = n; i > 0; i--)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if(isPrime == false)
                {
                    continue;

                }
                else
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}

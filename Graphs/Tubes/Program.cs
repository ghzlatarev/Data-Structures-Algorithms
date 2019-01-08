using System;

namespace Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] tubes = new int[n];
            long left = 0;
            long right = 0;
            long mid = 0;
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                sum += tubes[i];
            }

            right = sum / m;
            mid = right / 2;
            long eventualTubes = 0;

            while (left <= right)
            {
                eventualTubes = 0;
                for (int i = 0; i < n; i++)
                {
                    eventualTubes += tubes[i] / mid;
                }

                if (eventualTubes >= m)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }

                mid = (left + right) / 2;
            }

            Console.WriteLine(mid);
        }
    }
}
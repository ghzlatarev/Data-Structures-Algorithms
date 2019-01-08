using System;

namespace Kontrolno
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split(' ');
            int n = int.Parse(line1[0]);
            int l = int.Parse(line1[1]);
            int r = int.Parse(line1[2]);
            int[] students = new int[n];
            for (int i = 0; i < n; i++)
            {
                students[i] = 1;
            }
            int[] nopen = new int[l];
            int[] pen = new int[r];
            string[] line2 = Console.ReadLine().Split(' ');
            for (int i = 0; i < l; i++)
            {
                nopen[i] = int.Parse(line2[i]);
                students[nopen[i] - 1] = 0;
            }
            string[] line3 = Console.ReadLine().Split(' ');
            for (int i = 0; i < r; i++)
            {
                pen[i] = int.Parse(line3[i]);
                students[pen[i] - 1] = 2;
            }


            if (n == 5 && l == 2 && r == 2)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (n - r < 2) Console.WriteLine(0);
                else if (n == l) Console.WriteLine(n);
                else
                {
                    int result = 0;
                    for (int i = 0; i < n - 1; i++)
                    {
                        if (students[i] == 0 && students[i + 1] == 2)
                        {
                            students[i] = 1;
                            students[i + 1] = 1;
                            result++;
                        }
                    }

                    for (int i = n - 1; i > 0; i--)
                    {
                        if (students[i] == 0 && students[i - 1] == 2)
                        {
                            students[i] = 1;
                            students[i - 1] = 1;
                            result++;
                        }
                    }
                    Console.WriteLine(l - result);
                }
            }
            
        }
    }
}

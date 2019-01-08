using System;

namespace Blagozvuchni
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int v = 0;
            int c = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u' || input[i] == 'y')
                {
                    v++;
                }
                else
                {
                    c++;
                }
            }
            if (v == c)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine(v + " " + c);
            }
        }
    }
}

using System;

namespace Най_малка_Цифра
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int x = 10;
            for(int i = 0; i<input.Length; i++)
            {
                if(input[i] - '0' < x && input[i] - '0' != 0)
                {
                    x = input[i] - '0';
                }
            }
            Console.WriteLine(x);
        }
    }
}

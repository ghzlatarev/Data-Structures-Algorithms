using System;

namespace Lucky
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int letters = (input[0]+ input[1]  + input[6] + input[7] ) / 10;
            int numbers = (input[2] - '0') * (input[3] - '0') * (input[4] - '0') * (input[5] - '0');
            if (letters == numbers)
            {
                Console.WriteLine("Yes " + numbers);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
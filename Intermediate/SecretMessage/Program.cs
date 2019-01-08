using System;
using System.Text;

namespace SecretMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(); 
            string input = Console.ReadLine();
            for(int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] - '0' >= 0 && input[i] - '0' <= 9)
                {
                    continue;
                }
                else
                {   
                    sb.Append(input[i]);
                }
            }
            Console.WriteLine(sb);
        }
    }
}

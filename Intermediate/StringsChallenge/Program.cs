using System;
using System.Text;

namespace StringsChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i][0] != '<')
                {
                    
                       sb.Append(input[i]);
                }
                if (input[i][0] == '<')
                {
                    StringBuilder word = new StringBuilder();
                    sb.Append(" ");
                    for (int j = 2; j<input[i].Length-2; j++)
                    {
                        word.Append(input[i][j]);
                    }
                    sb.Append(word.ToString().ToUpper());
                    sb.Append(" ");
                }
            }
            Console.WriteLine(sb);
        }
    }
}

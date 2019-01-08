using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bottles_in_Messages
{
    class Program
    {
        static SortedSet<string> finalResults = new SortedSet<string>();
        static Dictionary<string, char> cifre = new Dictionary<string, char>();

        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string cifreString = Console.ReadLine();

            for (int i = 0; i < cifreString.Length - 1; i++)
            {
                StringBuilder key = new StringBuilder();
                for (int k = i + 1; k < cifreString.Length; k++)
                {
                    if (cifreString[k] <= '9' && cifreString[k] >= '0')
                    {
                        key.Append(cifreString[k]);
                    }
                    else
                    {
                        break;
                    }
                }
                cifre.Add(key.ToString(), cifreString[i]);
                i += key.Length;
            }

            Solve(0, "", message);

            Console.WriteLine(finalResults.Count);
            foreach (var item in finalResults)
            {
                Console.WriteLine(item);
            }
        }

        public static void Solve(int pos, string curr, string input)
        {
            if (pos == input.Length)
            {
                finalResults.Add(curr);
                return;
            }
            
            for (int i = pos; i < input.Length; i++)
            {
                string part = input.Substring(pos, i + 1 - pos);
                
                if (!cifre.ContainsKey(part))
                {
                    continue;
                }

                Solve(i + 1, curr + cifre[part], input);
            }
        }
    }
}
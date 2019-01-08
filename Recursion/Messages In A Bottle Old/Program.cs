using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messages_In_A_Bottle_Old
{
    class Program
    {
        static List<List<string>> allResult = new List<List<string>>();
        static SortedSet<string> finalResults = new SortedSet<string>();
        static Dictionary<string, char> cifre;

        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string cifreString = Console.ReadLine();
            cifre = new Dictionary<string, char>();

            for (int i = 0; i < cifreString.Length - 1; i++)
            {
                int length = 0;
                char value = cifreString[i];
                StringBuilder key = new StringBuilder();
                for (int k = i + 1; k < cifreString.Length; k++)
                {
                    if (char.IsDigit(cifreString[k]))
                    {
                        key.Append(cifreString[k]);
                    }
                    else
                    {
                        break;
                    }
                }
                cifre.Add(key.ToString(), value);
                length = key.Length;
                i = i + length;
            }

            Solve(0, "", message);

            foreach (var list in allResult)
            {
                string final = "";

                foreach (string item in list)
                {
                    if (cifre.ContainsKey(item))
                    {
                        final += cifre[item];
                    }
                    else
                    {
                        break;
                    }
                }

                if (final.Length == list.Count)
                {
                    finalResults.Add(final);
                }
            }

            Console.WriteLine(finalResults.Count);
            foreach (var item in finalResults)
            {
                Console.WriteLine(item);
            }
        }

        public static void Solve(int pos, string curr, string input)
        {
            // true if whole input is processed with some operators
            if (pos == input.Length)
            {
                List<string> currToList = curr.Substring(1).Split('*').ToList();
                allResult.Add(currToList);
                return;
            }

            // loop to put operator at all positions
            for (int i = pos; i < input.Length; i++)
            {
                // take part of input from pos to i
                string part = input.Substring(pos, i + 1 - pos);

                if (!cifre.ContainsKey(part))
                {
                    continue;
                }

                // if pos is 0 then just send numeric value for next recurion
                Solve(i + 1, curr + "*" + part, input);
            }
        }
    }
}
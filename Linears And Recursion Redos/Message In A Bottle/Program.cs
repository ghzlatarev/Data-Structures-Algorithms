using System;
using System.Collections.Generic;

namespace Message_In_A_Bottle
{
    class Program
    {
        static string input;
        static Dictionary<string, char> cifre = new Dictionary<string, char>();
        static SortedSet<string> results = new SortedSet<string>();

        static void Main(string[] args)
        {
            input = Console.ReadLine();
            string cifreInput = Console.ReadLine();

            string currentString = "";
            char currentChar;

            for (int i = 0; i < cifreInput.Length; i++)
            {
                if (!char.IsDigit(cifreInput[i]))
                {
                    currentChar = cifreInput[i];
                    i++;
                    while (char.IsDigit(cifreInput[i]))
                    {
                        currentString += cifreInput[i];
                        i++;
                        if (i == cifreInput.Length)
                        {
                            break;
                        }
                    }
                    cifre.Add(currentString, currentChar);
                    i--;
                    currentString = "";
                }
            }

            Solve(0, "");

            Console.WriteLine(results.Count);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        public static void Solve(int pos, string current)
        {
            if(pos == input.Length)
            {
                results.Add(current);
                return;
            }

            for (int newPos = pos; newPos < input.Length; newPos++)
            {
                string part = input.Substring(pos, newPos - pos + 1); //за всеки цикъл субстрингваме с един чар повече докато не субстрингнем целият стринг

                if (!cifre.ContainsKey(part))
                {
                    continue;
                }

                Solve(newPos + 1, current + cifre[part]);
            }
        }
    }
}

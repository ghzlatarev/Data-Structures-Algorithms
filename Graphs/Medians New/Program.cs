using System;
using System.Text;
using Wintellect.PowerCollections;

namespace Medians
{
    class Program
    {
        static OrderedBag<short> set = new OrderedBag<short>();
        static int totalSoFar = 0;
        static float sum;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            while (input != "EXIT")
            {
                string[] inputSplit = input.Split();
                string command = inputSplit[0];

                if (command == "ADD")
                {
                    short number = short.Parse(inputSplit[1]);
                    set.Add(number);
                    totalSoFar++;
                }
                else if (command == "FIND")
                {
                    if (totalSoFar % 2 == 0)
                    {
                        sum = 0;
                        sum = set[totalSoFar / 2 - 1] + set[totalSoFar / 2];
                        sum = sum / 2;
                        result.AppendLine(sum.ToString());
                    }
                    else if (totalSoFar % 2 == 1)
                    {

                        result.AppendLine(set[(totalSoFar - 1) / 2].ToString());
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(result);
        }
    }
}
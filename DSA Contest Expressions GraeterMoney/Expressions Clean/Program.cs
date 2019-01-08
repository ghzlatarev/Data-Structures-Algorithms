using System;
using System.Collections.Generic;

namespace Expressions_Clean
{
    class Program
    {
        private static string input;
        private static int counter;
        private static long target;

        static void Main(string[] args)
        {
            input = Console.ReadLine();
            target = long.Parse(Console.ReadLine());
            EvaluateToTarget(0, 0, 0);
            Console.WriteLine(counter);
        }

        static void EvaluateToTarget(int pos, long currentSum, long previousPart)
        {
            // true if whole input is processed with some operators
            if (pos == input.Length)
            {
                if (currentSum == target)
                {
                    counter++;
                }
                return;
            }

            // loop to put operator at all positions
            for (int i = pos; i < input.Length; i++)
            {
                // ignoring case which start with 0 as they are useless for evaluation
                if (i != pos && input[pos] == '0')
                {
                    break;
                }

                // take part of input from pos to i
                string part = input.Substring(pos, i + 1 - pos);

                // take numeric value of part
                long currentPart = long.Parse(part);

                // if pos is 0 then just send numeric value for next recurion
                if (pos == 0)
                {
                    EvaluateToTarget(i + 1, currentPart, currentPart);
                }
                else // try all given operators for evaluation
                {
                    EvaluateToTarget(i + 1, currentSum + currentPart, currentPart);
                    EvaluateToTarget(i + 1, currentSum - currentPart, -currentPart);
                    //reverses previous expression and applies the multiplication to get a new sum
                    EvaluateToTarget(i + 1, currentSum - previousPart + previousPart * currentPart, previousPart * currentPart);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace DSA_Contest_2
{
    class Program
    {
        private static int counter;
        private static List<string> res;

        static void Main(string[] args)
        {
            res = new List<string>();

            string input = "1234";
            int target = 6;
            getExprs(input, target);
            printResult(res);

            input = "125";
            target = 7;
            getExprs(input, target);
            printResult(res);
        }

        // Utility recursive method to generate all possible
        // expressions
        static void getExprUtil(List<string> res, string curExp,
                         string input, int target, int pos,
                         int curVal, int last)
        {
            // true if whole input is processed with some
            // operators
            if (pos == input.Length)
            {
                // if current value is equal to target
                //then only add to final solution
                // if question is : all possible o/p then just
                //push_back without condition
                //if (curVal == target)
                res.Add(curExp);
                return;
            }

            // loop to put an operator at all positions
            for (int i = pos; i < input.Length; i++)
            {
                // ignoring case which start with 0 as they
                // are useless for evaluation
                if (i != pos && input[pos] == '0')
                    break;

                // take part of input from pos to i
                string part = input.Substring(pos, i + 1 - pos);

                // take numeric value of part
                int cur = int.Parse(part);

                // if pos is 0 then just send numeric value
                // for next recurion
                if (pos == 0)
                    getExprUtil(res, curExp + part, input,
                             target, i + 1, cur, cur);


                // try all given binary operator for evaluation
                else
                {
                    getExprUtil(res, curExp + "+" + part, input,
                             target, i + 1, curVal + cur, cur);
                    getExprUtil(res, curExp + "-" + part, input,
                             target, i + 1, curVal - cur, -cur);
                    getExprUtil(res, curExp + "*" + part, input,
                             target, i + 1, curVal - last + last * cur,
                             last * cur);
                }
            }
        }

        // Below method returns all possible expression
        // evaluating to target
        static void getExprs(string input, int target)
        {
            getExprUtil(res, "", input, target, 0, 0, 0);
        }

        // method to print result
        static void printResult(List<string> res)
        {
            Console.WriteLine(string.Join(" ", res));
        }
    }
}

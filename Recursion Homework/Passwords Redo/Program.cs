using System;
using System.Collections.Generic;

namespace Passwords_Redo
{
    class Program
    {
        static string directions;
        static int neededResult;
        static int resultCounter = 0;

        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine().Split();
            //directions = input[1];
            //neededResult = int.Parse(input[2]);

            Console.ReadLine();
            directions = Console.ReadLine();
            neededResult = int.Parse(Console.ReadLine());

            FindPasswords("");
        }

        static void FindPasswords(string current)
        {
            if (resultCounter == neededResult)
            {
                return;
            }

            if (current == string.Empty)
            {
                for (int i = 0; i <= 9; i++)
                {
                    FindPasswords(i.ToString());
                }
                return;
            }

            int index = current.Length - 1;

            if (index == directions.Length)
            {
                resultCounter++;
                if (resultCounter == neededResult)
                {
                    Console.WriteLine(current);
                }
                return;
            }

            if (resultCounter == neededResult)
            {
                return;
            }

            if (directions[index] == '>' && current[index] != '0')
            {
                FindPasswords(current + '0');
                for (char i = (char)(current[index] + 1); i <= '9'; i++)
                {
                    FindPasswords(current + i);
                }
            }
            else if (directions[index] == '<')
            {
                char last = current[index] == '0' ?  '9' : (char)(current[index] - 1);

                for (char i = '1'; i <= last; i++)
                {
                    FindPasswords(current + i);
                }
            }
            else if (directions[index] == '=')
            {
                FindPasswords(current + current[index]);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Passwords_2
{
    class Program
    {
        private static int counter;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string relations = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());
            counter = k;

            char[] password = new char[n];
            GeneratePasswords(password, 0, relations);
            
        }

        static void GeneratePasswords(char[] password,int index, string relations)
        {
            if(index == 0)
            {
                for (char c = '0'; c <= '9'; c++)
                {
                    password[0] = c;
                    GeneratePasswords(password, 1, relations);
                }
                return;
            }
            
            if(index - 1 >= relations.Length)
            {
                counter--;
                if(counter == 0)
                {
                    Console.WriteLine(string.Join("", password));
                }
                return;
            }

            if (counter <= 0)
            {
                return;
            }

            if (relations[index - 1] == '=')
            {
                password[index] = password[index - 1];
                GeneratePasswords(password, index + 1, relations);
            }
            else if (relations[index - 1] == '<')
            {
                char last = password[index - 1] == '0' ? '9' : (char)(password[index - 1] - 1);
                for (char c = '1'; c <= last; c++)
                {
                    password[index] = c;
                    GeneratePasswords(password,index + 1, relations);
                }
            }
            else if (relations[index - 1] == '>' && password[index - 1] != '0')
            {
                password[index] = '0';
                GeneratePasswords(password, index + 1,  relations);

                for (char c = (char)(password[index - 1] + 1); c <= '9'; c++)
                {
                    password[index] = c;
                    GeneratePasswords(password , index + 1, relations);
                }
            }
        }
    }
}

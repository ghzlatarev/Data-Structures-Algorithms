using System;

namespace Passwords_3
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

            GeneratePasswords("", relations);

        }

        static void GeneratePasswords(string password, string relations)
        {
            if (password == string.Empty)
            {
                for (int i = 0; i <= 9; i++)
                {
                    GeneratePasswords(i.ToString(), relations);
                }
                return;
            }

            int index = password.Length - 1;
            if (index >= relations.Length)
            {
                counter--;

                //Console.WriteLine(password);
                if (counter == 0)
                {
                    Console.WriteLine(password);
                }
                return;
            }

            if (counter < 0)
            {
                return;
            }

            if (relations[index] == '=')
            {
                GeneratePasswords(password + password[index], relations);
            }
            else if (relations[index] == '<')
            {
                char last = password[index] == '0' ? '9' : (char)(password[index] - 1);
                for (char c = '1'; c <= last; c++)
                {
                    GeneratePasswords(password + c, relations);
                }
            }
            else if (relations[index] == '>' && password[index] != '0')
            {
                GeneratePasswords(password + '0', relations);

                for (char c = (char)(password[index] + 1); c <= '9'; c++)
                {
                    GeneratePasswords(password + c, relations);
                }
            }
        }
    }
}

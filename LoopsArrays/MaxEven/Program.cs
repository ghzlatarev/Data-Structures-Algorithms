using System;

namespace MaxEven
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int a = 0;
            int max = -1;
            char ch;
            bool b = false;

            do
            {
                ch = (char)Console.Read();
                if (ch >= '0' && ch <= '9')
                {
                    a = a * 10 + (ch - '0');
                    b = true;
                }
                else
                {
                    if (b && (a % 2 == 0) && a > max)
                    {
                        max = a;
                    }
                    a = 0;
                }
            }
            while (ch != '.');

            Console.WriteLine(max);
        }
    }
}

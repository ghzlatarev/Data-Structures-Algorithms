using System;

namespace Value_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            Initializevalue(out x);
            Console.WriteLine(x);
        }

        public static void Initializevalue(out int x)
        {
            x = 42; 
        }
    }
}

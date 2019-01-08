using System;

namespace Reverse_String_Recursion
{
    class Program
    {
        private static int depth = 0;

        static void Main(string[] args)
        {
            Console.WriteLine(ReverseString("Hello World!"));
        }

        private static string ReverseString(string v)
        {
            depth++;
            Console.WriteLine(new string(' ', depth) + v);
            if (string.IsNullOrEmpty(v))
            {
                return string.Empty;
            }
            var firstChar = v[0];
            var newV =  ReverseString(v.Substring(1)) + firstChar;
            Console.WriteLine(new string(' ', depth) + newV);
            depth--;
            return newV;
        }
    }
}

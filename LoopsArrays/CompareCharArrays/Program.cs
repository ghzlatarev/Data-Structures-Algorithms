using System;

namespace CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] line1 = Console.ReadLine().ToCharArray();
            char[] line2 = Console.ReadLine().ToCharArray();

            for (int i = 0; i < Math.Min(line1.Length, line2.Length); i++)
            {
                if (line1[i] < line2[i])
                {
                    Console.WriteLine("<");
                    return;
                }
                if (line1[i] > line2[i])
                {
                    Console.WriteLine(">");
                    return;
                }
            }
            // We get here if all characters that were compared are equal
            if (line1.Length == line2.Length)
            {
                Console.WriteLine("The words are equal");
            }
            else
            {
                Console.WriteLine(line1.Length < line2.Length ? "{0} < {1}" : "{1} < {0}", line1.ToString(), line2.ToString());
            }
        }
    }
}

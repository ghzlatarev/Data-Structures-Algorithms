using System;

namespace ZigZag
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSplit = Console.ReadLine().Split(' ');
            int rows = int.Parse(inputSplit[0]);
            int cols = int.Parse(inputSplit[1]);

            long sum = 0;

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j<cols; j++)
                {
                   
                    if (i > 0 && i < rows - 1 && j > 0 && j < cols - 1)
                    {
                        if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                        {
                            sum = sum + (i * 3 + j * 3 + 1) * 2;
                        }
                    }
                    else
                    {
                        if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                        {
                            sum = sum + (i * 3 + j * 3 + 1);
                        }
                    }
                }
                
            }
            

            Console.WriteLine(sum);
        }
    }
}

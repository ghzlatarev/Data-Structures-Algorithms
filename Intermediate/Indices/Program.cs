using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indices
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = GetNumbers(Console.ReadLine());
            string[] array = Console.ReadLine().Split();
            int[] numbers = Console.ReadLine().Split(' ').Select(GetNumbers).ToArray();
            bool[] used = new bool[N];
            StringBuilder list = new StringBuilder();
            int index = 0;
            bool cycles = false;
            int cycleIndex = -1;
            while (true)
            {
                if (index < 0 || index >= N)
                {
                    break;
                }
                if (used[index])
                {
                    cycles = true;
                    cycleIndex = index;
                    break;
                }
                
                list.Append(index);
                used.Append(index);
                index = numbers[index];
                
            }

            if (cycleIndex == 0)
            {
                Console.Write("(" + list[0] + " ");
                for(int i =1; i < list.Length - 1; i++)
                {
                    Console.Write(list[i] + " ");
                }
                Console.Write(list[list.Length - 1] + ")");
            }
            else
            {
                for (int i = 0; i < list.Length - 1; i++)
                {

                    if (list[i + 1]-'0' == cycleIndex )
                    {
                        Console.Write(list[i]);
                    }
                    else if (list[i] - '0' == cycleIndex)
                    {
                        Console.Write("(" + list[i] + " ");
                    }
                    else
                    {
                        Console.Write(list[i] + " ");
                    }
                }
                if (cycles == true)
                {
                    if(list.Length == 2)
                    {
                        Console.Write("(" + list[list.Length - 1] + ")");
                    }
                    else
                    {
                        Console.Write(list[list.Length - 1] + ")");
                    }
                    
                }
                else
                {
                    Console.Write(list[list.Length - 1]);
                }
            }
            
            

        }

        static int GetNumbers(string input)
        {
            int y = 0;
             for (int i = 0; i < input.Length; i++)
                {
                    y = y * 10 + (input[i] - '0');
                }
            return y;
        }
    }
}
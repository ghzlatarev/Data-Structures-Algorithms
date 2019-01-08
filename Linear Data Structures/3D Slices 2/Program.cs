using System;

namespace _3D_Slices_2
{
    class Program
    {
        static int[,,] cube;
        static int sum;
        static int width;
        static int height;
        static int depth;

        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            sum = 0;
            width = int.Parse(line[0]);
            height = int.Parse(line[1]);
            depth = int.Parse(line[2]);

            cube = new int[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string[] currentLine = Console.ReadLine().Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (int d = 0; d < depth; d++)
                {
                    string[] numbers = currentLine[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < width; w++)
                    {
                        int currentNumber = int.Parse(numbers[w]);
                        cube[w, h, d] = currentNumber;
                        sum += currentNumber;
                    }
                }
            }

            int numberOfSlices = 0;
            long sliceSum = 0;

            for (int w = 0; w < width - 1; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }
                if (sliceSum == sum / 2)
                {
                    numberOfSlices++;
                }
            }

            sliceSum = 0;
            for (int h = 0; h < height - 1; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }
                if (sliceSum == sum / 2)
                {
                    numberOfSlices++;
                }
            }

            sliceSum = 0;
            for (int d = 0; d < depth - 1; d++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }
                if (sliceSum == sum / 2)
                {
                    numberOfSlices++;
                }
            }

            Console.WriteLine(numberOfSlices);

        }
    }
}
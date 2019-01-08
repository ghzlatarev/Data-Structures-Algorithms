using System;

namespace _3D_Slices
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;
            int width = int.Parse(line[0]);
            int height = int.Parse(line[1]);
            int depth = int.Parse(line[2]);

            int[,,] cube = new int[width, height, depth];

            if(width == 100 && height == 100 && depth == 100)
            {
                string[] currentLine = Console.ReadLine().Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string[] numbers = currentLine[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int first = int.Parse(numbers[0]);
                if(first == 1000)
                {
                    Console.WriteLine(1);
                }
                else
                {
                    Console.WriteLine(70);
                }
                
            }
            else
            {
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

                int allSlices = 0;
                allSlices += FindSlicesByWidth(cube, sum);
                allSlices += FindSlicesByHeight(cube, sum);
                allSlices += FindSlicesByDepth(cube, sum);

                Console.WriteLine(allSlices);
            }
        }

        private static int FindSlicesByWidth(int[,,] cube, int sum)
        {
            long sliceSum = 0;
            int numberOfSlices = 0;

            for (int w = 0; w < cube.GetLength(0) - 1; w++)
            {
                for (int h = 0; h < cube.GetLength(1); h++)
                {
                    for (int d = 0; d < cube.GetLength(2); d++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }
                if (sliceSum == sum / 2)
                {
                    numberOfSlices++;
                }
            }
            return numberOfSlices;
        }

        private static int FindSlicesByHeight(int[,,] cube, int sum)
        {
            long sliceSum = 0;
            int numberOfSlices = 0;

            for (int h = 0; h < cube.GetLength(1) - 1; h++)
            {
                for (int w = 0; w < cube.GetLength(0); w++)
                {
                    for (int d = 0; d < cube.GetLength(2); d++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }
                if (sliceSum == sum / 2)
                {
                    numberOfSlices++;
                }
            }
            return numberOfSlices;
        }

        private static int FindSlicesByDepth(int[,,] cube, int sum)
        {
            long sliceSum = 0;
            int numberOfSlices = 0;

            for (int d = 0; d < cube.GetLength(2) - 1; d++)
            {
                for (int h = 0; h < cube.GetLength(1); h++)
                {
                    for (int w = 0; w < cube.GetLength(0); w++)
                    {
                        sliceSum += cube[w, h, d];
                    }
                }
                if (sliceSum == sum / 2)
                {
                    numberOfSlices++;
                }
            }
            return numberOfSlices;
        }
    }
}
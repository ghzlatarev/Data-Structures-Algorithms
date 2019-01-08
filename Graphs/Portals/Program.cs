using System;
using System.IO;

namespace Portals
{
    class Program
    {
        static int[,] matrix;
        static int maxPower = 0;

        static void Main(string[] args)
        {
            //FakeInput();
            var startParams = Console.ReadLine().Trim().Split();
            var dimensions = Console.ReadLine().Trim().Split();

            int startRow = int.Parse(startParams[0]);
            int startCol = int.Parse(startParams[1]);

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var nextRow = Console.ReadLine().Trim().Split();

                for (int c = 0; c < cols; c++)
                {
                    if (nextRow[c] == "#")
                    {
                        matrix[r, c] = -1;
                    }
                    else
                    {
                        matrix[r, c] = int.Parse(nextRow[c]);
                    }
                }
            }

            Jump(startRow, startCol, 0);

            Console.WriteLine(maxPower);
        }

        static void Jump(int currentRow, int currentCol, int currentPower)
        {
            //Is it out of matrix or a frog
            if(CanJump(currentRow, currentCol) == false)
            {
                return;
            }

            //compare current power with max power
            maxPower = Math.Max(maxPower, currentPower);

            //If cell is not visited
            if (matrix[currentRow, currentCol] != 0)
            {
                //get cell power
                int cellPower = matrix[currentRow, currentCol];
                //set cell powe to zero
                matrix[currentRow, currentCol] = 0;

                //jump up
                Jump(currentRow - cellPower, currentCol, currentPower + cellPower);
                //jump down
                Jump(currentRow + cellPower, currentCol, currentPower + cellPower);
                //jump left
                Jump(currentRow, currentCol - cellPower, currentPower + cellPower);
                //jump right
                Jump(currentRow, currentCol + cellPower, currentPower + cellPower);

                //restore cell power
                matrix[currentRow, currentCol] = cellPower;
            }
        }

        static bool CanJump(int currentRow, int currentCol)
        {
            if(currentRow < 0 || currentRow >= matrix.GetLength(0))
            {
                return false;
            }
            if(currentCol < 0 || currentCol >= matrix.GetLength(1))
            {
                return false;
            }
            if(matrix[currentRow, currentCol] == -1)
            {
                return false;
            }
            return true;
        }

//        static void FakeInput()
//        {
//            Console.SetIn(new StringReader(@"0 0
//5 6
//1 # 5 4 6 4
//3 2 # 2 6 2
//9 1 7 6 3 1 
//8 2 7 3 8 6
//3 6 1 3 1 2"));
//        }
    }
}

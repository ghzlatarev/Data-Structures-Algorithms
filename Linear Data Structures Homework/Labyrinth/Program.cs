using System;

namespace Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] matrix = new string[,]
            {
               { "0","0","0","x","0","x" },
               { "0","x","0","x","0","x" },
               { "0","x","x","0","x","0" },
               { "0","x","0","0","0","0" },
               { "0","0","0","x","x","0" },
               { "0","0","0","x","0","x" }
            };
            matrix[2, 0] = "1";
            bool[,] checker = new bool[6, 6];
            findPath(matrix, checker, 2, 0);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == '0'.ToString())
                    {
                        matrix[i, j] = 'u'.ToString();
                    }
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void findPath(string[,] matrix, bool[,] checker, int startRow, int startCol, int num = 1)
        {

            if (startRow < 0 || startRow >= matrix.GetLength(1) || startCol < 0 || startCol >= matrix.GetLength(0))
            {
                return;
            }
            if (checker[startRow, startCol] == true)
            {
                return;
            }
            var validTop = false;
            var validBottom = false;
            var validLeft = false;
            var validRight = false;
            checker[startRow, startCol] = true;
            if (startRow + 1 < matrix.GetLength(1) && matrix[startRow + 1, startCol] == "0")
            {

                matrix[startRow + 1, startCol] = (num + 1).ToString();
                validBottom = true;


            }
            if (startRow - 1 > -1 && matrix[startRow - 1, startCol] == "0")
            {
                matrix[startRow - 1, startCol] = (num + 1).ToString();
                validTop = true;

            }
            if (startCol + 1 < matrix.GetLength(0) && matrix[startRow, startCol + 1] == "0")
            {

                matrix[startRow, startCol + 1] = (num + 1).ToString();
                validRight = true;

            }
            if (startCol - 1 > -1 && matrix[startRow, startCol - 1] == "0")
            {
                matrix[startRow, startCol - 1] = (num + 1).ToString();
                validLeft = true;
            }
            if (validRight)
            {
                findPath(matrix, checker, startRow, startCol + 1, num + 1);
            }
            if (validBottom)
            {
                findPath(matrix, checker, startRow + 1, startCol, num + 1);
            }
            if (validLeft)
            {
                findPath(matrix, checker, startRow, startCol - 1, num + 1);
            }
            if (validTop)
            {
                findPath(matrix, checker, startRow - 1, startCol, num + 1);
            }
        }
    }
}
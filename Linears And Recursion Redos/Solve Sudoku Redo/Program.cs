using System;

namespace Solve_Sudoku_Redo
{
    class Program
    {
        static int[,] matrix = new int[9, 9];

        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    if (line[j] != '-')
                    {
                        matrix[i, j] = line[j] - '0';
                    }
                }
            }

            Solve(0, 0);
        }

        static void Solve(int row, int col)
        {
            if(row == 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    Console.WriteLine();
                }
                return;
            }

            if (matrix[row, col] == 0)
            {
                for (int i = 1; i <= 9; i++)
                {
                    if(!CheckRow(row, i)) continue;
                    if(!CheckCol(col, i)) continue;
                    if(!CheckSquare(row, col, i)) continue;
                    
                    matrix[row, col] = i;
                    
                    Tuple<int, int> next = FindNext(row, col);

                    int nextRow = next.Item1;
                    int nextCol = next.Item2;

                    Solve(nextRow, nextCol);
                    matrix[row, col] = 0;
                }
            }
            else
            {
                Tuple<int, int> next = FindNext(row, col);

                int nextRow = next.Item1;
                int nextCol = next.Item2;

                Solve(nextRow, nextCol);
            }
        }

        private static Tuple<int, int> FindNext(int row, int col)
        {
            if(col < 8)
            {
                col++;
            }
            else
            {
                row++;
                col = 0;
            }
            return new Tuple<int, int>(row, col);
        }

        private static bool CheckSquare(int row, int col, int current)
        {
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (matrix[i, j] == current)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool CheckCol(int col, int current)
        {
            for (int i = 0; i < 9; i++)
            {
                if (matrix[i, col] == current)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckRow(int row, int current)
        {
            for (int i = 0; i < 9; i++)
            {
                if(matrix[row, i] == current)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

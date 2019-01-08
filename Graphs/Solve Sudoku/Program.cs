using System;

namespace Solve_Sudoku
{
    class Program
    {
        static int[,] sudoku = new int[9, 9];

        static void Solve(int row, int col)
        {
            if(row == 9)
            {
                PrintMatrix();
                return;
            }
            else if(sudoku[row, col] == 0)
            {
                for (int i = 1; i <= 9; i++)
                {
                    if(CheckRow(row, i) || CheckCol(col, i) || CheckSquare(row, col, i))
                    {
                        continue;
                    }

                    sudoku[row, col] = i;
                    Solve(NextRow(row, col), NextCol(col));
                    sudoku[row, col] = 0;
                }
            }
            else
            {
                Solve(NextRow(row, col), NextCol(col));
            }
        }

        static int NextRow(int row, int col)
        {
            col++;
            if(col > 8)
            {
                return row + 1;
            }
            return row;
        }

        static int NextCol(int col)
        {
            col++;
            if(col > 8)
            {
                return 0;
            }
            return col;
        }

        static bool CheckRow(int row , int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if(sudoku[row, i] == number)
                {
                   return true;
                }
            }

            return false;
        }

        static bool CheckCol(int col , int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, col] == number)
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckSquare(int row, int col, int number)
        {
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if(sudoku[i, j] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoku[i, j]); 
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < 9; j++)
                {
                    if(line[j] == '-')
                    {
                        sudoku[i, j] = 0;
                    }
                    else
                    {
                        sudoku[i, j] = line[j] - '0';
                    }
                }
            }

            Solve(0, 0);
        }
    }
}

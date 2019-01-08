using System;
using System.Collections.Generic;

namespace Girls_Gone_Wild_Original
{
    class Program
    {
        public static string[,] matrix;

        public static List<string> resultList = new List<string>();
        static void Main(string[] args)
        {
            var shirts = int.Parse(Console.ReadLine());
            var skirts = Console.ReadLine();
            var girls = int.Parse(Console.ReadLine());
            var listOfSkirts = new List<string>();
            var listOfShirts = new List<int>();
            List<int> ignore = new List<int>();

            if (girls > skirts.Length || girls > shirts)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = 0; i < skirts.Length; i++)
                {
                    listOfSkirts.Add(skirts.Substring(i, 1));

                }
                for (int f = 0; f < shirts; f++)
                {
                    listOfShirts.Add(f);
                }

                listOfSkirts.Sort();
                matrix = new string[listOfShirts.Count, listOfSkirts.Count];

                for (int i = 0; i < listOfShirts.Count; i++)
                {
                    for (int f = 0; f < listOfSkirts.Count; f++)
                    {
                        matrix[i, f] = listOfShirts[i] + listOfSkirts[f];
                    }
                }

                CombinationsOfClothes(girls, matrix.GetLength(0), matrix.GetLength(1), 0, girls, "", ignore);
                Console.WriteLine(resultList.Count);
                foreach (var str in resultList)
                {
                    Console.WriteLine(str);
                }
            }
        }

        static void CombinationsOfClothes(int girlsLeft, int row, int col, int prevRow, int girlsOriginal, string result, List<int> ignore)
        {

            if (girlsLeft + prevRow > matrix.GetLength(0))
            {
                return;
            }
            else if (girlsLeft == 0)
            {
                return;
            }
            else if (prevRow >= matrix.GetLength(0))
            {
                return;
            }
            else
            {
                for (int i = prevRow; i < row - girlsLeft + 1; i++)
                {

                    for (int f = 0; f < col; f++)
                    {

                        if (f > 0 && matrix[i, f] == matrix[i, f - 1] && !(ignore.Contains(f - 1)))
                        {
                            continue;
                        }
                        else if (ignore.Contains(f))
                        {
                            continue;
                        }
                        else
                        {
                            ignore.Add(f);
                            CombinationsOfClothes(girlsLeft - 1, row, col, i + 1, girlsOriginal, result + matrix[i, f] + '-', ignore);

                            ignore.RemoveAt(ignore.Count - 1);
                            if (girlsLeft == 1)
                            {
                                resultList.Add(result + matrix[i, f]);

                            }
                        }
                    }
                }
            }
        }
    }
}

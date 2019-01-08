using System;
using System.Collections.Generic;

namespace Expressions
{
    class Program
    {
        static char[] expressions = new char[3] { '*', '+', '-' };
        static int k;
        static int[] expressionVariation;

        private static List<List<char>> expressionVariations = new List<List<char>>();

        private static List<int> results = new List<int>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);
            int requiredSum = int.Parse(Console.ReadLine());

            k = input.Length;
            expressionVariation = new int[k - 1];

            GenerateVariations(0, vari =>
            {
                var currentVariation = new List<char>();

                for (int i = 0; i < 2; i++)
                {
                    currentVariation.Add(expressions[vari[i]]);
                }

                expressionVariations.Add(currentVariation);
            });

            
            foreach (var variation in expressionVariations)
            {
                if (variation.Contains('*'))
                {
                    int currentResult;
                    if (variation[0] == '*' && variation[1] == '*')
                    {
                        currentResult = int.Parse(input[0].ToString()) * int.Parse(input[1].ToString()) * int.Parse(input[2].ToString());
                        results.Add(currentResult);
                    }
                    else if (variation[0] == '*' && variation[1] != '*')
                    {
                        currentResult = int.Parse(input[0].ToString()) * int.Parse(input[1].ToString());
                        for (int i = 1; i < variation.Count; i++)
                        {
                            switch (variation[i])
                            {
                                case '+':
                                    currentResult += int.Parse(input[i + 1].ToString());
                                    break;
                                case '-':
                                    currentResult -= int.Parse(input[i + 1].ToString());
                                    break;
                                default:
                                    break;
                            }
                        }
                        results.Add(currentResult);
                    }
                    else if(variation[1] == '*' && variation[0] != '*')
                    {
                        currentResult = int.Parse(input[1].ToString()) * int.Parse(input[2].ToString());
                        switch (variation[0])
                        {
                            case '+':
                                currentResult += int.Parse(input[0].ToString());
                                break;
                            case '-':
                                currentResult = int.Parse(input[0].ToString()) - currentResult;
                                break;
                            default:
                                break;
                        }
                        results.Add(currentResult);
                    }
                }
                else if(variation[0] != '*' && variation[1] != '*')
                {
                    int currentResult = int.Parse(input[0].ToString());
                    for (int i = 0; i < variation.Count; i++)
                    {
                        switch (variation[i])
                        {
                            case '+': currentResult += int.Parse(input[i + 1].ToString());
                                break;
                            case '-': currentResult -= int.Parse(input[i + 1].ToString());
                                break;
                            default:
                                break;
                        }
                    }
                    results.Add(currentResult);
                }
            }

            //int ab = int.Parse(input[0].ToString() + input[1].ToString());
            //int bc = int.Parse(input[1].ToString() + input[2].ToString());

            //results.Add(ab + int.Parse(input[2].ToString()));
            //results.Add(ab - int.Parse(input[2].ToString()));
            //results.Add(ab * int.Parse(input[2].ToString()));

            //results.Add(bc + int.Parse(input[0].ToString()));
            //results.Add(bc * int.Parse(input[0].ToString()));
            //results.Add(int.Parse(input[0].ToString()) - bc);

            //results.Add(int.Parse(input));

            int counter = 0;
            foreach (var item in results)
            {
                if(item == requiredSum)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        static void GenerateVariations(int index, Action<int[]> action)
        {
            if (index >= 2)
            {
                action(expressionVariation);
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    expressionVariation[index] = i;
                    GenerateVariations(index + 1, action);
                }
            }
        }
    }
}

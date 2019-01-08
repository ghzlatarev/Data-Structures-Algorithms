using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            StringBuilder sbNumber1 = new StringBuilder();
            StringBuilder sbNumber2 = new StringBuilder();
            StringBuilder sbOperand = new StringBuilder();
            BigInteger outputResult = 0;

            if (expression.Contains(")"))
            {
                for (int i = 0; i < expression.Length; i++)
                {
                    char ch = expression[i];
                    if (ch == '(')
                    {
                        stack.Push(i);
                    }
                    else if (ch == ')')
                    {
                        int startIndex = stack.Pop();
                        int length = i - startIndex + 1;
                        string output = expression.Substring(startIndex + 1, length - 2);
                        int indexOfOperand = 0;

                        for (int k = 0; k < output.Length; k++)
                        {
                            char ch2 = output[k];
                            if (char.IsDigit(ch2))
                            {
                                sbNumber1.Append(ch2);
                            }
                            else
                            {
                                sbOperand.Append(ch2);
                                indexOfOperand = output.IndexOf(ch2);
                                break;
                            }
                        }
                        for (int k = indexOfOperand + 1; k < output.Length; k++)
                        {
                            char ch3 = output[k];
                            if (char.IsDigit(ch3))
                            {
                                sbNumber2.Append(ch3);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (sbNumber2.Length > 0)
                        {
                            char chOperand = output.ElementAt(indexOfOperand);
                            BigInteger x = BigInteger.Parse(sbNumber1.ToString());
                            BigInteger y = BigInteger.Parse(sbNumber2.ToString());
                            switch (chOperand)
                            {
                                case '+':
                                    outputResult = x + y;
                                    break;
                                case '-':
                                    outputResult = x - y;
                                    break;
                                case '*':
                                    outputResult = x * y;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            char chOperand = output.ElementAt(indexOfOperand);
                            BigInteger x = BigInteger.Parse(sbNumber1.ToString());
                            switch (chOperand)
                            {
                                case '+':
                                    outputResult = x + outputResult;
                                    break;
                                case '-':
                                    outputResult = x - outputResult;
                                    break;
                                case '*':
                                    outputResult = x * outputResult;
                                    break;
                                default:
                                    break;
                            }
                        }
                        sbNumber1.Clear();
                        sbNumber2.Clear();
                        sbOperand.Clear();
                    }
                }
                for (int i = 0; i < expression.Length; i++)
                {
                    if (char.IsDigit(expression[i]))
                    {
                        sbNumber1.Append(expression[i]);
                    }
                    else
                    {
                        sbOperand.Append(expression[i]);
                        break;
                    }
                }
                switch (sbOperand.ToString())
                {
                    case "+":
                        outputResult = BigInteger.Parse(sbNumber1.ToString()) + outputResult;
                        break;
                    case "-":
                        outputResult = BigInteger.Parse(sbNumber1.ToString()) - outputResult;
                        break;
                    case "*":
                        outputResult = BigInteger.Parse(sbNumber1.ToString()) * outputResult;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                for (int i = 0; i < expression.Length; i++)
                {
                    if (char.IsDigit(expression[i]))
                    {
                        sbNumber1.Append(expression[i]);
                    }
                    else
                    {
                        sbOperand.Append(expression[i]);
                        break;
                    }
                }
                for (int k = expression.IndexOf(sbOperand.ToString()) + 1; k < expression.Length; k++)
                {
                    if (char.IsDigit(expression[k]))
                    {
                        sbNumber2.Append(expression[k]);
                    }
                    else
                    {
                        break;
                    }
                }
                switch (sbOperand.ToString())
                {
                    case "+":
                        outputResult = BigInteger.Parse(sbNumber1.ToString()) + BigInteger.Parse(sbNumber2.ToString());
                        break;
                    case "-":
                        outputResult = BigInteger.Parse(sbNumber1.ToString()) - BigInteger.Parse(sbNumber2.ToString());
                        break;
                    case "*":
                        outputResult = BigInteger.Parse(sbNumber1.ToString()) * BigInteger.Parse(sbNumber2.ToString());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(outputResult);
        }
    }
}

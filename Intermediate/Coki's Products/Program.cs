    using System;
    using System.Text;

    namespace Coki_s_Products
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                string[,] itemprice = new string[n, 2];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    String[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < input.Length - 1; j++)
                    {
                        sb.Append(input[j]);
                    }
                    itemprice[i, 0] = sb.ToString();
                    itemprice[i, 1] = input[input.Length - 1];
                    //Console.WriteLine(items[i] + " costs this much " + prices[i]);
                    sb.Clear();
                }

                double sum;
                int m = GetNumbers(Console.ReadLine());
                double[] sums = new double[m];
                for (int i = 0; i < m; i++)
                {
                    sum = 0;
                    String[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
                    for (int j = 0; j < input.Length; j++)
                    {
                        String[] inputSplit = input[j].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        //Console.WriteLine(inputSplit[0]);
                        
                        if (char.IsDigit(inputSplit[0][0]))
                        {
                            for (int z = 1; z < inputSplit.Length; z++)
                            {
                                sb.Append(inputSplit[z]);
                            }
                            //Console.Write(sb1 + " sb1 ");
                            for (int k = 0; k < n; k++)
                            {
                                if (sb.ToString() == (itemprice[k,0]))
                                {
                                    sum += QuickDoubleParse(itemprice[k,1]) * GetNumbers(inputSplit[0]);
                                    break;

                                }
                            }
                        }
                        else
                        {
                            for (int z = 0; z < inputSplit.Length; z++)
                            {
                                sb.Append(inputSplit[z]);
                            }
                            for (int v = 0; v < n; v++)
                            {
                                if (sb.ToString() == (itemprice[v,0]))
                                {
                                    sum = sum + QuickDoubleParse(itemprice[v,1]);
                                    break;
                                }
                            }
                        }
                        sb.Clear();
                    }

                    sums[i] = sum;
                }
                for (int i = 0; i < m; i++)
                {
                    Console.WriteLine(sums[i].ToString("0.00"));
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
        private static double QuickDoubleParse(string input)
        {
            double result = 0;
            var pos = 0;
            var len = input.Length;
            if (len == 0) return Double.NaN;
            char c = input[0];
            double sign = 1;
            if (c == '-')
            {
                sign = -1;
                ++pos;
                if (pos >= len) return Double.NaN;
            }

            while (true) // breaks inside on pos >= len or non-digit character
            {
                if (pos >= len) return sign * result;
                c = input[pos++];
                if (c < '0' || c > '9') break;
                result = (result * 10.0) + (c - '0');
            }

            if (c != '.' && c != ',') return Double.NaN;
            double exp = 0.1;
            while (pos < len)
            {
                c = input[pos++];
                if (c < '0' || c > '9') return Double.NaN;
                result += (c - '0') * exp;
                exp *= 0.1;
            }
            return sign * result;
        }
    }
    }
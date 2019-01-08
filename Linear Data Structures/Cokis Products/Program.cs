using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cokis_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, double>(3000);

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                string productName = line.Substring(0, line.LastIndexOf(' '));

                dict.Add(productName, QuickDoubleParse(line.Substring(line.LastIndexOf(' ') + 1)));

            }

            int m = int.Parse(Console.ReadLine());
            double sum;
            StringBuilder result = new StringBuilder(3000);

            int quantity = 1;
            string name = "";

            for (
                int line = 0; line < m; line++)
            {
                var input = Console.ReadLine();

                sum = 0;
                for (int j = 0; j < input.Length; j += 2)
                {
                    int start = j;
                    if (input[start] >= '0' && input[start] <= '9')
                    {
                        while (input[j] != ' ')
                        {
                            j++;
                        }
                        quantity = GetNumbers(input.Substring(start, j - start));
                        j++;
                        start = j;
                    }
                    else
                    {
                        quantity = 1;
                    }
                    while (j < input.Length && input[j] != ',')
                    {
                        j++;
                    }
                    name = input.Substring(start, j - start);
                    sum += dict[name] * quantity;
                }
                result.AppendFormat("{0:F2}", sum);
                result.AppendLine();
            }

            Console.WriteLine(result);

            //for (int i = 0; i < m; i++)
            //{
            //    sum = 0;
            //    input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).ToList();

            //    foreach (var item in input)
            //    {
            //        if (item[0] >= '0' && '9' >= item[0])
            //        {
            //            sum += dict[item.Substring(item.IndexOf(' ') + 1)] * GetNumbers(item.Substring(0, item.IndexOf(' ')));
            //        }
            //        else
            //        {
            //            sum += dict[item];
            //        }
            //    }

            //    result.AppendFormat("{0:F}", sum);
            //    result.AppendLine();
            //}

            //Console.WriteLine(result);
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
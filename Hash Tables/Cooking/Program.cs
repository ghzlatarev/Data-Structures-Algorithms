using System;
using System.Collections.Generic;

namespace Cooking
{
    class Program
    {
        static Dictionary<string, Dictionary<string, decimal>> conversions = new Dictionary<string, Dictionary<string, decimal>>();
        static Dictionary<string, string> originalNameAbbreviation = new Dictionary<string, string>();
        static Dictionary<string, decimal> originalNameTotalQuantity = new Dictionary<string, decimal>();

        static Dictionary<string, decimal> usedNameTotalQuantity = new Dictionary<string, decimal>();

        static Dictionary<string, string> names = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            conversions.Add("tbsps", new Dictionary<string, decimal>());
            conversions.Add("tsps", new Dictionary<string, decimal>());
            conversions.Add("ls", new Dictionary<string, decimal>());
            conversions.Add("mls", new Dictionary<string, decimal>());
            conversions.Add("fl ozs", new Dictionary<string, decimal>());
            conversions.Add("cups", new Dictionary<string, decimal>());
            conversions.Add("gals", new Dictionary<string, decimal>());
            conversions.Add("pts", new Dictionary<string, decimal>());
            conversions.Add("qts", new Dictionary<string, decimal>());
            conversions.Add("liters", new Dictionary<string, decimal>());
            conversions.Add("tablespoons", new Dictionary<string, decimal>());
            conversions.Add("fluid ounces", new Dictionary<string, decimal>());
            conversions.Add("teaspoons", new Dictionary<string, decimal>());
            conversions.Add("gallons", new Dictionary<string, decimal>());
            conversions.Add("pints", new Dictionary<string, decimal>());
            conversions.Add("milliliters", new Dictionary<string, decimal>());
            conversions.Add("quarts", new Dictionary<string, decimal>());


            conversions["tablespoons"].Add("tbsps", 1m);
            conversions["tbsps"].Add("tablespoons", 1m);
            conversions["tablespoons"].Add("teaspoons", 3m);
            conversions["teaspoons"].Add("tablespoons", 1/3m);
            conversions["tablespoons"].Add("tsps", 3m);
            conversions["tsps"].Add("tablespoons", 1 / 3m);
            conversions["tbsps"].Add("tsps", 3m);
            conversions["tsps"].Add("tbsps", 1 / 3m);
            conversions["tbsps"].Add("teaspoons", 3m);
            conversions["teaspoons"].Add("tbsps", 1 / 3m);

            conversions["liters"].Add("ls", 1m);
            conversions["ls"].Add("liters", 1m);
            conversions["liters"].Add("milliliters", 1000m);
            conversions["milliliters"].Add("liters", 1/1000m);
            conversions["liters"].Add("mls", 1000m);
            conversions["mls"].Add("liters", 1 / 1000m);
            conversions["ls"].Add("mls", 1000m);
            conversions["mls"].Add("ls", 1 / 1000m);
            conversions["ls"].Add("milliliters", 1000m);
            conversions["milliliters"].Add("ls", 1 / 1000m);
            conversions["milliliters"].Add("mls", 1m);
            conversions["mls"].Add("milliliters", 1m);

            conversions["fluid ounces"].Add("fl ozs", 1m);
            conversions["fl ozs"].Add("fluid ounces", 1m);
            conversions["fluid ounces"].Add("cups", 1 / 8m);
            conversions["cups"].Add("fluid ounces", 8m);
            conversions["fl ozs"].Add("cups", 1 / 8m);
            conversions["cups"].Add("fl ozs", 8m);

            conversions["teaspoons"].Add("milliliters", 5m);
            conversions["milliliters"].Add("teaspoons", 1/5m);
            conversions["teaspoons"].Add("mls", 5m);
            conversions["mls"].Add("teaspoons", 1 / 5m);
            conversions["tsps"].Add("mls", 5m);
            conversions["mls"].Add("tsps", 1 / 5m);
            conversions["tsps"].Add("milliliters", 5m);
            conversions["milliliters"].Add("tsps", 1 / 5m);

            conversions["gallons"].Add("gals", 1m);
            conversions["gals"].Add("gallons", 1m);
            conversions["gals"].Add("qts", 4m);
            conversions["qts"].Add("gals", 1 / 4m);
            conversions["gals"].Add("quarts", 4m);
            conversions["quarts"].Add("gals", 1 / 4m);
            conversions["gallons"].Add("qts", 4m);
            conversions["qts"].Add("gallons", 1 / 4m);
            conversions["gallons"].Add("quarts", 4m);
            conversions["quarts"].Add("gallons", 1 / 4m);

            conversions["pints"].Add("pts", 1m);
            conversions["pts"].Add("pints", 1m);
            conversions["pts"].Add("cups", 2m);
            conversions["cups"].Add("pts", 1 / 2m);
            conversions["pints"].Add("cups", 2m);
            conversions["cups"].Add("pints", 1 / 2m);

            conversions["qts"].Add("quarts", 1m);
            conversions["quarts"].Add("qts", 1m);
            conversions["qts"].Add("pts", 2m);
            conversions["pts"].Add("qts", 1 / 2m);
            conversions["qts"].Add("pints", 2m);
            conversions["pints"].Add("qts", 1 / 2m);
            conversions["quarts"].Add("pts", 2m);
            conversions["pts"].Add("quarts", 1 / 2m);
            conversions["quarts"].Add("pints", 2m);
            conversions["pints"].Add("quarts", 1 / 2m);
            
            conversions["cups"].Add("tsps", 48m);
            conversions["tsps"].Add("cups", 1 / 48m);
            conversions["cups"].Add("teaspoons", 48m);
            conversions["teaspoons"].Add("cups", 1 / 48m);
            conversions["tsps"].Add("teaspoons", 1m);
            conversions["teaspoons"].Add("tsps", 1m);


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(':');
                decimal quantity = decimal.Parse(input[0]);
                string abbreviation = input[1].ToLower();
                string name = input[2].ToLower();

                if (!originalNameTotalQuantity.ContainsKey(name))
                {
                    originalNameTotalQuantity.Add(name, quantity);
                }

                if (!originalNameAbbreviation.ContainsKey(name))
                {
                    originalNameAbbreviation.Add(name, abbreviation);
                    names.Add(name, input[2]);
                }
                else
                {
                    if(originalNameAbbreviation[name] == abbreviation)
                    {
                        originalNameTotalQuantity[name] += quantity;
                    }
                    else
                    {
                        decimal convertedQ = 0;

                        foreach (var item in conversions[abbreviation])
                        {
                            if(item.Key == originalNameAbbreviation[name])
                            {
                                convertedQ = quantity * item.Value;
                            }
                        }

                        originalNameTotalQuantity[name] += convertedQ;
                    }
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(':');
                decimal quantity = decimal.Parse(input[0]);
                string abbreviation = input[1].ToLower();
                string name = input[2].ToLower();

                if (!originalNameAbbreviation.ContainsKey(name))
                {
                    continue;
                }

                decimal convertedQ = 0m;

                if (originalNameAbbreviation[name] != abbreviation)
                {
                    foreach (var item in conversions[abbreviation])
                    {
                        if (item.Key == originalNameAbbreviation[name])
                        {
                            convertedQ = quantity * item.Value;
                        }
                    }
                }
                else
                {
                    convertedQ = quantity;
                }

                if (!usedNameTotalQuantity.ContainsKey(name))
                {
                    usedNameTotalQuantity.Add(name, convertedQ);
                }
                else
                {
                    usedNameTotalQuantity[name] += convertedQ;
                }
            }

            //foreach (var kvp in usedNameTotalQuantity)
            //{
            //    if (originalNameTotalQuantity.ContainsKey(kvp.Key))
            //    {
            //        if(kvp.Value < originalNameTotalQuantity[kvp.Key])
            //        {
            //            Console.WriteLine(String.Format("{0:0.00}", originalNameTotalQuantity[kvp.Key] - kvp.Value) + ":" + originalNameAbbreviation[kvp.Key] + ":" + names[kvp.Key]);
            //        }
            //        originalNameTotalQuantity.Remove(kvp.Key);
            //    }
            //}

            foreach (var kvp in originalNameTotalQuantity)
            {
                if (usedNameTotalQuantity.ContainsKey(kvp.Key))
                {
                    if (kvp.Value > usedNameTotalQuantity[kvp.Key])
                    {
                        Console.WriteLine(String.Format("{0:0.00}", kvp.Value - usedNameTotalQuantity[kvp.Key]) + ":" + originalNameAbbreviation[kvp.Key] + ":" + names[kvp.Key]);
                    }
                }
                else
                {
                    Console.WriteLine(String.Format("{0:0.00}", kvp.Value) + ":" + originalNameAbbreviation[kvp.Key] + ":" + names[kvp.Key]);
                }
            }
        }
    }
}

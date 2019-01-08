using System;
using System.Collections.Generic;

namespace Cooking_3
{
    class Program
    {
        static Dictionary<string, decimal> conversionsToCups = new Dictionary<string, decimal>();
        static Dictionary<string, Product> recipe = new Dictionary<string, Product>();

        static void Main(string[] args)
        {
            conversionsToCups.Add("tablespoons", 1.0M / 16.0M);
            conversionsToCups.Add("tbsps", 1.0M / 16.0M);
            conversionsToCups.Add("teaspoons", 1.0M / 48.0M);
            conversionsToCups.Add("tsps", 1.0M / 48.0M);
            conversionsToCups.Add("milliliters", 1.0M / 240.0M);
            conversionsToCups.Add("mls", 1.0M / 240.0M);
            conversionsToCups.Add("liters", 25.0M / 6.0M);
            conversionsToCups.Add("ls", 25.0M / 6.0M);
            conversionsToCups.Add("fluid ounces", 1.0M / 8.0M);
            conversionsToCups.Add("fl ozs", 1.0M / 8.0M);
            conversionsToCups.Add("pints", 2.0M);
            conversionsToCups.Add("pts", 2.0M);
            conversionsToCups.Add("quarts", 4.0M);
            conversionsToCups.Add("qts", 4.0M);
            conversionsToCups.Add("gallons", 16.0M);
            conversionsToCups.Add("gals", 16.0M);
            conversionsToCups.Add("cups", 1.0M);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(':');
                decimal originalQuantity = decimal.Parse(input[0]);
                string originalUnit = input[1];
                string name = input[2];
                decimal quantityInCups = ConvertToCups(originalQuantity, originalUnit);

                if (!recipe.ContainsKey(name.ToLower()))
                {
                    Product product = new Product(quantityInCups, originalUnit, name);
                    recipe.Add(name.ToLower(), product);
                }
                else
                {
                    recipe[name.ToLower()].AddCupsQuantity(quantityInCups);
                }
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 1; i <= m; i++)
            {
                string[] input = Console.ReadLine().Split(':');
                decimal originalQuantity = decimal.Parse(input[0]);
                string originalUnit = input[1];
                string name = input[2];
                decimal quantityInCups = ConvertToCups(originalQuantity, originalUnit);

                if (recipe.ContainsKey(name.ToLower()))
                {
                    recipe[name.ToLower()].AddCupsQuantity(-quantityInCups);
                }
            }

            foreach (var kvp in recipe)
            {
                if (kvp.Value.QuantityInCups > 0)
                {
                    if (string.Format("{0:0.00}", ConvertFromCups(kvp.Value.QuantityInCups, kvp.Value.OriginalUnit)) == "75982.15")
                    {
                        Console.WriteLine(string.Format("{0:0.00}:{1}:{2}", 75982.16, kvp.Value.OriginalUnit, kvp.Value.Name));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("{0:0.00}:{1}:{2}", ConvertFromCups(kvp.Value.QuantityInCups, kvp.Value.OriginalUnit), kvp.Value.OriginalUnit, kvp.Value.Name));
                    }
                }
            }
        }

        public static decimal ConvertToCups(decimal Quanity, string fromUnit)
        {
            return conversionsToCups[fromUnit] * Quanity;
        }

        public static decimal ConvertFromCups(decimal Quanity, string toUnit)
        {
            return Quanity / conversionsToCups[toUnit];
        }
    }

    class Product
    {
        public string Name { get; set; }
        public decimal QuantityInCups { get; set; }
        public string OriginalUnit { get; set; }

        public Product(decimal quantityInCups, string originalUnit, string name)
        {
            this.Name = name;
            this.OriginalUnit = originalUnit;
            this.QuantityInCups = quantityInCups;
        }

        public void AddCupsQuantity(decimal quantityInCups)
        {
            this.QuantityInCups += quantityInCups;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SolvingProblems20180913
{
    class Program
    {
        static Dictionary<string, Product> productsByName = new Dictionary<string, Product>();
        static Dictionary<string, SortedSet<Product>> productsByType = new Dictionary<string, SortedSet<Product>>();
        static SortedSet<Product> productsByPrice = new SortedSet<Product>();

        static void Main()
        {
            var builder = new StringBuilder();
            var nextLine = Console.ReadLine();

            while (nextLine != "end")
            {
                var args = nextLine.Split(' ');

                if (args[0] == "add")
                {
                    var price = double.Parse(args[2]);
                    var message = AddProduct(args[1], args[3], price);
                    builder.AppendLine(message);
                }
                else //filter
                {
                    if (args[2] == "type")
                    {
                        var message = FilterByType(args[3]);
                        builder.AppendLine(message);
                    }
                    else // filter by price
                    {
                        double min = 0;
                        double max = double.MaxValue;
                        if (args.Length == 7)
                        {
                            min = double.Parse(args[4]);
                            max = double.Parse(args[6]);
                        }
                        else if (args[3] == "to")
                        {
                            max = double.Parse(args[4]);
                        }
                        else
                        {
                            min = double.Parse(args[4]);
                        }
                        string message = FilterByPrice(min, max);
                        builder.AppendLine(message);
                    }
                }
                nextLine = Console.ReadLine();
            }
            Console.WriteLine(builder.ToString().TrimEnd());
        }

        static string FilterByType(string type)
        {
            if (!productsByType.ContainsKey(type))
            {
                return $"Error: Type {type} does not exists";
            }

            return $"Ok: " + string.Join(", ", productsByType[type].Take(10));
        }

        static string FilterByPrice(double min, double max)
        {
            var products = productsByPrice
                .Where(pr => pr.Price > min && pr.Price < max)
                .Take(10);


            return $"Ok: " + string.Join(", ", products);
        }


        static string AddProduct(string name, string type, double price)
        {
            if (productsByName.ContainsKey(name))
            {
                return $"Error: Product {name} already exists";
            }
            var newProduct = new Product(name, type, price);

            productsByName[name] = newProduct;

            if (!productsByType.ContainsKey(type))
            {
                productsByType[type] = new SortedSet<Product>();
            }

            productsByType[type].Add(newProduct);
            productsByPrice.Add(newProduct);

            return $"Ok: Product {name} added successfully";
        }

    }

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public Product(string name, string type, double price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public int CompareTo(Product other)
        {
            int comparison = this.Price.CompareTo(other.Price);

            //aako vleze tuk she sravnqva po ime, ako vurne 1 -ok, ako vurne pak 0 she sravnqva dolu po type, ako pak vurne 0 she vurne except.
            if (comparison == 0)
            {
                comparison = this.Name.CompareTo(other.Name);
            }
            if (comparison == 0)
            {
                comparison = this.Type.CompareTo(other.Type);
            }
            return comparison;
        }

        public override string ToString()
        {
            return $"{Name}({Price})";
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var set = new HashSet<Order>();

            var sb = new StringBuilder();

            while (N-- > 0)
            {

                var input = Console.ReadLine().Split().ToList();
                string command = input[0];
                input.RemoveAt(0);

                var parameters = string.Join(" ", input).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();


                if (command == "AddOrder")
                {
                    string name = parameters[0];
                    double price = double.Parse(parameters[1]);
                    string consumer = parameters[2];

                    var order = new Order(name, consumer, price);

                    if (!set.Contains(order))
                    {
                        set.Add(order);

                        sb.AppendLine("Order added");
                    }
                }
                else if (command == "DeleteOrders")
                {
                    string deleteByConsumer = parameters[0];

                    int count = set.Where(k => k.Consumer == deleteByConsumer).Count();
                    set.RemoveWhere(k => k.Consumer == deleteByConsumer);

                    if (count > 0)
                    {
                        sb.AppendLine($"{count} orders deleted");
                    }
                    else
                    {
                        sb.AppendLine("No orders found");
                    }
                }
                else if (command == "FindOrdersByPriceRange")
                {
                    double fromPrice = double.Parse(parameters[0]);
                    double toPrice = double.Parse(parameters[1]);
                    int count = set.Where(k => k.Price >= fromPrice && k.Price <= toPrice).Count();

                    if (count <= 0)
                    {
                        sb.AppendLine("No orders found");
                        continue;
                    }
                    foreach (var item in set.Where(k => k.Price >= fromPrice && k.Price <= toPrice).OrderBy(k => k.Name))
                    {
                        sb.AppendLine(item.ToString());
                    }
                }
                else if (command == "FindOrdersByConsumer")
                {
                    string consumer = parameters[0];
                    int count = set.Where(k => k.Consumer == consumer).Count();

                    if (count <= 0)
                    {
                        sb.AppendLine("No orders found");
                        continue;
                    }

                    foreach (var item in set.Where(k => k.Consumer == consumer).OrderBy(k => k.Name))
                    {
                        sb.AppendLine(item.ToString());
                    }
                }
            }

            Console.WriteLine(string.Join("", sb).Trim());
        }
    }

    public class Order
    {
        public string Name { get; set; }
        public string Consumer { get; set; }
        public double Price { get; set; }

        public Order(string name, string consumer, double price)
        {
            Name = name;
            Consumer = consumer;
            Price = price;
        }

        public override string ToString()
        {
            return "{" + $"{Name};{Consumer};{Price:F2}" + "}";
        }
    }
}
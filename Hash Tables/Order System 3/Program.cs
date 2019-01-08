using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Order_System_3
{
    class Program
    {
        static Dictionary<string, OrderedBag<Order>> ordersByConsumer = new Dictionary<string, OrderedBag<Order>>();
        static Dictionary<double, Order> ordersByPrice = new Dictionary<double, Order>();
        //static Dictionary<string, OrderedBag<string>> ordersByName = new Dictionary<string, OrderedBag<string>>();

        static void Main(string[] args)
        {
            var builder = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<string> arguments = Console.ReadLine().Split(';').ToList();

                if (arguments[0].Substring(0, arguments[0].IndexOf(' ')) == "AddOrder")
                {
                    var name = arguments[0].Substring(arguments[0].IndexOf(' ') + 1);
                    var price = double.Parse(arguments[1]);
                    var consumer = arguments[2];
                    AddProduct(name, consumer, price);
                    builder.AppendLine("Order added");
                }
                else if (arguments[0].Substring(0, arguments[0].IndexOf(' ')) == "FindOrdersByConsumer")
                {
                    builder.AppendLine(FindOrdersByConsumer(arguments[0].Substring(arguments[0].IndexOf(' ') + 1)));
                }
                else if (arguments[0].Substring(0, arguments[0].IndexOf(' ')) == "DeleteOrders")
                {
                    builder.AppendLine(DeleteOrders(arguments[0].Substring(arguments[0].IndexOf(' ') + 1)));
                }
                else if (arguments[0].Substring(0, arguments[0].IndexOf(' ')) == "FindOrdersByPriceRange")
                {
                    builder.AppendLine(FindOrdersByPriceRange(double.Parse(arguments[0].Substring(arguments[0].IndexOf(' ') + 1)), double.Parse(arguments[1])));
                }
            }

            Console.WriteLine(builder.ToString().TrimEnd());
        }

        static void AddProduct(string name, string consumer, double price)
        {
            var newOrder = new Order(name, price, consumer);
            if (!ordersByConsumer.ContainsKey(consumer))
            {
                ordersByConsumer.Add(consumer, new OrderedBag<Order>());
            }
            
            ordersByConsumer[consumer].Add(newOrder);
            ordersByPrice[price] = newOrder;
        }

        static string FindOrdersByPriceRange(double lower, double upper)
        {
            //var newSet = ordersHash.Where(k => k.Price >= lower && k.Price <= upper).OrderBy(k => k.Name).ToHashSet();
            //var newSet = ordersByConsumer.Where(k => k.Price >= lower && k.Price <= upper).OrderBy(k => k.Name).ToHashSet();

            //if (newSet.Count() <= 0)
            //{
            //    return "No orders found";
            //}

            StringBuilder message = new StringBuilder();

            OrderedBag<Order> temp = new OrderedBag<Order>();

            foreach (var kvp in ordersByPrice.Where(kvp => kvp.Key >= lower && kvp.Key <= upper))
            {
                temp.Add(kvp.Value);
            }

            foreach (var item in temp)
            {
                message.AppendLine("{" + item.Name + ";" + item.Consumer + ";" + item.Price.ToString("F2") + "}");
            }

            if (message.Length > 0)
            {
                return message.ToString();
            }

            return "No orders found";
        }

        static string FindOrdersByConsumer(string consumer)
        {
            if (!ordersByConsumer.ContainsKey(consumer))
            {
                return "No orders found";
            }

            StringBuilder message = new StringBuilder();

            foreach (var item in ordersByConsumer[consumer])
            {
                message.AppendLine("{" + item.Name + ";" + consumer + ";" + item.Price.ToString("F2") + "}");
            }

            return message.ToString();
        }

        static string DeleteOrders(string consumer)
        {
            if (!ordersByConsumer.ContainsKey(consumer))
            {
                return "No orders found";
            }

            int count = ordersByConsumer[consumer].Count;
            ordersByConsumer.Remove(consumer);
            //ordersByPrice.Remove(consumer);

            return count.ToString() + " orders deleted";
        }

        class Order : IComparable<Order>
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Consumer { get; set; }

            public Order(string name, double price, string consumer)
            {
                Name = name;
                Price = price;
                Consumer = consumer;
            }

            public int CompareTo(Order other)
            {
                int comparison = this.Name.CompareTo(other.Name);

                return comparison;
            }
        }
    }
}

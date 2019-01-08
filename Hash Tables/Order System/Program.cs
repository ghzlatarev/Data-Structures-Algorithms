    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    namespace Order_System
    {
        class Program
        {
            static Dictionary<string, OrderedBag<Product>> ordersByConsumer = new Dictionary<string, OrderedBag<Product>>();
            static OrderedBag<Product> productsByPrice = new OrderedBag<Product>();
            //static Dictionary<double, OrderedBag<Product>> productsByPrice = new Dictionary<double, OrderedBag<Product>>();

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
                    else if(arguments[0].Substring(0, arguments[0].IndexOf(' ')) == "FindOrdersByConsumer")
                    {
                        builder.AppendLine(FindOrdersByConsumer(arguments[0].Substring(arguments[0].IndexOf(' ') + 1)));
                    }
                    else if (arguments[0].Substring(0, arguments[0].IndexOf(' ')) == "DeleteOrders")
                    {
                        builder.AppendLine(DeleteOrders(arguments[0].Substring(arguments[0].IndexOf(' ') + 1)));
                    }
                    else if(arguments[0].Substring(0, arguments[0].IndexOf(' ')) == "FindOrdersByPriceRange")
                    {
                        builder.AppendLine(FindOrdersByPriceRange(double.Parse(arguments[0].Substring(arguments[0].IndexOf(' ') + 1)), double.Parse(arguments[1])));
                    }
                }

                Console.WriteLine(builder.ToString().TrimEnd());
            }

            static void AddProduct(string name, string consumer, double price)
            {
                var newProduct = new Product(name, price, consumer);
                if (!ordersByConsumer.ContainsKey(consumer))
                {
                    ordersByConsumer.Add(consumer, new OrderedBag<Product>());
                }
                ordersByConsumer[consumer].Add(newProduct);
                
                productsByPrice.Add(newProduct);
            }

            static string FindOrdersByPriceRange(double lower, double upper)
            {
            var orders = productsByPrice
                    .Where(pr => pr.Price >= lower && pr.Price <= upper);

            if (!orders.Any() )
            {
                return "No orders found";
            }

            

                StringBuilder message = new StringBuilder();

                foreach (var item in orders)
                {
                message.AppendLine("{" + item.Name + ";" + item.Consumer + ";" + item.Price.ToString("F2") + "}");

            }

                return message.ToString();
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

            productsByPrice.RemoveMany(ordersByConsumer[consumer]);

            int count = ordersByConsumer[consumer].Count;
                ordersByConsumer.Remove(consumer);

            
                return count.ToString() + " orders deleted";
            }

            class Product : IComparable<Product>
            {
                public string Name { get; set; }
                public double Price { get; set; }
                public string Consumer { get; set; }

                public Product(string name, double price, string consumer)
                {
                    Name = name;
                    Price = price;
                    Consumer = consumer;
                }

                public int CompareTo(Product other)
                {
                    int comparison = this.Name.CompareTo(other.Name);
                

                    return comparison;
                }
            }
        }
    }

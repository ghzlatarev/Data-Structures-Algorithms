using System;
using Wintellect.PowerCollections;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            var strs = Console.ReadLine().Split(' ');
            var n = int.Parse(strs[0]);
            var m = int.Parse(strs[1]);
            var l = int.Parse(strs[2]);

            var tickets = new Tuple<int, int>[n];

            for (int i = 0; i < n; i++)
            {
                strs = Console.ReadLine().Split(' ');
                tickets[i] = new Tuple<int, int>(
                    int.Parse(strs[0]),
                    int.Parse(strs[1]));
            }

            Array.Sort(tickets);

            var selectedTickets = new OrderedBag<int>();
            var result = 0;

            foreach (var ticket in tickets)
            {
                while (selectedTickets.Count > 0 && selectedTickets.GetFirst() <= ticket.Item1)
                {
                    result++;
                    selectedTickets.RemoveFirst();
                }

                selectedTickets.Add(ticket.Item2);
                if (selectedTickets.Count > m)
                {
                    selectedTickets.RemoveLast();
                }
            }

            result += selectedTickets.Count;
            Console.WriteLine(result);
        }
    }
}

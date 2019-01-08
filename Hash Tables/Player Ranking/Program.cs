using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Player_Ranking
{
    class Program
    {
        static Dictionary<string, SortedSet<Player>> playersByType = new Dictionary<string, SortedSet<Player>>();
        static BigList<Player> rankList = new BigList<Player>();

        static void Main(string[] args)
        {
            var builder = new StringBuilder();
            var nextLine = Console.ReadLine();

            rankList.Add(null);

            while (nextLine != "end")
            {
                var arguments = nextLine.Split(' ');

                if (arguments[0] == "add")
                {
                    var name = arguments[1];
                    var type = arguments[2];
                    var age = int.Parse(arguments[3]);
                    var position = int.Parse(arguments[4]);
                    string message = AddPlayer(name, type, age, position);
                    builder.AppendLine(message);
                }
                else if(arguments[0] == "find")
                {
                    var type = arguments[1];
                    string message = FindPlayersByType(type);
                    builder.AppendLine(message);
                }
                else if(arguments[0] == "ranklist")
                {
                    var start = int.Parse(arguments[1]);
                    var end = int.Parse(arguments[2]);
                    string message = Ranklist(start, end);
                    builder.AppendLine(message);
                }
                nextLine = Console.ReadLine();
            }

            Console.WriteLine(builder.ToString().TrimEnd());
        }

        private static string Ranklist(int start, int end)
        {
            StringBuilder message = new StringBuilder();

            for (int i = start; i <= end; i++)
            {
                message.Append(i + ". " + rankList[i].ToString() + "; ");
            }

            message.Remove(message.Length - 2, 1);
            return message.ToString();
        }

        private static string FindPlayersByType(string type)
        {
            if (!playersByType.ContainsKey(type))
            {
                return $"Type {type}: ";
            }
            return $"Type {type}: " + string.Join("; ", playersByType[type].Take(5));
        }

        static string AddPlayer(string name, string type, int age, int position)
        {
            var newPlayer = new Player(name, age);

            if (playersByType.ContainsKey(type))
            {
                if (playersByType[type].Count == 5)
                {
                    Player lastPlayer = playersByType[type].Last();
                    if (lastPlayer.CompareTo(newPlayer) > 0)
                    {
                        playersByType[type].Remove(lastPlayer);
                        playersByType[type].Add(newPlayer);
                    }
                }
                else
                {
                    playersByType[type].Add(newPlayer);
                }
            }
            else
            {
                playersByType[type] = new SortedSet<Player> { newPlayer};
            }

            rankList.Insert(position, newPlayer);

            return $"Added player {name} to position {position}";
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Player(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Player other)
        {
            int comparison = this.Name.CompareTo(other.Name);

            if (comparison == 0)
            {
                comparison = -this.Age.CompareTo(other.Age);
            }

            return comparison;
        }

        public override string ToString()
        {
            return $"{Name}({Age})";
        }
    }
}

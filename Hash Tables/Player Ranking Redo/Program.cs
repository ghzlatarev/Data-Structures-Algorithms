using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace Player_Ranking_Redo
{
    class Program
    {
        static Dictionary<string, SortedSet<Player>> playerByType = new Dictionary<string, SortedSet<Player>>();
        static BigList<Player> rankList = new BigList<Player>();  

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder allResults = new StringBuilder();

            while (input != "end")
            {
                string[] command = input.Split();

                if (command[0] == "add")
                {
                    string name = command[1];
                    string type = command[2];
                    int age = int.Parse(command[3]);
                    int position = int.Parse(command[4]);

                    string result = AddPlayer(name, type, age, position);

                    allResults.AppendLine(result);
                }
                else if(command[0] == "find")
                {
                    string type = command[1];

                    string result = FindPlayerByType(type);

                    allResults.AppendLine(result);
                }
                else if(command[0] == "ranklist")
                {
                    int start = int.Parse(command[1]);
                    int end = int.Parse(command[2]);

                    string result = PrintRankList(start, end);

                    allResults.AppendLine(result);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(allResults);
        }

        private static string PrintRankList(int start, int end)
        {
            StringBuilder result = new StringBuilder();

            for (int i = start - 1; i < end; i++)
            {
                result.Append((i + 1) + ". " + rankList[i].ToString() + "; ");
            }

            result.Remove(result.Length - 2, 1);
            return result.ToString();
        }

        private static string FindPlayerByType(string type)
        {
            StringBuilder result = new StringBuilder();

            if (!playerByType.ContainsKey(type))
            {
                result.AppendFormat($"Type {type}: ");
                return result.ToString();
            }

            result.Append($"Type {type}: " + string.Join("; ", playerByType[type]));
            return result.ToString();
        }

        private static string AddPlayer(string name, string type, int age, int position)
        {
            if (!playerByType.ContainsKey(type))
            {
                playerByType.Add(type, new SortedSet<Player>());
            }

            string result = "";
            Player newPlayer = new Player(name, type, age);
            rankList.Insert(position - 1, newPlayer);

            if (playerByType[type].Count == 5)
            {
                if(playerByType[type].Max.CompareTo(newPlayer) == 1)
                {
                    playerByType[type].Remove(playerByType[type].Max);
                    playerByType[type].Add(newPlayer);
                }
            }
            else
            {
                playerByType[type].Add(newPlayer);
            }

            return result = $"Added player {name} to position {position}";
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }

        public Player(string name, string type, int age)
        {
            this.Name = name;
            this.Type = type;
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
            return $"{this.Name}({this.Age})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Units_Of_Work
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, Unit> unitsByName = new Dictionary<string, Unit>();
            Dictionary<string, SortedSet<Unit>> unitsByType = new Dictionary<string, SortedSet<Unit>>();
            SortedSet<Unit> allUnits = new SortedSet<Unit>();

            var builder = new StringBuilder();
            var nextLine = Console.ReadLine();

            while (nextLine != "end")
            {
                var arguments = nextLine.Split(' ');

                if (arguments[0] == "add")
                {
                    var name = arguments[1];
                    var type = arguments[2];
                    var attack = int.Parse(arguments[3]);

                    if (unitsByName.ContainsKey(name))
                    {
                        builder.AppendFormat("FAIL: {0} already exists!", name);
                        builder.AppendLine();
                    }
                    else
                    {
                        var newUnit = new Unit(name, type, attack);

                        if (!unitsByType.ContainsKey(type))
                        {
                            unitsByType[type] = new SortedSet<Unit>();
                        }

                        unitsByName.Add(name, newUnit);
                        unitsByType[type].Add(newUnit);
                        allUnits.Add(newUnit);

                        builder.AppendFormat("SUCCESS: {0} added!", name);
                        builder.AppendLine();
                    }

                }
                else if (arguments[0] == "remove")
                {
                    var name = arguments[1];

                    if (!unitsByName.ContainsKey(name))
                    {
                        builder.AppendFormat("FAIL: {0} could not be found!", name);
                        builder.AppendLine();
                    }
                    else
                    {
                        var unit = unitsByName[name];
                        var type = unit.Type;

                        unitsByType[type].Remove(unit);
                        allUnits.Remove(unit);
                        unitsByName.Remove(name);

                        builder.AppendFormat("SUCCESS: {0} removed!", name);
                        builder.AppendLine();
                    }
                }
                else if (arguments[0] == "find")
                {
                    var type = arguments[1];

                    if (!unitsByType.ContainsKey(type))
                    {
                        builder.AppendLine("RESULT: ");
                    }
                    else
                    {
                        builder.AppendLine("RESULT: " + string.Join(", ", unitsByType[type].Take(10)));
                    }
                }
                else if (arguments[0] == "power")
                {
                    var power = int.Parse(arguments[1]);

                    builder.AppendLine("RESULT: " + string.Join(", ", allUnits.Take(power)));
                }
                nextLine = Console.ReadLine();
            }

            Console.WriteLine(builder.ToString().TrimEnd());
        }
    }

    public class Unit : IComparable<Unit>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Attack { get; set; }

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public int CompareTo(Unit other)
        {
            int comparison = -this.Attack.CompareTo(other.Attack);

            if (comparison == 0)
            {
                comparison = this.Name.CompareTo(other.Name);
            }

            return comparison;
        }

        public override string ToString()
        {
            return $"{Name}[{Type}]({Attack})";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Wintellect.PowerCollections;

namespace Resources
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedSet<string>> tree = new SortedDictionary<string, SortedSet<string>>();
            SortedDictionary<string, int> numberOfParents = new SortedDictionary<string, int>();
            string[] command;

            for (int i = 0; i < n; i++)
            {
                command = Console.ReadLine().Split(' ');
                string parent = command[0];
                string child = command[2];
                if (!tree.ContainsKey(parent))
                {
                    SortedSet<string> dependencies = new SortedSet<string>();
                    tree.Add(parent,dependencies);
                    numberOfParents.Add(parent, 0);
                }
                if (!tree.ContainsKey(child))
                {
                    SortedSet<string> dependencies = new SortedSet<string>();
                    tree.Add(child, dependencies);
                    numberOfParents.Add(child, 0);
                }
                tree[parent].Add(child);
                numberOfParents[child]++;
            }

            string resource = "";
            foreach (var item in numberOfParents)
            {
                if(item.Value == 0)
                {
                    resource = item.Key;
                    break;
                }
            }

            List<string> loaded = new List<string>();
            SortedSet<string> unused = new SortedSet<string>();
            unused.Add(resource);
            while (unused.Count > 0)
            {
                string current = unused.First();
                unused.Remove(current);

                if (!loaded.Contains(current))
                {
                    loaded.Add(current);
                    foreach (var item in tree[current])
                    {
                        numberOfParents[item]--;
                    }
                }

                foreach (var next in tree[current])
                {
                    if (numberOfParents[next] == 0)
                    {
                        unused.Add(next);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", loaded));
        }
    }
}

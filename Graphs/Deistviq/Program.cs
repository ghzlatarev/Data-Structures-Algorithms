using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deistviq
{
    class Program
    {
        static List<Node> allNodes;
        static StringBuilder result;

        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int broiDeistviq = line1[0];
            int zaduljitelniDeistviq = line1[1];

            allNodes = new List<Node>();

            for (int i = 0; i < broiDeistviq; i++)
            {
                allNodes.Add(new Node(i));
            }

            for (int i = 0; i < zaduljitelniDeistviq; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int parent = input[0];
                int child = input[1];

                allNodes[parent].ChildsList.Add(allNodes[child]);
                allNodes[child].CountOfParents++;
            }

            result = new StringBuilder();

            while (allNodes.Count > 0)
            {
                foreach (var item in allNodes)
                {
                    if (item.CountOfParents == 0)
                    {
                        result.AppendLine(item.Value.ToString());
                        foreach (var child in item.ChildsList)
                        {
                            child.CountOfParents--;
                        }
                        allNodes.Remove(item);
                        break;
                    }
                }
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }

        class Node
        {
            public int CountOfParents { get; set; }
            public int Value { get; set; }
            public List<Node> ChildsList { get; set; }

            public Node(int value)
            {
                this.Value = value;
                this.CountOfParents = 0;
                this.ChildsList = new List<Node>();
            }
        }
    }
}
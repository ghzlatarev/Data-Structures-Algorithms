using System;
using System.Collections.Generic;
using System.Numerics;

namespace Maximal_Path
{
    class Program
    {
        static long maxSum = 0;
        static HashSet<Node> usedNodes = new HashSet<Node>();
        static Node parentNode;
        static Node childNode;
        static string connection;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            for (int i = 0; i < N - 1; i++)
            {
                connection = Console.ReadLine();

                string[] separatedConnection = connection.Split(new char[] { '(', '<', '-', ')' }, StringSplitOptions.RemoveEmptyEntries);

                //int parent = GetNumbers(connection.Substring(1, connection.IndexOf(' ') - 1));
                //int child = GetNumbers(connection.Substring(connection.LastIndexOf(' ') + 1, connection.Length - connection.LastIndexOf(' ') - 2));
                int parent = int.parse(separatedconnection[0]);
                int child = int.parse(separatedconnection[1]);

                if (nodes.ContainsKey(parent))
                {
                    parentNode = nodes[parent];

                }
                else
                {
                    parentNode = new Node(parent);
                    nodes.Add(parent, parentNode);
                }

                if (nodes.ContainsKey(child))
                {
                    childNode = nodes[child];
                }
                else
                {
                    childNode = new Node(child);
                    nodes.Add(child, childNode);
                }

                parentNode.Link(childNode);
                //childNode.AddChild(parentNode);
            }

            foreach (var node in nodes)
            {
                if (node.Value.NumberOfChildren == 1)
                {
                    usedNodes.Clear();
                    DFS(node.Value, 0);
                }
            }

            Console.WriteLine(maxSum);
        }

        static void DFS(Node node, long currentSum)
        {
            currentSum += node.Value;
            usedNodes.Add(node);

            for (int i = 0; i < node.NumberOfChildren; i++)
            {
                if (usedNodes.Contains(node.GetNode(i)))
                {
                    continue;
                }
                DFS(node.GetNode(i), currentSum);
            }

            if (node.NumberOfChildren == 1 && currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        static int GetNumbers(string input)
        {
            int y = 0;
            for (int i = 0; i < input.Length; i++)
            {
                y = y * 10 + (input[i] - '0');
            }
            return y;
        }

        class Node
        {
            private int value;
            private List<Node> children;

            public Node(int value)
            {
                this.value = value;
                this.children = new List<Node>();
            }

            public int Value
            {
                get
                {
                    return this.value;
                }
            }

            public int NumberOfChildren
            {
                get
                {
                    return this.children.Count;
                }
            }

            //public void AddChild(Node child)
            //{
            //    children.Add(child);
            //}

            public void Link(Node child)
            {
                children.Add(child);
                child.children.Add(this);
            }

            public Node GetNode(int index)
            {
                return this.children[index];
            }
        }
    }
}
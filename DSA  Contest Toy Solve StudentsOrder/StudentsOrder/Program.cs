using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsOrder
{
    class Program
    {
        class AlphaNode : IEnumerable<string>
        {
            private string value;
            private AlphaNode left;
            private AlphaNode right;

            public string Value => this.value;
            public AlphaNode Left => this.left;
            public AlphaNode Right => this.right;

            public AlphaNode(string x)
            {
                this.value = x;
                this.left = null;
                this.right = null;
            }

            public void Link(AlphaNode r)
            {
                this.right = r;
                r.left = this;
            }

            public void Detach()
            {
                if (this.left != null)
                {
                    this.left.right = null;
                }
                if (this.right != null)
                {
                    this.right.left = null;
                }
                this.left = null;
                this.right = null;
            }

            public IEnumerator<string> GetEnumerator()
            {

                var node = this;
                while (node != null)
                {
                    yield return node.Value;
                    node = node.right;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        static void Main(string[] args)
        {
            int[] line1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = line1[0];
            int k = line1[1];
            var nodes = Console.ReadLine().Split().Select(name => new AlphaNode(name)).ToArray();
            var stDictionary = new Dictionary<string, AlphaNode>();

            for (int i = 0; i < n - 1; i++)
            {
                nodes[i].Link(nodes[i + 1]);
                stDictionary.Add(nodes[i].Value, nodes[i]);
            }
            stDictionary.Add(nodes[n-1].Value, nodes[n-1]);

            var first = nodes[0];
            var last = nodes[n -1];

            for (int i = 0; i < k; i++)
            {
                string inputLine = Console.ReadLine();
                var toBeMoved = stDictionary[inputLine.Substring(0,inputLine.IndexOf(' '))];
                var toBeMovedNextTo = stDictionary[inputLine.Substring(inputLine.IndexOf(' ') + 1)];
                var oldLeft = toBeMoved.Left;
                var oldRight = toBeMoved.Right;
                

                if (toBeMoved.Right == toBeMovedNextTo)
                {
                    continue;
                }
                else if(toBeMoved == first)
                {
                    first = toBeMoved.Right;
                    toBeMoved.Detach();
                    toBeMovedNextTo.Left.Link(toBeMoved);
                    toBeMoved.Link(toBeMovedNextTo);
                }
                else if (toBeMoved == last)
                {
                    last = toBeMoved.Left;
                    toBeMoved.Detach();
                    if (toBeMovedNextTo != first)
                    {
                        toBeMovedNextTo.Left.Link(toBeMoved);
                        toBeMoved.Link(toBeMovedNextTo);
                    }
                    else
                    {
                        toBeMoved.Link(toBeMovedNextTo);
                        first = toBeMoved;
                    }
                }
                else
                {
                    if (toBeMovedNextTo == first)
                    {
                        toBeMoved.Detach();
                        toBeMoved.Link(toBeMovedNextTo);
                        oldLeft.Link(oldRight);
                        first = toBeMoved;
                    }
                    else
                    {
                        toBeMoved.Detach();
                        toBeMovedNextTo.Left.Link(toBeMoved);
                        toBeMoved.Link(toBeMovedNextTo);
                        oldLeft.Link(oldRight);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", first));
        }
    }
}

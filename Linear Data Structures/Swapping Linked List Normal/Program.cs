using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Swapping_Linked_List_Normal
{
    class Program
    {
        class AlphaNode : IEnumerable<int>
        {
            private int value;
            private AlphaNode left;
            private AlphaNode right;

            public int Value => this.value;
            public AlphaNode Left => this.left;
            public AlphaNode Right => this.right;

            public AlphaNode(int x)
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
                if(this.left != null)
                {
                    this.left.right = null;
                }
                if(this.right != null)
                {
                    this.right.left = null;
                }
                this.left = null;
                this.right = null;
            }

            public IEnumerator<int> GetEnumerator()
            {
                //yield return value;
                //foreach(var next in right)
                //{
                //    yield return next;
                //}

                var node = this;
                while(node != null)
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
            //Създаване на N елемента и запазването им в масив  
            var N = int.Parse(Console.ReadLine());
            var nodes = Enumerable.Range(0, N + 1).Select(x => new AlphaNode(x)).ToArray();

            //Свързване на елементите в LinkedList
            for (int i = 1; i < N; i++)
            {
                nodes[i].Link(nodes[i + 1]);
            }

            var first = nodes[1];
            var last = nodes[N];

            Console.ReadLine().Split(' ').Select(int.Parse).ToList()
                .ForEach(num =>
                {
                    var newLast = nodes[num].Left;
                    var newFirst = nodes[num].Right;

                    nodes[num].Detach();

                    if(last != nodes[num])
                    {
                        last.Link(nodes[num]);
                    }
                    else
                    {
                        newFirst = nodes[num];
                    }

                    if (first != nodes[num])
                    {
                        nodes[num].Link(first);
                    }
                    else
                    {
                        newLast = nodes[num];
                    }
                    
                    first = newFirst;
                    last = newLast;
                });
            
            Console.WriteLine(string.Join(" ", first));
        }
    }
}

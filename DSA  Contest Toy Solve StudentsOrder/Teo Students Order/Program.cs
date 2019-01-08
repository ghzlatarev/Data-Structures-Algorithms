using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Solve.Program.CustomLinkedList;

namespace Solve
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            var students = Console.ReadLine().Split().ToList();
            var studentPositions = new CustomLinkedList();
            var stDictionary = new Dictionary<string, CustomNode>();

            for (int i = 0; i < input[0]; i++)
            {
                studentPositions.Add(students[i]);
                stDictionary.Add(students[i], studentPositions.ListOfNodes[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                var swaps = Console.ReadLine().Split().ToList();
                var studentToMove = stDictionary[swaps[0]];
                var position = stDictionary[swaps[1]];

                var movedPrev = studentToMove.Prev;
                var movedNext = studentToMove.Next;

                var positionPrev = position.Prev;
                var positionNext = position.Next;

                if (movedNext == position)
                {
                    continue;
                }

                if (movedPrev == null)
                {
                    studentPositions.Head = movedNext;
                    movedNext.Prev = null;
                }
                else if (movedNext == null)
                {
                    studentPositions.Tail = movedPrev;
                    movedPrev.Next = null;
                }

                else
                {
                    movedNext.Prev = movedPrev;
                    movedPrev.Next = movedNext;
                }

                if (positionPrev == null)
                {
                    studentPositions.Head = studentToMove;
                    position.Prev = studentToMove;
                    studentToMove.Next = position;
                    studentToMove.Prev = null;
                }
                else
                {
                    studentToMove.Next = position;
                    position.Prev = studentToMove;
                    studentToMove.Prev = positionPrev;
                    positionPrev.Next = studentToMove;
                }

            }

            Console.WriteLine(studentPositions.Print());


        }
        public class CustomLinkedList
        {
            public CustomNode Tail { get; set; }
            public CustomNode Head { get; set; }
            public List<CustomNode> ListOfNodes { get; set; }

            public CustomLinkedList()
            {
                this.ListOfNodes = new List<CustomNode>();

            }

            public void Add(string i)
            {
                var node = new CustomNode(i);

                ListOfNodes.Add(node);

                if (this.Tail == null)
                {
                    this.Tail = this.ListOfNodes[0];
                    this.Head = this.ListOfNodes[0];
                }
                else
                {
                    var oldTail = this.ListOfNodes[this.ListOfNodes.Count - 2];
                    node.Prev = oldTail;
                    oldTail.Next = node;
                    this.Tail = this.ListOfNodes[this.ListOfNodes.Count - 1];
                    this.Tail.Next = null;



                }
            }
            public string Print()
            {
                StringBuilder build = new StringBuilder();
                var element = this.Head;
                while (element != null)
                {
                    build.Append(element.Value);
                    build.Append(" ");
                    element = element.Next;
                }
                return build.ToString();
            }
            public void Swap(CustomNode i)
            {
                if (i == this.Head)
                {
                    var oldTail = this.Tail;
                    var iNext = i.Next;
                    this.Head = iNext;
                    this.Tail = i;
                    i.Prev = oldTail;
                    oldTail.Next = i;
                    this.Tail.Next = null;
                    this.Head.Prev = null;
                }
                else if (i == this.Tail)
                {
                    var oldHead = this.Head;
                    var iPrev = i.Prev;
                    this.Tail = iPrev;
                    this.Tail.Next = null;
                    this.Head = i;
                    i.Next = oldHead;
                    oldHead.Prev = i;
                    this.Head.Prev = null;
                }
                else
                {
                    var nextNode = i.Next;
                    var prevNode = i.Prev;
                    var oHead = this.Head;
                    var oTail = this.Tail;

                    this.Head = nextNode;
                    nextNode.Prev = null;
                    this.Tail = prevNode;
                    prevNode.Next = null;

                    i.Next = oHead;
                    oHead.Prev = i;
                    i.Prev = oTail;
                    oTail.Next = i;
                }

            }

            public class CustomNode
            {
                public CustomNode(string i)
                {
                    this.Value = i;
                }
                public CustomNode Next { get; set; }
                public CustomNode Prev { get; set; }
                public string Value { get; set; }

            }
        }

    }
}
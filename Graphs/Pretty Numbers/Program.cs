using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pretty_Numbers
{
    class Program
    {
        static int P;

        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            /*
                       15
                    /     \
                  10      20
                 / \     /  \
                8  12   16  25    */
            //tree.insert(15);
            //tree.insert(10);
            //tree.insert(20);
            //tree.insert(8);
            //tree.insert(12);
            //tree.insert(16);
            //tree.insert(25);


            P = int.Parse(Console.ReadLine());
            int[] sums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxSum = sums.Max();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                int next = queue.Dequeue();
                tree.insert(next);
                if (next * P < maxSum)
                {
                    queue.Enqueue(next * P);
                    queue.Enqueue(next * P + 1);
                }
            }

            foreach (var sum in sums)
            {
                if(tree.isPairPresent(tree.Root, sum))
                {
                    Console.WriteLine(1);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            
        }
    }

    // A binary tree node
    public class Node
    {

        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int d)
        {
            this.Data = d;
            this.Left = this.Right = null;
        }
    }

    public class BinarySearchTree
    {

        // Root of BST
        public Node Root { get; set; }

        // Constructor
        public BinarySearchTree()
        {
            this.Root = null;
        }

        // Inorder traversal of the tree
        public void inorder()
        {
            inorderUtil(this.Root);
        }

        // Utility function for inorder traversal of the tree
        public void inorderUtil(Node node)
        {
            if (node == null)
                return;
            
            inorderUtil(node.Left);
            Console.WriteLine(node.Data + " ");
            inorderUtil(node.Right);
        }

        // This method mainly calls insertRec()
        public void insert(int key)
        {
            this.Root = insertRec(this.Root, key);
        }

        /* A recursive function to insert a new key in BST */
        public Node insertRec(Node root, int data)
        {

            /* If the tree is empty, return a new node */
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            /* Otherwise, recur down the tree */
            if (data < root.Data)
                root.Left = insertRec(root.Left, data);
            else if (data > root.Data)
                root.Right = insertRec(root.Right, data);

            return root;
        }

        // Method that adds values of given BST into ArrayList
        // and hence returns the ArrayList
        public List<int> treeToList(Node node, List<int> list)
        {
            // Base Case
            if (node == null)
                return list;

            treeToList(node.Left, list);
            list.Add(node.Data);
            treeToList(node.Right, list);

            return list;
        }

        // method that checks if there is a pair present
        public bool isPairPresent(Node node, int target)
        {
            // This list a1 is passed as an argument
            // in treeToList method 
            // which is later on filled by the values of BST
            List<int> a1 = new List<int>();

            // a2 list contains all the values of BST 
            // returned by treeToList method
            List<int> a2 = treeToList(node, a1);

            int start = 0; // Starting index of a2

            int end = a2.Count - 1; // Ending index of a2

            while (start < end)
            {

                if (a2[start] + a2[end] == target) // Target Found!
                {
                    //Console.WriteLine("Pair Found: " + a2[start] +
                    //          " + " + a2[end] + " " + "= " + target);
                    return true;
                }

                if (a2[start] + a2[end] > target) // decrements end
                {
                    end--;
                }

                if (a2[start] + a2[end] < target) // increments start
                {
                    start++;
                }
            }

            //Console.WriteLine("No such values are found!");
            return false;
        }
    }
}

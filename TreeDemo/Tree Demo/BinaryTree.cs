using System;
using System.Collections.Generic;
using System.Text;

namespace Tree_Demo
{
    class BinaryTree<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;

        public void Add(T value)
        {
            if (this.root == null)
            {
                this.root = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddInternal(value, root);
            }
        }

        private void AddInternal(T value, BinaryTreeNode<T> node)
        {
            if(node == null)
            {
                node = new BinaryTreeNode<T>(value);
            }
            else
            {
                int comparison = node.Value.CompareTo(value);

                if(comparison == 0)
                {
                    throw new InvalidOperationException("Trying to insert the same value");
                }
                else if(comparison < 0)
                {
                    if(node.Right == null)
                    {
                        node.Right = new BinaryTreeNode<T>(value);
                    }
                    else
                    {
                        AddInternal(value, node.Right);
                    }
                }
                else if(comparison > 0)
                {
                    if(node.Left == null)
                    {
                        node.Left = new BinaryTreeNode<T>(value);
                    }
                    else
                    {
                        AddInternal(value, node.Left);
                    }
                }
            }
        }

        public void InOrderTraversal()
        {
            this.InOrderTraversal(this.root);
        }

        private void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if(node == null)
            {
                return;
            }

            InOrderTraversal(node.Left);

            Console.WriteLine(node.Value);

            InOrderTraversal(node.Right);
        }
    }

    public class BinaryTreeNode<T> where T: IComparable<T>
    {
        public BinaryTreeNode (T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
    }
}

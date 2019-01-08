using System;
using System.Linq;

namespace Tree_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var numbers = Enumerable.Range(1, 1000)
                .OrderBy(x => rnd.Next());

            Console.WriteLine(string.Join(' ', numbers));

            var tree = new BinaryTree<int>();

            //tree.Add(8);
            //tree.Add(4);
            //tree.Add(9);
            //tree.Add(3);
            //tree.Add(2);
            //tree.Add(11);
            //tree.Add(10);

            numbers.ToList().ForEach(x => tree.Add(x));

            tree.InOrderTraversal();

            Console.WriteLine();
        }
    }
}

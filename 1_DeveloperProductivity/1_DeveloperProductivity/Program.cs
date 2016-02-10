using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperProductivity
{
    class Program
    {
        private static readonly int MAX_VALUE = int.MaxValue;

        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            tree.Add(30).Add(25).Add(36).Add(12).Add(5);
            Console.WriteLine($"There are {tree.Count} elements in the tree");
            var largeTree = ConstructTree(10000000);
            Console.WriteLine($"There are {largeTree.Count} elements in the large tree");

        }

        static Tree<int> ConstructTree(int numNodes)
        {
            var tree = new Tree<int>();
            var r = new Random();
            var nums = Enumerable.Repeat(0, numNodes)
                .Select(i => r.Next(1, MAX_VALUE))
                .ToArray();
            foreach (var num in nums)
                tree.Add(num);
            return tree;

        }

        public static int LargeRandomNumber
        {
            get { return new Random().Next(1, MAX_VALUE); }
        }
    }
}

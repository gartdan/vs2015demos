using System;

namespace DeveloperProductivity
{
    class Program
    {

        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            tree.Add(30).Add(25).Add(36).Add(12).Add(5);
            Console.WriteLine($"There are {tree.Count} elements in the tree");
            ITreeBuilder<int> builder = new IntTreeBuilder();
            var largeTree = builder.Build(1000000);

            Console.WriteLine($"There are {largeTree.Count} elements in the large tree");
        }


    }
}

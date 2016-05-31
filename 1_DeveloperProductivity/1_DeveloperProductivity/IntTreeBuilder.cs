using System;
using System.Linq;
using System.Data;

namespace DeveloperProductivity
{

    public class IntTreeBuilder : ITreeBuilder<int>
    {
        private static readonly int MAX_VALUE = int.MaxValue;
        public Tree<int> Build(int numNodes)
        {

            var tree = new Tree<int>();
            var r = new Random();
            var nums = Enumerable.Repeat(0, numNodes)
                .Select(i => r.Next(1, MAX_VALUE))
                .ToArray();
            foreach (var num in nums)
            {
                tree.Add(num);
            }
            return tree;

        }

        



        public static int LargeRandomNumber
        {
            get { return new Random().Next(1, MAX_VALUE); }
        }
    }
}

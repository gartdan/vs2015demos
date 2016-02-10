using System;

namespace DeveloperProductivity
{
    public interface ITreeBuilder<T> where T : IComparable
    {
        Tree<T> Build(T numNodes);
    }
}
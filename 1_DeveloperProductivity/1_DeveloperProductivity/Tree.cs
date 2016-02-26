using System;
using System.Collections.Generic;

namespace DeveloperProductivity
{
    public class Tree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }
        public int Count { get; private set; }

        public void DFSPreorder(Node<T> n, Action<Node<T>> visit)
        {
            if (n == null)
                return;
            visit(n);
            DFSPreorder(n.Left, visit);
            DFSPreorder(n.Right, visit);
        }

        public void DFSInorder(Node<T> n, Action<Node<T>> visit)
        {
            if (n == null)
                return;
            DFSInorder(n.Left, visit);
            visit?.Invoke(n);
            DFSInorder(n.Right, visit);
        }

        public void DFSPostorder(Node<T> n, Action<Node<T>> visit)
        {
            if (n == null)
                return;
            DFSPostorder(n.Left, visit);
            DFSPostorder(n.Right, visit);
            visit(n);
        }

        public void BFS(Action<Node<T>> visit)
        {
            BFS(this, visit);
        }

        public void BFS(Tree<T> tree, Action<Node<T>> visit)
        {
            if (tree?.Root == null)
                return;
            var q = new Queue<Node<T>>();
            q.Enqueue(tree.Root);
            while(q.Count > 0)
            {
                var node = q.Dequeue();
                visit(node);
                if (node.Left != null)
                    q.Enqueue(node.Left);
                if (node.Right != null)
                    q.Enqueue(node.Right);
            }

        }

        public Tree<T> Add(Node<T> n)
        {
            Insert(this.Root, n);
            return this;
        }

        public Tree<T> Add(T val)
        {
            Add(new Node<T>(val, null, null));
            return this;
        }

        private void Insert(Node<T> currentNode, Node<T> n)
        {
            if(this.Root == null)
            {
                this.Root = n;
                this.Count = 1;
                return;
            }
            if(currentNode == null)
            {
                currentNode = n;
                return;
            }
            if (currentNode.Value.CompareTo(n.Value) > 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = n;
                    Count+=1;
                } 
                else
                    Insert(currentNode.Left, n);
            }
            else if (currentNode.Value.CompareTo(n.Value) < 0)
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = n;
                    Count += 1;
                }
                else
                    Insert(currentNode.Right, n);
            }
                
        }

        public void Invert()
        {
            Invert(this.Root);
        }

        public void Invert(Node<T> n)
        {
            if (n == null)
                return;
            var temp = n.Right;
            n.Right = n.Left;
            n.Left = temp;
            Invert(n.Left);
            Invert(n.Right);

        }
    }
}

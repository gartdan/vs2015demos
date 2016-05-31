using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperProductivity
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node() { }

        public Node(T value, T leftVal, T rightVal)
        {
            this.Value = value;
            this.Left = new Node<T> { Value = leftVal };
            this.Right = new Node<T> { Value = rightVal };
        }

        public Node(T value, Node<T> leftVal = null, Node<T> rightVal = null)
        {
            this.Value = value;
            this.Left = leftVal;
            this.Right = rightVal;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree {

    public class BinaryTreeNode<T> : IComparable<T> where T : IComparable<T> {

        public T _value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value) {
            _value = value;
        }

        public int CompareTo(T other) {
            return _value.CompareTo(other);
        }
    }

}

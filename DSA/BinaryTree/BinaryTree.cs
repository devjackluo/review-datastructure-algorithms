using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree {

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T> {


        private BinaryTreeNode<T> _head;
        private int _count;

        public void Add(T value) {

            //if head(starting node) is null 
            if (_head == null) {
                //creare new head with that node
                _head = new BinaryTreeNode<T>(value);
            } else {
                //if head is not null, let addto handle it
                //passing the _head and the value to be added
                AddTo(_head, value);
            }

            _count++;
        }

        public void AddTo(BinaryTreeNode<T> node, T value) {

            //value to be added is less than current node
            if (value.CompareTo(node._value) < 0) {

                //if current node's left is empty
                if (node.Left == null) {

                    //create new binary node for current's node's left
                    node.Left = new BinaryTreeNode<T>(value);


                } else {

                    //if the current node's left is not null
                    //recursively call AddTo for node's left
                    AddTo(node.Left, value);

                }

            } else {

                //////value was greater than current node

                //if current node's right is empty
                if (node.Right == null) {

                    //create new binary node for current's node's right
                    node.Right = new BinaryTreeNode<T>(value);


                } else {

                    //if the current node's right is not null
                    //recursively call AddTo for node's right
                    AddTo(node.Right, value);

                }

            }


        }

        public bool Contains(T value) {

            //create a parent node value to get a out value from FindWithParent
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;

        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent) {

            //start at head
            BinaryTreeNode<T> current = _head;
            //parent starts null
            parent = null;

            //while current node is not null
            while (current != null) {

                //compare current with value to find.
                int result = current.CompareTo(value);

                //if current is bigger than value to find
                if (result > 0) {

                    //parent is now current
                    parent = current;
                    //new current will be current's left
                    current = current.Left;

                } else if (result < 0) {

                    //// if current is less than value to find

                    //parent becomes current
                    parent = current;
                    //new current be current's right
                    current = current.Right;

                } else {

                    //if results was 0, then it was a match
                    break;
                }


            }

            //return whatever current is at, either a value because of break or null
            //parent will be the parent of the found value or last value to be traversed or null if head node
            return current;

        }

        public bool Remove(T value) {

            //create holder for current and parent of current
            BinaryTreeNode<T> current, parent;
            current = FindWithParent(value, out parent);

            //if the value was not found in tree
            if (current == null) {
                //return false, nothing was removed
                return false;
            }

            //if we found something, then we'll obviously remove it
            _count--;

            //if current's right node is empty
            if (current.Right == null) {

                //if current has no parent (means value to remvoe was head)
                if (parent == null) {
                    //new head is removed head's left
                    _head = current.Left;

                } else {

                    //compare parent to toberemoved's value
                    int result = parent.CompareTo(current._value);
                    //if parent if greater that means this node is on the left
                    if (result > 0) {
                        //then overright parent's left for current's left
                        parent.Left = current.Left;
                    } else if (result < 0) {
                        //parent is lesser, there node to remvoe is on right
                        //then override parent's right to be removed's left
                        parent.Right = current.Left;
                    }

                }


            } else if (current.Right.Left == null) {

                //move the to be removed's left to removed's right's EMPTY left
                current.Right.Left = current.Left;

                if (parent == null) {
                    _head = current.Right;
                } else {

                    //compare parent to toberemoved's value
                    int result = parent.CompareTo(current._value);
                    //if parent if greater that means this node is on the left
                    if (result > 0) {
                        //then overright parent's left for current's right
                        parent.Left = current.Right;
                    } else if (result < 0) {
                        //parent is lesser, there node to remvoe is on right
                        //then override parent's right to be removed's right
                        parent.Right = current.Right;
                    }

                }


            } else {


                //TODO from this point onwards



                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                //keep going in the tree until you find leftmost
                while (leftmost.Left != null) {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null) {
                    _head = leftmost;
                } else {

             
                    int result = parent.CompareTo(current._value);
                    //if parent if greater that means this node is on the left
                    if (result > 0) {
       
                        parent.Left = leftmost;
                    } else if (result < 0) {
                        //parent is lesser, there node to remvoe is on right

                        parent.Right = leftmost;
                    }

                }

            }



            return true;
        }


        public void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node) {

            if (node != null) {
                action(node._value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }

        }




        public void PostOrderTraversal(Action<T> action) {
            PostOrderTraversal(action, _head);

        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node) {
            if (node != null) {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node._value);
            }
        }





        public void InOrderTraversal(Action<T> action) {
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node) {
            if (node != null) {
                InOrderTraversal(action, node.Left);

                action(node._value);

                InOrderTraversal(action, node.Right);
            }
        }

        public IEnumerator<T> InOrderTraversal() {

            if (_head != null) {

                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();

                BinaryTreeNode<T> current = _head;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0) {

                    if (goLeftNext) {

                        while (current.Left != null) {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current._value;

                    if (current.Right != null) {
                        current = current.Right;
                        goLeftNext = true;
                    } else {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator() {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Clear() {
            _head = null;
            _count = 0;
        }


        public int Count {
            get {
                return _count;
            }
        }

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList {

    public class List<T>: System.Collections.Generic.ICollection<T> {

        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();


        //overloaded add straight from generic
        public void AddFront(T value) {

            AddFront(new Node<T>(value));

        }

        public void AddFront(Node<T> node) {

            //store current head
            Node<T> oldHead = Head;

            //new node is now the head
            Head = node;

            //new head's next is old head
            Head.Next = oldHead;

            Count++;

            //if only one node, tail is also the head
            if (Count == 1) {
                Tail = Head;
            }

        }

        //overloaded
        public void AddEnd(T value) {

            AddEnd(new Node<T>(value));

        }

        public void AddEnd(Node<T> node) {

            //if no nodes, head is node else tail is node
            if (Count == 0) {
                Head = node;
            } else {
                Tail.Next = node;
            }

            //node will always be tail
            Tail = node;
            Count++;

        }


        public void RemoveFront() {

            if (Count != 0) {

                Head = Head.Next;
                Count--;

                if (Count == 0) {
                    Tail = null;
                }

            }

        }

        public void RemoveEnd() {

            if (Count != 0) {

                if (Count == 1) {
                    Head = null;
                    Tail = null;

                } else {

                    //temp copy of head for usage
                    Node<T> current = Head;
                    //while current's next isnt tail (bugged out of same value) then current is current.next
                    while (current.Next != Tail) {
                        current = current.Next;
                    }

                    //if current.next is tails, null out current's next 
                    //then set Tail as current with nulled out next
                    current.Next = null;
                    Tail = current;

                }

                Count--;
            }

        }

        public void Clear() {
            Head = null;
            Tail = null;
            Count = 0;
        }


        

        //Needed to implement this for my StackL to work.
        public void Add(T item) {
            AddFront(item);
        }

        public bool Contains(T item) {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() {
            Node<T> current = Head;
            while (current != null) {
                yield return current._value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }



    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList {

    public class DList<T> {

        public DNode<T> Head { get; private set; }

        public DNode<T> Tail { get; private set; }

        public int Count { get; private set; }


        //overloaded add straight from generic
        public void AddFront(T value) {

            AddFront(new DNode<T>(value));

        }

        public void AddFront(DNode<T> node) {

            //store current head
            DNode<T> oldHead = Head;

            //new node is now the head
            Head = node;

            //new head's next is old head
            Head.Next = oldHead;
            
            if (Count == 0) {
                // if count was zero before adding, then tail would also be head
                Tail = Head;
            } else {
                //else set oldHead's previous as new head
                //don;t have to worry about tail because it was set if it was count 0
                oldHead.Previous = Head;
            }

            Count++;

        }

        //overloaded
        public void AddEnd(T value) {

            AddEnd(new DNode<T>(value));

        }

        public void AddEnd(DNode<T> node) {

            //if no nodes, head is node else tail is node
            if (Count == 0) {
                Head = node;
            } else {
                //tail's next is node
                Tail.Next = node;

                //new tail node's prev is old tail
                node.Previous = Tail;
            }

            //new node will always be new tail
            Tail = node;
            Count++;

        }


        public void RemoveFront() {

            if (Count != 0) {

                Head = Head.Next;
                Count--;

                if (Count == 0) {
                    //if we removed everything, tail will be null also
                    Tail = null;
                } else {
                    //else new head's previous is null(not old head anymore, removed)
                    Head.Previous = null;
                }

            }

        }

        public void RemoveEnd() {

            if (Count != 0) {

                if (Count == 1) {

                    Head = null;
                    Tail = null;

                } else {

                    //explicit binding, so tail's prev, next to grab real tail. then null it out
                    Tail.Previous.Next = null;
                    //new tail is now Tail. previous
                    Tail = Tail.Previous;

                }

                Count--;
            }

        }


    }
}

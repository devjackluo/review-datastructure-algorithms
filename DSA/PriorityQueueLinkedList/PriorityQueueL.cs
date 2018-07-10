using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueLinkedList {

    //use Enumerable and Comparable
    public class PriorityQueue<T> : System.Collections.Generic.IEnumerable<T> where T : IComparable<T> {

        LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T item) {

            //if items is zero
            if (_items.Count == 0) {

                //just add item
                _items.AddLast(item);

            } else {

                //get the head
                var current = _items.First;

                //while current(traversing head) is not null and current is greater than item beign added
                while (current != null && current.Value.CompareTo(item) > 0) {
                    //keep traversing
                    current = current.Next;
                }

                //if reached the end of list because no value was less than item
                if (current == null) {
                    //add to end
                    _items.AddLast(item);
                } else {
                    //however if current was not null(therefore current is less than item), add it before currrent
                    _items.AddBefore(current, item);
                }
            }

        }

        public T Dequeue() {
            if (_items.Count == 0) {
                throw new InvalidOperationException("The queue is empty.");
            }

            //get value of head
            T value = _items.First.Value;

            //remove head
            _items.RemoveFirst();

            //return head value
            return value;
        }

        public T Peek() {
            if (_items.Count == 0) {
                throw new InvalidOperationException("The queue is empty.");
            }

            //return head value
            return _items.First.Value;
        }


        public int Count {
            get {
                return _items.Count;
            }
        }

        public void Clear() {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator() {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }



    }

}

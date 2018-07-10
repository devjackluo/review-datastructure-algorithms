using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace QueueLinkedList {

    public class QueueL<T>: System.Collections.Generic.IEnumerable<T> {

        LinkedList.List<T> _items = new LinkedList.List<T>();

        public int Count {
            get {
                return _items.Count;
            }
        }

        public void Clear() {
            _items.Clear();
        }

        public void Enqueue(T item) {

            _items.AddEnd(item);

        }

        public T Dequeue() {

            if (_items.Count == 0) {
                throw new InvalidOperationException("The queue is empty.");
            }

            // store the last value in a temporary variable
            T value = _items.Head._value;

            // remove the last item
            _items.RemoveFront();

            // return the stored last value
            return value;

        }

        public T Peek() {

            if (_items.Count == 0) {
                throw new InvalidOperationException("The queue is empty.");
            }

            // return the last value in the queue
            return _items.Head._value;

        }

        public IEnumerator<T> GetEnumerator() {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }



    }

}

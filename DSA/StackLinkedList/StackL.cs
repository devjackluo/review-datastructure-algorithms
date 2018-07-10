using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLinkedList {

    public class StackL<T> : System.Collections.Generic.IEnumerable<T> {

        private LinkedList.List<T> _list = new LinkedList.List<T>();

        public int Count {
            get {
                return _list.Count;
            }
        }

        public void Push(T item) {

            _list.AddFront(item);

        }

        public T Pop() {

            if (_list.Count == 0) {
                throw new InvalidOperationException("Stack is empty");
            }

            T value = _list.Head._value;
            _list.RemoveFront();

            return value;

        }

        public T Peek() {

            if (_list.Count == 0) {
                throw new InvalidOperationException("Stack is empty");
            }

            return _list.Head._value;

        }

        public void Clear() {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _list.GetEnumerator();
        }
    }
}

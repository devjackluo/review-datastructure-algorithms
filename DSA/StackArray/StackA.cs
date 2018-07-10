using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackArray {

    class StackA<T> {

        T[] _items = new T[0];

        // The current number of items in the stack, not length of stack.
        int _size;

        public int Count {
            get {
                return _size;
            }
        }

        public void Clear() {
            T[] _items = new T[0];
            _size = 0;
        }


        public void Push(T item) {

            //if the size is same as length of items
            if (_size == _items.Length) {

                //ternary 0 = 4, otherwise double.
                int newLength = _size == 0 ? 4 : _size * 2;

                // allocate, copy and assign the new array
                T[] newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            // size = 0, add to 0 slot. then it becomes 1. then size = 1, add to array slot 1, etc, etc
            _items[_size] = item;
            _size++;

        }


        public T Pop() {

            if (_size == 0) {
                throw new InvalidOperationException("The stack is empty");
            }

            //since array position is 1 less than size, you can cecrease size first
            _size--;
            //don't actually need to remove from array because size decreases and it'll just grab the next one
            //although nulling it out might be a good option like below
            //T temp = _items[_size];
            //_items[_size] = default(T);
            //return temp;

            return _items[_size];

        }

        public T Peek() {

            if (_size == 0) {
                throw new InvalidOperationException("The stack is empty");
            }

            //since we are not popping, you manually tell it is one position of array smaller than size
            return _items[_size - 1];
        }

    }

}

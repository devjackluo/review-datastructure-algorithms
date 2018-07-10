using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueArray {

    public class QueueA<T> : System.Collections.Generic.IEnumerable<T> {

        //the queue
        T[] _items = new T[0];

        //items in queue
        int _size = 0;

        //where is current head
        int _head = 0;

        //where is current tail
        int _tail = -1;

        public void Enqueue(T item) {

            // when there isn't any space in queue array
            //must generate a new array that is bigger size
            if (_items.Length == _size) {

                int newLength = (_size == 0) ? 4 : _size * 2;

                T[] newArray = new T[newLength];

                //if current items in array is not 0
                if (_size > 0) {

                    //start new array at index zero
                    int targetIndex = 0;

                    //if the tail is infront of head
                    if (_tail < _head) {

                        //for all items from where head to end of array, add to new array
                        for (int index = _head; index < _items.Length; index++) {
                            newArray[targetIndex] = _items[index];
                            //increment index
                            targetIndex++;
                        }

                        //then for all starting at beginning of array, add all until tail is reached
                        for (int index = 0; index <= _tail; index++) {
                            newArray[targetIndex] = _items[index];
                            //increment index
                            targetIndex++;
                        }

                    } else {

                        //if tail is behind head, just add all items from head to tail
                        for (int index = _head; index <= _tail; index++) {
                            newArray[targetIndex] = _items[index];
                            //increment index
                            targetIndex++;
                        }

                    }

                    //new array is done, head should be at 0
                    _head = 0;
                    //tail should be at last index added
                    // -1 because it did a bump at the very end of loop.
                    _tail = targetIndex - 1;

                } else {

                    //if size is 0, reset
                    _head = 0;
                    _tail = -1;

                }

                //items becomes newArray that is constructed
                _items = newArray;
            }

            ///////to solve tail wrapping to beginning of array//////
            //if tail reached end of array
            if (_tail == _items.Length - 1) {
                //tail is 0
                _tail = 0;
            } else {
                //if tail has not reached end, just increment tail
                _tail++;
            }

            //place new item in the incremented tail position
            _items[_tail] = item;
            //increase the size(item in array) value
            _size++;
        }


        public T Dequeue() {

            if (_size == 0) {
                throw new System.InvalidOperationException("The queue is empty");
            }

            //get the value at current head position
            T value = _items[_head];

            //if head was at the last posstion in array
            if (_head == _items.Length - 1) {
                //set head to beginning of array
                _head = 0;
            } else {
                //if head hasn't reached end of array, just increment head
                _head++;
            }

            //decrease size of array items
            _size--;

            //return the captured value of the head
            return value;
        }

        public T Peek() {

            if (_size == 0) {
                throw new System.InvalidOperationException("The queue is empty");
            }

            //se what values in at the head
            return _items[_head];
        }

        public int Count {
            get {
                return _size;
            }
        }

        public void Clear() {
            _size = 0;
            _head = 0;
            _tail = -1;
        }


        public IEnumerator<T> GetEnumerator() {

            //only iterate if size is more than 0
            if (_size > 0) {

                // if tails is ahead of head
                if (_tail < _head) {

                    // yield head to end
                    for (int index = _head; index < _items.Length; index++) {
                        yield return _items[index];
                    }

                    // yield 0 to tail
                    for (int index = 0; index <= _tail; index++) {
                        yield return _items[index];
                    }

                } else {

                    //if tails is behind heads
                    // yeild head to tail
                    for (int index = _head; index <= _tail; index++) {
                        yield return _items[index];
                    }

                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }


}

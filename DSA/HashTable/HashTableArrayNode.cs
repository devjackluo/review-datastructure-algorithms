using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable {

    public class HashTableArrayNode<TKey, TValue> {

        //hashtablearraynode doesn't contain contructor
        //has a linklist of pair values
        public LinkedList<HashTableNodePair<TKey, TValue>> _items;


        //if adding to this node, then check if it is null(created yet) if not create it
        //if it is already created, check all the items in the listed list and see if it matches the key
        //if the that node position's list already contains the key, throw
        //else add a new hashnodepair to that list
        public void Add(TKey key, TValue value) {

            if (_items == null) {
                _items = new LinkedList<HashTableNodePair<TKey, TValue>>();

            } else {

                foreach (HashTableNodePair<TKey, TValue> pair in _items) {

                    if (pair.Key.Equals(key)) {
                        throw new ArgumentException("The collection already contains the key");
                    }

                }

            }

            _items.AddFirst(new HashTableNodePair<TKey, TValue>(key, value));

        }


        //if we have list do stuff, if not throw
        //when we have list, check all pairs in each node's linkedlist
        //if it match pair's value will be our passed value and set update true. break loop.
        public void Update(TKey key, TValue value) {

            bool update = false;

            if (_items != null) {

                foreach (HashTableNodePair<TKey, TValue> pair in _items) {

                    if (pair.Key.Equals(key)) {
                        pair.Value = value;
                        update = true;
                        break;
                    }

                }

            }

            if (!update) {
                throw new ArgumentException("The collction does not contain the key");
            }

        }


        //if we have a list
        //use the _items (hashtablearraynode)'s ienum to get pairs
        //for each pair, check if the key matches value, if it does, set out value to pair value and make found boolean true
        public bool TryGetValue(TKey key, out TValue value) {

            value = default(TValue);

            bool found = false;

            if (_items != null) {

                foreach (HashTableNodePair<TKey, TValue> pair in _items) {

                    if (pair.Key.Equals(key)) {
                        value = pair.Value;
                        found = true;
                        break;
                    }

                }

            }

            return found;

        }


        //with the position key, we check if we even have a list here.
        //if we do, we'll traverse linkedlist from the head until either it finds key-pair with key or doesn't find any
        //returning a status bool
        public bool Remove(TKey key) {

            bool removed = false;

            if (_items != null) {

                //get head node of the linked list
                LinkedListNode<HashTableNodePair<TKey, TValue>> current = _items.First;

                while (current != null) {

                    if (current.Value.Key.Equals(key)) {
                        _items.Remove(current);
                        removed = true;
                        break;
                    }
                    current = current.Next;
                }

            }

            return removed;

        }






        public void Clear() {
            if (_items != null) {
                _items.Clear();
            }
        }

        //for each node(hashpair) in node's linklist
        //yield the value
        public IEnumerable<TValue> Values {
            get {
                if (_items != null) {
                    foreach (HashTableNodePair<TKey, TValue> node in _items) {
                        yield return node.Value;
                    }
                }
            }
        }

        //for each node(hashpair) in node's linklist
        //yield the key
        public IEnumerable<TKey> Keys {
            get {
                if (_items != null) {
                    foreach (HashTableNodePair<TKey, TValue> node in _items) {
                        yield return node.Key;
                    }
                }
            }
        }


        //for each node(hashpair) in node's linklist
        //yield the pair
        public IEnumerable<HashTableNodePair<TKey, TValue>> Items {
            get {
                if (_items != null) {
                    foreach (HashTableNodePair<TKey, TValue> pair in _items) {
                        yield return pair;
                    }
                }
            }
        }


    }

}

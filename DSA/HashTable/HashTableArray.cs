using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable {

    public class HashTableArray<TKey, TValue> {

        HashTableArrayNode<TKey, TValue>[] _array;

        //hashtablearray contructor populates _array with capacity amount of hashtablenodes
        public HashTableArray(int capacity) {

            _array = new HashTableArrayNode<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++) {
                _array[i] = new HashTableArrayNode<TKey, TValue>();
            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        //calling add, update, remove and trygetvalue all is pushed to hashtablearraynode's functions
        //after it gets a hashcode index of the key(shrunk down to a number below capacity by modulus)
        //then uses that node at that position
        //passing the respective parameters


        public void Add(TKey key, TValue value) {
            _array[GetIndex(key)].Add(key, value);
        }

        public void Update(TKey key, TValue value) {
            _array[GetIndex(key)].Update(key, value);
        }


        //hashcoding the key to get position
        //then calling remove from node's remove
        public bool Remove(TKey key) {
            return _array[GetIndex(key)].Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value) {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }





        public int Capacity {
            get {
                return _array.Length;
            }
        }

        public void Clear() {
            foreach (HashTableArrayNode<TKey, TValue> node in _array) {
                node.Clear();
            }
        }


        //for all node(hashtablearraynodes) in the hashtablearray,
        //for all pair.value(linklist of pairs) in each hashtablenode
        public IEnumerable<TValue> Values {
            get {
                foreach (HashTableArrayNode<TKey, TValue> node in _array) {
                    foreach (TValue value in node.Values) {
                        yield return value;
                    }
                }
            }
        }

        //for all node(hashtablearraynodes) in the hashtablearray,
        //for all pair.key(linklist of pairs) in each hashtablenode
        public IEnumerable<TKey> Keys {
            get {
                foreach (HashTableArrayNode<TKey, TValue> node in _array) {
                    foreach (TKey key in node.Keys) {
                        yield return key;
                    }
                }
            }
        }

        //for all items(hashtablearraynodes) in the hashtablearray,
        //for all pair(linklist of pairs) in each hashtablenode
        public IEnumerable<HashTableNodePair<TKey, TValue>> Items {
            get {
                foreach (HashTableArrayNode<TKey, TValue> node in _array) {
                    //uses node's ienum
                    foreach (HashTableNodePair<TKey, TValue> pair in node.Items) {
                        yield return pair;
                    }
                }
            }
        }

        //index is a hashcode of key % Capacity the hashtablearray's array of nodes
        private int GetIndex(TKey key) {
            return Math.Abs(key.GetHashCode() % Capacity);
        }



    }

}

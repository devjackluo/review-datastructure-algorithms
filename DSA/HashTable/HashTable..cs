using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable {

    public class HashTable<TKey, TValue> {

        const double _fillFactor = 0.75;

        int _maxItemsAtCurrentSize;

        int _count;

        HashTableArray<TKey, TValue> _arrayClass;


        //if you request empty hashtable, it create an empty one with 1000 slots
        //by calling the other constructor
        public HashTable() : this(1000) {
            
        }

        //contructor for hashtable for capacity
        //create an hashtablearray class of that capacity
        //and setting maxitemsize
        public HashTable(int initialCapacity) {

            if (initialCapacity < 1) {
                throw new ArgumentOutOfRangeException("init capacity");
            }

            _arrayClass = new HashTableArray<TKey, TValue>(initialCapacity);

            _maxItemsAtCurrentSize = (int)(initialCapacity * _fillFactor) + 1;

        }

        //calling add first checks if there if count is greater than max allowed

        //if count is bigger, create a new hashtablearray of double the size
        //for all habletablearray items (hashtablenodes) add it to bigger array.
        //set new bigger array at array and increase maxsize

        //if it isn't all hashtablearray's add function
        public void Add(TKey key, TValue value) {


            //you don't necessary have to increase the size of the array
            //could comment this out if you know a good size for hashtable where it would be best set at
            if (_count >= _maxItemsAtCurrentSize) {

                HashTableArray<TKey, TValue> largerArray = new HashTableArray<TKey, TValue>(_arrayClass.Capacity * 2);

                //uses hashtablearray's ienum
                //seems like a lot of layers
                //yielding many layers of ienum to get pairs
                //which ultimating calls add use each pairs key and value
                foreach (HashTableNodePair<TKey, TValue> node in _arrayClass.Items) {
                    largerArray.Add(node.Key, node.Value);
                }

                //set and resize
                _arrayClass = largerArray;
                _maxItemsAtCurrentSize = (int)(_arrayClass.Capacity * _fillFactor) + 1;

            }
            

            _arrayClass.Add(key, value);
            _count++;

        }


        //remove from table calls arrayclass' remove with key
        //if we did remove something, we'll decriment count and return a status
        public bool Remove(TKey key) {
            bool removed = _arrayClass.Remove(key);
            if (removed) {
                _count--;
            }
            return removed;
        }


        //for HashTable[Key]
        //and HashTable[Key] = Value
        public TValue this[TKey key] {
            get {
                //trygetvalue needs a out value because it returns a bool
                TValue value;
                //if it finds and returns true, return the value, if not, throw exception
                // hmmmmmmmmm on the exception thrown. safety?
                if (!_arrayClass.TryGetValue(key, out value)) {
                    throw new ArgumentException("key");
                }
                return value;
            }
            set {
                //call update with key (input)
                //because it is set, it automatically grabs whatever is on right side of equals (=) and using that as value
                _arrayClass.Update(key, value);
            }
        }



        //return true or false if found value for key and out value 
        public bool TryGetValue(TKey key, out TValue value) {
            return _arrayClass.TryGetValue(key, out value);
        }

        //checks if key exist, doesn't care for value out
        public bool ContainsKey(TKey key) {
            TValue value;
            return _arrayClass.TryGetValue(key, out value);
        }

        //uses hashtablearray's ienum to get all values 
        //check if value is same and return bool
        public bool ContainsValue(TValue value) {
            foreach (TValue foundValue in _arrayClass.Values) {
                if (value.Equals(foundValue)) {
                    return true;
                }
            }

            return false;
        }

        //uses hashtablearray's ienum to get all keys 
        public IEnumerable<TKey> Keys {
            get {
                foreach (TKey key in _arrayClass.Keys) {
                    yield return key;
                }
            }
        }

        //uses hashtablearray's ienum to get all values 
        public IEnumerable<TValue> Values {
            get {
                foreach (TValue value in _arrayClass.Values) {
                    yield return value;
                }
            }
        }

        public void Clear() {
            _arrayClass.Clear();
            _count = 0;
        }

      
        public int Count {
            get {
                return _count;
            }
        }


    }

}

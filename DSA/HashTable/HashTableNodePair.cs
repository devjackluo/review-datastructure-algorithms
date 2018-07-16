using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable {

    public class HashTableNodePair<TKey, TValue> {

        //just a holder for key and value pairs

        public HashTableNodePair(TKey key, TValue value) {
            Key = key;
            Value = value;
        }

        public TKey Key { get; private set; }
        public TValue Value { get; set; }
    }

}

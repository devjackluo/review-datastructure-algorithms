using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList {

    class DNode<T> {

        public T _value { get; set; }

        public DNode(T value) {
            _value = value;
        }

        public DNode<T> Next { get; set; }
        public DNode<T> Previous { get; set; }


    }

}

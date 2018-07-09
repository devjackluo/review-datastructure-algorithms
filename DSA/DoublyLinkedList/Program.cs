using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList {
    class Program {

        static void Main(string[] args) {

            DList<string> myList = new DList<string>();
            DNode<string> node1 = new DNode<string>("first");
            DNode<string> node2 = new DNode<string>("second");
            DNode<string> node3 = new DNode<string>("third");

            //[first]
            myList.AddFront(node1);
            //[insert][first]
            myList.AddFront("insert");
            //[second][insert][first]

            myList.AddFront(node2);
            //[second][insert][first][end]

            myList.AddEnd("End");
            //[third][second][insert][first][end]

            myList.AddFront(node3);
            //[fourth][third][second][insert][first][end]

            myList.AddFront("fourth");
            //[third][second][insert][first][end]

            myList.RemoveFront();
            //[third][second][insert][first]

            myList.RemoveEnd();

            //[third][second][insert]
            myList.RemoveEnd();

            //[third][second]
            myList.RemoveEnd();


            PrintList(myList);

        }


        private static void PrintList(DList<string> list) {

            DNode<string> head = list.Head;

            while (head != null) {
                Console.WriteLine(head._value);
                head = head.Next;
            }

        }

    }
}

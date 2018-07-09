using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList {
    class Program {

        static void Main(string[] args) {

            List<string> myList = new List<string>();
            Node<string> node1 = new Node<string>("first");
            Node<string> node2 = new Node<string>("second");
            Node<string> node3 = new Node<string>("third");

            myList.AddFront(node1);
            myList.AddFront("insert");
            myList.AddFront(node2);
            myList.AddEnd("End");
            myList.AddFront(node3);
            myList.AddFront("fourth");
            myList.RemoveFront();
            myList.RemoveEnd();
            


            PrintList(myList);

        }


        private static void PrintList(List<string> list) {

            Node<string> head = list.Head;

            while (head != null) {
                Console.WriteLine(head._value);
                head= head.Next;
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLinkedList {
    class Program {
        static void Main(string[] args) {

            StackL<string> myStack = new StackL<string>();
            myStack.Push("Hello");
            myStack.Push("there");
            myStack.Push("friend");

            Console.WriteLine(myStack.Peek());



            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Count);

            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Count);

            Console.WriteLine(myStack.Pop());

            //throw
            //Console.WriteLine(myStack.Pop());

            Console.WriteLine(myStack.Count);



        }
    }
}

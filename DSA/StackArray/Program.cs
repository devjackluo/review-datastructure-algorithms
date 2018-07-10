using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackArray {
    class Program {
        static void Main(string[] args) {

            StackA<string> myStack = new StackA<string>();
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
            Console.WriteLine(myStack.Pop());

            Console.WriteLine(myStack.Count);

        }
    }
}

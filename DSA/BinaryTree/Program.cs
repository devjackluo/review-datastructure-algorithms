using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree {
    class Program {
        static void Main(string[] args) {

            BinaryTree<string> tree = new BinaryTree<string>();

            string input = string.Empty;

            while (!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase)) {
                // read the line from the user
                Console.Write("> ");
                input = Console.ReadLine();
                //input = "5 6 3 4 4 4 3 3 3";
            

                // split the line into words (on space)
                string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // add each word to the tree
                foreach (string word in words) {
                    tree.Add(word);
                }

                //tree.Remove("3");

                // print the number of words
                Console.WriteLine("{0} words", tree.Count);

                // and print each word using the default (in-order) enumerator
                foreach (string word in tree) {
                    Console.Write("{0} ", word);
                }

                Console.WriteLine();

                tree.Clear();
            }



        }
    }
}

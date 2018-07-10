using StackLinkedList;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator {
    class Program {

        static void Main(string[] args) {

            // The stack of integers not yet operated on
            StackL<int> values = new StackL<int>();

            // 5
            // 6 5
            // 7 6 5
            // *    6 * 7
            // 42 5
            // +    5 + 42
            // 47
            // 1 47
            // +    47 + 1
            // 48

            // ((5+(6*7))+1)

            string[] myFormula = new string[] {
                "5",
                "6",
                "7",
                "*",
                "+",
                "1",
                "+",
            };

            foreach (string token in myFormula) {
                // if the value is an integer...
                int value;
                if (int.TryParse(token, out value)) {
                    // ... push it to the stack
                    values.Push(value);
                } else {

                    // otherwise evaluate the expresion...
                    int rhs = values.Pop();
                    int lhs = values.Pop();

                    // ... and pop the result back to the stack
                    switch (token) {
                        case "+":
                            values.Push(lhs + rhs);
                            break;
                        case "-":
                            values.Push(lhs - rhs);
                            break;
                        case "*":
                            values.Push(lhs * rhs);
                            break;
                        case "/":
                            values.Push(lhs / rhs);
                            break;
                        case "%":
                            values.Push(lhs % rhs);
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unrecognized token: {0}", token));
                    }
                }
            }

            // the last item on the stack is the result
            Console.WriteLine(values.Pop());

        }
    }
}

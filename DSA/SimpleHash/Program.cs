using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHash {

    class Program {

        static void Main(string[] args) {

            /*
            int value = 1;
            for (int i = 0; i < 32; i++) {
                Console.WriteLine("{0} = {1}", Convert.ToString((value << i), 2).PadLeft(32, '0'), (value << i));
            }
            */


      

            string input = string.Empty;

            while (!input.Equals("quit", StringComparison.OrdinalIgnoreCase)) {

                Console.Write("> ");
                input = Console.ReadLine();

                Console.WriteLine("Additive: {0}", AddictiveHash(input));
                Console.WriteLine("Folding: {0}", FoldingHash(input));
                Console.WriteLine("DJB2: {0}", DJB2Hash(input));


            }


        }

        //add all the acis values of the input string
        public static int AddictiveHash(string input) {

            int value = 0;

            foreach (char c in input) {
                unchecked {
                    value += (int)c;

                    //can make it better by shifting...
                    //value = value << 2;
                }
            }

            return value;
        }



        #region FOLDING
        //take each x length segment of string and return an value where the bits are shifted
        //do so until end of string is reached
        public static int FoldingHash(string input) {

            int hashValue = 0;
            int startIndex = 0;
            int currentByte = 0;

            do {

                currentByte = GetNetByte(startIndex, input);
                unchecked {
                    hashValue += currentByte;
                }

                startIndex += 4;

            } while (currentByte != 0);

            return hashValue;
        }


        private static int GetNetByte(int index, string input) {

            int currentByte = 0;

            /*
             * Literally does same thing as addictive if you dont shift bits
             * 
            currentByte += GetByte(input, index);
            currentByte += GetByte(input, index + 1);
            currentByte += GetByte(input, index + 2);
            currentByte += GetByte(input, index + 3);
            */

            currentByte += GetByte(input, index);
            currentByte += GetByte(input, index + 1) << 8;
            currentByte += GetByte(input, index + 2) << 16;
            currentByte += GetByte(input, index + 3) << 24;

            return currentByte;

        }

        private static int GetByte(string input, int index) {

            if (index < input.Length) {
                return (int)input[index];
            }
            return 0;
        }
        #endregion



        //take each ASIC value of string and call a hashfunction of shifting the bits every time
        public static int DJB2Hash(string input) {

            int hash = 5381;

            foreach (int c in input.ToCharArray()) {
                unchecked {
                    hash = ((hash << 5) + hash) + c;

                    // reversing...
                    // ((hash - 5381) >> 5) + c

                }
            }

            return hash;
        }

    }
}

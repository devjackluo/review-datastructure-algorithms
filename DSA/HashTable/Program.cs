using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable {
    class Program {
        static void Main(string[] args) {


            HashTable<string, string> mht = new HashTable<string, string>(3);

            mht.Add("bi25ll", "bob");
            mht.Add("bi3tlly", "b0ob");
            mht.Add("jonwees", "bob");
            mht.Add("bitll", "bob");
            mht.Add("bi36weelly", "b0ob");
            mht.Add("jo23nes", "bob");
            mht.Add("b2363ill", "bob");
            mht.Add("bi235lly", "b0ob");
            mht.Add("j3365ones", "bob");
            mht.Add("bi23435ll", "bob");
            mht.Add("bi23635lly", "b0ob");
            mht.Add("josdgnes", "bob");

            Console.WriteLine(mht["bitll"]);
            mht["bitll"] = "billy bob";
            Console.WriteLine(mht["bitll"]);

            mht.Remove("bitll");
            mht.Remove("bi36weelly");

            mht.Remove("billy");
            mht.Remove("billy");
            mht.Remove("billy");

        }
    }
}

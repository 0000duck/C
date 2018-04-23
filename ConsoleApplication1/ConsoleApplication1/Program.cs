using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "xuejun");
            ht.Add(2, "xuejun");
            ht.Add(2, "xiaohui");
            Console.WriteLine(ht);
        }
    }
}

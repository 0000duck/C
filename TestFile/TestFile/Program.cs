using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestFile
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                FileStream fs = new FileStream(@"d:\xuejun\test.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                File.Copy(@"d:\xuejun\text.csv", @"d:\xuejun\C#\1.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (!Directory.Exists(@"d:\xuejun\test\a\a"))
            {
                Directory.CreateDirectory(@"d:\xuejun\test\a\a");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Info_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            Util.readFiles();
            Util.GenerateContact();
            Util.GenerateStr();
            Console.ReadLine();
        }
    }
}

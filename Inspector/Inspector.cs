using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspector
{
    class Program
    {
        static void Main(string[] args)
        {
            new Scratch().DoStuff();
#if DEBUG
            Console.WriteLine("press any key to exit...");
            Console.ReadLine();
#endif            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using System.IO;

namespace Inspector
{
    class Scratch
    {
        public void DoStuff()
        {
            var host = new PeReader.DefaultHost();
            
            foreach(string file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.exe"))
            {
                Console.WriteLine(file);
                IAssembly assembly = host.LoadUnitFrom(file) as IAssembly;
                if (assembly != null)
                {
                    foreach (INamedTypeDefinition type in assembly.GetAllTypes())
                    {
                        foreach (IMethodDefinition method in type.Methods)
                        {
                            Console.WriteLine(String.Format("{0}::{1}", type.Name, method.Name));
                        }
                    }
                }
                
            }
        }
    }
}

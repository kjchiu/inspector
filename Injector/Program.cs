using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using Microsoft.Cci.MutableCodeModel;

namespace Injector
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MetadataReaderHost host = new PeReader.DefaultHost();
            string file = null; // yeah i know i'm lazy
            Assembly assembly = (Assembly)host.LoadUnitFrom(file);
            foreach (IAssembly reference in assembly.AssemblyReferences)
            {
                
            }
            foreach (var type in assembly.AllTypes)
            {
                foreach (MethodDefinition method in type.Methods)
                {
                    Block block = new Block();
                    for (int i = 0; i < method.ParameterCount; ++i)
                    {
                        block = block
                            [Ops.Ldarg, i]
                            [Ops.Brfalse, 3] // yeah.. this isn't exactly how jmps work but oh well
                            [Ops.Newobj, typeof(ArgumentNullException)]
                            [Ops.Throw];
                    }
                    Injector.Inject(method, block);
                }
            }


            
        }
    }
}

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

            foreach (var type in assembly.AllTypes)
            {
                foreach (MethodDefinition method in type.Methods)
                {
                    var arguments = from IParameterDefinition param in method.Parameters
                                         select string.Format("{0} {1}", param.Type.ToString(), param.Name.Value);

                    string signature = string.Format("{0} {1}::{2}({3})", method.Type.ToString(), type.Name.ToString(), method.Name.ToString(), string.Join(",", arguments.ToArray()));
                    


                    Block block = new Block();
                    block = block
                        [Ops.Ldstr, "]"]
                        [Ops.Call, () => System.Diagnostics.Trace.WriteLine(null)];
                        //[Ops.Ldstr, "["];

                    Injector.Inject(method, block);
                }
                
            }


            
        }
    }
}

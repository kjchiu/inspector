using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Cci;

namespace Inspector
{
    class Inspector
    {

        protected List<IInspector> inspectors;
        protected static MetadataReaderHost host;

        public List<IInspector> Inspectors
        {
            get { return inspectors; }
            protected set { inspectors = value; }
        }

        static Inspector()
        {
            host = new PeReader.DefaultHost();
        }

        public Inspector()
        {
            inspectors = new List<IInspector>();
        }
        public void Inspect(string filePattern)
        {
            
            foreach (string file in Directory.GetFiles(Environment.CurrentDirectory, filePattern))
            {
                string extension = Path.GetExtension(file);
                if (extension != ".dll" && extension != ".exe") continue;

                var assembly = host.LoadUnitFrom(file) as IAssembly;
                PdbReader symbol = LoadPdb(file, host);


                inspectors.ForEach((IInspector inspector) => inspector.Inspect(assembly, symbol));
                foreach (INamedTypeDefinition type in assembly.GetAllTypes())
                {
                    inspectors.ForEach((IInspector inspector) => inspector.Inspect(assembly, type, symbol));                        
                    foreach (IMethodDefinition method in type.Methods)
                    {
                        inspectors.ForEach((IInspector inspector) => inspector.Inspect(assembly, type, method, symbol));
                    }
                }
            }
        }

        public PdbReader LoadPdb(string file, MetadataReaderHost host )
        {
            PdbReader symbol = null;
            try
            {
                string symbolFile = Path.ChangeExtension(file, ".pdb");
                if (File.Exists(symbolFile))
                    symbol = new PdbReader(File.Open(symbolFile, FileMode.Open, FileAccess.Read), host);
            }
            catch (Exception)
            {
                // yum yum, i feel dirty writing this.
                symbol = null;
            }
            return symbol;
        }

        



        static void Main(string[] args)
        {
            Inspector gadget = new Inspector();
            gadget.Inspect("*.*");
            gadget.Inspectors.Add(new MethodInspector());
#if DEBUG
            Console.WriteLine("press any key to exit...");
            Console.ReadLine();
#endif            
        }
    }
}

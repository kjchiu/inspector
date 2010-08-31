using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;

namespace Inspector
{
    interface IInspector
    {
        void Inspect(IAssembly assembly, PdbReader symbol);
        void Inspect(IAssembly assembly, INamedTypeDefinition type, PdbReader symbol);
        void Inspect(IAssembly assembly, INamedTypeDefinition type, IMethodDefinition method, PdbReader symbol);
    }
}

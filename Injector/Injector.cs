using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci.MutableCodeModel;

namespace Injector
{
    class Injector
    {
        public static void Inject(MethodDefinition method, Block block)
        {
            Inject(method, block, 0);
        }

        public static void Inject(MethodDefinition method, Block block, int offset)
        {
            for (int i = 0; i < block.Instructions.Count; ++i)
            {
                (method.Body as MethodBody).Operations.Insert(offset + i, block.Instructions[i]);
            }
        }
    }
}

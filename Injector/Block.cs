using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci.MutableCodeModel;

namespace Injector
{
    class Block
    {
        private List<Operation> instructions;

        public List<Operation> Instructions
        {
            get { return this.instructions; }
        }
    
        public Block this[Func<Operation> op]
        {
            get 
            {
                this.instructions.Add(op());
                return this; 
            }
        }

        public Block this[Func<object, Operation> op, object arg]
        {
            get
            {
                this.instructions.Add(op(arg));
                return this;
            }
        }

        public Block this[Func<object, object, Operation> op, object argA, object argB]
        {
            get
            {
                this.instructions.Add(op(argA, argB));
                return this;
            }
        }
        
        public Block()
        {
            instructions = new List<Operation>();
        }





    }
}

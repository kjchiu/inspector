using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspector.Data
{
    class MethodInfo
    {
        /// <summary>
        /// Method name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type containing method definition
        /// </summary>
        public string ContainingType { get; set;  }

        /// <summary>
        /// List of method calls
        /// </summary>
        public IEnumerable<MethodCall> MethodCalls { get; set; }

        /// <summary>
        /// List of local variable definitions
        /// </summary>
        public IEnumerable<Variable> LocalVariables { get; set; }

        /// <summary>
        /// List of arguments
        /// </summary>
        public IEnumerable<Variable> Arguments { get; set; }
    }
}

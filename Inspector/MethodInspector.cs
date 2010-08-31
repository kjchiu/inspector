using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data = Inspector.Data;
using cci = Microsoft.Cci;

namespace Inspector
{
    class MethodInspector : IInspector
    {
        public delegate void HandleMethod(data.MethodInfo method);
        public void Inspect(cci.IAssembly assembly, cci.PdbReader symbol)
        {
            
        }

        public void Inspect(cci.IAssembly assembly, cci.INamedTypeDefinition type, cci.PdbReader symbol)
        {
            
        }

        public void Inspect(cci.IAssembly assembly, cci.INamedTypeDefinition type, cci.IMethodDefinition method, cci.PdbReader symbol)
        {
            data.MethodInfo info = new data.MethodInfo();
            info.MethodCalls = ParseMethodCalls(method);
            
        }

       

        /// <summary>
        /// Return lazy list of method calls in given method
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private IEnumerable<data.MethodCall> ParseMethodCalls(cci.IMethodDefinition method)
        {
            foreach (var callOp in from cci.IOperation op in method.Body.Operations where IsCallOperation(op) select op)
            {
                data.MethodCall call = new data.MethodCall();
                call.TargetName = ParseTargetMethodName(callOp.Value as dynamic);
                call.TargetType = method.ContainingType.ToString(); // relying on a horrible quirk for now
                yield return call;
            }
        }
        
        private IEnumerable<data.Variable> ParseLocalVariables(cci.IMethodDefinition method, cci.PdbReader symbol)
        {

            IEnumerable<cci.ILocalDefinition> locals;
            if (symbol != null)
            {
                locals = from cci.ILocalDefinition localVar in symbol.GetLocalScopes(method.Body).SelectMany<cci.ILocalScope, cci.ILocalDefinition>(symbol.GetVariablesInScope) select localVar;                       
            }
            else
            {
                locals = method.Body.LocalVariables;
            }
            foreach(cci.ILocalDefinition local in locals)
            {
                data.Variable variable = new data.Variable();
                variable.Name = local.Name.Value;
                variable.Type = ParseTypeName(local.Type);
                yield return variable;
            }
        }

        #region Utils
        
        /// <summary>
        /// Returns true of given operation is a parseable function call.
        /// </summary>
        /// <param name="operation"></param>
        /// <returns>Currently calli is unsupported as the argument is an offset and not an explicit function signature.</returns>
        private bool IsCallOperation(cci.IOperation operation)
        {
            return operation.OperationCode == cci.OperationCode.Call || operation.OperationCode == cci.OperationCode.Callvirt;
        }

        private string ParseTypeName(cci.ITypeReference type)
        {
            cci.INamedTypeReference namedType = type as cci.INamedTypeReference;
            if (namedType != null) 
                return namedType.Name.Value;
            else 
                return "[?]";

        }

        #region ParseTargetMethodName
        /// <summary>
        /// catch all case
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private string ParseTargetMethodName(object method)
        {
            return string.Empty;
        }

        /// <summary>
        /// generic method reference case
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private string ParseTargetMethodName(cci.IGenericMethodInstanceReference method)
        {
            return method.Name.Value;
        }

        /// <summary>
        /// general method reference
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private string ParseTargetMethodName(cci.IMethodReference method)
        {
            return method.Name.Value;
        }
        #endregion
        #endregion
    }
}

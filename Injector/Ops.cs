using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using Microsoft.Cci.MutableCodeModel;

namespace Injector
{
    public abstract class Ops
    {

        #region " Op Code List"

        public static Func<Operation> Add
        {
            get { return () => new Operation() { OperationCode = OperationCode.Add }; }
        }

        public static Func<Operation> Add_Ovf
        {
            get { return () => new Operation() { OperationCode = OperationCode.Add_Ovf }; }
        }

        public static Func<Operation> Add_Ovf_Unc
        {
            get { return () => new Operation() { OperationCode = OperationCode.Add_Ovf_Un }; }
        }

        public static Func<Operation> And
        {
            get { return () => new Operation() { OperationCode = OperationCode.And }; }
        }

        public static Func<Operation> Arglist
        {
            get { return () => new Operation() { OperationCode = OperationCode.Arglist }; }
        }

        #region " Conditional Branch "
        
        public static Func<object, Operation> Beq
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Beq, Value = offset } ;}
        }

        public static Func<object, Operation> Beq_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Beq_S, Value = offset }; }
        }

        public static Func<object, Operation> Bne_Un
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bne_Un, Value = offset }; }
        }

        public static Func<object, Operation> Bne_Un_s
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bne_Un_S, Value = offset }; }
        }

        public static Func<object, Operation> Bge
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bge, Value = offset }; }
        }

        public static Func<object, Operation> Bge_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bge_S, Value = offset }; }
        }

        public static Func<object, Operation> Bge_Un
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bge_Un, Value = offset }; }
        }

        public static Func<object, Operation> Bge_Un_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bge_Un_S, Value = offset }; }
        }

        public static Func<object, Operation> Bgt
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bgt, Value = offset }; }
        }

        public static Func<object, Operation> Bgt_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bgt_S, Value = offset }; }
        }

        public static Func<object, Operation> Bgt_Un
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bgt_Un, Value = offset }; }
        }

        public static Func<object, Operation> Bgt_Un_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Bgt_Un_S, Value = offset }; }
        }


        public static Func<object, Operation> Ble
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Ble, Value = offset }; }
        }

        public static Func<object, Operation> Ble_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Ble_S, Value = offset }; }
        }

        public static Func<object, Operation> Ble_Un
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Ble_Un, Value = offset }; }
        }

        public static Func<object, Operation> Ble_Un_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Ble_Un_S, Value = offset }; }
        }

        public static Func<object, Operation> Blt
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Blt, Value = offset }; }
        }

        public static Func<object, Operation> Blt_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Blt_S, Value = offset }; }
        }

        public static Func<object, Operation> Blt_Un
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Blt_Un, Value = offset }; }
        }

        public static Func<object, Operation> Blt_Un_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Blt_Un_S, Value = offset }; }
        }

        #endregion

        public static Func<object, Operation> Br
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Br, Value = offset }; }
        }

        public static Func<object, Operation> Br_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Br_S, Value = offset }; }
        }

        public static Func<object, Operation> Brtrue
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Brtrue, Value = offset }; }
        }

        public static Func<object, Operation> Brtrue_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Brtrue_S, Value = offset }; }
        }

        public static Func<object, Operation> Brfalse
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Brfalse, Value = offset }; }
        }

        public static Func<object, Operation> Brfalse_S
        {
            get { return (object offset) => new Operation() { OperationCode = OperationCode.Brfalse_S, Value = offset }; }
        }

        public static Func<Operation> Box
        {
            get { return () => new Operation() { OperationCode = OperationCode.Box }; }
        }

        public static Func<object, Operation> Call
        {
            get { return (object method) => new Operation() { OperationCode = OperationCode.Call, Value = method }; }
        }

        public static Func<object, Operation> Calli
        {
            get { return (object method) => new Operation() { OperationCode = OperationCode.Calli, Value = method }; }
        }

        public static Func<object, Operation> Callvirt
        {
            get { return (object method) => new Operation() { OperationCode = OperationCode.Callvirt, Value = method }; }
        }

        public static Func<Operation> Ceq
        {
            get { return () => new Operation() { OperationCode = OperationCode.Ceq }; }
        }

        public static Func<Operation> Cgt
        {
            get { return () => new Operation() { OperationCode = OperationCode.Cgt }; }
        }

        public static Func<Operation> Cgt_Un
        {
            get { return () => new Operation() { OperationCode = OperationCode.Cgt_Un }; }
        }

        public static Func<Operation> Clt
        {
            get { return () => new Operation() { OperationCode = OperationCode.Clt }; }
        }

        public static Func<Operation> Clt_Un
        {
            get { return () => new Operation() { OperationCode = OperationCode.Clt_Un }; }
        }

        public static Func<Operation> Ckfinite
        {
            get { return () => new Operation() { OperationCode = OperationCode.Ckfinite }; }
        }

        public static Func<object, Operation> Constrained
        {
            get { return (object type) => new Operation() { OperationCode = OperationCode.Constrained_, Value = (Type)type }; }
        }

        public static Func<object, Operation> Ldstr
        {
            get { return (object str) => new Operation() { OperationCode = OperationCode.Ldstr, Value = (string)str}; }
        }

        public static Func<object, Operation> Ldarg
        {
            get { return (object index) => new Operation() { OperationCode = OperationCode.Ldarg, Value = (int)index }; }
        }

        public static Func<object, Operation> Newobj
        {
            get { return (object type) => new Operation() { OperationCode = OperationCode.Newobj, Value = (Type)type }; }
        }

        public static Func<Operation> Throw
        {
            get { return () => new Operation() { OperationCode = OperationCode.Throw }; }
        }

        #endregion        
    }  
    

}

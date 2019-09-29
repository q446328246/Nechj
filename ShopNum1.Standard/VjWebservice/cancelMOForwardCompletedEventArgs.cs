using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace ShopNum1.Standard.VjWebservice
{
    [GeneratedCode("System.Web.Services", "2.0.50727.1433"), DesignerCategory("code"), DebuggerStepThrough]
    public class cancelMOForwardCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly object[] object_0;

        internal cancelMOForwardCompletedEventArgs(object[] object_1, Exception exception_0, bool bool_0,
                                                   object object_2) : base(exception_0, bool_0, object_2)
        {
            object_0 = object_1;
        }

        public int Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (int) object_0[0];
            }
        }
    }
}
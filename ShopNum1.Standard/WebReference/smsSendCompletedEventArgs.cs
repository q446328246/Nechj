using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace ShopNum1.Standard.WebReference
{
    [GeneratedCode("System.Web.Services", "2.0.50727.3053"), DebuggerStepThrough, DesignerCategory("code")]
    public class smsSendCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly object[] object_0;

        internal smsSendCompletedEventArgs(object[] object_1, Exception exception_0, bool bool_0, object object_2)
            : base(exception_0, bool_0, object_2)
        {
            object_0 = object_1;
        }

        public string Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (string) object_0[0];
            }
        }
    }
}
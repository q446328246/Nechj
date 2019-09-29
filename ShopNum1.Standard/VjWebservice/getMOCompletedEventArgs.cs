using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace ShopNum1.Standard.VjWebservice
{
    [GeneratedCode("System.Web.Services", "2.0.50727.1433"), DebuggerStepThrough, DesignerCategory("code")]
    public class getMOCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly object[] object_0;

        internal getMOCompletedEventArgs(object[] object_1, Exception exception_0, bool bool_0, object object_2)
            : base(exception_0, bool_0, object_2)
        {
            object_0 = object_1;
        }

        public GClass0[] Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (GClass0[]) object_0[0];
            }
        }
    }
}
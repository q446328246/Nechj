using System;
using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class EmailVerificationSuccess : BaseWebControl, ICallbackEventHandler
    {
        private string skinFilename = "E-mailVerificationSuccess.ascx";

        public EmailVerificationSuccess()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string GetCallbackResult()
        {
            throw new NotImplementedException();
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeSkin(Control skin)
        {
        }
    }
}
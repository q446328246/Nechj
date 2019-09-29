using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class FindPasswordSuccess : BaseWebControl, ICallbackEventHandler
    {
        private LinkButton LinkButtonLogin;
        private string skinFilename = "FindPasswordSuccess.ascx";

        public FindPasswordSuccess()
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
            LinkButtonLogin = (LinkButton) skin.FindControl("LinkButtonLogin");
            if (!Page.IsPostBack)
            {
                LinkButtonLogin.PostBackUrl = GetPageName.RetDomainUrl("index");
            }
        }
    }
}
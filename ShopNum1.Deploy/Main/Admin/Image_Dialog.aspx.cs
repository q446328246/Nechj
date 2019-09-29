using System;
using System.Web.SessionState;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Image_Dialog : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImagePack.ImageUrl = Globals.ImagePath + Operator.FilterString(base.Request.QueryString["imagepath"]);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_TJmember : ShopNum1.Deploy.App_Code.BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (((Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type")))
            {
                case "0":
                    PanelSmember.Visible = false;
                    PanelM_Cmember.Visible = true;
                    break;

                case "1":
                    PanelSmember.Visible = true;
                    PanelM_Cmember.Visible = false;
                    break;
            }
        }
    }
}
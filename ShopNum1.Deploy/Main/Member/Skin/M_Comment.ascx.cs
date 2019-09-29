using System;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_Comment : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = (Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type");
            switch (str)
            {
                case null:
                    break;

                case "0":
                    PanelComment1.Visible = true;
                    return;

                case "1":
                    PanelComment2.Visible = true;
                    return;

                case "2":
                    PanelComment3.Visible = true;
                    return;

                default:
                    if (!(str == "3"))
                    {
                        if (!(str == "4"))
                        {
                            break;
                        }
                        PanelComment5.Visible = true;
                    }
                    else
                    {
                        PanelComment4.Visible = true;
                    }
                    return;
            }
            PanelComment1.Visible = true;
        }
    }
}
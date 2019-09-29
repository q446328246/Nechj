using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_Comment : BaseMemberWebControl
    {
        private Panel PanelComment1;
        private Panel PanelComment2;
        private Panel PanelComment3;
        private Panel PanelComment4;
        private Panel PanelComment5;
        private string skinFilename = "M_Comment.ascx";

        public M_Comment()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            PanelComment1 = (Panel) skin.FindControl("PanelComment1");
            PanelComment2 = (Panel) skin.FindControl("PanelComment2");
            PanelComment3 = (Panel) skin.FindControl("PanelComment3");
            PanelComment4 = (Panel) skin.FindControl("PanelComment4");
            PanelComment5 = (Panel) skin.FindControl("PanelComment5");
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
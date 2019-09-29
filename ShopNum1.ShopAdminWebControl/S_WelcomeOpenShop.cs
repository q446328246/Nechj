using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_WelcomeOpenShop : BaseMemberWebControl
    {
        private HtmlAnchor LinkA;
        private HtmlGenericControl divHaveOpen;
        private HtmlGenericControl divHaveOpenNo;
        private string skinFilename = "S_WelcomeOpenShop.ascx";

        public S_WelcomeOpenShop()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            divHaveOpen = (HtmlGenericControl) skin.FindControl("divHaveOpen");
            divHaveOpenNo = (HtmlGenericControl) skin.FindControl("divHaveOpenNo");
            LinkA = (HtmlAnchor) skin.FindControl("LinkA");
            try
            {
                DataTable dataInfoByMemLoginID =
                    ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetDataInfoByMemLoginID(
                        base.MemLoginID);
                if ((dataInfoByMemLoginID != null) && (dataInfoByMemLoginID.Rows.Count > 0))
                {
                    LinkA.HRef = "/Shop/ShopAdmin/S_ShopOpenStep3.aspx?type=have";
                }
                else
                {
                    LinkA.HRef = "/Shop/ShopAdmin/S_ShopOpenStep1.aspx";
                }
            }
            catch (Exception)
            {
                LinkA.HRef = "/Shop/ShopAdmin/S_ShopOpenStep1.aspx";
            }
            string str = Common.Common.GetNameById("MemberType", "ShopNum1_Member",
                "  AND  MemLoginID='" + base.MemLoginID + "'  ");
            if (!(string.IsNullOrEmpty(str) || !(str == "2")))
            {
                divHaveOpen.Visible = true;
                divHaveOpenNo.Visible = false;
            }
            else
            {
                divHaveOpen.Visible = false;
                divHaveOpenNo.Visible = true;
            }
        }
    }
}
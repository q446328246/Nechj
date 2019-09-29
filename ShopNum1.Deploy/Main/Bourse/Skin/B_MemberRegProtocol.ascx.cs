using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Bourse.Skin
{
    [ParseChildren(true)]
    public partial class B_MemberRegProtocol : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                GetRegProtocolInfo();
            }
        }
        protected void GetRegProtocolInfo()
        {
            labelRegProtocol.Text = Page.Server.HtmlDecode(ShopSettings.GetValue("abc"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // QUERY
        string c=    Request.QueryString["B"];   
            var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            int GetIsShopActivate = memberrankguid_Action.UpdateIsShopActivate(base.MemLoginID);
            if (GetIsShopActivate!=0)
            {

               // Response.Redirect(string.Format(c+".aspx"));

                Response.Redirect(string.Format("http://{0}{1}", ShopSettings.siteDomain, "/main/Bourse/" + c + ".aspx"), true);
            }
            else
            {
                Response.Write("<script>alert('出错了再试一次！');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("http://{0}{1}", ShopSettings.siteDomain, "/main/Bourse/B_Welcome.aspx"), true);
        //    Response.Redirect(string.Format("B_Welcome.ascx"), true);
        }
    }
}
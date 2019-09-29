using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Encryption;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Api
{
    public partial class userCheck : Page, IRequiresSessionState
    {
        private readonly ShopNum1_Member_Action shopNum1_Member_Action_0 =
            ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["otype"] == null)
            {
                base.Response.Write("notarget");
            }
            else
            {
                method_0(Page.Request["otype"]);
            }
        }

        private void method_0(string string_0)
        {
            string str = string_0;
            switch (str)
            {
                case null:
                    break;

                case "checkemail":
                    if (base.Request["email"] != null)
                    {
                        string email = base.Request["email"];
                        DataTable table = shopNum1_Member_Action_0.MemberFindPwdPro(email);
                        if ((table == null) || (table.Rows.Count == 0))
                        {
                            base.Response.Write("notfind");
                        }
                        else
                        {
                            base.Response.Write("success");
                        }
                    }
                    else
                    {
                        base.Response.Write("notarget");
                    }
                    return;

                default:
                    if (str != "checklogin")
                    {
                        if (!(str == "checkshopname"))
                        {
                            break;
                        }
                        string name = Page.Request["shopname"];
                        if (LogicFactory.CreateShopNum1_ShopInfoList_Action().CheckShopName(name) > 0)
                        {
                            base.Response.Write("success");
                        }
                        else
                        {
                            base.Response.Write("failed");
                        }
                    }
                    else
                    {
                        string memLoginID = string.Empty;
                        string input = string.Empty;
                        try
                        {
                            memLoginID = base.Request["memlogid"];
                            input = base.Request["pwd"];
                        }
                        catch
                        {
                            base.Response.Write("notarget");
                        }
                        if (shopNum1_Member_Action_0.CheckPassword(memLoginID, DESEncrypt.Decrypt(input)) > 0)
                        {
                            base.Response.Write("success");
                        }
                        else
                        {
                            base.Response.Write("notfind");
                        }
                    }
                    return;
            }
            base.Response.Write("notarget");
        }
    }
}
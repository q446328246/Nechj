using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Left : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_Page_Action shopNum1_Page_Action_0 =
            ((ShopNum1_Page_Action) LogicFactory.CreateShopNum1_Page_Action());

        private bool bool_0;
        private DataTable dt;
        private DataTable dataTable_1;

        protected void BindMenu()
        {
            if (hiddenFieldGuid.Value == "9F1B9C51-F8F3-42C8-8465-501C5F3D1D1B".ToLower())
            {
                dataTable_1 = shopNum1_Page_Action_0.GetOnePageBySuper(0);
                bool_0 = true;
                dt = shopNum1_Page_Action_0.GetTwopageBySupper(-1, 0);
            }
            else
            {
                dataTable_1 = shopNum1_Page_Action_0.GetOnePage(hiddenFieldGuid.Value, 0);
            }
            RepeaterMenu.DataSource = dataTable_1;
            RepeaterMenu.DataBind();
            if ((dataTable_1 != null) && (dataTable_1.Rows.Count > 0))
            {
                var repeater = (Repeater) RepeaterMenu.Items[dataTable_1.Rows.Count - 1].FindControl("RepeaterChild");
                for (int i = 0; i < repeater.Items.Count; i++)
                {
                    var localize = (Localize) repeater.Items[i].FindControl("LocalizeImgLeft");
                    localize.Text = "<img src='images/s.jpg'/>";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (base.Request.Cookies["AdminLoginCookie"] != null)
                {
                    HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    hiddenFieldGuid.Value = cookie2.Values["Guid"];
                }
                else
                {
                    base.Response.Redirect("~/Admin/Html/Nopower.html");
                }
            }
            BindMenu();
        }

        protected void RepeaterMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var table = new DataTable();
            var field = e.Item.FindControl("HiddenFieldOneID") as HiddenField;
            if (bool_0)
            {
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    string format = "OneID='{0}'";
                    string sort = "OrderID DESC";
                    format = string.Format(format, field.Value);
                    DataRow[] source = dt.Select(format, sort);
                    if ((source != null) && (source.Length > 0))
                    {
                        table = source.CopyToDataTable<DataRow>();
                    }
                }
            }
            else
            {
                table = shopNum1_Page_Action_0.GetTwopage(hiddenFieldGuid.Value, Convert.ToInt32(field.Value), 0);
            }
            var repeater = e.Item.FindControl("RepeaterChild") as Repeater;
            repeater.DataSource = table;
            repeater.DataBind();
            if ((table != null) && (table.Rows.Count > 0))
            {
                var localize = (Localize) repeater.Items[table.Rows.Count - 1].FindControl("Localizeimg");
                localize.Text =
                    "<img src='images/icon_line_Last.gif' id='img_Line' runat ='server' style='border-width:0;'/>";
            }
        }
    }
}
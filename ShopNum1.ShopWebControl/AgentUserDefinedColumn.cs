using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class AgentUserDefinedColumn : BaseWebControl
    {
        private Literal LiteralMenu;
        private string skinFilename = "AgentUserDefinedColumn.ascx";

        public AgentUserDefinedColumn()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ColumnType { get; set; }

        public string IfShow { get; set; }

        protected string ShopID { get; set; }

        public string ChangeIfOpen(string ifOpen)
        {
            if (ifOpen == "0")
            {
                return "_self";
            }
            return "_blank";
        }

        public void CreateNav()
        {
            DataTable table =
                ((Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action())
                    .SearchUserDefinedColumnList(IfShow, ColumnType);
            var builder = new StringBuilder();
            builder.Append("<div id=\"mainNav\"><ul class=\"menuList\">");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (i < table.Rows.Count)
                {
                    string str5 = SetUrl(table.Rows[i]["LinkAddress"]);
                    string str3 = table.Rows[i]["Name"].ToString();
                    string str2 = ChangeIfOpen(table.Rows[i]["IfOpen"].ToString());
                    if (table.Rows[i]["LinkAddress"].ToString().IndexOf("://") > 0)
                    {
                        if ((Page.Request.Cookies["BBsPath"] != null) &&
                            ((table.Rows[i]["LinkAddress"].ToString().ToLower().IndexOf("bbs") > 0) ||
                             (table.Rows[i]["LinkAddress"].ToString().ToLower().IndexOf("www.sqpai.com") > 0)))
                        {
                            string str = Page.Request.Cookies["BBsPath"].Value;
                            builder.Append("<li><a href=\"" + str + "\" target=\"" + str2 + "\">" + str3 + "</a></li>");
                        }
                        else
                        {
                            builder.Append(
                                string.Concat(new[]
                                {
                                    "<li><a href=\"", table.Rows[i]["LinkAddress"], "\" target=\"", str2, "\">",
                                    str3,
                                    "</a></li>"
                                }));
                        }
                    }
                    else
                    {
                        string str4 = Page.Request.RawUrl.ToLower().Replace(".aspx", ".html");
                        if (str4 == "/")
                        {
                            str4 = "/default.aspx";
                        }
                        if ((str5.ToLower().IndexOf(str4) != -1) ||
                            ((Page.Request.Path.ToLower() == "/default.aspx") && (str3 == "首页")))
                        {
                            builder.Append("<li><a href=\"" + str5 + "\" target=\"" + str2 + "\" class=\"selectStyle\">" +
                                           str3 + "</a></li>");
                        }
                        else
                        {
                            builder.Append("<li><a href=\"" + str5 + "\" target=\"" + str2 + "\">" + str3 + "</a></li>");
                        }
                    }
                }
            }
            builder.Append("</ul></div>");
            LiteralMenu.Text = builder.ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            LiteralMenu = (Literal) skin.FindControl("LiteralMenu");
            CreateNav();
        }

        public string SetUrl(object object_0)
        {
            return ("http://" + ShopSettings.siteDomain + "/" +
                    object_0.ToString().Replace(".aspx", "").Replace(".html", "") +
                    (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"));
        }
    }
}
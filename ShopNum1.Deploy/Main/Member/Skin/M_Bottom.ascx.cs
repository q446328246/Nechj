using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_Bottom : BaseMemberControl
    {
        public string GetOverrideUrlName()
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ShopSettings.overrideUrlName;
            }
            return ".aspx";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
            LabelShopCopy.Text = ShopSettings.GetValue("CopyrightShop");
        }

        protected void BindData()
        {
            DataTable table = Common.Common.GetTableById("*", "ShopNum1_UserDefinedColumn",
                "  AND    ShowLocation=1 AND    IsMember =1 and ifshow=1  ORDER  BY   OrderID  DESC   ");
            if (table != null)
            {
                var builder = new StringBuilder();
                string str2 = string.Empty;
                if (Page.Request.QueryString["tag"] != null)
                {
                    str2 = Page.Request.QueryString["tag"];
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string str = table.Rows[i]["LinkAddress"].ToString();
                    if (str.Contains("http://"))
                    {
                        if (str.Contains("?"))
                        {
                            builder.Append(string.Concat(new object[] {"<a id=lia", i, " href='", str, "'"}));
                        }
                        else
                        {
                            builder.Append(string.Concat(new object[] {"<a id=lia", i, " href='", str, "'"}));
                        }
                    }
                    else
                    {
                        builder.Append(
                            string.Concat(new object[]
                            {
                                "<a id=lia", i, " href='http://", ShopSettings.siteDomain, "/", str,
                                GetOverrideUrlName(), "'"
                            }));
                    }
                    if ((str2 == string.Empty) && (Page.Request.RawUrl.ToLower().Contains("default") && (i == 0)))
                    {
                        builder.Append(" class=\"curr\" ");
                        builder.Append(" target='" + method_1(table.Rows[i]["IfOpen"].ToString()) + "'>");
                        builder.Append(table.Rows[i]["Name"] + "</a>|");
                        builder.AppendLine("</li>");
                    }
                    else
                    {
                        if (str2 == i.ToString())
                        {
                            builder.Append(" class=\"curr\" ");
                        }
                        else
                        {
                            builder.Append(" style=''");
                        }
                        builder.Append(" target='" + method_1(table.Rows[i]["IfOpen"].ToString()) + "'>");
                        builder.Append(table.Rows[i]["Name"] + "</a>|");
                    }
                }
                try
                {
                    LiteralShowMenu.Text = builder.ToString().Substring(0, builder.ToString().Length - 1);
                }
                catch (Exception)
                {
                    LiteralShowMenu.Text = "";
                }
            }
        }

        private string method_1(string string_1)
        {
            if (string_1 == "0")
            {
                string_1 = "_self";
                return string_1;
            }
            if (string_1 == "1")
            {
                string_1 = "_blank";
            }
            return string_1;
        }
    }
}
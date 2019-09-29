using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_SeeBuyRate_Report : BaseShopWebControl
    {
        private string skinFilename = "S_SeeBuyRate_Report.ascx";

        public S_SeeBuyRate_Report()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                if (HttpSecureCookie.Decode(cookie).Values["MemberType"] != "2")
                {
                    GetUrl.RedirectTopLogin();
                    return;
                }
            }
            if (!Page.IsPostBack &&
                ((((Page.Request["MemLoginID"] != null) && (Page.Request["SaleNumber1"] != null)) &&
                  ((Page.Request["SaleNumber1"] != null) && (Page.Request["ClickCount1"] != null))) &&
                 (Page.Request["ClickCount1"] != null)))
            {
                Page.Response.Clear();
                string str = Page.Request.QueryString["Type"];
                if (str == "xls")
                {
                    Page.Response.Charset = "UTF-8";
                    Page.Response.ContentEncoding = Encoding.GetEncoding("gbk");
                    Page.Response.ContentType = "Application/ms-excel";
                }
                else
                {
                    Page.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                }
                Page.Response.AppendHeader("Content-Disposition",
                    "attachment;filename=\"SellBuyRate_Report" +
                    DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                BindData();
                Page.Response.Flush();
                Page.Response.Close();
                Page.Response.End();
            }
        }

        protected void BindData()
        {
            string shopID = Page.Request["MemLoginID"];
            string str2 = Page.Request["SaleNumber1"];
            string str3 = Page.Request["SaleNumber2"];
            string str4 = Page.Request["ClickCount1"];
            string str5 = Page.Request["ClickCount2"];
            string productName = Page.Request["ProductName"];
            DataTable table = ((Shop_Report_Action) LogicFactory.CreateShop_Report_Action()).SearchClickCount(shopID,
                str2, str3,
                str4, str5,
                productName);
            if ((table != null) && (table.Rows.Count > 0))
            {
                Page.Response.Write("<table width=\"100%\">");
                Page.Response.Write("<tr bgcolor=\"#6699cc\">");
                Page.Response.Write(" <td style=\"text-align:center;\">商品名称</td>");
                Page.Response.Write("<td style=\"text-align:center;\">货号</td>");
                Page.Response.Write("<td style=\"text-align:center;\">访问量</td>");
                Page.Response.Write("<td style=\"text-align:center;\">销售量</td>");
                Page.Response.Write("<td style=\"text-align:center;\">访问购买率</td>");
                Page.Response.Write("<tr>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Page.Response.Write("<tr>");
                    Page.Response.Write("<td align=\"center\" width=\"300\"> {Name}</td>".Replace("{Name}",
                        table.Rows[i]["Name"]
                            .ToString()));
                    Page.Response.Write("<td width=\"150\" align=\"center\"> {ProductNum}</td>".Replace("{ProductNum}",
                        "_" +
                        table.Rows[i][
                            "ProductNum"
                            ]));
                    Page.Response.Write("<td width=\"100\" align=\"center\"> {ClickCount}</td>".Replace("{ClickCount}",
                        table.Rows[i][
                            "ClickCount"
                            ].ToString()));
                    Page.Response.Write("<td width=\"100\" align=\"center\"> {SaleNumber}</td>".Replace("{SaleNumber}",
                        table.Rows[i][
                            "SaleNumber"
                            ].ToString()));
                    Page.Response.Write("<td width=\"100\" align=\"center\"> {BuyRate}</td>".Replace("{BuyRate}",
                        table.Rows[i][
                            "BuyRate"]
                            .ToString()));
                    Page.Response.Write("</tr>");
                }
                Page.Response.Write("</table>");
            }
        }
    }
}
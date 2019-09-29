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
    public class S_Stock_Report : BaseShopWebControl
    {
        private string skinFilename = "S_Stock_Report.ascx";

        public S_Stock_Report()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                if (HttpSecureCookie.Decode(cookie).Values["MemberType"] != "2")
                {
                    GetUrl.RedirectTopLogin();
                    return;
                }
            }
            if (!Page.IsPostBack &&
                ((((Page.Request["ProductCategoryCode"] != null) && (Page.Request["SaleNumber1"] != null)) &&
                  ((Page.Request["SaleNumber2"] != null) && (Page.Request["RepertoryCount1"] != null))) &&
                 (Page.Request["RepertoryCount2"] != null)))
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
                    "attachment;filename=\"StockReport_" + DateTime.Now.ToString("yyyymmddhhmm") +
                    "." + str + "\"");
                BindData();
                Page.Response.Flush();
                Page.Response.Close();
                Page.Response.End();
            }
        }

        protected void BindData()
        {
            string str = Page.Request["SaleNumber1"];
            string str2 = Page.Request["SaleNumber2"];
            string str3 = Page.Request["RepertoryCount1"];
            string str4 = Page.Request["RepertoryCount2"];
            string productname = Page.Request["productname"];
            string memLoginID = Page.Request["MemLoginID"];
            DataTable table = ((Shop_Report_Action) LogicFactory.CreateShop_Report_Action()).Search(memLoginID,
                Page.Request[
                    "ProductCategoryCode"
                    ], str, str2,
                str3, str4,
                productname);
            if ((table != null) && (table.Rows.Count > 0))
            {
                Page.Response.Write("<table width=\"100%\">");
                Page.Response.Write("<tr bgcolor=\"#6699cc\" style=\"text-align:center;\">");
                Page.Response.Write(" <td  style=\"text-align:center;\">商品名称</td>");
                Page.Response.Write(" <td  style=\"text-align:center;\">所属分类</td>");
                Page.Response.Write("<td  style=\"text-align:center;\">货号</td>");
                Page.Response.Write("<td  style=\"text-align:center;\">已销售量</td>");
                Page.Response.Write("<td  style=\"text-align:center;\">剩余库存量</td>");
                Page.Response.Write("<tr  style=\"text-align:center;\">");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Page.Response.Write("<tr>");
                    Page.Response.Write("<td align=\"center\" width=\"300\"> {Name}</td>".Replace("{Name}",
                        table.Rows[i]["Name"]
                            .ToString()));
                    Page.Response.Write(
                        "<td align=\"center\" width=\"150\"> {ProductSeriesName}</td>".Replace("{ProductSeriesName}",
                            table.Rows[i][
                                "ProductSeriesName"]
                                .ToString()));
                    if (table.Rows[i]["ProductNum"].ToString().Trim() != "")
                    {
                        Page.Response.Write(
                            "<td align=\"center\" width=\"200\"> {ProductNum}</td>".Replace("{ProductNum}",
                                "_" +
                                table.Rows[i]["ProductNum"]));
                    }
                    else
                    {
                        Page.Response.Write(
                            "<td align=\"center\" width=\"200\"> {ProductNum}</td>".Replace("{ProductNum}",
                                table.Rows[i]["ProductNum"]
                                    .ToString() ?? ""));
                    }
                    Page.Response.Write("<td align=\"center\" width=\"100\"> {SaleNumber}</td>".Replace("{SaleNumber}",
                        table.Rows[i][
                            "SaleNumber"
                            ].ToString()));
                    Page.Response.Write(
                        "<td align=\"center\" width=\"100\"> {RepertoryCount}</td>".Replace("{RepertoryCount}",
                            table.Rows[i][
                                "RepertoryCount"]
                                .ToString()));
                    Page.Response.Write("</tr>");
                }
                Page.Response.Write("</table>");
            }
        }
    }
}
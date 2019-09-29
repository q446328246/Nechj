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
    public class S_ShopSellOrder_Report : BaseShopWebControl
    {
        private string skinFilename = "S_ShopSellOrder_Report.ascx";

        public S_ShopSellOrder_Report()
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
                (((Page.Request["MemLoginID"] != null) && (Page.Request["textBoxTime1"] != null)) &&
                 (Page.Request["textBoxTime2"] != null)))
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
                    "attachment;filename=\"ShopSellOrder_Report" +
                    DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                BindData();
                Page.Response.Output.Flush();
                Page.Response.End();
            }
        }

        protected void BindData()
        {
            string memLoginID = Page.Request["MemLoginID"];
            string str2 = Page.Request["textBoxTime1"];
            string str3 = Page.Request["textBoxTime2"];
            string productName = Page.Request["ProductName"];
            DataTable table =
                ((Shop_Report_Action)LogicFactory.CreateShop_Report_Action()).SearchShopSellOrder(memLoginID, str2,
                    str3, productName);
            if ((table != null) && (table.Rows.Count > 0))
            {
                Page.Response.Output.Write("<table width=\"100%\">");
                Page.Response.Output.Write("<tr bgcolor=\"#6699cc\">");
                Page.Response.Output.Write(" <td>商品名称</td>");
                Page.Response.Output.Write("<td>货号</td>");
                Page.Response.Output.Write("<td>销售数量</td>");
                Page.Response.Output.Write("<td>销售额</td>");
                Page.Response.Output.Write("<td>均价</td>");
                Page.Response.Output.Write("<tr>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Page.Response.Output.Write("<tr>");
                    Page.Response.Output.Write("<td width=\"100\" align=\"center\"> {ProductName}</td>".Replace(
                        "{ProductName}", table.Rows[i]["ProductName"].ToString()));
                    Page.Response.Output.Write(
                        "<td width=\"100\" align=\"center\"> {RepertoryNumber}</td>".Replace("{RepertoryNumber}",
                            table.Rows[i][
                                "RepertoryNumber"]
                                .ToString()));
                    Page.Response.Output.Write("<td width=\"100\" align=\"center\"> {BuyNumber}</td>".Replace("{BuyNumber}",
                        table.Rows[i][
                            "BuyNumber"]
                            .ToString()));
                    Page.Response.Output.Write("<td width=\"100\" align=\"center\"> {BuyPrice}</td>".Replace("{BuyPrice}",
                        table.Rows[i][
                            "BuyPrice"]
                            .ToString()));
                    Page.Response.Output.Write(
                        "<td width=\"100\" align=\"center\"> {AveragePrice}</td>".Replace("{AveragePrice}",
                            table.Rows[i]["AveragePrice"]
                                .ToString()));
                    Page.Response.Output.Write("</tr>");
                }
                Page.Response.Output.Write("</table>");
            }
        }
    }
}
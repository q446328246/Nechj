using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SellOrder_Report : PageBase, IRequiresSessionState
    {
        private void BindData()
        {
            DataTable table =
                ((ShopNum1_Report_Action) LogicFactory.CreateShopNum1_Report_Action()).SearchSellOrder(
                    Page.Request.QueryString["pname"], Page.Request.QueryString["sname"],
                    Page.Request.QueryString["DispatchTime1"], Page.Request.QueryString["DispatchTime2"]);
            if ((table != null) && (table.Rows.Count > 0))
            {
                base.Response.Write("<table width=\"100%\">");
                base.Response.Write("<tr bgcolor=\"#6699cc\">");
                base.Response.Write(" <td align=\"center\">商品名称</td>");
                base.Response.Write("<td align=\"center\">商铺名称</td>");
                base.Response.Write("<td align=\"center\">货号</td>");
                base.Response.Write("<td align=\"center\">销售数量</td>");
                base.Response.Write("<td align=\"center\">销售额</td>");
                base.Response.Write("<td align=\"center\">均价</td>");
                base.Response.Write("<td align=\"center\">邮费</td>");
                base.Response.Write("</tr>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    base.Response.Write("<tr>");
                    base.Response.Write("<td align=\"center\" width=\"100\"> {ProductName}</td>".Replace(
                        "{ProductName}", table.Rows[i]["ProductName"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {ShopName}</td>".Replace("{ShopName}",
                                                                                                      table.Rows[i][
                                                                                                          "ShopName"]
                                                                                                          .ToString()));
                    base.Response.Write(
                        "<td align=\"center\" width=\"100\"> {RepertoryNumber}</td>".Replace("{RepertoryNumber}",
                                                                                             table.Rows[i][
                                                                                                 "RepertoryNumber"]
                                                                                                 .ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {BuyNumber}</td>".Replace("{BuyNumber}",
                                                                                                       table.Rows[i][
                                                                                                           "BuyNumber"]
                                                                                                           .ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {BuyPrice}</td>".Replace("{BuyPrice}",
                                                                                                      table.Rows[i][
                                                                                                          "BuyPrice"]
                                                                                                          .ToString()));
                    base.Response.Write(
                        "<td align=\"center\" width=\"100\"> {AveragePrice}</td>".Replace("{AveragePrice}",
                                                                                          table.Rows[i]["AveragePrice"]
                                                                                              .ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {FeePay}</td>".Replace("{FeePay}",
                                                                                                    table.Rows[i][
                                                                                                        "dispatchprice"]
                                                                                                        .ToString()));
                    base.Response.Write("</tr>");
                }
                base.Response.Write("</table>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack && ((Page.Request["DispatchTime1"] != null) && (Page.Request["DispatchTime2"] != null)))
            {
                base.Response.Clear();
                string str = base.Request.QueryString["Type"];
                if (str == "xls")
                {
                    base.Response.Charset = "UTF-8";
                    base.Response.ContentEncoding = Encoding.GetEncoding("gbk");
                    base.Response.ContentType = "Application/ms-excel";
                }
                else
                {
                    base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                }
                base.Response.AppendHeader("Content-Disposition",
                                           "attachment;filename=\"SellOrderReport_" +
                                           DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                BindData();
                base.Response.Flush();
                base.Response.Close();
                base.Response.End();
            }
        }
    }
}
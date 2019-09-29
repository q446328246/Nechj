using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OrderProduct_Report : PageBase, IRequiresSessionState
    {
        private void BindData()
        {
            var action = (ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action();
            string startdate = (Page.Request.QueryString["DispatchTime1"] == "")
                                   ? "-1"
                                   : Page.Request.QueryString["DispatchTime1"];
            string enddate = (Page.Request.QueryString["DispatchTime2"] == "")
                                 ? "-1"
                                 : Page.Request.QueryString["DispatchTime2"];
            string shopname = (Page.Request.QueryString["ShopName"] == "") ? "-1" : Page.Request.QueryString["ShopName"];
            DataTable table = action.SearchOrderProduct(Page.Request.QueryString["oname"],
                                                        Page.Request.QueryString["pname"], shopname, startdate, enddate);
            if ((table != null) && (table.Rows.Count > 0))
            {
                base.Response.Write("<table width=\"100%\">");
                base.Response.Write("<tr bgcolor=\"#6699cc\">");
                base.Response.Write(" <td align=\"center\">订单号</td>");
                base.Response.Write(" <td align=\"center\">店主</td>");
                base.Response.Write("<td align=\"center\">店铺名称</td>");
                base.Response.Write("<td align=\"center\">商品名称</td>");
                base.Response.Write("<td align=\"center\">数量</td>");
                base.Response.Write("<td align=\"center\">交易金额</td>");
                base.Response.Write("<td align=\"center\">日期</td>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    base.Response.Write("<tr>");
                    base.Response.Write(
                        "<td align=\"center\" style=\"background-color:#FFF\" style=\"vnd.ms-excel.numberformat:@\" width=\"100\"> {OrderNumber}</td>"
                            .Replace("{OrderNumber}", table.Rows[i]["OrderNumber"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {MemLoginID}</td>".Replace("{MemLoginID}",
                                                                                                        table.Rows[i][
                                                                                                            "MemLoginID"
                                                                                                            ].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {ShopName}</td>".Replace("{ShopName}",
                                                                                                      table.Rows[i][
                                                                                                          "ShopName"]
                                                                                                          .ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {ProductName}</td>".Replace(
                        "{ProductName}", table.Rows[i]["ProductName"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {BuyNumber}</td>".Replace("{BuyNumber}",
                                                                                                       table.Rows[i][
                                                                                                           "BuyNumber"]
                                                                                                           .ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {Amount}</td>".Replace("{Amount}",
                                                                                                    table.Rows[i][
                                                                                                        "Amount"]
                                                                                                        .ToString()));
                    base.Response.Write(
                        "<td align=\"center\" style=\"vnd.ms-excel.numberformat:yyyy/mm/dd;background-color:#FFF\" width=\"100\"> {CreateTime}</td>"
                            .Replace("{CreateTime}", table.Rows[i]["CreateTime"].ToString()));
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
                    base.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
                    base.Response.ContentType = "Application/ms-excel";
                }
                else
                {
                    base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                }
                base.Response.AppendHeader("Content-Disposition",
                                           "attachment;filename=\"OrderProductReport_" +
                                           DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                BindData();
                base.Response.Flush();
                base.Response.Close();
                base.Response.End();
            }
        }
    }
}
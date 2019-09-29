using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopAmount_Report : PageBase, IRequiresSessionState
    {
        private void BindData()
        {
            string startdate = (Page.Request.QueryString["DispatchTime1"] == "")
                                   ? "-1"
                                   : Page.Request.QueryString["DispatchTime1"];
            string enddate = (Page.Request.QueryString["DispatchTime2"] == "")
                                 ? "-1"
                                 : Page.Request.QueryString["DispatchTime2"];
            DataTable table =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).SearchShopAmount(
                    startdate, enddate);
            if ((table != null) && (table.Rows.Count > 0))
            {
                base.Response.Write("<table width=\"100%\">");
                base.Response.Write("<tr bgcolor=\"#6699cc\">");
                base.Response.Write(" <td align=\"center\">店主</td>");
                base.Response.Write("<td align=\"center\">店铺名称</td>");
                base.Response.Write("<td align=\"center\">订单数</td>");
                base.Response.Write("<td align=\"center\">总金额</td>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    base.Response.Write("<tr>");
                    base.Response.Write("<td align=\"center\" width=\"100\"> {MemLoginID}</td>".Replace("{MemLoginID}",
                                                                                                        table.Rows[i][
                                                                                                            "MemLoginID"
                                                                                                            ].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {ShopName}</td>".Replace("{ShopName}",
                                                                                                      table.Rows[i][
                                                                                                          "ShopName"]
                                                                                                          .ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {OrderNum}</td>".Replace("{OrderNum}",
                                                                                                      table.Rows[i][
                                                                                                          "OrderNum"]
                                                                                                          .ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {Amount}</td>".Replace("{Amount}",
                                                                                                    table.Rows[i][
                                                                                                        "Amount"]
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
                                           "attachment;filename=\"ShopAmountReport_" +
                                           DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                BindData();
                base.Response.Flush();
                base.Response.Close();
                base.Response.End();
            }
        }
    }
}
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class userOrder_Report : PageBase, IRequiresSessionState
    {
        private void BindData()
        {
            var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            string startdate = (Page.Request.QueryString["DispatchTime1"] == "")
                                   ? ""
                                   : Page.Request.QueryString["DispatchTime1"];
            string enddate = (Page.Request.QueryString["DispatchTime2"] == "")
                                 ? ""
                                 : Page.Request.QueryString["DispatchTime2"];
            DataTable table = action.SearchOrderInfos(Page.Request.QueryString["personname"],
                                                          startdate, enddate);
            if ((table != null) && (table.Rows.Count > 0))
            {
                base.Response.Write("<table width=\"100%\">");
                base.Response.Write("<tr bgcolor=\"#6699cc\">");
                base.Response.Write(" <td align=\"center\" width=\"300\">订单号</td>");
                base.Response.Write("<td align=\"center\">收货人</td>");
                base.Response.Write("<td align=\"center\">Email</td>");
                base.Response.Write("<td align=\"center\">收获地址</td>");
                base.Response.Write("<td align=\"center\">电话号码</td>");
                base.Response.Write("<td align=\"center\">确认时间</td>");
                base.Response.Write("</tr>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    base.Response.Write("<tr>");
                    base.Response.Write("<td align=\"center\" width=\"300\"> dd-{OrderNumber}</td>".Replace("{OrderNumber}", table.Rows[i]["OrderNumber"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {Name}</td>".Replace("{Name}", table.Rows[i]["Name"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"150\"> {Email}</td>".Replace("{Email}", table.Rows[i]["Email"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {Address}</td>".Replace("{Address}", table.Rows[i]["Address"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {Mobile}</td>".Replace("{Mobile}", table.Rows[i]["Mobile"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {ConfirmTime}</td>".Replace("{ConfirmTime}", table.Rows[i]["ConfirmTime"].ToString()));
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
                    base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
                    base.Response.ContentType = "Application/ms-excel";
                }
                else
                {
                    base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                }
                base.Response.AppendHeader("Content-Disposition", "attachment;filename=\"userOrderReport_" + DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                BindData();
                base.Response.Flush();
                base.Response.Close();
                base.Response.End();
            }

        }
    }
}
using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class PaymentStatistics_Report : PageBase, IRequiresSessionState
    {
        private void BindData()
        {
            DataTable table = ((ShopNum1_ExtendOrderStatistics_Action)LogicFactory.CreateShopNum1_ExtendOrderStatistics_Action()).SearchPaymentStatistics();
            base.Response.Write("<table width=\"100%\">");
            base.Response.Write("<tr bgcolor=\"#6699cc\">");
            base.Response.Write("<td align=\"center\">排行</td>");
            base.Response.Write("<td align=\"center\">支付方式名称</td>");
            base.Response.Write("<td align=\"center\">使用次数</td>");
            base.Response.Write("<td align=\"center\">使用百分比</td>");
            base.Response.Write("</tr>");
            if ((table != null) && (table.Rows.Count > 0))
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    base.Response.Write("<tr>");
                    int num2 = i + 1;
                    base.Response.Write("<td align=\"center\" width=\"50\"> {Top}</td>".Replace("{Top}", num2.ToString()));
                    base.Response.Write("<td align=\"center\" width=\"200\"> {PaymentName}</td>".Replace("{PaymentName}", table.Rows[i]["PaymentName"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {PaymentCount}</td>".Replace("{PaymentCount}", table.Rows[i]["PaymentCount"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {Percentage}</td>".Replace("{Percentage}", decimal.Round((decimal.Parse(table.Rows[i]["PaymentCount"].ToString()) * 100M) / decimal.Parse(table.Rows[i]["AllCount"].ToString()), 2).ToString() + "%"));
                    base.Response.Write("</tr>");
                }
            }
            base.Response.Write("</table>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                base.Response.Clear();
                string str = base.Request.QueryString["Type"].ToString();
                if (str == "xls")
                {
                    base.Response.ContentEncoding = Encoding.Default;
                    base.Response.ContentType = "Application/ms-excel";
                }
                else
                {
                    base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                }
                base.Response.AppendHeader("Content-Disposition", "attachment;filename=\"PaymentStatistics_Report_" + DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                this.BindData();
                base.Response.Flush();
                base.Response.Close();
                base.Response.End();
            }
            else
            {
                base.Response.Write("");
            }
        }

    }
}
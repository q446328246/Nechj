using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentStatistics_Report : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();

            if (base.Request.Cookies["AdminLoginCookie"] == null)
            {
                base.Response.Write("<script type=\"text/javascript\">window.top.location.href='Login.aspx';</script>");
            }
            else if (!Page.IsPostBack)
            {
                base.Response.Clear();
                if (base.Request.QueryString["Type"] != null)
                {
                    string str = base.Request.QueryString["Type"];
                    if (str == "xls")
                    {
                        base.Response.ContentType = "Application/ms-excel";
                        base.Response.ContentEncoding = Encoding.UTF8;
                    }
                    else
                    {
                        base.Response.ContentType = "text/HTML";
                        base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                    }
                    
                    base.Response.AppendHeader("Content-Disposition",
                                               "attachment;filename=\"会员资金记录_" + DateTime.Now.ToString("yyyymmddhhmm") +
                                               "." + str + "\"");
                    BindData();
                    base.Response.Flush();
                    base.Response.Close();
                    base.Response.End();
                }
            }
        }

        private void BindData()
        {
            
            try
            {
                var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                HttpCookie cookie1 = base.Request.Cookies["MoneyReportCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie1);
                int operateType = Convert.ToInt32(cookie2.Values["operateType"]);
                DataTable table = action.SearchAdvancePayment("", operateType);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                    base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">会员ID</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >姓名</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >当前资金</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >冻结金币（BV）</td>");
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        base.Response.Write("<tr>");
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", table.Rows[i]["MemLoginID"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Name}</td>".Replace("{Name}",table.Rows[i]["Name"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center;color:red\"> ￥{Frist_Money}</td>".Replace("{Frist_Money}", table.Rows[i]["Frist_Money"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center;color:red\"> ￥{LockAdvancePayment}</td>".Replace("{LockAdvancePayment}", table.Rows[i]["LockAdvancePayment"].ToString()));
                        base.Response.Write("</tr>");
                    }
                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                    string str = "";
                    string str2 = "";
                    DataTable allAdvancePayment = action.GetAllAdvancePayment(-1,operateType);
                    if ((allAdvancePayment != null) && (allAdvancePayment.Rows.Count > 0))
                    {
                        if (!string.IsNullOrEmpty(allAdvancePayment.Rows[0][0].ToString()))
                        {
                            str = allAdvancePayment.Rows[0][0].ToString();
                        }
                        else
                        {
                            str = "0";
                        }
                    }
                    else
                    {
                        str = "0";
                    }
                    string str3 = Common.Common.GetNameById("SUM(LockAdvancePayment)", "ShopNum1_Member", " AND 1=1");
                    if (!string.IsNullOrEmpty(str3))
                    {
                        str2 = str3;
                    }
                    else
                    {
                        str2 = "0";
                    }
                    if (operateType == 1)
                    {
                        base.Response.Write("<td colspan=\"4\" style=\"color:red\">当前会员（BV）累计金额【￥" + str + "】, 会员冻结金币（BV）累计金额【￥" + str2 + "】 </td>");
                    }
                    if (operateType == 2)
                    {
                        base.Response.Write("<td colspan=\"4\" style=\"color:red\">当前会员（DV）累计金额【￥" + str + "】, 会员冻结金币（BV）累计金额【￥" + str2 + "】 </td>");
                    }
                    if (operateType == 3)
                    {
                        base.Response.Write("<td colspan=\"4\" style=\"color:red\">当前会员（RV）累计金额【￥" + str + "】, 会员冻结金币（BV）累计金额【￥" + str2 + "】 </td>");
                    }
                        base.Response.Write("</tr>");
                    base.Response.Write("</table>");
                }
                HttpCookie cookie = base.Request.Cookies["OrderListReportCookie"];
                cookie.Expires = DateTime.Now.AddDays(-99.0);
                base.Response.Cookies.Add(cookie);
            }
            catch (Exception)
            {
            }
        }
    }
}
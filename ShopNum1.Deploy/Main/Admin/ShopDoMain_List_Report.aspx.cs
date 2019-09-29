using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopDoMain_List_Report : PageBase, IRequiresSessionState
    {
        private void BindData()
        {
            HttpCookie cookie = base.Request.Cookies["ShopDoMainReportCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            string str = cookie2.Values["PageCheck"];
            string str2 = cookie2.Values["Guids"];
            string memLoginID = cookie2.Values["MemLoginID"];
            string isAudit = cookie2.Values["IsAudit"];
            var action = new ShopNum1_ShopURLManage_Action();
            DataTable table = null;
            if (str == "1")
            {
                table = action.SearchByID(str2);
            }
            else
            {
                table = action.Search(memLoginID, isAudit);
            }
            if ((table != null) && (table.Rows.Count > 0))
            {
                base.Response.Write(
                    "<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">”Ú√˚</td>");
                base.Response.Write("<td align=\"center\"  style=\"background-color:#6699cc\">µÍ∆ÃURL</td>");
                base.Response.Write("<td  align=\"center\" style=\"background-color:#6699cc\">±∏∞∏∫≈</td>");
                base.Response.Write("<td align=\"center\" style=\"background-color:#6699cc\">µÍ∆Ã√˚</td>");
                base.Response.Write("<td  align=\"center\" style=\"background-color:#6699cc\">…Í«Î ±º‰</td>");
                base.Response.Write("<td align=\"center\" style=\"background-color:#6699cc\">…Û∫À◊¥Ã¨</td>");
                base.Response.Write("</tr>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    base.Response.Write("<tr>");
                    base.Response.Write(
                        "<td align=\"center\" style=\"background-color:#FFF\"> {DoMain}</td>".Replace("{DoMain}",
                                                                                                      table.Rows[i][
                                                                                                          "DoMain"]
                                                                                                          .ToString()));
                    base.Response.Write(
                        "<td align=\"center\" style=\"background-color:#FFF\"> {GoUrl}</td>".Replace("{GoUrl}",
                                                                                                     table.Rows[i][
                                                                                                         "GoUrl"]
                                                                                                         .ToString()));
                    base.Response.Write(
                        "<td  align=\"center\" style=\"background-color:#FFF\"> {SiteNumber}</td>".Replace(
                            "{SiteNumber}", table.Rows[i]["SiteNumber"].ToString()));
                    base.Response.Write(
                        "<td align=\"center\" style=\"background-color:#FFF\"> {MemLoginID}</td>".Replace(
                            "{MemLoginID}", table.Rows[i]["MemLoginID"].ToString()));
                    base.Response.Write(
                        "<td align=\"center\" style=\"background-color:#FFF\"> {AddTime}</td>".Replace("{AddTime}",
                                                                                                       table.Rows[i][
                                                                                                           "AddTime"]
                                                                                                           .ToString()));
                    string newValue = string.Empty;
                    string str6 = table.Rows[i]["IsAudit"].ToString();
                    if (str6 != null)
                    {
                        if (!(str6 == "0"))
                        {
                            if (str6 == "1")
                            {
                                newValue = " “—…Û∫À";//LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "1");
                            }
                        }
                        else
                        {
                            newValue = " Œ¥…Û∫À"; //LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "0");
                        }
                    }
                    base.Response.Write(
                        "<td align=\"center\" style=\"background-color:#FFF\"> {IsAudit}</td>".Replace("{IsAudit}",
                                                                                                       newValue));
                    base.Response.Write("</tr>");
                }
                base.Response.Write("</table>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                base.Response.Clear();
                if (base.Request.QueryString["Type"] != null)
                {
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
                        base.Response.ContentType = "text/HTML";
                    }
                    base.Response.AppendHeader("Content-Disposition",
                                               "attachment;filename=\"ShopDomainReport_" +
                                               DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                    BindData();
                    base.Response.Flush();
                    base.Response.Close();
                    base.Response.End();
                }
            }
        }
    }
}
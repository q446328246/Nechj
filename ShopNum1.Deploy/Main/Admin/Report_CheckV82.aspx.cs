using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Report_CheckV82 : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
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
                                               "attachment;filename=\"MoneyReport_" +
                                               DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                    BindData();
                    Thread.Sleep(100);
                    base.Response.Flush();
                    base.Response.Close();
                    base.Response.End();
                }
            }
        }

        public string ChangeOperateStatus(string operateStatus)
        {
            if (operateStatus == "0")
            {
                return "δȷ��";
            }
            if (operateStatus == "1")
            {
                return "�����";
            }
            return "�Ѿܾ�";
        }

        public string ChangeOperateType(string operateType)
        {
            if (operateType == "0")
            {
                return "��̨����";
            }
            if (operateType == "1")
            {
                return "��̨��ֵ";
            }
            if (operateType == "2")
            {
                return "��Ա��������";
            }
            if (operateType == "3")
            {
                return "��Ա������ֵ";
            }
            return "";
        }

        private void BindData()
        {
            string str4;
            int num;
            DataTable table;
            string str5;
            string str6;
            string str7;
            string str8;
            string TextBoxModifyTime1;
            string TextBoxModifyTime2;

            HttpCookie cookie = base.Request.Cookies["MoneyReportCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            string orderNumber = cookie2.Values["OrderNumber"];
            string memLoginID = cookie2.Values["MemLoginID"];
            string memberLoginNo = cookie2.Values["MemberLoginNo"];
            string realName = cookie2.Values["RealName"];
            int operateType = Convert.ToInt32(cookie2.Values["operateType"]);
            
            switch (cookie2.Values["reportType"])
            {
                case "1":
                    str4 = cookie2.Values["State"];
                    str4 = (str4 == "") ? "-1" : str4;
                    str5 = cookie2.Values["Sdate"];
                    str6 = cookie2.Values["Edate"];
                    TextBoxModifyTime1 = cookie2.Values["ModifySdate"];
                    TextBoxModifyTime2 = cookie2.Values["ModifyEdate"];
                    table =
                        ((ShopNum1_AdvancePaymentApplyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).SearchCzDc(memLoginID, str5, str6, 1,
                                                                                             Convert.ToInt32(str4), 0,TextBoxModifyTime1,TextBoxModifyTime2);
                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">��ֵ����</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��Ա��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ǰ��ң�BV��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >���</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ֵ��ʽ</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >״̬</td>");
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>"
                                    .Replace("{OrderNumber}", table.Rows[num]["OrderNumber"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {MemLoginID}</td>".Replace(
                                    "{MemLoginID}", table.Rows[num]["MemLoginID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Date}</td>".Replace("{Date}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Date"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));

                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {ModifyTime}</td>".Replace("{ModifyTime}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "ModifyTime"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));

                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {CurrentAdvancePayment}</td>"
                                    .Replace("{CurrentAdvancePayment}",
                                             table.Rows[num]["CurrentAdvancePayment"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {OperateMoney}</td>".Replace(
                                    "{OperateMoney}", table.Rows[num]["OperateMoney"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {PaymentName}</td>".Replace(
                                    "{PaymentName}", table.Rows[num]["PaymentName"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {OperateStatus}</td>".Replace(
                                    "{OperateStatus}", ChangeOperateStatus(table.Rows[num]["OperateStatus"].ToString())));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;

                case "2":
                    str4 = cookie2.Values["State"];
                    str4 = (str4 == "") ? "-1" : str4;
                    str5 = cookie2.Values["Sdate"];
                    str6 = cookie2.Values["Edate"];
                    table =
                        ((ShopNum1_AdvancePaymentApplyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).Search(memLoginID, str5, str6, 0,
                                                                                             Convert.ToInt32(str4), 0);
                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">���ֵ���</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��Ա��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��Ա����</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��Ա�ȼ�</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ǰ��ң�BV��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >���</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >ʵ�ʵ��˽��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center \" >�����˺�</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >״̬</td>");
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>"
                                    .Replace("{OrderNumber}", table.Rows[num]["OrderNumber"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {MemLoginID}</td>".Replace(
                                    "{MemLoginID}", table.Rows[num]["MemLoginID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {RealName}</td>".Replace(
                                    "{RealName}", table.Rows[num]["RealName"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {huiyuandengji}</td>".Replace(
                                    "{huiyuandengji}", table.Rows[num]["huiyuandengji"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Date}</td>".Replace("{Date}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Date"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {CurrentAdvancePayment}</td>"
                                    .Replace("{CurrentAdvancePayment}",
                                             table.Rows[num]["CurrentAdvancePayment"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {OperateMoney}</td>".Replace(
                                    "{OperateMoney}", table.Rows[num]["OperateMoney"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {ActualMoney}</td>".Replace(
                                    "{ActualMoney}", table.Rows[num]["ActualMoney"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Bank}</td>".Replace(
                                    "{Bank}", table.Rows[num]["Bank"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Account}</td>".Replace(
                                    "{Account}", "'"+table.Rows[num]["Account"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {TrueName}</td>".Replace(
                                    "{TrueName}", table.Rows[num]["TrueName"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {OperateStatus}</td>".Replace(
                                    "{OperateStatus}", ChangeOperateStatus(table.Rows[num]["OperateStatus"].ToString())));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;

                case "3":
                    str4 = cookie2.Values["State"];
                    str4 = (str4 == "") ? "-1" : str4;
                    str5 = cookie2.Values["Sdate"];
                    str6 = cookie2.Values["Edate"];
                    str7 = cookie2.Values["Edate"];
                    table =
                        ((ShopNum1_PreTransfer_Action) LogicFactory.CreateShopNum1_PreTransfer_Action()).Search(
                            orderNumber, memLoginID, str7, str5, str6, 0, operateType);
                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">ת�˵���</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >ת�˻�ԱID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >ת�˽��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�տ���ID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ע</td>");
                        
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>"
                                    .Replace("{OrderNumber}", table.Rows[num]["OrderNumber"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {MemLoginID}</td>".Replace(
                                    "{MemLoginID}", table.Rows[num]["MemLoginID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {OperateMoney}</td>".Replace(
                                    "{OperateMoney}", table.Rows[num]["OperateMoney"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {RMemberID}</td>".Replace(
                                    "{RMemberID}", table.Rows[num]["RMemberID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Date}</td>".Replace("{Date}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Date"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));
                            string type1 = "";
                            if (table.Rows[num]["type"].ToString() == "1")
                            { type1 = "K���һ�"; }
                            if (table.Rows[num]["type"].ToString() == "2")
                            { type1 = "K��ת��"; }
                            if (table.Rows[num]["type"].ToString() == "3")
                            { type1 = "KTת��"; }
                            if (table.Rows[num]["type"].ToString() == "4")
                            { type1 = "ɨ��֧��"; }
                            if (table.Rows[num]["type"].ToString() == "5")
                            { type1 = "������תKT"; }
                            if (table.Rows[num]["type"].ToString() == "6")
                            { type1 = "KTת������"; }
                            if (table.Rows[num]["type"].ToString() == "7")
                            { type1 = "�̻�ת��"; }
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {type}</td>".Replace("{type}",type1));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Memo}</td>".Replace("{Memo}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Memo"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;

                case "4":
                    str8 = cookie2.Values["OperType"];
                    str5 = cookie2.Values["Sdate"];
                    str6 = cookie2.Values["Edate"];
                    str7 = cookie2.Values["Edate"];
                    table =
                        ((ShopNum1_AdvancePaymentModifyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).Search(memLoginID, str5, str6,
                                                                                              Convert.ToInt32(str8), 0);
                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">��ԱID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ǰ��ң�BV��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ע</td>");
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>"
                                    .Replace("{MemLoginID}", table.Rows[num]["MemLoginID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Date}</td>".Replace("{Date}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Date"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {OperateType}</td>".Replace(
                                    "{OperateType}", ChangeOperateType(table.Rows[num]["OperateType"].ToString())));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {money_first}</td>"
                                    .Replace("{money_first}",
                                             table.Rows[num]["money_first"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {money_two}</td>".Replace(
                                    "{money_two}", table.Rows[num]["money_two"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {money_free}</td>".Replace
                                    ("{money_free}", table.Rows[num]["money_free"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Memo}</td>".Replace("{Memo}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Memo"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;

                case "5":
                    str8 = cookie2.Values["OperType"];
                    str5 = cookie2.Values["Sdate"];
                    str6 = cookie2.Values["Edate"];
                    str7 = cookie2.Values["Edate"];
                    table =
                        ((ShopNum1_AdvancePaymentModifyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).Search(memLoginID, str5, str6,
                                                                                              Convert.ToInt32(str8), 0);
                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">��ԱID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�������</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ǰ�����ң�BV��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����|�ⶳ���</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����|�ⶳ����</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ע</td>");
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>"
                                    .Replace("{MemLoginID}", table.Rows[num]["MemLoginID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Date}</td>".Replace("{Date}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Date"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {OperateType}</td>".Replace(
                                    "{OperateType}", ChangeOperateType(table.Rows[num]["OperateType"].ToString())));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {money_first}</td>"
                                    .Replace("{money_first}",
                                             table.Rows[num]["money_first"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {money_two}</td>".Replace(
                                    "{money_two}", table.Rows[num]["money_two"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {money_free}</td>".Replace
                                    ("{money_free}", table.Rows[num]["money_free"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Memo}</td>".Replace("{Memo}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Memo"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;

                case "6":
                    int isDeleted = Convert.ToInt32(cookie2.Values["State"]);
                    str8 = cookie2.Values["OperType"];
                    str5 = cookie2.Values["Sdate"];
                    str6 = cookie2.Values["Edate"];
                    str7 = cookie2.Values["Edate"];
                    table =
                        ((ShopNum1_AdvancePaymentApplyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).SearchDc(memLoginID, realName, str5, str6, isDeleted);
                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">��ԱID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��Ա���</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��Ա����</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����ʱ��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�Ƽ�����</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�ƹ����</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��̬�ͷ�</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�����ܽ��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ɱ���</td>");
                        
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����״̬</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��Ա�ȼ�</td>");
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {BonusID}</td>"
                                    .Replace("{BonusID}", table.Rows[num]["BonusID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Mem}</td>".Replace("{Mem}",
                                                                                                             table.Rows[
                                                                                                                 num][
                                                                                                                     "Mem"
                                                                                                                 ]
                                                                                                                 .ToString
                                                                                                                 ()));

                            base.Response.Write(
                                 "<td style=\"background-color:#FFF;text-align:center\"> {RealName}</td>"
                                     .Replace("{RealName}",
                                              table.Rows[num]["RealName"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Cre}</td>"
                                    .Replace("{Cre}",
                                             table.Rows[num]["Cre"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Bonus1}</td>"
                                    .Replace("{Bonus1}",
                                             table.Rows[num]["Bonus1"].ToString()));
                            base.Response.Write(
                               "<td style=\"background-color:#FFF;text-align:center\"> {Bonus2}</td>"
                                   .Replace("{Bonus2}",
                                            table.Rows[num]["Bonus2"].ToString()));
                            base.Response.Write(
                               "<td style=\"background-color:#FFF;text-align:center\"> {Bonus3}</td>"
                                   .Replace("{Bonus3}",
                                            table.Rows[num]["Bonus3"].ToString()));
                            base.Response.Write(
                               "<td style=\"background-color:#FFF;text-align:center\"> {BonusAll}</td>"
                                   .Replace("{BonusAll}",
                                            table.Rows[num]["BonusAll"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Proportion}</td>"
                                    .Replace("{Proportion}",
                                             table.Rows[num]["Proportion"].ToString()));

                            string state = null;
                            if (Convert.ToInt32(table.Rows[num]["isd"].ToString()) == 1)
                            {
                                state = "�ѷ���";
                            }
                            else
                            {
                                state = "δ����";
                            }
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {isd}</td>".Replace
                                    ("{isd}", state));
                            string str = "";
                            if (Convert.ToInt32(table.Rows[num]["meml"].ToString()) == 0)
                            {
                                str = "�����Ա";
                            }
                            if (Convert.ToInt32(table.Rows[num]["meml"].ToString()) == 1)
                            {
                                str = "һ�ǻ�Ա";
                            }
                            if (Convert.ToInt32(table.Rows[num]["meml"].ToString()) == 2)
                            {
                                str = "���ǻ�Ա";
                            }
                            if (Convert.ToInt32(table.Rows[num]["meml"].ToString()) == 3)
                            {
                                str = "���ǻ�Ա";
                            }
                            if (Convert.ToInt32(table.Rows[num]["meml"].ToString()) == 4)
                            {
                                str = "���ǻ�Ա";
                            }
                            if (Convert.ToInt32(table.Rows[num]["meml"].ToString()) == 5)
                            {
                                str = "���ǻ�Ա";
                            }
                            if (Convert.ToInt32(table.Rows[num]["meml"].ToString()) == 6)
                            {
                                str = "��ͨ��Ա";
                            }
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {meml}</td>".Replace("{meml}",str));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;
                case "7":
                    str8 = cookie2.Values["State"];
                    str5 = cookie2.Values["Sdate"];
                    str6 = cookie2.Values["Edate"];

                    table = ((ShopNum1_AdvancePaymentApplyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).ETHSearchTx("", "", str5, str6, 0, Convert.ToInt32(str8), 0);
                       
                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">����ID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ԱID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >���ֵ�ַ</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�������ETH��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >״̬</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����ʱ��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����Hash</td>");
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderID}</td>"
                                    .Replace("{OrderID}", table.Rows[num]["OrderID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemloginID}</td>"
                                    .Replace("{MemloginID}", table.Rows[num]["MemloginID"].ToString()));
                            base.Response.Write(
                                 "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {ETHAddress}</td>"
                                     .Replace("{ETHAddress}", table.Rows[num]["ETHAddress"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {ETH}</td>"
                                    .Replace("{ETH}",
                                             table.Rows[num]["ETH"].ToString()));
                            string str = "";
                            if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 0)
                            {
                                str = "δȷ��";
                            }
                            if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 1)
                            {
                                str = "�����";
                            }
                            if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 2)
                            {
                                str = "�Ѿܾ�";
                            }
                       
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Status}</td>".Replace("{Status}", str));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {TxTime}</td>".Replace
                                    ("{TxTime}", table.Rows[num]["TxTime"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {TxHash}</td>".Replace
                                    ("{TxHash}", table.Rows[num]["TxHash"].ToString()));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;

                case "17":
                    str8 = cookie2.Values["State"];
                    str5 = cookie2.Values["Sdate"];
                    str6 = cookie2.Values["Edate"];

                    table = ((ShopNum1_AdvancePaymentApplyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).NECSearchTx("", "", str5, str6, 0, Convert.ToInt32(str8), 0);

                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">����ID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ԱID</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >���ֵ�ַ</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >�������NEC��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >״̬</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����ʱ��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >����Hash</td>");
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderID}</td>"
                                    .Replace("{OrderID}", table.Rows[num]["OrderID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemloginID}</td>"
                                    .Replace("{MemloginID}", table.Rows[num]["MemloginID"].ToString()));
                            base.Response.Write(
                                 "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {NECAddress}</td>"
                                     .Replace("{NECAddress}", table.Rows[num]["NECAddress"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {NEC}</td>"
                                    .Replace("{NEC}",
                                             table.Rows[num]["NEC"].ToString()));
                            string str = "";
                            if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 0)
                            {
                                str = "δȷ��";
                            }
                            if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 1)
                            {
                                str = "�����";
                            }
                            if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 2)
                            {
                                str = "�Ѿܾ�";
                            }

                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Status}</td>".Replace("{Status}", str));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {TxTime}</td>".Replace
                                    ("{TxTime}", table.Rows[num]["TxTime"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {TxHash}</td>".Replace
                                    ("{TxHash}", table.Rows[num]["TxHash"].ToString()));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;

                case "19":
                 int str854 = Convert.ToInt32( cookie2.Values["Bizhong"]);
                 string str523 = cookie2.Values["MemLoginID"];
                 int str645 = Convert.ToInt32( cookie2.Values["State"]);
                 string str641 = cookie2.Values["Sdate"];
                 string str621 = cookie2.Values["Edate"];

                    table = ((ShopNum1_AdvancePaymentApplyLog_Action)
                         LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action()).ETHSearchCz(str523, str641, str621, str645, str854,0);

                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(
                            "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                        base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                        base.Response.Write(
                            " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">��Ա��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ֵ��ַ</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ֵʱ��</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ֵ���</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��ֵ����</td>");
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >��������</td>");
                        base.Response.Write("</tr>");
                        for (num = 0; num < table.Rows.Count; num++)
                        {
                            base.Response.Write("<tr>");
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>"
                                    .Replace("{MemLoginID}", table.Rows[num]["MemLoginID"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Fromaddr}</td>"
                                    .Replace("{Fromaddr}", table.Rows[num]["Fromaddr"].ToString()));
                            base.Response.Write(
                                 "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Time}</td>"
                                     .Replace("{Time}", table.Rows[num]["Time"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Counts}</td>"
                                    .Replace("{Counts}",
                                             table.Rows[num]["Counts"].ToString()));
                           // string str = "";
                            //if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 0)
                            //{
                            //    str = "δȷ��";
                            //}
                            //if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 1)
                            //{
                            //    str = "�����";
                            //}
                            //if (Convert.ToInt32(table.Rows[num]["Status"].ToString()) == 2)
                            //{
                            //    str = "�Ѿܾ�";
                            //}

                          
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Bizhong}</td>".Replace
                                    ("{Bizhong}", table.Rows[num]["Bizhong"].ToString()));
                            base.Response.Write(
                                "<td style=\"background-color:#FFF;text-align:center\"> {Texthash}</td>".Replace
                                    ("{Texthash}", table.Rows[num]["Texthash"].ToString()));
                            base.Response.Write("</tr>");
                        }
                        base.Response.Write("</table>");
                    }
                    break;
            }
        }

       
    }
}
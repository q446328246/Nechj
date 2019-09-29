using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OrderScore_List : PageBase, IRequiresSessionState
    {
        protected const string Order_Operate = "Order_Operate.aspx";
        protected const string OrderList_Report = "OrderList_Report.aspx";

        public void BindData(string orderString)
        {
            try
            {
                DataTable infoInManage =
                    ((ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action())
                        .GetInfoInManage(method_5(orderString));
                if ((infoInManage != null) && (infoInManage.Rows.Count > 0))
                {
                    Num1GridViewShow.DataSource = infoInManage.DefaultView;
                    Num1GridViewShow.DataBind();
                }
                else
                {
                    Num1GridViewShow.DataSource = null;
                    Num1GridViewShow.DataBind();
                }
            }
            catch (Exception exception)
            {
                Page.Response.Write(exception.Message);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除红包订单",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "OrderScore_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageBox.Show("批量删除成功！");
                BindData("CreateTime");
            }
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出红包订单数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "OrderScore_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            ReportData();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData("CreateTime");
        }

        public string GetState(string state)
        {
            if (state == "1")
            {
                return "已处理";
            }
            return "未处理";
        }

        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OrderScore_List.aspx?style=1&status=-1");
        }

        protected void LinkButtonOderStatusNo_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OrderScore_List.aspx?style=3&status=0");
        }

        protected void LinkButtonOderStatusOk_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OrderScore_List.aspx?style=2&status=1");
        }

        private string method_5(string string_4)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxOrderNumber.Text.Trim()))
            {
                str = str + "   and   OrderNumber='" + Operator.FilterString(TextBoxOrderNumber.Text.Trim()) + "'  ";
            }
            if (!string.IsNullOrEmpty(TextBoxMemLoginID.Text.Trim()))
            {
                str = str + "   and   Name like '%" + Operator.FilterString(TextBoxMemLoginID.Text.Trim()) + "%'  ";
            }
            if (!string.IsNullOrEmpty(TextBoxPhone.Text.Trim()))
            {
                str = str + "   and   Mobile = '" + Operator.FilterString(TextBoxPhone.Text.Trim()) + "'  ";
            }
            if (!string.IsNullOrEmpty(TextBoxShopID.Text.Trim()))
            {
                str = str + "   and   ShopMemLoginID = '" + Operator.FilterString(TextBoxShopID.Text.Trim()) + "'  ";
            }
            if (!string.IsNullOrEmpty(TextBoxCreateTime1.Text.Trim()))
            {
                str = str + "   and   CreateTime > '" + Operator.FilterString(TextBoxCreateTime1.Text.Trim()) + "'  ";
            }
            if (!string.IsNullOrEmpty(TextBoxCreateTime2.Text.Trim()))
            {
                str = str + "   and   CreateTime < '" + Operator.FilterString(TextBoxCreateTime2.Text.Trim()) + "'  ";
            }
            if (!string.IsNullOrEmpty(TextBoxShouldPayPrice1.Text.Trim()))
            {
                str = str + "   and   TotalScore > " + TextBoxShouldPayPrice1.Text.Trim() + "  ";
            }
            if (!string.IsNullOrEmpty(TextBoxShouldPayPrice2.Text.Trim()))
            {
                str = str + "   and   TotalScore < " + TextBoxShouldPayPrice2.Text.Trim() + "  ";
            }
            if ((base.Request.QueryString["status"] != null) && (base.Request.QueryString["status"] != "-1"))
            {
                str = str + "   and   OderStatus =" + base.Request.QueryString["status"] + "  ";
            }
            return (str + "   order  by   " + string_4 + "   desc    ");
        }

        private void method_6()
        {
            try
            {
                DataTable infoInManage =
                    ((ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action())
                        .GetInfoInManage(method_5("CreateTime"));
                if ((infoInManage != null) && (infoInManage.Rows.Count > 0))
                {
                    base.Response.Write(
                        "<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                    base.Response.Write(
                        " <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">订单号</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺ID</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >订单总红包</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >买家会员名</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >收货人</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >手机号码</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >电子邮件</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >邮政编码</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >下单时间</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >状态</td>");
                    for (int i = 0; i < infoInManage.Rows.Count; i++)
                    {
                        base.Response.Write("<tr>");
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>"
                                .Replace("{OrderNumber}", infoInManage.Rows[i]["OrderNumber"].ToString()));
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {ShopMemLoginID}</td>".Replace(
                                "{ShopMemLoginID}", infoInManage.Rows[i]["ShopMemLoginID"].ToString()));
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {TotalScore}</td>".Replace(
                                "{TotalScore}", infoInManage.Rows[i]["TotalScore"].ToString()));
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {MemLoginID}</td>".Replace(
                                "{MemLoginID}", infoInManage.Rows[i]["MemLoginID"].ToString()));
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {Name}</td>".Replace("{Name}",
                                                                                                         infoInManage
                                                                                                             .Rows[i][
                                                                                                                 "Name"]
                                                                                                             .ToString()));
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {Mobile}</td>".Replace("{Mobile}",
                                                                                                           infoInManage
                                                                                                               .Rows[i][
                                                                                                                   "Mobile"
                                                                                                               ]
                                                                                                               .ToString
                                                                                                               ()));
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {Email}</td>".Replace("{Email}",
                                                                                                          infoInManage
                                                                                                              .Rows[i][
                                                                                                                  "Email"
                                                                                                              ].ToString
                                                                                                              ()));
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {Postalcode}</td>".Replace(
                                "{Postalcode}", infoInManage.Rows[i]["Postalcode"].ToString()));
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {CreateTime}</td>".Replace(
                                "{CreateTime}", infoInManage.Rows[i]["CreateTime"].ToString()));
                        string newValue = string.Empty;
                        if (infoInManage.Rows[i]["OderStatus"].ToString() == "1")
                        {
                            newValue = "已处理";
                        }
                        else
                        {
                            newValue = "未处理";
                        }
                        base.Response.Write(
                            "<td style=\"background-color:#FFF;text-align:center\"> {OderStatus}</td>".Replace(
                                "{OderStatus}", newValue));
                        base.Response.Write("</tr>");
                    }
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

        protected void Num1GridViewShow_Changing(object sender, GridViewPageEventArgs e)
        {
            Num1GridViewShow.PageIndex = e.NewPageIndex;
            Num1GridViewShow.DataBind();
        }

        protected void Num1GridViewShow_Sorting(object sender, GridViewSortEventArgs e)
        {
            string str = e.SortExpression;
            BindData(method_5(str));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if ((base.Request.QueryString["style"] != null) && (base.Request.QueryString["status"] != null))
            {
                string str2 = base.Request.QueryString["style"];
               // base.Request.QueryString["status"];
                string str = str2;
                if (str != null)
                {
                    if (str != "1")
                    {
                        if (!(str == "2"))
                        {
                            if (str == "3")
                            {
                                LinkButtonAll.CssClass = "";
                                LinkButtonOderStatusOk.CssClass = "";
                                LinkButtonOderStatusNo.CssClass = "cur";
                            }
                        }
                        else
                        {
                            LinkButtonAll.CssClass = "";
                            LinkButtonOderStatusOk.CssClass = "cur";
                            LinkButtonOderStatusNo.CssClass = "";
                        }
                    }
                    else
                    {
                        LinkButtonAll.CssClass = "cur";
                        LinkButtonOderStatusOk.CssClass = "";
                        LinkButtonOderStatusNo.CssClass = "";
                    }
                }
            }
            BindData("CreateTime");
        }

        public void ReportData()
        {
            base.Response.Clear();
            string str = "xls";
            if (str == "xls")
            {
                base.Response.ContentType = "Application/ms-excel";
                base.Response.ContentEncoding = Encoding.UTF8;
            }
            base.Response.AppendHeader("Content-Disposition",
                                       "attachment;filename=\"ScoreOrderInfo_" + DateTime.Now.ToString("yyyymmddhhmm") +
                                       "." + str + "\"");
            method_6();
            base.Response.Flush();
            base.Response.Close();
            base.Response.End();
        }
    }
}
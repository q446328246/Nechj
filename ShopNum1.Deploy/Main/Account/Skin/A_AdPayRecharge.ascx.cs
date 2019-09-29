using System;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1.Payment;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_AdPayRecharge : BaseMemberControl
    {
        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string RechargeType { get; set; }

        public string strEndTime { get; set; }

        public string strOrderNum { get; set; }

        public string strStartTime { get; set; }


        ShopNum1_Member_Action memberaction = new ShopNum1_Member_Action();
        protected void BindPayment()
        {
            sel_PayMent.Items.Clear();
            sel_PayMentType.Items.Clear();
            DataTable table = ((ShopNum1_Payment_Action) LogicFactory.CreateShopNum1_Payment_Action()).SearchByShop(1);
            var item = new ListItem
            {
                Text = "-请选择支付方式-",
                Value = "-1"
            };
            sel_PayMent.Items.Add(item);
            sel_PayMentType.Items.Add(item);
            //ListItem item3 = new ListItem();
            //item3.Text = "微信扫码";
            //item3.Value = "BF843A85-A889-4E58-89E8-0002392B7B5A";
            //sel_PayMent.Items.Add(item3);
            //sel_PayMentType.Items.Add(item3);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    var item2 = new ListItem();
                    if (row["Name"].ToString().Trim() != "金币（BV）支付")
                    {
                        item2.Text = row["Name"].ToString().Trim();
                        item2.Value = row["Guid"].ToString().Trim();
                        sel_PayMent.Items.Add(item2);
                        sel_PayMentType.Items.Add(item2);
                    }
                }
            }
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Confirm_Click(object sender, EventArgs e)
        {
            if (hid_PayMentValue.Value == "-1")
            {
                MessageBox.Show("请选择支付方式！");
            }
            
            else if (Convert.ToDecimal(txt_Recharge.Value.Trim()) > 0)
            {

                #region
                var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                {
                    Guid = System.Guid.NewGuid(),
                    OperateType = "1",//充值
                    CurrentAdvancePayment = Convert.ToDecimal(Lab_AdPayment.Text),
                    OperateMoney = Convert.ToDecimal(txt_Recharge.Value),
                    OperateStatus = 0,
                    Date = DateTime.Now
                    
                   
                    
                };
                
                if (hid_PayMentValue.Value == "1e7cc2d2-130e-4e62-9be9-aa07f727ed4c")
	           {
                   advancePaymentApplyLog.UserName = txtUserName.Value;
                    advancePaymentApplyLog.BankCard = txtBankCard.Value;
                   advancePaymentApplyLog.GetBamkCard = RadioButtonList_Bank.SelectedItem.Text.ToString();
                   DataTable table = memberaction.SearchMembertwo(base.MemLoginID);
                    //20号开启
                   if (table.Rows[0]["MemberRankGuid"].ToString().ToUpper().Trim() != "49844669-3893-413E-951E-77B2EBE4FE28")
                   {
                       Response.Write("<script>top.location='/main/member/m_index.aspx?action=5';</script>");
                       return;
                   }
               }
                else
	          {
                  advancePaymentApplyLog.UserName = "其它支付方式支付无充值人姓名";
                advancePaymentApplyLog.GetBamkCard ="其它支付方式支付";
                advancePaymentApplyLog.BankCard = "其它支付方式支付无充值卡号";
	           }
                
                string str2 = "C" + new Order().CreateOrderNumber();
                advancePaymentApplyLog.OrderNumber = str2;
                advancePaymentApplyLog.MemLoginID = base.MemLoginID;
                advancePaymentApplyLog.PaymentGuid = new Guid(hid_PayMentValue.Value);
                advancePaymentApplyLog.PaymentName = hid_PayMent.Value;
                advancePaymentApplyLog.Memo = txt_Remark.Value.Trim();
                advancePaymentApplyLog.UserMemo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                advancePaymentApplyLog.IsDeleted = 0;
                advancePaymentApplyLog.OrderStatus = 0;
                string str3 = GetID().ToString();
                advancePaymentApplyLog.ID = Convert.ToInt32(str3);
                
                var action =
                    (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                if (action.ApplyOperateMoney(advancePaymentApplyLog) > 0)
                {
                    string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
                    string url = new PayUrlOperate().GetPayUrl(hid_PayMentValue.Value, txt_Recharge.Value.Trim(),ShopSettings.siteDomain + "/main/account/A_Index.aspx","充值", advancePaymentApplyLog.OrderNumber, "Recharge", "0","admin", base.MemLoginID, timetemp);
                    if (url.Length > 0x3e8)
                    {
                        Encoding encoding;
                        if (url.Split(new[] {'|'})[0].IndexOf("UTF") != -1)
                        {
                            encoding = Encoding.UTF8;
                        }
                        else 
                        {
                            encoding = Encoding.Default;
                        }
                        Page.Response.ContentEncoding = encoding;
                        Page.Response.Write(url.Split(new[] {'|'})[1]);
                    }
                    else if (hid_PayMent.Value == "微信扫码")
                    {
                        //Response.Write("<script>top.location='/main/account/WeiXinPay.aspx?action=1&ordernumber=" + advancePaymentApplyLog.OrderNumber + "&payprice=" + advancePaymentApplyLog.OperateMoney + "';</script>");
                        Page.Response.Redirect("WeiXinPay.aspx?action=1&ordernumber=" + advancePaymentApplyLog.OrderNumber + "&payprice=" + advancePaymentApplyLog.OperateMoney );
                    }
                    else if (hid_PayMent.Value != "线下支付")
                    {
                        Page.Response.Redirect(url);
                    }
                    else
                    {
                        //Response.Write("<script>alert('线下支付申请提交成功！请及时汇款！');</script>");
                        //MessageBox.Show("线下支付申请提交成功！请及时汇款！");
                        //Page.Response.Redirect("/main/account/A_Index.aspx");
                        //Response.Write("<script>alert('线下支付申请提交成功！请及时汇款！');location.href='/main/account/A_Index.aspx';</script>");
                        Response.Write("<script>top.location='/main/member/m_index.aspx?action=3';</script>");
                        //Response.Write("<script>top.location='m_index.aspx?action=3';</script>");
                    }
                    GetMemInfo();
                    BindPayment();
                    method_2();
                }
                else
                {
                    MessageBox.Show("充值失败！");
                }
                GetMemInfo();
                BindPayment();
                #endregion
            }
            else
            {
                MessageBox.Show("充值金额不能为负数！");
            }
        }

        protected void Btn_Select_Click(object sender, EventArgs e)
        {
            strStartTime = txt_StartTime.Value;
            strEndTime = txt_EndTime.Value;
            RechargeType = hid_SelPayMentType.Value;
            strOrderNum = txt_OrderNum.Value;
            method_0();
            Page.Response.Redirect("A_AdPayRecharge.aspx?Type=1&pageid=1&StartTime=" + strStartTime + "&EndTime=" + strEndTime + "&RechargeType=" + RechargeType + "&OrderNum=" + strOrderNum);
        }

        protected int GetID()
        {
            string columnName = "ID";
            string tableName = "ShopNum1_AdvancePaymentApplyLog";
            return (1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
        }

        protected void GetMemInfo()
        {
            DataTable table =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(
                    base.MemLoginID);
            try
            {
                if (table.Rows.Count > 0)
                {
                    Lab_MemLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
                    Lab_AdPayment.Text = table.Rows[0]["AdvancePayment"].ToString();
                }
            }
            catch
            {
            }
        }

        public static string GetType(string OperateStatus)
        {
            if (OperateStatus == "0")
            {
                return "未处理";
            }
            if (OperateStatus == "1")
            {
                return "已处理";
            }
            if (OperateStatus == "2")
            {
                return "已拒绝";
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            GetMemInfo();
            BindPayment();
            if (!Page.IsPostBack)
            {
                strStartTime = (Common.Common.ReqStr("StartTime") == "") ? "" : Common.Common.ReqStr("StartTime");
                strEndTime = (Common.Common.ReqStr("EndTime") == "") ? "" : Common.Common.ReqStr("EndTime");
                strOrderNum = (Common.Common.ReqStr("OrderNum") == "") ? "" : Common.Common.ReqStr("OrderNum");
                RechargeType = (Common.Common.ReqStr("RechargeType") == "")
                    ? "-1"
                    : Common.Common.ReqStr("RechargeType");
                txt_StartTime.Value = strStartTime;
                txt_EndTime.Value = strEndTime;
                txt_OrderNum.Value = strOrderNum;
                hid_SelPayMentType.Value = RechargeType;
                method_0();
            }
        }

        private void method_0()
        {
            var action =
                (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            new DataTable();
            try
            {
                string strCondition = method_1();
                var commonModel = new CommonPageModel
                {
                    Condition = "  AND   1=1   " + strCondition + "     AND  IsDeleted=0   ",
                    Currentpage = pageid,
                    Resultnum = "0",
                    Tablename = "ShopNum1_AdvancePaymentApplyLog",
                    PageSize = PageSize
                };
                DataTable table = action.SelectAdvPayment_List(commonModel);
                var pl = new PageList1
                {
                    PageSize = Convert.ToInt32(PageSize),
                    PageID = Convert.ToInt32(pageid)
                };
                if ((table != null) && (table.Rows.Count > 0))
                {
                    pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
                }
                else
                {
                    pl.RecordCount = 0;
                }
                pageDiv.InnerHtml =
                    new PageListBll("main/Account/A_AdPayRecharge.aspx", true).GetPageListNew(pl);
                commonModel.Resultnum = "1";
                string str2 = Common.Common.GetNameById("SUM(cast(OperateMoney as float))",
                    "ShopNum1_AdvancePaymentApplyLog", strCondition);
                if (!string.IsNullOrEmpty(str2))
                {
                    lab_PayRecharge.Text = str2;
                }
                else
                {
                    lab_PayRecharge.Text = "0";
                }
                string str3 = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_AdvancePaymentApplyLog", strCondition);
                if (!string.IsNullOrEmpty(str3))
                {
                    lab_PayNum.Text = str3;
                }
                else
                {
                    lab_PayNum.Text = "0";
                }
                DataTable table2 = action.SelectAdvPayment_List(commonModel);
                if (table2.Rows.Count > 0)
                {
                    Rep_NoValue.Visible = false;
                    Rep_PayRecharge.DataSource = table2.DefaultView;
                    Rep_PayRecharge.DataBind();
                }
                else
                {
                    Rep_NoValue.Visible = true;
                    var table3 = new DataTable();
                    table3.Columns.Add("NoValue", typeof (string));
                    DataRow row = table3.NewRow();
                    row["NoValue"] = "暂无信息";
                    table3.Rows.Add(row);
                    Rep_NoValue.DataSource = table3;
                    Rep_NoValue.DataBind();
                }
            }
            catch
            {
            }
        }

        private string method_1()
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(Lab_MemLoginID.Text.Trim()))
            {
                str = str + "  AND  MemLoginID=  '" + Lab_MemLoginID.Text.Trim() + "'   ";
                if (Operator.FormatToEmpty(strStartTime) != string.Empty)
                {
                    str = str + " AND Date>='" + Operator.FilterString(strStartTime) + "'";
                }
                if (Operator.FormatToEmpty(strEndTime) != string.Empty)
                {
                    str = str + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " +
                          Operator.FilterString(strEndTime) + "'),120)  as  a)  ";
                }
                if (Operator.FormatToEmpty(strOrderNum) != string.Empty)
                {
                    str = str + " AND OrderNumber='" + strOrderNum + "'";
                }
                if ((Operator.FormatToEmpty(RechargeType) != string.Empty) &&
                    (Operator.FormatToEmpty(RechargeType) != "-1"))
                {
                    str = str + " AND PaymentGuid='" + RechargeType + "'";
                }
            }
            return (str + "AND  OperateType=1  ");
        }

        private void method_2()
        {
            txt_Recharge.Value = string.Empty;
            txt_Remark.Value = string.Empty;
        }

        protected void Rep_PayRecharge_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Charge")
            {
                var button = (LinkButton) sender;
                var field = button.Parent.FindControl("HiddenFieldPayMentValue") as HiddenField;
                var field2 = button.FindControl("HiddenFieldOrderNumber") as HiddenField;
                var field3 = button.FindControl("HiddenFieldOperateMoney") as HiddenField;
                string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
                string url = new PayUrlOperate().GetPayUrl(field.Value, field3.Value.Trim(),
                    ShopSettings.siteDomain + "/main/account/A_Index.aspx", "充值",
                    field2.Value, "Recharge", "0", "admin", base.MemLoginID,
                    timetemp);
                if (url.Length > 0x3e8)
                {
                    Encoding encoding;
                    if (url.Split(new[] {'|'})[0].IndexOf("UTF") != -1)
                    {
                        encoding = Encoding.UTF8;
                    }
                    else
                    {
                        encoding = Encoding.Default;
                    }
                    Page.Response.ContentEncoding = encoding;
                    Page.Response.Write(url.Split(new[] {'|'})[1]);
                }

                else if (hid_PayMent.Value != "线下支付")
                {
                    Page.Response.Redirect(url);
                }
                else
                {
                    MessageBox.Show("线下支付申请提交成功！请及时汇款！");
                }
            }
        }

        protected void Rep_PayRecharge_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var label = (Label) e.Item.FindControl("LabelOperateStatus");
                var anchor2 = (HtmlAnchor) e.Item.FindControl("deleteData");
                var anchor = (HtmlAnchor) e.Item.FindControl("PayUrl");
                if (label.Text == "未处理")
                {
                    anchor2.Visible = true;
                    anchor.Visible = true;
                    var field = (HiddenField) e.Item.FindControl("HiddenFieldPayMentValue");
                    var field2 = (HiddenField) e.Item.FindControl("HiddenFieldOrderNumber");
                    var field3 = (HiddenField) e.Item.FindControl("HiddenFieldOperateMoney");
                    var field4 = (HiddenField) e.Item.FindControl("HiddenFieldPaymentName");
                    string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
                    string str = new PayUrlOperate().GetPayUrl(field.Value, field3.Value.Trim(),
                        ShopSettings.siteDomain + "/main/account/A_Index.aspx",
                        "充值", field2.Value, "Recharge", "0", "admin",
                        base.MemLoginID, timetemp);
                    if (str.Length > 0x3e8)
                    {
                        anchor.HRef = str.Split(new[] {'|'})[1];
                    }
                    else
                    {
                        anchor.HRef = str;
                    }
                    if (field4.Value == "线下支付")
                    {
                        anchor.Visible = false;
                    }
                }
                else if (label.Text == "已拒绝")
                {
                    anchor2.Visible = true;
                    anchor.Visible = false;
                }
                else
                {
                    anchor.Visible = false;
                    anchor2.Visible = false;
                }
            }
        }

        
    }
}
                                            

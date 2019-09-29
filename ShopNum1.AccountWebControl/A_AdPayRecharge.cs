using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using ShopNum1MultiEntity;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_AdPayRecharge : BaseMemberWebControl
    {
        private Button Btn_Confirm;
        private Button Btn_Select;
        private Label Lab_AdPayment;
        private Label Lab_MemLoginID;
        private Repeater Rep_NoValue;
        private Repeater Rep_PayRecharge;
        private HtmlForm fromA_AdPayTiXian;
        private HtmlInputHidden hid_PayMent;
        private HtmlInputHidden hid_PayMentValue;
        private HtmlInputHidden hid_SelPayMentType;
        private HtmlInputText htmlInputText_3;
        private Label lab_PayNum;
        private Label lab_PayRecharge;
        private HtmlGenericControl pageDiv;
        private HtmlSelect sel_PayMent;
        private HtmlSelect sel_PayMentType;
        private string skinFilename = "A_AdPayRecharge.ascx";
        private HtmlInputText txt_EndTime;
        private HtmlInputText txt_Recharge;
        private HtmlTextArea txt_Remark;
        private HtmlInputText txt_StartTime;

        public A_AdPayRecharge()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string RechargeType { get; set; }

        public string strEndTime { get; set; }

        public string strOrderNum { get; set; }

        public string strStartTime { get; set; }

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

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            if (hid_PayMentValue.Value == "-1")
            {
                MessageBox.Show("请选择支付方式！");
            }
            else
            {
                var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = "1",
                    CurrentAdvancePayment = Convert.ToDecimal(Lab_AdPayment.Text),
                    OperateMoney = Convert.ToDecimal(txt_Recharge.Value),
                    OperateStatus = 0,
                    Date = DateTime.Now
                };
                string str2 = "C" + new Order().CreateOrderNumber();
                advancePaymentApplyLog.OrderNumber = str2;
                advancePaymentApplyLog.MemLoginID = base.MemLoginID;
                advancePaymentApplyLog.PaymentGuid = new Guid(hid_PayMentValue.Value);
                advancePaymentApplyLog.PaymentName = hid_PayMent.Value;
                advancePaymentApplyLog.Memo = txt_Remark.Value.Trim();
                advancePaymentApplyLog.UserMemo = DateTime.Now.ToLocalTime().ToString("yyyyMMddhhmmss");
                advancePaymentApplyLog.IsDeleted = 0;
                advancePaymentApplyLog.OrderStatus = 0;
                string str3 = GetID().ToString();
                advancePaymentApplyLog.ID = Convert.ToInt32(str3);
                var action =
                    (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                if (action.ApplyOperateMoney(advancePaymentApplyLog) > 0)
                {
                    string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
                    string url = new PayUrlOperate().GetPayUrl(hid_PayMentValue.Value, txt_Recharge.Value.Trim(),
                        ShopSettings.siteDomain + "/main/account/A_Index.aspx",
                        "充值", advancePaymentApplyLog.OrderNumber, "Recharge", "0",
                        "admin", base.MemLoginID, timetemp);
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
            }
        }

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            strStartTime = txt_StartTime.Value;
            strEndTime = txt_EndTime.Value;
            RechargeType = hid_SelPayMentType.Value;
            strOrderNum = htmlInputText_3.Value;
            BindData();
            Page.Response.Redirect("A_AdPayRecharge.aspx?Type=1&pageid=1&StartTime=" + strStartTime + "&EndTime=" +
                                   strEndTime + "&RechargeType=" + RechargeType + "&OrderNum=" + strOrderNum);
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

        protected override void InitializeSkin(Control skin)
        {
            fromA_AdPayTiXian = (HtmlForm) skin.FindControl("fromA_AdPayTiXian");
            txt_Recharge = (HtmlInputText) skin.FindControl("txt_Recharge");
            txt_Remark = (HtmlTextArea) skin.FindControl("txt_Remark");
            Lab_AdPayment = (Label) skin.FindControl("Lab_AdPayment");
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            Btn_Confirm = (Button) skin.FindControl("Btn_Confirm");
            Btn_Confirm.Click += Btn_Confirm_Click;
            Rep_PayRecharge = (Repeater) skin.FindControl("Rep_PayRecharge");
            Rep_PayRecharge.ItemDataBound += Rep_PayRecharge_ItemDataBound;
            Rep_PayRecharge.ItemCommand += Rep_PayRecharge_ItemCommand;
            Rep_NoValue = (Repeater) skin.FindControl("Rep_NoValue");
            sel_PayMent = (HtmlSelect) skin.FindControl("sel_PayMent");
            sel_PayMentType = (HtmlSelect) skin.FindControl("sel_PayMentType");
            hid_PayMent = (HtmlInputHidden) skin.FindControl("hid_PayMent");
            hid_PayMentValue = (HtmlInputHidden) skin.FindControl("hid_PayMentValue");
            hid_SelPayMentType = (HtmlInputHidden) skin.FindControl("hid_SelPayMentType");
            txt_StartTime = (HtmlInputText) skin.FindControl("txt_StartTime");
            txt_EndTime = (HtmlInputText) skin.FindControl("txt_EndTime");
            lab_PayNum = (Label) skin.FindControl("lab_PayNum");
            lab_PayRecharge = (Label) skin.FindControl("lab_PayRecharge");
            htmlInputText_3 = (HtmlInputText) skin.FindControl("txt_OrderNum");
            Btn_Select = (Button) skin.FindControl("Btn_Select");
            Btn_Select.Click += Btn_Select_Click;
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
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
                htmlInputText_3.Value = strOrderNum;
                hid_SelPayMentType.Value = RechargeType;
                BindData();
            }
        }

        private void BindData()
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

        private void Rep_PayRecharge_ItemCommand(object sender, RepeaterCommandEventArgs e)
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

        private void Rep_PayRecharge_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
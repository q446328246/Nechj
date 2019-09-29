using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_AdPayDecrease : BaseMemberWebControl
    {
        private Button Btn_Confirm;
        private Button Btn_Select;
        private Label Lab_AdPayment;
        private Label Lab_MemLoginID;
        private Repeater Rep_NoValue;
        private Repeater Rep_PayDecrease;
        private HtmlInputHidden hidMemberType;
        private HtmlInputHidden hid_BankType;
        private HtmlInputHidden hid_RealName;
        private HiddenField hid_SelectBank;
        private HtmlInputPassword input_PayPwd;
        private Label lab_PayDecrease;
        private Label lab_PayNum;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "A_AdPayDecrease.ascx";
        private HtmlInputText txt_Account;
        private HtmlInputText txt_Bank;
        private HtmlInputText txt_ConfirmBankID;
        private HtmlInputText txt_Decrease;
        private HtmlInputText txt_EndTime;
        private HtmlInputText txt_OrderNum;
        private HtmlInputText txt_RealName;
        private HtmlTextArea txt_Remark;
        private HtmlInputText txt_StartTime;
        private HtmlInputText txt_hidbank;

        public A_AdPayDecrease()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string strEndTime { get; set; }

        public string strHidbank { get; set; }

        public string strOrderNum { get; set; }

        public string strSelectBank { get; set; }

        public string strStartTime { get; set; }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            string payPwd =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetPayPwd(base.MemLoginID);
            if ((payPwd == "") || (payPwd == null))
            {
                Page.Response.Redirect("A_PwdSer.aspx");
            }
            else
            {
                Encryption.GetMd5SecondHash(input_PayPwd.Value.Trim());
                if (Convert.ToDecimal(txt_Decrease.Value) <= 0M)
                {
                    MessageBox.Show("交易金额不能为零或者负数！");
                }
                else if (Convert.ToDecimal(txt_Decrease.Value) > Convert.ToDecimal(Lab_AdPayment.Text))
                {
                    MessageBox.Show("提现金额不能大于金币（BV）");
                }
                else if (txt_Remark.Value.Length > 300)
                {
                    MessageBox.Show("会员备注不能大于300字符");
                }
                else
                {
                    var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                    {
                        Guid = Guid.NewGuid(),
                        OperateType = "0",
                        CurrentAdvancePayment = Convert.ToDecimal(Lab_AdPayment.Text),
                        OperateMoney = Convert.ToDecimal(txt_Decrease.Value.Trim()),
                        OperateStatus = 0,
                        Date = DateTime.Now
                    };
                    advancePaymentApplyLog.OrderNumber = "T" + new Order().CreateOrderNumber();
                    advancePaymentApplyLog.Memo = txt_Remark.Value;
                    advancePaymentApplyLog.MemLoginID = base.MemLoginID;
                    advancePaymentApplyLog.PaymentGuid = Guid.Empty;
                    advancePaymentApplyLog.PaymentName = string.Empty;
                    if (hid_BankType.Value == "线下打款")
                    {
                        advancePaymentApplyLog.Bank = txt_Bank.Value;
                        advancePaymentApplyLog.TrueName = txt_RealName.Value;
                        advancePaymentApplyLog.Account = txt_ConfirmBankID.Value;
                    }
                    else
                    {
                        advancePaymentApplyLog.Bank = hid_BankType.Value;
                        advancePaymentApplyLog.TrueName = hid_RealName.Value;
                        advancePaymentApplyLog.Account = txt_Account.Value;
                    }
                    advancePaymentApplyLog.IsDeleted = 0;
                    advancePaymentApplyLog.ID = method_2() + 1;
                    var action3 =
                        (ShopNum1_AdvancePaymentApplyLog_Action)
                            LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                    if (action3.ApplyOperateMoney(advancePaymentApplyLog) > 0)
                    {
                        try
                        {
                            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                            {
                                Guid = Guid.NewGuid(),
                                OperateType = 2,
                                CurrentAdvancePayment = advancePaymentApplyLog.CurrentAdvancePayment,
                                OperateMoney = Convert.ToDecimal(txt_Decrease.Value.Trim()),
                                LastOperateMoney =
                                    Convert.ToDecimal(advancePaymentApplyLog.CurrentAdvancePayment) -
                                    Convert.ToDecimal(txt_Decrease.Value.Trim()),
                                Date = DateTime.Now,
                                Memo = "会员提现扣除金币（BV）￥" + txt_Decrease.Value.Trim(),
                                MemLoginID = base.MemLoginID,
                                CreateUser = base.MemLoginID,
                                CreateTime = DateTime.Now,
                                IsDeleted = 0
                            };
                            ((ShopNum1_AdvancePaymentModifyLog_Action)
                                LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                                    advancePaymentModifyLog);
                        }
                        catch (Exception)
                        {
                        }
                        GetMemInfo();
                        MessageBox.Show("申请成功");
                        Page.Response.Redirect("A_AdPayDecrease.aspx?type=1");
                    }
                }
            }
        }

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            strStartTime = txt_StartTime.Value;
            strEndTime = txt_EndTime.Value;
            strOrderNum = txt_OrderNum.Value;
            method_0();
            Page.Response.Redirect("A_AdPayDecrease.aspx?Type=1&pageid=1&StartTime=" + strStartTime + "&EndTime=" +
                                   strEndTime + "&OrderNum=" + strOrderNum);
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
                    hid_RealName.Value = table.Rows[0]["RealName"].ToString();
                }
            }
            catch
            {
            }
        }

        public static string GetState(string type)
        {
            if (type == "0")
            {
                return "未处理";
            }
            if (type == "1")
            {
                return "已完成";
            }
            if (type == "2")
            {
                return "拒绝申请";
            }
            return "";
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_Decrease = (HtmlInputText) skin.FindControl("txt_Decrease");
            txt_Bank = (HtmlInputText) skin.FindControl("txt_Bank");
            txt_Remark = (HtmlTextArea) skin.FindControl("txt_Remark");
            txt_RealName = (HtmlInputText) skin.FindControl("txt_RealName");
            txt_ConfirmBankID = (HtmlInputText) skin.FindControl("txt_ConfirmBankID");
            Lab_AdPayment = (Label) skin.FindControl("Lab_AdPayment");
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            input_PayPwd = (HtmlInputPassword) skin.FindControl("input_PayPwd");
            hid_BankType = (HtmlInputHidden) skin.FindControl("hid_BankType");
            txt_Account = (HtmlInputText) skin.FindControl("txt_Account");
            hid_RealName = (HtmlInputHidden) skin.FindControl("hid_RealName");
            txt_hidbank = (HtmlInputText) skin.FindControl("txt_hidbank");
            Btn_Confirm = (Button) skin.FindControl("Btn_Confirm");
            Btn_Confirm.Click += Btn_Confirm_Click;
            Rep_PayDecrease = (Repeater) skin.FindControl("Rep_PayDecrease");
            Rep_NoValue = (Repeater) skin.FindControl("Rep_NoValue");
            hidMemberType = (HtmlInputHidden) skin.FindControl("hidMemberType");
            hid_SelectBank = (HiddenField) skin.FindControl("hid_SelectBank");
            txt_StartTime = (HtmlInputText) skin.FindControl("txt_StartTime");
            txt_EndTime = (HtmlInputText) skin.FindControl("txt_EndTime");
            txt_OrderNum = (HtmlInputText) skin.FindControl("txt_OrderNum");
            Btn_Select = (Button) skin.FindControl("Btn_Select");
            Btn_Select.Click += Btn_Select_Click;
            lab_PayNum = (Label) skin.FindControl("lab_PayNum");
            lab_PayDecrease = (Label) skin.FindControl("lab_PayDecrease");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            GetMemInfo();
            if (!Page.IsPostBack)
            {
                strStartTime = (Common.Common.ReqStr("StartTime") == "") ? "" : Common.Common.ReqStr("StartTime");
                strEndTime = (Common.Common.ReqStr("EndTime") == "") ? "" : Common.Common.ReqStr("EndTime");
                strOrderNum = (Common.Common.ReqStr("OrderNum") == "") ? "" : Common.Common.ReqStr("OrderNum");
                txt_StartTime.Value = strStartTime;
                txt_EndTime.Value = strEndTime;
                txt_OrderNum.Value = strOrderNum;
                hidMemberType.Value = Common.Common.GetNameById("membertype", "shopnum1_member",
                    " And MemloginId='" + base.MemLoginID + "'");
                method_0();
            }
        }

        private void method_0()
        {
            string text1 = hid_SelectBank.Value;
            var action =
                (ShopNum1_AdvancePaymentApplyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            new DataTable();
            try
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(Lab_MemLoginID.Text.Trim()))
                {
                    str = str + "  AND  MemLoginID=  '" + base.MemLoginID + "'  ";
                    str = method_1(str);
                }
                var commonModel = new CommonPageModel
                {
                    Condition = "  AND   1=1   " + str + "     AND  IsDeleted=0      ",
                    Currentpage = pageid,
                    Resultnum = "0",
                    Tablename = "ShopNum1_AdvancePaymentApplyLog",
                    PageSize = PageSize
                };
                DataTable table2 = action.SelectAdvPayment_List(commonModel);
                var pl = new PageList1
                {
                    PageSize = Convert.ToInt32(PageSize),
                    PageID = Convert.ToInt32(pageid)
                };
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    pl.RecordCount = Convert.ToInt32(table2.Rows[0][0]);
                }
                else
                {
                    pl.RecordCount = 0;
                }
                pageDiv.InnerHtml =
                    new PageListBll("main/Account/A_AdPayDecrease.aspx", true).GetPageListNew(pl);
                commonModel.Resultnum = "1";
                DataTable table = action.SelectAdvPayment_List(commonModel);
                string str3 = Common.Common.GetNameById("SUM(cast(OperateMoney as float))",
                    "ShopNum1_AdvancePaymentApplyLog", str);
                if (!string.IsNullOrEmpty(str3))
                {
                    lab_PayDecrease.Text = str3;
                }
                else
                {
                    lab_PayDecrease.Text = "0";
                }
                string str2 = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_AdvancePaymentApplyLog", str);
                if (!string.IsNullOrEmpty(str2))
                {
                    lab_PayNum.Text = str2;
                }
                else
                {
                    lab_PayNum.Text = "0";
                }
                if (table.Rows.Count > 0)
                {
                    Rep_NoValue.Visible = false;
                    Rep_PayDecrease.DataSource = table.DefaultView;
                    Rep_PayDecrease.DataBind();
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

        private string method_1(string string_8)
        {
            if (Operator.FormatToEmpty(strStartTime) != string.Empty)
            {
                string_8 = string_8 + " AND Date>='" + Operator.FilterString(strStartTime) + "' ";
            }
            if (Operator.FormatToEmpty(strEndTime) != string.Empty)
            {
                string_8 = string_8 + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " +
                           Operator.FilterString(strEndTime) + "'),120)  as  a)  ";
            }
            if (Operator.FormatToEmpty(strOrderNum) != string.Empty)
            {
                string_8 = string_8 + " AND OrderNumber='" + strOrderNum + "'";
            }
            string_8 = string_8 + "AND  OperateType=0  ";
            return string_8;
        }

        private int method_2()
        {
            try
            {
                return Common.Common.ReturnMaxID("ID", "MemLoginID", base.MemLoginID, "ShopNum1_AdvancePaymentApplyLog");
            }
            catch
            {
                return 0;
            }
        }
    }
}
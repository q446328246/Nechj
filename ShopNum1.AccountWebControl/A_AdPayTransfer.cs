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
    public class A_AdPayTransfer : BaseMemberWebControl
    {
        private Button Btn_Confirm;
        private Button Btn_Select;
        private Label Lab_AdPayment;
        private Label Lab_MemLoginID;
        private Repeater Rep_NoValue;
        private Repeater Rep_PayTransfer;
        private HtmlInputPassword input_PayPwd;
        private Label lab_PayNum;
        private Label lab_PayTransfer;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "A_AdPayTransfer.ascx";
        private HtmlInputText txt_ConfirmTransferID;
        private HtmlInputText txt_EndTime;
        private HtmlInputText txt_OrderNum;
        private HtmlInputText txt_RealName;
        private HtmlTextArea txt_Remark;
        private HtmlInputText txt_StartTime;
        private HtmlInputText txt_Transfer;
        private HtmlInputText txt_TransferID;

        public A_AdPayTransfer()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AdPayment { get; set; }

        public string OrderNumber { get; set; }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string strEndTime { get; set; }

        public string strOrderNum { get; set; }

        public string strStartTime { get; set; }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string payPwd = action.GetPayPwd(base.MemLoginID);
            if ((payPwd == "") || (payPwd == null))
            {
                Page.Response.Redirect("A_PwdSer.aspx");
            }
            else
            {
                string str3 = Encryption.GetMd5SecondHash(input_PayPwd.Value.Trim());
                if (payPwd != str3)
                {
                    MessageBox.Show("交易密码不正确!");
                }
                else
                {
                    var table = new DataTable();
                    if (txt_ConfirmTransferID.Value.Trim() != txt_TransferID.Value.Trim())
                    {
                        MessageBox.Show("转账id不匹配");
                    }
                    else if (txt_TransferID.Value.Trim() == base.MemLoginID)
                    {
                        MessageBox.Show("您不能转账给自己！");
                    }
                    else if (action.CheckmemLoginID(txt_TransferID.Value.Trim()) > 0)
                    {
                        string str2 = action.GetPayPwd(base.MemLoginID);
                        if (Encryption.GetMd5SecondHash(input_PayPwd.Value.Trim()) == str2)
                        {
                            table = action.SearchByMemLoginID(txt_TransferID.Value);
                            switch (
                                action.Transfer(base.MemLoginID, txt_TransferID.Value, txt_Transfer.Value.Trim()))
                            {
                                case -1:
                                    MessageBox.Show("金币（BV）不足！");
                                    break;

                                case 0:
                                    MessageBox.Show("转账失败！");
                                    break;

                                case 1:
                                    try
                                    {
                                        var transfer = new ShopNum1_PreTransfer
                                        {
                                            Guid = Guid.NewGuid(),
                                            IsDeleted = 0,
                                            MemLoginID = base.MemLoginID,
                                            RMemberID = txt_TransferID.Value
                                        };
                                        if (string.IsNullOrEmpty(txt_Remark.Value))
                                        {
                                            txt_Remark.Value = "转账给" + txt_TransferID.Value;
                                        }
                                        transfer.Memo = txt_Remark.Value;
                                        transfer.OperateMoney = txt_Transfer.Value;
                                        transfer.OperateStatus = 0;
                                        transfer.type = 1;
                                        transfer.OperateStatus = 1;
                                        transfer.Date = DateTime.Now.ToLocalTime();
                                        var order = new Order();
                                        OrderNumber = transfer.OrderNumber = "Z" + order.CreateOrderNumber();
                                        method_0(transfer);
                                    }
                                    catch
                                    {
                                    }
                                    MoneyModifyLog(base.MemLoginID, txt_Transfer.Value.Trim(), Lab_AdPayment.Text.Trim(),
                                        "0",
                                        "您转账给会员" + txt_TransferID.Value + "￥" + txt_Transfer.Value.Trim());
                                    MoneyModifyLog(txt_TransferID.Value.Trim(), txt_Transfer.Value.Trim(),
                                        table.Rows[0]["AdvancePayment"].ToString(), "1",
                                        "会员" + base.MemLoginID + "转账￥" + txt_Transfer.Value.Trim() + "给您");
                                    GetMemInfo();
                                    method_1();
                                    MessageBox.Show("转账成功！");
                                    Page.Response.Redirect("A_AdPayTransfer.aspx?type=1");
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("交易密码有误！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("该用户不存在！");
                    }
                }
            }
        }

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            strStartTime = txt_StartTime.Value;
            strEndTime = txt_EndTime.Value;
            strOrderNum = txt_OrderNum.Value;
            string str = Common.Common.ReqStr("Type");
            str = (str == "") ? "0" : str;
            Page.Response.Redirect("A_AdPayTransfer.aspx?Type=" + str + "&pageid=1&StartTime=" + strStartTime +
                                   "&EndTime=" + strEndTime + "&OrderNum=" + strOrderNum);
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
                    Lab_AdPayment.Text = (table.Rows[0]["AdvancePayment"].ToString() == "")
                        ? "0.00"
                        : table.Rows[0]["AdvancePayment"].ToString();
                    AdPayment = Lab_AdPayment.Text;
                }
            }
            catch
            {
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_Transfer = (HtmlInputText) skin.FindControl("txt_Transfer");
            txt_TransferID = (HtmlInputText) skin.FindControl("txt_TransferID");
            txt_Remark = (HtmlTextArea) skin.FindControl("txt_Remark");
            txt_RealName = (HtmlInputText) skin.FindControl("txt_RealName");
            txt_ConfirmTransferID = (HtmlInputText) skin.FindControl("txt_ConfirmTransferID");
            Lab_AdPayment = (Label) skin.FindControl("Lab_AdPayment");
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            input_PayPwd = (HtmlInputPassword) skin.FindControl("input_PayPwd");
            Btn_Confirm = (Button) skin.FindControl("Btn_Confirm");
            Btn_Confirm.Click += Btn_Confirm_Click;
            Rep_PayTransfer = (Repeater) skin.FindControl("Rep_PayTransfer");
            Rep_NoValue = (Repeater) skin.FindControl("Rep_NoValue");
            txt_OrderNum = (HtmlInputText) skin.FindControl("txt_OrderNum");
            txt_StartTime = (HtmlInputText) skin.FindControl("txt_StartTime");
            txt_EndTime = (HtmlInputText) skin.FindControl("txt_EndTime");
            lab_PayNum = (Label) skin.FindControl("lab_PayNum");
            lab_PayTransfer = (Label) skin.FindControl("lab_PayTransfer");
            Btn_Select = (Button) skin.FindControl("Btn_Select");
            Btn_Select.Click += Btn_Select_Click;
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
                method_1();
            }
        }

        private void method_0(ShopNum1_PreTransfer shopNum1_PreTransfer_0)
        {
            new ShopNum1_PreTransfer_Action().InsertPay(shopNum1_PreTransfer_0);
        }

        private void method_1()
        {
            var action =
                (ShopNum1_AdvancePaymentModifyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            try
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(base.MemLoginID))
                {
                    if (Common.Common.ReqStr("type") == "0")
                    {
                        return;
                    }
                    if (Common.Common.ReqStr("type") == "1")
                    {
                        str = str + "  AND  MemLoginID=  '" + base.MemLoginID + "'   ";
                        str = method_2(str);
                    }
                    else
                    {
                        str = str + "  AND  Rmemberid=  '" + base.MemLoginID + "'   ";
                        str = method_2(str);
                    }
                }
                var commonModel = new CommonPageModel
                {
                    Condition = "  AND   1=1   " + str + "     AND  IsDeleted=0 ",
                    Currentpage = pageid,
                    Tablename = "ShopNum1_PreTransfer",
                    Resultnum = "0",
                    PageSize = PageSize
                };
                DataTable table3 = action.SelectAdvPaymentModifyLog_List(commonModel);
                var pl = new PageList1
                {
                    PageSize = Convert.ToInt32(PageSize),
                    PageID = Convert.ToInt32(pageid)
                };
                if ((table3 != null) && (table3.Rows.Count > 0))
                {
                    pl.RecordCount = Convert.ToInt32(table3.Rows[0][0]);
                }
                else
                {
                    pl.RecordCount = 0;
                }
                pageDiv.InnerHtml =
                    new PageListBll("main/Account/A_AdPayTransfer.aspx", true).GetPageListNew(pl);
                commonModel.Resultnum = "1";
                DataTable table = action.SelectAdvPaymentModifyLog_List(commonModel);
                string str2 = Common.Common.GetNameById("SUM(cast(OperateMoney as float))", "ShopNum1_PreTransfer", str);
                if (!string.IsNullOrEmpty(str2))
                {
                    lab_PayTransfer.Text = str2;
                }
                else
                {
                    lab_PayTransfer.Text = "0";
                }
                string str3 = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_PreTransfer", str);
                if (!string.IsNullOrEmpty(str3))
                {
                    lab_PayNum.Text = str3;
                }
                else
                {
                    lab_PayNum.Text = "0";
                }
                if (table.Rows.Count > 0)
                {
                    Rep_NoValue.Visible = false;
                    Rep_PayTransfer.DataSource = table;
                    Rep_PayTransfer.DataBind();
                }
                else
                {
                    Rep_NoValue.Visible = true;
                    var table2 = new DataTable();
                    table2.Columns.Add("NoValue", typeof (string));
                    DataRow row = table2.NewRow();
                    row["NoValue"] = "暂无信息";
                    table2.Rows.Add(row);
                    Rep_NoValue.DataSource = table2;
                    Rep_NoValue.DataBind();
                }
            }
            catch
            {
            }
        }

        private string method_2(string string_8)
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
            return string_8;
        }

        protected void MoneyModifyLog(string memloginID, string money, string CurrentAdvancePayment, string type,
            string string_8)
        {
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
            {
                Guid = Guid.NewGuid(),
                OperateType = 6,
                CurrentAdvancePayment = Convert.ToDecimal(CurrentAdvancePayment),
                OperateMoney = Convert.ToDecimal(money)
            };
            if (type == "0")
            {
                advancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(CurrentAdvancePayment) -
                                                           Convert.ToDecimal(money);
            }
            else
            {
                advancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(CurrentAdvancePayment) +
                                                           Convert.ToDecimal(money);
            }
            advancePaymentModifyLog.Date = DateTime.Now;
            advancePaymentModifyLog.Memo = string_8;
            advancePaymentModifyLog.MemLoginID = memloginID;
            advancePaymentModifyLog.CreateUser = base.MemLoginID;
            advancePaymentModifyLog.CreateTime = DateTime.Now;
            advancePaymentModifyLog.IsDeleted = 0;
            new Order();
            advancePaymentModifyLog.OrderNumber = OrderNumber;
            advancePaymentModifyLog.UserMemo = txt_Remark.Value;
            ((ShopNum1_AdvancePaymentModifyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                .OperateMoney(advancePaymentModifyLog);
        }
    }
}
using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_AdPayTransfer_Rv_Bv : BaseMemberControl
    {
        public string AdPayment { get; set; }

        public string OrderNumber { get; set; }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string strEndTime { get; set; }

        public string strOrderNum { get; set; }

        public string strStartTime { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
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
                BindData();
            }
        }

        /// <summary>
        /// 生成转帐单
        /// </summary>
        /// <param name="shopNum1_PreTransfer_0"></param>
        private void GeneratePreTransfer(ShopNum1_PreTransfer shopNum1_PreTransfer_0)
        {
            new ShopNum1_PreTransfer_Action().InsertPay(shopNum1_PreTransfer_0);
        }

        private void BindData()
        {
            var action =
                (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
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
                    PageSize = PageSize,
                    Select_YuJu = "*"
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
                    new PageListBll("main/Account/A_AdPayTransfer_Rv_Bv.aspx", true).GetPageListNew(pl);
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
                    table2.Columns.Add("NoValue", typeof(string));
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

        /// <summary>
        /// 会员金币（BV）转帐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Confirm_Click(object sender, EventArgs e)
        {

            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (action.CheckmemLoginID(base.MemLoginID.Trim()) > 0)
            {
                string strMemID = action.GetMemLoginIDONNO(base.MemLoginID.Trim());
                string payPwd = action.GetPayPwd(base.MemLoginID);
                if ((payPwd == "") || (payPwd == null))
                {
                    Page.Response.Redirect("A_PwdSer.aspx");
                }
                else
                {
                    string str3 = Common.Encryption.GetMd5SecondHash(input_PayPwd.Value.Trim());
                    if (payPwd != str3)
                    {
                        MessageBox.Show("支付密码不正确!");
                    }
                    else
                    {
                        var table = new DataTable();

                        
                        
                        if (Convert.ToDecimal(txt_Transfer.Value.Trim()) < 0)
                        {
                            MessageBox.Show("您不能转换负数！");
                        }
                        else 
                        {
                            #region
                            string str2 = action.GetPayPwd(base.MemLoginID);
                            if (Common.Encryption.GetMd5SecondHash(input_PayPwd.Value.Trim()) == str2)
                            {
                                table = action.SearchByMemLoginID(base.MemLoginID);
                                switch (
                                    action.Transfer_Rv_Bv(base.MemLoginID, strMemID, txt_Transfer.Value.Trim()))
                                {
                                    case -1:
                                        MessageBox.Show("人民币（RV）不足！");
                                        break;

                                    case 0:
                                        MessageBox.Show("转账失败！");
                                        break;

                                    case 1:
                                        try //转帐日志
                                        {
                                            //var transfer = new ShopNum1_PreTransfer
                                            //{
                                            //    Guid = Guid.NewGuid(),
                                            //    IsDeleted = 0,
                                            //    MemLoginID = base.MemLoginID,
                                            //    //RMemberID = txt_TransferID.Value
                                            //    RMemberID = strMemID
                                            //};

                                            //if (string.IsNullOrEmpty(txt_Remark.Value))
                                            //{
                                            //    //txt_Remark.Value = "转账给" + txt_TransferID.Value;
                                            //    txt_Remark.Value = "转账给" + strMemID;
                                            //}

                                            //transfer.Memo = txt_Remark.Value;
                                            //transfer.OperateMoney = txt_Transfer.Value;
                                            //transfer.OperateStatus = 0;
                                            //transfer.type = 1;
                                            //transfer.OperateStatus = 1;
                                            //transfer.Date = DateTime.Now.ToLocalTime();
                                            var order = new Order();
                                            OrderNumber = "ZH" + order.CreateOrderNumber();
                                            //= transfer.OrderNumber
                                            //GeneratePreTransfer(transfer);

                                        }
                                        catch
                                        {

                                        }
                                        MoneyModifyLog_RV(base.MemLoginID, txt_Transfer.Value.Trim(), table.Rows[0]["Score_rv"].ToString(), "0", "您转换人民币￥" + txt_Transfer.Value.Trim() + "为金币");
                                        MoneyModifyLog_BV(strMemID.Trim(), txt_Transfer.Value.Trim(), table.Rows[0]["AdvancePayment"].ToString(), "1", "您转换人民币为" + txt_Transfer.Value.Trim() + "金币");

                                        GetMemInfo();
                                        BindData();
                                        MessageBox.Show("转账成功！");
                                        Page.Response.Redirect("A_AdPayDetailList.aspx");
                                        //Response.Write("<script>top.location='A_AdPayDetailList.aspx?action=1';</script>");
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("支付密码有误！");
                            }
                            #endregion
                        }

                        
                    }
                }
            }
            else
            {
                MessageBox.Show("收款人用户有误或不存在！");
            }
        }

        protected void Btn_Select_Click(object sender, EventArgs e)
        {
            strStartTime = txt_StartTime.Value;
            strEndTime = txt_EndTime.Value;
            strOrderNum = txt_OrderNum.Value;
            string str = Common.Common.ReqStr("Type");
            str = (str == "") ? "0" : str;
            Page.Response.Redirect("A_AdPayTransfer_Rv_Bv.aspx?Type=" + str + "&pageid=1&StartTime=" + strStartTime +
                                   "&EndTime=" + strEndTime + "&OrderNum=" + strOrderNum);
        }

        protected int GetID()
        {
            string columnName = "ID";
            string tableName = "ShopNum1_AdvancePaymentApplyLog";
            return (1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
        }

        /// <summary>
        /// 会员金币（BV）帐户信息
        /// </summary>
        protected void GetMemInfo()
        {
            DataTable table = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(base.MemLoginID);
            try
            {
                if (table.Rows.Count > 0)
                {
                    Lab_MemLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
                    Lab_AdPayment.Text = (table.Rows[0]["Score_rv"].ToString() == "") ? "0.00" : table.Rows[0]["Score_rv"].ToString();
                    AdPayment = Lab_AdPayment.Text;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 转帐日志
        /// </summary>
        /// <param name="memloginID"></param>
        /// <param name="money"></param>
        /// <param name="CurrentAdvancePayment"></param>
        /// <param name="type"></param>
        /// <param name="string_8"></param>
        protected void MoneyModifyLog_RV(string memloginID, string money, string CurrentScore_rv, string type, string string_8)
        {
            DataTable table = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(memloginID);
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
            {
                
                Guid = Guid.NewGuid(),
                OperateType = 6,

                
            };
            
            if (type == "0")
            {

                advancePaymentModifyLog.OperateMoney = Convert.ToDecimal(money);
                advancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(CurrentScore_rv);
                advancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(CurrentScore_rv) -
                                                           Convert.ToDecimal(money);
                
            }
            else
            {

                advancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(CurrentScore_rv);
                advancePaymentModifyLog.OperateMoney = Convert.ToDecimal(money);
                advancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(CurrentScore_rv) +
                                                           Convert.ToDecimal(money);
                
            }
            
            advancePaymentModifyLog.Date = DateTime.Now;
            advancePaymentModifyLog.Memo = string_8;
            advancePaymentModifyLog.MemLoginID = memloginID;
            advancePaymentModifyLog.CreateUser = base.MemLoginID;
            advancePaymentModifyLog.CreateTime = DateTime.Now;
            advancePaymentModifyLog.IsDeleted = 0;
            
            ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                .OperateMoneyRVRVRV(advancePaymentModifyLog);
        }

        protected void MoneyModifyLog_BV(string memloginID, string money, string CurrentAdvancePayment, string type,
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
            
            ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                .OperateMoney(advancePaymentModifyLog);
        }
    }
}


using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_AdPayDetailList : BaseMemberControl
    {
        public string EndTime { get; set; }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string StartTime { get; set; }

        public string strEndTime { get; set; }

        public string strOrderNum { get; set; }

        public string strPayType { get; set; }

        public string strStartTime { get; set; }
        public string strSelect { get; set; }

        protected void Btn_Select_Click(object sender, EventArgs e)
        {
            strStartTime = txt_StartTime.Value;
            strEndTime = txt_EndTime.Value;
            strPayType = sel_Type.Value;
            strSelect = sel_Type.Value;
            method_0();
            Page.Response.Redirect("A_AdPayDetailList.aspx?Type=1&pageid=1&StartTime=" + strStartTime + "&EndTime=" +
                                   strEndTime + "&PayType=" + strPayType);
        }

        public static string ChangeOperateType(string operateType)
        {
            if (operateType == "1")
            {
                return "增加";
            }
            if (operateType == "2")
            {
                return "扣取";
            }
            if (operateType == "3")
            {
                return "消费";
            }
            if (operateType == "4")
            {
                return "收入";
            }
            if (operateType == "5")
            {
                return "系统";
            }
            if (operateType == "6")
            {
                return "转账";
            }
            if (operateType == "7")
            {
                 return "积分消费";
            }
            if (operateType == "8")
            {
                return "积分获得";
            }
            if (operateType == "9")
            {
                return "红包消费";
            }
            if (operateType == "10")
            {
                return "红包获得";
            }
            if (operateType == "11")
            {
                return "重消积分消费";
            }
            if (operateType == "12")
            {
                return "重消积分获得";
            }
            if (operateType == "13")
            {
                return "店铺收入、提现";
            }
            if (operateType == "14")
            {
                return "重消币消费";
            }
            if (operateType == "15")
            {
                return "重消币获得";
            }
            if (operateType == "16")
            {
                return "C积分消费";
            }
            if (operateType == "17")
            {
                return "C积分获得";
            }
            if (operateType == "18")
            {
                return "冻结收入、扣除";
            }
            return "";
        }

        public static string GetMoney(string CurrentAdvancePayment, string LastOperateMoney, string OperateMoney)
        {
            decimal num = Convert.ToDecimal(CurrentAdvancePayment);
            decimal num2 = Convert.ToDecimal(LastOperateMoney);
            if (num > num2)
            {
                return ("-" + OperateMoney);
            }
            if (num < num2)
            {
                return ("+" + OperateMoney);
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            if (!Page.IsPostBack)
            {
                strStartTime = (Common.Common.ReqStr("StartTime") == "") ? "" : Common.Common.ReqStr("StartTime");
                strEndTime = (Common.Common.ReqStr("EndTime") == "") ? "" : Common.Common.ReqStr("EndTime");
                strPayType = (Common.Common.ReqStr("PayType") == "") ? "-1" : Common.Common.ReqStr("PayType");
                txt_StartTime.Value = strStartTime;
                txt_EndTime.Value = strEndTime;
                hid_type.Value = strPayType;
                sel_Type.Value = strSelect;
                method_0();
            }
        }

        private void method_0()
        {
            var action =
                (ShopNum1_AdvancePaymentModifyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            try
            {
                string str = string.Empty;
                str = method_1(str);
                string selce_two = string.Empty;
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                {
                    selce_two = " and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_rv <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_cv <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_cv <> 0";
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                {
                    selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_DJ_BV <> 0";
                }
                var commonModel = new CommonPageModel
                {
                    Condition = "  AND   1=1   " + str + selce_two,
                    Currentpage = pageid,
                    Tablename = "ShopNum1_AdvancePaymentModifyLog",
                     Resultnum = "0",
                    PageSize = PageSize
                }; 
               
		       commonModel.Select_YuJu="*";
	            
                
                DataTable table = action.SelectAdvPaymentModifyLog_List(commonModel);
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
                    new PageListBll("main/Account/A_AdPayDetailList.aspx?", true).GetPageListNew(pl);
                commonModel.Resultnum = "1";
                decimal num2 = 0M;
                string str2 = "0";
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(HuoDe_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(XiaoFei_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(HuoDe_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(HuoDe_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_rv as money_first,XiaoFei_rv as money_two,XiaoFei_Hou_rv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(XiaoFei_rv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(HuoDe_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(DeDao_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_Qian_cv as money_first,XiaoFei_cv as money_two,XiaoFei_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(XiaoFei_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_cv as money_first,DeDao_cv as money_two,DeDao_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                     str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                {
                    commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_DJ_BV as money_first,HuoDe_DJ_BV as money_two,Huo_DeHou_DJ_BV as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                    str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                }
                DataTable table2 = action.SelectAdvPaymentModifyLog_List(commonModel);
                Rep_PayA_AdPayDetailList.DataSource = table2.DefaultView;
                Rep_PayA_AdPayDetailList.DataBind();
                int num = 0;
                string str3 = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                if (!string.IsNullOrEmpty(str3))
                {
                    num = Convert.ToInt32(str3);
                }
                lab_PayNum.Text = num.ToString();

               
                if (!string.IsNullOrEmpty(str2))
                {
                    num2 = Convert.ToDecimal(str2);
                }
                lab_PayDetail.Text = num2.ToString();
                if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == -1)
                {
                    MYid_one.Visible = false;
                }
                else
                {
                    MYid_one.Visible = true;
                }
            }
            catch
            {
            }
        }

        private string method_1(string string_9)
        {
            if (!string.IsNullOrEmpty(base.MemLoginID))
            {
                string_9 = string_9 + "  AND  MemLoginID=  '" + base.MemLoginID + "'   ";
            }
            if (Operator.FormatToEmpty(strStartTime) != string.Empty)
            {
                string_9 = string_9 + " AND Date>='" + Operator.FilterString(strStartTime) + "' ";
            }
            if (Operator.FormatToEmpty(strEndTime) != string.Empty)
            {
                string_9 = string_9 + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " +
                           Operator.FilterString(strEndTime) + "'),120)  as  a)  ";
            }
            if ((Operator.FormatToEmpty(strPayType) != string.Empty) && (Operator.FormatToEmpty(strPayType) != "-1") && Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <=6)
            {
                string_9 = string_9 + " AND OperateType=" + strPayType;
            }
            return string_9;
        }
    }
}
                                            

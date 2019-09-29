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
    public class A_AdPayDetailList : BaseMemberWebControl
    {
        private Button Btn_Select;
        private Repeater Rep_PayA_AdPayDetailList;
        private HtmlInputHidden hid_type;
        private Label lab_PayDetail;
        private Label lab_PayNum;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "A_AdPayDetailList.ascx";
        private HtmlInputText txt_EndTime;
        private HtmlInputText txt_StartTime;

        public A_AdPayDetailList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string EndTime { get; set; }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string StartTime { get; set; }

        public string strEndTime { get; set; }

        public string strOrderNum { get; set; }

        public string strPayType { get; set; }

        public string strStartTime { get; set; }

        private void Btn_Select_Click(object sender, EventArgs e)
        {
            strStartTime = txt_StartTime.Value;
            strEndTime = txt_EndTime.Value;
            strPayType = hid_type.Value;
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

        protected override void InitializeSkin(Control skin)
        {
            Rep_PayA_AdPayDetailList = (Repeater) skin.FindControl("Rep_PayA_AdPayDetailList");
            hid_type = (HtmlInputHidden) skin.FindControl("hid_type");
            txt_StartTime = (HtmlInputText) skin.FindControl("txt_StartTime");
            txt_EndTime = (HtmlInputText) skin.FindControl("txt_EndTime");
            lab_PayNum = (Label) skin.FindControl("lab_PayNum");
            lab_PayDetail = (Label) skin.FindControl("lab_PayDetail");
            Btn_Select = (Button) skin.FindControl("Btn_Select");
            Btn_Select.Click += Btn_Select_Click;
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            if (!Page.IsPostBack)
            {
                strStartTime = (Common.Common.ReqStr("StartTime") == "") ? "" : Common.Common.ReqStr("StartTime");
                strEndTime = (Common.Common.ReqStr("EndTime") == "") ? "" : Common.Common.ReqStr("EndTime");
                strPayType = (Common.Common.ReqStr("PayType") == "") ? "-1" : Common.Common.ReqStr("PayType");
                txt_StartTime.Value = strStartTime;
                txt_EndTime.Value = strEndTime;
                hid_type.Value = strPayType;
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
                var commonModel = new CommonPageModel
                {
                    Condition = "  AND   1=1   " + str,
                    Currentpage = pageid,
                    Tablename = "ShopNum1_AdvancePaymentModifyLog",
                    Resultnum = "0",
                    PageSize = PageSize
                };
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
                DataTable table2 = action.SelectAdvPaymentModifyLog_List(commonModel);
                Rep_PayA_AdPayDetailList.DataSource = table2.DefaultView;
                Rep_PayA_AdPayDetailList.DataBind();
                int num = 0;
                string str3 = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_AdvancePaymentModifyLog", str);
                if (!string.IsNullOrEmpty(str3))
                {
                    num = Convert.ToInt32(str3);
                }
                lab_PayNum.Text = num.ToString();
                decimal num2 = 0M;
                string str2 = Common.Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", str);
                if (!string.IsNullOrEmpty(str2))
                {
                    num2 = Convert.ToDecimal(str2);
                }
                lab_PayDetail.Text = num2.ToString();
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
            if ((Operator.FormatToEmpty(strPayType) != string.Empty) && (Operator.FormatToEmpty(strPayType) != "-1"))
            {
                string_9 = string_9 + " AND OperateType=" + strPayType;
            }
            return string_9;
        }
    }
}
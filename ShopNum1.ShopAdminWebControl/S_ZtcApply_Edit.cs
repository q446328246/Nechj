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

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ZtcApply_Edit : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Button ButtonConfirm;
        private HiddenField HiddenFieldCode;
        private HiddenField HiddenFieldIsRight;
        private HiddenField HiddenFieldMoney;
        private HiddenField HiddenFieldSelectPrpductGuid;
        private HiddenField HiddenFieldSelectPrpductName;
        private Label LabelMoney;
        private TextBox TextBoxMoney;
        private TextBox TextBoxRemark;
        private TextBox TextBoxStartTime;
        private HtmlInputHidden hidWxPay;
        private string skinFilename = "S_ZtcApply_Edit.ascx";

        public S_ZtcApply_Edit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            CreateZtcApplyData();
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ZtcApply_List.aspx");
        }

        public void CreateZtcApplyData()
        {
            string str = string.Empty;
            string str2 = string.Empty;
            DataTable table =
                ((ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action()).SearchShopInfo(
                    base.MemLoginID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                str = table.Rows[0]["ShopID"].ToString();
                str2 = table.Rows[0]["ShopName"].ToString();
            }
            var action2 = (ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action();
            var ztcApply = new ShopNum1_ZtcApply
            {
                ApplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                AuditState = 0,
                AuditTime = Convert.ToDateTime("1900-1-1"),
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                CreateUser = base.MemLoginID,
                IsDeleted = 0,
                MemberID = base.MemLoginID,
                OperateRemark = "",
                OperateUser = "",
                PayState = 1,
                ProductGuid = new Guid(HiddenFieldSelectPrpductGuid.Value),
                ProductName = HiddenFieldSelectPrpductName.Value,
                Remark = TextBoxRemark.Text.Trim(),
                ShopID = str,
                ShopName = str2,
                StartTime = Convert.ToDateTime(TextBoxStartTime.Text.Trim()),
                Type = 0,
                Ztc_Money = Convert.ToDecimal(TextBoxMoney.Text.Trim())
            };
            if (action2.Add(ztcApply) > 0)
            {
                Yck();
                MessageBox.Show("申请成功，请等待审核！");
                HiddenFieldCode.Value = "0";
                HiddenFieldSelectPrpductGuid.Value = "0";
                HiddenFieldIsRight.Value = "0";
                HiddenFieldSelectPrpductName.Value = "";
                TextBoxMoney.Text = "";
                TextBoxStartTime.Text = "";
                TextBoxRemark.Text = "";
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelMoney = (Label) skin.FindControl("LabelMoney");
            HiddenFieldMoney = (HiddenField) skin.FindControl("HiddenFieldMoney");
            HiddenFieldSelectPrpductGuid = (HiddenField) skin.FindControl("HiddenFieldSelectPrpductGuid");
            TextBoxMoney = (TextBox) skin.FindControl("TextBoxMoney");
            TextBoxStartTime = (TextBox) skin.FindControl("TextBoxStartTime");
            TextBoxRemark = (TextBox) skin.FindControl("TextBoxRemark");
            HiddenFieldSelectPrpductName = (HiddenField) skin.FindControl("HiddenFieldSelectPrpductName");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            ButtonConfirm.Click += ButtonConfirm_Click;
            hidWxPay = (HtmlInputHidden) skin.FindControl("hidWxPay");
            HiddenFieldCode = (HiddenField) skin.FindControl("HiddenFieldCode");
            HiddenFieldIsRight = (HiddenField) skin.FindControl("HiddenFieldIsRight");
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            if (!Page.IsPostBack)
            {
                TextBoxMoney.Text = ShopSettings.GetValue("ZtcMoney");
                hidWxPay.Value = ShopSettings.GetValue("ZtcMoney");
            }
            DataTable table =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(
                    base.MemLoginID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                LabelMoney.Text = "当前拥有金币（BV）:￥" + table.Rows[0]["AdvancePayment"];
                HiddenFieldMoney.Value = table.Rows[0]["AdvancePayment"].ToString();
            }
        }

        public void Yck()
        {
            decimal num = 0M;
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = action.SearchByMemLoginID(base.MemLoginID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                num = Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString());
            }
            action.UpdateAdvancePayment(1, base.MemLoginID, Convert.ToDecimal(TextBoxMoney.Text.Trim()));
            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
            {
                Guid = Guid.NewGuid(),
                OperateType = 3,
                CurrentAdvancePayment = num,
                OperateMoney = Convert.ToDecimal(TextBoxMoney.Text.Trim()),
                LastOperateMoney = num - Convert.ToDecimal(TextBoxMoney.Text.Trim()),
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Memo = "申请直通车支付金币（BV）￥" + TextBoxMoney.Text.Trim(),
                MemLoginID = base.MemLoginID,
                CreateUser = base.MemLoginID,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsDeleted = 0
            };
            ((ShopNum1_AdvancePaymentModifyLog_Action) LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action())
                .OperateMoney(advancePaymentModifyLog);
        }
    }
}
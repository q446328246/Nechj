using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_EnsureApplyRecordOperate : BaseShopWebControl
    {
        private HtmlAnchor GoPayPwd;
        private Button btn_Back;
        private Button btn_Sumbit;
        private HtmlInputHidden hid_payText;
        private HtmlInputHidden hid_payValue;
        private Label lab_EnsureName;
        private HtmlSelect sel_PayMent;
        private string skinFilename = "S_EnsureApplyRecordOperate.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private HtmlInputText txt_AdvPayMent;
        private HtmlInputText txt_EnsureMoney;
        private HtmlInputText txt_Remark;

        public S_EnsureApplyRecordOperate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txt_EnsureMoney.Value) > Convert.ToDecimal(txt_AdvPayMent.Value))
            {
                MessageBox.Show("金币（BV）不足，请充值");
            }
            else
            {
                var action2 = (Shop_Ensure_Action) LogicFactory.CreateShop_Ensure_Action();
                var applyEnsure = new ShopNum1_Shop_ApplyEnsure
                {
                    Guid = Guid.NewGuid(),
                    EnsureID = int.Parse(string_2),
                    ApplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    CreateUser = base.MemLoginID,
                    ShopID = base.MemLoginID,
                    IsPayMent = 1,
                    Remarks = txt_Remark.Value,
                    PaymentName = hid_payText.Value,
                    PaymentType = new Guid("9cf4b176-8ade-4211-878c-7b753c69450a"),
                    MemberLoginID = base.MemLoginID,
                    IsAudit = 1
                };
                if (action2.ApplyShopEnsure(applyEnsure) > 0)
                {
                    decimal num2 = 0M;
                    string str = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member",
                        "   AND    MemLoginID ='" + base.MemLoginID + "'    ");
                    if (!string.IsNullOrEmpty(str))
                    {
                        num2 = Convert.ToDecimal(str);
                    }
                    decimal num = Convert.ToDecimal(txt_EnsureMoney.Value);
                    if (num > 0M)
                    {
                        var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                        {
                            Guid = Guid.NewGuid(),
                            OperateType = 3,
                            CurrentAdvancePayment = num2,
                            OperateMoney = num,
                            LastOperateMoney = Convert.ToDecimal(num2) - num,
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            Memo = "申请店铺担保",
                            MemLoginID = base.MemLoginID,
                            CreateUser = base.MemLoginID,
                            CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            IsDeleted = 0
                        };
                        ((ShopNum1_AdvancePaymentModifyLog_Action)
                            Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                                advancePaymentModifyLog);
                    }
                    Page.Response.Redirect("S_EnsureApplyRecordList.aspx");
                }
                else
                {
                    MessageBox.Show("购买失败！");
                }
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_EnsureApplyRecordList.aspx");
        }

        protected void DateBind()
        {
            DataTable shopEnsure =
                ((Shop_Ensure_Action) LogicFactory.CreateShop_Ensure_Action()).GetShopEnsure(int.Parse(string_2));
            if ((shopEnsure != null) && (shopEnsure.Rows.Count > 0))
            {
                lab_EnsureName.Text = shopEnsure.Rows[0]["Name"].ToString();
                txt_EnsureMoney.Value = shopEnsure.Rows[0]["EnsureMoney"].ToString();
            }
            DataTable table2 =
                ((ShopNum1_Member_Action) Factory.LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(
                    base.MemLoginID);
            txt_AdvPayMent.Value = table2.Rows[0]["AdvancePayment"].ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            GoPayPwd = (HtmlAnchor) skin.FindControl("GoPayPwd");
            if (
                string.IsNullOrEmpty(Common.Common.GetNameById("PayPwd", "ShopNum1_Member",
                    "  AND  MemLoginID='" + base.MemLoginID + "'  ")))
            {
                GoPayPwd.Visible = true;
            }
            else
            {
                GoPayPwd.Visible = false;
            }
            lab_EnsureName = (Label) skin.FindControl("lab_EnsureName");
            txt_AdvPayMent = (HtmlInputText) skin.FindControl("txt_AdvPayMent");
            txt_EnsureMoney = (HtmlInputText) skin.FindControl("txt_EnsureMoney");
            txt_Remark = (HtmlInputText) skin.FindControl("txt_Remark");
            sel_PayMent = (HtmlSelect) skin.FindControl("sel_PayMent");
            hid_payValue = (HtmlInputHidden) skin.FindControl("hid_payValue");
            hid_payText = (HtmlInputHidden) skin.FindControl("hid_payText");
            btn_Back = (Button) skin.FindControl("btn_Back");
            btn_Back.Click += btn_Back_Click;
            btn_Sumbit = (Button) skin.FindControl("btn_Sumbit");
            btn_Sumbit.Click += btn_Sumbit_Click;
            string_2 = (Common.Common.ReqStr("id") == "0") ? "0" : Common.Common.ReqStr("id");
            string_1 = (Common.Common.ReqStr("guid") == "null") ? "0" : Common.Common.ReqStr("Guid");
            string_3 = (Common.Common.ReqStr("type") == null) ? "" : Common.Common.ReqStr("type");
            string_4 = Encryption.GetMd5Hash(string_3);
            DateBind();
        }
    }
}
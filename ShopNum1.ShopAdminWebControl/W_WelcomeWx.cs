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
    public class W_WelcomeWx : BaseShopWebControl
    {
        private HtmlAnchor Apaypwdalink;
        private Button BtnPay;
        private HtmlInputHidden hidDepartTime;
        private HtmlInputHidden hidEndTime;
        private HtmlInputHidden hidIsTip;
        private HtmlInputHidden hidMyShouldPay;
        private HtmlInputHidden hidOpenTime;
        private HtmlInputHidden hidPayTime;
        private HtmlInputHidden hidShowWeiXin;
        private HtmlInputHidden hidWxPayMoney;
        private Label lblIsHavePayPwd;
        private string skinFilename = "W_WelcomeWx.ascx";

        public W_WelcomeWx()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void BindWx()
        {
            DataTable table = Common.Common.GetTableById("IsWeixin,wOpenTime,wEndTime,wDepartTime,wPayMoney",
                "shopnum1_shopinfo",
                " And memloginId='" + base.MemLoginID + "'");
            if (table.Rows.Count <= 0)
            {
                return;
            }
            hidShowWeiXin.Value = table.Rows[0]["IsWeixin"].ToString();
            hidOpenTime.Value = table.Rows[0]["wOpenTime"].ToString();
            hidEndTime.Value = table.Rows[0]["wEndTime"].ToString();
            string str = table.Rows[0]["wDepartTime"].ToString();
            hidDepartTime.Value = str;
            string str2 = str;
            switch (str2)
            {
                case null:
                    break;

                case "1":
                    hidPayTime.Value = "1个月";
                    goto Label_0188;

                case "3":
                    hidPayTime.Value = "3个月";
                    goto Label_0188;

                case "6":
                    hidPayTime.Value = "6个月";
                    goto Label_0188;

                default:
                    if (!(str2 == "12"))
                    {
                        if (!(str2 == "24"))
                        {
                            break;
                        }
                        hidPayTime.Value = "2年";
                    }
                    else
                    {
                        hidPayTime.Value = "1年";
                    }
                    goto Label_0188;
            }
            hidPayTime.Value = "1年";
            Label_0188:
            if (hidShowWeiXin.Value == "1")
            {
                if (hidEndTime.Value != "")
                {
                    if (Convert.ToDateTime(hidEndTime.Value).AddMonths(-1) < DateTime.Now.ToLocalTime())
                    {
                        hidIsTip.Value = "1";
                    }
                }
                else
                {
                    hidIsTip.Value = "0";
                }
            }
            else
            {
                hidIsTip.Value = "3";
            }
            string str3 = Common.Common.GetNameById("cast(advancepayment as varchar(20))+'|'+isnull(paypwd,0)",
                "shopnum1_member", " And memloginId='" + base.MemLoginID + "'");
            hidMyShouldPay.Value = str3.Split(new[] {'|'})[0];
            if (str3.Split(new[] {'|'})[1] == "0")
            {
                lblIsHavePayPwd.Visible = true;
                Apaypwdalink.Visible = true;
            }
            string str4 = table.Rows[0]["wPayMoney"].ToString();
            if (str4 == "")
            {
                str4 = ShopSettings.GetValue("WxPayMoney");
            }
            hidWxPayMoney.Value = str4;
        }

        protected void BtnPay_Click(object sender, EventArgs e)
        {
            string str = hidShowWeiXin.Value;
            decimal num = 0M;
            decimal num2 = Convert.ToDecimal(hidWxPayMoney.Value);
            if (!string.IsNullOrEmpty(hidMyShouldPay.Value))
            {
                num = Convert.ToDecimal(hidMyShouldPay.Value);
            }
            if (num < num2)
            {
                MessageBox.Show("金币（BV）不足，请及时充值！");
            }
            else
            {
                var action =
                    (ShopNum1_AdvancePaymentModifyLog_Action)
                        LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 3,
                    CurrentAdvancePayment = num,
                    OperateMoney = num2,
                    LastOperateMoney = Convert.ToDecimal(num) - num2,
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).ToLocalTime(),
                    MemLoginID = base.MemLoginID,
                    CreateUser = base.MemLoginID,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).ToLocalTime(),
                    IsDeleted = 0
                };
                int months = 12;
                try
                {
                    months = Convert.ToInt32(hidDepartTime.Value);
                }
                catch
                {
                }
                if ((str == "0") || (str == ""))
                {
                    Common.Common.UpdateInfo(
                        string.Concat(new object[]
                        {
                            "isWeixin=1,wopentime='", DateTime.Now.ToLocalTime(), "',wEndTime='",
                            DateTime.Now.ToLocalTime().AddMonths(months), "'"
                        }), "shopnum1_shopinfo",
                        " And memloginId='" + base.MemLoginID + "'");
                    advancePaymentModifyLog.Memo = "微信商城功能开启成功";
                    action.OperateMoney(advancePaymentModifyLog);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"pop",
                        "<script>alert('微信商城功能开启成功！');window.parent.location.href='s_index.aspx';</script>");
                }
                else
                {
                    Common.Common.UpdateInfo("wEndTime='" + DateTime.Now.ToLocalTime().AddMonths(12) + "'",
                        "shopnum1_shopinfo", " And memloginId='" + base.MemLoginID + "'");
                    advancePaymentModifyLog.Memo = "微信商城功能续费成功";
                    action.OperateMoney(advancePaymentModifyLog);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"pop",
                        "<script>alert('微信商城功能续费成功！');location.href='W_WelcomeWX.aspx';</script>");
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            hidShowWeiXin = (HtmlInputHidden) skin.FindControl("hidShowWeiXin");
            hidOpenTime = (HtmlInputHidden) skin.FindControl("hidOpenTime");
            hidEndTime = (HtmlInputHidden) skin.FindControl("hidEndTime");
            hidIsTip = (HtmlInputHidden) skin.FindControl("hidIsTip");
            hidWxPayMoney = (HtmlInputHidden) skin.FindControl("hidWxPayMoney");
            hidPayTime = (HtmlInputHidden) skin.FindControl("hidPayTime");
            hidDepartTime = (HtmlInputHidden) skin.FindControl("hidDepartTime");
            hidMyShouldPay = (HtmlInputHidden) skin.FindControl("hidMyShouldPay");
            lblIsHavePayPwd = (Label) skin.FindControl("lblIsHavePayPwd");
            Apaypwdalink = (HtmlAnchor) skin.FindControl("Apaypwdalink");
            BtnPay = (Button) skin.FindControl("BtnPay");
            BtnPay.Click += BtnPay_Click;
            if (!Page.IsPostBack)
            {
                BindWx();
            }
        }
    }
}
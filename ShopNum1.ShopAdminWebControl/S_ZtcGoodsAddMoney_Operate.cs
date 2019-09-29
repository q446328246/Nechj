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
    public class S_ZtcGoodsAddMoney_Operate : BaseShopWebControl
    {
        private Button ButtonAddMoney;
        private Button ButtonBackList;
        private Button ButtonPay;
        private HiddenField HiddenFieldMyMoney;
        private Image ImageProduct;
        private Label LabelIsHavePayPwd;
        private Label LabelShowState;
        private Label LabelYue;
        private Label LabelZtcMoneyShow;
        private Label LabelZtcName;
        private TextBox TextBoxAddMoney;
        private HtmlAnchor paypwdalink;
        private string skinFilename = "S_ZtcGoodsAddMoney_Operate.ascx";

        public S_ZtcGoodsAddMoney_Operate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonAddMoney_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ZtcGoods_List.aspx");
        }

        protected void ButtonPay_Click(object sender, EventArgs e)
        {
            decimal result = 0M;
            if (!decimal.TryParse(TextBoxAddMoney.Text.Trim(), out result))
            {
                MessageBox.Show("输入格式错误！");
            }
            else
            {
                var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                DataTable table = action2.SearchByMemLoginID(base.MemLoginID);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    result = Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString());
                }
                if (Convert.ToDecimal(TextBoxAddMoney.Text.Trim()) > result)
                {
                    MessageBox.Show("金币（BV）不足！");
                }
                else
                {
                    try
                    {
                        var action = (ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action();
                        if (
                            action.UpdateAddMoney(Page.Request.QueryString["ID"].Replace("'", ""),
                                Convert.ToDecimal(TextBoxAddMoney.Text.Trim())) > 0)
                        {
                            action2.UpdateAdvancePayment(1, base.MemLoginID,
                                Convert.ToDecimal(TextBoxAddMoney.Text.Trim()));
                            var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                            {
                                Guid = Guid.NewGuid(),
                                OperateType = 3,
                                CurrentAdvancePayment = result,
                                OperateMoney = Convert.ToDecimal(TextBoxAddMoney.Text.Trim()),
                                LastOperateMoney = result - Convert.ToDecimal(TextBoxAddMoney.Text.Trim()),
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                Memo = "续费直通车支付金币（BV）￥" + TextBoxAddMoney.Text.Trim(),
                                MemLoginID = base.MemLoginID,
                                CreateUser = base.MemLoginID,
                                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                IsDeleted = 0
                            };
                            ((ShopNum1_AdvancePaymentModifyLog_Action)
                                LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                                    advancePaymentModifyLog);
                            string g = string.Empty;
                            string shopNameAndID = string.Empty;
                            string str3 = string.Empty;
                            string str4 = string.Empty;
                            DataTable infoByGuid = action.GetInfoByGuid(Page.Request.QueryString["ID"]);
                            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
                            {
                                g = infoByGuid.Rows[0]["ProductGuid"].ToString();
                                shopNameAndID = GetShopNameAndID(infoByGuid.Rows[0]["MemberID"].ToString(), 1);
                                str3 = GetShopNameAndID(infoByGuid.Rows[0]["MemberID"].ToString(), 2);
                                str4 = infoByGuid.Rows[0]["StartTime"].ToString();
                            }
                            var action4 = (ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action();
                            var ztcApply = new ShopNum1_ZtcApply
                            {
                                ApplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                AuditState = 1,
                                AuditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                CreateUser = base.MemLoginID,
                                IsDeleted = 0,
                                MemberID = base.MemLoginID,
                                OperateRemark = "续费",
                                OperateUser = "",
                                PayState = 1,
                                ProductGuid = new Guid(g),
                                ProductName = LabelZtcName.Text,
                                Remark = "续费",
                                ShopID = shopNameAndID,
                                ShopName = str3,
                                StartTime = Convert.ToDateTime(str4),
                                Type = 1,
                                Ztc_Money = Convert.ToDecimal(TextBoxAddMoney.Text.Trim())
                            };
                            if (action4.Add(ztcApply) > 0)
                            {
                                MessageBox.Show("充值成功！");
                                GetDataByID(Page.Request.QueryString["ID"]);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("充值失败！错误：" + exception.Message);
                    }
                }
            }
        }

        public void GetDataByID(string ID)
        {
            DataTable infoByGuid =
                ((ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action()).GetInfoByGuid(ID);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                LabelZtcName.Text = infoByGuid.Rows[0]["ZtcName"].ToString();
                ImageProduct.ImageUrl = infoByGuid.Rows[0]["ZtcImg"].ToString();
                LabelZtcMoneyShow.Text = infoByGuid.Rows[0]["Ztc_Money"].ToString();
                LabelShowState.Text = GetDay(Convert.ToDecimal(infoByGuid.Rows[0]["Ztc_Money"].ToString()));
            }
        }

        public string GetDay(decimal Ztc_Money)
        {
            decimal num = Convert.ToDecimal(ShopSettings.GetValue("ZtcMoney"));
            if (num > Ztc_Money)
            {
                return "余额不足";
            }
            decimal num3 = Ztc_Money%num;
            if ((num3 != 0M) && ((Convert.ToDouble(num3)/Convert.ToDouble(num)) > 0.5))
            {
                int num2 = Convert.ToInt32((Ztc_Money/num)) - 1;
                return ("余额还可使用" + num2 + "天");
            }
            return ("余额还可使用" + Convert.ToInt32((Ztc_Money/num)) + "天");
        }

        public string GetShopNameAndID(string MemberID, int typeid)
        {
            string str = string.Empty;
            DataTable table =
                ((ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action()).SearchShopInfo(
                    base.MemLoginID);
            string str2 = "";
            string str3 = "";
            if ((table != null) && (table.Rows.Count > 0))
            {
                str2 = table.Rows[0]["ShopID"].ToString();
                str3 = table.Rows[0]["ShopName"].ToString();
            }
            if (typeid == 1)
            {
                return str2;
            }
            if (typeid == 2)
            {
                str = str3;
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            HiddenFieldMyMoney = (HiddenField) skin.FindControl("HiddenFieldMyMoney");
            LabelYue = (Label) skin.FindControl("LabelYue");
            LabelIsHavePayPwd = (Label) skin.FindControl("LabelIsHavePayPwd");
            paypwdalink = (HtmlAnchor) skin.FindControl("paypwdalink");
            ButtonPay = (Button) skin.FindControl("ButtonPay");
            ButtonPay.Click += ButtonPay_Click;
            LabelZtcName = (Label) skin.FindControl("LabelZtcName");
            ImageProduct = (Image) skin.FindControl("ImageProduct");
            LabelZtcMoneyShow = (Label) skin.FindControl("LabelZtcMoneyShow");
            LabelShowState = (Label) skin.FindControl("LabelShowState");
            ButtonAddMoney = (Button) skin.FindControl("ButtonAddMoney");
            ButtonAddMoney.Click += ButtonAddMoney_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            TextBoxAddMoney = (TextBox) skin.FindControl("TextBoxAddMoney");
            if (Page.Request.QueryString["ID"] != null)
            {
                GetDataByID(Page.Request.QueryString["ID"]);
            }
            string str = Common.Common.GetNameById("PayPwd", "ShopNum1_Member",
                "  and  MemLoginID='" + base.MemLoginID + "'");
            string str2 = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member",
                "  and  MemLoginID='" + base.MemLoginID + "'");
            LabelYue.Text = "您当前的金币（BV）余额为：￥" + str2;
            HiddenFieldMyMoney.Value = str2;
            if (string.IsNullOrEmpty(str))
            {
                LabelIsHavePayPwd.Visible = true;
                paypwdalink.Visible = true;
                ButtonPay.Enabled = false;
            }
        }
    }
}
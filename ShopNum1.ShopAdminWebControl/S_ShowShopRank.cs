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
    public class S_ShowShopRank : BaseShopWebControl
    {
        private Button ButtonPay;
        private HiddenField HiddenFieldPayType;
        private HiddenField HiddenFieldRankGuid;
        private Label LabelYue;
        private Label lblNotifacate;
        private Repeater RepeaterShow;
        private Label label_1;
        private HtmlAnchor paypwdalink;
        private string skinFilename = "S_ShowShopRank.ascx";

        public S_ShowShopRank()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonPay_Click(object sender, EventArgs e)
        {
            var action1 = (Shop_Rank_Action) LogicFactory.CreateShop_Rank_Action();
            DataTable table = Common.Common.GetTableById("*", "ShopNum1_ShopRank",
                " AND  Guid='" + HiddenFieldRankGuid.Value + "'   ");
            decimal price = 0M;
            string rankName = string.Empty;
            if ((table != null) && (table.Rows.Count > 0))
            {
                price = Convert.ToDecimal(table.Rows[0]["price"].ToString());
                rankName = table.Rows[0]["Name"].ToString();
                decimal advancePayment = 0M;
                string str2 = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member",
                    " AND  MemLoginID='" + base.MemLoginID + "'   ");
                if (!string.IsNullOrEmpty(str2))
                {
                    advancePayment = Convert.ToDecimal(str2);
                }
                if (advancePayment < price)
                {
                    MessageBox.Show("金币（BV）不足，请及时充值！");
                }
                else
                {
                    if (HiddenFieldPayType.Value == "升级")
                    {
                        GoUp(price, rankName, advancePayment);
                    }
                    else if (HiddenFieldPayType.Value == "续费")
                    {
                        GoOn(price, advancePayment);
                    }
                    HiddenFieldRankGuid.Value = "";
                    HiddenFieldPayType.Value = "";
                    GetData();
                }
            }
        }

        public void GetData()
        {
            string str = Common.Common.GetNameById("PayPwd", "ShopNum1_Member",
                "  and  MemLoginID='" + base.MemLoginID + "'");
            string str2 = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member",
                "  and  MemLoginID='" + base.MemLoginID + "'");
            LabelYue.Text = "您当前的金币（BV）余额为：￥" + str2;
            if (string.IsNullOrEmpty(str))
            {
                label_1.Visible = true;
                paypwdalink.Visible = true;
                ButtonPay.Enabled = false;
                lblNotifacate.Visible = true;
            }
            DataTable table = ((Shop_Rank_Action) LogicFactory.CreateShop_Rank_Action()).Search(0);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        public bool GetNowLV(string guid)
        {
            DataTable dataInfoByMemLoginID =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetDataInfoByMemLoginID(
                    base.MemLoginID);
            string str = string.Empty;
            if ((dataInfoByMemLoginID != null) && (dataInfoByMemLoginID.Rows.Count > 0))
            {
                str = dataInfoByMemLoginID.Rows[0]["ShopRank"].ToString();
            }
            return (guid == str);
        }

        public void GoOn(decimal price, decimal AdvancePayment)
        {
            DateTime time2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var action = (Shop_ShopApplyRank_Action) LogicFactory.CreateShop_ShopApplyRank_Action();
            DataTable nowLv = action.GetNowLv(base.MemLoginID);
            if ((nowLv != null) && (nowLv.Rows.Count > 0))
            {
                time2 = Convert.ToDateTime(nowLv.Rows[0]["VerifyTime"].ToString());
            }
            DateTime time3 = time2.AddYears(1);
            try
            {
                if (action.UpdataVerifyTime(time3.ToString(), base.MemLoginID) > 0)
                {
                    try
                    {
                        ((ShopNum1_Member_Action) Factory.LogicFactory.CreateShopNum1_Member_Action())
                            .UpdateAdvancePayment(1, base.MemLoginID, price);
                    }
                    catch (Exception)
                    {
                    }
                    var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                    {
                        Guid = Guid.NewGuid(),
                        OperateType = 3,
                        CurrentAdvancePayment = AdvancePayment,
                        OperateMoney = price,
                        LastOperateMoney = Convert.ToDecimal(AdvancePayment) - price,
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Memo = "续费店铺等级",
                        MemLoginID = base.MemLoginID,
                        CreateUser = base.MemLoginID,
                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        IsDeleted = 0
                    };
                    ((ShopNum1_AdvancePaymentModifyLog_Action)
                        Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                            advancePaymentModifyLog);
                    MessageBox.Show(
                        string.Concat(new object[] {"续费成功！(本次续费，共花费金币（BV）", price, "元，续费期限延至", time3.ToString(), ")"}));
                }
            }
            catch (Exception)
            {
            }
        }

        public void GoUp(decimal price, string RankName, decimal AdvancePayment)
        {
            var action = (Shop_ShopApplyRank_Action) LogicFactory.CreateShop_ShopApplyRank_Action();
            var rank = new ShopNum1_Shop_ApplyShopRank
            {
                ApplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsAudit = 1,
                MemberLoginID = base.MemLoginID,
                IsPayMent = 1,
                PaymentName = "金币（BV）支付",
                PaymentType = new Guid("385c9c54-2b58-4b65-8ea9-f01872126715"),
                RankGuid = new Guid(HiddenFieldRankGuid.Value),
                VerifyTime = DateTime.Now.AddYears(1),
                RankName = RankName
            };
            try
            {
                action.Add(rank);
                try
                {
                    action.DeleteOutRankGuid(HiddenFieldRankGuid.Value, base.MemLoginID);
                }
                catch (Exception)
                {
                }
                try
                {
                    action.UpdataShopRank(HiddenFieldRankGuid.Value, base.MemLoginID);
                }
                catch (Exception)
                {
                }
                try
                {
                    ((ShopNum1_Member_Action) Factory.LogicFactory.CreateShopNum1_Member_Action()).UpdateAdvancePayment(
                        1, base.MemLoginID, price);
                }
                catch (Exception)
                {
                }
                var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                {
                    Guid = Guid.NewGuid(),
                    OperateType = 3,
                    CurrentAdvancePayment = AdvancePayment,
                    OperateMoney = price,
                    LastOperateMoney = Convert.ToDecimal(AdvancePayment) - price,
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Memo = "升级店铺等级",
                    MemLoginID = base.MemLoginID,
                    CreateUser = base.MemLoginID,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                ((ShopNum1_AdvancePaymentModifyLog_Action)
                    Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoney(
                        advancePaymentModifyLog);
                MessageBox.Show("升级成功！");
                GetData();
            }
            catch (Exception)
            {
                MessageBox.Show("升级失败！");
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            HiddenFieldRankGuid = (HiddenField) skin.FindControl("HiddenFieldRankGuid");
            ButtonPay = (Button) skin.FindControl("ButtonPay");
            ButtonPay.Click += ButtonPay_Click;
            HiddenFieldPayType = (HiddenField) skin.FindControl("HiddenFieldPayType");
            LabelYue = (Label) skin.FindControl("LabelYue");
            label_1 = (Label) skin.FindControl("LabelIsHavePayPwd");
            paypwdalink = (HtmlAnchor) skin.FindControl("paypwdalink");
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            lblNotifacate = (Label)skin.FindControl("lblNotifacate");
            RepeaterShow.ItemDataBound += RepeaterShow_ItemDataBound;
            GetData();
        }

        public bool lvCompare(string guid)
        {
            int num = -1;
            int num2 = 0;
            var action = (Shop_Rank_Action) LogicFactory.CreateShop_Rank_Action();
            DataTable dataInfoByMemLoginID =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetDataInfoByMemLoginID(
                    base.MemLoginID);
            string str = string.Empty;
            if ((dataInfoByMemLoginID != null) && (dataInfoByMemLoginID.Rows.Count > 0))
            {
                str = dataInfoByMemLoginID.Rows[0]["ShopRank"].ToString();
            }
            DataTable table3 = action.Search("'" + str + "'", 0);
            if ((table3 != null) && (table3.Rows.Count > 0))
            {
                num = Convert.ToInt32(table3.Rows[0]["RankValue"].ToString());
            }
            DataTable table2 = action.Search("'" + guid + "'", 0);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                num2 = Convert.ToInt32(table2.Rows[0]["RankValue"].ToString());
            }
            if (num >= num2)
            {
                return false;
            }
            return true;
        }

        protected void RepeaterShow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldGuid");
                var field2 = (HiddenField) e.Item.FindControl("HiddenFieldIsDefault");
                var label = (Label) e.Item.FindControl("LabelShopTemplateCount");
                var button = (Button) e.Item.FindControl("ButtonPayGoOn");
                string text = label.Text;
                string str2 = "0";
                if (!string.IsNullOrEmpty(text))
                {
                    str2 = text.Split(new[] {','}).Length.ToString();
                }
                label.Text = str2;
                var button2 = (Button) e.Item.FindControl("runbutton");
                if (!lvCompare(field.Value))
                {
                    button2.Visible = false;
                }
                var cell = (HtmlTableCell) e.Item.FindControl("TdName");
                if (GetNowLV(field.Value))
                {
                    cell.Attributes["Class"] = "addOnline";
                    button.Visible = true;
                }
                if (field2.Value == "0")
                {
                    button2.Visible = false;
                    button.Visible = false;
                }
            }
        }
    }
}
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ZtcGoods_Operate : BaseMemberWebControl
    {
        private Button ButtonAddMoney;
        private Button ButtonBackList;
        private Button ButtonConfirm;
        private Image ImageProduct;
        private Label LabelCreateTime;
        private Label LabelShowState;
        private Label LabelStartTime;
        private Label LabelState;
        private Label LabelZtcMoneyShow;
        private TextBox TextBoxOrganizImg;
        private TextBox TextBoxSellCount;
        private TextBox TextBoxSellPrice;
        private TextBox TextBoxZtcName;
        private string skinFilename = "S_ZtcGoods_Operate.ascx";

        public S_ZtcGoods_Operate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action();
            int result = 0;
            decimal num2 = 0M;
            if (!int.TryParse(TextBoxSellCount.Text.Trim(), out result))
            {
                MessageBox.Show("销售数量格式有误！");
            }
            else if (!decimal.TryParse(TextBoxSellPrice.Text.Trim(), out num2))
            {
                MessageBox.Show("销售价格格式有误！");
            }
            else
            {
                try
                {
                    if (
                        action.Update(Page.Request.QueryString["ID"].Replace("'", ""), TextBoxZtcName.Text.Trim(),
                            TextBoxOrganizImg.Text.Trim(), TextBoxSellPrice.Text.Trim(),
                            TextBoxSellCount.Text.Trim()) > 0)
                    {
                        MessageBox.Show("编辑成功！");
                        GetDataByID(Page.Request.QueryString["ID"]);
                    }
                    else
                    {
                        MessageBox.Show("编辑失败！");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("编辑失败！原因：" + exception.Message);
                }
            }
        }

        protected void ButtonAddMoney_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ZtcGoods_List.aspx");
        }

        public void GetDataByID(string ID)
        {
            DataTable infoByGuid =
                ((ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action()).GetInfoByGuid(ID);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                TextBoxZtcName.Text = infoByGuid.Rows[0]["ZtcName"].ToString();
                ImageProduct.ImageUrl = infoByGuid.Rows[0]["ZtcImg"].ToString();
                TextBoxOrganizImg.Text = infoByGuid.Rows[0]["ZtcImg"].ToString();
                TextBoxSellPrice.Text = infoByGuid.Rows[0]["SellPrice"].ToString();
                TextBoxSellCount.Text = infoByGuid.Rows[0]["SellCount"].ToString();
                LabelZtcMoneyShow.Text = infoByGuid.Rows[0]["Ztc_Money"].ToString();
                LabelStartTime.Text = infoByGuid.Rows[0]["StartTime"].ToString();
                LabelCreateTime.Text = infoByGuid.Rows[0]["CreateTime"].ToString();
                if (infoByGuid.Rows[0]["State"].ToString() == "0")
                {
                    LabelState.Text = "关闭";
                }
                else if (infoByGuid.Rows[0]["State"].ToString() == "1")
                {
                    LabelState.Text = "开启";
                }
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

        protected override void InitializeSkin(Control skin)
        {
            TextBoxZtcName = (TextBox) skin.FindControl("TextBoxZtcName");
            ImageProduct = (Image) skin.FindControl("ImageProduct");
            TextBoxSellPrice = (TextBox) skin.FindControl("TextBoxSellPrice");
            TextBoxSellCount = (TextBox) skin.FindControl("TextBoxSellCount");
            LabelZtcMoneyShow = (Label) skin.FindControl("LabelZtcMoneyShow");
            LabelStartTime = (Label) skin.FindControl("LabelStartTime");
            LabelCreateTime = (Label) skin.FindControl("LabelCreateTime");
            LabelState = (Label) skin.FindControl("LabelState");
            LabelShowState = (Label) skin.FindControl("LabelShowState");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            ButtonConfirm.Click += ButtonConfirm_Click;
            ButtonAddMoney = (Button) skin.FindControl("ButtonAddMoney");
            ButtonAddMoney.Click += ButtonAddMoney_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            TextBoxOrganizImg = (TextBox) skin.FindControl("TextBoxOrganizImg");
            if (Page.Request.QueryString["ID"] != null)
            {
                GetDataByID(Page.Request.QueryString["ID"]);
            }
        }
    }
}
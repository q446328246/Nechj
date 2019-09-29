using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OrderScore_Operate : PageBase, IRequiresSessionState
    {
        public void BindOrderMessage()
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            DataTable infoByGuid = action.GetInfoByGuid(hiddenFieldGuid.Value);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                LabelShopIDValue.Text = infoByGuid.Rows[0]["ShopMemLoginID"].ToString();
                LabelOrderNumberValue.Text = infoByGuid.Rows[0]["OrderNumber"].ToString();
                LabelMemLoginIDValue.Text = infoByGuid.Rows[0]["MemLoginID"].ToString();
                LabelShopNameValue.Text = GetShopName(infoByGuid.Rows[0]["ShopMemLoginID"].ToString());
                if (infoByGuid.Rows[0]["OderStatus"].ToString() == "1")
                {
                    LabelOderStatusValue.Text = "已处理";
                }
                else
                {
                    LabelOderStatusValue.Text = "未处理";
                }
                LabelCreateTimeValue.Text = infoByGuid.Rows[0]["CreateTime"].ToString();
                if (Convert.ToDateTime(infoByGuid.Rows[0]["ConfirmTime"].ToString()) == Convert.ToDateTime("1900-1-1"))
                {
                    LabelConfirmTimeValue.Text = "未处理";
                }
                else
                {
                    LabelConfirmTimeValue.Text = infoByGuid.Rows[0]["ConfirmTime"].ToString();
                }
                LabelTotalScoreValue.Text = infoByGuid.Rows[0]["TotalScore"].ToString();
                LabelNameValue.Text = infoByGuid.Rows[0]["Name"].ToString();
                LabelEmailValue.Text = infoByGuid.Rows[0]["Email"].ToString();
                string str2 = string.Empty;
                string str3 = string.Empty;
                string str4 = string.Empty;
                if (!string.IsNullOrEmpty(infoByGuid.Rows[0]["Address"].ToString()))
                {
                    DataTable table2;
                    DataTable adressNameByCode;
                    string[] strArray = infoByGuid.Rows[0]["Address"].ToString().Split(new[] {'|'});
                    if (strArray.Length > 0)
                    {
                        str2 = strArray[0];
                        str3 = strArray[1];
                    }
                    string code = string.Empty;
                    if (!string.IsNullOrEmpty(str2))
                    {
                        string[] strArray2 = str2.Split(new[] {'/'});
                        if (strArray2.Length > 0)
                        {
                            code = strArray2[0];
                        }
                    }
                    if (code.Length == 9)
                    {
                        adressNameByCode = action.GetAdressNameByCode(code.Substring(0, 3));
                        if ((adressNameByCode != null) && (adressNameByCode.Rows.Count > 0))
                        {
                            str4 = str4 + adressNameByCode.Rows[0]["Name"];
                        }
                        DataTable table3 = action.GetAdressNameByCode(code.Substring(0, 6));
                        if ((table3 != null) && (table3.Rows.Count > 0))
                        {
                            str4 = str4 + table3.Rows[0]["Name"];
                        }
                        table2 = action.GetAdressNameByCode(code);
                        if ((table2 != null) && (table2.Rows.Count > 0))
                        {
                            str4 = str4 + table2.Rows[0]["Name"];
                        }
                    }
                    else if (code.Length == 6)
                    {
                        adressNameByCode = action.GetAdressNameByCode(code.Substring(0, 3));
                        if ((adressNameByCode != null) && (adressNameByCode.Rows.Count > 0))
                        {
                            str4 = str4 + adressNameByCode.Rows[0]["Name"];
                        }
                        table2 = action.GetAdressNameByCode(code);
                        if ((table2 != null) && (table2.Rows.Count > 0))
                        {
                            str4 = str4 + table2.Rows[0]["Name"];
                        }
                    }
                    else if (code.Length == 3)
                    {
                        table2 = action.GetAdressNameByCode(code);
                        if ((table2 != null) && (table2.Rows.Count > 0))
                        {
                            str4 = str4 + table2.Rows[0]["Name"];
                        }
                    }
                }
                LabelAddressValue.Text = str4 + str3;
                LabelPostalcodeValue.Text = infoByGuid.Rows[0]["Postalcode"].ToString();
                LabelMobileValue.Text = infoByGuid.Rows[0]["Mobile"].ToString();
            }
        }

        public void BindProduct(string OrderNumber)
        {
            DataTable productByOrderNumber =
                ((ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action())
                    .GetProductByOrderNumber(OrderNumber);
            if ((productByOrderNumber != null) && (productByOrderNumber.Rows.Count > 0))
            {
                RepeaterData.DataSource = productByOrderNumber.DefaultView;
                RepeaterData.DataBind();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OrderScore_List.aspx");
        }

        protected void ButtonOderStatus_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            try
            {
                if (action.ChangeOderStatus(hiddenFieldGuid.Value, "1") > 0)
                {
                    BindOrderMessage();
                    MessageBox.Show("处理成功，请及时发货！");
                    if (LabelOderStatusValue.Text == "已处理")
                    {
                        ButtonOderStatus.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("操作失败！");
            }
        }

        public string GetShopName(string user)
        {
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(user);
            if ((memLoginInfo != null) && (memLoginInfo.Rows.Count > 0))
            {
                return memLoginInfo.Rows[0]["ShopName"].ToString();
            }
            return "店铺已经不存在了";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                if (base.Request.QueryString["guid"] != null)
                {
                    hiddenFieldGuid.Value = base.Request.QueryString["guid"];
                }
                BindOrderMessage();
                if (base.Request.QueryString["OrderNumber"] != null)
                {
                    BindProduct(base.Request.QueryString["OrderNumber"]);
                }
            }
            if (LabelOderStatusValue.Text == "已处理")
            {
                ButtonOderStatus.Visible = false;
            }
        }
    }
}
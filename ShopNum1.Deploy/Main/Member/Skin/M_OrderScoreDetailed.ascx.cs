using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_OrderScoreDetailed : BaseMemberControl
    {
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_OrderScoreList.aspx");
        }

        public void GetOrder()
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            DataTable infoByGuid = action.GetInfoByGuid(Page.Request.QueryString["guid"]);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                LabelOrderNumber.Text = infoByGuid.Rows[0]["OrderNumber"].ToString();
                LabelCreateTime.Text = infoByGuid.Rows[0]["CreateTime"].ToString();
                if (infoByGuid.Rows[0]["OderStatus"].ToString() == "1")
                {
                    LabelOderStatus.Text = "已处理";
                }
                else
                {
                    LabelOderStatus.Text = "未处理";
                }
                if (Convert.ToDateTime(infoByGuid.Rows[0]["ConfirmTime"].ToString()) ==
                    Convert.ToDateTime("1900-1-1"))
                {
                    LabelConfirmTime.Text = "未处理";
                }
                else
                {
                    LabelConfirmTime.Text = infoByGuid.Rows[0]["ConfirmTime"].ToString();
                }
                LabelName.Text = infoByGuid.Rows[0]["Name"].ToString();
                LabelPostalcode.Text = infoByGuid.Rows[0]["Postalcode"].ToString();
                LabelMobile.Text = infoByGuid.Rows[0]["Mobile"].ToString();
                LabelEmail.Text = infoByGuid.Rows[0]["Email"].ToString();
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
                LabelAddress.Text = str4 + str3;
                HiddenFieldShopMemLoginID.Value = infoByGuid.Rows[0]["ShopMemLoginID"].ToString();
            }
        }

        public void GetOrderProduct()
        {
            string orderNumber = string.Empty;
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            DataTable infoByGuid = action.GetInfoByGuid(Page.Request.QueryString["guid"]);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                orderNumber = infoByGuid.Rows[0]["OrderNumber"].ToString();
            }
            DataTable productByOrderNumber = action.GetProductByOrderNumber(orderNumber);
            if ((productByOrderNumber != null) && (productByOrderNumber.Rows.Count > 0))
            {
                RepeaterProduct.DataSource = productByOrderNumber.DefaultView;
                RepeaterProduct.DataBind();
            }
        }

        public void GetSellUser()
        {
            DataTable shopInfo =
                ((ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action()).GetShopInfo(
                    HiddenFieldShopMemLoginID.Value);
            if ((shopInfo != null) && (shopInfo.Rows.Count > 0))
            {
                LabelShopID.Text = HiddenFieldShopMemLoginID.Value;
                LabelShopName.Text = shopInfo.Rows[0]["ShopName"].ToString();
                LabelShopPhone.Text = shopInfo.Rows[0]["UserMobile"].ToString();
                LabelShopEmail.Text = shopInfo.Rows[0]["UserEmail"].ToString();
                LabelShopAddress.Text = shopInfo.Rows[0]["Address"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["guid"] != null)
            {
                GetOrder();
                GetOrderProduct();
                GetSellUser();
            }
        }
    }
}
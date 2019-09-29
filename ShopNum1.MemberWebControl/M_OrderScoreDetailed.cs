using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_OrderScoreDetailed : BaseMemberWebControl
    {
        private Button ButtonBack;
        private HiddenField HiddenFieldShopMemLoginID;
        private Label LabelAddress;
        private Label LabelConfirmTime;
        private Label LabelCreateTime;
        private Label LabelEmail;
        private Label LabelMobile;
        private Label LabelName;
        private Label LabelOderStatus;
        private Label LabelOrderNumber;
        private Label LabelPostalcode;
        private Label LabelShopAddress;
        private Label LabelShopEmail;
        private Label LabelShopID;
        private Label LabelShopName;
        private Label LabelShopPhone;
        private Repeater RepeaterProduct;
        private string skinFilename = "M_OrderScoreDetailed.ascx";

        public M_OrderScoreDetailed()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
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
                if (Convert.ToDateTime(infoByGuid.Rows[0]["ConfirmTime"].ToString()) == Convert.ToDateTime("1900-1-1"))
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

        protected override void InitializeSkin(Control skin)
        {
            LabelOrderNumber = (Label) skin.FindControl("LabelOrderNumber");
            LabelCreateTime = (Label) skin.FindControl("LabelCreateTime");
            LabelOderStatus = (Label) skin.FindControl("LabelOderStatus");
            LabelConfirmTime = (Label) skin.FindControl("LabelConfirmTime");
            RepeaterProduct = (Repeater) skin.FindControl("RepeaterProduct");
            LabelName = (Label) skin.FindControl("LabelName");
            LabelPostalcode = (Label) skin.FindControl("LabelPostalcode");
            LabelMobile = (Label) skin.FindControl("LabelMobile");
            LabelEmail = (Label) skin.FindControl("LabelEmail");
            LabelAddress = (Label) skin.FindControl("LabelAddress");
            ButtonBack = (Button) skin.FindControl("ButtonBack");
            ButtonBack.Click += ButtonBack_Click;
            HiddenFieldShopMemLoginID = (HiddenField) skin.FindControl("HiddenFieldShopMemLoginID");
            LabelShopID = (Label) skin.FindControl("LabelShopID");
            LabelShopName = (Label) skin.FindControl("LabelShopName");
            LabelShopPhone = (Label) skin.FindControl("LabelShopPhone");
            LabelShopEmail = (Label) skin.FindControl("LabelShopEmail");
            LabelShopAddress = (Label) skin.FindControl("LabelShopAddress");
            if (Page.Request.QueryString["guid"] != null)
            {
                GetOrder();
                GetOrderProduct();
                GetSellUser();
            }
        }
    }
}
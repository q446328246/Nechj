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
    public class S_ScoreOrder_Edit : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Button ButtonOderStatus;
        private Label LabelAddress;
        private Label LabelCreateTime;
        private Label LabelEmail;
        private Label LabelMemLoginID;
        private Label LabelMobile;
        private Label LabelName;
        private Label LabelOderStatus;
        private Label LabelOrderNumber;
        private Label LabelPostalcode;
        private Label LabelTotalScore;
        private Repeater RepeaterShopCart2;
        private string skinFilename = "S_ScoreOrder_Edit.ascx";

        public S_ScoreOrder_Edit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonOderStatus_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            try
            {
                if (action.ChangeOderStatus(Page.Request.QueryString["guid"], "1") > 0)
                {
                    MessageBox.Show("操作成功,请及时发货！");
                    GetOrderData();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["stype"] != null)
            {
                if (Page.Request.QueryString["OderStatus"] != null)
                {
                    Page.Response.Redirect("S_ScoreOrder_List.aspx?stype=" + Page.Request.QueryString["stype"] +
                                           "&OderStatus=" + Page.Request.QueryString["OderStatus"]);
                }
                else
                {
                    Page.Response.Redirect("S_ScoreOrder_List.aspx?stype=" + Page.Request.QueryString["stype"]);
                }
            }
            else
            {
                Page.Response.Redirect("S_ScoreOrder_List.aspx");
            }
        }

        public void GetOrderData()
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            DataTable infoByGuid = action.GetInfoByGuid(Page.Request.QueryString["guid"]);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                LabelOrderNumber.Text = infoByGuid.Rows[0]["OrderNumber"].ToString();
                if (infoByGuid.Rows[0]["OderStatus"].ToString() == "1")
                {
                    LabelOderStatus.Text = "已处理";
                    ButtonOderStatus.Visible = false;
                }
                else
                {
                    LabelOderStatus.Text = "未处理";
                }
                LabelMemLoginID.Text = infoByGuid.Rows[0]["MemLoginID"].ToString();
                LabelCreateTime.Text = infoByGuid.Rows[0]["CreateTime"].ToString();
                LabelTotalScore.Text = infoByGuid.Rows[0]["TotalScore"].ToString();
                LabelName.Text = infoByGuid.Rows[0]["Name"].ToString();
                LabelEmail.Text = infoByGuid.Rows[0]["Email"].ToString();
                string str3 = string.Empty;
                string str4 = string.Empty;
                string str2 = string.Empty;
                if (!string.IsNullOrEmpty(infoByGuid.Rows[0]["Address"].ToString()))
                {
                    DataTable adressNameByCode;
                    DataTable table3;
                    string[] strArray2 = infoByGuid.Rows[0]["Address"].ToString().Split(new[] {'|'});
                    if (strArray2.Length > 0)
                    {
                        str3 = strArray2[0];
                        str4 = strArray2[1];
                    }
                    string code = string.Empty;
                    if (!string.IsNullOrEmpty(str3))
                    {
                        string[] strArray = str3.Split(new[] {'/'});
                        if (strArray.Length > 0)
                        {
                            code = strArray[0];
                        }
                    }
                    if (code.Length == 9)
                    {
                        adressNameByCode = action.GetAdressNameByCode(code.Substring(0, 3));
                        if ((adressNameByCode != null) && (adressNameByCode.Rows.Count > 0))
                        {
                            str2 = str2 + adressNameByCode.Rows[0]["Name"];
                        }
                        DataTable table4 = action.GetAdressNameByCode(code.Substring(0, 6));
                        if ((table4 != null) && (table4.Rows.Count > 0))
                        {
                            str2 = str2 + table4.Rows[0]["Name"];
                        }
                        table3 = action.GetAdressNameByCode(code);
                        if ((table3 != null) && (table3.Rows.Count > 0))
                        {
                            str2 = str2 + table3.Rows[0]["Name"];
                        }
                    }
                    else if (code.Length == 6)
                    {
                        adressNameByCode = action.GetAdressNameByCode(code.Substring(0, 3));
                        if ((adressNameByCode != null) && (adressNameByCode.Rows.Count > 0))
                        {
                            str2 = str2 + adressNameByCode.Rows[0]["Name"];
                        }
                        table3 = action.GetAdressNameByCode(code);
                        if ((table3 != null) && (table3.Rows.Count > 0))
                        {
                            str2 = str2 + table3.Rows[0]["Name"];
                        }
                    }
                    else if (code.Length == 3)
                    {
                        table3 = action.GetAdressNameByCode(code);
                        if ((table3 != null) && (table3.Rows.Count > 0))
                        {
                            str2 = str2 + table3.Rows[0]["Name"];
                        }
                    }
                }
                LabelAddress.Text = str2 + str4;
                LabelPostalcode.Text = infoByGuid.Rows[0]["Postalcode"].ToString();
                LabelMobile.Text = infoByGuid.Rows[0]["Mobile"].ToString();
            }
        }

        public void GetOrderProduct()
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            DataTable infoByGuid = action.GetInfoByGuid(Page.Request.QueryString["guid"]);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                string orderNumber = infoByGuid.Rows[0]["OrderNumber"].ToString();
                DataTable productByOrderNumber = action.GetProductByOrderNumber(orderNumber);
                if ((productByOrderNumber != null) && (productByOrderNumber.Rows.Count > 0))
                {
                    RepeaterShopCart2.DataSource = productByOrderNumber.DefaultView;
                    RepeaterShopCart2.DataBind();
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelOrderNumber = (Label) skin.FindControl("LabelOrderNumber");
            LabelOderStatus = (Label) skin.FindControl("LabelOderStatus");
            LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
            LabelCreateTime = (Label) skin.FindControl("LabelCreateTime");
            LabelTotalScore = (Label) skin.FindControl("LabelTotalScore");
            RepeaterShopCart2 = (Repeater) skin.FindControl("RepeaterShopCart2");
            LabelName = (Label) skin.FindControl("LabelName");
            LabelEmail = (Label) skin.FindControl("LabelEmail");
            LabelAddress = (Label) skin.FindControl("LabelAddress");
            LabelPostalcode = (Label) skin.FindControl("LabelPostalcode");
            LabelMobile = (Label) skin.FindControl("LabelMobile");
            ButtonOderStatus = (Button) skin.FindControl("ButtonOderStatus");
            ButtonOderStatus.Click += ButtonOderStatus_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            if (Page.Request.QueryString["guid"] != null)
            {
                GetOrderData();
                GetOrderProduct();
            }
        }
    }
}
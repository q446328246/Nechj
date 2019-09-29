using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopInfo_AuditOperate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonBank_Click(object sender, EventArgs e)
        {
            if ((base.Request.QueryString["GoBack"] != null) && (base.Request.QueryString["GoBack"] == "nosh"))
            {
                base.Response.Redirect("ShopInfoList_AuditNo.aspx");
            }
            else
            {
                base.Response.Redirect("ShopInfoList_Audit.aspx");
            }
        }

        public string GetShopCategory(string code)
        {
            if (!string.IsNullOrEmpty(code) && (code.Length > 0))
            {
                var action = (ShopNum1_ShopCategory_Action) LogicFactory.CreateShopNum1_ShopCategory_Action();
                string str = string.Empty;
                int num = code.Length/3;
                for (int i = 1; i <= num; i++)
                {
                    string str3 = code.Substring(0, i*3);
                    DataTable shopCategoryMeto = action.GetShopCategoryMeto(str3);
                    if ((shopCategoryMeto != null) && (shopCategoryMeto.Rows.Count > 0))
                    {
                        if (str == string.Empty)
                        {
                            str = shopCategoryMeto.Rows[0]["Name"].ToString();
                        }
                        else
                        {
                            str = str + "/" + shopCategoryMeto.Rows[0]["Name"];
                        }
                    }
                }
                return str;
            }
            return "";
        }

        private void BindData()
        {
            CheckGuid.Value = base.Request.QueryString["guid"];
            CheckGuid.Value.Replace("'", "");
            DataTable allShopInfoByGuid =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetAllShopInfoByGuid(
                    CheckGuid.Value);
            TextBoxName.Text = allShopInfoByGuid.Rows[0]["Name"].ToString();
            TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["ShopName"].ToString();
            TextBoxSalesRange.Text = allShopInfoByGuid.Rows[0]["SalesRange"].ToString();
            TextBoxTel.Text = allShopInfoByGuid.Rows[0]["Tel"].ToString();
            TextBoxPhone.Text = allShopInfoByGuid.Rows[0]["Phone"].ToString();
            TextBoxPostalCode.Text = allShopInfoByGuid.Rows[0]["PostalCode"].ToString();
            TextBoxAddress.Text = allShopInfoByGuid.Rows[0]["Address"].ToString();
            TextBoxAddressValue.Text = allShopInfoByGuid.Rows[0]["AddressValue"].ToString().Replace(",", "");
            TextBoxIdentityCard.Text = allShopInfoByGuid.Rows[0]["IdentityCard"].ToString();
            ImageCardImage1.ImageUrl = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["CardImage"];
            aCardImage1.HRef = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["CardImage"];
            aBusinessLicense.HRef = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["BusinessLicense"];

            aTaxRegistrationtr.HRef = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["TaxRegistration"];
            aOrganization.HRef = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["Organization"];

            ImageBusinessLicense.ImageUrl = "~/ImgUpload/ShopCertification/" +
                                            allShopInfoByGuid.Rows[0]["BusinessLicense"];
            ImageTaxRegistrationtr.ImageUrl = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["TaxRegistration"];
            ImageOrganization.ImageUrl = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["Organization"];

            TextBoxReferral.Text = allShopInfoByGuid.Rows[0]["Referral"].ToString();
            if (allShopInfoByGuid.Rows[0]["ShopType"].ToString() == "0")
            {
                TextBoxShopType.Text = "个人";
                PanelShowBusinessLicense.Visible = true;
            }
            else if (allShopInfoByGuid.Rows[0]["ShopType"].ToString() == "1")
            {
                PanelTaxRegistrationtr.Visible = true;
                PanelShowBusinessLicense.Visible = true;
                PanelOrganization.Visible = true;
                TextBoxShopType.Text = "企业";
            }
            TextBoxShopCategory.Text = GetShopCategory(allShopInfoByGuid.Rows[0]["ShopCategoryID"].ToString());
            TextBoxMainGoods.Text = allShopInfoByGuid.Rows[0]["MainGoods"].ToString();
            TextBoxAddressDeteil.Text = allShopInfoByGuid.Rows[0]["Address"].ToString();
        }


    }
}
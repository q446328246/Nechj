using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopInfo_Operate : PageBase, IRequiresSessionState
    {
        private string ShopID { get; set; }

        protected void ButtonBank_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopInfoList_Manage.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var info = new ShopNum1_ShopInfo();
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            info.Name = TextBoxName.Text;
            info.ShopName = TextBoxShopName.Text;
            info.SalesRange = TextBoxSalesRange.Text;
            info.Email = TextBoxEmail.Text;
            info.Tel = TextBoxTel.Text;
            info.Phone = TextBoxPhone.Text;
            info.PostalCode = TextBoxPostalCode.Text;
            info.IdentityCard = TextBoxIdentityCard.Text;
            info.RegistrationNum = TextBoxRegistrationNum.Text;
            info.CompanName = TextBoxCompanName.Text;
            info.LegalPerson = TextBoxLegalPerson.Text;
            info.RegisteredCapital = Convert.ToDecimal(TextBoxRegisteredCapital.Text);
            info.BusinessTerm = TextBoxBusinessTerm.Text;
            info.BusinessScope = TextBoxBusinessScope.Text;
            info.Address = TextBoxAddress.Text;
            info.IsExpires = Convert.ToInt32(DropDownListIsExpires.SelectedValue);
            info.IsClose = Convert.ToInt32(DropDownListIsClose.SelectedValue);
            info.CompanyIntroduce = TextBoxCompanyIntroduce.Text;
            info.ShopIntroduce = TextBoxShopIntroduce.Text;
            info.MemLoginID = HiddenFieldMemLoginID.Value;
            info.MainGoods = TextBoxMainGoods.Text;
            info.IdentityCard = TextBoxIdentityCard.Text;
            if (action.UpdateShopInfoDetail(info) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "修改店铺信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopInfo_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.Visible = true;
                MessageShow.ShowMessage("编辑成功!");
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("编辑失败!");
            }
        }

        private void BindData()
        {
            CheckGuid.Value = base.Request.QueryString["guid"];
            CheckGuid.Value.Replace("'", "");
            DataTable allShopInfoByGuid =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetAllShopInfoByGuid(
                    CheckGuid.Value);
            if (allShopInfoByGuid.Rows[0]["ShopType"].ToString() == "0")
            {
                TextBoxShopType.Text = "个人店铺";
                thYyzz.Visible = false;
                tdYyzz.Visible = false;
            }
            else
            {
                TextBoxShopType.Text = "企业店铺";
            }
            HiddenFieldMemLoginID.Value = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString();
            TextBoxName.Text = allShopInfoByGuid.Rows[0]["Name"].ToString();
            TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["ShopName"].ToString();
            TextBoxSalesRange.Text = allShopInfoByGuid.Rows[0]["SalesRange"].ToString();
            TextBoxEmail.Text = allShopInfoByGuid.Rows[0]["Email"].ToString();
            TextBoxTel.Text = allShopInfoByGuid.Rows[0]["Tel"].ToString();
            TextBoxPhone.Text = allShopInfoByGuid.Rows[0]["Phone"].ToString();
            TextBoxPostalCode.Text = allShopInfoByGuid.Rows[0]["PostalCode"].ToString();
            TextBoxAddress.Text = allShopInfoByGuid.Rows[0]["Address"].ToString();
            TextBoxShopUrl.Text = ShopUrlOperate.GetShopUrl(allShopInfoByGuid.Rows[0]["ShopID"].ToString());
            TextBoxOpenTime.Text = allShopInfoByGuid.Rows[0]["OpenTime"].ToString();
            TextBoxCompanyIntroduce.Text = allShopInfoByGuid.Rows[0]["CompanyIntroduce"].ToString();
            TextBoxShopIntroduce.Text = allShopInfoByGuid.Rows[0]["ShopIntroduce"].ToString();
            ShopID = ShopSettings.GetValue("PersonShopUrl") + allShopInfoByGuid.Rows[0]["ShopID"];
            TextBoxRegistrationNum.Text = allShopInfoByGuid.Rows[0]["RegistrationNum"].ToString();
            TextBoxCompanName.Text = allShopInfoByGuid.Rows[0]["CompanName"].ToString();
            TextBoxLegalPerson.Text = allShopInfoByGuid.Rows[0]["LegalPerson"].ToString();
            TextBoxRegisteredCapital.Text = allShopInfoByGuid.Rows[0]["RegisteredCapital"].ToString();
            TextBoxBusinessTerm.Text = allShopInfoByGuid.Rows[0]["BusinessTerm"].ToString();
            TextBoxBusinessScope.Text = allShopInfoByGuid.Rows[0]["BusinessScope"].ToString();
            TextBoxShopID.Text = allShopInfoByGuid.Rows[0]["ShopID"].ToString();
            TextBoxMainGoods.Text = allShopInfoByGuid.Rows[0]["MainGoods"].ToString();
            DropDownListIsExpires.SelectedValue = allShopInfoByGuid.Rows[0]["IsExpires"].ToString();
            DropDownListIsClose.SelectedValue = allShopInfoByGuid.Rows[0]["IsClose"].ToString();
            TextBoxIdentityCard.Text = allShopInfoByGuid.Rows[0]["IdentityCard"].ToString();
            ImageBanner.ImageUrl = allShopInfoByGuid.Rows[0]["Banner"].ToString();
            aBanner.HRef = allShopInfoByGuid.Rows[0]["Banner"].ToString();
            ImageCardImage1.ImageUrl = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["CardImage"];
            aCardImage1.HRef = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["CardImage"];
            ImageCardImage2.ImageUrl = "~/ImgUpload/ShopCertification/s_" + allShopInfoByGuid.Rows[0]["CardImage"];
            aCardImage2.HRef = "~/ImgUpload/ShopCertification/s_" + allShopInfoByGuid.Rows[0]["CardImage"];
            aBusinessLicense.HRef = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["BusinessLicense"];
            ImageBusinessLicense.ImageUrl = "~/ImgUpload/ShopCertification/" +
                                            allShopInfoByGuid.Rows[0]["BusinessLicense"];
            DataTable table2 = ((Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action()).SearchEnsureApply(ShopID);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                RepeaterEnsure.DataSource = table2.DefaultView;
                RepeaterEnsure.DataBind();
            }
            else
            {
                RepeaterEnsure.DataSource = null;
                RepeaterEnsure.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }
}
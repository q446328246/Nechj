using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Data;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1MultiEntity;
using ShopNum1.Standard;


namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MeberShip_Particular_IsBusiness : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkPass.Visible = true;
            LinkDelte.Visible = true;
            BindData();

        }
        private void BindData()
        {
            string MembershipID = base.Request.QueryString["MembershipID"];
            DataTable allShopInfoByGuid =
                ((ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetAllMemberShipByMembershipIDNEC(MembershipID);
            TextBoxName.Text = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString(); //会员ID
            TextBoxShopCategory.Text = allShopInfoByGuid.Rows[0]["RealName"].ToString();//姓名
            TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["CardID"].ToString();//身份证

            TextBoxShopType.Text = allShopInfoByGuid.Rows[0]["ShopName"].ToString();//商家名称
            
            //TextBoxMainGoods.Text = allShopInfoByGuid.Rows[0]["MemLoginNO"].ToString();//用户编号

            //审核状态
            if (allShopInfoByGuid.Rows[0]["Status"].ToString() == "0")
            {
                TextBoxSalesRange.Text = "审核中";
            }
            if (allShopInfoByGuid.Rows[0]["Status"].ToString() == "1" )
            {
                TextBoxSalesRange.Text = "已审核";
                LinkPass.Visible = false;
                LinkDelte.Visible = false;
            }
            if (allShopInfoByGuid.Rows[0]["Status"].ToString() == "2")
            {
                TextBoxSalesRange.Text = "已拒绝";
                LinkPass.Visible = false;
                LinkDelte.Visible = false;
            }

            TextBoxTel.Text = allShopInfoByGuid.Rows[0]["createtime"].ToString();//提交申请日期
 
      //,[CardAndPeopleImage]、  正面
      //,[LicenseImage]   营业执照
      //,[FanCardImage]  反面

            aOrganization.HRef = "~/" + allShopInfoByGuid.Rows[0]["CardAndPeopleImage"];//身份证正面
            ImageOrganization.ImageUrl = "~/" + allShopInfoByGuid.Rows[0]["CardAndPeopleImage"];

            ImageLicenseImage.HRef = "~/" + allShopInfoByGuid.Rows[0]["LicenseImage"];//营业执照
            ImageBusinessLicense.ImageUrl = "~/" + allShopInfoByGuid.Rows[0]["LicenseImage"];

            ImageCardImageFanCardImage.HRef = "~/" + allShopInfoByGuid.Rows[0]["FanCardImage"];//反面
            ImageBusinessLicenseFanCardImage.ImageUrl = "~/" + allShopInfoByGuid.Rows[0]["FanCardImage"];
            //ImageTaxRegistrationtr.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["RegistrationImage"];


            //aShopImageone.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["ShopImageone"];
            //aShopImagetwo.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["ShopImagetwo"];
            //aOpeningImage.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["OpeningImage"];

            //ImageShopImageone.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["ShopImageone"];
            //ImageShopImagetwo.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["ShopImagetwo"];
            //ImageOpeningImage.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["OpeningImage"];

            //if (allShopInfoByGuid.Rows[0]["RegistrationImage"].ToString()=="")
            //{
            //    PanelTaxRegistrationtr.Visible = false;
            //}
            if (allShopInfoByGuid.Rows[0]["CardAndPeopleImage"].ToString() == "")
            {
                PanelOrganization.Visible = false;
            }
            if (allShopInfoByGuid.Rows[0]["LicenseImage"].ToString() == "")
            {
                PanelOrganization.Visible = false;
            }
            if (allShopInfoByGuid.Rows[0]["FanCardImage"].ToString() == "")
            {
                PanelOrganization.Visible = false;
            }
            //if (allShopInfoByGuid.Rows[0]["ShopImageone"].ToString() == "")
            //{
            //    PanelShopImageone.Visible = false;
            //}
            //if (allShopInfoByGuid.Rows[0]["ShopImagetwo"].ToString() == "")
            //{
            //    PanelShopImagetwo.Visible = false;
            //}
            //if (allShopInfoByGuid.Rows[0]["OpeningImage"].ToString() == "")
            //{
            //    PanelOpeningImage.Visible = false;
            //}

        }

        protected void ButtonBank_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MemberShip_List_IsBusiness.aspx");
        }



        protected void ButtonPassByShip_Click(object sender, EventArgs e)
        {


            string ShipID = base.Request.QueryString["MembershipID"];
            ShopNum1_Member_Action Memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable table = action.SearchShipIDNEC(ShipID);
            if (table != null && table.Rows.Count > 0)
            {
                string MemLoginID = table.Rows[0]["MemLoginID"].ToString();


                int UpdateRefuseStatusNEC_Status = action.UpdateRefuseStatusNEC_Status(ShipID);
                int UpdateRefuseStatusNEC_member = action.UpdateRefuseStatusNEC_member(MemLoginID);
                if (UpdateRefuseStatusNEC_Status > 0 && UpdateRefuseStatusNEC_member > 0)
                {
                    Response.Write("<Script Language=JavaScript>alert('审核成功！');</Script>");
                }
                else
                {
                    Response.Write("<Script Language=JavaScript>alert('审核失败，请联系管理员！');</Script>");
                }

            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert('未查询到该数据！');</Script>");
            }




        }

        protected void ButtonRefuseByShip_Click(object sender, EventArgs e)
        {

            string ShipID = base.Request.QueryString["MembershipID"];
            var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable table = action.SearchShipIDNEC(ShipID);
            if (table != null && table.Rows.Count > 0)
            {
                string MemLoginID = table.Rows[0]["MemLoginID"].ToString();


                int UpdateRefuseStatusNEC_member1 = action.UpdateRefuseStatusNEC_Status2(ShipID);
                if (UpdateRefuseStatusNEC_member1 > 0)
                {
                    Response.Write("<Script Language=JavaScript>alert('拒绝成功！');</Script>");
                }
                else
                    {
                        Response.Write("<Script Language=JavaScript>alert('拒绝失败，请联系管理员！');</Script>");
                    }

            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert('未查询到该数据！');</Script>");
            }
        }

    }
}
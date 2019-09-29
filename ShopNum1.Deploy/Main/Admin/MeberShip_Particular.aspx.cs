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
    public partial class MeberShip_Particular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkPass.Visible = false;
            LinkDelte.Visible = false;
            BindData();

        }
        private void BindData()
        {
            string MembershipID = base.Request.QueryString["MembershipID"];
            DataTable allShopInfoByGuid =
                ((ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetAllMemberShipByMembershipID(MembershipID);
            TextBoxName.Text = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString(); //会员ID
            TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["ShopNames"].ToString();//车牌
            TextBoxShopType.Text = allShopInfoByGuid.Rows[0]["NewRankID"].ToString();//升级的会员等级
            //TextBoxShopCategory.Text = allShopInfoByGuid.Rows[0]["RealName"].ToString();//姓名
            //TextBoxMainGoods.Text = allShopInfoByGuid.Rows[0]["MemLoginNO"].ToString();//用户编号

            //审核状态
            if (allShopInfoByGuid.Rows[0]["ShipStatus"].ToString() == "0")
            {
                TextBoxSalesRange.Text = "未通过";
            }
            if (allShopInfoByGuid.Rows[0]["ShipStatus"].ToString() == "1" || allShopInfoByGuid.Rows[0]["ShipStatus"].ToString() == "3")
            {
                TextBoxSalesRange.Text = "未审核";
                LinkPass.Visible = true;
                LinkDelte.Visible = true;
            }
            if (allShopInfoByGuid.Rows[0]["ShipStatus"].ToString() == "2")
            {
                TextBoxSalesRange.Text = "未通过";
            }

            TextBoxTel.Text = allShopInfoByGuid.Rows[0]["AddTime"].ToString();//提交申请日期
            //TextBoxPhone.Text = allShopInfoByGuid.Rows[0]["BirthdayTime"].ToString();//生日
            //TextBoxPostalCode.Text = allShopInfoByGuid.Rows[0]["IdentityCard"].ToString();//身份证
            //TextBoxIdentityCard.Text = allShopInfoByGuid.Rows[0]["Sex"].ToString();//性别
            //TextBoxRegistrationNum.Text = allShopInfoByGuid.Rows[0]["Phone"].ToString();//电话
            //TextBoxCompanName.Text = allShopInfoByGuid.Rows[0]["Mobile"].ToString();//手机
            //TextBoxLegalPerson.Text = allShopInfoByGuid.Rows[0]["Adress"].ToString();//居住地址
            //TextBoxRegisteredCapital.Text = allShopInfoByGuid.Rows[0]["Area"].ToString();//申办区县代理的地址
            //TextBoxBusinessTerm.Text = allShopInfoByGuid.Rows[0]["Occupation"].ToString();//曾从事职业
            //TextBoxAddress.Text = allShopInfoByGuid.Rows[0]["RERealName"].ToString();//招商人姓名
            //TextBoxAddressValue.Text = allShopInfoByGuid.Rows[0]["REMemLoginNO"].ToString();//招商人用户编号
            //TextBoxAddressDeteil.Text = allShopInfoByGuid.Rows[0]["REAddTime"].ToString();//招商人注册时间
            //TextBoxHeBathday.Text = allShopInfoByGuid.Rows[0]["REBirthdayTime"].ToString();//招商人生日

            //TextBoxHeCar.Text = allShopInfoByGuid.Rows[0]["REIdentityCard"].ToString();//招商人身份证号
            //TextBoxHeSex.Text = allShopInfoByGuid.Rows[0]["RESex"].ToString();//招商人性别
            //TextBoxHePhone.Text = allShopInfoByGuid.Rows[0]["REPhone"].ToString();//招商人电话
            //TextBoxHeModel.Text = allShopInfoByGuid.Rows[0]["REMobile"].ToString();//招商人手机
            //TextBoxHeAdress.Text = allShopInfoByGuid.Rows[0]["REAdress"].ToString();//招商人居住地址
            //TextBoxHeReplaceName.Text = allShopInfoByGuid.Rows[0]["ShopNames"].ToString();//区代名称
            TextBoxHeReplace.Text = allShopInfoByGuid.Rows[0]["Belongs"].ToString();//上级区代

            //aCardImage1.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["IdentityCardImage"];
            //aBusinessLicense.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["LicenseImage"];

            //aTaxRegistrationtr.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["RegistrationImage"];
            aOrganization.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["OrganizationImage"];

            //ImageCardImage1.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["IdentityCardImage"];
            //ImageBusinessLicense.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["LicenseImage"];

            //ImageTaxRegistrationtr.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["RegistrationImage"];
            ImageOrganization.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["OrganizationImage"];

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
            if (allShopInfoByGuid.Rows[0]["OrganizationImage"].ToString() == "")
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
            base.Response.Redirect("MemberShip_List.aspx");
        }



        protected void ButtonPassByShip_Click(object sender, EventArgs e)
        {


            string ShipID = base.Request.QueryString["MembershipID"];
            ShopNum1_Member_Action Memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable table = action.SearchShipID(ShipID);
            string MemberRankGuid = table.Rows[0]["NewRankID"].ToString();
            string MemLoginID = table.Rows[0]["MemLoginID"].ToString();
            string Outmessage = string.Empty;

            string Belongs = table.Rows[0]["Belongs"].ToString();
            string ShopNames = table.Rows[0]["ShopNames"].ToString();
            string LastRankID = table.Rows[0]["LastRankID"].ToString();
            DateTime ExamineTime = DateTime.Now;


            Outmessage = "您的" + MemberRankGuid + "绑定成功!";
            //var builder = new StringBuilder();
            //builder.Append("<?xml version='1.0' encoding='utf-8'?>");
            //builder.Append("<Shop>");
            //builder.Append("<Ver>1.0</Ver>");
            //builder.Append("<ShopName>" + table.Rows[0]["ShopNames"].ToString() + "</ShopName>"); //区代名称
            //builder.Append("<OrgID>1000</OrgID>"); //
            //builder.Append("<ShopType>2</ShopType>"); //区代类型
            //builder.Append("<Status>1</Status>"); //
            //builder.Append("<CustomerNo>" + table.Rows[0]["MemLoginNO"].ToString() + "</CustomerNo>"); //经销商编号
            //builder.Append("<AddDate>" + DateTime.Now.ToString() + "</AddDate>"); //加入时间
            //builder.Append("<RecommendCustomerNo></RecommendCustomerNo>"); //推荐人编号
            //builder.Append("<ParentShopNo>" + table.Rows[0]["Belongs"].ToString() + "</ParentShopNo>"); //上级区代编号
            //builder.Append("<Memo></Memo>"); //备注
            //builder.Append("</Shop>");
            //string info = builder.ToString();
            //TJAPItwo.WebService webservice = new TJAPItwo.WebService();
            //string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //string privateKey_two = "Info=" + info + md5_one;
            //string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //string returnResult = webservice.Operate("CHECKSHOPINPUT", info, md5Check_two);
            string returnResult = "成功";
            if (returnResult == "成功")
            {
                action.UpdatePassStatus(ShipID, ExamineTime);
                Memaction.UpdateMemberCarBand(MemLoginID, Belongs, ShopNames, LastRankID);
                DataTable gpstable = action.SearchGPSBand(Belongs);
                if (gpstable.Rows[0]["BandStatus"].ToString() == "0")
                {
                    decimal price = Convert.ToDecimal(gpstable.Rows[0]["BandPrice"]);
                    action.UpdateGPSBandStatus(Belongs);
                    action.INsertAdvancePaymentModifyLog_Gz_BandPVA(MemLoginID, price * 5, "绑定矿机获得");
                }
                #region 发送站内信
                var messageInfo = new ShopNum1_MessageInfo
                {
                    Guid = Guid.NewGuid(),
                    Title = "会员升级成功",
                    Type = "1",
                    Content = "尊敬的" + MemLoginID.Trim() + ":" + Outmessage,
                    MemLoginID = MemLoginID,
                    SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsDeleted = 0
                };
                var usermessage = new List<string>
                        {
                            MemLoginID
                        };
                ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
                                                                                                     usermessage);


                Response.Write("<Script Language=JavaScript>alert('操作成功！');</Script>");



                #endregion
            }
            else
            {
                Response.Write("<script>alert('" + returnResult + "');</script>");

            }






        }

        protected void ButtonRefuseByShip_Click(object sender, EventArgs e)
        {

            string ShipID = base.Request.QueryString["MembershipID"];
            var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable table = action.SearchShipID(ShipID);
            string MemberRankGuid = table.Rows[0]["NewRankID"].ToString();
            string MemLoginID = table.Rows[0]["MemLoginID"].ToString();
            string Outmessage = string.Empty;
            string Mobile = table.Rows[0]["Mobile"].ToString();

            action.UpdateRefuseStatus(ShipID);
            action.UpdateRefuseweixinOpenid(MemLoginID);

            Outmessage = "您车辆绑定申请已被驳回，请下次申请!";


            var messageInfo = new ShopNum1_MessageInfo
            {
                Guid = Guid.NewGuid(),
                Title = "会员升级失败",
                Type = "1",
                Content = "尊敬的" + MemLoginID.Trim() + ":" + Outmessage,
                MemLoginID = MemLoginID,
                SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsDeleted = 0
            };
            var usermessage = new List<string>
                        {
                            MemLoginID
                        };
            ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
                                                                                               usermessage);
            //加个失败短信    内容是 Outmessage

            Response.Write("<Script Language=JavaScript>alert('操作成功！');</Script>");

        }

    }
}
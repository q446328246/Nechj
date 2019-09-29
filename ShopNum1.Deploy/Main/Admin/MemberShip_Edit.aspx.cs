using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberShip_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }


        private void BindData()
        {
            string MembershipID = base.Request.QueryString["MembershipID"];
            DataTable allShopInfoByGuid =
                ((ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetAllMemberShipByMembershipID(MembershipID);
            TextBoxName.Text = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString(); //会员ID
            //TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["LastRankName"].ToString();//原有会员等级
            //TextBoxShopType.Text = allShopInfoByGuid.Rows[0]["NewRankName"].ToString();//升级的会员等级
            TextBoxShopCategory.Text = allShopInfoByGuid.Rows[0]["RealName"].ToString();//姓名
            TextBoxMainGoods.Text = allShopInfoByGuid.Rows[0]["MemLoginNO"].ToString();//用户编号

            //审核状态
            if (allShopInfoByGuid.Rows[0]["ShipStatus"].ToString() == "0")
            {
                TextBoxSalesRange.Text = "未审核";
            }
            if (allShopInfoByGuid.Rows[0]["ShipStatus"].ToString() == "1")
            {
                TextBoxSalesRange.Text = "已审核通过";
            }
            if (allShopInfoByGuid.Rows[0]["ShipStatus"].ToString() == "2")
            {
                TextBoxSalesRange.Text = "未通过";
            }

            TextBoxTel.Text = allShopInfoByGuid.Rows[0]["AddTime"].ToString();//提交申请日期
            TextBoxPhone.Text = allShopInfoByGuid.Rows[0]["BirthdayTime"].ToString();//生日
            TextBoxPostalCode.Text = allShopInfoByGuid.Rows[0]["IdentityCard"].ToString();//身份证
            TextBoxIdentityCard.Text = allShopInfoByGuid.Rows[0]["Sex"].ToString();//性别
            TextBoxRegistrationNum.Text = allShopInfoByGuid.Rows[0]["Phone"].ToString();//电话
            TextBoxCompanName.Text = allShopInfoByGuid.Rows[0]["Mobile"].ToString();//手机
            TextBoxLegalPerson.Text = allShopInfoByGuid.Rows[0]["Adress"].ToString();//居住地址


            //hid_Area.Value = ((allShopInfoByGuid.Rows[0]["Area"].ToString() == "") ||
            //                                    (allShopInfoByGuid.Rows[0]["Area"].ToString() == ",,|0,0,0"))
            //                                       ? "0"
            //                                       : allShopInfoByGuid.Rows[0]["Area"].ToString();

            string area = allShopInfoByGuid.Rows[0]["Area"].ToString();//申办区县代理的地址
            TextBoxRegisteredCapital.Text = GetAddressDetil(area);
            TextBoxBusinessTerm.Text = allShopInfoByGuid.Rows[0]["Occupation"].ToString();//曾从事职业
            TextBoxAddress.Text = allShopInfoByGuid.Rows[0]["RERealName"].ToString();//招商人姓名
            TextBoxAddressValue.Text = allShopInfoByGuid.Rows[0]["REMemLoginNO"].ToString();//招商人用户编号
            TextBoxAddressDeteil.Text = allShopInfoByGuid.Rows[0]["REAddTime"].ToString();//招商人注册时间
            TextBoxHeBathday.Text = allShopInfoByGuid.Rows[0]["REBirthdayTime"].ToString();//招商人生日

            TextBoxHeCar.Text = allShopInfoByGuid.Rows[0]["REIdentityCard"].ToString();//招商人身份证号
            TextBoxHeSex.Text = allShopInfoByGuid.Rows[0]["RESex"].ToString();//招商人性别
            TextBoxHePhone.Text = allShopInfoByGuid.Rows[0]["REPhone"].ToString();//招商人电话
            TextBoxHeModel.Text = allShopInfoByGuid.Rows[0]["REMobile"].ToString();//招商人手机
            TextBoxHeAdress.Text = allShopInfoByGuid.Rows[0]["REAdress"].ToString();//招商人居住地址
            TextBoxHeReplaceName.Text = allShopInfoByGuid.Rows[0]["ShopNames"].ToString();//区代名称
            TextBoxHeReplace.Text = allShopInfoByGuid.Rows[0]["Belongs"].ToString();//上级区代

            aCardImage1.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["IdentityCardImage"];
            aBusinessLicense.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["LicenseImage"];

            aTaxRegistrationtr.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["RegistrationImage"];
            aOrganization.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["OrganizationImage"];

            ImageCardImage1.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["IdentityCardImage"];
            ImageBusinessLicense.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["LicenseImage"];

            ImageTaxRegistrationtr.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["RegistrationImage"];
            ImageOrganization.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["OrganizationImage"];

            aShopImageone.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["ShopImageone"];
            aShopImagetwo.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["ShopImagetwo"];
            aOpeningImage.HRef = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["OpeningImage"];

            ImageShopImageone.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["ShopImageone"];
            ImageShopImagetwo.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["ShopImagetwo"];
            ImageOpeningImage.ImageUrl = "~/ImgUpload/Member_Ship/" + allShopInfoByGuid.Rows[0]["OpeningImage"];

            if (allShopInfoByGuid.Rows[0]["RegistrationImage"].ToString() == "")
            {
                PanelTaxRegistrationtr.Visible = false;
            }
            if (allShopInfoByGuid.Rows[0]["OrganizationImage"].ToString() == "")
            {
                PanelOrganization.Visible = false;
            }
            if (allShopInfoByGuid.Rows[0]["ShopImageone"].ToString() == "")
            {
                PanelShopImageone.Visible = false;
            }
            if (allShopInfoByGuid.Rows[0]["ShopImagetwo"].ToString() == "")
            {
                PanelShopImagetwo.Visible = false;
            }
            if (allShopInfoByGuid.Rows[0]["OpeningImage"].ToString() == "")
            {
                PanelOpeningImage.Visible = false;
            }

        }

        protected void ButtonBank_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MemberShip_List.aspx");


        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            string MembershipID = base.Request.QueryString["MembershipID"];

            ShopNum1_ShopInfoList_Action Member_ship_Delete = new ShopNum1_ShopInfoList_Action();

            ShopNum1_MemberShip_Action Member_shipAddress_Delete = new ShopNum1_MemberShip_Action();


            int result = Member_ship_Delete.DeleteShip( MembershipID);

            int resultAddress = Member_shipAddress_Delete.DeleteShipAdress(TextBoxName.Text);

            if (result == 1&&resultAddress==1)
            {
                Response.Write("<script>alert('删除成功');window.location.href ='MemberShip_List.aspx'</script>");

                //base.Response.Redirect("MemberShip_List.aspx");
            }

        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
             string MembershipID = base.Request.QueryString["MembershipID"];

            var member = new ShopNum1_MemberShip();

            ShopNum1_MemberShip shopNum1_MemberShip=new ShopNum1_MemberShip();

            string[] strArrayAdress = hid_AreaValue.Value.ToString().Split(new[] { '|' })[0].Split(new[] { ',' });
            string Province = strArrayAdress[0];
            string City = strArrayAdress[1];
            string District = strArrayAdress[2];


            ShopNum1_MemberShipAdress memberShipAdress = new ShopNum1_MemberShipAdress();
            ShopNum1_MemberShip_Action memberShipAction =
                        (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();

            memberShipAdress.Province = Province;
            memberShipAdress.City = City;
            memberShipAdress.District = District;
            memberShipAdress.MemLoginID = TextBoxName.Text;

            DataTable memshipAdressChongFu = memberShipAction.SearchShipAdress(Province, City, District);
            DataTable memshipAdressChongFuID = memberShipAction.SearchShipAdressID(memberShipAdress);
            DataTable memshipAdressChongFuAddress = memberShipAction.SearchShipAdressAndID(memberShipAdress);//判断会员id和地址是否同时存在

            if (Province == "" || City == "" || District == "")
            {

            }
            else
            {
                if (memshipAdressChongFuID.Rows.Count > 0)//判断会员id是否存在
                {
                    if (memshipAdressChongFuAddress.Rows.Count > 0)//判断会员id和地址是否同时存在
                    {

                    }
                    else if (memshipAdressChongFu.Rows.Count > 0)//判断地址是否存在
                    {
                        Response.Write("<script>alert('申请拟办区代地址已存在！');</script>");
                        return;
                    }
                    else
                    {
                        memberShipAction.UpdateShipAdress(memberShipAdress);
                    }
                }
                else
                {
                    if (memshipAdressChongFu.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('申请拟办区代地址已存在！');</script>");
                        return;
                    }
                    else
                    {
                        memberShipAction.AddShipAdress(memberShipAdress);
                    }
                }
            }
            //shopNum1_MemberShip.LastRankID= TextBoxShopName.Text;//原有会员等级
            //shopNum1_MemberShip.NewRankID=TextBoxShopType.Text;//升级的会员等级
            shopNum1_MemberShip.MemLoginID = TextBoxName.Text;
            shopNum1_MemberShip.MemLoginNO = TextBoxMainGoods.Text;
            shopNum1_MemberShip.RealName = TextBoxShopCategory.Text;//姓名

            shopNum1_MemberShip.BirthdayTime=DateTime.Parse(TextBoxPhone.Text);//生日
            shopNum1_MemberShip.IdentityCard=TextBoxPostalCode.Text ;//身份证
            shopNum1_MemberShip.Sex=TextBoxIdentityCard.Text;//性别
            shopNum1_MemberShip.Phone=TextBoxRegistrationNum.Text ;//电话
            shopNum1_MemberShip.Mobile=TextBoxCompanName.Text;//手机
            shopNum1_MemberShip.Adress = TextBoxLegalPerson.Text;//居住地址
            if (Province != "" && City != "" && District != "")
            {
                shopNum1_MemberShip.Area = hid_AreaValue.Value;
            }
            else
            {
                shopNum1_MemberShip.Area = TextBoxRegisteredCapital.Text;
            }
            //shopNum1_MemberShip.Area = TextBoxRegisteredCapital.Text;//申办区县代理的地址
            shopNum1_MemberShip.Occupation=TextBoxBusinessTerm.Text;//曾从事职业
            shopNum1_MemberShip.RERealName=TextBoxAddress.Text;//招商人姓名
            shopNum1_MemberShip.REMemLoginNO=TextBoxAddressValue.Text;//招商人用户编号
            shopNum1_MemberShip.REAddTime=DateTime.Parse( TextBoxAddressDeteil.Text);//招商人注册时间
            shopNum1_MemberShip.REBirthdayTime=DateTime.Parse( TextBoxHeBathday.Text) ;//招商人生日

            shopNum1_MemberShip.REIdentityCard=TextBoxHeCar.Text;//招商人身份证号
            shopNum1_MemberShip.RESex=TextBoxHeSex.Text;//招商人性别
            shopNum1_MemberShip.REPhone=TextBoxHePhone.Text;//招商人电话
            shopNum1_MemberShip.REMobile=TextBoxHeModel.Text;//招商人手机
            shopNum1_MemberShip.REAdress=TextBoxHeAdress.Text;//招商人居住地址
            shopNum1_MemberShip.ShopNames= TextBoxHeReplaceName.Text;//区代名称
            shopNum1_MemberShip.Belongs=TextBoxHeReplace.Text;//上级区代

            ShopNum1_ShopInfoList_Action Member_ship_Update = new ShopNum1_ShopInfoList_Action();

             int result= Member_ship_Update.UpdateShip(shopNum1_MemberShip, MembershipID);

             if (result == 1)
             {
                 Response.Write("<script>alert('修改成功')</script>");
             }
             
        }

        //protected string GetAdress(string Address)
        //{
        //    string[] strArray2 = Address.Split(new[] { '|' })[0].Split(new[] { ',' });
        //    if (strArray2.Length == 3)
        //    {
        //        return (strArray2[0] + strArray2[1] + strArray2[2]);
        //    }
        //    if (strArray2.Length == 2)
        //    {
        //        return (strArray2[0] + strArray2[1]);
        //    }
        //    if (strArray2.Length == 1)
        //    {
        //        return strArray2[0];
        //    }
        //    return Address;
        //}


        public string GetAddressDetil(string addressValue)
        {
            string[] strArray2 = addressValue.Split(new[] { '|' })[0].Split(new[] { ',' });
            string str = string.Empty;
            if (strArray2.Length > 2)
            {
                return (strArray2[0] + strArray2[1] + strArray2[2]);
            }
            if (strArray2.Length > 1)
            {
                return (strArray2[0] + strArray2[1]);
            }
            if (strArray2.Length > 0)
            {
                str = strArray2[0];
            }
            return str;
        }
        
    }
}
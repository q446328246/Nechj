using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_CarBand : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonUpgrade_Click(object sender, EventArgs e)
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];



             ShopNum1_MemberShip_Action memberShipAction =
                        (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                    DataTable memshipChongFu = memberShipAction.SearchShipRepeatMemLoginID(MemberLoginID, 1);
                    if (memshipChongFu.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('您已在申请列表中，请等待系统审批！');</script>");
                    }
                    else
                    {
                        string shebei = "";
                        
                        if (Textshebei.Text.Length == 11)
                        {
                            shebei = "0" + Textshebei.Text.Trim();
                        }
                        else if (Textshebei.Text.Length == 10)
                        {
                            shebei = "01" + Textshebei.Text.Trim();
                        }
                        else 
                        {
                            shebei = Textshebei.Text.Trim();
                        }
                        DataTable deviceno = memberShipAction.SearchGPS_device(shebei);
                        if (deviceno.Rows.Count > 0)
                        {
                            DataTable memdevice = memberShipAction.SearchMEM_device(shebei);
                            if (memdevice.Rows.Count > 0) 
                            {
                                Response.Write("<script>alert('该设备号已经被绑定！');</script>");
                                return;
                            }
                            string Outmessage = string.Empty;
                            string CarType = string.Empty;
                            string CarTypeName = string.Empty;
                            //Outmessage = "您的临时区代理申请已经通过,请于1天内下单！注意：首次购买时需重新登陆账号！";

                            if (RadioButtonAgentMember.Checked == true)
                            {
                                CarType = "1";
                                CarTypeName = "新能源汽车";
                                Outmessage = "您的新能源汽车绑定申请已成功提交！";
                            }
                            else
                            {
                                CarType = "2";
                                CarTypeName = "燃油汽车";
                                Outmessage = "您的燃油汽车绑定申请已成功提交！";
                            }

                            #region 原逻辑
                            ShopNum1_MemberShip memberShip = new ShopNum1_MemberShip();
                            memberShip.ShopNames = TextBoxShopNames.Text.Trim();
                            memberShip.Belongs = shebei;
                            memberShip.MemLoginID = MemberLoginID;
                            memberShip.LastRankID = CarType;
                            memberShip.NewRankID = CarTypeName;
                            memberShip.RealName = "";
                            memberShip.MemLoginNO = "";
                            //1申请状态 2区代I状态 3区代II申请状态 4区代II状态
                            memberShip.ShipStatus = 1;
                            memberShip.AddDate = DateTime.Now;
                            memberShip.BirthdayTime = DateTime.Now;
                            memberShip.IdentityCard = "";
                            memberShip.Sex = "";
                            memberShip.Phone = "";
                            memberShip.Mobile = "";
                            memberShip.Adress = "";
                            memberShip.Area = "";
                            memberShip.Occupation = "";
                            //memberShip.IdentityCardImage = FileUpload(FileUploadIdentityCardImage, new Order().CreateOrderNumber(), MemberLoginID);
                            //memberShip.LicenseImage = FileUpload(FileUploadLicenseImage, new Order().CreateOrderNumber(), MemberLoginID);
                            memberShip.OrganizationImage = FileUpload(FileUploadOrganizationImage, new Order().CreateOrderNumber(), MemberLoginID);
                            memberShip.REMemLoginNO = "";
                            memberShip.RERealName = "";
                            memberShip.REAddTime = DateTime.Now;
                            //新加
                            memberShip.ExamineTime = null;


                            memberShipAction.Add(memberShip);



                            #endregion
                            #region 发送站内信
                            var messageInfo = new ShopNum1_MessageInfo
                            {
                                Guid = Guid.NewGuid(),
                                Title = "车辆绑定申请成功",
                                Type = "1",
                                Content = "尊敬的" + MemberLoginID.Trim() + ":" + Outmessage,
                                MemLoginID = MemberLoginID,
                                SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                IsDeleted = 0
                            };
                            var usermessage = new List<string>
                        {
                            MemberLoginID
                        };
                            ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
                                                                                                                 usermessage);

                            //加个通过短信
                            //var sms = new SMS();
                            //string retmsg = "";
                            //sms.Send(TextBoxMobile.Text.Trim(), "尊敬的" + MemberLoginID.Trim() + ":" + Outmessage + "【唐江宝宝】", out retmsg);

                            Response.Write("<script>top.location='m_index.aspx?action=2';</script>");



                            #endregion
                        }
                        else 
                        {
                            Response.Write("<script>alert('系统不存在该设备号！');</script>");
                        }
                    }


        }



        protected string FileUpload(FileUpload ControlName, string ImageName, string memloginid)
        {
            if (ControlName.HasFile)
            {
                var info = new FileInfo(ControlName.PostedFile.FileName);
                string str2 = "~/ImgUpload/Member_Ship";
                string filepath = str2 + "/" + ImageName + memloginid + info.Extension;
                string retstr = string.Empty;
                if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, filepath, out retstr))
                {
                    return (ImageName + memloginid + info.Extension);
                }
                MessageBox.Show(retstr);
                return "0";
            }
            return "1";
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1MultiEntity;
using System.Data;
using ShopNum1.Factory;
using System.Text;
using ShopNum1.Standard;
namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MemberUpgrade5 : System.Web.UI.UserControl
    {


        protected string GetAdress(object AddressValue)
        {
            try
            {
                string[] strArray2 = AddressValue.ToString().Split(new[] { '|' })[0].Split(new[] { ',' });
                string str2 = string.Empty;
                if (strArray2.Length == 3)
                {
                    str2 = strArray2[0] + strArray2[1] + strArray2[2];
                }
                else if (strArray2.Length == 2)
                {
                    str2 = strArray2[0] + strArray2[1];
                }
                else
                {
                    str2 = strArray2[0];
                }

                return str2;
            }
            catch
            {
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieShopMemberLogin1 = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin1 = HttpSecureCookie.Decode(cookieShopMemberLogin1);
            //会员登录ID
            string MemberLoginID1 = decodedCookieShopMemberLogin1.Values["MemLoginID"];
            ShopNum1_Member_Action memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            if (!IsPostBack)
            {
                String Guidid = memberrankguid_Action.GetGuidByMemLoginID(MemberLoginID1);
                DataTable table =
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMemberGuid(Guidid);

                TextBoxMemLoginID.Text = table.Rows[0]["MemLoginNO"].ToString();

                TextBoxMemLoginID.ReadOnly = true;
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
        protected void ButtonUpgrade_Click(object sender, EventArgs e)
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            ShopNum1_Member_Action memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);
            String Guidid = memberrankguid_Action.GetGuidByMemLoginID(MemberLoginID);
            DataTable table =
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMemberGuid(Guidid);
            //TJAPItwo.WebService webservice = new TJAPItwo.WebService();

            //string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //string privateKey_two = "Info=" + TextBoxMemLoginID.Text + md5_one;
            //string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //string Result = webservice.Operate("GETCUSTOMERINFO", TextBoxMemLoginID.Text, md5Check_two);
            //string[] sArray = Result.Split(new char[2] { '~', '|' });
            //string reMemLoginNO = table.Rows[0]["Superior"].ToString();
            //String reGuidid = memberrankguid_Action.GetGuidByMemLoginNO(reMemLoginNO);
            //DataTable table2 =
            //        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMemberGuid(reGuidid);
            //string reRealName = table2.Rows[0]["RealName"].ToString(); ;
            DateTime reAddTime = Convert.ToDateTime("1900/01/01");

            //if (sArray[0] != "false")
            //{
            //    reMemLoginNO = sArray[4];
            //    reRealName = sArray[5];
            //    reAddTime = Convert.ToDateTime(sArray[6]);
            //}

            #region 选择区代表申请
            if (RadioButtonAgentMember.Checked == true)
            {
                if (memberGuid.ToLower().Equals(MemberLevel.AGENT_MEMBER_ID.ToLower()))
                {
                    Response.Write("<script>alert('您已经是区代理会员！');</script>");
                }
                else
                {
                    ShopNum1_MemberShip_Action memberShipAction =
                        (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                    DataTable memshipChongFu = memberShipAction.SearchShipRepeatMemLoginID(MemberLoginID, 1);
                    if (memshipChongFu.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('您已在申请列表中，请等待！');</script>");
                    }
                    else
                    {
                        

                            string Outmessage = string.Empty;

                            //Outmessage = "您的临时区代理申请已经通过,请于1天内下单！注意：首次购买时需重新登陆账号！";
                            Outmessage = "您的临时区代理会员申请已成功提交！";
                            
                            //var builder = new StringBuilder();
                            //builder.Append("<?xml version='1.0' encoding='utf-8'?>");
                            //builder.Append("<Shop>");
                            //builder.Append("<Ver>1.0</Ver>");
                            //builder.Append("<ShopName>" + TextBoxShopNames.Text.Trim() + "</ShopName>"); //区代名称
                            //builder.Append("<OrgID>1000</OrgID>"); //
                            //builder.Append("<ShopType>2</ShopType>"); //区代类型
                            //builder.Append("<Status>1</Status>"); //
                            //builder.Append("<CustomerNo>" + TextBoxMemLoginID.Text.Trim() + "</CustomerNo>"); //经销商编号
                            //builder.Append("<AddDate>" + DateTime.Now.ToString() + "</AddDate>"); //加入时间
                            //builder.Append("<RecommendCustomerNo></RecommendCustomerNo>"); //推荐人编号
                            //builder.Append("<ParentShopNo>" + "C0000001" + "</ParentShopNo>"); //上级区代编号
                            //builder.Append("<Memo></Memo>"); //备注
                            //builder.Append("</Shop>");
                            //string info = builder.ToString();
                            //TJAPItwo.WebService webservice1 = new TJAPItwo.WebService();
                            //string md5_one1 = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                            //string privateKey_two1 = "Info=" + info + md5_one1;
                            //string md5Check_two1 = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two1);
                            //string returnResult1 = webservice1.Operate("CHECKSHOPINPUT", info, md5Check_two1);
                            //if (returnResult1 == "成功")
                            //{
                                #region 原逻辑
                                ShopNum1_MemberShip memberShip = new ShopNum1_MemberShip();
                                memberShip.ShopNames = TextBoxShopNames.Text.Trim();
                                memberShip.Belongs = "C0000001";
                                memberShip.MemLoginID = MemberLoginID;
                                memberShip.LastRankID = memberGuid;
                                memberShip.NewRankID = MemberLevel.AGENT_MEMBER_ID;
                                memberShip.RealName = TextBoxName.Text.Trim();
                                memberShip.MemLoginNO = TextBoxMemLoginID.Text.Trim();
                                //1申请状态 2区代I状态 3区代II申请状态 4区代II状态
                                memberShip.ShipStatus = 1;
                                memberShip.AddDate = DateTime.Now;
                                memberShip.BirthdayTime = Convert.ToDateTime(TextBoxBirthday.Text.ToString());
                                memberShip.IdentityCard = TextBoxCardID.Text.Trim();
                                memberShip.Sex = TextBoxSex.Text.Trim();
                                memberShip.Phone = TextBoxPhone.Text.Trim();
                                memberShip.Mobile = TextBoxMobile.Text.Trim();
                                memberShip.Adress = TextBoxAdress.Text.Trim();
                                memberShip.Area = GetAdress(hid_AreaValue.Value) + TextBoxAdresss.Text.Trim();
                                memberShip.Occupation = TextBoxOccupation.Text.Trim();
                                //memberShip.IdentityCardImage = FileUpload(FileUploadIdentityCardImage, new Order().CreateOrderNumber(), MemberLoginID);
                                memberShip.REMemLoginNO = "";
                                memberShip.RERealName = "";
                                memberShip.REAddTime = reAddTime;
                                //新加
                                memberShip.ExamineTime = null;


                                memberShipAction.Add(memberShip);


                               
                                #endregion

                                //((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateMemberRankGuid(MemberLoginID, MemberLevel.AGENT_MEMBER_ID);
                                #region 发送站内信
                                var messageInfo = new ShopNum1_MessageInfo
                                {
                                    Guid = Guid.NewGuid(),
                                    Title = "会员升级成功",
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
                                var sms = new SMS();
                                string retmsg = "";
                                sms.Send(TextBoxMobile.Text.Trim(), "尊敬的" + MemberLoginID.Trim() + ":" + Outmessage + "【唐江宝宝】", out retmsg);

                                Response.Write("<script>top.location='m_index.aspx?action=2';</script>");



                                #endregion
                            //}
                            //else 
                            //{
                            //    Response.Write("<script>alert('" + returnResult1 + "');</script>");
                            //}






                            // var messageInfo = new ShopNum1_MessageInfo
                            // {
                            //     Guid = Guid.NewGuid(),
                            //     Title = "临时区代理成功",
                            //     Type = "1",
                            //     Content = "尊敬的" + MemberLoginID + ":您的临时区代理会员申请已成功提交!",
                            //     MemLoginID = MemberLoginID,
                            //     SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            //     IsDeleted = 0
                            // };
                            // var usermessage = new List<string>
                            //{
                            //      MemberLoginID
                            //};
                            // ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
                            //                                                                               usermessage);
                            // Response.Write("<script>top.location='m_index.aspx?action=2';</script>");

                        }
                    }

                
            }
            #endregion

            #region 选择社区店铺申请
            if (RadioButtonCommunityMember.Checked == true)
            {
                if (memberGuid.ToLower().Equals(MemberLevel.COMMUNITY_MEMBER_ID.ToLower()))
                {
                    Response.Write("<script>alert('您已经是社区店铺会员！');</script>");
                }
                else
                {
                    ShopNum1_MemberShip_Action memberShipAction =
                        (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                    DataTable memshipChongFu = memberShipAction.SearchShipRepeatMemLoginID(MemberLoginID, 1);

                    if (memshipChongFu.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('您已在申请列表中，请等待！');</script>");
                    }
                    else
                    {
                        string Outmessage = string.Empty;

                        //Outmessage = "您的临时社区店申请已经通过,请于1天内下单！注意：首次购买时需重新登陆账号！";
                        Outmessage = "您的临时社区店申请已成功提交！";
                        ShopNum1_MemberShip memberShip = new ShopNum1_MemberShip();
                        memberShip.ShopNames = TextBoxShopNames.Text.Trim();
                        memberShip.Belongs = TextBoxBelongs.Text.Trim();
                        memberShip.MemLoginID = MemberLoginID;
                        memberShip.LastRankID = memberGuid;
                        memberShip.NewRankID = MemberLevel.COMMUNITY_MEMBER_ID;
                        memberShip.RealName = TextBoxName.Text.Trim();
                        memberShip.MemLoginNO = TextBoxMemLoginID.Text.Trim();
                        memberShip.ShipStatus = 1;
                        memberShip.AddDate = DateTime.Now;
                        memberShip.BirthdayTime = Convert.ToDateTime(TextBoxBirthday.Text.ToString());
                        memberShip.IdentityCard = TextBoxCardID.Text.Trim();
                        memberShip.Sex = TextBoxSex.Text.Trim();
                        memberShip.Phone = TextBoxPhone.Text.Trim();
                        memberShip.Mobile = TextBoxMobile.Text.Trim();
                        memberShip.Adress = TextBoxAdress.Text.Trim();
                        memberShip.Area = GetAdress(hid_AreaValue.Value) + TextBoxAdresss.Text.Trim();
                        memberShip.Occupation = TextBoxOccupation.Text.Trim();
                        //memberShip.IdentityCardImage = FileUpload(FileUploadIdentityCardImage, new Order().CreateOrderNumber(), MemberLoginID);
                        memberShip.REMemLoginNO = "";
                        memberShip.RERealName = "";
                        memberShip.REAddTime = reAddTime;
                        memberShip.ExamineTime = null;



                        memberShipAction.Add(memberShip);

                        //((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateMemberRankGuid(MemberLoginID, MemberLevel.COMMUNITY_MEMBER_ID);

                        #region 发送站内信
                        var messageInfo = new ShopNum1_MessageInfo
                        {
                            Guid = Guid.NewGuid(),
                            Title = "会员升级成功",
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
                        var sms = new SMS();
                        string retmsg = "";
                        sms.Send(TextBoxMobile.Text.Trim(), "尊敬的" + MemberLoginID.Trim() + ":" + Outmessage + "【唐江宝宝】", out retmsg);

                        Response.Write("<script>top.location='m_index.aspx?action=2';</script>");



                        #endregion


                        //var messageInfo = new ShopNum1_MessageInfo
                        //{
                        //    Guid = Guid.NewGuid(),
                        //    Title = "临时社区店申请成功",
                        //    Type = "1",
                        //    Content = "尊敬的" + MemberLoginID + ":您的临时社区店会员申请已成功提交!",
                        //    MemLoginID = MemberLoginID,
                        //    SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        //    IsDeleted = 0
                        //};
                        //var usermessage = new List<string>
                        //   {
                        //         MemberLoginID
                        //   };
                        //((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
                        //                                                                              usermessage);
                        //Response.Write("<script>top.location='m_index.aspx?action=2';</script>");


                    }
                }
            }
            #endregion



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            ShopNum1_MemberShip_Action memberShipAction =
                        (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            memberShipAction.DeleteMemberShipOfMemLoginID(MemberLoginID);
            memberShipAction.DeleteShipAdress(MemberLoginID);
            Response.Write("<script>alert('您已清除数据，请重新提交申请！');</script>");


        }
    }
}
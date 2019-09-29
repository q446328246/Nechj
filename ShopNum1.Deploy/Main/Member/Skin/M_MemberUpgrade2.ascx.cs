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
    public partial class M_MemberUpgrade2 : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 旧逻辑
            //HttpCookie cookieShopMemberLogin1 = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            //HttpCookie decodedCookieShopMemberLogin1 = HttpSecureCookie.Decode(cookieShopMemberLogin1);
            ////会员登录ID
            //string MemberLoginID1 = decodedCookieShopMemberLogin1.Values["MemLoginID"];
            //var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID1);
            //if (memberGuid.Equals(MemberLevel.AGENT_MEMBER_ID))
            //{
            //    TextBoxPlacement.ReadOnly = true;
            //    TextBoxPlacement.Text = "C0000001";
            //}
            #endregion

        }

        protected void ButtonUpgrade_Click(object sender, EventArgs e)
        {
            #region 旧逻辑
            //string Status = "1";
            //string OrgID = "1000";
            //HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            //HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            ////会员登录ID
            //string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            //var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);
            //String Guidid = memberrankguid_Action.GetGuidByMemLoginID(MemberLoginID);
            //DataTable table =
            //        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMember("'" + Guidid + "'");

            //if (TextBoxPlacement.Text != "")
            //{
            //    #region 选择区代表申请
            //    var orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            //    DataTable tabletwo;
            //    string ShopType = "";
                
            //    string Rankid = "";
            //    string ParentShopNo = "";

            //    if (memberGuid.Equals(MemberLevel.AGENT_MEMBER_ID))
            //    {
            //        tabletwo = orderaction.SearchOrderUpgradeQD(MemberLoginID);
            //        ShopType = "2";
                    
            //        Rankid = MemberLevel.AGENT_MEMBER_ID_two;
            //        ParentShopNo = "C0000001";
            //    }
            //    else if (memberGuid.Equals(MemberLevel.COMMUNITY_MEMBER_ID))
            //    {
            //        tabletwo = orderaction.SearchOrderUpgradeSQ(MemberLoginID);
            //        ShopType = "1";
                    
            //        Rankid = MemberLevel.COMMUNITY_MEMBER_ID_two;
            //        ParentShopNo = TextBoxPlacement.Text;
            //    }
            //    else
            //    {
            //        tabletwo = new DataTable();
            //    }
            //    if (tabletwo.Rows.Count > 0)
            //    {
            //        var builder = new StringBuilder();
            //        builder.Append("<?xml version='1.0' encoding='utf-8'?>");
            //        builder.Append("<Shop>");
            //        builder.Append("<Ver>1.0</Ver>");
            //        builder.Append("<ShopName>" + TextBoxName.Text + "</ShopName>"); //区代名称
            //        builder.Append("<OrgID>" + OrgID + "</OrgID>"); //
            //        builder.Append("<ShopType>" + ShopType + "</ShopType>"); //区代类型
            //        builder.Append("<Status>" + Status + "</Status>"); //


            //        builder.Append("<CustomerNo>" + table.Rows[0]["MemLoginNO"].ToString() + "</CustomerNo>"); //经销商编号

            //        builder.Append("<AddDate>" + DateTime.Now.ToString() + "</AddDate>"); //加入时间
            //        builder.Append("<RecommendCustomerNo></RecommendCustomerNo>"); //推荐人编号
            //        builder.Append("<ParentShopNo>" + ParentShopNo + "</ParentShopNo>"); //上级区代编号
            //        builder.Append("<Memo></Memo>"); //备注

            //        builder.Append("<Order>");
            //        builder.Append("<Ver>1.0</Ver>");
            //        builder.Append("<OrderNo>" + tabletwo.Rows[0]["OrderNumber"].ToString() + "</OrderNo>");
            //        builder.Append("<Status>1</Status>");
            //        builder.Append("<OrderType>4</OrderType>");
            //        builder.Append("<EntityType>shop</EntityType>");
            //        builder.Append("<EntityID>" + tabletwo.Rows[0]["MemLoginNO"].ToString() + "</EntityID>");
            //        builder.Append("<ApplyEntityTyp>shop</ApplyEntityTyp>");
            //        builder.Append("<ApplyEntityID>" + tabletwo.Rows[0]["ServiceAgent"].ToString() + "</ApplyEntityID>");
            //        builder.Append("<TotalPV></TotalPV>");
            //        builder.Append("<TotalMoney>" + tabletwo.Rows[0]["ProductPrice"].ToString() + "</TotalMoney>");
            //        builder.Append("<Memo></Memo>");
            //        builder.Append("<CreateTime>" + tabletwo.Rows[0]["CreateTime"].ToString() + "</CreateTime>");
            //        builder.Append("<CreateMan>" + tabletwo.Rows[0]["MemLoginNO"].ToString() + "</CreateMan>");
            //        builder.Append("</Order>");

            //        builder.Append("</Shop>");

            //        string info = builder.ToString();
            //        TJAPItwo.WebService webservice = new TJAPItwo.WebService();
            //        string returnResult = webservice.Operate("Shop", info);
            //        if (returnResult == "操作成功")
            //        {
            //            var Memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            //            Memaction.UpdateMemberRankGuid(MemberLoginID, Rankid);
            //            Memaction.UpdateMemberShopName(MemberLoginID,TextBoxName.Text);

            //            var messageInfo = new ShopNum1_MessageInfo
            //            {
            //                Guid = Guid.NewGuid(),
            //                Title = "会员升级成功",
            //                Type = "1",
            //                Content = "尊敬的" + MemberLoginID + ":您的会员成功升级为区代理!",
            //                MemLoginID = MemberLoginID,
            //                SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
            //                IsDeleted = 0
            //            };
            //            var usermessage = new List<string>
            //               {
            //                     MemberLoginID
            //               };
            //            ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
            //                                                                                          usermessage);
            //            Response.Write("<script>top.location='m_index.aspx?action=1';</script>");
            //        }
            //        else
            //        {
            //            Response.Write("<script>alert('" + returnResult + "！');</script>");

            //        }
            //    #endregion
            //    }
            //    else 
            //    {
            //        Response.Write("<script>alert('您的单笔订单不满足升级条件！');</script>");
            //    }

            //}
            //else
            //{
            //    Response.Write("<script>alert('推荐人和上级区代不能为空！');</script>");
            //}
#endregion

            string NewMemRank = string.Empty;
            string Message = string.Empty;
            string title=string.Empty;
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string memberRankGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);
            ShopNum1_MemberShip_Action memberShipAction =
                        (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable memshipChongFu = memberShipAction.SearchShipRepeatMemLoginID(MemberLoginID,3);
            DataTable GetMobile = memberShipAction.SearchShipRepeatMemLoginID(MemberLoginID,2);
            if (memshipChongFu.Rows.Count > 0)
            {
                Response.Write("<script>alert('您已在申请列表中，请耐心等待！');</script>");
            }
            else
            {
                if (memberRankGuid.ToLower().Equals(MemberLevel.AGENT_MEMBER_ID_two.ToLower()))
                {
                    NewMemRank = MemberLevel.AGENT_MEMBER_ID_three;
                    Message="您的区代理II会员申请已成功提交!";
                    title="区代理II申请成功！";
                }
                if (memberRankGuid.ToLower().Equals(MemberLevel.COMMUNITY_MEMBER_ID_two.ToLower()))
                {
                    NewMemRank = MemberLevel.COMMUNITY_MEMBER_ID_three;
                    Message = "您的社区店II会员申请已成功提交!";
                    title="社区店II申请成功！";
                }
                string LicenseImage=FileUpload(FileUploadLicenseImage, new Order().CreateOrderNumber(), MemberLoginID);
                string OrganizationImage = FileUpload(FileUploadOrganizationImage, new Order().CreateOrderNumber(), MemberLoginID);
                string RegistrationImage = FileUpload(FileUploadRegistrationImage, new Order().CreateOrderNumber(), MemberLoginID);
                string ShopImageone = FileUpload(FileUploadShopImageone, new Order().CreateOrderNumber(), MemberLoginID);
                string ShopImagetwo = FileUpload(FileUploadShopImagetwo, new Order().CreateOrderNumber(), MemberLoginID);
                string OpeningImage = FileUpload(FileUploadOpeningImage, new Order().CreateOrderNumber(), MemberLoginID);
                string IdentityCardImage = FileUpload(FileUploadIdentityCardImage, new Order().CreateOrderNumber(), MemberLoginID);

                memberShipAction.UpdateUpgradetwo(memberRankGuid, NewMemRank, LicenseImage, OrganizationImage,
                    RegistrationImage, ShopImageone, ShopImagetwo, OpeningImage, IdentityCardImage, MemberLoginID);
                var messageInfo = new ShopNum1_MessageInfo
                        {
                            Guid = Guid.NewGuid(),
                            Title = title,
                            Type = "1",
                            Content = "尊敬的" + MemberLoginID + ":"+Message,
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
                var sms = new SMS();
                                                    string retmsg = "";
                                                    sms.Send(GetMobile.Rows[0]["Mobile"].ToString(), "尊敬的" + MemberLoginID.Trim() + ":" + Message + "【唐江宝宝】", out retmsg);
                Response.Write("<script>top.location='m_index.aspx?action=2';</script>");


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
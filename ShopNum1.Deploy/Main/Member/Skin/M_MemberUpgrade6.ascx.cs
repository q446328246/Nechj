using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using System.Data;
using ShopNum1.Common.ShopNum1.Common;
using System.Text;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using ShopNum1.Factory;
using ShopNum1.Common;


namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MemberUpgrade6 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    ShopNum1_MemberShip_Action memShiaction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
        //    ShopNum1_OrderInfo_Action orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
        //    ShopNum1_Member_Action memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        //    HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        //    HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //    //会员登录ID
        //    string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
        //    DataTable tablemember = memaction.SearchMembertwo(MemberLoginID);
        //    if (tablemember.Rows[0]["MemberRankGuid"].ToString() == MemberLevel.COMMUNITY_MEMBER_ID)
        //    {
        //        #region 社区店I自动升级
        //        DataTable SQTable = orderaction.SearchOrderUpgradeSQ(MemberLoginID);
        //        if (SQTable.Rows.Count > 0)
        //        {
        //            DataTable ShipTable = memShiaction.SearchShipMemLoginNO(SQTable.Rows[0]["MemLoginNO"].ToString(), 2);
        //            var builder = new StringBuilder();
        //            builder.Append("<?xml version='1.0' encoding='utf-8'?>");
        //            builder.Append("<Shop>");
        //            builder.Append("<Ver>1.0</Ver>");
        //            builder.Append("<ShopName>" + ShipTable.Rows[0]["ShopNames"].ToString() + "</ShopName>"); //区代名称
        //            builder.Append("<OrgID>1000</OrgID>"); //
        //            builder.Append("<ShopType>1</ShopType>"); //区代类型
        //            builder.Append("<Status>1</Status>"); //


        //            builder.Append("<CustomerNo>" + ShipTable.Rows[0]["MemLoginNO"].ToString() + "</CustomerNo>"); //经销商编号

        //            builder.Append("<AddDate>" + DateTime.Now.ToString() + "</AddDate>"); //加入时间
        //            builder.Append("<RecommendCustomerNo></RecommendCustomerNo>"); //推荐人编号
        //            builder.Append("<ParentShopNo>" + ShipTable.Rows[0]["Belongs"].ToString() + "</ParentShopNo>"); //上级区代编号
        //            builder.Append("<Memo></Memo>"); //备注

        //            builder.Append("<Order>");
        //            builder.Append("<Ver>1.0</Ver>");
        //            builder.Append("<OrderNo>" + SQTable.Rows[0]["OrderNumber"].ToString() + "</OrderNo>");
        //            builder.Append("<Status>1</Status>");
        //            builder.Append("<OrderType>4</OrderType>");
        //            builder.Append("<EntityType>shop</EntityType>");
        //            builder.Append("<EntityID>" + SQTable.Rows[0]["MemLoginNO"].ToString() + "</EntityID>");
        //            builder.Append("<ApplyEntityTyp>shop</ApplyEntityTyp>");
        //            builder.Append("<ApplyEntityID>" + SQTable.Rows[0]["ServiceAgent"].ToString() + "</ApplyEntityID>");
        //            builder.Append("<TotalPV></TotalPV>");
        //            builder.Append("<TotalMoney>" + SQTable.Rows[0]["ShouldPayPrice"].ToString() + "</TotalMoney>");
        //            builder.Append("<Memo></Memo>");
        //            builder.Append("<CreateTime>" + SQTable.Rows[0]["CreateTime"].ToString() + "</CreateTime>");
        //            builder.Append("<CreateMan>" + SQTable.Rows[0]["MemLoginNO"].ToString() + "</CreateMan>");
        //            builder.Append("</Order>");

        //            builder.Append("</Shop>");

        //            string info = builder.ToString();
        //            TJAPItwo.WebService webservice = new TJAPItwo.WebService();
        //            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
        //            string privateKey_two = "Info=" + info + md5_one;
        //            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
        //            string returnResult = webservice.Operate("Shop", info, md5Check_two);

        //            if (returnResult == "操作成功")
        //            {

        //                memaction.UpdateMemberRankGuid(MemberLoginID, MemberLevel.COMMUNITY_MEMBER_ID_two);
        //                memaction.UpdateMemberShopName(MemberLoginID, ShipTable.Rows[0]["ShopNames"].ToString());
        //                var messageInfo = new ShopNum1_MessageInfo
        //                {
        //                    Guid = Guid.NewGuid(),
        //                    Title = "会员升级成功",
        //                    Type = "1",
        //                    Content = "尊敬的" + MemberLoginID.Trim() + ":您已经成功升级到社区店I！",
        //                    MemLoginID = MemberLoginID,
        //                    SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
        //                    IsDeleted = 0
        //                };
        //                var usermessage = new List<string>
        //                {
        //                    MemberLoginID
        //                };
        //                ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
        //                                                                                                     usermessage);

        //                //加个通过短信
        //                var sms = new SMS();
        //                string retmsg = "";
        //                sms.Send(ShipTable.Rows[0]["Mobile"].ToString(), "尊敬的" + MemberLoginID.Trim() + ":您已经成功升级到社区店I！" + "【唐江宝宝】", out retmsg);
        //            }
        //            else
        //            {
        //                Response.Write("<script>alert('" + returnResult + "请联系管理员！');</script>");


        //            }
        //        }
        //        else 
        //        {
        //            Response.Write("<script>alert('请您先下订单，再推送！');</script>");
        //        }
        //        #endregion
        //    }
        //    else if (tablemember.Rows[0]["MemberRankGuid"].ToString() == MemberLevel.AGENT_MEMBER_ID)
        //    {
        //        #region 区代理I自动升级
        //        DataTable QDTable = orderaction.SearchOrderUpgradeQD(MemberLoginID);
        //        if (QDTable.Rows.Count > 0)
        //        {

        //            DataTable ShipTable = memShiaction.SearchShipMemLoginNO(QDTable.Rows[0]["MemLoginNO"].ToString(), 2);
        //            var builder = new StringBuilder();
        //            builder.Append("<?xml version='1.0' encoding='utf-8'?>");
        //            builder.Append("<Shop>");
        //            builder.Append("<Ver>1.0</Ver>");
        //            builder.Append("<ShopName>" + ShipTable.Rows[0]["ShopNames"].ToString() + "</ShopName>"); //区代名称
        //            builder.Append("<OrgID>1000</OrgID>"); //
        //            builder.Append("<ShopType>2</ShopType>"); //区代类型
        //            builder.Append("<Status>1</Status>"); //


        //            builder.Append("<CustomerNo>" + ShipTable.Rows[0]["MemLoginNO"].ToString() + "</CustomerNo>"); //经销商编号

        //            builder.Append("<AddDate>" + DateTime.Now.ToString() + "</AddDate>"); //加入时间
        //            builder.Append("<RecommendCustomerNo></RecommendCustomerNo>"); //推荐人编号
        //            builder.Append("<ParentShopNo>" + ShipTable.Rows[0]["Belongs"].ToString() + "</ParentShopNo>"); //上级区代编号
        //            builder.Append("<Memo></Memo>"); //备注

        //            builder.Append("<Order>");
        //            builder.Append("<Ver>1.0</Ver>");
        //            builder.Append("<OrderNo>" + QDTable.Rows[0]["OrderNumber"].ToString() + "</OrderNo>");
        //            builder.Append("<Status>1</Status>");
        //            builder.Append("<OrderType>4</OrderType>");
        //            builder.Append("<EntityType>shop</EntityType>");
        //            builder.Append("<EntityID>" + QDTable.Rows[0]["MemLoginNO"].ToString() + "</EntityID>");
        //            builder.Append("<ApplyEntityTyp>shop</ApplyEntityTyp>");
        //            builder.Append("<ApplyEntityID>" + QDTable.Rows[0]["ServiceAgent"].ToString() + "</ApplyEntityID>");
        //            builder.Append("<TotalPV></TotalPV>");
        //            builder.Append("<TotalMoney>" + QDTable.Rows[0]["ShouldPayPrice"].ToString() + "</TotalMoney>");
        //            builder.Append("<Memo></Memo>");
        //            builder.Append("<CreateTime>" + QDTable.Rows[0]["CreateTime"].ToString() + "</CreateTime>");
        //            builder.Append("<CreateMan>" + QDTable.Rows[0]["MemLoginNO"].ToString() + "</CreateMan>");
        //            builder.Append("</Order>");

        //            builder.Append("</Shop>");

        //            string info = builder.ToString();
        //            TJAPItwo.WebService webservice = new TJAPItwo.WebService();
        //            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
        //            string privateKey_two = "Info=" + info + md5_one;


        //            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
        //            string returnResult = webservice.Operate("Shop", info, md5Check_two);

        //            if (returnResult == "操作成功")
        //            {

        //                memaction.UpdateMemberRankGuid(MemberLoginID, MemberLevel.AGENT_MEMBER_ID_two);
        //                memaction.UpdateMemberShopName(MemberLoginID, ShipTable.Rows[0]["ShopNames"].ToString());
        //                var messageInfo = new ShopNum1_MessageInfo
        //                {
        //                    Guid = Guid.NewGuid(),
        //                    Title = "会员升级成功",
        //                    Type = "1",
        //                    Content = "尊敬的" + MemberLoginID.Trim() + ":您已经成功升级到区代理I！",
        //                    MemLoginID = MemberLoginID,
        //                    SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
        //                    IsDeleted = 0
        //                };
        //                var usermessage = new List<string>
        //                {
        //                    MemberLoginID
        //                };
        //                ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo,
        //                                                                                                     usermessage);

        //                //加个通过短信
        //                var sms = new SMS();
        //                string retmsg = "";
        //                sms.Send(ShipTable.Rows[0]["Mobile"].ToString(), "尊敬的" + MemberLoginID.Trim() + ":您已经成功升级到区代理I！" + "【唐江宝宝】", out retmsg);
        //            }
        //            else
        //            {
        //                Response.Write("<script>alert('" + returnResult + "请联系管理员！');</script>");


        //            }
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('请您先下订单，再推送！');</script>");
        //        }
        //        #endregion
        //    }

        //}
    }
}
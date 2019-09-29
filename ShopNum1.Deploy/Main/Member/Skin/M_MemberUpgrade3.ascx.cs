using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using System.Data;
using System.Text;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MemberUpgrade3 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        //    HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //    //会员登录ID
        //    string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
        //    string memRankGuid = MemberLevel.VIP_MEMBER_ID_two;
        //    var updatememRankGuid = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
        //    var memberorser_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
        //    DataTable table = memberorser_Action.SearchOrderUpgrade(MemberLoginID);
        //    DataTable tableone = updatememRankGuid.SearchMembertwo(MemberLoginID);
        //    if (table!=null&&table.Rows.Count > 0)
        //    {
        //        string OrderType = "";//订单类型
                
        //        string EntityType = "customer";
                
        //        if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.大唐专区)
        //        {
        //            OrderType = "5";
        //        }
        //        if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.VIP专区)
        //        {
        //            OrderType = "2";
        //        }
        //        if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.区代专区1)
        //        {
        //            OrderType = "4";
        //        }
        //        if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.区代专区2)
        //        {
        //            OrderType = "3";
        //        }
        //        if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.社区店铺专区1)
        //        {
        //            OrderType = "4";
        //        }
        //        if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.社区店铺专区2)
        //        {
        //            OrderType = "3";
        //        }
        //        //订单
        //        string OrderNO = table.Rows[0]["OrderNumber"].ToString();

        //        string Status = "1";
        //        string EntityID = table.Rows[0]["MemLoginNO"].ToString();

        //        string ApplyEntityType = "shop";
        //        string ApplyEntityID = "888";
        //        string TotalPV = table.Rows[0]["Score_pv_a"].ToString();
        //        string TotalMoney = table.Rows[0]["ShouldPayPrice"].ToString();
        //        decimal total = Convert.ToDecimal(TotalMoney);
        //        decimal pv = Convert.ToDecimal(TotalPV);
        //        string Memo = table.Rows[0]["ShopName"].ToString();
        //        string CreateTime = table.Rows[0]["CreateTime"].ToString();
        //        DateTime order_date = Convert.ToDateTime(CreateTime);
        //        string CreateMan = table.Rows[0]["MemLoginNO"].ToString();
        //        string vip_user_no = table.Rows[0]["ShopID"].ToString();

        //        string PrvCityCountry = table.Rows[0]["Address"].ToString();
        //        string[] sArray = PrvCityCountry.Split(new char[2] { ',', ' ' });
        //        string prv = sArray[0];
        //        string city = sArray[1];
        //        string country = sArray[2];
        //        string shop_no = table.Rows[0]["ShopName"].ToString();
        //        string service_no = table.Rows[0]["ServiceAgent"].ToString();


        //        var builder = new StringBuilder();
        //        builder.Append("<?xml version='1.0' encoding='utf-8'?>");
        //        builder.Append("<Order>");
        //        builder.Append("<Ver>1.0</Ver>");

        //        builder.Append("<OrderNO>" + OrderNO + "</OrderNO>"); //订单编号 *
        //        builder.Append("<Status>" + Status + "</Status>"); //订单状态 // 0:未审核；1:已审核 * 
        //        builder.Append("<OrderType>5</OrderType>"); //1：注册单; 2:重消单；3：二次进货；4：首次进货； *
        //        builder.Append("<EntityType>" + EntityType + "</EntityType>"); //订单人类型 shop:区代 customer:会员 *
        //        builder.Append("<EntityID>" + EntityID + "</EntityID>"); //下订单人标识 *
        //        builder.Append("<ApplyEntityType>" + ApplyEntityType + "</ApplyEntityType>");
        //        builder.Append("<ApplyEntityID>" + service_no + "</ApplyEntityID>");
        //        builder.Append("<TotalPV>" + TotalPV + "</TotalPV>"); //总PV *
        //        builder.Append("<TotalMoney>" + TotalMoney + "</TotalMoney>"); //总金额*
        //        builder.Append("<Memo>" + Memo + "</Memo>");
        //        builder.Append("<CreateTime>" + CreateTime + "</CreateTime>"); //创建时间 *
        //        builder.Append("<CreateMan>" + CreateMan + "</CreateMan>"); //创建人 *
        //        builder.Append("<upgrade>60</upgrade>");
        //        builder.Append("</Order>");
        //        string info = builder.ToString();
        //        TJAPItwo.WebService webservice = new TJAPItwo.WebService();
        //        string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
        //        string privateKey_two = "Info=" + info + md5_one;
        //        string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
        //        string returnResult = webservice.Operate("SALE", info, md5Check_two);
        //        if (returnResult == "操作成功")
        //        {
        //            updatememRankGuid.UpdateMemberRankGuid(MemberLoginID, memRankGuid);
        //            Response.Write("<script>top.location='m_index.aspx?action=1';</script>");

        //        }
        //        else if (returnResult == "身份证号码重复")
        //        {
        //            Response.Write("<script>alert('身份证号码重复！');</script>");
        //        }
        //        else if (returnResult == "会员编号重复")
        //        {
        //            Response.Write("<script>alert('会员编号重复！');</script>");
        //        }
        //        else if (returnResult == "手机号码重复")
        //        {
        //            Response.Write("<script>alert('手机号码重复！');</script>");
        //        }
        //        else if (returnResult == "安置编号不存在")
        //        {
        //            Response.Write("<script>alert('服务专员不存在！');</script>");
        //        }
        //        else if (returnResult == "推荐编号不存在")
        //        {
        //            Response.Write("<script>alert('邀请人不正确！');</script>");
        //        }
        //        else if (returnResult == "安置编号不在推荐编号的安置网络中")
        //        {
        //            Response.Write("<script>alert('安置编号不在推荐编号的安置网络中！');</script>");
        //        }
        //        else if (returnResult == "订单所属服务网点不存在")
        //        {
        //            Response.Write("<script>alert('订单所属服务网点不存在！');</script>");
        //        }
        //        else if (returnResult == "服务区已满")
        //        {
        //            Response.Write("<script>alert('服务区已满！');</script>");
        //        }
        //        else if (returnResult == "系统错误")
        //        {
        //            Response.Write("<script>alert('系统错误！');</script>");
        //        }
        //        else if (returnResult != "操作成功" && returnResult != "身份证号码重复" && returnResult != "会员编号重复" && returnResult != "手机号码重复" && returnResult != "安置编号不存在" && returnResult != "推荐编号不存在" && returnResult != "安置编号不在推荐编号的安置网络中" && returnResult != "订单所属服务网点不存在" && returnResult != "服务区已满" && returnResult != "系统错误")
        //        {
        //            Response.Write("<script>alert('" + returnResult + "');</script>");
        //        }



        //    }
        //    else 
        //    {
        //        Response.Write("<script>alert('您未达到单笔订单积分12000的需求！当前所差积分为：" + (12000 - Convert.ToInt32(tableone.Rows[0]["Score_record _pv_a"])) + ",升级需要一次性补单!');</script>");
        //    }
        //}
    }
}
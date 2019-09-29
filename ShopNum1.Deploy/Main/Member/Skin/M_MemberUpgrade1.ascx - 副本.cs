using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;
using ShopNum1.Deploy.TJAPI;
using System.Text;
using System.Net;
using ShopNum1.Common.ShopNum1.Common;


namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MemberUpgrade1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonUpgrade_Click(object sender, EventArgs e)
        {
            if (TextBoxReferee.Text != "" && TextBoxPlacement.Text != "" && TextBoxbank.Text != "" && TextBoxbank_address.Text != "" && TextBoxaccount_no.Text != "" && TextBoxaccount_name.Text != "")
            {
                #region 升级会员
                HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
                //会员登录ID
                string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
                var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
                String memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);
                //string table2 = memberrankguid_Action.GetGuidByMemLoginID(MemberLoginID);
                String Guid = memberrankguid_Action.GetGuidByMemLoginID(MemberLoginID);
                DataTable table =
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMember("'" + Guid + "'");

                if (Convert.ToInt32(table.Rows[0]["Score_pv_a"]) > 300||Convert.ToInt32(table.Rows[0]["Score_pv_cv"]) > 12000)
                {
                    string memRankGuid = "E5EA79AC-A3E9-492B-9F86-9C7F8A48AA76";
                    var updatememRankGuid = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    
                    //记录推荐和安置人发送WebService
                    string intro_no = TextBoxReferee.Text;
                    string up_no = TextBoxPlacement.Text;
                    string no = table.Rows[0]["MemLoginNO"].ToString();
                    string name = table.Rows[0]["RealName"].ToString();
                    string nickname = table.Rows[0]["Name"].ToString();
                    string mobile = table.Rows[0]["Mobile"].ToString();
                    string id_card = table.Rows[0]["IdentityCard"].ToString();
                    string remark = "";
                    string password = table.Rows[0]["Pwd"].ToString();
                    DateTime add_date = DateTime.Now;
                    string bank = TextBoxbank.Text;
                    string bank_address = TextBoxbank_address.Text;
                    string account_no = TextBoxaccount_no.Text;
                    string account_name = TextBoxaccount_name.Text;
                    string message;
                    //测试用

                    //string no1 = "G0000055";
                    //string name1 = "GZaYYS";
                    //string mobile1 = "133333333333";
                    //string id_card1 = "12333";
                    //string intro_no1 = "C85302595";
                    //string up_no1 = "C6699999";
                    //string remark1 = "";
                    //string password1 = "111111";
                    //DateTime add_date1 = Convert.ToDateTime("2013-01-01 00:00:00");
                    //string nickname1 = "GZaYYS";
                    //string bank1 = "3";
                    //string bank_address1 = "4";
                    //string account_no1 = "5";
                    //string account_name1 = "6";
                    //接口2
                    var builder = new StringBuilder();
                    builder.Append("<?xml version='1.0' encoding='utf-8'?>\r\n");
                    builder.Append("<Customer>\r\n");
                    builder.Append("<Ver>1.0</Ver>\r\n");
                    builder.Append("<CustomerNO>" + no + "</CustomerNO>\r\n");
                    builder.Append("<FullName>" + name + "</FullName>\r\n");
                    builder.Append("<Mobile>" + mobile + "</Mobile>\r\n");
                    builder.Append("<CardNO>" + id_card + "</CardNO>\r\n");
                    builder.Append("<RecommendNo>" + intro_no + "</RecommendNo>\r\n");
                    builder.Append("<ParentNo>" + up_no + "</ParentNo>\r\n");
                    builder.Append("<Memo>" + remark + "</Memo>\r\n");
                    builder.Append("<Password>" + password + "</Password>\r\n");
                    builder.Append("<AddDate>" + add_date.ToString() + "</AddDate>\r\n");
                    builder.Append("<NickName>" + nickname + "</NickName>\r\n");
                    builder.Append("<Bank>" + bank + "</Bank>\r\n");
                    builder.Append("<Branch>" + bank_address + "</Branch>\r\n");
                    builder.Append("<AccountNo>" + account_no + "</AccountNo>\r\n");
                    builder.Append("<AccountName>" + account_name + "</AccountName>\r\n");
                    builder.Append("</Customer>\r\n");
                    string info = builder.ToString();
                    //TJAPItwo.WebService webservice = new TJAPItwo.WebService();
                    //string returnResult = webservice.Operate("Customer", info);
                   
                    
                    //接口1
                    //string user_no = no1;
                    //string passworda = password1;
                    byte[] bytes = Encoding.Default.GetBytes(password);
                    string str=Convert.ToBase64String(bytes);
                    string result = ShopNum1.Common.Encryption.GetMd5Hash(str);
                    //string str1 = user_no +"."+ str;
                    //byte[] data = System.Text.Encoding.Unicode.GetBytes(str1);
                    //System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    //string result = md5.ComputeHash(str1);



                    City api = new City();




                    api.AddUser(no, name, nickname, mobile, id_card, intro_no, up_no, remark, password, bank, bank_address, account_no, account_name, add_date, result, out message);
                    if (message == "操作成功") 
                    {

                        updatememRankGuid.UpdateMemberRankGuid(MemberLoginID, memRankGuid);
                        Response.Write("<script>alert('恭喜您成功升级为VIP会员！');</script>");


                        #region 升级成功，发送以前所有订单
                        var orderinfoaction = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
                        DataTable orderset = orderinfoaction.GetOrderLastInfo(MemberLoginID);

                        foreach (DataRow dr in orderset.Rows)
                            {

                                string messagetwo = "";
                                string OrderType = "";//订单类型
                                string EntityType = "";//会员类型
                                if (dr["MemberRankGuid"].ToString() == MemberLevel.NORMAL_MEMBER_ID || dr["MemberRankGuid"].ToString() == MemberLevel.VIP_MEMBER_ID)
                                {
                                    EntityType = "customer";
                                }
                                if (dr["MemberRankGuid"].ToString() == MemberLevel.COMMUNITY_MEMBER_ID || dr["MemberRankGuid"].ToString() == MemberLevel.AGENT_MEMBER_ID)
                                {
                                    EntityType = "shop";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.大唐专区)
                                {
                                    OrderType = "1";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.VIP专区)
                                {
                                    OrderType = "2";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.区代专区1)
                                {
                                    OrderType = "4";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.区代专区2)
                                {
                                    OrderType = "3";
                                }
                                //订单
                                string OrderNO = dr["OrderNumber"].ToString();
                                string Status = "1";
                                string EntityID = dr["MemLoginNO"].ToString();
                                string ApplyEntityType = "shop";
                                string ApplyEntityID = "888";
                                string TotalPV = dr["Score_pv_a"].ToString();
                                string TotalMoney = dr["ShouldPayPrice"].ToString();
                                decimal total = Convert.ToDecimal(TotalMoney);
                                decimal pv = Convert.ToDecimal(TotalPV);
                                string Memo = dr["ShopName"].ToString(); ;
                                string CreateTime = dr["CreateTime"].ToString();
                                DateTime order_date = Convert.ToDateTime(CreateTime);
                                string CreateMan = dr["MemLoginNO"].ToString();
                                string vip_user_no = dr["ShopID"].ToString();

                                string PrvCityCountry = dr["Address"].ToString();
                                string[] sArray = PrvCityCountry.Split(new char[2] { ',', ' ' });
                                string prv = sArray[0];
                                string city = sArray[1];
                                string country = sArray[2];
                                string shop_no = dr["ShopName"].ToString();
                                string service_no = dr["ServiceAgent"].ToString(); 


                                var buildertwo = new StringBuilder();
                                buildertwo.Append("<?xml version='1.0' encoding='gb2312'?>\r\n");
                                buildertwo.Append("<Order>\r\n");
                                buildertwo.Append("<Ver>1.0</Ver>\r\n");

                                buildertwo.Append("<OrderNO>" + OrderNO + "</OrderNO>\r\n"); //订单编号 *
                                buildertwo.Append("<Status>" + Status + "</Status>\r\n"); //订单状态 // 0:未审核；1:已审核 * 
                                buildertwo.Append("<OrderType>" + OrderType + "</OrderType>\r\n"); //1：注册单; 2:重消单；3：二次进货；4：首次进货； *
                                buildertwo.Append("<EntityType>" + EntityType + "</EntityType>\r\n"); //订单人类型 shop:区代 customer:会员 *
                                buildertwo.Append("<EntityID>" + EntityID + "</EntityID>\r\n"); //下订单人标识 *
                                buildertwo.Append("<ApplyEntityType>" + ApplyEntityType + "</ApplyEntityType>\r\n");
                                buildertwo.Append("<ApplyEntityID>" + ApplyEntityID + "</ApplyEntityID>\r\n");
                                buildertwo.Append("<TotalPV>" + TotalPV + "</TotalPV>\r\n"); //总PV *
                                buildertwo.Append("<TotalMoney>" + TotalMoney + "</TotalMoney>\r\n"); //总金额*
                                buildertwo.Append("<Memo>" + Memo + "</Memo>\r\n");
                                buildertwo.Append("<CreateTime>" + CreateTime + "</CreateTime>\r\n"); //创建时间 *
                                buildertwo.Append("<CreateMan>" + CreateMan + "</CreateMan>\r\n"); //创建人 *

                                buildertwo.Append("</Order>\r\n");
                                string infotwo = builder.ToString();
                                //TJAPItwo.WebService webservice = new TJAPItwo.WebService();
                                //string returnResulttwo = webservice.Operate("SALE", infotwo);

                                
                                byte[] bytestwo = Encoding.Default.GetBytes(OrderNO);
                                string strtwo = Convert.ToBase64String(bytestwo);
                                string str1two = EntityID + strtwo;
                                string resulttwo = ShopNum1.Common.Encryption.GetMd5Hash(str1two);
                                
                                api.AddConsumeOrder(OrderNO, EntityID, order_date, total, pv, vip_user_no, prv, city, country, Memo, Status, service_no, shop_no, resulttwo, out messagetwo);

                            

                        }
                        #endregion


                    }
                    if (message == "身份认证失败")
                    {
                        Response.Write("<script>alert('身份认证失败！');</script>");
                    }
                    if (message == "会员编号重复")
                    {
                        Response.Write("<script>alert('会员编号重复！');</script>");
                    }
                    if (message == "安置编号不存在")
                    {
                        Response.Write("<script>alert('服务专员不存在！');</script>");
                    }
                    if (message == "推荐编号不存在")
                    {
                        Response.Write("<script>alert('邀请人不正确！');</script>");
                    }
                    if (message == "会员编号不存在")
                    {
                        Response.Write("<script>alert('此会员不存在！');</script>");
                    }
                    if (message == "订单号重复")
                    {
                        Response.Write("<script>alert('订单号重复！');</script>");
                    }
                    if (message == "安置人已满")
                    {
                        Response.Write("<script>alert('服务区已满！');</script>");
                    }

                    



                   
                }
                else
                {
                    Response.Write("<script>alert('对不起，您的A积分未满足大于300或者C积分为满足大于12000！');</script>");
                }
                #endregion}
            }
            else
            {
                Response.Write("<script>alert('所有条目均不能为空！');</script>");
            }
        }

        public string GetMD5(string sDataIn, string move)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(move + sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("x").PadLeft(2, '0');
            }
            return sTemp;
        }
    }
}
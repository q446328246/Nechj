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

            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            var orderinfoaction1 = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = action.SearchMembertwo(MemberLoginID);
            Name.Text = table.Rows[0]["Name"].ToString();
            RealName.Text = table.Rows[0]["RealName"].ToString();
            DataTable orderset1 = orderinfoaction1.GetOrderLastInfoShopName(table.Rows[0]["MemLoginNO"].ToString());
            DataTable SelectSuperior = orderinfoaction1.SelectSuperior(MemberLoginID);
            if (SelectSuperior.Rows[0]["Superior"].ToString()!=""||SelectSuperior.Rows[0]["Superior"].ToString()!=null)
            {
                TextBoxReferee.Text = SelectSuperior.Rows[0]["Superior"].ToString().Trim();
                TextBoxReferee.ReadOnly = true;

            }
            else
            {
                TextBoxReferee.Text = "";
                TextBoxReferee.ReadOnly = false;
                
            }

            if (!Page.IsPostBack)
            {
                DropDownListLiShu.DataSource = orderset1;
                DropDownListLiShu.DataTextField = "ShopNames";
                DropDownListLiShu.DataValueField = "ServiceAgent";
                DropDownListLiShu.DataBind();
            }
        }

        protected void ButtonUpgrade_Click(object sender, EventArgs e)
        {


            ShopNum1_Referral_Action Referral_Action = (ShopNum1_Referral_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Referral_Action();

            if (TextBoxReferee.Text != "" && TextBoxbank.Text != "" && TextBoxbank_address.Text != "" && TextBoxaccount_no.Text != "" && TextBoxaccount_name.Text != "" && TextBoxPlacement.Text != "")
            {
                //
                //ShopNum1_Referral referral = new ShopNum1_Referral();
                //referral.AccountName = TextBoxaccount_name.Text;
                //referral.Agent = DropDownListLiShu.SelectedValue;
                //referral.BankBranch = TextBoxbank_address.Text;
                //referral.BankID = TextBoxaccount_no.Text;
                //referral.BankName = TextBoxbank.Text;
                //referral.MemloginID = TextBoxReferee.Text;

                //Referral_Action.Add(referral);
                if (RealName.Text != null && RealName.Text != "")
                {
                    if (Name.Text != null && Name.Text != "")
                    {

                        #region 升级会员
                        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
                        //会员登录ID
                        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
                        var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
                        var orderinfoaction = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
                        String memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);
                        //string table2 = memberrankguid_Action.GetGuidByMemLoginID(MemberLoginID);
                        String Guid = memberrankguid_Action.GetGuidByMemLoginID(MemberLoginID);
                        DataTable table =
                            ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMemberGuid(Guid);
                        DataTable tableno = memberrankguid_Action.SearchMembertwo(MemberLoginID);
                        DataTable orderset = orderinfoaction.GetOrderLastInfo(tableno.Rows[0]["MemLoginNO"].ToString());

                        if (Convert.ToInt32(table.Rows[0]["Score_pv_a"]) >= 300 || Convert.ToInt32(table.Rows[0]["Score_pv_cv"]) > 1)
                        {
                            string memRankGuid = "";
                            string LevelInt = "";
                            //if (Convert.ToInt32(table.Rows[0]["Score_pv_a"]) >= 300 && Convert.ToInt32(table.Rows[0]["Score_pv_a"]) < 12000 && Convert.ToInt32(table.Rows[0]["Score_pv_cv"]) < 1)
                            if (Convert.ToInt32(table.Rows[0]["Score_pv_a"]) >= 300)
                            {
                                memRankGuid = MemberLevel.VIP_MEMBER_ID;
                                LevelInt = "1";
                            }
                            if (Convert.ToInt32(table.Rows[0]["Score_pv_a"]) >= 12000 && (Convert.ToDateTime(table.Rows[0]["RegeDate"])).AddDays(60) > DateTime.Now)
                            {
                                memRankGuid = MemberLevel.VIP_MEMBER_ID_two;
                                LevelInt = "2";
                            }

                            var updatememRankGuid = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

                            //记录推荐和安置人发送WebService
                            string intro_no = TextBoxReferee.Text.Trim();
                            string up_no = TextBoxPlacement.Text.Trim();
                            string no = table.Rows[0]["MemLoginNO"].ToString();
                            string name = table.Rows[0]["RealName"].ToString();
                            string sex = "1";
                            string nickname = table.Rows[0]["Name"].ToString();
                            string mobile = table.Rows[0]["Mobile"].ToString();
                            string id_card = table.Rows[0]["IdentityCard"].ToString();
                            int Score_pv_a = Convert.ToInt32(table.Rows[0]["Score_pv_a"]);
                            string remark = "";
                            string password = table.Rows[0]["Pwd"].ToString();
                            DateTime add_date = DateTime.Now;
                            string addtime = add_date.ToString();
                            string bank = TextBoxbank.SelectedValue;
                            string bank_address = TextBoxbank_address.Text.Trim();
                            string account_no = TextBoxaccount_no.Text.Trim();
                            string account_name = TextBoxaccount_name.Text.Trim();
                            string message;







                            #region 升级成功，发送以前所有订单



                            string info = "<MemberOrders>";
                            foreach (DataRow dr in orderset.Rows)
                            {

                                string messagetwo = "";
                                string OrderType = "";//订单类型
                                string EntityType = "";//会员类型

                                if (dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.COMMUNITY_MEMBER_ID.ToUpper() || dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.AGENT_MEMBER_ID.ToUpper() || dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper() || dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.VIP_MEMBER_ID.ToUpper() || dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.VIP_MEMBER_ID_two.ToUpper())
                                {
                                    EntityType = "customer";
                                }
                                if (dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.AGENT_MEMBER_ID_three.ToUpper() || dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.COMMUNITY_MEMBER_ID_three.ToUpper() || dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.AGENT_MEMBER_ID_two.ToUpper() || dr["MemberRankGuid"].ToString().ToUpper() == MemberLevel.COMMUNITY_MEMBER_ID_two.ToUpper())
                                {
                                    EntityType = "shop";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.大唐专区)
                                {
                                    OrderType = "0";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.VIP专区)
                                {
                                    OrderType = "1";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.区代专区1)
                                {
                                    OrderType = "1";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.区代专区2)
                                {
                                    OrderType = "1";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.社区店铺专区1)
                                {
                                    OrderType = "1";
                                }
                                if (Convert.ToInt32(dr["shop_category_id"]) == (int)CustomerCategory.社区店铺专区2)
                                {
                                    OrderType = "1";
                                }
                                //订单
                                string OrderNO = dr["OrderNumber"].ToString();

                                string EntityID = dr["MemLoginNO"].ToString();
                                string ApplyEntityType = "shop";

                                #region 计算PV
                                decimal GeneralPV = Convert.ToDecimal(dr["Score_pv_a"]) + (Convert.ToDecimal(dr["Score_pv_b"]) - Convert.ToDecimal(dr["Offset_pv_b"]));
                                #endregion
                                string TotalPV = GeneralPV.ToString();
                                #region 计算Money
                                decimal GeneralMoney = Convert.ToDecimal(dr["ShouldPayPrice"]) - Convert.ToDecimal(dr["Offset_pv_b"]);

                                #endregion
                                string TotalMoney = GeneralMoney.ToString();
                                decimal total = Convert.ToDecimal(TotalMoney);
                                decimal pv = Convert.ToDecimal(TotalPV);
                                string Memo = dr["ShopName"].ToString(); ;

                                string order_date = DateTime.Now.ToString();
                                string CreateMan = dr["MemLoginNO"].ToString();
                                string vip_user_no = dr["ShopID"].ToString();

                                string PrvCityCountry = dr["Address"].ToString();

                                string shop_no = dr["ShopName"].ToString();
                                string service_no = DropDownListLiShu.SelectedValue;


                                StringBuilder buildertwo = new StringBuilder();
                                buildertwo.Append("<MemberOrder>");


                                buildertwo.Append("<Number>" + no.Trim().ToUpper() + "</Number>"); //订单编号 *
                                buildertwo.Append("<Name>" + nickname.Trim() + "</Name>"); //会员姓名
                                buildertwo.Append("<OrderID>" + OrderNO.Trim() + "</OrderID>"); //订单编号
                                buildertwo.Append("<TotalMoney>" + TotalMoney.Trim() + "</TotalMoney>"); //总金额
                                buildertwo.Append("<TotalPv>" + TotalPV.Trim() + "</TotalPv>"); //总PV
                                buildertwo.Append("<IsAgain>0</IsAgain>"); //是否首单(0:首单 1：升级单)
                                buildertwo.Append("<OrderType>" + OrderType.Trim() + "</OrderType>"); //订单类型(0：资格订单 1：重消订单)OrderDate
                                buildertwo.Append("<OrderDate>" + order_date.Trim() + "</OrderDate>"); //创建时间 *
                                buildertwo.Append("</MemberOrder>");

                                info = info + buildertwo.ToString();


                            }
                            string infotwo = info + "</MemberOrders>";
                            string memberorders = System.Web.HttpUtility.HtmlEncode(infotwo);


                            #endregion
                            TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
                            TJAPIzhuliang.MemberService webservice = new TJAPIzhuliang.MemberService();
                            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                            string privateKey_two = "Number=" + no.Trim().ToUpper() + "&Placement=" + up_no.Trim() + "&Direct=" + intro_no.Trim() + "&LevelInt=" + LevelInt.Trim() + "&Name=" + name.Trim() + "&Sex=" + sex.Trim() + "&MobileTele=" + mobile.Trim() + "&PaperNumber=" + id_card.Trim() + "&BankName=" + bank.Trim() + "&BankAddress=" + bank_address.Trim() + "&BankCard=" + account_no.Trim() + "&strBankBook=" + account_name.Trim() + "&RegisterDate=" + addtime.Trim() + "&PetName=" + name.Trim() + "&MemberOrders=" + memberorders + md5_one.Trim();
                            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                            string returnResult = mms.MemberInfo(no.Trim().ToUpper(), up_no.Trim(), intro_no.Trim(), LevelInt.Trim(), name.Trim(), sex.Trim(), mobile.Trim(), id_card.Trim(), bank.Trim(), bank_address.Trim(), account_no.Trim(), account_name.Trim(), addtime.Trim(), name.Trim(), memberorders, md5Check_two);



                            if (returnResult.ToUpper() == "Success".ToUpper())
                            {
                                String memberGuidTWO = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);
                                if (memberGuidTWO != MemberLevel.VIP_MEMBER_ID_two) 
                                {
                                    updatememRankGuid.UpdateMemberRankGuid(MemberLoginID, memRankGuid);
                                }

                                
                                updatememRankGuid.UpdateMemberRecordPva(MemberLoginID, Score_pv_a, DateTime.Now);
                                Response.Write("<script>top.location='m_index.aspx?action=1';</script>");





                            }
                            else if (returnResult == "身份证号码重复")
                            {
                                Response.Write("<script>alert('身份证号码重复！');</script>");
                            }
                            else if (returnResult == "会员编号重复")
                            {
                                Response.Write("<script>alert('会员编号重复！');</script>");
                            }
                            else if (returnResult == "手机号码重复")
                            {
                                Response.Write("<script>alert('手机号码重复！');</script>");
                            }
                            else if (returnResult == "安置编号不存在")
                            {
                                Response.Write("<script>alert('服务专员不存在！');</script>");
                            }
                            else if (returnResult == "推荐编号不存在")
                            {
                                Response.Write("<script>alert('邀请人不正确！');</script>");
                            }
                            else if (returnResult == "安置编号不在推荐编号的安置网络中")
                            {
                                Response.Write("<script>alert('安置编号不在推荐编号的安置网络中！');</script>");
                            }
                            else if (returnResult == "订单所属服务网点不存在")
                            {
                                Response.Write("<script>alert('订单所属服务网点不存在！');</script>");
                            }
                            else if (returnResult == "服务区已满")
                            {
                                Response.Write("<script>alert('服务区已满！');</script>");
                            }
                            else if (returnResult == "系统错误")
                            {
                                Response.Write("<script>alert('系统错误！');</script>");
                            }
                            else if (returnResult != "操作成功" && returnResult != "身份证号码重复" && returnResult != "会员编号重复" && returnResult != "手机号码重复" && returnResult != "安置编号不存在" && returnResult != "推荐编号不存在" && returnResult != "安置编号不在推荐编号的安置网络中" && returnResult != "订单所属服务网点不存在" && returnResult != "服务区已满" && returnResult != "系统错误")
                            {
                                Response.Write("<script>alert('" + returnResult + "');</script>");
                                
                            }






                        }
                        else
                        {
                            Response.Write("<script>alert('对不起，您的A积分未满足大于1200或者C积分为满足大于12000！');</script>");
                        }
                        #endregion}
                    }
                    else
                    {
                        Response.Write("<script>alert('会员昵称不能为空！请到账户管理=>会员个人信息中修改会员昵称！');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('会员姓名不能为空！请联系客服');</script>");
                }
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

        //public static string Md5JiaMi(string strPwd)
        //{

        //    string cl = strPwd;
        //    string pwd = "";
        //    MD5 md5 = new MD5CryptoServiceProvider();//实例化一个md5对像
        //    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
        //    byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
        //    // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

        //        pwd += Convert.ToString(s[i], 16).PadLeft(2, '0');

        //    }



        //    return pwd.PadLeft(32, '0');


        //}
        //public static string MyMd5JiaMi = "123456";
    }
}
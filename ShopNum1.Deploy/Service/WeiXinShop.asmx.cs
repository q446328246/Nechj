using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ShopNum1.BusinessLogic;
using System.Data;
using ShopNum1.Deploy.MobileServiceAPP;
using ShopNum1.Factory;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// WeiXinShop 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]

    public class WeiXinShop : System.Web.Services.WebService
    {
        String SETMONEYBYID_ERROR01 = "待绑定的会员工号不存在或密码不正确。";
        String SETMONEYBYID_ERROR02 = "本微信已进行过一次绑定，请勿重复炒作。";
        String SETMONEYBYID_ERROR03 = "绑定成功，请退出本页面，祝您购物愉快！";
        String SETMONEYBYID_ERROR04 = "绑定操作进行失败，请联系客服咨询。";
        String SETMONEYBYID_ERROR05 = "待绑定的会员工号已经绑定其它微信不可重复绑定。";
        String SETMONEYBYID_ERROR06 = "普通会员不能绑定微信商城哟。";
        //绑定微信号
        [WebMethod]
        public string BoundWeiXin(string Mobile, string WinMemLoginID, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Mobile=" + Mobile + "&WinMemLoginID=" + WinMemLoginID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable MemberTable = member_Action.GetALLMobileALLl(Mobile);
            if (MemberTable.Rows.Count > 0)
            {
                DataTable WinMemLoginIDTable = member_Action.SelectWinMemLoginID(WinMemLoginID);
                if (WinMemLoginIDTable.Rows.Count > 0)
                {
                    return SETMONEYBYID_ERROR02;
                }
                else
                {
                    if (member_Action.SelectWeiXinMemLoginNO(MemberTable.Rows[0]["MemLoginNO"].ToString()).Rows.Count > 0)
                    {
                        return SETMONEYBYID_ERROR05;
                    }
                    else
                    {
                        DateTime newdate = System.DateTime.Now;

                     int   getnum = member_Action.InsertWeixinMember(MemberTable.Rows[0]["MemLoginNO"].ToString(), WinMemLoginID, newdate);
                        

                        if (getnum != 0)
                        {
                            return SETMONEYBYID_ERROR03;
                        }
                        else
                        {
                            return SETMONEYBYID_ERROR04;
                        }
                    }

                }
            }
            else
            {
                return SETMONEYBYID_ERROR01;
            }
            }
            else
            {
                return "加密串对比失败!";
            }

        }
        //查询我们这面是不是存在了这个opnenid
        [WebMethod]
        public string SelectMobile(string Mobile, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Mobile=" + Mobile  + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            DataTable WinMemLoginIDTable = member_Action.GetALLMobileALLl(Mobile);
            if (WinMemLoginIDTable.Rows.Count > 0)
            {
                return "1";
            }
            else
            {

                return "不能存在这个手机号";
            }
            }
            else
            {
                return "加密串对比失败!";
            }


        }
        //创建微信号在TJ88
        [WebMethod]
        public string CreateWeiXin(string MemLoginNO, string WinMemLoginID, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "MemLoginNO=" + MemLoginNO + "&WinMemLoginID=" + WinMemLoginID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                DataTable WinMemLoginIDTable = member_Action.SelectWinMemLoginID(WinMemLoginID);
                if (WinMemLoginIDTable.Rows.Count > 0)
                {
                    return SETMONEYBYID_ERROR02;
                }
                else
                {
                    if (member_Action.SelectWeiXinMemLoginNO(MemLoginNO).Rows.Count > 0)
                    {
                        return SETMONEYBYID_ERROR05;
                    }
                    else
                    {
                        DateTime newdate = System.DateTime.Now;

                        int getnum = member_Action.InsertWeixinMember(MemLoginNO, WinMemLoginID, newdate);


                        if (getnum != 0)
                        {
                            return SETMONEYBYID_ERROR03;
                        }
                        else
                        {
                            return SETMONEYBYID_ERROR04;
                        }
                    }

                }

            }
            else
            {
                return "加密串对比失败!";
            }
        }
        ////查询是不是520
        //[WebMethod]
        //public string SelecteIs520Member(string memberloginNO)
        //{

        //    ShengZhenCreateOrder cnfirmOrderAPP = new ShengZhenCreateOrder();


        //    DataTable Is520Membertable = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectIs520MemberBymemberloginid(memberloginNO);
          
        //    try
        //    {


        //        if (Is520Membertable.Rows[0]["Is520Member"].ToString() != "0")
        //        {
        //            return Is520Membertable.Rows[0]["Is520Member"].ToString();
        //        }
        //        else
        //        {
        //            return "0";
        //        }



        //    }
        //    catch
        //    {

        //        return "3";

        //    }



        //}
        ////修改520为1
        //[WebMethod]
        //public string UpdateIs520MemberBymemberloginid(string memberloginNO)
        //{

        //    ShengZhenCreateOrder cnfirmOrderAPP = new ShengZhenCreateOrder();


        //    int Is520Membertable = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateIs520MemberBymemberloginid(memberloginNO);

        //    try
        //    {


        //        if (Is520Membertable != 0)
        //        {
        //            return "1";
        //        }
        //        else
        //        {
        //            return "0";
        //        }



        //    }
        //    catch
        //    {

        //        return "3";

        //    }



        //}
        //随机c会员
        [WebMethod]
        public string MemberRegisterMemberGetMemberNumber()
        {



            try
            {
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


                return action.GetMemberNumber();


            }
            catch
            {

                return "0";
            }


        }
        //注册C会员
        [WebMethod]
        public string MemberRegisterMember(string memloginid, string Email, string Mobile, string Name, string recommendid, string IdentityCard, string Pwd, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memloginNO=" + memloginid + "&email=" + Email + "&Mobile=" + Mobile + "&Name=" + Name + "&recommendid=" + recommendid + "&IdentityCard=" + IdentityCard + "&Pwd=" + Pwd + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            SignIn SignIn2 = new SignIn();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    string order = SignIn2.MemberRegisterMember(memloginid, Email, Mobile, Name, recommendid, IdentityCard, Pwd);
                    switch (order)
                    {
                        case "0":
                            return "会员已存在!";
                        case "1":
                            return "推荐人不能没有";
                        case "2":
                            return "真实姓名为空";
                        case "3":
                            return "推荐人错误!";
                        case "4":
                            return "身份证已存在!";
                        case "5":

                            return "注册失败!";
                        case "7":
                            var sMS = new SMS();
                            string text5 = "";
                            sMS.Send(Mobile.Trim(), "您已经成功注册唐江巴巴会员，您的工号是：" + memloginid + "您的密码是：" + Pwd + "祝您购物愉快！" + "【唐江巴巴】", out text5);
                            return "注册成功!";
                        default:
                            return "出现了错误!";

                    }


                }
                catch
                {
                    return "出现错误了,出现了异常!";

                }

            }
            else
            {
                return "加密串对比失败!";
            }


        }

        //查询推荐人是否存在
        [WebMethod]
        public string selectSuperior(string MemberloingNO)
        {



            try
            {
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();





                if (MemberloingNO == "" || string.IsNullOrEmpty(MemberloingNO))
                {

                    return "0";
                }
                DataTable rank = action.selectGETMemberloginID_MemberloingNO(MemberloingNO);
                if (rank.Rows.Count > 0)
                {
                    //if (rank.Rows[0]["Is520Member"].ToString() != "1" && rank.Rows[0]["Is520Member"].ToString() != "0") 
                    //{
                        string ccRank = rank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                        if (ccRank == MemberLevel.NORMAL_Regular_Members.ToUpper())
                        {

                            return "2";
                        }
                        else
                        {
                            return "1";
                        }
                    //}
                    //else
                    //{
                    //    return "3";
                    //}

                }
                else
                {

                    return "4";
                }


            }
            catch
            {

                return "0";
            }


        }

        //查询自己的工号
        [WebMethod]
        public string selectMyMemberloingNO(string WinMemLoginID)
        {

            try
            {
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


                DataTable weixin = action.selectGETWinMemLoginIDByMemberloingNO(WinMemLoginID);

                if (weixin != null && weixin.Rows.Count > 0)
                {
                    return weixin.Rows[0]["MemLoginNO"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch
            {

                return "0";
            }


        }
        //查询自己红包
        [WebMethod]
        public string selectMyHV(string WinMemLoginID)
        {

            try
            {
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


                DataTable weixin = action.selectGETHVByMemberloingNO(WinMemLoginID);

                if (weixin != null && weixin.Rows.Count > 0)
                {
                    return weixin.Rows[0]["Score_hv"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch
            {

                return "0";
            }


        }

        //返回自己的银行卡信息
        [WebMethod]
        public DataTable selectMyMemberAll(string WinMemLoginID, string md5)
        {
            DataTable kong = new DataTable();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memloginNO=" + WinMemLoginID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            SignIn SignIn2 = new SignIn();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


                    DataTable weixin = action.selectGETMemberBank(WinMemLoginID);

                    if (weixin != null && weixin.Rows.Count > 0)
                    {
                        return weixin;
                    }
                    else
                    {
                        return kong;
                    }
                }
                catch
                {

                    return kong;
                }

            }
            else
            {
                return kong;
            }
        }

        //创建订单
        [WebMethod]
        public string CreateOrder(string OrderID, string OpenID, int ShopCategoryID, int PayMentType, string ProductId, int BuyNumber, decimal PostPrice, string Color, string Size, string TextBoxMessage, string Name, string Email, string Address, string Tel, string Mobile, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OrderID=" + OrderID + "&OpenID=" + OpenID + "&ShopCategoryID=" + ShopCategoryID + "&PayMentType=" + PayMentType + "&ProductId=" + ProductId + "&BuyNumber=" + BuyNumber + "&PostPrice=" + PostPrice + "&Color=" + Color + "&Size=" + Size + "&TextBoxMessage=" + TextBoxMessage + "&Name=" + Name + "&Email=" + Email + "&Address=" + Address + "&Tel=" + Tel + "&Mobile=" + Mobile + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            SignIn SignIn2 = new SignIn();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    WeiXinService weixin = new WeiXinService();
                    string order = weixin.CreateOrder(OrderID, OpenID, ShopCategoryID, PayMentType, ProductId, BuyNumber, PostPrice, Color, Size, TextBoxMessage, Name, Email, Address, Tel, Mobile);

                    switch (order)
                    {
                        case "1":

                            return "购买失败";

                        case "2":

                            return "请填写正确的服务商";

                        case "3":

                            return "支付方式不能为空";

                        case "4":

                            return "价格应处于￥105700-￥106300之间";

                        case "5":

                            return "价格应该处于￥35900-￥36100之间";

                        case "6":

                            return "收货地址错误";

                        case "7":

                            return "支付方式错误";

                        case "8":

                            return "很抱歉,抢购商品一个ID限购一件！";

                        case "9":

                            return "很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！";


                        default:
                            return "1";


                    }


                }
                catch
                {
                    return "出现错误了,出现了异常!";

                }

            }
            else
            {
                return "加密串对比失败!";
            }


        }

        //查询他所有的下家
        [WebMethod]
        public DataTable selectGETmemBySuperior(string OpenID, string md5, string state)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "openID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            SignIn SignIn2 = new SignIn();
            DataTable kong = new DataTable();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

                    DataTable membertable = action.selectGETmemBySuperiorGet_free(OpenID, state);
                    return membertable;

                }
                catch
                {
                    return kong;

                }

            }
            else
            {
                return kong;
            }


        }

        //查询他所有的下家个数
        //现在没任何用
        [WebMethod]
        public DataTable selectGETmemBySuperiorCount(string OpenID, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "openID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            SignIn SignIn2 = new SignIn();
            DataTable kong = new DataTable();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

                    DataTable membertable = action.selectGETmemBySuperiorGetCount(OpenID);
                    return membertable;

                }
                catch
                {
                    return kong;

                }

            }
            else
            {
                return kong;
            }


        }


        //查询交易记录条数
        [WebMethod]
        public DataTable SelectAllAdvancePaymentModifyLogByMemberloginIDCount(string memberloginID, string Currentpage, string PageSize, string strPayType, string md5)
        {

            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memberloginID=" + memberloginID + "&Currentpage=" + Currentpage + "&PageSize=" + PageSize + "&strPayType=" + strPayType + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            DataTable kong = new DataTable();

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                var action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                try
                {
                    var actione = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    memberloginID = actione.SelectMemberloginid_By_NO(memberloginID).Rows[0]["MemLoginID"].ToString();
                    string str = string.Empty;
                    str = str + "  AND  MemLoginID=  '" + memberloginID + "'   ";
                    if ((Operator.FormatToEmpty(strPayType) != string.Empty) && (Operator.FormatToEmpty(strPayType) != "-1") && Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        str = str + " AND OperateType=" + strPayType;
                    }
                    string selce_two = string.Empty;
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        selce_two = " and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_rv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_cv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_cv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_DJ_BV <> 0";
                    }
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + selce_two,
                        Currentpage = Currentpage,
                        Tablename = "ShopNum1_AdvancePaymentModifyLog",
                        Resultnum = "0",
                        PageSize = PageSize
                    };

                    commonModel.Select_YuJu = "*";

                    string str2 = "0";
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_rv as money_first,XiaoFei_rv as money_two,XiaoFei_Hou_rv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_rv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(DeDao_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_Qian_cv as money_first,XiaoFei_cv as money_two,XiaoFei_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_cv as money_first,DeDao_cv as money_two,DeDao_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_DJ_BV as money_first,HuoDe_DJ_BV as money_two,Huo_DeHou_DJ_BV as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    DataTable table2 = action.SelectAdvPaymentModifyLog_List(commonModel);



                    return table2;

                }
                catch
                {

                    return kong;

                }

            }

            else
            {
                return kong;

            }
        }

        //查询交易记录
        [WebMethod]
        public DataTable SelectAllAdvancePaymentModifyLogByMemberloginID(string memberloginID, string Currentpage, string PageSize, string strPayType, string md5)
        {

            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memberloginID=" + memberloginID + "&Currentpage=" + Currentpage + "&PageSize=" + PageSize + "&strPayType=" + strPayType + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            DataTable kong = new DataTable("MyDT");

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {

                var action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                try
                {
                    var actione = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    memberloginID = actione.SelectMemberloginid_By_NO(memberloginID).Rows[0]["MemLoginID"].ToString();
                    string str = string.Empty;
                    str = str + "  AND  MemLoginID=  '" + memberloginID + "'   ";
                    if ((Operator.FormatToEmpty(strPayType) != string.Empty) && (Operator.FormatToEmpty(strPayType) != "-1") && Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        str = str + " AND OperateType=" + strPayType;
                    }
                    string selce_two = string.Empty;
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        selce_two = " and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_rv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_cv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_cv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_DJ_BV <> 0";
                    }
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + selce_two,
                        Currentpage = Currentpage,
                        Tablename = "ShopNum1_AdvancePaymentModifyLog",
                        Resultnum = "1",
                        PageSize = PageSize
                    };

                    commonModel.Select_YuJu = "*";

                    string str2 = "0";
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_rv as money_first,XiaoFei_rv as money_two,XiaoFei_Hou_rv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_rv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(DeDao_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_Qian_cv as money_first,XiaoFei_cv as money_two,XiaoFei_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_cv as money_first,DeDao_cv as money_two,DeDao_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_DJ_BV as money_first,HuoDe_DJ_BV as money_two,Huo_DeHou_DJ_BV as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber,CASE OperateType when 1 then '充值' when 2 then '提现' when 3 then '消费' when 4 then '收入' when 5 then '系统' when 5 then '转账' END as jilu ";
                        str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    DataTable table2 = action.SelectAdvPaymentModifyLog_List(commonModel);

                    if (table2.Rows.Count > 0)
                    {
                        return table2;
                    }
                    else
                    {
                        return kong;
                    }



                }
                catch (Exception ex)
                {

                    return kong;

                }

            }

            else
            {
                return kong;

            }
        }


        //支付
        [WebMethod]
        public string Pay(string OrderNumber, string OpenID, string ScoreHvType, string PayPwd, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OpenID=" + OpenID + "&ScoreHvType=" + ScoreHvType + "&PayPwd=" + PayPwd + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            DataTable kong = new DataTable();

            WeiXinServicePay_Bv payApp = new WeiXinServicePay_Bv();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    string order = payApp.Pay(OrderNumber, OpenID, ScoreHvType, PayPwd);

                    switch (order)
                    {
                        case "1":
                            return "支付密码为空";

                        case "2":
                            return "您输入的交易密码不正确";

                        case "3":
                            return "不明确是否使用红包";

                        case "4":
                            return "您的交易金额为0，不能使用智付支付";

                        case "5":
                            return "付款金额错误";

                        case "6":
                            return "您当前帐户上面的金额不足，无法支付";

                        case "7":
                            return "该订单已经支付";

                        case "8":
                            return "1";

                        case "9":
                            return "订单支付错误";




                        default:
                            return "错误编号";

                    }



                }
                catch
                {
                    return "错误！";

                }

            }

            else
            {
                return "md5对不错误！";

            }
        }



        //创建购物车订单

        [WebMethod]
        public string CreateOrderCar(string OrderID, string OpenID, int ShopCategoryID, int PayMentType, string ProductIds, decimal OrderPrice, decimal PostPrice, string TextBoxMessage, string Name, string Email, string Address, string Tel, string Mobile, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OrderID=" + OrderID + "&OpenID=" + OpenID + "&ShopCategoryID=" + ShopCategoryID + "&PayMentType=" + PayMentType + "&ProductIds=" + ProductIds + "&OrderPrice=" + OrderPrice + "&PostPrice=" + PostPrice + "&TextBoxMessage=" + TextBoxMessage + "&Name=" + Name + "&Email=" + Email + "&Address=" + Address + "&Tel=" + Tel + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            DataTable kong = new DataTable();

            WeiXinService payApp = new WeiXinService();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    string order = payApp.CreateOrderCar(OrderID, OpenID, ShopCategoryID, PayMentType, ProductIds, OrderPrice, PostPrice, TextBoxMessage, Name, Email, Address, Tel, Mobile);

                    switch (order)
                    {
                        case "1":
                            return "购买失败";

                        case "2":
                            return "请填写正确的服务商";

                        case "3":
                            return "支付方式不能为空";

                        case "4":
                            return "价格应处于￥105700-￥106300之间";

                        case "5":
                            return "价格应该处于￥35900-￥36100之间";

                        case "6":
                            return "收货地址错误";

                        case "7":
                            return "支付方式错误";

                        case "8":
                            return "很抱歉,抢购商品一个ID限购一件！";

                        case "9":
                            return "很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！";


                        default:
                            return "1";

                    }



                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }


        //付款？郭泽傻逼的
        [WebMethod]
        public string WeixinPay(string OrderNumber, decimal Totol, string GetAwyID, string DVHV, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OrderNumber=" + OrderNumber + "&Totol=" + Totol + "&GetAwyID=" + GetAwyID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            DataTable kong = new DataTable();

            WeiXinServicePay_weixinPayment payApp = new WeiXinServicePay_weixinPayment();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    string order = payApp.Pay(OrderNumber, Totol, GetAwyID, DVHV);
                    return order;





                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }
        //微信绑定自己推荐目标
        [WebMethod]
        public string HappyAngel(string OpenID, string number, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OpenID=" + OpenID + "&number=" + number + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    DataTable membertable = action.SelectMemberByOpenId(OpenID);
                    if (membertable != null && membertable.Rows.Count > 0)
                    {
                        string memloginID = membertable.Rows[0]["MemLoginID"].ToString();
                        DataTable angeltable = action.GetALLWeixin_Angel(memloginID);
                        if (angeltable != null && angeltable.Rows.Count > 0)
                        {
                            int fanhui = action.updateWeixin_Angel(number, System.DateTime.Now, memloginID);

                            if (fanhui != 0)
                            {
                                return "修改目标成功，祝您成功！";
                            }
                            else
                            {
                                return "修改目标时出错了，请重新尝试，如果多次出现本错误请联系客服人员。";
                            }
                        }
                        else
                        {
                            int fanhui = action.INsertWeixin_Angel(memloginID, System.DateTime.Now, Convert.ToInt32(number));
                            if (fanhui != 0)
                            {
                                return "添加目标成功，祝您成功！";
                            }
                            else
                            {
                                return "添加目标时出错了，请重新尝试，如果多次出现本错误请联系客服人员。";
                            }
                        }
                    }
                    else
                    {
                        return "没有查询到您的工号，请联系客服人员进行咨询。";
                    }





                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }


        //查询自己推荐目标
        [WebMethod]
        public string HappyAngelConut(string OpenID, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OpenID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    DataTable membertable = action.SelectMemberByOpenId(OpenID);
                    if (membertable != null && membertable.Rows.Count > 0)
                    {
                        string memloginID = membertable.Rows[0]["MemLoginID"].ToString();
                        DataTable angeltable = action.GetALLWeixin_Angel(memloginID);
                        if (angeltable != null && angeltable.Rows.Count > 0)
                        {
                            return angeltable.Rows[0]["ReferenceNumber"].ToString();


                        }
                        else
                        {
                            return "没有查询到数据。";
                        }

                    }
                    else
                    {
                        return "没有查询到您的工号，请联系客服人员进行咨询。";
                    }





                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }

        //发送确认目标个数的短信接口
        [WebMethod]
        public string SMS(string OpenID, string number, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OpenID=" + OpenID + "&number=" + number + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    DataTable membertable = action.SelectMemberByOpenId(OpenID);
                    if (membertable != null && membertable.Rows.Count > 0)
                    {
                        string memloginID = membertable.Rows[0]["MemLoginID"].ToString();
                        DataTable memberalltable = action.GetALLMemberByShopid(memloginID);
                        if (memberalltable != null && memberalltable.Rows.Count > 0)
                        {
                            var sMS = new SMS();
                            string text5 = "";
                            string Mobile = memberalltable.Rows[0]["mobile"].ToString();
                            if (Convert.ToInt32(number) <= 10)
                            {
                                sMS.Send(Mobile.Trim(), "尊敬的会员：" + memloginID + ",你已经制定了自己的目标，目标个数为" + number + "个,请加油完成目标。" + "【唐江巴巴】", out text5);
                                return "1";
                            }
                            else
                            {
                                sMS.Send(Mobile.Trim(), "尊敬的会员：" + memloginID + ",你已经制定了自己的目标，目标个数为" + number + "个,请加油完成目标。" + "【唐江巴巴】", out text5);
                                return "1";
                            }
                        }
                        else
                        {
                            return "没有查询到您的工号，请联系客服人员进行咨询。";
                        }


                    }
                    else
                    {
                        return "没有查询到您的工号，请联系客服人员进行咨询。";
                    }






                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }

        //发送确认目标个数的短信接口
        [WebMethod]
        public string BindPayPrice(string OrderNumber, string OpenID, string ScoreHvType, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OrderNumber=" + OrderNumber + "&OpenID=" + OpenID + "&ScoreHvType=" + ScoreHvType + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    WeiXinServicePay_weixinPayment pay = new WeiXinServicePay_weixinPayment();

                    string cc = pay.BindPayPrice(OrderNumber, OpenID, ScoreHvType);


                    return cc;

                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }

        //订单价格详情显示
        [WebMethod]
        public string BindOrderPrice(string OrderNumber, string OpenID, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OrderNumber=" + OrderNumber + "&OpenID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    WeiXinService pay = new WeiXinService();

                    string cc = pay.BindOrderPrice(OrderNumber, OpenID);


                    return cc;

                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }

        //修改银行卡信息
        [WebMethod]
        public string UpdateBank(string Bank, string BankName, string BankNo, string BankAddress, string OpenID, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Bank=" + Bank + "&BankName=" + BankName + "&BankNo=" + BankNo + "&BankAddress=" + BankAddress + "&OpenID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    WeiXinService pay = new WeiXinService();

                    string cc = pay.UpdateBank(Bank, BankName, BankNo, BankAddress, OpenID);


                    return cc;

                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }




        //微信退款
        [WebMethod]
        public string WeiXinOrderRefund(string Ordernumber, string RefundReason, string Introduce, string RefundTypes, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Ordernumber=" + Ordernumber + "&RefundReason=" + RefundReason + "&Introduce=" + Introduce + "&RefundTypes=" + RefundTypes + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    WeiXinService pay = new WeiXinService();

                    string cc = pay.WeiXinOrderRefund(Ordernumber, RefundReason, Introduce, RefundTypes);

                    return cc;
                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }




  //签到
        [WebMethod]
        public string SignIn_HV(string OpenID, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "MyMemLoginID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                SignIn SignIn2 = new SignIn();


                try
                {
                     var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    DataTable membertable = action.SelectMemberByOpenId(OpenID);
                    if (membertable != null && membertable.Rows.Count > 0)
                    {
                        string memloginID = membertable.Rows[0]["MemLoginID"].ToString();
                        string order = SignIn2.SignIn_HV(memloginID);
                        switch (order)
                        {
                            case "have":
                                return "您今天已经签到过了!";

                            case "true":
                                return "签到成功";


                            case "false":
                                return "签到失败了!";



                            default:
                                return "签到时出现了异常错误。";

                        }
                    }
                    else
                    {
                        return "没查询到您的工号！";
                    }


                }
                catch
                {

                    return "出现了异常错误。";
                }

            }

            else
            {

                return "MD5对比失败。";




            }
        }


        //返回自己的账户信息
        [WebMethod]
        public DataTable WeiXinSelectMemberInfo(string OpenID, string md5)
        {
            DataTable kong = new DataTable();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OpenID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            SignIn SignIn2 = new SignIn();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {

                    WeiXinPayDecrease payd = new WeiXinPayDecrease();




                    DataTable weixin = payd.WeiXinSelectMemberInfo(OpenID);

                    if (weixin != null && weixin.Rows.Count > 0)
                    {
                        return weixin;
                    }
                    else
                    {
                        return kong;
                    }
                }
                catch
                {

                    return kong;
                }

            }
            else
            {
                return kong;
            }
        }


        //微信提现
        [WebMethod]
        public string WeiXinDecrease(string OpenID, string Decrease_bv, string Remark, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OpenID=" + OpenID + "&Decrease_bv=" + Decrease_bv + "&Remark=" + Remark + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    WeiXinPayDecrease payd = new WeiXinPayDecrease();

                    string cc = payd.WeiXinDecrease(OpenID, Decrease_bv, Remark);

                    return cc;
                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }


        //微信提现查询银行账户信息
        [WebMethod]
        public string WeiXinDecreaseBank(string OpenID, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OpenID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    WeiXinPayDecrease payd = new WeiXinPayDecrease();

                    string cc = payd.WeiXinDecreaseBank(OpenID);

                    return cc;
                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }

        //绑定姓名身份证
        [WebMethod]
        public string UpdateBindRealName(string RealName, string ID, string OpenID,string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "RealName=" + RealName + "&ID=" + ID + "&OpenID=" + OpenID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);


            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    WeiXinService pay = new WeiXinService();

                    string cc = pay.UpdateBindRealName(RealName, ID, OpenID);


                    return cc;

                }
                catch
                {

                    return "出错了";

                }

            }

            else
            {
                return "md5对比失败";

            }
        }




        //返回订单物流信息
        [WebMethod]
        public DataTable WeiXinSelectOrderInfoWL(string OrderID, string md5)
        {
            DataTable kong = new DataTable();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "OrderID=" + OrderID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            SignIn SignIn2 = new SignIn();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {

                    WeiXinService web = new WeiXinService();




                    DataTable weixin = web.WeiXinSelectOrderInfoWL(OrderID);

                    if (weixin != null && weixin.Rows.Count > 0)
                    {
                        return weixin;
                    }
                    else
                    {
                        return kong;
                    }
                }
                catch
                {

                    return kong;
                }

            }
            else
            {
                return kong;
            }
        }
        //查询微信店铺名和卖家
        [WebMethod]
        public DataTable WeiXinSelectShopName(string Guid, string md5)
        {
            DataTable kong = new DataTable();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Guid=" + Guid + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            SignIn SignIn2 = new SignIn();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {

                    WeiXinService web = new WeiXinService();




                    DataTable weixin = web.WeiXinSelectShopName(Guid);

                    if (weixin != null && weixin.Rows.Count > 0)
                    {
                        return weixin;
                    }
                    else
                    {
                        return kong;
                    }
                }
                catch
                {

                    return kong;
                }

            }
            else
            {
                return kong;
            }
        }


    }
}

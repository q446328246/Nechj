using System;
using System.Data;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api.Main.Member
{
    /// <summary>
    /// ThreeClassify 的摘要说明
    /// </summary>
    public class ThreeClassify : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (ShopNum1.Common.Common.ReqStr("type") != "")
                {
                    string strType = ShopNum1.Common.Common.ReqStr("type"); //类型
                    string FatherID = ShopNum1.Common.Common.ReqStr("FatherID"); //父ID


                    switch (strType)
                    {
                        case "SupplyDemandCategory": //供求分类
                            context.Response.Write(GetSupplyDemandCategory(FatherID));
                            break;
                        case "RegionCode": //地区
                            context.Response.Write(GetRegion(FatherID));
                            break;

                        case "SignIn": //签到
                            context.Response.Write(SignIn());
                            break;
                        //case "MemUpgrade": //会员升级
                        //    context.Response.Write(MemUpgrade());
                        //    break;
                        
                    }
                }
            }
            catch
            {
                context.Response.Write("error");
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
        //对红包进行添加
        private void UpdateRankScore(int Score, int RankScore, string MemLoginID)
        {
            string vScore = ShopNum1.Common.Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)", "shopnum1_member",
                                               " and memloginid='" + MemLoginID + "'");
            int currentscore = 0, rankscore = 0;
            if (vScore != "" && vScore.IndexOf("-") != -1)
            {
                currentscore = Convert.ToInt32(vScore.Split('-')[1]);
                rankscore = Convert.ToInt32(vScore.Split('-')[0]);
            }
            if (Score > 0)
            {
                var ScoreModifyLog = new ShopNum1_ScoreModifyLog();
                ScoreModifyLog.Guid = Guid.NewGuid();
                ScoreModifyLog.OperateType = 1;
                ScoreModifyLog.CurrentScore = (currentscore - Score);
                ScoreModifyLog.OperateScore = Score;
                ScoreModifyLog.LastOperateScore = currentscore;
                ScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ScoreModifyLog.Memo = "签到送消费红包";
                ScoreModifyLog.MemLoginID = MemLoginID;
                ScoreModifyLog.CreateUser = MemLoginID;
                ScoreModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ScoreModifyLog.IsDeleted = 0;
                var shopNum1_ScoreModifyLog =
                    (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
                shopNum1_ScoreModifyLog.OperateScore(ScoreModifyLog);
            }
            //等级红包
            if (RankScore > 0)
            {
                

                var RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
                
                RankScoreModifyLog.OperateType = 1;
                RankScoreModifyLog.CurrentScore = (rankscore - RankScore);
                RankScoreModifyLog.OperateScore = RankScore;
                RankScoreModifyLog.LastOperateScore = rankscore;
                RankScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                RankScoreModifyLog.Memo = "签到送等级红包";
                RankScoreModifyLog.MemLoginID = MemLoginID;
                RankScoreModifyLog.CreateUser = MemLoginID;
                RankScoreModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                RankScoreModifyLog.IsDeleted = 0;
                var RankScoreModifyLog_Action =
                    (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
                RankScoreModifyLog_Action.OperateScore(RankScoreModifyLog);
            }
        }


        public bool SignInBool(string MemberLoginID)
        {
            var member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            var signIn = new ShopNum1_SignIn();
            signIn.guid = Guid.NewGuid();
            signIn.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            signIn.MemLoginID = MemberLoginID;
            int check = member_Action.AddSignin(signIn);
            if (check > 0)
            {
                //签到成功
                string SignOrSendScore = ShopSettings.GetValue("SignOrSendScore"); //签到是否送红包 0表示不送红包，1表示送红包 
                string strRankScore = ShopSettings.GetValue("SignRankScore"); //等级红包
                string strSignScore = ShopSettings.GetValue("SignScore"); //消费红包

                //送红包
                if (!string.IsNullOrEmpty(SignOrSendScore) && int.Parse(SignOrSendScore) == 1)
                {
                    member_Action.UpdateMemberScore(MemberLoginID, Convert.ToInt32(strRankScore),
                                                    Convert.ToInt32(strSignScore));
                    decimal vScore = Convert.ToDecimal(ShopNum1.Common.Common.GetScore_hv(MemberLoginID).Rows[0]["Score_hv"]);
                    var shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
                    shopNum1_AdvancePaymentModifyLog.hv_guid_two = Guid.NewGuid();
                    shopNum1_AdvancePaymentModifyLog.OperateType = 1;

                    shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_hv = vScore - Convert.ToDecimal(strSignScore);
                    shopNum1_AdvancePaymentModifyLog.HuoDe_hv = Convert.ToDecimal(strSignScore) ;
                    shopNum1_AdvancePaymentModifyLog.Huo_DeHou_hv = vScore;
                    shopNum1_AdvancePaymentModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_AdvancePaymentModifyLog.HuoDe_Mom = "签到送红包";
                    shopNum1_AdvancePaymentModifyLog.MemLoginID = MemberLoginID;
                    shopNum1_AdvancePaymentModifyLog.CreateUser = MemberLoginID;
                    shopNum1_AdvancePaymentModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;
                    var shopNum1_AdvancePaymentModifyLog_Action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                    shopNum1_AdvancePaymentModifyLog_Action.OperateScore_HV(shopNum1_AdvancePaymentModifyLog);
                    UpdateRankScore(Convert.ToInt32(strSignScore), Convert.ToInt32(strRankScore), MemberLoginID);
                }
                return true;
            }
            return false;
        }

        //会员升级
 //       public string MemUpgrade()
 //       {
 //           HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
 //           HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
 //           //会员登录ID
 //           string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
 //           string result = string.Empty;
 //           //判断PVA几分是否大于300
 //           var memberrankguid_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
 //           String memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);

 //           if (memberGuid.Equals("A6DA75AD-E1AC-4DF8-99AD-980294A16581")) { 
 //               DataTable table2 =
 //               ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).Search("'" +MemberLoginID+ "'",
 //                   0);
 //               if (((int)table2.Rows[0]["Score_pv_a"]) > 300)
 //               {
 //                   string memRankGuid = "E5EA79AC-A3E9-492B-9F86-9C7F8A48AA76";
 //                   var updatememRankGuid = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
 //                   updatememRankGuid.UpdateMemberRankGuid(MemberLoginID, memRankGuid);
 //                   return "yes";
 //               }
 //               else 
 //               {
 //                   return "no";
 //               }
               
 //           }
 //return "s";
 //       }

        //签到
        public string SignIn()
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            var member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            //判断今天是否签到过
            string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dataTable = member_Action.CheckSignin(MemberLoginID, dayTime);
            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0]["count"]) > 0)
                {
                    return "have";
                }
                else
                {
                    string SignOrSendScore = ShopSettings.GetValue("SignOrSendScore"); //签到是否送红包 0表示不送红包，1表示送红包 
                    string strRankScore = ShopSettings.GetValue("SignRankScore"); //等级红包
                    string strSignScore = ShopSettings.GetValue("SignScore"); //消费红包
                    if (SignOrSendScore == "1")
                    {
                        if (SignInBool(MemberLoginID))
                        {
                            return "true|" + strSignScore + "|" + strRankScore;
                        }
                        else
                        {
                            return "true";
                        }
                    }

                    return "false";
                }
            }
            else
            {
                if (SignInBool(MemberLoginID))
                {
                    return "true";
                }
                return "false";
            }
        }

        public string GetRegion(string FatherID)
        {
            var Region_Action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
            DataTable dataTable = Region_Action.SearchtRegionCategory(Convert.ToInt32(FatherID), 0);
            string strString = string.Empty;
            strString = "<option value=\"-1\">-请选择-</option>";
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    strString += "<option value=\"" + dr["ID"] + "|" + dr["Code"] + "\">" + dr["Name"] + "</option>";
                }
            }
            return strString;
        }

        /// <summary>
        ///   供求分类
        /// </summary>
        /// <param name="FatherID"></param>
        /// <returns></returns>
        public string GetSupplyDemandCategory(string FatherID)
        {
            var SupplyDemandCategory_Action =
                (ShopNum1_SupplyDemandCategory_Action)LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
            DataTable dataTable = SupplyDemandCategory_Action.GetDataByFatherID(FatherID);
            string strString = string.Empty;
            strString = "<option value=\"-1\">-请选择-</option>";
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    strString += "<option value=" + dr["ID"] + "|" + dr["Code"] + ">" + dr["Name"] + "</option>";
                }
            }
            return strString;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ShopNum1MultiEntity;
using ShopNum1.Common;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common.ShopNum1.Mobile;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// XianShiYouService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class XianShiYouService : System.Web.Services.WebService
    {

        [WebMethod]
        public void Login(string Mobile, string PWD)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable selectMember = member_Action.GetALLMemberAll1(Mobile, Common.Encryption.GetMd5Hash(PWD));
            JsonMessage message = new JsonMessage();
            DateTime newtime = System.DateTime.Now;

            if (selectMember.Rows.Count > 0)
            {
                DateTime Oldtime = Convert.ToDateTime(selectMember.Rows[0]["ErrorTime"]);
                int ErrorNum = Convert.ToInt32(selectMember.Rows[0]["ErrorNum"]);
                int NewHouers = Convert.ToInt32(newtime.Subtract(Oldtime).TotalHours);
                if (selectMember.Rows[0]["IsForbid"].ToString() == "1")
                {
                    message.Result = 0;
                    message.Error_code = 1;

                    Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                    Context.Response.End();

                }
                else if (ErrorNum >= 5)
                {
                    if (NewHouers >= 1)
                    {
                        string dt = DateTime.Now.AddHours(720).ToString("yyyy-MM-dd HH:mm:ss");
                        string md5 = Mobile + "~" + PWD + "~" + dt;
                        member_Action.UpdateMemberErrorNumGetNull1(Mobile);

                        message.Data = ServiceHelper.GetJSON<string>(ShopNum1.Encryption.DESEncrypt.M_Encrypttwo(md5));
                        Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                        Context.Response.End();
                    }
                    else
                    {
                        message.Result = 0;
                        message.Error_code = 2;

                        Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                        Context.Response.End();
                    }
                }
                else
                {
                    string dt = DateTime.Now.AddHours(720).ToString("yyyy-MM-dd HH:mm:ss");
                    string md5 = Mobile + "~" + PWD + "~" + dt;
                    member_Action.UpdateMemberErrorNumGetNull1(Mobile);

                    message.Data = ServiceHelper.GetJSON<string>(ShopNum1.Encryption.DESEncrypt.M_Encrypttwo(md5));
                    message.Result = 1;
                    Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                    Context.Response.End();
                }
            }
            else
            {
                message.Result = 0;
                message.Error_code = 3;
                member_Action.UpdateMemberErrorNum(Mobile, 1);
                member_Action.UpdateMembeErrorTime(Mobile, newtime);
                Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                Context.Response.End();
            }
        }


        //登陆
        [WebMethod]
        public void Logintwo(string memloginid, string token)
        {

            GZMessage message = new GZMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == memloginid.ToUpper())
            {
                try
                {
                    DataTable selectMember = member_Action.SearchMemberGz(memloginid);

                    message.Data = Gz_XSY_Member.FromDataRow(selectMember.Rows[0]);//ServiceHelper.M_json(selectGoods);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(Gz_XSY_Member));

                    Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));
                    Context.Response.End();


                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = "10002";
                    message.Message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }


            }
            else
            {
                message.Result = 0;
                message.Code = "10001";
                message.Message = "token验证失败";
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }



        }




        /// <summary>
        /// 减金币
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public void GZ_XSY_BV(string memloginid, string ordernumber, decimal bv, string md5)
        {

            GZMessage message = new GZMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memloginid=" + memloginid + "&ordernumber=" + ordernumber + "&bv=" + bv + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                //try
                //{
                DataTable table = member_Action.SearchMembertwo(memloginid);
                if (table.Rows.Count>0)
                {
                    decimal membv = Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString());
                    if (bv > membv)
                    {
                        message.Result = 0;
                        message.Code = "10002";
                        message.Message = "账号资金不足!";
                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                        Context.Response.End();
                    }
                    else
                    {
                        GZ_XSY_OrderInfo xsy = new GZ_XSY_OrderInfo();
                        xsy.MemloginID = memloginid;
                        xsy.OrderNumber = ordernumber;
                        xsy.bv = bv;
                        xsy.Date = DateTime.Now;
                        int cc = member_Action.AddGZ_XSY_OrderInfo(xsy);
                        member_Action.INsertAdvancePaymentModifyLog_Gz_XSY(memloginid, bv, "发红包扣除" + ordernumber);

                        message.Result = 1;
                        message.Code = "10000";
                        message.Message = "成功!";
                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                        Context.Response.End();
                    }
                
                }
                else
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = "账号不存在!";
                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                    Context.Response.End();
                }

                //}
                //catch (Exception ex)
                //{

                //    message.Result = 0;
                //    message.Code = "10002";
                //    message.Message = ex.Message;

                //    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                //    Context.Response.End();
                //}


            }
            else
            {
                message.Result = 0;
                message.Code = "10001";
                message.Message = "密钥验证失败";
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }
        /// <summary>
        /// 加红包
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public void GZ_XSY_HV(string memloginid, decimal hv, string md5)
        {

            GZMessage message = new GZMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memloginid=" + memloginid + "&hv=" + hv + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                //try
                //{
                member_Action.InsertAdvancePaymentModifyLog_Gz_XSY_hv(memloginid, hv, "抢红包获得");

                message.Result = 1;
                message.Code = "10000";
                message.Message = "成功!";
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                Context.Response.End();


                //}
                //catch (Exception ex)
                //{

                //    message.Result = 0;
                //    message.Code = "10002";
                //    message.Message = ex.Message;

                //    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                //    Context.Response.End();
                //}


            }
            else
            {
                message.Result = 0;
                message.Code = "10001";
                message.Message = "密钥验证失败";
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }
        /// <summary>
        /// 加PVB
        /// </summary>
        /// <param name="Mobile">手机号码</param>
        /// <param name="ScorePVB">PVB数量</param>
        /// <returns></returns>
        [WebMethod]
        public void AddScorePVB(string Mobile, decimal ScorePVB, string token, string url, string orderId)
        {
            JsonMessage message = new JsonMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            decimal pvb = Convert.ToDecimal(member_Action.GetMemberScorePVB(Mobile).Rows[0]["Score_pv_b"].ToString());
            string ReturnValue = JieMi(Mobile, token);
            ScorePVB = ScorePVB / 100;
            if (ReturnValue == "1")
            {
                if (Mobile != null && Mobile != "" && ScorePVB > 0)
                {
                    try
                    {
                        member_Action.InsertAdvancePaymentModifyLogRecord1(Mobile, pvb, ScorePVB, pvb + ScorePVB, "PVB转入" + orderId);
                        int count = member_Action.AddScorePVB(Mobile, ScorePVB);
                        if (count > 0)
                        {
                            message.Data = count;
                            message.Result = 1;
                            Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));

                            Thread thread = new Thread(new ParameterizedThreadStart(GetrtnValue));
                            thread.Start(url);
                            Context.Response.End();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = 4;

                    Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = 5;

                    Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                    Context.Response.End();
                }
            }
        }

        /// <summary>
        /// 减PVB
        /// </summary>
        /// <param name="Mobile">手机号码</param>
        /// <param name="ScorePVB">PVB数量</param>
        /// <returns></returns>
        [WebMethod]
        public void JianScorePVB(string Mobile, decimal ScorePVB, string token, string url, string orderId)
        {
            JsonMessage message = new JsonMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable Mtd = member_Action.Getrmobile(Mobile);
            if (Mtd != null && Mtd.Rows.Count > 0)
            {
                string MemLoginID = Mtd.Rows[0]["MemLoginID"].ToString();
                decimal pvb = Convert.ToDecimal(member_Action.GetPVB(MemLoginID).Rows[0]["Score_pv_b"].ToString());
                string ReturnValue = JieMi(Mobile, token);

                if (ReturnValue == "1")
                {
                    if (pvb > 0)
                    {
                        if (ScorePVB > 0)
                        {
                            ScorePVB = ScorePVB / 100;
                            decimal pvb_Cha = pvb - ScorePVB;

                            if (pvb_Cha >= 0)
                            {
                                if (Mobile != null && Mobile != "")
                                {
                                    try
                                    {

                                        int count = member_Action.InsertAdvancePaymentModifyLogRecord22(MemLoginID, ScorePVB, "PVB转出" + orderId);
                                        if (count > 0)
                                        {
                                            message.Data = count;
                                            message.Result = 1;
                                            Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));

                                            Thread thread = new Thread(new ParameterizedThreadStart(GetrtnValue));
                                            thread.Start(url);
                                            Context.Response.End();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }

                            }
                            else
                            {
                                message.Result = 0;
                                message.Error_code = 6;

                                Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                                Context.Response.End();
                            }
                        }
                        else
                        {
                            message.Result = 0;
                            message.Error_code = 9;

                            Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                            Context.Response.End();
                        }
                    }

                    else
                    {
                        message.Result = 0;
                        message.Error_code = 7;

                        Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                        Context.Response.End();
                    }
                }
                else
                {

                    if (ReturnValue == "0")
                    {
                        message.Result = 0;
                        message.Error_code = 4;

                        Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                        Context.Response.End();
                    }
                    else if (ReturnValue == "2")
                    {
                        message.Result = 0;
                        message.Error_code = 5;

                        Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                        Context.Response.End();
                    }

                }
            }
            else
            {
                message.Result = 0;
                message.Error_code = 8;

                Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                Context.Response.End();
            }
        }

        [WebMethod]
        public void QueryScorePVB(string Mobile, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            JsonMessage message = new JsonMessage();
            string ReturnValue = JieMi(Mobile, token);
            if (ReturnValue == "1")
            {
                if (Mobile != null && Mobile != "")
                {
                    try
                    {
                        DataRow dr = member_Action.GetMemberScorePVB(Mobile).Rows[0];
                        string Superior = dr["Superior"].ToString();
                        string superiorMobile = member_Action.GetMemberMobile(Superior).Rows[0]["Mobile"].ToString();
                        message.Data = ShopNum1_PartMember.PartMember(dr, superiorMobile);
                        message.Result = 1;
                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_PartMember));
                        Context.Response.Write(ServiceHelper.GetJSON_two<JsonMessage>(message, types));
                        Context.Response.End();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = 4;

                    Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = 5;

                    Context.Response.Write(ServiceHelper.GetJSON<JsonMessage>(message));
                    Context.Response.End();
                }
            }
        }

        public string JieMi(string Mobile, string token)
        {
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypttwo(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication1(tValues[0], tValues[1], tValues[2]);
            if (Mobile != tValues[0])
            {
                ReturnValue = "2";
            }
            return ReturnValue;
        }
        /// <summary>
        /// Get请求回调地址
        /// </summary>
        /// <param name="url">地址</param>
        public void GetrtnValue(object url)
        {
            WebClient myWebClient = new WebClient();
            Encoding enc = Encoding.GetEncoding("UTF-8");
            Byte[] pageData = myWebClient.DownloadData((string)url);
            string values = enc.GetString(pageData);
            JsonMessage message = new JsonMessage();
            try
            {
                message.Data = values;
                message.Result = 1;
                message.Error_code = 0;
            }
            catch (Exception ex)
            {
                message.Data = "";
                message.Result = 0;
                message.Error_code = 6;
            }
        }
    }
}

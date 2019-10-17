using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using System.Data;
using ShopNum1MultiEntity;
using ShopNum1.Deploy.KCELogic;
using ShopNum1.Factory;
using ShopNum1.Deploy.Api;
using System.IO;
using System.Drawing;
using System.Configuration;
using ShopNum1.Deploy.Service;
using ShopNum1.Deploy.MobileServiceAPP;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.Deploy.KCESservice
{
    /// <summary>
    /// NECAPI 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class NECAPI : System.Web.Services.WebService
    {

        [WebMethod]

        public void WHJTest(string MemLoginID) {
            GZMessage message = new GZMessage();
            Gz_LogicApi gl = new Gz_LogicApi();
            message.Result = 0;
            message.Code = gl.RJiaMi(MemLoginID);
            message.Message = Gz_LogicApi.GetString("MG000020");
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }






        public void WriteLog(string strLog)
        {
            string sFilePath = "d:\\" + DateTime.Now.ToString("yyyyMM");
            string sFileName = "rizhi" + DateTime.Now.ToString("dd") + ".log";
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);
                //不存在则创建
            }
            FileStream fs;
            StreamWriter sw;
            if (File.Exists(sFileName))
            //验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "   ---   " + strLog);
            sw.Close();
            fs.Close();
        }

        public List<Nec_RenRenZZ> FromDataRowNec_RenRenZZ(DataTable table)
        {
            List<Nec_RenRenZZ> KCE_CTC_OrderInfo = new List<Nec_RenRenZZ>();
            foreach (DataRow row in table.Rows)
            {
                Nec_RenRenZZ kco = new Nec_RenRenZZ();

                kco.ID = Convert.ToString(row["ID"]);
                kco.NEC = Convert.ToString(row["NEC"]);
                kco.ChongZhiID = Convert.ToString(row["ChongZhiID"]);
                kco.AddTime = Convert.ToString(row["AddTime"]);
                kco.Status = Convert.ToString(row["Status"]);
                kco.RenType = Convert.ToString(row["RenType"]);
                KCE_CTC_OrderInfo.Add(kco);
            }
            return KCE_CTC_OrderInfo;
        }





        [WebMethod]
        public void RenRenZZList(string MemLoginID)
        {
            GZMessage message = new GZMessage();
            Gz_LogicApi gl = new Gz_LogicApi();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            DataTable dt = member_Action.RenRenZZList(MemLoginID);

            if (dt.Rows.Count > 0)
            {
                object CCCC = new
                {
                    Result = 1,
                    Data = FromDataRowNec_RenRenZZ(dt)
                };

                Context.Response.Write(StringHelper.Serialize(CCCC));
                Context.Response.End();
            }
            else
            {
                object CCCCT = new
                {
                    Result = 0,
                    Code = "10086",
                    Message = Gz_LogicApi.GetString("GZ24")
                };
                Context.Response.Write(StringHelper.Serialize(CCCCT));
                Context.Response.End();
            }
        }

        
    



        /// <summary>
        /// 人人转账
        /// </summary>
        /// <param name="MemLoginID">用户id</param>
        /// <param name="NEC">nec</param>
        /// <param name="IIPassWord">支付密码</param>
        /// <param name="Token"></param>
        [WebMethod]
        public void RenRenZhuanZhang(string MemLoginID, decimal NEC, string phone, string IIPassWord, string Token,string RenType="1") {

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();


            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {

                if (NEC < 0)
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000020");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {

                    DataTable table = member_Action.SearchMembertwo(MemLoginID);
                    decimal MyNEC = Convert.ToDecimal(table.Rows[0]["Score_dv"]);
                    string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                    if (RenType == "1")
                    {
                        #region 11



                        if (IIPassWord == "")
                        {
                            message.Result = 0;
                            message.Code = "10023";
                            message.Message = Gz_LogicApi.GetString("MG000021");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();
                        }
                        else if (MyNEC < NEC)
                        {
                            message.Result = 0;
                            message.Code = "10023";
                            message.Message = Gz_LogicApi.GetString("MG000008");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();
                        }
                        else
                        {
                            string md5SecondHash = Common.Encryption.GetMd5SecondHash(IIPassWord.Trim());
                            if (MyIIPassWord != md5SecondHash)
                            {
                                message.Result = 0;
                                message.Code = "10024";
                                message.Message = Gz_LogicApi.GetString("MG000010");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();

                            }
                            else
                            {
                                if (table.Rows.Count > 0)
                                {
                                    int Status = 0;
                                    string ChongZhiID = string.Empty;
                                    #region 发送充值请求
                                    Gz_LogicApi gla = new Gz_LogicApi();
                                    ChongZhiID = gla.RenRenZhuanZhang(MemLoginID, NEC, phone, RenType);
                                    #endregion
                                    if (!string.IsNullOrEmpty(ChongZhiID))
                                    {
                                        Status = 2;
                                        member_Action.ZhuanZhangNECKou(MemLoginID, NEC, "商城支出");
                                    }
                                    else
                                    {
                                        Status = 1;
                                    }
                                    #region 记录该次交易
                                    member_Action.Add_Nec_RenRenZZ(MemLoginID, NEC, ChongZhiID, Status,RenType);
                                    #endregion



                                    message.Result = (Status == 2 ? 1 : 0);
                                    message.Code = "10000";
                                    message.Message = (Status == 2 ? Gz_LogicApi.GetString("MG000011") : "商城同步失败");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();

                                }
                                else
                                {
                                    message.Result = 0;
                                    message.Code = "10001";
                                    message.Message = Gz_LogicApi.GetString("MG000023");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();
                                }
                            }
                        }
                        #endregion
                    }
                    else {
                        if (IIPassWord == "")
                        {
                            message.Result = 0;
                            message.Code = "10023";
                            message.Message = Gz_LogicApi.GetString("MG000021");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();
                        }
                        else {

                            string md5SecondHash = Common.Encryption.GetMd5SecondHash(IIPassWord.Trim());
                            if (MyIIPassWord != md5SecondHash)
                            {
                                message.Result = 0;
                                message.Code = "10024";
                                message.Message = Gz_LogicApi.GetString("MG000010");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();

                            }
                            else {
                                if (table.Rows.Count > 0)
                                {
                                    int Status = 0;
                                    string ChongZhiID = string.Empty;
                                    #region 发送充值请求
                                    Gz_LogicApi gla = new Gz_LogicApi();
                                    ChongZhiID = gla.RenRenZhuanZhang(MemLoginID, NEC, phone, RenType);
                                    #endregion
                                    if (!string.IsNullOrEmpty(ChongZhiID))
                                    {
                                        Status = 2;
                                        member_Action.ZhuanZhangNECJia(MemLoginID, NEC, "商城转入");
                                    }
                                    else
                                    {
                                        Status = 1;
                                    }
                                    #region 记录该次交易
                                    member_Action.Add_Nec_RenRenZZ(MemLoginID, NEC, ChongZhiID, Status, RenType);
                                    #endregion



                                    message.Result = (Status == 2 ? 1 : 0);
                                    message.Code = "10000";
                                    message.Message = (Status == 2 ? Gz_LogicApi.GetString("MG000011") : "商城同步失败");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();

                                }
                                else
                                {
                                    message.Result = 0;
                                    message.Code = "10001";
                                    message.Message = Gz_LogicApi.GetString("MG000023");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();
                                }
                            }
             
                        }
                    }

                }
            }
            else {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
            }
        }



        //人人商城创建租赁订单
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MemLoginID">会员ID</param>
        /// <param name="ProductGuid">商品Guid  23470ba0-183f-4e8d-94e8-e7fcee0f3306  1G综合算力包 </param>
        /// <param name="GuiGeType">购买个数购买种类1=60天2=180天3=270天</param>
        /// <param name="BuyNumber">购买个数</param>
   
        /// <param name="KeyToken">支付密码</param>
        [WebMethod]
        public void RenRenCreateOrder(string MemLoginID, string ProductGuid, int GuiGeType, int BuyNumber,string KeyToken)
        {

            Gz_LogicApi cnfirmOrderAPP = new Gz_LogicApi();
            GZMessage message = new GZMessage();

            if (CheckKeyToken(MemLoginID, KeyToken))
            {
                try
                {

                    


                    string order = cnfirmOrderAPP.WHJ_CreateOrder(MemLoginID, ProductGuid, GuiGeType, BuyNumber);

                    if (order == "1")
                    {
                        message.Code = Gz_LogicApi.GetString("MG000026");
                        message.Message = Gz_LogicApi.GetString("MG000026");
                        message.Result = 1;
                    }
                    else
                    {
                        message.Code = order;
                        message.Message = order;
                        message.Result = 0;
                    }




                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();



            }
            else {
                message.Result = 0;
                message.Code = "10086";
                message.Message = Gz_LogicApi.GetString("MG000016");

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
        }



        public bool CheckKeyToken(string MemLoginID, string KeyToken) {
            bool dvsd = false;
            Gz_LogicApi cnfirmOrderAPP = new Gz_LogicApi();
            if (cnfirmOrderAPP.RJiaMi(MemLoginID) == KeyToken) {
                dvsd = true;
            }
            return dvsd;
        }



        //NEC 2.0 查询商家申请状态
        [WebMethod]
        public void SelectNecChongZhi(string Token, string MemLoginID)
        {


            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                //Gz_LogicApi gzl = new Gz_LogicApi();

                //BtypePrice fh = gzl.SelectBiZongPrice(BType);

                DataTable fh = member_Action.SelectNecChongZhi(MemLoginID);
                if (fh != null && fh.Rows.Count > 0)
                {
                    message.Data = NEC_ChongZhiJiLu.FromData(fh);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(NEC_ChongZhiJiLu));
                    types.Add(typeof(List<NEC_ChongZhiJiLu>));

                    Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                }
                else
                {
                    message.Result = 1;
                    message.Code = "0";
                    message.Message = Gz_LogicApi.GetString("GZ28"); ;

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();

                }
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }




        //NEC 2.0 查询商家申请状态
        [WebMethod]
        public void SelectApplyBusinessStatus(string Token, string MemLoginID)
        {


            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                //Gz_LogicApi gzl = new Gz_LogicApi();

                //BtypePrice fh = gzl.SelectBiZongPrice(BType);

                DataTable fh = member_Action.Select_All_ShenQingStatus(MemLoginID);
                if (fh != null && fh.Rows.Count > 0)
                {
                    message.Result = 1;
                    message.Code = fh.Rows[0]["Status"].ToString();
                    message.Message = fh.Rows[0]["Status"].ToString();

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    message.Result = 1;
                    message.Code = "3";
                    message.Message = "3";

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();

                }
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //NEC 2.0 查询旷工费
        [WebMethod]
        public void SelectKGFPrice(string Token, string MemLoginID)
        {


            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                //Gz_LogicApi gzl = new Gz_LogicApi();

                //BtypePrice fh = gzl.SelectBiZongPrice(BType);

                string table = member_Action.SelectKGFPrice();


                message.Result = 1;
                message.Code = "1";
                message.Message = table;

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //NEC2.0 查询币种价格和增跌幅
        [WebMethod]
        public void SelectBiZongPrice(string Token, string MemLoginID)
        {
            DataTable table = new DataTable();

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                //Gz_LogicApi gzl = new Gz_LogicApi();

                //BtypePrice fh = gzl.SelectBiZongPrice(BType);

                table = member_Action.SelectBiZongPrice();


                message.Data = NEC_BiBi.FromData(table);



                List<Type> types = new List<Type>();
                types.Add(typeof(NEC_BiBi));
                types.Add(typeof(List<NEC_BiBi>));

                Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //2019-07-30  NEC 2.0  续约并支付理财基金订单
        [WebMethod]
        public void ContractFinancialOrder(string Token, string MemLoginID, string OrderNumber, int BuyNumber, string PayPwd)
        {
            Gz_LogicApi cnfirmOrderAPP = new Gz_LogicApi();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {

                try
                {
                    string order = cnfirmOrderAPP.ContractFinancialOrder(MemLoginID, OrderNumber, BuyNumber, PayPwd);

                    if (order == "1")
                    {
                        message.Code = Gz_LogicApi.GetString("MG000026");
                        message.Message = Gz_LogicApi.GetString("MG000026");
                        message.Result = 1;
                    }
                    else
                    {
                        message.Code = order;
                        message.Message = order;
                        message.Result = 0;
                    }




                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = ex.Message;
                    message.Message = ex.Message;

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000081");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000081");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }



        //2019-07-31  NEC 2.0 商家转账
        [WebMethod]
        public void TransferBusinessNEC(string MemLoginID, string ReMemLoginID, decimal NEC, string IIPassWord, string Token)
        {
            GZMessage message = new GZMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthenticationTwo(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                DataTable REtable = member_Action.SearchMembertwoOrMobile(ReMemLoginID);
                string RRmem = REtable.Rows[0]["MemLoginID"].ToString();
                //string Mobile = REtable.Rows[0]["Mobile"].ToString();
                //string LastFour = Mobile.Substring(Mobile.Length - 4, 4);


                if (RRmem == MemLoginID)
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000019");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                //else if (LastFour != MobileLastFour)
                //{
                //    message.Result = 0;
                //    message.Code = "10001";
                //    message.Message = "手机后四位验证失败";
                //    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                //    Context.Response.End();
                //}
                else if (NEC < 0)
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000020");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {

                    DataTable table = member_Action.SearchMembertwo(MemLoginID);
                    decimal MyNEC = Convert.ToDecimal(table.Rows[0]["Score_dv"]);
                    string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                    #region 11
                    if (IIPassWord == "")
                    {
                        message.Result = 0;
                        message.Code = "10023";
                        message.Message = Gz_LogicApi.GetString("MG000021");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                        Context.Response.End();
                    }
                    else if (MyNEC < NEC)
                    {
                        message.Result = 0;
                        message.Code = "10023";
                        message.Message = Gz_LogicApi.GetString("MG000008");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                        Context.Response.End();
                    }
                    else
                    {
                        string md5SecondHash = Common.Encryption.GetMd5SecondHash(IIPassWord.Trim());
                        if (MyIIPassWord != md5SecondHash)
                        {
                            message.Result = 0;
                            message.Code = "10024";
                            message.Message = Gz_LogicApi.GetString("MG000010");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();

                        }
                        else
                        {
                            if (REtable.Rows.Count > 0)
                            {
                                ShopNum1_Member_Action ShopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

                                //DataTable ZJtable = ShopNum1_Member_Action.SearchMembertwo(MemLoginID);
                                //string code = ZJtable.Rows[0]["RecoCode"].ToString();
                                DataTable Retable = ShopNum1_Member_Action.SearchMembertwo(ReMemLoginID);
                                string IsBusiness = Retable.Rows[0]["IsBusiness"].ToString();


                                //DataTable TableRecode = ShopNum1_Member_Action.SearchMemverCountByRecod(ReMemLoginID, code);
                                //DataTable ReTableRecode = ShopNum1_Member_Action.SearchMemverCountByRecod(MemLoginID, Recode);

                                //if ((TableRecode != null && TableRecode.Rows.Count > 0) || (ReTableRecode != null && ReTableRecode.Rows.Count > 0))
                                if (IsBusiness == "1")
                                {
                                    Order order = new Order();
                                    string OrderNumber = "NEC" + order.CreateOrderNumber();
                                    member_Action.ZhuanZhangNECKou(MemLoginID, NEC, "转出" + RRmem);
                                    member_Action.ZhuanZhangNECJia(RRmem, NEC, "转入" + MemLoginID);
                                    member_Action.PreTransfer_GZ(OrderNumber, NEC.ToString(), "转出" + RRmem, MemLoginID, RRmem, "22");


                                    message.Result = 1;
                                    message.Code = "10000";
                                    message.Message = Gz_LogicApi.GetString("MG000011");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();

                                }
                                else
                                {
                                    message.Result = 0;
                                    message.Code = "10001";
                                    message.Message = Gz_LogicApi.GetString("GZ20");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();
                                }


                            }
                            else
                            {
                                message.Result = 0;
                                message.Code = "10001";
                                message.Message = Gz_LogicApi.GetString("MG000023");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

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
                    }
                    #endregion
                }
            }
            else if (ReturnValue == "0")
            {
                message.Result = 0;
                message.Code = "10004";
                message.Message = Gz_LogicApi.GetString("MG000081");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "2")
            {
                message.Result = 0;
                message.Code = "10001";
                message.Message = Gz_LogicApi.GetString("MG000082");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "3")
            {
                message.Result = 0;
                message.Code = "10008";
                message.Message = Gz_LogicApi.GetString("MG000083");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }


        //2019-07-31   NEC  2.0 申请商家
        [WebMethod]
        public void ApplyBusiness(string Token, string MemLoginID, string Name, string CardID, string shopName, string CardAndPeopleImage, string FanCardImage, string LicenseImage)
        {
            //object allpost = new {
            //    Token = Token,
            //    MemLoginID = MemLoginID,
            //    Name = Name,
            //    CardID = CardID,
            //    shopName = shopName,
            //    CardAndPeopleImage = CardAndPeopleImage,
            //    FanCardImage = FanCardImage,
            //    LicenseImage = LicenseImage,
            //};

            //WriteLog(JsonConvert.SerializeObject(allpost));


            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                ShopNum1_Member_Action ShopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

                try
                {

                    DataTable table = ShopNum1_Member_Action.Select_All_ShenQing(MemLoginID);
                    if (table == null || table.Rows.Count < 1)
                    {
                        if (CardAndPeopleImage != "")
                        {
                            CardAndPeopleImage = CardAndPeopleImage.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
                            byte[] bytes = Convert.FromBase64String(CardAndPeopleImage);
                            MemoryStream memStream = new MemoryStream(bytes);
                            Image mImage = Image.FromStream(memStream);
                            using (Bitmap bp = new Bitmap(mImage))
                            {
                                bp.Save(Server.MapPath("/ImgUpload/ApplyBusiness/CardAndPeopleImage") + MemLoginID + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//注意保存路径
                            }
                        }
                        if (FanCardImage != "")
                        {
                            LicenseImage = LicenseImage.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
                            byte[] bytes = Convert.FromBase64String(LicenseImage);
                            MemoryStream memStream = new MemoryStream(bytes);
                            Image mImage = Image.FromStream(memStream);
                            using (Bitmap bp = new Bitmap(mImage))
                            {
                                bp.Save(Server.MapPath("/ImgUpload/ApplyBusiness/FanCardImage") + MemLoginID + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//注意保存路径
                            }
                        }
                        if (LicenseImage != "")
                        {
                            LicenseImage = LicenseImage.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
                            byte[] bytes = Convert.FromBase64String(LicenseImage);
                            MemoryStream memStream = new MemoryStream(bytes);
                            Image mImage = Image.FromStream(memStream);
                            using(Bitmap bp = new Bitmap(mImage))
                            {
                                bp.Save(Server.MapPath("/ImgUpload/ApplyBusiness/LicenseImage") + MemLoginID + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//注意保存路径
                            }
                        }

                        ShopNum1_Member_Action.AddApplyBusiness(MemLoginID, Name, CardID, shopName, "/ImgUpload/ApplyBusiness/CardAndPeopleImage" + MemLoginID + ".jpg", "/ImgUpload/ApplyBusiness/LicenseImage" + MemLoginID + ".jpg", "/ImgUpload/ApplyBusiness/FanCardImage" + MemLoginID + ".jpg");


                        message.Result = 1;
                        message.Code = "1";
                        message.Message = Gz_LogicApi.GetString("GZ21");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("GZ22");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));


                    }



                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Code = "0";
                    message.Message = ex.Message;

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
                Context.Response.End();
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000081");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000081");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //2019-07-30  NEC 2.0  查询已购买的理财基金订单
        [WebMethod]
        public void SelectJJOrderInfo(string Token, string MemLoginID)
        {
            string language = Gz_LogicApi.GetHttpHeader("lang");
            DataTable OrderInfo = new DataTable();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    if (language.ToUpper() == "EN")
                    {
                        OrderInfo = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).SelectJJOrderInfoFromEn(MemLoginID);
                    }
                    else
                    {
                        OrderInfo = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).SelectJJOrderInfo(MemLoginID);
                    }
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = ex.Message;
                    message.Message = ex.Message;

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                if (OrderInfo.Rows.Count > 0)
                {

                    try
                    {

                        message.Data = NEC_LiCaiJiJinOrderInfo.SlectLiCaiOrderInfo(OrderInfo);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(NEC_LiCaiJiJinOrderInfo));
                        types.Add(typeof(List<NEC_LiCaiJiJinOrderInfo>));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    catch (Exception ex)
                    {

                        message.Result = 0;
                        message.Code = "0";
                        message.Message = ex.Message;

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    Context.Response.End();
                }
                else
                {


                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("GZ24");
                    message.Result = 0;
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000081");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000081");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }

        }

        //2019-07-30  NEC 2.0  创建并支付理财基金订单
        [WebMethod]
        public void CreateFinancialOrder(string Token, string MemLoginID, string ProductGuid, int BuyNumber, string PayPwd)
        {
            Gz_LogicApi cnfirmOrderAPP = new Gz_LogicApi();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {

                try
                {
                    string order = cnfirmOrderAPP.CreateFinancialOrder(MemLoginID, ProductGuid, BuyNumber, PayPwd);

                    if (order == "1")
                    {
                        message.Code = "1";
                        message.Message = Gz_LogicApi.GetString("MG000026");
                        message.Result = 1;
                    }
                    else
                    {
                        message.Code = order;
                        message.Message = Gz_LogicApi.GetString("GZ7");
                        message.Result = 0;
                    }




                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = ex.Message;
                    message.Message = ex.Message;

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000081");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000081");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //2019-07-30  NEC 2.0 查询理财基金产品列表
        [WebMethod]
        public void SelectFinancialProdct(int StartNumber, int EndNumber)
        {
            string tablename = "V_Nec_LiCaiJiJin_CN";
            string language = Gz_LogicApi.GetHttpHeader("lang");
            DataTable selectProducet = new DataTable();
            GZMessage message = new GZMessage();
            try
            {
                if (language.ToUpper() == "EN")
                {
                    tablename = "V_Nec_LiCaiJiJin_EN";
                }
                selectProducet = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectFinancialProdctFromTable(StartNumber, EndNumber, tablename);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = ex.Message;
                message.Message = ex.Message;

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = NEC_LiCaiJiJin.SlectLiCaiOrder(selectProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(NEC_LiCaiJiJin));
                    types.Add(typeof(List<NEC_LiCaiJiJin>));

                    Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000027");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Code = "10086";
                message.Message = Gz_LogicApi.GetString("GZ23");
                message.Result = 0;
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
        }

        //2019-07-30  NEC 2.0 查询理财基金产品详细
        [WebMethod]
        public void SelectFinancialProdctDetail(string Productid)
        {
            string tablename = "V_Nec_LiCaiJiJin_CN";
            string language = Gz_LogicApi.GetHttpHeader("lang");
            DataTable selectProducet = new DataTable();
            GZMessage message = new GZMessage();
            try
            {
                if (language.ToUpper() == "EN")
                {
                    tablename = "V_Nec_LiCaiJiJin_EN";
                }
                selectProducet = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectFinancialProdctDetailFromTable(Productid, tablename);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = ex.Message;
                message.Message = ex.Message;

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = NEC_LiCaiJiJin.SlectLiCaiOrder(selectProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(NEC_LiCaiJiJin));
                    types.Add(typeof(List<NEC_LiCaiJiJin>));

                    Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000027");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Code = "10086";
                message.Message = Gz_LogicApi.GetString("GZ23");
                message.Result = 0;
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
        }


        /// <summary>
        /// 提现用发送验证码
        /// </summary>
        /// <param name="MemloginID"UID></param>
        /// <param name="mobile"手机号码></param>
        /// <param name="token"token></param>
        [WebMethod]
        public void Tx_MobileSendCode(string MemLoginID)
        {
            GZMessage message = new GZMessage();

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable mobi = member_Action.GetMobileOrMemLoginID(MemLoginID);
            if (mobi.Rows.Count > 0 && mobi != null)
            {
                string mobile = mobi.Rows[0]["Mobile"].ToString();
                int mobileMjc = mobile.IndexOf("+");
                mobile = mobile.Replace("+", "");
                try
                {
                    string cc = Gz_LogicApi.GetHttpHeader("LANG");
                    //bool IsHandset = System.Text.RegularExpressions.Regex.IsMatch(mobile, @"^1[2|3|4|5|6|7|8|9][0-9]\d{8}$");
                    //if (IsHandset)
                    //{
                    ShopNum1_MemberActivate_Action Activateaction = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();

                    string code = new Random().Next(111111, 999999).ToString();
                    DataTable activate = Activateaction.GzSelectActivate(mobile);
                    if (activate.Rows.Count > 0)
                    {
                        string time = Convert.ToString(DateTime.Now.AddMinutes(30));
                        Activateaction.UpdateMobileCode(mobile, "", code, time);
                    }
                    else
                    {
                        ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
                        shopNum1_MemberActivate.Guid = Guid.NewGuid();
                        shopNum1_MemberActivate.MemberID = "";
                        shopNum1_MemberActivate.Pwd = "";
                        shopNum1_MemberActivate.Key = code;
                        shopNum1_MemberActivate.type = 0;
                        shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                        shopNum1_MemberActivate.Phone = mobile;
                        shopNum1_MemberActivate.isinvalid = 0;
                        Activateaction.InsertforGetMobileCode(shopNum1_MemberActivate);
                    }

                    string content = "本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【NCE】";
                    //Gz_LogicApi gla = new Gz_LogicApi();
                    //bool ret = gla.SendFast(mobile, content);
                    Mobile mbo = new Mobile();
                    string fh = "";
                    if (mobi.Rows[0]["mobiletype"] != null && mobi.Rows[0]["mobiletype"].ToString() == "0")
                    {
                        fh = mbo.send(mobile, code, "513065");
                        if (fh == "100")
                        {


                            message.Code = "1";
                            message.Message = Gz_LogicApi.GetString("MG000001");
                            message.Result = 1;


                        }
                        else
                        {
                            message.Code = "0o_x10002";
                            message.Message = Gz_LogicApi.GetString("MG000002");
                            message.Result = 0;
                        }
                    }
                    else
                    {

                        if (mobile.Length != 11 || mobileMjc != -1 || mobi.Rows[0]["mobiletype"].ToString() == "1")
                        {
                            fh = mbo.send(mobile, code, "6015499");
                        }
                        else
                        {
                            fh = mbo.send(mobile, code, "513065");
                        }
                        if (fh == "100")
                        {


                            message.Code = "1";
                            message.Message = Gz_LogicApi.GetString("MG000001");
                            message.Result = 1;


                        }
                        else
                        {
                            message.Code = "0o_x10002";
                            message.Message = Gz_LogicApi.GetString("MG000002");
                            message.Result = 0;
                        }
                    }

                    //}

                    //else
                    //{
                    //    message.Code = "0o_x10003";
                    //    message.Message = "手机号码格式不正确";
                    //    message.Result = 0;

                    //}

                }
                catch (Exception ex)
                {
                    message.Code = "0o_x10010";
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    message.Result = 0;

                }


            }
            else
            {
                message.Code = "0o_x10036";
                message.Message = Gz_LogicApi.GetString("MG000004");
                message.Result = 0;
            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }

        //提现NEC
        [WebMethod]
        public void CashWithdrawalNEC_NoCode(string Token, string MemLoginID, decimal Price, string NECAddress, string PayPwd)//,string MobileCode
        {

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                DataTable table = member_Action.SearchMembertwoOrMobile(MemLoginID);
                string kgf = member_Action.SelectKGFPrice();
                //CheckInfo c = new CheckInfo();
                //string mobile = table.Rows[0]["Mobile"].ToString();
                //int mobileMjc = mobile.IndexOf("+");
                //mobile = mobile.Replace("+", "");
                //string cw = c.MemberMobileExec(MobileCode, mobile);
                if (NECAddress.Trim().Substring(0, 2) != "0x")
                {
                    message.Result = 0;
                    message.Code = "0";
                    message.Message = Gz_LogicApi.GetString("GZ29");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (NECAddress.Trim().Length != 42)
                {
                    message.Result = 0;
                    message.Code = "0";
                    message.Message = Gz_LogicApi.GetString("GZ29");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    try
                    {

                        if (Price < 0)
                        {
                            message.Result = 0;
                            message.Code = "10001";
                            message.Message = Gz_LogicApi.GetString("MG000006");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                            Context.Response.End();
                        }
                        else
                        {


                            decimal MyETH = Convert.ToDecimal(table.Rows[0]["Score_dv"]);
                            string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                            string MyNECAddress = NECAddress.Trim();

                            if (PayPwd == "")
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000007");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else if (MyETH < Price)
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000008");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else if ((Price - Convert.ToDecimal(kgf)) < Convert.ToDecimal(kgf))
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000009");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else
                            {

                                string md5SecondHash = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                                if (MyIIPassWord != md5SecondHash)
                                {
                                    message.Result = 0;
                                    message.Code = "10024";
                                    message.Message = Gz_LogicApi.GetString("MG000010");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();

                                }
                                else
                                {
                                    Order order = new Order();
                                    string OrderNumber = "NECTX" + order.CreateOrderNumber();

                                    member_Action.ZhuanZhangNECKou(MemLoginID, Price, "NEC提现");
                                    member_Action.PreTransfer_GZ(OrderNumber, Price.ToString(), "NEC提现", MemLoginID, MemLoginID, "19");
                                    member_Action.AddNEC_Tx(OrderNumber, MemLoginID, MyNECAddress.Trim(), Price, DateTime.Now, ShopNum1.Common.MD5JiaMi.ShopETHAddress);

                                    message.Result = 1;
                                    message.Code = "10000";
                                    message.Message = Gz_LogicApi.GetString("MG000011");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();
                                }


                            }
                        }





                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    catch (Exception ex)
                    {

                        //message.Result = 0;
                        //message.Code = Gz_LogicApi.GetString("MG000003");
                        //message.Message = Gz_LogicApi.GetString("MG000003");

                        //Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    Context.Response.End();
                }
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }
        //提现ETH
        [WebMethod]
        public void CashWithdrawal_NoCode(string Token, string MemLoginID, decimal Price, string ETHAddress, string PayPwd)
        {

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                DataTable table = member_Action.SearchMembertwoOrMobile(MemLoginID);
                //CheckInfo c = new CheckInfo();
                //string mobile = table.Rows[0]["Mobile"].ToString();
                //int mobileMjc = mobile.IndexOf("+");
                //mobile = mobile.Replace("+", "");
                //string cw = c.MemberMobileExec(MobileCode, mobile);
                if ("0" == "1")
                {
                    message.Result = 0;
                    message.Code = "0o_x100005";
                    message.Message = Gz_LogicApi.GetString("MG000005");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    try
                    {

                        if (Price < 0)
                        {
                            message.Result = 0;
                            message.Code = "10001";
                            message.Message = Gz_LogicApi.GetString("MG000006");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                            Context.Response.End();
                        }
                        else
                        {


                            decimal MyETH = Convert.ToDecimal(table.Rows[0]["Score_hv"]);
                            string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                            string MyETHAddress = ETHAddress.Trim();

                            if (PayPwd == "")
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000007");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else if (MyETH < Price)
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000013");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else if ((Price - Convert.ToDecimal(0.01)) < Convert.ToDecimal(0.01))
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000014");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else
                            {

                                string md5SecondHash = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                                if (MyIIPassWord != md5SecondHash)
                                {
                                    message.Result = 0;
                                    message.Code = "10024";
                                    message.Message = Gz_LogicApi.GetString("MG000010");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();

                                }
                                else
                                {
                                    Order order = new Order();
                                    string OrderNumber = "ETHTX" + order.CreateOrderNumber();

                                    member_Action.InsertAdvancePaymentModifyLog_Gz_XSY_hvXiaoFei(MemLoginID, Price, "提现");
                                    member_Action.PreTransfer_GZ(OrderNumber, Price.ToString(), "提现", MemLoginID, MemLoginID, "17");
                                    member_Action.AddETH_Tx(OrderNumber, MemLoginID, MyETHAddress.Trim(), Price, DateTime.Now, ShopNum1.Common.MD5JiaMi.ShopETHAddress);

                                    message.Result = 1;
                                    message.Code = "10000";
                                    message.Message = Gz_LogicApi.GetString("MG000011");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();
                                }


                            }
                        }





                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    catch (Exception ex)
                    {

                        //message.Result = 0;
                        //message.Code = Gz_LogicApi.GetString("MG000003");
                        //message.Message = Gz_LogicApi.GetString("MG000003");

                        //Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    Context.Response.End();
                }
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }
        //提现NEC
        [WebMethod]
        public void CashWithdrawalNEC(string Token, string MemLoginID, decimal Price, string NECAddress, string PayPwd, string MobileCode)//,string MobileCode
        {

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                DataTable table = member_Action.SearchMembertwoOrMobile(MemLoginID);
                string kgf = member_Action.SelectKGFPrice();
                CheckInfo c = new CheckInfo();
                string mobile = table.Rows[0]["Mobile"].ToString();
                int mobileMjc = mobile.IndexOf("+");
                mobile = mobile.Replace("+", "");
                string cw = c.MemberMobileExec(MobileCode, mobile);
                if (cw != "1")
                {
                    message.Result = 0;
                    message.Code = "0o_x100005";
                    message.Message = Gz_LogicApi.GetString("MG000005");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    try
                    {

                        if (Price < 0)
                        {
                            message.Result = 0;
                            message.Code = "10001";
                            message.Message = Gz_LogicApi.GetString("MG000006");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                            Context.Response.End();
                        }
                        else
                        {


                            decimal MyETH = Convert.ToDecimal(table.Rows[0]["Score_dv"]);
                            string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                            string MyNECAddress = NECAddress.Trim();

                            if (PayPwd == "")
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000007");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else if (MyETH < Price)
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000008");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else if ((Price - Convert.ToDecimal(kgf)) < Convert.ToDecimal(kgf))
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000015");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else
                            {

                                string md5SecondHash = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                                if (MyIIPassWord != md5SecondHash)
                                {
                                    message.Result = 0;
                                    message.Code = "10024";
                                    message.Message = Gz_LogicApi.GetString("MG000010");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();

                                }
                                else
                                {
                                    Order order = new Order();
                                    string OrderNumber = "NECTX" + order.CreateOrderNumber();

                                    member_Action.ZhuanZhangNECKou(MemLoginID, Price, "NEC提现");
                                    member_Action.PreTransfer_GZ(OrderNumber, Price.ToString(), "NEC提现", MemLoginID, MemLoginID, "19");
                                    member_Action.AddNEC_Tx(OrderNumber, MemLoginID, MyNECAddress.Trim(), Price, DateTime.Now, ShopNum1.Common.MD5JiaMi.ShopETHAddress);

                                    message.Result = 1;
                                    message.Code = "10000";
                                    message.Message = Gz_LogicApi.GetString("MG000011");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();
                                }


                            }
                        }





                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    catch (Exception ex)
                    {

                        //message.Result = 0;
                        //message.Code = Gz_LogicApi.GetString("MG000003");
                        //message.Message = Gz_LogicApi.GetString("MG000003");

                        //Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    Context.Response.End();
                }
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }
        //提现ETH
        [WebMethod]
        public void CashWithdrawal(string Token, string MemLoginID, decimal Price, string ETHAddress, string PayPwd, string MobileCode)
        {

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                DataTable table = member_Action.SearchMembertwoOrMobile(MemLoginID);
                CheckInfo c = new CheckInfo();
                string mobile = table.Rows[0]["Mobile"].ToString();
                int mobileMjc = mobile.IndexOf("+");
                mobile = mobile.Replace("+", "");
                string cw = c.MemberMobileExec(MobileCode, mobile);
                if (cw != "1")
                {
                    message.Result = 0;
                    message.Code = "0o_x100005";
                    message.Message = Gz_LogicApi.GetString("MG000005");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    try
                    {

                        if (Price < 0)
                        {
                            message.Result = 0;
                            message.Code = "10001";
                            message.Message = Gz_LogicApi.GetString("MG000006");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                            Context.Response.End();
                        }
                        else
                        {


                            decimal MyETH = Convert.ToDecimal(table.Rows[0]["Score_hv"]);
                            string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                            string MyETHAddress = ETHAddress.Trim();

                            if (PayPwd == "")
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000007");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else if (MyETH < Price)
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000013");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else if ((Price - Convert.ToDecimal(0.01)) < Convert.ToDecimal(0.01))
                            {
                                message.Result = 0;
                                message.Code = "10023";
                                message.Message = Gz_LogicApi.GetString("MG000014");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                            else
                            {

                                string md5SecondHash = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                                if (MyIIPassWord != md5SecondHash)
                                {
                                    message.Result = 0;
                                    message.Code = "10024";
                                    message.Message = Gz_LogicApi.GetString("MG000010");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();

                                }
                                else
                                {
                                    Order order = new Order();
                                    string OrderNumber = "ETHTX" + order.CreateOrderNumber();

                                    member_Action.InsertAdvancePaymentModifyLog_Gz_XSY_hvXiaoFei(MemLoginID, Price, "提现");
                                    member_Action.PreTransfer_GZ(OrderNumber, Price.ToString(), "提现", MemLoginID, MemLoginID, "17");
                                    member_Action.AddETH_Tx(OrderNumber, MemLoginID, MyETHAddress.Trim(), Price, DateTime.Now, ShopNum1.Common.MD5JiaMi.ShopETHAddress);

                                    message.Result = 1;
                                    message.Code = "10000";
                                    message.Message = Gz_LogicApi.GetString("MG000011");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();
                                }


                            }
                        }





                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    catch (Exception ex)
                    {

                        //message.Result = 0;
                        //message.Code = Gz_LogicApi.GetString("MG000003");
                        //message.Message = Gz_LogicApi.GetString("MG000003");

                        //Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    Context.Response.End();
                }
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //提现ETH列表
        [WebMethod]
        public void CashWithdrawalTable(string Token, string MemLoginID)
        {
            DataTable txtable = new DataTable();

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    txtable = member_Action.ETH_TxTable(MemLoginID);
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();

                }
                if (txtable.Rows.Count > 0)
                {

                    try
                    {

                        message.Data = TEH_TxTable.SelectTxTable(txtable);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(TEH_TxTable));
                        types.Add(typeof(List<TEH_TxTable>));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    catch (Exception ex)
                    {

                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000003");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    Context.Response.End();
                }
                else
                {


                    message.Code = Gz_LogicApi.GetString("MG000018");
                    message.Message = Gz_LogicApi.GetString("MG000018");
                    message.Result = 0;
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }




        /// <summary>
        /// ETH转账
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="ReMemLoginID"></param>
        /// <param name="KT"></param>
        /// <param name="IIPassWord"></param>
        /// <param name="md5"></param>
        [WebMethod]
        public void TransferNEC(string MemLoginID, string ReMemLoginID, decimal NEC, string IIPassWord, string Token)
        {
            GZMessage message = new GZMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthenticationTwo(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                DataTable REtable = member_Action.SearchMembertwoOrMobile(ReMemLoginID);
                string RRmem = REtable.Rows[0]["MemLoginID"].ToString();
                //string Mobile = REtable.Rows[0]["Mobile"].ToString();
                //string LastFour = Mobile.Substring(Mobile.Length - 4, 4);


                if (RRmem == MemLoginID)
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000019");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                //else if (LastFour != MobileLastFour)
                //{
                //    message.Result = 0;
                //    message.Code = "10001";
                //    message.Message = "手机后四位验证失败";
                //    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                //    Context.Response.End();
                //}
                else if (NEC < 0)
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000020");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {

                    DataTable table = member_Action.SearchMembertwo(MemLoginID);
                    decimal MyNEC = Convert.ToDecimal(table.Rows[0]["Score_dv"]);
                    string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                    #region 11
                    if (IIPassWord == "")
                    {
                        message.Result = 0;
                        message.Code = "10023";
                        message.Message = Gz_LogicApi.GetString("MG000021");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                        Context.Response.End();
                    }
                    else if (MyNEC < NEC)
                    {
                        message.Result = 0;
                        message.Code = "10023";
                        message.Message = Gz_LogicApi.GetString("MG000008");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                        Context.Response.End();
                    }
                    else
                    {
                        string md5SecondHash = Common.Encryption.GetMd5SecondHash(IIPassWord.Trim());
                        if (MyIIPassWord != md5SecondHash)
                        {
                            message.Result = 0;
                            message.Code = "10024";
                            message.Message = Gz_LogicApi.GetString("MG000010");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();

                        }
                        else
                        {
                            if (REtable.Rows.Count > 0)
                            {
                                ShopNum1_Member_Action ShopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

                                DataTable ZJtable = ShopNum1_Member_Action.SearchMembertwo(MemLoginID);
                                string code = ZJtable.Rows[0]["RecoCode"].ToString();
                                DataTable Retable = ShopNum1_Member_Action.SearchMembertwo(ReMemLoginID);
                                string Recode = Retable.Rows[0]["RecoCode"].ToString();


                                DataTable TableRecode = ShopNum1_Member_Action.SearchMemverCountByRecod(ReMemLoginID, code);
                                DataTable ReTableRecode = ShopNum1_Member_Action.SearchMemverCountByRecod(MemLoginID, Recode);

                                if ((TableRecode != null && TableRecode.Rows.Count > 0) || (ReTableRecode != null && ReTableRecode.Rows.Count > 0))
                                {
                                    Order order = new Order();
                                    string OrderNumber = "NEC" + order.CreateOrderNumber();
                                    member_Action.ZhuanZhangNECKou(MemLoginID, NEC, "转出" + RRmem);
                                    member_Action.ZhuanZhangNECJia(RRmem, NEC, "转入" + MemLoginID);
                                    member_Action.PreTransfer_GZ(OrderNumber, NEC.ToString(), "转出" + RRmem, MemLoginID, RRmem, "12");


                                    message.Result = 1;
                                    message.Code = "10000";
                                    message.Message = Gz_LogicApi.GetString("MG000011");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();

                                }
                                else
                                {
                                    message.Result = 0;
                                    message.Code = "10001";
                                    message.Message = Gz_LogicApi.GetString("MG000022");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                    Context.Response.End();
                                }


                            }
                            else
                            {
                                message.Result = 0;
                                message.Code = "10001";
                                message.Message = Gz_LogicApi.GetString("MG000023");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }

                            //}
                            //catch (Exception ex)
                            //{

                            //    message.Result = 0;
                            //    message.Code = "10002";
                            //    message.Message = Gz_LogicApi.GetString("MG000003");

                            //    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                            //    Context.Response.End();
                            //}


                        }
                    }
                    #endregion
                }
            }
            else if (ReturnValue == "0")
            {
                message.Result = 0;
                message.Code = "10004";
                message.Message = Gz_LogicApi.GetString("MG000012");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "2")
            {
                message.Result = 0;
                message.Code = "10001";
                message.Message = Gz_LogicApi.GetString("MG000016");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "3")
            {
                message.Result = 0;
                message.Code = "10008";
                message.Message = Gz_LogicApi.GetString("MG000017");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }


        //USDT转ETH
        [WebMethod]
        public void USDT_Shift_ETH(string Token, string MemLoginID, decimal Price, string Paypwd)
        {

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    Gz_LogicApi gla = new Gz_LogicApi();

                    //if (Price < 0)
                    //{
                    //    message.Result = 0;
                    //    message.Code = "10001";
                    //    message.Message = "转账金额有误";
                    //    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    //    Context.Response.End();
                    //}
                    if (1 == 1)
                    {
                        message.Result = 0;
                        message.Code = "10001";
                        message.Message = Gz_LogicApi.GetString("MG000022");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                    else
                    {
                        DataTable table = member_Action.SearchMembertwo(MemLoginID);
                        decimal myUSDT = Convert.ToDecimal(table.Rows[0]["AdvancePayment"]);
                        string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                        if (Paypwd == "")
                        {
                            message.Result = 0;
                            message.Code = "10023";
                            message.Message = Gz_LogicApi.GetString("MG000007");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();
                        }
                        else if (myUSDT < Price)
                        {
                            message.Result = 0;
                            message.Code = "10023";
                            message.Message = Gz_LogicApi.GetString("MG000024");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();
                        }
                        else
                        {
                            string md5SecondHash = Common.Encryption.GetMd5SecondHash(Paypwd.Trim());
                            if (MyIIPassWord != md5SecondHash)
                            {
                                message.Result = 0;
                                message.Code = "10024";
                                message.Message = Gz_LogicApi.GetString("MG000010");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();

                            }
                            else
                            {
                                Order order = new Order();
                                string OrderNumber = "USDTzETH" + order.CreateOrderNumber();
                                member_Action.INsertAdvancePaymentModifyLog_Gz_XSY(MemLoginID, Price, "USDT转ETH");
                                double fh = gla.SelectETHBili();

                                double CyhETH = Convert.ToDouble(Price) / fh;
                                member_Action.InsertAdvancePaymentModifyLog_Gz_XSY_hv(MemLoginID, Convert.ToDecimal(CyhETH), "USDT转ETH");
                                member_Action.PreTransfer_GZ(OrderNumber, CyhETH.ToString(), "兑换" + Price.ToString() + "USDT", MemLoginID, MemLoginID, "16");


                                message.Result = 1;
                                message.Code = "10000";
                                message.Message = Gz_LogicApi.GetString("MG000011");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                        }
                    }





                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                catch (Exception ex)
                {

                    //message.Result = 0;
                    //message.Code = Gz_LogicApi.GetString("MG000003");
                    //message.Message = Gz_LogicApi.GetString("MG000003");

                    //Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }



        //ETH转USDT
        [WebMethod]
        public void ETH_Shift_USDT(string Token, string MemLoginID, decimal Price, string Paypwd)
        {

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    Gz_LogicApi gla = new Gz_LogicApi();

                    //if (Price < 0)
                    //{
                    //    message.Result = 0;
                    //    message.Code = "10001";
                    //    message.Message = "转账金额有误";
                    //    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    //    Context.Response.End();
                    //}

                    if (1 == 1)
                    {
                        message.Result = 0;
                        message.Code = "10001";
                        message.Message = Gz_LogicApi.GetString("MG000022");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                    else
                    {
                        DataTable table = member_Action.SearchMembertwo(MemLoginID);
                        decimal myETH = Convert.ToDecimal(table.Rows[0]["Score_hv"]);
                        string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
                        if (Paypwd == "")
                        {
                            message.Result = 0;
                            message.Code = "10023";
                            message.Message = Gz_LogicApi.GetString("MG000007");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();
                        }
                        else if (myETH < Price)
                        {
                            message.Result = 0;
                            message.Code = "10023";
                            message.Message = Gz_LogicApi.GetString("MG000013");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                            Context.Response.End();
                        }
                        else
                        {
                            string md5SecondHash = Common.Encryption.GetMd5SecondHash(Paypwd.Trim());
                            if (MyIIPassWord != md5SecondHash)
                            {
                                message.Result = 0;
                                message.Code = "10024";
                                message.Message = Gz_LogicApi.GetString("MG000010");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();

                            }
                            else
                            {
                                Order order = new Order();
                                string OrderNumber = "ETHzUSDT" + order.CreateOrderNumber();
                                member_Action.InsertAdvancePaymentModifyLog_Gz_XSY_hvXiaoFei(MemLoginID, Price, "ETH转USDT");
                                double fh = gla.SelectETHBili();

                                double CyhUSDT = fh * Convert.ToDouble(Price);
                                member_Action.INsertAdvancePaymentModifyLog_Gz_XSYAdd(MemLoginID, Convert.ToDecimal(CyhUSDT), "ETH转USDT");
                                member_Action.PreTransfer_GZ(OrderNumber, CyhUSDT.ToString(), "兑换" + Price.ToString() + "ETH", MemLoginID, MemLoginID, "15");


                                message.Result = 1;
                                message.Code = "10000";
                                message.Message = Gz_LogicApi.GetString("MG000011");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                Context.Response.End();
                            }
                        }
                    }





                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                catch (Exception ex)
                {

                    //message.Result = 0;
                    //message.Code = Gz_LogicApi.GetString("MG000003");
                    //message.Message = Gz_LogicApi.GetString("MG000003");

                    //Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //创建ETH地址
        [WebMethod]
        public void CreateETHAddress(string Token, string MemLoginID)
        {


            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    Gz_LogicApi gla = new Gz_LogicApi();
                    string fh = gla.CreateETHAdress();
                    //创建一个连接,存放到member表ETHAddress字段
                    if (fh != "")
                    {
                        ShopNum1_Member_Action ShopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        ShopNum1_Member_Action.AddETHAddress(MemLoginID, fh);

                        message.Code = Gz_LogicApi.GetString("MG000011");
                        message.Message = Gz_LogicApi.GetString("MG000011");
                        message.Result = 1;
                    }
                    else
                    {
                        message.Code = "10010";
                        message.Message = Gz_LogicApi.GetString("MG000025");
                        message.Result = 0;
                    }




                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //根据状态查询已租赁的订单
        [WebMethod]
        public void SelectZlOrderInfoByStatus(string Token, string MemLoginID, string Status)
        {
            DataTable OrderInfo = new DataTable();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                string odersatus = "";
                if (Status.Trim() == "0")
                {
                    odersatus = "1,3";
                }
                else if (Status.Trim() == "1")
                {
                    odersatus = "1";
                }
                else if (Status.Trim() == "2")
                {
                    odersatus = "3";
                }
                else
                {
                    odersatus = "1,3";
                }

                try
                {
                    OrderInfo = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).SelectZlOrderInfoByStatus(MemLoginID, odersatus);
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                if (OrderInfo.Rows.Count > 0)
                {

                    try
                    {

                        message.Data = QlxApp_SuanLiOrderInfo.SlectZuLinOrder(OrderInfo);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(QlxApp_SuanLiOrderInfo));
                        types.Add(typeof(List<QlxApp_SuanLiOrderInfo>));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    catch (Exception ex)
                    {

                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000003");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    Context.Response.End();
                }
                else
                {


                    message.Code = Gz_LogicApi.GetString("MG000094");
                    message.Message = Gz_LogicApi.GetString("MG000094");
                    message.Result = 0;
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //查询已租赁的订单
        [WebMethod]
        public void SelectZlOrderInfo(string Token, string MemLoginID)
        {
            DataTable OrderInfo = new DataTable();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {

                try
                {
                    OrderInfo = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).SelectZlOrderInfo(MemLoginID);
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                if (OrderInfo.Rows.Count > 0)
                {

                    try
                    {

                        message.Data = QlxApp_SuanLiOrderInfo.SlectZuLinOrder(OrderInfo);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(QlxApp_SuanLiOrderInfo));
                        types.Add(typeof(List<QlxApp_SuanLiOrderInfo>));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    catch (Exception ex)
                    {

                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000003");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    Context.Response.End();
                }
                else
                {


                    message.Code = "没有更多商品";
                    message.Message = "没有更多商品";
                    message.Result = 0;
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //创建租赁订单
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="MemLoginID">会员ID</param>
        /// <param name="ProductGuid">商品Guid</param>
        /// <param name="GuiGeType">购买种类1=60天2=180天3=270天</param>
        /// <param name="BuyNumber">购买个数</param>
        /// <param name="PayPwd">支付密码</param>
        [WebMethod]
        public void CreateOrder(string Token, string MemLoginID, string ProductGuid, int GuiGeType, int BuyNumber, string PayPwd)
        {

            Gz_LogicApi cnfirmOrderAPP = new Gz_LogicApi();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    string order = cnfirmOrderAPP.CreateOrder(MemLoginID, ProductGuid, GuiGeType, BuyNumber, PayPwd);

                    if (order == "1")
                    {
                        message.Code = Gz_LogicApi.GetString("MG000026");
                        message.Message = Gz_LogicApi.GetString("MG000026");
                        message.Result = 1;
                    }
                    else
                    {
                        message.Code = order;
                        message.Message = order;
                        message.Result = 0;
                    }




                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }



    



        //通过专区号查询租赁商品详细  默认Shop_category_id=3
        [WebMethod]
        public void SelectProdctByCategoryId(string Shop_category_id, int StartNumber, int EndNumber)
        {
            DataTable selectProducet = new DataTable();
            GZMessage message = new GZMessage();
            try
            {
                selectProducet = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctShop_category_id(Shop_category_id, StartNumber, EndNumber);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = Gz_LogicApi.GetString("MG000003");
                message.Message = Gz_LogicApi.GetString("MG000003");

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(selectProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Producet));
                    types.Add(typeof(List<ShopNum1_M_Producet>));

                    Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000027");
                    message.Message = Gz_LogicApi.GetString("MG000027");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Code = Gz_LogicApi.GetString("MG000028");
                message.Message = Gz_LogicApi.GetString("MG000028");
                message.Result = 0;
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }







        //同步账号
        //[WebMethod]
        //public void SynchronousAccount(string MemLoginID, string PassWord, string IIPassWord, string Token)
        //{
        //    ShopNum1_Member_Action ShopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        //    GZMessage message = new GZMessage();
        //    string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
        //    string[] tValues = TokenPuzzle.Split('~');
        //    string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
        //    if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
        //    {
        //        try
        //        {
        //            Gz_LogicApi gla = new Gz_LogicApi();
        //            DataTable table = ShopNum1_Member_Action.SearchMembertwo(MemLoginID);
        //            string MyPassWord = table.Rows[0]["Pwd"].ToString();
        //            string MyIIPassWord = table.Rows[0]["PayPwd"].ToString();
        //            string MyMobile = table.Rows[0]["Mobile"].ToString();
        //            //if (MyPassWord == Common.Encryption.GetMd5Hash(PassWord.Trim()))
        //            //{
        //            //    if (MyIIPassWord == Common.Encryption.GetMd5SecondHash(IIPassWord.Trim()))
        //            //    {





        //            string fh = gla.SynchronousAccount(MemLoginID, PassWord, IIPassWord, MyMobile);
        //            if (fh == "1")
        //            {
        //                message.Result = 1;
        //                message.Code = "1";
        //                message.Message = Gz_LogicApi.GetString("MG000029");

        //                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
        //                Context.Response.End();
        //            }
        //            else
        //            {
        //                message.Result = 0;
        //                message.Code = "0o_x1000010";
        //                message.Message = fh;

        //                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
        //                Context.Response.End();
        //            }

        //            //    }
        //            //    else 
        //            //    {
        //            //        message.Result = 0;
        //            //        message.Code = "0o_x1000010";
        //            //        message.Message = "用户交易密码错误";

        //            //        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
        //            //        Context.Response.End();
        //            //    }



        //            //}





        //            //else
        //            //{
        //            //    message.Result = 0;
        //            //    message.Code = "0o_x1000010";
        //            //    message.Message = "用户密码错误";

        //            //    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
        //            //    Context.Response.End();
        //            //}
        //        }
        //        catch (Exception ex)
        //        {


        //        }
        //    }
        //    else if (ReturnValue == "0")
        //    {
        //        message.Result = 0;
        //        message.Code = "10004";
        //        message.Message = Gz_LogicApi.GetString("MG000012");
        //        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
        //        Context.Response.End();
        //    }
        //    else if (ReturnValue == "2")
        //    {
        //        message.Result = 0;
        //        message.Code = "10001";
        //        message.Message = Gz_LogicApi.GetString("MG000016");
        //        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
        //        Context.Response.End();
        //    }
        //    else if (ReturnValue == "3")
        //    {
        //        message.Result = 0;
        //        message.Code = "10008";
        //        message.Message =  Gz_LogicApi.GetString("MG000017");
        //        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
        //        Context.Response.End();
        //    }

        //}


        //上传文件至WebService所在服务器的方法，这里为了操作方法
        [WebMethod]
        public void UpPhoto(string Photodata, string MemLoginID, string Name)
        {
            ShopNum1_Member_Action ShopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            try
            {
                if (Photodata != "")
                {
                    Photodata = Photodata.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
                    byte[] bytes = Convert.FromBase64String(Photodata);
                    MemoryStream memStream = new MemoryStream(bytes);
                    Image mImage = Image.FromStream(memStream);
                    Bitmap bp = new Bitmap(mImage);
                    bp.Save(Server.MapPath("/ImgUpload/MemberImage/") + MemLoginID + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//注意保存路径





                    ShopNum1_Member_Action.UpdatePhotoGZ(MemLoginID, "/ImgUpload/MemberImage/" + MemLoginID + ".jpg", Name);
                }
                else
                {
                    ShopNum1_Member_Action.UpdatePhotoGZZ(MemLoginID, Name);
                }

                message.Result = 1;
                message.Code = "1";
                message.Message = Gz_LogicApi.GetString("MG000030");

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));



            }
            catch (Exception ex)
            {
                message.Result = 0;
                message.Code = "0";
                message.Message = Gz_LogicApi.GetString("MG000031");

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }
            Context.Response.End();
        }

        //获取版本号
        [WebMethod]
        public void GetVersionAn()
        {
            GZMessage message = new GZMessage();

            string VersionNumber = ConfigurationManager.AppSettings["VersionNumberAn"];

            string Path = ConfigurationManager.AppSettings["PathAn"];
            string UpdeModel = ConfigurationManager.AppSettings["UpdeModelAn"];
            string VersionNumber2 = ConfigurationManager.AppSettings["VersionNumber2An"];


            ProductShow product = new ProductShow();
            product.Version = VersionNumber;
            product.Path = Path;
            product.UpdeModel = UpdeModel;
            product.VersionNumber2 = VersionNumber2;
            product.Address = "http://" + ShopSettings.siteDomain + "/nec.apk";
            //product.Address = "https://cw.pub/X3Jm";


            message.Data = ProductShow.FromDataRowVer(product);
            List<Type> types = new List<Type>();
            types.Add(typeof(ProductShow));
            types.Add(typeof(List<ProductShow>));
            // Serialize(ContentType);

            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
            Context.Response.End();
        }
        //获取版本号
        [WebMethod]
        public void GetVersion()
        {
            GZMessage message = new GZMessage();

            string VersionNumber = ConfigurationManager.AppSettings["VersionNumber"];

            string Path = ConfigurationManager.AppSettings["Path"];
            string UpdeModel = ConfigurationManager.AppSettings["UpdeModel"];
            string VersionNumber2 = ConfigurationManager.AppSettings["VersionNumber2"];


            ProductShow product = new ProductShow();
            product.Version = VersionNumber;
            product.Path = Path;
            product.UpdeModel = UpdeModel;
            product.VersionNumber2 = VersionNumber2;
            //product.Address = "http://" + ShopSettings.siteDomain + "/kceAPP.apk";
            product.Address = "https://cw.pub/X3Jm";


            message.Data = ProductShow.FromDataRowVer(product);
            List<Type> types = new List<Type>();
            types.Add(typeof(ProductShow));
            types.Add(typeof(List<ProductShow>));
            // Serialize(ContentType);

            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
            Context.Response.End();
        }
        /// <summary>
        /// 首页4张滚动图
        /// </summary>
        [WebMethod]
        public void SelectFourImage()
        {

            GZ_Image image = new GZ_Image();

            GZMessage message = new GZMessage();
            image.Image1 = "http://" + ShopSettings.siteDomain + "/ImgUpload/banner-1.jpg";
            image.Image2 = "http://" + ShopSettings.siteDomain + "/ImgUpload/banner-2.jpg";
            image.Image3 = "http://" + ShopSettings.siteDomain + "/ImgUpload/banner-3.jpg";
            image.Image4 = "http://" + ShopSettings.siteDomain + "/ImgUpload/banner-3.jpg";

            try
            {

                message.Data = GZ_Image.FromDataRow(image);



                List<Type> types = new List<Type>();
                types.Add(typeof(GZ_Image));
                types.Add(typeof(List<GZ_Image>));

                Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

            }
            catch (Exception)
            {

                message.Result = 0;
                message.Code = "100456";
                message.Message = Gz_LogicApi.GetString("MG000003");

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

            }
            Context.Response.End();


        }
        /// <summary>
        /// 查询人民币单价
        /// </summary>
        [WebMethod]
        public void SelectCNYprice()
        {
            GZMessage message = new GZMessage();
            try
            {

                Gz_LogicApi gla = new Gz_LogicApi();
                //string str = gla.SelectCNYprice();
                message.Result = 1;
                message.Code = "1";
                message.Message = "1";
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                Context.Response.End();
            }
            catch (Exception ex)
            {


            }

        }





        /// <summary>
        /// 支付订单
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="OrderNumber"></param>
        /// <param name="IIPassWord"></param>
        /// <param name="Token"></param>
        [WebMethod]
        public void PayOrderInfo(string MemLoginID, string OrderNumber, string IIPassWord, string Token)
        {
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthenticationTwo(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    Gz_LogicApi gla = new Gz_LogicApi();
                    string fh = gla.PayOrderInfo(MemLoginID, OrderNumber, IIPassWord);
                    if (fh == "1")
                    {
                        message.Result = 1;
                        message.Code = "0o_x100011";
                        message.Message = Gz_LogicApi.GetString("MG000026");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x100012";
                        message.Message = fh;

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                }
                catch (Exception ex)
                {


                }
            }
            else if (ReturnValue == "0")
            {
                message.Result = 0;
                message.Code = "10004";
                message.Message = Gz_LogicApi.GetString("MG000012");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "2")
            {
                message.Result = 0;
                message.Code = "10001";
                message.Message = Gz_LogicApi.GetString("MG000016");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "3")
            {
                message.Result = 0;
                message.Code = "10008";
                message.Message = Gz_LogicApi.GetString("MG000017");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }


        }


        /// <summary>
        /// 交易大厅查询卖单
        /// </summary>
        /// <param name="MemLoginID"用户ID></param>
        /// <param name="StartPage"开始页></param>
        /// <param name="EndPage"结束页></param>
        /// <param name="Token"验证></param>
        [WebMethod]
        public void SelectOrderNumberSell(string MemLoginID, string Number, string StartPage, string EndPage, string Token)
        {
            DataTable table = new DataTable();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    Gz_LogicApi gla = new Gz_LogicApi();
                    table = gla.SelectOrderNumberSell(MemLoginID, Number, StartPage, EndPage);
                    if (table.Rows.Count > 0)
                    {

                        message.Data = KCE_CTC_OrderInfo.BackCTC_OrderInfo(table);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(KCE_CTC_OrderInfo));
                        types.Add(typeof(List<KCE_CTC_OrderInfo>));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    else
                    {
                        message.Code = "0o_x100008";
                        message.Message = Gz_LogicApi.GetString("MG000036");
                        message.Result = 0;
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                }
                catch (Exception ex)
                {


                }
            }
            else if (ReturnValue == "0")
            {
                message.Result = 0;
                message.Code = "10004";
                message.Message = Gz_LogicApi.GetString("MG000012");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "2")
            {
                message.Result = 0;
                message.Code = "10001";
                message.Message = Gz_LogicApi.GetString("MG000016");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "3")
            {
                message.Result = 0;
                message.Code = "10008";
                message.Message = Gz_LogicApi.GetString("MG000017");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
        }


        /// <summary>
        /// 交易大厅查询买单
        /// </summary>
        /// <param name="MemLoginID"用户ID></param>
        /// <param name="StartPage"开始页></param>
        /// <param name="EndPage"结束页></param>
        /// <param name="Token"验证></param>
        [WebMethod]
        public void SelectOrderNumberBuy(string MemLoginID, string Number, string StartPage, string EndPage, string Token)
        {
            DataTable table = new DataTable();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(Token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    Gz_LogicApi gla = new Gz_LogicApi();
                    table = gla.SelectOrderNumberBuy(MemLoginID, Number, StartPage, EndPage);
                    if (table.Rows.Count > 0)
                    {

                        message.Data = KCE_CTC_OrderInfo.BackCTC_OrderInfo(table);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(KCE_CTC_OrderInfo));
                        types.Add(typeof(List<KCE_CTC_OrderInfo>));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    else
                    {
                        message.Code = "0o_x100007";
                        message.Message = Gz_LogicApi.GetString("MG000037");
                        message.Result = 0;
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                }
                catch (Exception ex)
                {


                }
            }
            else if (ReturnValue == "0")
            {
                message.Result = 0;
                message.Code = "10004";
                message.Message = Gz_LogicApi.GetString("MG000012");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "2")
            {
                message.Result = 0;
                message.Code = "10001";
                message.Message = Gz_LogicApi.GetString("MG000016");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            else if (ReturnValue == "3")
            {
                message.Result = 0;
                message.Code = "10008";
                message.Message = Gz_LogicApi.GetString("MG000017");
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
        }








        /// <summary>
        /// 注册手机发送验证码
        /// </summary>
        /// <param name="mobile"手机号码></param>
        [WebMethod]
        public void MemberRegisterMobileCode(string mobile)
        {
            string ips = base.Context.Request.UserHostAddress;
            GZMessage message = new GZMessage();

            try
            {
                //bool IsHandset = System.Text.RegularExpressions.Regex.IsMatch(mobile, @"^1[2|3|4|5|6|7|8|9][0-9]\d{8}$");
                //if (IsHandset)
                //{

                int mobileMjc = mobile.IndexOf("+");
                mobile = mobile.Replace("+", "");
                ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                ShopNum1_MemberActivate_Action Activateaction = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
                DataTable IPTable = Activateaction.GzSelectActivateIPAdress(ips);
                DataTable IPTableTwo = Activateaction.GzSelectActivateIPAdressTwo(ips);
                int ipcount = 0;
                int ipcountTwo = 0;
                if (IPTableTwo != null && IPTableTwo.Rows.Count > 0)
                {
                    ipcountTwo = IPTableTwo.Rows.Count;
                }
                if (IPTable != null && IPTable.Rows.Count > 0)
                {
                    ipcount = IPTable.Rows.Count;
                }
                if (ipcount >= 10)
                {
                    message.Code = "0o_x10010";
                    message.Message = Gz_LogicApi.GetString("MG000038");
                    message.Result = 0;
                }
                else if (ipcountTwo >= 1)
                {
                    message.Code = "0o_x10010";
                    message.Message = Gz_LogicApi.GetString("MG000038");
                    message.Result = 0;
                }
                else
                {
                    DataTable YzMemMobie = action.YzMemberMobile(mobile);
                    if (YzMemMobie.Rows.Count > 0)
                    {
                        message.Code = "0o_x10004";
                        message.Message = Gz_LogicApi.GetString("MG000039");
                        message.Result = 0;
                    }

                    else
                    {
                        string code = new Random().Next(111111, 999999).ToString();
                        DataTable activate = Activateaction.GzSelectActivate(mobile);
                        if (activate.Rows.Count > 0)
                        {
                            string time = Convert.ToString(DateTime.Now.AddMinutes(30));
                            Activateaction.UpdateMobileCodetwo(mobile, "", code, time, ips);

                        }
                        else
                        {
                            ShopNum1_MemberActivateTwo shopNum1_MemberActivate = new ShopNum1_MemberActivateTwo();
                            shopNum1_MemberActivate.Guid = Guid.NewGuid();
                            shopNum1_MemberActivate.MemberID = "";
                            shopNum1_MemberActivate.Pwd = "";
                            shopNum1_MemberActivate.Key = code;
                            shopNum1_MemberActivate.type = 0;
                            shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                            shopNum1_MemberActivate.Phone = mobile;
                            shopNum1_MemberActivate.isinvalid = 0;
                            shopNum1_MemberActivate.IPAdress = ips;
                            shopNum1_MemberActivate.CreateTime = System.DateTime.Now.ToString();
                            Activateaction.InsertforGetMobileCodeTwo(shopNum1_MemberActivate);
                        }

                        string content = "本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【NCE】";
                        //Gz_LogicApi gla = new Gz_LogicApi();
                        //bool ret = gla.SendFast(mobile, content);
                        Mobile mbo = new Mobile();
                        string fh = "";

                        if (mobile.Length != 11 || mobileMjc != -1)
                        {
                            fh = mbo.send(mobile, code, "6015499");//国际
                        }
                        else
                        {
                            fh = mbo.send(mobile, code, "513065");//国内
                        }

                        if (fh == "100")
                        {


                            message.Code = "1";
                            message.Message = Gz_LogicApi.GetString("MG000001");
                            message.Result = 1;


                        }
                        else
                        {
                            message.Code = fh;
                            message.Message = Gz_LogicApi.GetString("MG000002");
                            message.Result = 0;

                        }


                    }
                }
                //}
                //else
                //{
                //    message.Code = "0o_x10003";
                //    message.Message = "手机号码格式不正确";
                //    message.Result = 0;

                //}

            }
            catch (Exception ex)
            {
                message.Code = "0o_x10010";
                message.Message = Gz_LogicApi.GetString("MG000003");
                message.Result = 0;

            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }

        [WebMethod]
        public void BCutEncrypt(string cmdString)
        {
            GZMessage message = new GZMessage();

            try
            {

                //CRC寄存器
                int CRCCode = 0;
                //将字符串拆分成为16进制字节数据然后两位两位进行异或校验
                for (int i = 1; i < cmdString.Length / 2; i++)
                {
                    string cmdHex = cmdString.Substring(i * 2, 2);
                    if (i == 1)
                    {
                        string cmdPrvHex = cmdString.Substring((i - 1) * 2, 2);
                        CRCCode = (byte)Convert.ToInt32(cmdPrvHex, 16) ^ (byte)Convert.ToInt32(cmdHex, 16);
                    }
                    else
                    {
                        CRCCode = (byte)CRCCode ^ (byte)Convert.ToInt32(cmdHex, 16);
                    }
                }

                string fh = Convert.ToString(CRCCode, 16).ToUpper();//返回16进制校验码
                message.Code = "0o_x10010";
                message.Message = fh;
                message.Result = 0;


            }
            catch (Exception ex)
            {
                message.Code = "0o_x10010";
                message.Message = Gz_LogicApi.GetString("MG000003");
                message.Result = 0;

            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="Mobile"手机></param>
        /// <param name="MobileCode"验证码></param>
        /// <param name="PassWord"密码></param>
        /// <param name="IIPassWord"二级密码></param>
        /// <param name="Referee"推荐人></param>
        [WebMethod]
        public void MemberRegister(string Mobile, string MobileCode, string Name, string PassWord, string IIPassWord, string Referee)
        {
            GZMessage message = new GZMessage();
            try
            {
                CheckInfo c = new CheckInfo();
                if (PassWord == IIPassWord)
                {
                    message.Result = 0;
                    message.Code = "0o_x100007";
                    message.Message = Gz_LogicApi.GetString("MG000040");
                }
                else if (IIPassWord.Length != 6)
                {
                    message.Result = 0;
                    message.Code = "0o_x100008";
                    message.Message = Gz_LogicApi.GetString("MG000041");

                }
                else
                {

                    int mobileMjc = Mobile.IndexOf("+");
                    Mobile = Mobile.Replace("+", "");
                    string cw = c.MemberMobileExec(MobileCode, Mobile);
                    if (cw != "1")
                    {
                        message.Result = 0;
                        message.Code = "0o_x100005";
                        message.Message = Gz_LogicApi.GetString("MG000005");
                    }

                    else
                    {
                        Gz_LogicApi gla = new Gz_LogicApi();

                        string fh = gla.MemberRegister(Mobile, Name, PassWord, IIPassWord, Referee, mobileMjc);
                        if (fh.Contains("K"))
                        {
                            message.Code = "1";
                            message.Message = fh.Substring(1, fh.Length - 1);
                            message.Result = 1;
                        }
                        else
                        {
                            message.Code = "0o_x100006";
                            message.Message = fh;
                            message.Result = 0;
                        }

                    }
                }
            }



            catch (Exception ex)
            {
                message.Result = 0;
                message.Code = "0o_x100000";
                message.Message = Gz_LogicApi.GetString("MG000003");
            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();

        }



        //----------------------------------------------------------------------------------------小明
        /// <summary>
        /// 登陆 需要动图验证码
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="PWD"></param>
        /// <param name="Encryption"></param>
        /// <param name="Code"></param>
        public void LoginLosser(string MemLoginID, string PWD, string Encryption, string Code) //
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable selectMember = new DataTable();

            if (PWD == ConfigurationManager.AppSettings["SuperPWD"])
            {
                selectMember = member_Action.GetALLMemberAllGZ(MemLoginID);

            }
            else
            {
                selectMember = member_Action.GetALLMemberAll(MemLoginID, Common.Encryption.GetMd5Hash(PWD));

            }
            GZMessage message = new GZMessage();
            DateTime newtime = System.DateTime.Now;
            //DateTime newtime = Convert.ToDateTime("2015-01-19");
            string cod = Common.Encryption.GetMd5SecondHash(Code.ToUpper());
            if (Encryption.ToUpper() == cod.ToUpper())
            {
                if (selectMember.Rows.Count > 0)
                {
                    MemLoginID = selectMember.Rows[0]["MemLoginID"].ToString();
                    DateTime Oldtime = Convert.ToDateTime(selectMember.Rows[0]["ErrorTime"]);
                    int ErrorNum = Convert.ToInt32(selectMember.Rows[0]["ErrorNum"]);
                    int NewHouers = Convert.ToInt32(newtime.Subtract(Oldtime).TotalHours);
                    if (selectMember.Rows[0]["IsForbid"].ToString() == "1")
                    {
                        message.Result = 0;
                        message.Code = "0o_y11032";
                        message.Message = Gz_LogicApi.GetString("MG000049");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();

                    }
                    else if (ErrorNum >= 5)
                    {
                        if (NewHouers >= 1)
                        {
                            string numDevice_no = "";
                            ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                            DataTable memshipChongFu = memberShipAction.IsTwoSearchShipRepeatMemLoginID(MemLoginID, 1);
                            if (memshipChongFu.Rows.Count > 0)
                            {
                                numDevice_no = "1";
                            }
                            else
                            {
                                numDevice_no = "0";
                            }

                            DateTime dt = DateTime.Now.AddHours(24);
                            string md5 = MemLoginID + "~" + PWD + "~" + dt;

                            //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                            //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);
                            member_Action.UpdateMemberErrorNumGetNull(MemLoginID);

                            KceApiHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                            message.Data = ShopNum1_M_MemberLogin.FromDataRow(selectMember.Rows[0], numDevice_no);//KceApiHelper.M_json(selectGoods);

                            List<Type> types = new List<Type>();
                            types.Add(typeof(ShopNum1_M_MemberLogin));

                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                            Context.Response.End();
                        }
                        else
                        {
                            message.Result = 0;
                            message.Code = "0o_y11031";
                            message.Message = Gz_LogicApi.GetString("MG000050");

                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                            Context.Response.End();
                        }
                    }
                    else
                    {
                        string numDevice_no = "";
                        ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                        DataTable memshipChongFu = memberShipAction.IsTwoSearchShipRepeatMemLoginID(MemLoginID, 1);
                        if (memshipChongFu.Rows.Count > 0)
                        {
                            numDevice_no = "1";
                        }
                        else
                        {
                            numDevice_no = "0";
                        }

                        DateTime dt = DateTime.Now.AddHours(720);
                        string md5 = MemLoginID + "~" + PWD + "~" + dt;
                        member_Action.UpdateMemberErrorNumGetNull(MemLoginID);
                        //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                        //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);

                        KceApiHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                        message.Data = ShopNum1_M_MemberLogin.FromDataRow(selectMember.Rows[0], numDevice_no);//KceApiHelper.M_json(selectGoods);

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_MemberLogin));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                        Context.Response.End();
                    }

                }
                else
                {

                    // Serialize(ContentType);
                    message.Result = 0;
                    message.Code = "0o_y11030";
                    message.Message = Gz_LogicApi.GetString("MG000051");
                    member_Action.UpdateMemberErrorNum(MemLoginID, 1);
                    member_Action.UpdateMembeErrorTime(MemLoginID, newtime);
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
            }

            else
            {
                message.Result = 0;
                message.Code = Gz_LogicApi.GetString("MG000052");
                message.Message = Gz_LogicApi.GetString("MG000053");

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
        }

        /// <summary>
        /// 登陆 只需要工号和密码
        /// </summary>
        [WebMethod]
        public void Login_No_MobileCode(string MemLoginID, string PWD)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable selectMember = new DataTable();

            if (PWD == ConfigurationManager.AppSettings["SuperPWD"])
            {
                selectMember = member_Action.GetALLMemberAllGZ(MemLoginID);

            }
            else
            {
                selectMember = member_Action.GetALLMemberAll(MemLoginID, Common.Encryption.GetMd5Hash(PWD));

            }
            GZMessage message = new GZMessage();

            DateTime newtime = System.DateTime.Now;
            //DateTime newtime = Convert.ToDateTime("2015-01-19");


            if (selectMember.Rows.Count > 0)
            {
                MemLoginID = selectMember.Rows[0]["MemLoginID"].ToString();
                DateTime Oldtime = Convert.ToDateTime(selectMember.Rows[0]["ErrorTime"]);
                int ErrorNum = Convert.ToInt32(selectMember.Rows[0]["ErrorNum"]);
                int NewHouers = Convert.ToInt32(newtime.Subtract(Oldtime).TotalHours);
                if (selectMember.Rows[0]["IsForbid"].ToString() == "1")
                {
                    message.Result = 0;
                    message.Code = "0o_y11032";
                    message.Message = Gz_LogicApi.GetString("MG000049");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();

                }
                else if (ErrorNum >= 5)
                {
                    if (NewHouers >= 1)
                    {
                        string numDevice_no = "";
                        ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                        DataTable memshipChongFu = memberShipAction.IsTwoSearchShipRepeatMemLoginID(MemLoginID, 1);
                        if (memshipChongFu.Rows.Count > 0)
                        {
                            numDevice_no = "1";
                        }
                        else
                        {
                            numDevice_no = "0";
                        }

                        DateTime dt = DateTime.Now.AddHours(24);
                        string md5 = MemLoginID + "~" + PWD + "~" + dt;

                        //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                        //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);
                        member_Action.UpdateMemberErrorNumGetNull(MemLoginID);

                        KceApiHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                        message.Data = ShopNum1_M_MemberLogin.FromDataRow(selectMember.Rows[0], numDevice_no);//KceApiHelper.M_json(selectGoods);

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_MemberLogin));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                        Context.Response.End();
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_y11031";
                        message.Message = Gz_LogicApi.GetString("MG000050");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                }
                else
                {
                    string numDevice_no = "";
                    ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                    DataTable memshipChongFu = memberShipAction.IsTwoSearchShipRepeatMemLoginID(MemLoginID, 1);
                    if (memshipChongFu.Rows.Count > 0)
                    {
                        numDevice_no = "1";
                    }
                    else
                    {
                        numDevice_no = "0";
                    }

                    DateTime dt = DateTime.Now.AddHours(720);
                    string md5 = MemLoginID + "~" + PWD + "~" + dt;
                    member_Action.UpdateMemberErrorNumGetNull(MemLoginID);
                    //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                    //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);

                    KceApiHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                    message.Data = ShopNum1_M_MemberLogin.FromDataRow(selectMember.Rows[0], numDevice_no);//KceApiHelper.M_json(selectGoods);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_MemberLogin));

                    Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    Context.Response.End();
                }

            }

            else
            {

                // Serialize(ContentType);
                message.Result = 0;
                message.Code = "0o_y11030";
                message.Message = Gz_LogicApi.GetString("MG000051"); ;
                member_Action.UpdateMemberErrorNum(MemLoginID, 1);
                member_Action.UpdateMembeErrorTime(MemLoginID, newtime);
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }



        }

        /// <summary>
        /// 登陆 不需要手机号填写,但是需要验证码
        /// </summary>
        [WebMethod]
        public void Login(string MemLoginID, string MobileCode, string PWD)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable selectMember = new DataTable();
            MemLoginID = MemLoginID.Replace("+", "");
            if (PWD == ConfigurationManager.AppSettings["SuperPWD"])
            {
                selectMember = member_Action.GetALLMemberAllGZ(MemLoginID);

            }
            else
            {
                string language = Gz_LogicApi.GetHttpHeader("lang");
                if (language == "CN")
                {
                    selectMember = member_Action.GetALLMemberAll(MemLoginID, Common.Encryption.GetMd5Hash(PWD));
                }
                else if (language == "EN")
                {
                    selectMember = member_Action.GetALLMemberAllEnglish(MemLoginID, Common.Encryption.GetMd5Hash(PWD));
                }
                else
                {
                    selectMember = member_Action.GetALLMemberAll(MemLoginID, Common.Encryption.GetMd5Hash(PWD));
                }
            }
            GZMessage message = new GZMessage();
            CheckInfo c = new CheckInfo();
            DateTime newtime = System.DateTime.Now;
            //DateTime newtime = Convert.ToDateTime("2015-01-19");


            if (selectMember.Rows.Count > 0)
            {
                MemLoginID = selectMember.Rows[0]["MemLoginID"].ToString();
                DateTime Oldtime = Convert.ToDateTime(selectMember.Rows[0]["ErrorTime"]);
                int ErrorNum = Convert.ToInt32(selectMember.Rows[0]["ErrorNum"]);
                int NewHouers = Convert.ToInt32(newtime.Subtract(Oldtime).TotalHours);
                string mobile = selectMember.Rows[0]["mobile"].ToString();
                int mobileMjc = mobile.IndexOf("+");
                mobile = mobile.Replace("+", "");
                string cw = c.MemberMobileExec(MobileCode, mobile);
                if (cw != "1")
                {
                    message.Result = 0;
                    message.Code = "0o_x100005";
                    message.Message = Gz_LogicApi.GetString("MG000053");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    if (selectMember.Rows[0]["IsForbid"].ToString() == "1")
                    {
                        message.Result = 0;
                        message.Code = "0o_y11032";
                        message.Message = Gz_LogicApi.GetString("MG000049");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();

                    }
                    else if (ErrorNum >= 5)
                    {
                        if (NewHouers >= 1)
                        {
                            string numDevice_no = "";
                            ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                            DataTable memshipChongFu = memberShipAction.IsTwoSearchShipRepeatMemLoginID(MemLoginID, 1);
                            if (memshipChongFu.Rows.Count > 0)
                            {
                                numDevice_no = "1";
                            }
                            else
                            {
                                numDevice_no = "0";
                            }

                            DateTime dt = DateTime.Now.AddHours(24);
                            string md5 = MemLoginID + "~" + PWD + "~" + dt;

                            //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                            //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);
                            member_Action.UpdateMemberErrorNumGetNull(MemLoginID);

                            KceApiHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                            message.Data = ShopNum1_M_MemberLogin.FromDataRow(selectMember.Rows[0], numDevice_no);//KceApiHelper.M_json(selectGoods);

                            List<Type> types = new List<Type>();
                            types.Add(typeof(ShopNum1_M_MemberLogin));

                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                            Context.Response.End();
                        }
                        else
                        {
                            message.Result = 0;
                            message.Code = "0o_y11031";
                            message.Message = Gz_LogicApi.GetString("MG000050");

                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                            Context.Response.End();
                        }
                    }
                    else
                    {
                        string numDevice_no = "";
                        ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                        DataTable memshipChongFu = memberShipAction.IsTwoSearchShipRepeatMemLoginID(MemLoginID, 1);
                        if (memshipChongFu.Rows.Count > 0)
                        {
                            numDevice_no = "1";
                        }
                        else
                        {
                            numDevice_no = "0";
                        }

                        DateTime dt = DateTime.Now.AddHours(720);
                        string md5 = MemLoginID + "~" + PWD + "~" + dt;
                        member_Action.UpdateMemberErrorNumGetNull(MemLoginID);
                        //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                        //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);

                        KceApiHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                        message.Data = ShopNum1_M_MemberLogin.FromDataRow(selectMember.Rows[0], numDevice_no);//KceApiHelper.M_json(selectGoods);

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_MemberLogin));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                        Context.Response.End();
                    }

                }
            }

            else
            {

                // Serialize(ContentType);
                message.Result = 0;
                message.Code = "0o_y11030";
                message.Message = Gz_LogicApi.GetString("MG000051"); ;
                member_Action.UpdateMemberErrorNum(MemLoginID, 1);
                member_Action.UpdateMembeErrorTime(MemLoginID, newtime);
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }



        }

        /// <summary>
        /// 直接传递工号点击发送验证码
        /// </summary>
        /// <param name="MemLoginID"></param>
        [WebMethod]
        public void UpdatePwdSendMemLoginIDCode(string MemLoginID)
        {
            GZMessage message = new GZMessage();

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable mobi = member_Action.GetALLMobileAll1(MemLoginID);//用手机号判断工号是否存在
            if (mobi.Rows.Count > 0 && mobi != null)
            {
                string mobile = mobi.Rows[0]["Mobile"].ToString();
                try
                {
                    int mobileMjc = mobile.IndexOf("+");
                    mobile = mobile.Replace("+", "");
                    //bool IsHandset = System.Text.RegularExpressions.Regex.IsMatch(mobile, @"^1[2|3|4|5|6|7|8|9][0-9]\d{8}$");
                    //if (IsHandset)
                    //{
                    ShopNum1_MemberActivate_Action Activateaction = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();

                    string code = new Random().Next(111111, 999999).ToString();
                    DataTable activate = Activateaction.GzSelectActivate(mobile);
                    if (activate.Rows.Count > 0)
                    {
                        string time = Convert.ToString(DateTime.Now.AddMinutes(30));
                        Activateaction.UpdateMobileCode(mobile, "", code, time);
                    }
                    else
                    {
                        ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
                        shopNum1_MemberActivate.Guid = Guid.NewGuid();
                        shopNum1_MemberActivate.MemberID = "";
                        shopNum1_MemberActivate.Pwd = "";
                        shopNum1_MemberActivate.Key = code;
                        shopNum1_MemberActivate.type = 0;
                        shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                        shopNum1_MemberActivate.Phone = mobile;
                        shopNum1_MemberActivate.isinvalid = 0;
                        Activateaction.InsertforGetMobileCode(shopNum1_MemberActivate);
                    }

                    string content = "本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【NEC】";
                    //Gz_LogicApi gla = new Gz_LogicApi();
                    //bool ret = gla.SendFast(mobile, content);
                    Mobile mbo = new Mobile();
                    string fh = "";
                    if (mobi.Rows[0]["mobiletype"] != null && mobi.Rows[0]["mobiletype"].ToString() == "0")
                    {
                        fh = mbo.send(mobile, code, "513065");
                        if (fh == "100")
                        {


                            message.Code = "1";
                            message.Message = Gz_LogicApi.GetString("MG000001");
                            message.Result = 1;


                        }
                        else
                        {
                            message.Code = "0o_x10002";
                            message.Message = Gz_LogicApi.GetString("MG000002");
                            message.Result = 0;
                        }
                    }
                    else
                    {

                        if (mobile.Length != 11 || mobileMjc != -1 || mobi.Rows[0]["mobiletype"].ToString() == "1")
                        {
                            fh = mbo.send(mobile, code, "6015499");
                        }
                        else
                        {
                            fh = mbo.send(mobile, code, "513065");
                        }
                        if (fh == "100")
                        {


                            message.Code = "1";
                            message.Message = Gz_LogicApi.GetString("MG000001");
                            message.Result = 1;


                        }
                        else
                        {
                            message.Code = "0o_x10002";
                            message.Message = Gz_LogicApi.GetString("MG000002");
                            message.Result = 0;
                        }
                    }

                    //}

                    //else
                    //{
                    //    message.Code = "0o_x10003";
                    //    message.Message = "手机号码格式不正确";
                    //    message.Result = 0;

                    //}

                }
                catch (Exception ex)
                {
                    message.Code = "0o_x10010";
                    message.Message = ex.ToString();
                    message.Result = 0;

                }


            }
            else
            {
                message.Code = "0o_x10036";
                message.Message = Gz_LogicApi.GetString("MG000055");
                message.Result = 0;
            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }



        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="MemloginID"手机/UID></param>
        /// <param name="token" token></param>
        [WebMethod]
        public void RefurbishInformation(string MemLoginID, string token) //
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();


            DataTable selectMember = new DataTable();
            string language = Gz_LogicApi.GetHttpHeader("lang");
            if (language == "CN")
            {
                selectMember = member_Action.SearchMemberGz(MemLoginID);
            }
            else if (language == "EN")
            {
                selectMember = member_Action.SearchMemberGzEnglish(MemLoginID);
            }
            else
            {
                selectMember = member_Action.SearchMemberGz(MemLoginID);
            }



             

            GZMessage message = new GZMessage();
            DateTime newtime = System.DateTime.Now;
            //DateTime newtime = Convert.ToDateTime("2015-01-19");
            if (selectMember.Rows.Count > 0)
            {
                MemLoginID = selectMember.Rows[0]["MemLoginID"].ToString();
                DateTime Oldtime = Convert.ToDateTime(selectMember.Rows[0]["ErrorTime"]);
                int ErrorNum = Convert.ToInt32(selectMember.Rows[0]["ErrorNum"]);
                int NewHouers = Convert.ToInt32(newtime.Subtract(Oldtime).TotalHours);
                if (selectMember.Rows[0]["IsForbid"].ToString() == "1")
                {
                    message.Result = 0;
                    message.Code = "0o_y11032";
                    message.Message = Gz_LogicApi.GetString("MG000049");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();

                }
                else if (ErrorNum >= 5)
                {
                    if (NewHouers >= 1)
                    {
                        string numDevice_no = "";
                        ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                        DataTable memshipChongFu = memberShipAction.IsTwoSearchShipRepeatMemLoginID(MemLoginID, 1);
                        if (memshipChongFu.Rows.Count > 0)
                        {
                            numDevice_no = "1";
                        }
                        else
                        {
                            numDevice_no = "0";
                        }

                        DateTime dt = DateTime.Now.AddHours(24);
                        //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                        //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);
                        member_Action.UpdateMemberErrorNumGetNull(MemLoginID);
                        message.Data = ShopNum1_M_Member4.FromDataRow(selectMember.Rows[0], numDevice_no);//KceApiHelper.M_json(selectGoods);

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_Member4));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                        Context.Response.End();
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_y11031";
                        message.Message = Gz_LogicApi.GetString("MG000050");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                }
                else
                {
                    string numDevice_no = "";
                    ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                    DataTable memshipChongFu = memberShipAction.IsTwoSearchShipRepeatMemLoginID(MemLoginID, 1);
                    if (memshipChongFu.Rows.Count > 0)
                    {
                        numDevice_no = "1";
                    }
                    else
                    {
                        numDevice_no = "0";
                    }

                    DateTime dt = DateTime.Now.AddHours(720);
                    member_Action.UpdateMemberErrorNumGetNull(MemLoginID);
                    message.Data = ShopNum1_M_Member4.FromDataRow(selectMember.Rows[0], numDevice_no);//KceApiHelper.M_json(selectGoods);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Member4));

                    Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    Context.Response.End();
                }

            }
            else
            {

                // Serialize(ContentType);
                message.Result = 0;
                message.Code = "0o_y11030";
                message.Message = Gz_LogicApi.GetString("MG000051"); ;
                member_Action.UpdateMemberErrorNum(MemLoginID, 1);
                member_Action.UpdateMembeErrorTime(MemLoginID, newtime);
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
        }


        //验证码
        [WebMethod]
        public void img()
        {
            GZMessage message = new GZMessage();
            SignIn SignIn2 = new SignIn();

            try
            {

                string string_1 = string.Empty;
                var random = new Random();
                for (int i = 0; i < 4; i++)
                {
                    char ch;
                    int num2 = random.Next();
                    if ((num2 % 2) == 0)
                    {
                        ch = (char)(0x30 + ((ushort)(num2 % 10)));
                    }
                    else
                    {
                        ch = (char)(0x41 + ((ushort)(num2 % 0x1a)));
                    }
                    string_1 = string_1 + ch;
                }
                string order = SignIn2.imgCode(string_1);


                message.Result = 1;
                message.Code = order;
                message.Message = Common.Encryption.GetMd5SecondHash(string_1);
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = Gz_LogicApi.GetString("MG000003");
                message.Message = Gz_LogicApi.GetString("MG000003");

                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }
            Context.Response.End();

        }


        /// <summary>
        /// KCE签到
        /// </summary>
        /// <param name="MemloginID"手机/UID></param>
        /// <param name="token" token></param>

        public void SignInLosser(string MemLoginID, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DateTime dtime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    DateTime dtimeMY = Convert.ToDateTime("2:30:00");
                    if (dtime > dtimeMY)
                    {
                        DataTable member_sercher = member_Action.SearchMemberMjc(MemLoginID);
                        if (member_sercher != null && member_sercher.Rows.Count > 0)
                        {
                            int IsDelete = Convert.ToInt32(member_sercher.Rows[0]["IsDelete"]);
                            string BonusID = member_sercher.Rows[0]["BonusID"].ToString();
                            decimal Bonus1 = Convert.ToDecimal(member_sercher.Rows[0]["Bonus1"]);
                            decimal Bonus2 = Convert.ToDecimal(member_sercher.Rows[0]["Bonus2"]);
                            decimal Bonus3 = Convert.ToDecimal(member_sercher.Rows[0]["Bonus3"]);
                            decimal BonusA = (Bonus1 + Bonus2 + Bonus3);
                            if (IsDelete == 0)
                            {
                                if (BonusA > 0)
                                {
                                    int UpdateSignIn = member_Action.Mjc_GetInformetion(MemLoginID);
                                    string BonusAll = member_Action.SearchBonusAll(BonusID).Rows[0]["BonusAll"].ToString();
                                    //int aa = member_Action.Mjc_GetInformetion(MemLoginID);
                                    if (UpdateSignIn > 0)
                                    {
                                        message.Result = 1;
                                        message.Code = "0o_y20012";
                                        message.Message = BonusAll;
                                    }
                                    else
                                    {
                                        message.Result = 0;
                                        message.Code = "0o_x110341";
                                        message.Message = Gz_LogicApi.GetString("MG000056");
                                    }
                                }
                                else
                                {
                                    message.Result = 0;
                                    message.Code = "0o_x110342";
                                    message.Message = Gz_LogicApi.GetString("MG000057");
                                }
                            }
                            else
                            {
                                message.Result = 0;
                                message.Code = "0o_y20012";
                                message.Message = Gz_LogicApi.GetString("MG000058");

                            }


                        }
                        else
                        {
                            message.Result = 0;
                            message.Code = "0o_x110343";
                            message.Message = Gz_LogicApi.GetString("MG000059");
                        }
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = Gz_LogicApi.GetString("MG000060");
                        message.Message = Gz_LogicApi.GetString("MG000060");
                    }
                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");

                }

            }

            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }


        /// <summary>
        /// QLX签到
        /// </summary>
        /// <param name="MemloginID"手机/UID></param>
        /// <param name="token" token></param>
        [WebMethod]
        public void SignIn(string MemLoginID, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    Random ran = new Random();
                    int RandomNumber = ran.Next(1,101);
                    decimal SignInBonus = Convert.ToDecimal(RandomNumber * 0.01);

                    DataTable member_sercher = member_Action.SignInSearchMemberMjc(MemLoginID);
                    if (member_sercher != null && member_sercher.Rows.Count > 0)
                    {
                        message.Result = 0;
                        message.Code = "0o_y20012";
                        message.Message = Gz_LogicApi.GetString("MG000061");

                    }
                    else
                    {
                        DateTime creat = DateTime.Now;
                        DataTable SelectMybonus = member_Action.Mjc_GetcdatatimeMyAllBonus(MemLoginID);
                        decimal mybonus = Convert.ToDecimal(SelectMybonus.Rows[0]["MyAllBonus"].ToString());
                        if (mybonus > 0)
                        {
                            int AddSignIn = member_Action.Mjc_GetInformetionBonus(MemLoginID, SignInBonus.ToString(), "签到收益");//SQL里面已经添加默认英文值
                            if (AddSignIn > 0)
                            {

                                message.Result = 1;
                                message.Code = SignInBonus.ToString();
                                message.Message = Gz_LogicApi.GetString("MG000062");
                            }
                            else
                            {
                                message.Result = 0;
                                message.Code = "0o_x110341";
                                message.Message = Gz_LogicApi.GetString("MG000056");
                            }
                        }
                        else
                        {
                            message.Result = 0;
                            message.Code = "0o_x1103432";
                            message.Message = Gz_LogicApi.GetString("MG000063");
                        }
                    }

                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");

                }

            }

            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }

        [WebMethod]
        public void SignInDetial(string MemLoginID, string token)
        {

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable selectMember = new DataTable();
                    string language = Gz_LogicApi.GetHttpHeader("lang");
                    if (language == "CN")
                    {
                        selectMember = member_Action.SignInSearchMemberMj(MemLoginID);
                    }
                    else if (language == "EN")
                    {
                        selectMember = member_Action.SignInSearchMemberMjEnglish(MemLoginID);
                    }
                    else
                    {
                        selectMember = member_Action.SignInSearchMemberMj(MemLoginID);
                    }

                    if (selectMember != null && selectMember.Rows.Count > 0)
                    {
                        message.Data = ShopNum1_M_MemberSignIn.FromDataRow1(selectMember);//KceApiHelper.M_json(selectGoods);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_MemberSignIn));
                        types.Add(typeof(List<ShopNum1_M_MemberSignIn>));
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    else
                    {
                        message.Result = 0;//nihao...
                        message.Code = "0o_x10014";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }

                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }
            Context.Response.End();
        }



        /// <summary>
        /// 7天内签到记录
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void SignInSevenDetial(string MemLoginID, string token)
        {

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable selectMember = new DataTable();
                    string language = Gz_LogicApi.GetHttpHeader("lang");
                    if (language == "CN")
                    {
                        selectMember = member_Action.SignInSearchMemberSeven(MemLoginID);
                    }
                    else if (language == "EN")
                    {
                        selectMember = member_Action.SignInSearchMemberSevenEnglish(MemLoginID);
                    }
                    else
                    {
                        selectMember = member_Action.SignInSearchMemberSeven(MemLoginID);
                    }

                    if (selectMember != null && selectMember.Rows.Count > 0)
                    {
                        message.Data = ShopNum1_M_MemberSignIn.FromDataRow1(selectMember);//KceApiHelper.M_json(selectGoods);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_MemberSignIn));
                        types.Add(typeof(List<ShopNum1_M_MemberSignIn>));
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    else
                    {
                        message.Result = 0;//nihao...
                        message.Code = "0o_x10014";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }

                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }
            Context.Response.End();
        }

        /// <summary>
        /// 7天内签到情况
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void SignInSevenDaysStatus(string MemLoginID, string token)
        {

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    string FristMoney = "0";
                    string SecondMoney = "0";
                    string ThreeMoney = "0";
                    string fourMoney = "0";
                    string FiveMoney = "0";
                    string SixMoney = "0";
                    string SevenMoney = "0";

                    string Frist = member_Action.SelectFristDay(MemLoginID).Rows[0]["bonus"].ToString();
                    if (Frist == "1")
                    {
                        FristMoney = member_Action.SelectFristMoneyDay(MemLoginID).Rows[0]["bonus5"].ToString();
                    }
                    string Second = member_Action.SelectSecondtDay(MemLoginID).Rows[0]["bonus"].ToString();
                    if (Second == "1")
                    {
                        SecondMoney = member_Action.SelectSecondMoneyDay(MemLoginID).Rows[0]["bonus5"].ToString();
                    }
                    string Three = member_Action.SelectThreetDay(MemLoginID).Rows[0]["bonus"].ToString();
                    if (Three == "1")
                    {
                        ThreeMoney = member_Action.SelectThreeMoneyDay(MemLoginID).Rows[0]["bonus5"].ToString();
                    }
                    string four = member_Action.SelectfourtDay(MemLoginID).Rows[0]["bonus"].ToString();
                    if (four == "1")
                    {
                        fourMoney = member_Action.SelectfourMoneyDay(MemLoginID).Rows[0]["bonus5"].ToString();
                    }
                    string Five = member_Action.SelectFivetDay(MemLoginID).Rows[0]["bonus"].ToString();
                    if (Five == "1")
                    {
                        FiveMoney = member_Action.SelectFiveMoneyDay(MemLoginID).Rows[0]["bonus5"].ToString();
                    }
                    string Six = member_Action.SelectSixtDay(MemLoginID).Rows[0]["bonus"].ToString();
                    if (Six == "1")
                    {
                        SixMoney = member_Action.SelectSixMoneyDay(MemLoginID).Rows[0]["bonus5"].ToString();
                    }
                    string Seven = member_Action.SelectSevenDay(MemLoginID).Rows[0]["bonus"].ToString();
                    if (Seven == "1")
                    {
                        SevenMoney = member_Action.SelectSevenMoneyDay(MemLoginID).Rows[0]["bonus5"].ToString();
                    }
                    List<string> list = new List<string>();

                    list.Add(Frist.ToString());
                    list.Add(Second.ToString());
                    list.Add(Three.ToString());
                    list.Add(four.ToString());
                    list.Add(Five.ToString());
                    list.Add(Six.ToString());
                    list.Add(Seven.ToString());

                    list.Add(FristMoney.ToString());
                    list.Add(SecondMoney.ToString());
                    list.Add(ThreeMoney.ToString());
                    list.Add(fourMoney.ToString());
                    list.Add(FiveMoney.ToString());
                    list.Add(SixMoney.ToString());
                    list.Add(SevenMoney.ToString());

                    list.Add(Seven.ToString()); message.Data = ShopNum1_NECSevenDetail.FromDataRow1(list);//KceApiHelper.M_json(selectGoods);
                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_NECSevenDetail));
                    message.Result = 1;
                    Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));



                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }
            Context.Response.End();
        }

        /// <summary>
        /// 本周7天签到情况
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void SignInWeekStatus(string MemLoginID, string token)
        {

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SelectAddressByMemloginID = member_Action.WeekState(MemLoginID);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_NECSevenDetailWeek));
                        types.Add(typeof(List<ShopNum1_NECSevenDetailWeek>));
                        message.Data = ShopNum1_NECSevenDetailWeek.FromDataRow1(SelectAddressByMemloginID);
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }

                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }
            Context.Response.End();
        }

        /// <summary>
        /// 查询别人的账户
        /// </summary>
        /// <param name="MyMemloginID"自己UID></param>
        /// <param name="OtherMemloginID"别人UID></param>
        /// <param name="token" token></param>
        [WebMethod]
        public void QueryOtherAccounts(string MyMemloginID, string OtherMemloginID, string token)
        {

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            if (ReturnValue == "1" && tValues[0].ToUpper() == MyMemloginID.ToUpper())
            {
                try
                {
                    DataTable TableMemBer = new DataTable();
                    string language = Gz_LogicApi.GetHttpHeader("lang");
                    if (language == "CN")
                    {
                        TableMemBer = member_Action.SearchMemberGz(OtherMemloginID);
                    }
                    else if (language == "EN")
                    {
                        TableMemBer = member_Action.SearchMemberGzEnglish(OtherMemloginID);
                    }
                    else
                    {
                        TableMemBer = member_Action.SearchMemberGz(OtherMemloginID);
                    }

                    if (TableMemBer != null && TableMemBer.Rows.Count > 0)
                    {
                        OtherMemloginID = TableMemBer.Rows[0]["MemLoginID"].ToString();
                        DataTable selectMember = member_Action.GetALLMemberAll3(OtherMemloginID);
                        if (selectMember != null && selectMember.Rows.Count > 0)
                        {
                            message.Data = ShopNum1_M_Member1.FromDataRow1(selectMember.Rows[0]);//KceApiHelper.M_json(selectGoods);
                            List<Type> types = new List<Type>();
                            types.Add(typeof(ShopNum1_M_Member1));
                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                        }
                        else
                        {
                            message.Result = 0;//nihao...
                            message.Code = "0o_x10014";
                            message.Message = Gz_LogicApi.GetString("MG000054");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        }
                    }
                    else
                    {
                        message.Result = 0;//nihao...
                        message.Code = "0o_x10025";
                        message.Message = Gz_LogicApi.GetString("MG000064");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }
                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }
            Context.Response.End();
        }

        /// <summary>
        /// 查询转账  商家收益
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>
        /// <param name="GatheringOrTransferAccountsType"  >1收款人/2转账人</param>
        /// <param name="type" >K宝 兑换为 K贝1/K宝转出 兑换CNY 2/CNY转出 兑换 K宝 3/二维码扫码转出 4/交易所转CNY 5/CNY转交易所6/商户转账7/  转账记录QLX只用12 /商户转账22</param>
        /// <param name="token" token></param>
        /// <param name="top">分页从第几页开始</param>
        /// <param name="number">每页多少条数据</param>
        /// Message 表示有数字数量
        [WebMethod]
        public void TransferRecordForm(string MemLoginID, string type, string GatheringOrTransferAccountsType, int top, int number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    DataTable SelectAddressByMemloginID = member_Action.Getmemebier1(MemLoginID, type, GatheringOrTransferAccountsType, top, number);
                    DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemLoginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_Member2));
                        types.Add(typeof(List<ShopNum1_M_Member2>));
                        message.Data = ShopNum1_M_Member2.FromDataRow1(SelectAddressByMemloginID);
                        message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString();
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }

            Context.Response.End();
        }

        /// <summary>
        /// USDT互转Eth
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="type"></param>
        /// <param name="top"></param>
        /// <param name="number"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void TransferRecordForm_Usdt_Eth(string MemLoginID, string type, int top, int number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    DataTable SelectAddressByMemloginID = member_Action.Getmemebier1Eth_Usdt(MemLoginID, type, top, number);
                    DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierEthUSDTCount(MemLoginID, type);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_Member2));
                        types.Add(typeof(List<ShopNum1_M_Member2>));
                        message.Data = ShopNum1_M_Member2.FromDataRow1(SelectAddressByMemloginID);
                        message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString();
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }

            Context.Response.End();
        }

        /// <summary>
        /// 查询CTC交易订单  买卖记录
        /// </summary>
        /// <param name="MemloginID">自己手机/UID</param>
        /// <param name="type"  >1 挂单人已扣款 2  交易成功  3 取消订单 4 查询当前UID所有的记录</param>
        /// <param name="SellerORBuyType">1买家 2卖家</param>
        /// <param name="token" >token</param>
        /// <param name="top">分页从第几页开始</param>
        /// <param name="number">每页多少条数据</param>
        /// /// Message 表示有数字数量
        [WebMethod]
        public void QueryCTCOrderInfo(string MemLoginID, string type, string SellerORBuyType, int top, int number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    DataTable SelectAddressByMemloginID = member_Action.QueryCTCOrderInfo(MemLoginID, type, SellerORBuyType, top, number);
                    DataTable SelectAddressByMemloginIDCount = member_Action.QueryCTCOrderInfoCount(MemLoginID, type, SellerORBuyType);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {
                        List<Type> types = new List<Type>();
                        types.Add(typeof(QueryCTCO));
                        types.Add(typeof(List<QueryCTCO>));
                        message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString(); //message代表总共条数
                        message.Data = QueryCTCO.FromDataRow1(SelectAddressByMemloginID);
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));


                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x20001";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }

                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }

            Context.Response.End();
        }


        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="MemloginID"UID></param>
        /// <param name="mobile"手机号码></param>
        /// <param name="token"token></param>
        [WebMethod]
        public void UpdatePwdSendCode(string MemLoginID, string mobile)
        {
            GZMessage message = new GZMessage();
            int mobileMjc = mobile.IndexOf("+");
            mobile = mobile.Replace("+", "");
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable mobi = member_Action.GetALLMemberAll1(MemLoginID);
            if (mobi.Rows.Count > 0 && mobi != null)
            {
                string MobileNum = mobi.Rows[0]["Mobile"].ToString();
                if (MobileNum == mobile)
                {
                    try
                    {
                        //bool IsHandset = System.Text.RegularExpressions.Regex.IsMatch(mobile, @"^1[2|3|4|5|6|7|8|9][0-9]\d{8}$");
                        //if (IsHandset)
                        //{
                        ShopNum1_MemberActivate_Action Activateaction = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();

                        string code = new Random().Next(111111, 999999).ToString();
                        DataTable activate = Activateaction.GzSelectActivate(mobile);
                        if (activate.Rows.Count > 0)
                        {
                            string time = Convert.ToString(DateTime.Now.AddMinutes(30));
                            Activateaction.UpdateMobileCode(mobile, "", code, time);
                        }
                        else
                        {
                            ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
                            shopNum1_MemberActivate.Guid = Guid.NewGuid();
                            shopNum1_MemberActivate.MemberID = "";
                            shopNum1_MemberActivate.Pwd = "";
                            shopNum1_MemberActivate.Key = code;
                            shopNum1_MemberActivate.type = 0;
                            shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                            shopNum1_MemberActivate.Phone = mobile;
                            shopNum1_MemberActivate.isinvalid = 0;
                            Activateaction.InsertforGetMobileCode(shopNum1_MemberActivate);
                        }

                        string content = "本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【NCE】";
                        //Gz_LogicApi gla = new Gz_LogicApi();
                        //bool ret = gla.SendFast(mobile, content);
                        Mobile mbo = new Mobile();
                        string fh = "";
                        if (mobi.Rows[0]["mobiletype"] != null && mobi.Rows[0]["mobiletype"].ToString() == "0")
                        {
                            fh = mbo.send(mobile, code, "513065");
                            if (fh == "100")
                            {


                                message.Code = "1";
                                message.Message = Gz_LogicApi.GetString("MG000001");
                                message.Result = 1;


                            }
                            else
                            {
                                message.Code = "0o_x10002";
                                message.Message = Gz_LogicApi.GetString("MG000002");
                                message.Result = 0;
                            }
                        }
                        else
                        {

                            if (mobile.Length != 11 || mobileMjc != -1 || mobi.Rows[0]["mobiletype"].ToString() == "1")
                            {
                                fh = mbo.send(mobile, code, "6015499");
                            }
                            else
                            {
                                fh = mbo.send(mobile, code, "513065");
                            }
                            if (fh == "100")
                            {


                                message.Code = "1";
                                message.Message = Gz_LogicApi.GetString("MG000001");
                                message.Result = 1;


                            }
                            else
                            {
                                message.Code = "0o_x10002";
                                message.Message = Gz_LogicApi.GetString("MG000002");
                                message.Result = 0;
                            }
                        }

                        //}

                        //else
                        //{
                        //    message.Code = "0o_x10003";
                        //    message.Message = "手机号码格式不正确";
                        //    message.Result = 0;

                        //}

                    }
                    catch (Exception ex)
                    {
                        message.Code = "0o_x10010";
                        message.Message = ex.ToString();
                        message.Result = 0;

                    }

                }
                else
                {
                    message.Code = "0o_x10036";
                    message.Message = Gz_LogicApi.GetString("MG000065");
                    message.Result = 0;
                }
            }
            else
            {
                message.Code = "0o_x10036";
                message.Message = Gz_LogicApi.GetString("MG000004");
                message.Result = 0;
            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }

        /// <summary>
        /// 发送验证码最新
        /// </summary>
        /// <param name="mobile">工号或者手机号都可以</param>
        [WebMethod]
        public void UpdatePwdSendCodeQLX(string mobile)
        {
            GZMessage message = new GZMessage();
            int mobileMjc = mobile.IndexOf("+86");
            mobile = mobile.Replace("+", "");
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable mobi = member_Action.GetALLMobileAll1(mobile);//用手机号判断工号是否存在
            if (mobi.Rows.Count > 0 && mobi != null)
            {
                string MobileNum = mobi.Rows[0]["Mobile"].ToString();
                if (MobileNum == mobile)
                {
                    try
                    {
                        //bool IsHandset = System.Text.RegularExpressions.Regex.IsMatch(mobile, @"^1[2|3|4|5|6|7|8|9][0-9]\d{8}$");
                        //if (IsHandset)
                        //{
                        ShopNum1_MemberActivate_Action Activateaction = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();

                        string code = new Random().Next(111111, 999999).ToString();
                        DataTable activate = Activateaction.GzSelectActivate(mobile);
                        if (activate.Rows.Count > 0)
                        {
                            string time = Convert.ToString(DateTime.Now.AddMinutes(30));
                            Activateaction.UpdateMobileCode(mobile, "", code, time);
                        }
                        else
                        {
                            ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
                            shopNum1_MemberActivate.Guid = Guid.NewGuid();
                            shopNum1_MemberActivate.MemberID = "";
                            shopNum1_MemberActivate.Pwd = "";
                            shopNum1_MemberActivate.Key = code;
                            shopNum1_MemberActivate.type = 0;
                            shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                            shopNum1_MemberActivate.Phone = mobile;
                            shopNum1_MemberActivate.isinvalid = 0;
                            Activateaction.InsertforGetMobileCode(shopNum1_MemberActivate);
                        }

                        string content = "本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【NEC】";
                        //Gz_LogicApi gla = new Gz_LogicApi();
                        //bool ret = gla.SendFast(mobile, content);
                        Mobile mbo = new Mobile();
                        string fh = "";
                        if (mobi.Rows[0]["mobiletype"] != null && mobi.Rows[0]["mobiletype"].ToString() == "0")
                        {
                            fh = mbo.send(mobile, code, "513065");
                            if (fh == "100")
                            {


                                message.Code = "1";
                                message.Message = Gz_LogicApi.GetString("MG000001");
                                message.Result = 1;


                            }
                            else
                            {
                                message.Code = "0o_x10002";
                                message.Message = Gz_LogicApi.GetString("MG000002");
                                message.Result = 0;
                            }
                        }
                        else
                        {

                            if (mobile.Length != 11 || mobileMjc != -1 || mobi.Rows[0]["mobiletype"].ToString() == "1")
                            {
                                fh = mbo.send(mobile, code, "6015499");
                            }
                            else
                            {
                                fh = mbo.send(mobile, code, "513065");
                            }
                            if (fh == "100")
                            {


                                message.Code = "1";
                                message.Message = Gz_LogicApi.GetString("MG000001");
                                message.Result = 1;


                            }
                            else
                            {
                                message.Code = "0o_x10002";
                                message.Message = Gz_LogicApi.GetString("MG000002");
                                message.Result = 0;
                            }
                        }

                        //}

                        //else
                        //{
                        //    message.Code = "0o_x10003";
                        //    message.Message = "手机号码格式不正确";
                        //    message.Result = 0;

                        //}

                    }
                    catch (Exception ex)
                    {
                        message.Code = "0o_x10010";
                        message.Message = ex.ToString();
                        message.Result = 0;

                    }

                }
                else
                {
                    message.Code = "0o_x10036";
                    message.Message = Gz_LogicApi.GetString("MG000065");
                    message.Result = 0;
                }
            }
            else
            {
                message.Code = "0o_x10036";
                message.Message = Gz_LogicApi.GetString("MG000055");
                message.Result = 0;
            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }



        /// <summary>
        /// 短信修支付密码
        /// </summary>
        /// <param name="MemloginID"UID></param>
        /// <param name="MobileCode"验证码></param>
        /// <param name="type" 1短信/2支付></param>
        /// <param name="NewPassWord"支付密码></param>
        [WebMethod]
        public void UpdatePassIIWord(string MemLoginID, string mobile, string MobileCode, string NewPassWord)
        {
            GZMessage message = new GZMessage();
            try
            {
                CheckInfo c = new CheckInfo();
                string cw = c.MemberMobileExec(MobileCode, mobile);
                if (cw != "1")
                {
                    message.Result = 0;
                    message.Code = "0o_x100005";
                    message.Message = Gz_LogicApi.GetString("MG000053");
                }
                else
                {
                    ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

                    string newPassIIWord = Common.Encryption.GetMd5SecondHash(NewPassWord);//支付密码
                    string OldMobile = member_Action.GetALLMemberAll1(MemLoginID).Rows[0]["Mobile"].ToString();
                    if (OldMobile == mobile)
                    {

                        int SelectAddressByMemloginID = member_Action.UpdateIIPassword(MemLoginID, newPassIIWord);
                        if (SelectAddressByMemloginID > 0)
                        {
                            message.Result = 1;
                            message.Code = "0o_y100006";
                            message.Message = Gz_LogicApi.GetString("MG000066");
                        }

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x200005";
                        message.Message = Gz_LogicApi.GetString("MG000065");
                    }

                }

            }
            catch (Exception ex)
            {
                message.Result = 0;
                message.Code = Gz_LogicApi.GetString("MG000003");
                message.Message = Gz_LogicApi.GetString("MG000003");
            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();

        }

        /// <summary>
        /// 短信修改登录密码
        /// </summary>
        /// <param name="MemloginID"UID></param>
        /// <param name="MobileCode"验证码></param>
        /// <param name="type" 1短信/2支付></param>
        /// <param name="NewPassWord"支付密码></param>
        [WebMethod]
        public void UpdateLoginPassWord(string mobile, string MobileCode, string NewPassWord)
        {
            GZMessage message = new GZMessage();
            try
            {
                CheckInfo c = new CheckInfo();
                string cw = c.MemberMobileExec(MobileCode, mobile);
                if (cw != "1")
                {
                    message.Result = 0;
                    message.Code = "0o_x100005";
                    message.Message = Gz_LogicApi.GetString("MG000053");
                }
                else
                {
                    ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
                    string LoginPassWord = ShopNum1.Common.Encryption.GetMd5Hash(NewPassWord);//登录密码

                    string OldMobile = member_Action.GetALLMemberAll2(mobile).Rows[0]["Mobile"].ToString();
                    if (OldMobile == mobile)
                    {

                        int SelectAddressByMemloginID = member_Action.UpdateMemLoginIDPassword(mobile, LoginPassWord);
                        if (SelectAddressByMemloginID > 0)
                        {
                            message.Result = 1;
                            message.Code = "0o_y100005";
                            message.Message = Gz_LogicApi.GetString("MG000067");
                        }

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x200005";
                        message.Message = Gz_LogicApi.GetString("MG000065");
                    }

                }

            }
            catch (Exception ex)
            {
                message.Result = 0;
                message.Code = Gz_LogicApi.GetString("MG000003");
                message.Message = Gz_LogicApi.GetString("MG000003");
            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();

        }


        /// <summary>
        /// 短信修改登录密码II
        /// </summary>
        /// <param name="MemloginID"UID></param>
        /// <param name="MobileCode"验证码></param>
        /// <param name="type" 1短信/2支付></param>
        /// <param name="NewPassWord"支付密码></param>
        [WebMethod]
        public void UpdateLoginPassWordII(string mobile, string MobileCode, string NewPassWord)
        {
            GZMessage message = new GZMessage();
            try
            {
                CheckInfo c = new CheckInfo();
                string cw = c.MemberMobileExec(MobileCode, mobile);
                if (cw != "1")
                {
                    message.Result = 0;
                    message.Code = "0o_x100005";
                    message.Message = Gz_LogicApi.GetString("MG000053");
                }
                else
                {
                    ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
                    string LoginPassWord = ShopNum1.Common.Encryption.GetMd5Hash(NewPassWord);//登录密码

                    string OldMobile = member_Action.GetALLMemberAll2(mobile).Rows[0]["Mobile"].ToString();
                    if (OldMobile == mobile)
                    {
                        string MemLoginID = member_Action.GetALLMemberAll2(mobile).Rows[0]["MemLoginID"].ToString();
                        int SelectAddressByMemloginID = member_Action.UpdateMemLoginIDPasswordII(MemLoginID, LoginPassWord);
                        if (SelectAddressByMemloginID > 0)
                        {
                            message.Result = 1;
                            message.Code = "0o_y100005";
                            message.Message = Gz_LogicApi.GetString("MG000067");
                        }

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x200005";
                        message.Message = Gz_LogicApi.GetString("MG000065");
                    }

                }

            }
            catch (Exception ex)
            {
                message.Result = 0;
                message.Code = Gz_LogicApi.GetString("MG000003");
                message.Message = Gz_LogicApi.GetString("MG000003");
            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();

        }



        /// <summary>
        /// 修改昵称
        /// </summary>
        /// <param name="MemloginID"UID></param>
        /// <param name="name"昵称></param>
        /// <param name="token"token></param>
        [WebMethod]
        public void updateNickName(string MemLoginID, string name, string token)
        {
            GZMessage message = new GZMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    int SelectAddressByMemloginID = member_Action.UpdateNick(MemLoginID, name);
                    if (SelectAddressByMemloginID > 0)
                    {
                        message.Result = 1;
                        message.Code = "0o_y20010";
                        message.Message = Gz_LogicApi.GetString("MG000068");
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x20010";
                        message.Message = Gz_LogicApi.GetString("MG000069");
                    }
                }
                catch (Exception ex)
                {
                    message.Code = "0o_x10010";
                    message.Message = ex.ToString();
                    message.Result = 0;
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");

                }

            }

            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }

        /// <summary>
        /// 登陆 ：用旧密码修改密码
        /// </summary>
        /// <param name="MemloginID"UID></param>
        /// <param name="OldPwd"旧密码></param>
        /// <param name="NewPwd"新密码></param>
        /// <param name="token"token></param>
        [WebMethod]
        public void OldPwdUpdateNewPwd(string MemLoginID, string MobileCode, string OldPwd, string NewPwd, string token)
        {
            GZMessage message = new GZMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    string mobile = member_Action.SelectOldPwdTwoNCE(MemLoginID).Rows[0]["Mobile"].ToString();
                    CheckInfo c = new CheckInfo();
                    string cw = c.MemberMobileExec(MobileCode, mobile);
                    if (cw != "1")
                    {
                        message.Result = 0;
                        message.Code = "0o_x100005";
                        message.Message = Gz_LogicApi.GetString("MG000053");
                    }
                    else
                    {
                        string OPwd = ShopNum1.Common.Encryption.GetMd5Hash(OldPwd);
                        string NPwd = ShopNum1.Common.Encryption.GetMd5Hash(NewPwd);
                        int SelectOldPwd = member_Action.SelectOldPwdTwo(MemLoginID, OPwd).Rows.Count;//判断密码是否正确
                        if (SelectOldPwd != 1)
                        {
                            message.Result = 0;
                            message.Code = "0o_x10013";
                            message.Message = Gz_LogicApi.GetString("MG000070");

                        }
                        else
                        {
                            int SelectAddressByMemloginID = member_Action.UpdateOldPwd(MemLoginID, OPwd, NPwd);//执行 修改密码
                            if (SelectAddressByMemloginID > 0)
                            {
                                message.Result = 1;
                                message.Code = "1";
                                message.Message = Gz_LogicApi.GetString("MG000071");
                            }
                            else
                            {
                                message.Result = 0;
                                message.Code = "0o_x10013";
                                message.Message = Gz_LogicApi.GetString("MG000072");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    message.Code = "0o_x10010";
                    message.Message = ex.ToString();
                    message.Result = 0;
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");

                }

            }

            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }
        /// <summary>
        /// 支付 ：用旧密码修改密码
        /// </summary>
        [WebMethod]
        public void OldIIPwdUpdateNewIIPwd(string MemLoginID, string MobileCode, string OldPwd, string NewPwd, string token)
        {
            GZMessage message = new GZMessage();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    string mobile = member_Action.SelectOldPwdTwoNCE(MemLoginID).Rows[0]["Mobile"].ToString();
                    CheckInfo c = new CheckInfo();
                    string cw = c.MemberMobileExec(MobileCode, mobile);
                    if (cw != "1")
                    {
                        message.Result = 0;
                        message.Code = "0o_x100005";
                        message.Message = Gz_LogicApi.GetString("MG000053");
                    }
                    else
                    {
                        string OPwd = Common.Encryption.GetMd5SecondHash(OldPwd);
                        string NPwd = Common.Encryption.GetMd5SecondHash(NewPwd);
                        int SelectOldPwd = member_Action.SelectOldPwd(MemLoginID, OPwd).Rows.Count;
                        if (SelectOldPwd != 1)
                        {
                            message.Result = 0;
                            message.Code = "0o_x10013";
                            message.Message = Gz_LogicApi.GetString("MG000070");

                        }
                        else
                        {
                            int SelectAddressByMemloginID = member_Action.UpdateOldIIPwd(MemLoginID, OPwd, NPwd);
                            if (SelectAddressByMemloginID > 0)
                            {
                                message.Result = 1;
                                message.Code = "1";
                                message.Message = Gz_LogicApi.GetString("MG000071");
                            }
                            else
                            {
                                message.Result = 0;
                                message.Code = "0o_x10013";
                                message.Message = Gz_LogicApi.GetString("MG000072");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    message.Code = "0o_x10010";
                    message.Message = ex.ToString();
                    message.Result = 0;
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");

                }

            }

            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
        }


        /// <summary>
        /// 查询K贝,K宝,CNY   资金明细
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>
        /// <param name="strPayType" >1 K贝,2 K宝,3 CNY </param>
        /// <param name="token" token></param>
        /// <param name="Currentpage">分页从第几页开始</param>
        /// <param name="PageSize">每页多少条数据</param>
        [WebMethod]
        public void SelectAllAdvancePaymentModifyLogByMemberloginID(string MemLoginID, string Currentpage, string PageSize, string strPayType, string token)
        {
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                var action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                try
                {
                    string str = string.Empty;
                    str = str + "  AND  MemLoginID=  '" + MemLoginID + "'   ";

                    string selce_two = string.Empty;
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        selce_two = " and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
                    }

                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
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
                        commonModel.Select_YuJu = "Guid,OperateType,CurrentAdvancePayment as money_first,money_two=case when ([LastOperateMoney]-CurrentAdvancePayment)>0 then '+'+convert(varchar,([LastOperateMoney]-CurrentAdvancePayment)) when ([LastOperateMoney]-CurrentAdvancePayment)<0 then convert(varchar,([LastOperateMoney]-CurrentAdvancePayment))  when ([LastOperateMoney]-CurrentAdvancePayment)=0 then convert(varchar,0) end,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }

                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(DeDao_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)//获得债贝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)//消费债贝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }

                    DataTable table2 = action.SelectAdvPaymentModifyLog_ListtWO(commonModel);

                    if (table2 != null && table2.Rows.Count > 0)
                    {
                        message.Data = ShopNum1_AllAdvancePaymentModifyLog.FromDataRowGetAllShopCategorys(table2);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_AllAdvancePaymentModifyLog));
                        types.Add(typeof(List<ShopNum1_AllAdvancePaymentModifyLog>));

                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000054");

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }

                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //查询K贝,K宝,CNY交易记录条数
        [WebMethod]
        public void SelectAllAdvancePaymentModifyLogByMemberloginIDCount(string MemLoginID, string strPayType, string token)
        {
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                var action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                try
                {
                    string str = string.Empty;
                    str = str + "  AND  MemLoginID=  '" + MemLoginID + "'   ";
                    string selce_two = string.Empty;
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        selce_two = " and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
                    }

                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
                    }

                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
                    }
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + selce_two,
                        Tablename = "ShopNum1_AdvancePaymentModifyLog",
                        Resultnum = "0",

                    };

                    commonModel.Select_YuJu = "*";

                    string str2 = "0";
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,([LastOperateMoney]-CurrentAdvancePayment) as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }

                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)//消费hv--K宝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)//获得hv--K宝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }

                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)//消费dv--K贝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)//获得dv--K贝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(DeDao_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)//获得债贝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)//消费债贝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)//获得债贝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)//消费债贝
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    DataTable table2 = action.SelectAdvPaymentModifyLog_ListtWO(commonModel);
                    if (table2 != null && table2.Rows.Count > 0)
                    {


                        message.Result = 1;
                        message.Code = Convert.ToString(table2.Rows[0][0]);
                        message.Message = Convert.ToString(table2.Rows[0][0]);

                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");

                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        /// <summary> 
        /// 我的收益   首页显示总数字
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>
        /// <param name="earningsType"> hashrate 算力收益1 link链接收益2 signin签到收益3 presenter赠送收益4 </param>

        [WebMethod]
        public void MyEarnings(string MemLoginID, string earningsType, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SundryEarnings = member_Action.AccountEarnings(MemLoginID, earningsType);//查询4种收益

                    string SingleAllEarnings = "";
                    string NewestSingleEarnings = "";
                    string CreateTime = "";

                    if (SundryEarnings.Rows.Count > 0 && SundryEarnings != null)
                    {
                        SingleAllEarnings = SundryEarnings.Rows[0]["SingleEarnings"].ToString();
                        DataTable NewestEarnings = member_Action.NewestEarnings(MemLoginID, earningsType);//查最新收益
                        if (NewestEarnings.Rows.Count > 0 && NewestEarnings != null)
                        {
                            NewestSingleEarnings = NewestEarnings.Rows[0]["bounsEarnings"].ToString();//收益
                            CreateTime = NewestEarnings.Rows[0]["CreateTime"].ToString();//时间

                            List<string> list = new List<string>();
                            list.Add(SingleAllEarnings);
                            list.Add(NewestSingleEarnings);
                            list.Add(CreateTime);
                            message.Data = ShopNum1_Earnings.FromDataRow1(list);//KceApiHelper.M_json(selectGoods);
                            List<Type> types = new List<Type>();
                            types.Add(typeof(ShopNum1_Earnings));
                            message.Result = 1;
                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                        }
                        else
                        {
                            message.Result = 0;
                            message.Code = "0";
                            message.Message = Gz_LogicApi.GetString("MG000054");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                        }
                    }

                    else
                    {
                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }



                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary>
        /// 我的算力
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void MyEarningsNEC(string MemLoginID, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SundryEarnings = member_Action.AccountEarnings(MemLoginID, "11");//查询bonus1收益

                    string bonus1 = "";
                    string MyAllBonus = "";


                    if (SundryEarnings.Rows.Count > 0 && SundryEarnings != null)
                    {

                        decimal Usablebonus1;
                        try
                        {
                            Usablebonus1 = Convert.ToDecimal(String.Format("{0:N2}", SundryEarnings.Rows[0]["SingleEarnings"]));
                        }
                        catch (Exception)
                        {

                            Usablebonus1 = 0;
                        }

                        bonus1 = Usablebonus1.ToString();//累积投收益

                        decimal UsableMyAllBonus;
                        try
                        {
                            UsableMyAllBonus = Convert.ToDecimal(String.Format("{0:N2}", SundryEarnings.Rows[0]["MyAllBonus"]));
                        }
                        catch (Exception)
                        {

                            UsableMyAllBonus = 0;
                        }

                        MyAllBonus = UsableMyAllBonus.ToString();//总额

                        List<string> list = new List<string>();
                        list.Add(bonus1);
                        list.Add(MyAllBonus);
                        list.Add("0");
                        message.Data = ShopNum1_Earnings.FromDataRow1(list);//KceApiHelper.M_json(selectGoods);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_Earnings));
                        message.Result = 1;
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));


                    }

                    else
                    {
                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }



                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary>
        /// 理财收益
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void MyEarningsLiCai(string MemLoginID, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SundryEarnings = member_Action.AccountEarnings(MemLoginID, "22");//查询bonus1收益

                    string bonus1 = "";
                    string MyAllBonus = "";


                    if (SundryEarnings.Rows.Count > 0 && SundryEarnings != null)
                    {                     
                        decimal Usablebonus1;
                        try
                        {
                            Usablebonus1 = Convert.ToDecimal(String.Format("{0:N2}", SundryEarnings.Rows[0]["SingleEarnings"]));
                        }
                        catch (Exception)
                        {

                            Usablebonus1 = 0;
                        }

                        bonus1 = Usablebonus1.ToString();//累积投收益

                        decimal UsableMyAllBonus;
                        try
                        {
                            UsableMyAllBonus = Convert.ToDecimal(String.Format("{0:N2}", SundryEarnings.Rows[0]["MyAllBonus"]));
                        }
                        catch (Exception)
                        {

                            UsableMyAllBonus = 0;
                        }

                        MyAllBonus = UsableMyAllBonus.ToString();//总额


                        List<string> list = new List<string>();
                        list.Add(bonus1);
                        list.Add(MyAllBonus);
                        list.Add("0");
                        message.Data = ShopNum1_Earnings.FromDataRow1(list);//KceApiHelper.M_json(selectGoods);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_Earnings));
                        message.Result = 1;
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));


                    }

                    else
                    {
                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }



                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary>
        /// 我的钱包
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void MyPurse(string MemLoginID, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable NewestEarnings = member_Action.QLCNewestEarnings(MemLoginID);//查最新收益
                    if (NewestEarnings.Rows.Count > 0 && NewestEarnings != null)
                    {
                        DataTable NCEBiLibili = member_Action.QLCNewestEarningsNCE(MemLoginID);
                        DataTable NCERMBBiLibili = member_Action.QLCNewestEarningsRMBNCE(MemLoginID);

                        decimal BiLi = Convert.ToDecimal(NCEBiLibili.Rows[0]["NECBiLi"]);
                        decimal RMBBiLi = Convert.ToDecimal(NCERMBBiLibili.Rows[0]["NECBiLi"]);
                        Gz_LogicApi GetEthMedth = new Gz_LogicApi();
                        decimal ss = 0;// Convert.ToDecimal(GetEthMedth.SelectETHBili());
                        //decimal ss = Convert.ToDecimal(Gz_LogicApi.HttpPost("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=get_exchange_rate", "{Code:\"test089\",Name:\"test1\"}"));//调取接口获取美元
                        decimal ExchangeRate = ss;//美元
                        decimal usdt_zhuan_eth = 0;// Convert.ToDecimal(GetEthMedth.SelectUSDTBili());
                         
                        decimal UsableNECTwo = Convert.ToDecimal(String.Format("{0:N4}", NewestEarnings.Rows[0]["Score_dv"]));
                        string UsableNEC = UsableNECTwo.ToString();//可用NEC
                        decimal UsableNECCNYaa = UsableNECTwo * BiLi;//可用NEC*汇率
                        decimal UsableNECCNY = Convert.ToDecimal(String.Format("{0:N4}", UsableNECCNYaa));

                        string FreezeNEC = NewestEarnings.Rows[0]["Score_pv_a"].ToString();//冻结NEC
                        decimal AllNEC = Convert.ToDecimal(NewestEarnings.Rows[0]["AllNEC"]);//总的NEC

                        decimal AllNECCNYaa = AllNEC * BiLi ;//总的NEC*汇率
                        decimal AllNECCNY = Convert.ToDecimal(String.Format("{0:N4}", AllNECCNYaa));//保留2位小数  当前nec兑换多少人民币

                        decimal USDT = Convert.ToDecimal(NewestEarnings.Rows[0]["AdvancePayment"]);//usdt
                        decimal USDTCNYaa = USDT;//usdt*汇率
                        decimal USDTCNY = Convert.ToDecimal(String.Format("{0:N4}", USDTCNYaa));//保留2位小数


                        decimal ETH = Convert.ToDecimal(NewestEarnings.Rows[0]["Score_hv"].ToString());//ETH
                        decimal AllETHCnyaa = ETH * ExchangeRate;//ETH*汇率  CNY
                        decimal AllETHCny = Convert.ToDecimal(String.Format("{0:N4}", AllETHCnyaa));//保留2位小数
                        decimal AllNECUSDT = AllNEC + USDT + ETH;//NEC+USDT+ ETH 
                        decimal AllNECUSDTCNY = AllNECCNY + USDTCNY + AllETHCny;//显示所有(NEC+USDT+ ETH )*汇率
                         
                        List<string> list = new List<string>();

                        list.Add(UsableNEC);
                        list.Add(FreezeNEC);
                        list.Add(AllNEC.ToString());
                        list.Add(AllNECCNY.ToString());

                        list.Add(USDT.ToString());
                        list.Add(USDTCNY.ToString());
                        list.Add(AllNECUSDT.ToString());
                        list.Add(AllNECUSDTCNY.ToString());

                        list.Add(ETH.ToString());
                        list.Add(AllETHCny.ToString());

                        list.Add(ss.ToString());
                        list.Add(usdt_zhuan_eth.ToString());
                        list.Add(UsableNECCNY.ToString());


                        message.Data = ShopNum1_QLXEarnings.FromDataRow1(list);//KceApiHelper.M_json(selectGoods);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_QLXEarnings));
                        message.Result = 1;
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }




                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary>
        /// 我的收益一串
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="token">  hashrate 算力收益1 link链接收益2 signin签到收益3 presenter赠送收益4</param>
        [WebMethod]
        public void MyEarningsSingleSQL(string MemLoginID, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SundryEarnings = member_Action.AccountEarningsSingleSQL(MemLoginID);//查询4种收益
                    string hashrateAll  ;
                    string linkAll  ;
                    string signinAll;
                    string presenterAll ;

                    string hashrateNew ;
                    string linkNew;
                    string signinNew ;
                    string presenterNew;
                    string createtime ;

                    if (SundryEarnings != null &&SundryEarnings.Rows.Count > 0)
                    {

                        hashrateAll = SundryEarnings.Rows[0]["Bonus1"].ToString();
                        if (hashrateAll == "" || hashrateAll == null)
                        { 
                            hashrateAll = "0"; 
                        }
                             
                        linkAll = SundryEarnings.Rows[0]["Bonus2"].ToString();
                        if (linkAll == "" || linkAll == null)
                        {
                            linkAll = "0";
                        }
                       signinAll = SundryEarnings.Rows[0]["Bonus3"].ToString();

                       if (signinAll == "" || signinAll == null)
                       {
                           signinAll = "0";
                       }
                        
                       presenterAll = SundryEarnings.Rows[0]["Bonus4"].ToString();
                       if (presenterAll == "" || presenterAll == null)
                       {
                           presenterAll = "0";
                       }
                        string presenterAllBonus = Convert.ToString(Convert.ToDecimal(hashrateAll) + Convert.ToDecimal(linkAll) + Convert.ToDecimal(signinAll) + Convert.ToDecimal(presenterAll));//累积总收益

                        DataTable NewestEarnings = member_Action.NewestEarningsSingleSQl(MemLoginID);//查最新收益
                        if (NewestEarnings.Rows.Count > 0 && NewestEarnings != null)
                        {
                            hashrateNew = NewestEarnings.Rows[0]["Bonus1"].ToString();
                           if (hashrateNew == "" || hashrateNew == null)
                           {
                               hashrateNew = "0";
                           }
                           linkNew = NewestEarnings.Rows[0]["Bonus2"].ToString();
                           if (linkNew == "" || linkNew == null)
                           {
                               linkNew = "0";
                           }
                           signinNew = NewestEarnings.Rows[0]["Bonus3"].ToString();
                           if (signinNew == "" || signinNew == null)
                           {
                               signinNew = "0";
                           }
                            
                           presenterNew = NewestEarnings.Rows[0]["Bonus4"].ToString();
                           if (presenterNew == "" || presenterNew == null)
                           {
                               presenterNew = "0";
                           }
 
                            string NewAllBonus = Convert.ToString(Convert.ToDecimal(hashrateNew) + Convert.ToDecimal(linkNew) + Convert.ToDecimal(signinNew) + Convert.ToDecimal(presenterNew));//昨日收益
                            createtime = NewestEarnings.Rows[0]["CreateTime"].ToString();
                            List<string> list = new List<string>();
                            list.Add(hashrateAll);
                            list.Add(linkAll);
                            list.Add(signinAll);
                            list.Add(presenterAll);

                            list.Add(hashrateNew);
                            list.Add(linkNew);
                            list.Add(signinNew);
                            list.Add(presenterNew);
                            list.Add(createtime);
                            list.Add(presenterAllBonus);
                            list.Add(NewAllBonus);

                            message.Data = ShopNum1_EarningSingleSql.FromDataRow1(list);//KceApiHelper.M_json(selectGoods);
                            List<Type> types = new List<Type>();
                            types.Add(typeof(ShopNum1_EarningSingleSql));
                            message.Result = 1;
                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                        }
                        else
                        {
                            message.Result = 0;
                            message.Code = "0";
                            message.Message = Gz_LogicApi.GetString("MG000054");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                        }
                    }

                    else
                    {
                        message.Result = 0;
                        message.Code = "0";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }



                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }


        /// <summary> 
        /// 我的收益  具体记录
        /// </summary>hashrate 算力收益1 link链接收益2 signin签到收益3 presenter赠送收益4 
        /// <param name="MemloginID"自己手机/UID></param>
        /// <param name="token" token></param>
        [WebMethod]
        public void MyEarningsDetails(string MemLoginID, string top, string number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    DataTable SelectEarningsDetails = member_Action.MyEarningsDetails(MemLoginID, top, number);
                    if (SelectEarningsDetails != null && SelectEarningsDetails.Rows.Count > 0)
                    {

                        List<Type> types = new List<Type>();
                        types.Add(typeof(EarningsDetails));
                        types.Add(typeof(List<EarningsDetails>));
                        message.Data = EarningsDetails.FromDataRow1(SelectEarningsDetails);
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));


                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }
        /// <summary>
        /// 用type来区分
        /// </summary>

        [WebMethod]
        public void MyEarningsDetailsNew(string MemLoginID, string type, string top, string number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    DataTable SelectEarningsDetails = member_Action.MyEarningsDetailsNew(MemLoginID, type, top, number);
                    if (SelectEarningsDetails != null && SelectEarningsDetails.Rows.Count > 0)
                    {

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_EarningsDetailsNews));
                        types.Add(typeof(List<ShopNum1_EarningsDetailsNews>));
                        message.Data = ShopNum1_EarningsDetailsNews.FromDataRow1(SelectEarningsDetails);
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));


                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary>
        /// 社区收益
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="type"></param>
        /// <param name="top"></param>
        /// <param name="number"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void MyEarningsDetailsNewSheQu(string MemLoginID, string type, string top, string number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SelectEarningsDetails = new DataTable();
                    string language = Gz_LogicApi.GetHttpHeader("lang");
                    if (language == "CN")
                    {
                        SelectEarningsDetails = member_Action.MyEarningsDetailsNewSheQu(MemLoginID, type, top, number);
                    }
                    else if (language == "EN")
                    {
                        SelectEarningsDetails = member_Action.MyEarningsDetailsNewSheQuEnglish(MemLoginID, type, top, number);
                    }
                    else
                    {
                        SelectEarningsDetails = member_Action.MyEarningsDetailsNewSheQu(MemLoginID, type, top, number);
                    }
                    if (SelectEarningsDetails != null && SelectEarningsDetails.Rows.Count > 0)
                    {

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_EarningsDetailsNews2));
                        types.Add(typeof(List<ShopNum1_EarningsDetailsNews2>));
                        message.Data = ShopNum1_EarningsDetailsNews2.FromDataRow1(SelectEarningsDetails);
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));


                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary>
        /// 查询公告标题
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>  
        /// <param name="token" token></param>
        /// <param name="top">分页从第几页开始</param>
        /// <param name="number">每页多少条数据</param> 
        /// Message 表示有数字数量
        [WebMethod]
        public void ShowNotice(string MemLoginID, int top, int number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SelectAddressByMemloginID = member_Action.Cotice(top, number);
                    //DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemloginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {

                        List<Type> types = new List<Type>();
                        types.Add(typeof(KCENotice));
                        types.Add(typeof(List<KCENotice>));
                        message.Data = KCENotice.FromDataRow1(SelectAddressByMemloginID);
                        //message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString();
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");


                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");


                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");


                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }

            Context.Response.End();
        }


        /// <summary> 
        /// 查询公告内容
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>
        /// <param name="token" token></param>
        /// Message 表示数字数量
        [WebMethod]
        public void ShowNoticeContent(string MemLoginID, string Guid, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    DataTable SelectAddressByMemloginID = member_Action.CoticeContent(Guid);
                    //DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemloginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {

                        message.Data = KCENoticeContent.FromDataRow1(SelectAddressByMemloginID.Rows[0]);//KceApiHelper.M_json(selectGoods);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(KCENoticeContent));
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }

            Context.Response.End();
        }


        /// <summary>
        /// 留言
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>  

        [WebMethod]
        public void Message(string MemLoginID, string QuestionType, string talk, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    int SelectAddressByMemloginID = member_Action.KCEMessage(MemLoginID, talk, QuestionType);
                    //DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemloginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID > 0)
                    {
                        message.Result = 1;
                        message.Code = "1";
                        message.Message = Gz_LogicApi.GetString("MG000073");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10015";
                        message.Message = Gz_LogicApi.GetString("MG000074");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");

                }
                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            }

            Context.Response.End();
        }


        /// <summary>
        /// 查推荐人
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>  

        [WebMethod]
        public void QueryReferee(string MemLoginID, int top, int number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SelectAddressByMemloginID = new DataTable();
                    string language = Gz_LogicApi.GetHttpHeader("lang");
                    if (language == "CN")
                    {
                        SelectAddressByMemloginID = member_Action.QueryReference1(MemLoginID, top, number);
                    }
                    else if (language == "EN")
                    {
                        SelectAddressByMemloginID = member_Action.QueryReferenceEnglish(MemLoginID, top, number);
                    }
                    else
                    {
                        SelectAddressByMemloginID = member_Action.QueryReference1(MemLoginID, top, number);
                    }
                    //DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemloginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {
                        DataTable SelectAddressByMemloginIDQXL = member_Action.QueryReference1QXL(MemLoginID);

                        message.Message = SelectAddressByMemloginIDQXL.Rows[0]["meml"].ToString();
                        message.Data = QueryReference.FromDataRow1(SelectAddressByMemloginID);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(QueryReference));
                        types.Add(typeof(List<QueryReference>));
                        //message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString();
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary>
        /// 查推荐自己下面所有收益,也就是自己的收益
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="top"></param>
        /// <param name="number"></param>
        /// <param name="token"></param>
        [WebMethod]
        public void QueryRefereeBonus(string MemLoginID, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SelectAddressByMemloginID = member_Action.QueryReference1Bonus(MemLoginID);
                    //DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemloginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {
                        string YesterdayAllBonus = SelectAddressByMemloginID.Rows[0]["YesterdayAllBonus"].ToString();
                        message.Result = 1;
                        message.Code = "1";
                        message.Message = YesterdayAllBonus;
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }


        /// <summary>
        /// 查KT购买k宝记录
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>  
        /// <param name="type"/UID>1为等于/2为不等于</param>  
        /// <param name="type">1收款人是55667788/2不是55667788</param>
        [WebMethod]
        public void QueryKtBuyHv(string MemLoginID, string type, string GatheringOrTransferAccountsType, int top, int number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    DataTable SelectAddressByMemloginID = member_Action.QueryKtTHv(MemLoginID, type, GatheringOrTransferAccountsType, top, number);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_Member2));
                        types.Add(typeof(List<ShopNum1_M_Member2>));
                        message.Data = ShopNum1_M_Member2.FromDataRow1(SelectAddressByMemloginID);
                        message.Message = SelectAddressByMemloginID.Rows.Count.ToString();
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }


        /// <summary>
        /// 绑定设备号
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="shebeihao">设备号</param>
        /// <param name="photo">照片</param>
        /// <param name="CarType">车类型（1、新能源车，2燃油车）</param>
        /// <param name="CarNumber">车牌号</param>
        /// <param name="token"></param>

        [WebMethod]
        public void BindingDevice_no(string MemLoginID, string shebeihao, string photo, string CarType, string CarNumber, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    ShopNum1_MemberShip_Action memberShipAction = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                    DataTable memshipChongFu = memberShipAction.SearchShipRepeatMemLoginID(MemLoginID, 1);
                    if (memshipChongFu.Rows.Count > 0)
                    {
                        message.Result = 0;
                        message.Code = "000002";
                        message.Message = Gz_LogicApi.GetString("MG000074");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }
                    else
                    {
                        if (shebeihao == "" || photo == "" || CarNumber == "")
                        {
                            message.Result = 0;
                            message.Code = "000001";
                            message.Message = Gz_LogicApi.GetString("MG000076");
                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        }
                        else
                        {
                            DataTable CheckMeml_Device = memberShipAction.Check_Device(MemLoginID);
                            if (memshipChongFu.Rows.Count > 0)
                            {
                                message.Result = 0;
                                message.Code = "000002";
                                message.Message = Gz_LogicApi.GetString("MG000077");
                                Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                            }
                            else
                            {
                                string CarName = "";
                                string CarTypeNum = "";
                                if (CarType == "1")
                                {
                                    CarName = "新能源汽车";
                                    CarTypeNum = "1";
                                }
                                else
                                {
                                    CarName = "燃油汽车";
                                    CarTypeNum = "2";
                                }

                                string shebei = "";
                                if (shebeihao.Length == 11)
                                {
                                    shebei = "0" + shebeihao.Trim();
                                }
                                else if (shebeihao.Length == 10)
                                {
                                    shebei = "01" + shebeihao.Trim();
                                }
                                else
                                {
                                    shebei = shebeihao.Trim();
                                }
                                DataTable deviceno = member_Action.SearchGPS_device(shebei);
                                if (deviceno.Rows.Count > 0)
                                {
                                    DataTable memdevice = member_Action.SearchMEM_device(shebei);
                                    if (memdevice.Rows.Count > 0)
                                    {
                                        message.Result = 0;
                                        message.Code = "000003";
                                        message.Message = Gz_LogicApi.GetString("MG000078");
                                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                                    }
                                    else
                                    {

                                        //-----------------------------照片-----------------------------------
                                        photo = photo.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
                                        byte[] bytes = Convert.FromBase64String(photo);
                                        MemoryStream memStream = new MemoryStream(bytes);
                                        Image mImage = Image.FromStream(memStream);
                                        Bitmap bp = new Bitmap(mImage);
                                        bp.Save(Server.MapPath("~/ImgUpload/Member_Ship/") + MemLoginID + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//注意保存路径
                                        string photoaReal = "~/ImgUpload/Member_Ship/" + MemLoginID + ".jpg";
                                        //----------------------------照片------------------------------------


                                        int SelectAddressByMemloginID = member_Action.BindingDevice_no(MemLoginID, shebeihao, photoaReal, CarTypeNum, CarName, CarNumber);

                                        if (SelectAddressByMemloginID > 0)
                                        {
                                            message.Result = 1;
                                            message.Code = "1";
                                            message.Message = "您的" + CarName + "申请绑定成功！";
                                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                        }
                                        else
                                        {
                                            message.Result = 0;
                                            message.Code = "000005";
                                            message.Message = Gz_LogicApi.GetString("MG000079");
                                            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                        }
                                    }
                                }
                                else
                                {
                                    message.Result = 0;
                                    message.Code = "000006";
                                    message.Message = Gz_LogicApi.GetString("MG000080");
                                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000081");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000082");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000083");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }



        /// <summary>
        /// 绑定地址
        /// </summary>
        /// <param name="MemloginID"自己手机/UID></param>  

        [WebMethod]
        public void BindingAddress(string MemLoginID, string Address, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    int SelectAddressByMemloginID = member_Action.Bindingaddress(MemLoginID, Address);
                    //DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemloginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID > 0)
                    {
                        message.Result = 1;
                        message.Code = "1";
                        message.Message = Gz_LogicApi.GetString("MG000084");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10015";
                        message.Message = Gz_LogicApi.GetString("MG000085");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }


        /// <summary> 
        /// 查询账户记录  奖金记录
        /// </summary>查询 静态 动态 兑换额 流通额
        /// <param name="MemloginID"自己手机/UID></param>
        /// <param name="token" token></param>
        /// Message 表示数字数量
        [WebMethod]
        public void QueryAccountRecords(string MemLoginID, string PayPwd, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    string newPassIIWord = Common.Encryption.GetMd5SecondHash(PayPwd);
                    string Pwdpay = member_Action.Accountrecords(MemLoginID).Rows[0]["PayPwd"].ToString();
                    DataTable jingtai = member_Action.AccountrecordsBonus3(MemLoginID);
                    DataTable duihuane = member_Action.AccountrecordsThree(MemLoginID);
                    if (newPassIIWord == Pwdpay)
                    {
                        decimal Frist = 0;//静态
                        decimal Second = 0;//总和
                        decimal Three = 0;
                        decimal five = 0;
                        if (duihuane != null && duihuane.Rows.Count > 0)
                        {
                            if (duihuane.Rows[0]["ExchangeAmount"] == null)
                            {
                                Three = 0;
                            }
                            else
                            {
                                Three = Convert.ToDecimal(duihuane.Rows[0]["ExchangeAmount"]);//兑换额
                            }
                            if (duihuane.Rows[0]["Allnum"] == null)
                            {
                                five = 0;
                            }
                            else
                            {
                                five = Convert.ToDecimal(duihuane.Rows[0]["Allnum"]);//流通额
                            }
                        }
                        if (jingtai != null && jingtai.Rows.Count > 0)
                        {
                            if (jingtai.Rows[0]["Static"] == null)
                            {
                                Frist = 0;
                            }
                            else
                            {
                                Frist = Convert.ToDecimal(jingtai.Rows[0]["Static"]);//静态
                            }
                            if (jingtai.Rows[0]["Trends"] == null)
                            {
                                Second = 0;
                            }
                            else
                            {
                                Second = Convert.ToDecimal(jingtai.Rows[0]["Trends"]);//动态
                            }

                        }

                        List<decimal> list = new List<decimal>();
                        list.Add(Frist);
                        list.Add(Second);
                        list.Add(Three);
                        list.Add(five);
                        message.Data = AcountA_B_C.FromDataRow1(list);//KceApiHelper.M_json(selectGoods);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(AcountA_B_C));
                        message.Result = 1;
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10252";
                        message.Message = Gz_LogicApi.GetString("MG000086");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }

                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary>
        /// 提现记录
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="PayPwd"></param>
        /// <param name="token"></param>
        /// type  1 查询提现ETH 、2查询NEC提现
        [WebMethod]
        public void TiXianRecord(string MemLoginID, string type, string top, string number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    DataTable SelectAddressByMemloginID = new DataTable();
                    string language = Gz_LogicApi.GetHttpHeader("lang");
                    if (language == "CN")
                    {
                        SelectAddressByMemloginID = member_Action.Select_NEC_TiXian(MemLoginID, type, top, number);
                    }
                    else if (language == "EN")
                    {
                        SelectAddressByMemloginID = member_Action.Select_NEC_TiXianEnglish(MemLoginID, type, top, number);
                    }
                    else
                    {
                        SelectAddressByMemloginID = member_Action.Select_NEC_TiXian(MemLoginID, type, top, number);
                    }
                    //DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemloginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {
                        DataTable SelectAddressByMemloginIDQXL = member_Action.Select_NEC_TiXian_Count(MemLoginID, type);
                        List<Type> types = new List<Type>();
                        types.Add(typeof(NEC_TiXian));
                        types.Add(typeof(List<NEC_TiXian>));
                        message.Message = SelectAddressByMemloginIDQXL.Rows[0]["meml"].ToString();
                        message.Data = NEC_TiXian.FromDataRow1(SelectAddressByMemloginID);
                        //message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString();
                        Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }

        /// <summary> 
        /// 查询账户记录  奖金记录
        /// </summary>Type1 1动态明细 2静态明细 3兑换额 4 流通额
        /// <param name="MemloginID"自己手机/UID></param>
        /// <param name="token" token></param>
        /// Message 表示数字数量
        [WebMethod]
        public void BonusDetails(string MemLoginID, string Type1, string top, string number, string token)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    DataTable SelectAddressByMemloginID = member_Action.BounsKCE(MemLoginID, Type1, top, number);
                    //DataTable SelectAddressByMemloginIDCount = member_Action.GetmemebierCount(MemloginID, type, GatheringOrTransferAccountsType);
                    if (SelectAddressByMemloginID != null && SelectAddressByMemloginID.Rows.Count > 0)
                    {
                        if (Type1 == "1")
                        {
                            List<Type> types = new List<Type>();
                            types.Add(typeof(KCEBonus));
                            types.Add(typeof(List<KCEBonus>));
                            message.Data = KCEBonus.FromDataRow1(SelectAddressByMemloginID);
                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                        }
                        if (Type1 == "2")
                        {
                            List<Type> types = new List<Type>();
                            types.Add(typeof(KCEBonus1));
                            types.Add(typeof(List<KCEBonus1>));
                            message.Data = KCEBonus1.FromDataRow1(SelectAddressByMemloginID);
                            //message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString();
                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                        }
                        if (Type1 == "3")
                        {
                            List<Type> types = new List<Type>();
                            types.Add(typeof(KCEBonus2));
                            types.Add(typeof(List<KCEBonus2>));
                            message.Data = KCEBonus2.FromDataRow1(SelectAddressByMemloginID);
                            //message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString();
                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                        }
                        if (Type1 == "4")
                        {
                            List<Type> types = new List<Type>();
                            types.Add(typeof(KCEBonus3));
                            types.Add(typeof(List<KCEBonus3>));
                            message.Data = KCEBonus3.FromDataRow1(SelectAddressByMemloginID);
                            //message.Message = SelectAddressByMemloginIDCount.Rows.Count.ToString();
                            Context.Response.Write(KceApiHelper.GetJSON_two<GZMessage>(message, types));
                        }

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "0o_x10013";
                        message.Message = Gz_LogicApi.GetString("MG000054");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    }


                }
                catch (Exception ex)
                {
                    message.Result = 00;
                    message.Code = Gz_LogicApi.GetString("MG000003");
                    message.Message = Gz_LogicApi.GetString("MG000003");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                }
            }
            else
            {
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10004";
                    message.Message = Gz_LogicApi.GetString("MG000012");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10001";
                    message.Message = Gz_LogicApi.GetString("MG000016");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
                else if (ReturnValue == "3")
                {
                    message.Result = 0;
                    message.Code = "10008";
                    message.Message = Gz_LogicApi.GetString("MG000017");
                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));

                }
            }

            Context.Response.End();
        }


        //--------------------------------------------------------------------------------------------------------老周

        //






        //CTC挂卖单
        //MemloginID 自己的UID
        //hv 出售NEC数量
        //Paypwd 交易密码
        //token  身份验证信息
        [WebMethod]
        public void SellK(string MemLoginID, string hv, string Paypwd, string token)
        {
            GZMessage message = new GZMessage();
            message.Result = 0;
            message.Code = "10004";
            message.Message = Gz_LogicApi.GetString("MG000087");
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
            //GZMessage message = new GZMessage();
            //string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            //string[] tValues = TokenPuzzle.Split('~');
            //if (MemLoginID.ToUpper() == tValues[0].ToUpper())
            //{
            //    string ReturnValue = KceApiHelper.UserAuthenticationTwo(tValues[0], tValues[1], tValues[2]);
            //    if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            //    {

            //        try
            //        {
            //            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            //            DataTable TableMemBer = member_Action.SearchMemberGz(MemLoginID);
            //            DataTable TableNECBiLi = member_Action.QLXNECBiLiAPP("2");
            //            decimal NECBiLi = Convert.ToDecimal(TableNECBiLi.Rows[0]["NECBiLi"]);

            //                decimal MyHv = Convert.ToDecimal(TableMemBer.Rows[0]["Score_dv"]);

            //                string payPwd = member_Action.GetPayPwd(MemLoginID);

            //                string str3 = Common.Encryption.GetMd5SecondHash(Paypwd.Trim());
            //                if (payPwd != str3)
            //                {
            //                    message.Result = 0;
            //                    message.Code = "0o_x110004";
            //                    message.Message = "用户二级密码错误";
            //                }

            //                else
            //                {
            //                    if (MyHv >= Convert.ToDecimal(hv))
            //                    {

            //                        if (Convert.ToDecimal(hv) <= 0)
            //                        {
            //                            message.Result = 0;
            //                            message.Code = "0o_x110005";
            //                            message.Message = "输入的NEC不能为负数或为0";
            //                        }

            //                        else
            //                        {

            //                            var order = new Order();
            //                            string OrderNumber = order.CreateOrderNumber();
            //                            string OrderNumberMemloginID = MemLoginID.Substring(MemLoginID.Length - 2);
            //                            OrderNumber = OrderNumber + OrderNumberMemloginID;
            //                            decimal Score_pv_b = Convert.ToDecimal(hv) * NECBiLi;
            //                            int selectMember = member_Action.AddCTCMaiDan(MemLoginID, OrderNumber, hv, Score_pv_b.ToString());

            //                            message.Result = 1;
            //                            message.Code = "Y_110002";
            //                            message.Message = "挂卖单成功";

            //                        }


            //                    }
            //                    else
            //                    {
            //                        message.Result = 0;
            //                        message.Code = "0o_x110003";
            //                        message.Message = "用户NEC不足，无法挂单";


            //                    }
            //                }




            //        }
            //        catch (Exception ex)
            //        {

            //            message.Result = 0;
            //            message.Code = Gz_LogicApi.GetString("MG000003");
            //            message.Message = Gz_LogicApi.GetString("MG000003");



            //        }


            //        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            //        Context.Response.End();
            //    }
            //    else
            //    {
            //        // Serialize(ContentType);                  
            //        if (ReturnValue == "0")
            //        {
            //            message.Result = 0;
            //            message.Code = "10004";
            //            message.Message = Gz_LogicApi.GetString("MG000012");
            //            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            //            Context.Response.End();
            //        }
            //        else if (ReturnValue == "2")
            //        {
            //            message.Result = 0;
            //            message.Code = "10001";
            //            message.Message = Gz_LogicApi.GetString("MG000016");
            //            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            //            Context.Response.End();
            //        }
            //        else if (ReturnValue == "3")
            //        {
            //            message.Result = 0;
            //            message.Code = "10008";
            //            message.Message =  Gz_LogicApi.GetString("MG000017");
            //            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            //            Context.Response.End();
            //        }
            //    }


            //}

        }


        //CTC挂买单
        //MemloginID 自己的UID
        //hv 购买K宝数量
        //Paypwd 交易密码
        //token  身份验证信息
        [WebMethod]
        public void BuyK(string MemLoginID, string hv, string Paypwd, string token)
        {
            GZMessage message = new GZMessage();
            message.Result = 0;
            message.Code = "10004";
            message.Message = Gz_LogicApi.GetString("MG000088");
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();
            //string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            //string[] tValues = TokenPuzzle.Split('~');
            //if (MemLoginID.ToUpper() == tValues[0].ToUpper())
            //{
            //    string ReturnValue = KceApiHelper.UserAuthenticationTwo(tValues[0], tValues[1], tValues[2]);
            //    if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            //    {

            //        try
            //        {
            //            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //            DataTable TableNECBiLi = member_Action.QLXNECBiLiAPP("1");
            //            decimal NECBiLi = Convert.ToDecimal(TableNECBiLi.Rows[0]["NECBiLi"]);
            //            DataTable TableMemBer = member_Action.SearchMemberGz(MemLoginID);



            //                decimal AdvancePayment = Convert.ToDecimal(TableMemBer.Rows[0]["AdvancePayment"]);
            //                string payPwd = member_Action.GetPayPwd(MemLoginID);

            //                string str3 = Common.Encryption.GetMd5SecondHash(Paypwd.Trim());
            //                if (payPwd != str3)
            //                {
            //                    message.Result = 0;
            //                    message.Code = "0o_x110004";
            //                    message.Message = "用户二级密码错误";
            //                }

            //                else
            //                {

            //                    decimal Score_pv_b = Convert.ToDecimal(hv) * NECBiLi;
            //                    if (AdvancePayment >= Score_pv_b)
            //                    {

            //                        if (Convert.ToDecimal(hv) <= 0)
            //                        {
            //                            message.Result = 0;
            //                            message.Code = "0o_x110005";
            //                            message.Message = "输入的NEC不能为负数或为0";
            //                        }
            //                        else
            //                        {

            //                            var order = new Order();
            //                            string OrderNumber = order.CreateOrderNumber();
            //                            string OrderNumberMemloginID = MemLoginID.Substring(MemLoginID.Length - 2);
            //                            OrderNumber = OrderNumber + OrderNumberMemloginID;

            //                            int selectMember = member_Action.AddCTCGetDan(MemLoginID, OrderNumber, hv, Score_pv_b.ToString());

            //                            message.Result = 1;
            //                            message.Code = "Y_110002";
            //                            message.Message = "挂买单成功";

            //                        }


            //                    }
            //                    else
            //                    {
            //                        message.Result = 0;
            //                        message.Code = "0o_x110003";
            //                        message.Message = "用户USDT不足，无法挂单";


            //                    }
            //                }


            //        }
            //        catch (Exception ex)
            //        {

            //            message.Result = 0;
            //            message.Code = Gz_LogicApi.GetString("MG000003");
            //            message.Message = Gz_LogicApi.GetString("MG000003");



            //        }


            //        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            //        Context.Response.End();
            //    }
            //    else
            //    {
            //        // Serialize(ContentType);                  
            //        if (ReturnValue == "0")
            //        {
            //            message.Result = 0;
            //            message.Code = "10004";
            //            message.Message = Gz_LogicApi.GetString("MG000012");
            //            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            //            Context.Response.End();
            //        }
            //        else if (ReturnValue == "2")
            //        {
            //            message.Result = 0;
            //            message.Code = "10001";
            //            message.Message = Gz_LogicApi.GetString("MG000016");
            //            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            //            Context.Response.End();
            //        }
            //        else if (ReturnValue == "3")
            //        {
            //            message.Result = 0;
            //            message.Code = "10008";
            //            message.Message =  Gz_LogicApi.GetString("MG000017");
            //            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            //            Context.Response.End();
            //        }
            //    }


            // }

        }



        //CTC取消单
        //MemloginID 自己的UID
        //OrderNumber 挂的订单编号
        //token  身份验证信息
        [WebMethod]
        public void CancelCTC(string MemLoginID, string OrderNumber, string token)
        {
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(KceApiHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            if (MemLoginID.ToUpper() == tValues[0].ToUpper())
            {
                string ReturnValue = KceApiHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
                if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
                {

                    try
                    {
                        ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

                        DataTable selectMember = member_Action.SelctOderInfoAll(OrderNumber);
                        if (selectMember != null && selectMember.Rows.Count > 0)
                        {
                            string OderStatus = selectMember.Rows[0]["OderStatus"].ToString();
                            if (OderStatus == "1")
                            {
                                string ShipmentStatus = selectMember.Rows[0]["ShipmentStatus"].ToString();
                                if (ShipmentStatus == "2")
                                {
                                    member_Action.UpdateOderInfoOderStatus(OrderNumber);
                                    message.Result = 1;
                                    message.Code = "Y_110003";
                                    message.Message = Gz_LogicApi.GetString("MG000089");
                                }
                                else
                                {
                                    member_Action.UpdateOderInfoOderStatusTwo(OrderNumber);
                                    message.Result = 1;
                                    message.Code = "Y_110003";
                                    message.Message = Gz_LogicApi.GetString("MG000089");
                                }

                            }
                            else
                            {
                                message.Result = 0;
                                message.Code = "0o_x110008";
                                message.Message = Gz_LogicApi.GetString("MG000090");
                            }
                        }
                        else
                        {
                            message.Result = 0;
                            message.Code = "0o_x110009";
                            message.Message = Gz_LogicApi.GetString("MG000091");
                        }





                    }
                    catch (Exception ex)
                    {

                        message.Result = 0;
                        message.Code = Gz_LogicApi.GetString("MG000003");
                        message.Message = Gz_LogicApi.GetString("MG000003");



                    }


                    Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    // Serialize(ContentType);                  
                    if (ReturnValue == "0")
                    {
                        message.Result = 0;
                        message.Code = "10004";
                        message.Message = Gz_LogicApi.GetString("MG000012");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                    else if (ReturnValue == "2")
                    {
                        message.Result = 0;
                        message.Code = "10001";
                        message.Message = Gz_LogicApi.GetString("MG000016");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                    else if (ReturnValue == "3")
                    {
                        message.Result = 0;
                        message.Code = "10008";
                        message.Message = Gz_LogicApi.GetString("MG000017");
                        Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
                        Context.Response.End();
                    }
                }


            }

        }


        //返回NEC的交易比例
        [WebMethod]
        public void GETNECBiLi(string TypeNumber)
        {
            GZMessage message = new GZMessage();



            try
            {
                ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();


                DataTable TableNECBiLi = member_Action.QLXNECBiLiAPP(TypeNumber);
                if (TableNECBiLi != null && TableNECBiLi.Rows.Count > 0)
                {
                    string NECBiLi = Convert.ToString(TableNECBiLi.Rows[0]["NECBiLi"]);



                    message.Result = 1;
                    message.Code = NECBiLi;
                    message.Message = Gz_LogicApi.GetString("MG000092");
                }
                else
                {
                    message.Result = 0;
                    message.Code = "Y_110031";
                    message.Message = Gz_LogicApi.GetString("MG000093");
                }





            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = Gz_LogicApi.GetString("MG000003");
                message.Message = Gz_LogicApi.GetString("MG000003");



            }
            Context.Response.Write(KceApiHelper.GetJSON<GZMessage>(message));
            Context.Response.End();





        }
    }
}

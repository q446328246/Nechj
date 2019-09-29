using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Factory;
using ShopNum1.ShopWebControl;
using ShopNum1MultiEntity;
using ShopNum1.BusinessLogic;


namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// pcoment 的摘要说明
    /// </summary>
    public class Recharge : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }
        public void ProcessRequest(HttpContext context)
        {
            //    String SETMONEYBYID_ERROR01 = "ID没有对应用户，ID错误。";
            //    String SETMONEYBYID_ERROR02 = "MD5对比过程出现不匹配。请检查MD5加密过程和结果。";
            //    String SETMONEYBYID_ERROR03 = "输入的类型错误，请输入“BV”或者“DV”字样。";
            //    String SETMONEYBYID_ERROR04 = "执行对应账户资金修改过程中出错。";
            //    String SETMONEYBYID_ERROR05 = "在录入用户的交易记录中出错了。";
            //    String SETMONEYBYID_ERROR06 = "充值过程中出现错误，没有在资金明细中加入记录。";
            //    String SETMONEYBYID_ERROR07 = "已经执行过一次相同的资金变革，无法执行相同单号的任务";
            //public string SetMoneyById(string creatTime, string money, string id, string type, string md5)
            //{
            //    string creatTime = ShopNum1.Common.Common.ReqPostStr("createtime");
            //    string money = ShopNum1.Common.Common.ReqPostStr("money");
            //    string id = ShopNum1.Common.Common.ReqPostStr("id");
            //    string type = ShopNum1.Common.Common.ReqPostStr("type");
            //    string md5 = ShopNum1.Common.Common.ReqPostStr("md5");
            //    string logID = ShopNum1.Common.Common.ReqPostStr("applyno");

            //    string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            //    string privateKey_two = "Createtime=" + HttpUtility.UrlDecode(creatTime) + "&Money=" + money + "&ID=" + id + "&Type=" + type + "&Applyno=" + logID + md5_one + "";
            //    string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //    var shopNum1_AdvancePaymentModifyLog_Action =
            //                (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            //    if (md5Check_two.ToUpper() == md5.ToUpper())
            //    {

            //        ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
            //        DataTable moneyAndDv = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectMemberByMemLoginID(id);
            //        if (moneyAndDv.Rows.Count > 0)
            //        {
            //          DataTable table2=  shopNum1_AdvancePaymentModifyLog_Action.GetAdvancePaymentModifyLog_two(logID);
            //            string Mytype = string.Empty;
            //            try
            //            {


            //                if (type.ToUpper() == "DV")
            //                {

            //                    Mytype = "Score_dv";
            //                    advance.HuoDe_dv = Convert.ToDecimal(money);
            //                    advance.HuoDe_Hou_dv = Convert.ToDecimal(moneyAndDv.Rows[0]["Score_dv"]) + Convert.ToDecimal(money);
            //                    advance.HuoDe_YuanYou_dv = Convert.ToDecimal(moneyAndDv.Rows[0]["Score_dv"]);


            //                }
            //                else if (type.ToUpper() == "BV")
            //                {
            //                    Mytype = "AdvancePayment";
            //                    advance.CurrentAdvancePayment = Convert.ToDecimal(moneyAndDv.Rows[0]["AdvancePayment"]);
            //                    advance.OperateMoney = Convert.ToDecimal(money);
            //                    advance.LastOperateMoney = Convert.ToDecimal(moneyAndDv.Rows[0]["AdvancePayment"]) + Convert.ToDecimal(money);

            //                }
            //                else
            //                {
            //                    context.Response.Write( SETMONEYBYID_ERROR03);
            //                }
            //                if (table2 != null && table2.Rows.Count > 0)
            //                {
            //                    context.Response.Write(SETMONEYBYID_ERROR07);
            //                }
            //                else
            //                {
            //                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateMoneyByDateTimeAndID(Convert.ToDecimal(money), id, Mytype);

            //                    advance.Guid = Guid.NewGuid();
            //                    advance.IsDeleted = 0;
            //                    advance.OperateType = 1;
            //                    advance.Date = Convert.ToDateTime(HttpUtility.UrlDecode(creatTime));
            //                    advance.Memo = "A网转账";
            //                    advance.MemLoginID = id;
            //                    advance.CreateUser = id;
            //                    advance.CreateTime = Convert.ToDateTime(HttpUtility.UrlDecode(creatTime));
            //                    advance.LogID = logID;
            //                    advance.OrderNumber = "";

            //                    try
            //                    {
            //                        if (table2 != null && table2.Rows.Count > 0)
            //                        {
            //                            context.Response.Write(SETMONEYBYID_ERROR07);
            //                        }
            //                        else
            //                        {
            //                            shopNum1_AdvancePaymentModifyLog_Action.OperateMoneyRV_two(advance, Mytype);
            //                        }


            //                    }
            //                    catch
            //                    {
            //                        context.Response.Write(SETMONEYBYID_ERROR05);

            //                    }
            //                    DataTable table3 = shopNum1_AdvancePaymentModifyLog_Action.GetAdvancePaymentModifyLog_two(logID);
            //                    if (table3 != null && table3.Rows.Count > 0)
            //                    {
            //                        context.Response.Write("转账成功" + logID);
            //                    }
            //                    else
            //                    {
            //                        context.Response.Write(SETMONEYBYID_ERROR06 );
            //                    }
            //                }


            //            }
            //            catch
            //            {

            //                context.Response.Write(  SETMONEYBYID_ERROR04);
            //            }










            //        }
            //        else
            //        {
            //            context.Response.Write(  SETMONEYBYID_ERROR01);
            //        }

            //    }
            //    else
            //    {
            //        context.Response.Write(  SETMONEYBYID_ERROR02);
            //    }



            //}


            //}


        }
    }
}
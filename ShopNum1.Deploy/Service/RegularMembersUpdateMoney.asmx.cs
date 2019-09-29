using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ShopNum1.BusinessLogic;
using System.Data;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// RegularMembersUpdateMoney 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class RegularMembersUpdateMoney : System.Web.Services.WebService
    {
        String SETMONEYBYID_ERROR01 = "ID和姓名没有对应用户，ID或者姓名错误，不是S会员也不行";
        String SETMONEYBYID_ERROR02 = "MD5对比过程出现不匹配。请检查MD5加密过程和结果。";
        String SETMONEYBYID_ERROR03 = "输入的类型错误，请输入“BV”或者“DV”字样。";
        String SETMONEYBYID_ERROR04 = "执行对应账户资金修改过程中出错。";
        String SETMONEYBYID_ERROR05 = "在录入用户的交易记录中出错了。";
        String SETMONEYBYID_ERROR06 = "充值过程中出现错误，没有在资金明细中加入记录。";
        String SETMONEYBYID_ERROR07 = "已经执行过一次相同的资金变革，无法执行相同单号的任务";
        [WebMethod]
        public string RegularMembersUpdateMoney_S(string creatTime, string money, string id, string type, string md5, string logID, string name)
        {
            ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
            DataTable NODate = new DataTable();
            try
            {
                NODate = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectnoByMemLoginID(id);
            }
            catch (Exception ex)
            {

                throw (ex);
            }

            string NO = "";
            if (NODate.Rows.Count > 0)
            {
                NO = NODate.Rows[0]["MemLoginID"].ToString();
            }
            else
            {
                return "转账失败," + logID + "," + SETMONEYBYID_ERROR01 + id;
            }

            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "creatTime=" + creatTime + "&money=" + money + "&id=" + NO + "&type=" + type + "&logID=" + logID + "&name=" + name + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            var shopNum1_AdvancePaymentModifyLog_Action =
                        (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {

                DataTable moneyAndDv = new DataTable();

                try
                {
                    moneyAndDv = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectMemberByMemLoginIDAndName(NO,name);
                }
                catch (Exception ex)
                {

                    throw (ex);

                }
                if (moneyAndDv.Rows.Count > 0)
                {
                    DataTable table2 = shopNum1_AdvancePaymentModifyLog_Action.GetAdvancePaymentModifyLog_two(logID);
                    string Mytype = string.Empty;
                    try
                    {


                        if (type.ToUpper() == "DV")
                        {

                            Mytype = "Score_dv";
                            advance.HuoDe_dv = Convert.ToDecimal(money);
                            advance.HuoDe_Hou_dv = Convert.ToDecimal(moneyAndDv.Rows[0]["Score_dv"]) + Convert.ToDecimal(money);
                            advance.HuoDe_YuanYou_dv = Convert.ToDecimal(moneyAndDv.Rows[0]["Score_dv"]);


                        }
                        else if (type.ToUpper() == "BV")
                        {
                            Mytype = "AdvancePayment";
                            advance.CurrentAdvancePayment = Convert.ToDecimal(moneyAndDv.Rows[0]["AdvancePayment"]);
                            advance.OperateMoney = Convert.ToDecimal(money);
                            advance.LastOperateMoney = Convert.ToDecimal(moneyAndDv.Rows[0]["AdvancePayment"]) + Convert.ToDecimal(money);

                        }
                        else
                        {
                            return SETMONEYBYID_ERROR03;
                        }
                        if (table2 != null && table2.Rows.Count > 0)
                        {
                            return "转账失败," + logID + "," + SETMONEYBYID_ERROR07 + id;
                        }
                        else
                        {
                            try
                            {
                                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateMoneyByDateTimeAndID(Convert.ToDecimal(money), NO, Mytype);

                                advance.Guid = Guid.NewGuid();
                                advance.IsDeleted = 0;
                                advance.OperateType = 1;
                                advance.Date = Convert.ToDateTime(HttpUtility.UrlDecode(creatTime));
                                advance.Memo = "A网转账" + logID;
                                advance.MemLoginID = NO;
                                advance.CreateUser = NO;
                                advance.CreateTime = Convert.ToDateTime(HttpUtility.UrlDecode(creatTime));
                                advance.LogID = logID;
                                advance.OrderNumber = "";
                            }
                            catch (Exception ex)
                            {

                                throw (ex);
                            }


                            try
                            {
                                if (table2 != null && table2.Rows.Count > 0)
                                {
                                    return "转账失败," + logID + "," + SETMONEYBYID_ERROR07 + id;
                                }
                                else
                                {
                                    shopNum1_AdvancePaymentModifyLog_Action.OperateMoneyRV_two(advance, Mytype);
                                }


                            }
                            catch
                            {
                                return "转账失败," + logID + "," + SETMONEYBYID_ERROR05 + id;

                            }
                            DataTable table3 = shopNum1_AdvancePaymentModifyLog_Action.GetAdvancePaymentModifyLog_two(logID);
                            if (table3 != null && table3.Rows.Count > 0)
                            {
                                return "转账成功," + logID + "," + "成功" + id;
                            }
                            else
                            {
                                return "转账失败," + logID + "," + SETMONEYBYID_ERROR06 + id;
                            }
                        }


                    }
                    catch
                    {

                        return "转账失败," + logID + "," + SETMONEYBYID_ERROR04 + id;
                    }










                }
                else
                {
                    return SETMONEYBYID_ERROR01;
                }

            }
            else
            {
                return SETMONEYBYID_ERROR02;
            }



        }
    }
}

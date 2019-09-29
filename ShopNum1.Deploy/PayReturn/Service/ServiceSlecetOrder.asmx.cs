using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ShopNum1MultiEntity;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Text;
using ShopNum1.Common.ShopNum1.Common;
using System.Configuration;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// ServiceSlecetOrder 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri1.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ServiceSlecetOrder : System.Web.Services.WebService
    {
        String SELECETORDERBYTIME_ERROR01 = "MD5对比错误";
        String SELECETORDERBYTIME_ERROR02 = "查询出记录中没有任何记录，记录数量为0";
        String SELECETORDERBYTIME_ERROR03 = "查询出的数据转化成JSON字符串时出错了";
        String SELECETORDERBYTIME_ERROR04 = "操作成功";
        String SELECETORDERBYTIME_ERROR05 = "在修改数据库时出错。";
        String SELECETORDERBYTIME_ERROR06 = "输入的rnkguid数字不对";
        String SELECETORDERBYTIME_ERROR08 = "执行修改语句时错误";
        String SELECETORDERBYTIME_ERROR09 = "用户编号不存在";

        [WebMethod]
        public string SelecetOrderByTime(string startTime, string orderTime,string cargthid, string md5)
        {
           // string privateKey = "StartTime=" + startTime + "&OrderTime=" + orderTime +"&Cargth"+cargthid+ "&MD5=" + md5 + "";
            // string str2 = CreatTime + "&" + money + "&" + ID + "&" + Type + "&" + md5;

          //  string md5Check = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey);
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "StartTime=" + startTime + "&OrderTime=" + orderTime + "&Cargth" + cargthid  + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
                DataTable moneyAndDv = new DataTable();
                if (cargthid=="")
                {
                    moneyAndDv = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderByTime(Convert.ToDateTime(startTime), Convert.ToDateTime(orderTime));
                }
                else
                {
                    int id = Convert.ToInt32(cargthid);
                    moneyAndDv = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderByTimeAndcarghid(Convert.ToDateTime(startTime),Convert.ToDateTime(orderTime), id);
                }


                if (moneyAndDv.Rows.Count == 0)
                {
                    return SELECETORDERBYTIME_ERROR02;
                }
                else
                {
                    try
                    {
                        
                       return ServiceHelper.M_json(moneyAndDv);
                    }
                    catch 
                    {
                        return SELECETORDERBYTIME_ERROR03;
                       
                    }
                  
                }
               


                
            }
            else
            {
                return SELECETORDERBYTIME_ERROR01;
            }

        }

        [WebMethod]
        public string SelecetGoodsByCargthID(int startNum, int overNum, string cate_id, string md5)
        {
           // string privateKey = "StartNum=" + startNum + "&OrderNum=" + overNum + "&Cargth" + cate_id + "&MD5=" + md5 + "";
            // string str2 = CreatTime + "&" + money + "&" + ID + "&" + Type + "&" + md5;

           // string md5Check = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey);
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "StartNum=" + startNum + "&OrderNum=" + overNum + "&Cargth" + cate_id  + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
                DataTable selectGoods = new DataTable();
                
                    int id = Convert.ToInt32(cate_id);
                    selectGoods = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectGoodsByNum(startNum, overNum, id);



                    if (selectGoods.Rows.Count == 0)
                {
                    return SELECETORDERBYTIME_ERROR01;
                }
                else
                {
                    try
                    {
                       
                         return ServiceHelper.M_json(selectGoods);
                     
                    }
                    catch 
                    {

                        return SELECETORDERBYTIME_ERROR03;
                    }
                    
                }




            }
            else
            {
                return SELECETORDERBYTIME_ERROR02;
            }

        }

        [WebMethod]
        public string SelectImg(int Goos_id, string md5)
        {
           // string privateKey = "Good_ID=" + Goos_id + "&MD5" + md5 + "";
            // string str2 = CreatTime + "&" + money + "&" + ID + "&" + Type + "&" + md5;

          //  string md5Check = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey);
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Good_ID=" + Goos_id  + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
                DataTable selectImg = new DataTable();


                selectImg = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelecetImgByGoods_id(Goos_id);



                if (selectImg.Rows.Count == 0)
                {
                    return SELECETORDERBYTIME_ERROR02;
                }
                else
                {
                    try
                    {
                        
                        return ServiceHelper.M_json(selectImg);
                    }
                    catch 
                    {

                        return SELECETORDERBYTIME_ERROR03;
                    }
                    
                }




            }
            else
            {
                return SELECETORDERBYTIME_ERROR01;
            }

        }

        [WebMethod]
        public string SelcetOrderById(int goosID, string cate_id, string md5)
        {
          //  string privateKey = "Good_ID=" + goosID + "&Cate_id=" + cate_id + "&MD5" + md5 + "";
            // string str2 = CreatTime + "&" + money + "&" + ID + "&" + Type + "&" + md5;

           // string md5Check = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey);
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Good_ID=" + goosID + "&Cate_id=" + cate_id  + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
                DataTable selectImg = new DataTable();

                int id= Convert.ToInt32(cate_id);
                selectImg = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectAllByGoods_id(goosID,id);



                if (selectImg.Rows.Count == 0)
                {
                    return SELECETORDERBYTIME_ERROR02;
                }
                else
                {
                    try
                    {
                        

                    return ServiceHelper.M_json(selectImg);
                    }
                    catch 
                    {
                        
                        return SELECETORDERBYTIME_ERROR03;
                    }
                    
                }




            }
            else
            {
                return SELECETORDERBYTIME_ERROR01;
            }

        }
        [WebMethod]
        public string UpdateMenberRank(string rnkGuid,string menberId, string md5)
        {
            // string privateKey = "Good_ID=" + Goos_id + "&MD5" + md5 + "";
            // string str2 = CreatTime + "&" + money + "&" + ID + "&" + Type + "&" + md5;

            //  string md5Check = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey);
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "RnkGuid=" + rnkGuid + "&MenberId=" + menberId + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
                string myRnkaGuid = "";
                if (rnkGuid == "4")
                {
                    myRnkaGuid = MemberLevel.NORMAL_Shopkeeper;
                }
                if (rnkGuid == "2")
                {
                    myRnkaGuid = MemberLevel.VIP_MEMBER_ID;
                }
                if (rnkGuid == "3")
                {
                    myRnkaGuid = MemberLevel.VIP_MEMBER_ID_two;
                }
                if (rnkGuid == "1")
                {
                    myRnkaGuid = MemberLevel.NORMAL_MEMBER_ID;
                }
               
                try
                {
                    if (myRnkaGuid != "")
                    {
                        DataTable memberloginID_my = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).selectGETMemberloginID_MemberloingNO(menberId);
                        DateTime t = System.DateTime.Now;
                        if (rnkGuid == "4")
                        {
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateRetailersState(menberId);
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).InsertLogUpdateTime_two(memberloginID_my.Rows[0]["MemLoginID"].ToString(), t, memberloginID_my.Rows[0]["MemberRankGuid"].ToString(), myRnkaGuid);
                        }
                        else
                        {
                            try
                            {
                                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateMemberRankGuidGZ(menberId, myRnkaGuid);
                                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).InsertLogUpdateTime_two(memberloginID_my.Rows[0]["MemLoginID"].ToString(), t, memberloginID_my.Rows[0]["MemberRankGuid"].ToString(), myRnkaGuid);
                            }
                            catch (Exception ex)
                            {
                                
                                throw ex;
                            }
                         
                            if (rnkGuid == "3")
                            {

                                try
                                {

                                   
                            
                                  
                                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).InsertLogUpdateTime(memberloginID_my.Rows[0]["MemLoginID"].ToString(), t);
                                }
                                catch (Exception ex)
                                {
                                    
                                    throw ex;
                                }
                            }
                        }
                       
                        return SELECETORDERBYTIME_ERROR04;

                    }
                    else
                    {
                        return SELECETORDERBYTIME_ERROR06;
                    }



                }
                catch
                {

                    return SELECETORDERBYTIME_ERROR05;
                }







            }
            else
            {
                return SELECETORDERBYTIME_ERROR01;
            }
            
        }
        [WebMethod]
        public string UpdateMemberSuperior(string cmember, string memLoginID, string md5)
        {
            // string privateKey = "StartNum=" + startNum + "&OrderNum=" + overNum + "&Cargth" + cate_id + "&MD5=" + md5 + "";
            // string str2 = CreatTime + "&" + money + "&" + ID + "&" + Type + "&" + md5;

            // string md5Check = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey);
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "cmember=" + cmember + "&memLoginID=" + memLoginID + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();

                DataTable NODate = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectnoByMemLoginID(memLoginID);
                string NO = NODate.Rows[0]["MemLoginID"].ToString();

                int selectGoods = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateMemberSuperior(NO, cmember);



             if (selectGoods == 0)
                {
                    return SELECETORDERBYTIME_ERROR08;
                }
                else
                {

                    return SELECETORDERBYTIME_ERROR04;
                }




            }
            else
            {
                return SELECETORDERBYTIME_ERROR01;
            }

        }

        [WebMethod]
        public string UpdateMemberIdentityCard(string memLoginNO, string IdentityCard, string md5)
        {
            
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memLoginNO=" + memLoginNO + "&IdentityCard=" + IdentityCard + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
                  int selectGoods = 0;
                try
                {
                    selectGoods = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateMemberIdentityCard(memLoginNO, IdentityCard);
                }
                catch (Exception)
                {
                  return SELECETORDERBYTIME_ERROR08;
                }
                
                 if (selectGoods == 0)
                {
                    return SELECETORDERBYTIME_ERROR09;
                }
                else
                {

                    return SELECETORDERBYTIME_ERROR04;
                }




            }
            else
            {
                return SELECETORDERBYTIME_ERROR01;
            }

        }

        [WebMethod]
        public string UpdateMemberName(string name, string memLoginNO, string md5)
        {

            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "name=" + name + "&memLoginNO=" + memLoginNO + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                ShopNum1_AdvancePaymentModifyLog advance = new ShopNum1_AdvancePaymentModifyLog();
                int selectGoods = 0;
                try
                {
                    selectGoods = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateMemberRealName(memLoginNO, name);
                }
                catch (Exception)
                {
                    return SELECETORDERBYTIME_ERROR08;
                }

                if (selectGoods == 0)
                {
                    return SELECETORDERBYTIME_ERROR09;
                }
                else
                {

                    return SELECETORDERBYTIME_ERROR04;
                }




            }
            else
            {
                return SELECETORDERBYTIME_ERROR01;
            }

        }

        [WebMethod]
        public string Select_Q_S_MemloginID(string startTime, string orderTime, string md5)
        {

            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "startTime=" + startTime + "&orderTime=" + orderTime + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                
                DataTable table1=new DataTable();
                try
                {
                     table1= ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectAllMemberShip();
                    DataTable table2 = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectUpdateRecordCommunity(startTime, orderTime);

                    //table1.Columns.Add("UpdateName",typeof(string));
                    //table1.Columns.Add("DataTime", typeof(DateTime));
                    //table1.Columns.Add("IsUpdate", typeof(int));
                    //for (int i = 0; i < table1.Rows.Count; i++)
                    //{
                    //    foreach (DataRow tempRow2 in table2.Rows)
                    //    {
                    //        if (Convert.ToString(table1.Rows[i]["MemLoginNO"]) == Convert.ToString(tempRow2["MemLoginNO"]))   //要转成int型的去比较才行哟
                    //        {
                    //            table1.Rows[i]["UpdateName"] = tempRow2["UpdateName"];
                    //            table1.Rows[i]["DataTime"] = tempRow2["DataTime"];
                    //            table1.Rows[i]["IsUpdate"] = tempRow2["IsUpdate"];
                    //            break;
                    //        }
                    //    }
                    //}
                    for (int i = 0; i < table2.Rows.Count; i++)
                    {
                         table1.ImportRow(table2.Rows[i]);
                    }
                   




                }
                catch (Exception)
                {
                    return SELECETORDERBYTIME_ERROR08;
                }

                if (table1.Rows.Count == 0)
                {
                    return SELECETORDERBYTIME_ERROR02;
                  
                }
                else
                {
                    StringBuilder builder = new StringBuilder(ServiceHelper.ConvertDataTableToXML(table1));
                    builder.Replace("</Table>", "</Member>");
                    builder.Replace("<Table>", "<Member>");

                    builder.Replace("</NewDataSet>", "</Members>");
                    builder.Replace("<NewDataSet>", "<Members>");

                    builder.Replace("<string xmlns=\"http://tempuri1.org/\">", "<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    builder.Replace("</string>", "</xml>");

                    
                    return builder.ToString();
                }




            }
            else
            {
                return SELECETORDERBYTIME_ERROR01;
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_OrderInfo_Action : IShopNum1_OrderInfo_Action
    {
        public DataTable GetRecoCode_MJCStr(string strID, bool isadmin = false)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            string strSql = string.Empty;
            strSql = " select RecoCode from ShopNum1_Member where MemLoginID = @strID";


            if (!isadmin)
            {
                strSql += " and ( MemLoginID not in(SELECT BLID from WHJ_BlackList))";
            }

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable Search_MJCStr(string sql, bool isadmin = false)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@sql";
            parms[0].Value = sql;
            string strSql = string.Empty;
            strSql = "select MemLoginID from ShopNum1_Member where MemLoginID = @sql ";

            if (!isadmin)
            {
                strSql += " and ( MemLoginID not in(SELECT BLID from WHJ_BlackList))";
            }

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable Search_MJC_twoStr(string MemLoginID,bool isadmin=false)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            string strSql = string.Empty;

            strSql = "select MemLoginID from ShopNum1_Member where (MemLoginID = @MemLoginID or Name=@MemLoginID) ";
            if (!isadmin) {
                strSql += " and ( MemLoginID not in(SELECT BLID from WHJ_BlackList))";
            }

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        /// <summary>
        /// 查询购买的基金的订单
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="MemLoginID"></param>
        /// <param name="StartPage"></param>
        /// <param name="EndPage"></param>
        /// <returns></returns>
        public DataTable SelectJJOrderInfo(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                            DatabaseExcetue.ReturnDataTable("select OrderNumber,b.ProductName,OderStatus,ShouldPayPrice,a.CalculationTime,a.CalculationEndTime,(SuanLiDaySum-SuanLiDayAdd) as Day,Profit,SuanLiDaySum as DaySum  from ShopNum1_OrderInfo as a left join ShopNum1_OrderProduct as b on b.OrderInfoGuid=a.Guid left join Nec_LiCaiJiJin as c on C.ProductId=b.ProductGuid where a.shop_category_id=4  and a.MemLoginID=@MemLoginID order by a.CreateTime desc", parms);
        }


        public DataTable SelectJJOrderInfoFromEn(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                            DatabaseExcetue.ReturnDataTable("select OrderNumber,b.ProductName_EN,OderStatus,ShouldPayPrice,a.CalculationTime,a.CalculationEndTime,(SuanLiDaySum-SuanLiDayAdd) as Day,Profit,SuanLiDaySum as DaySum  from ShopNum1_OrderInfo as a left join ShopNum1_OrderProduct as b on b.OrderInfoGuid=a.Guid left join Nec_LiCaiJiJin as c on C.ProductId=b.ProductGuid where a.shop_category_id=4  and a.MemLoginID=@MemLoginID order by a.CreateTime desc", parms);
        }


        /// <summary>
        /// 根据状态查询租赁的订单
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="MemLoginID"></param>
        /// <param name="StartPage"></param>
        /// <param name="EndPage"></param>
        /// <returns></returns>
        public DataTable SelectZlOrderInfoByStatus(string MemLoginID,string Status)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Status";
            parms[1].Value = Status;

            return
                            DatabaseExcetue.ReturnDataTable("select OrderNumber,ShouldPayPrice as NEC,SuanLiGet,PayTime,BuyNumber,(SuanLiDaySum-SuanLiDayAdd) as Day,SuanLiDaySum,ProductImg,ProductName from ShopNum1_OrderInfo as a left join ShopNum1_OrderProduct as b on b.OrderInfoGuid=a.Guid where OderStatus in (@Status) and a.shop_category_id=3  and a.MemLoginID=@MemLoginID", parms);
        }
        /// <summary>
        /// 查询租赁进行中的订单
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="MemLoginID"></param>
        /// <param name="StartPage"></param>
        /// <param name="EndPage"></param>
        /// <returns></returns>
        public DataTable SelectZlOrderInfo(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                            DatabaseExcetue.ReturnDataTable("select OrderNumber,SuanLiGet,PayTime,BuyNumber,(SuanLiDaySum-SuanLiDayAdd) as Day,ProductImg,ProductName from ShopNum1_OrderInfo as a left join ShopNum1_OrderProduct as b on b.OrderInfoGuid=a.Guid where OderStatus=1 and a.shop_category_id=3  and a.MemLoginID=@MemLoginID", parms);
        }

        //NEC 租赁支付方法
        public int NEC_PayOrderInfo(string OrderNumber, string MemLoginID, DateTime PayTime, decimal NEC, decimal myNEC)
        {
            string item = string.Empty;
            var sqlList = new List<string>();

            item =
                string.Concat(new object[]
                {
                    "IF  EXISTS (select * from ShopNum1_OrderInfo where OderStatus=0 and  (OrderNumber='",OrderNumber,"' or TradeID='",OrderNumber,"')) UPDATE  ShopNum1_OrderInfo SET OderStatus=1 , PayTime='",PayTime,"',ServiceAgent='",MemLoginID,"' WHERE MemLoginID='",MemLoginID,"' and (OrderNumber='",OrderNumber,"' or TradeID='",OrderNumber,"')"
                });
            sqlList.Add(item);




            item =
            string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_dv =Score_dv-", NEC,",Score_pv_a=Score_pv_a+",NEC," WHERE  MemLoginID ='",MemLoginID, "'"
                });
            sqlList.Add(item);


            item =
            string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_dv],[HuoDe_dv],[Huo_DeHou_sdv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myNEC,",",NEC,",",myNEC-NEC,",getdate(),'算力置换','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
            sqlList.Add(item);









            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //KCE 支付方法
        public int KCE_PayOrderInfo(string OrderNumber, string MemLoginID, string ShopID, DateTime PayTime, string TypeID, decimal Kb, decimal CNY, decimal myCNY, decimal myKb, decimal myEdu, decimal shopCNY, decimal shopKb, decimal shopEdu)
        {
            string item = string.Empty;
            var sqlList = new List<string>();

            item =
                string.Concat(new object[]
                {
                    "IF  EXISTS (select * from ShopNum1_OrderInfoTwo where OderStatus=1 and  (OrderNumber='",OrderNumber,"' or TradeID='",OrderNumber,"')) UPDATE  ShopNum1_OrderInfoTwo SET OderStatus=2 , PayTime='",PayTime,"',ServiceAgent='",MemLoginID,"' WHERE MemLoginID='",ShopID,"' and (OrderNumber='",OrderNumber,"' or TradeID='",OrderNumber,"')"
                });
            sqlList.Add(item);



            if (TypeID == "1")
            {
                //修改新的购买 消耗100%K宝  得到85%kt
                decimal newCNY = CNY * Convert.ToDecimal(0.85);

                item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_hv =Score_hv-", Kb,
                    ",AdvancePayment=AdvancePayment+",newCNY,",Score_pv_b=Score_pv_b-",Kb," WHERE  MemLoginID ='",MemLoginID, "'"
                });
                sqlList.Add(item);

                #region 买家扣除额度记录
                item =
               string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[XiaoFei_YuanYou_pv_b],[XiaoFei_pv_b],[XiaoFei_Hou_pv_b],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myEdu,",",Kb,",",Kb+myEdu,",getdate(),'扣除','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);

                #endregion
                #region 买家扣除K宝记录
                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[XiaoFei_YuanYou_hv],[XiaoFei_hv],[XiaoFei_Hou_hv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myKb,",",Kb,",",myKb-Kb,",getdate(),'扣取','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);
                #endregion
                #region 买家增加KT记录
                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[CurrentAdvancePayment],[OperateMoney],[LastOperateMoney],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myCNY,",",newCNY,",",newCNY+myCNY,",getdate(),'获得','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);
                #endregion


                item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_hv =Score_hv+", Kb,
                    ",Score_pv_b=Score_pv_b+",CNY*2," WHERE  MemLoginID ='",ShopID, "'"
                });
                sqlList.Add(item);
                #region 卖家增加额度记录
                item =
               string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_pv_b],[HuoDe_pv_b],[Huo_DeHou_pv_b],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",shopEdu,",",CNY*2,",",CNY*2+shopEdu,",getdate(),'获得','",ShopID,"','",ShopID,"',getdate(),0)"
                });
                sqlList.Add(item);

                #endregion
                #region 卖家增加K宝记录
                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_hv],HuoDe_hv,[Huo_DeHou_hv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",shopKb,",",Kb,",",Kb+shopKb,",getdate(),'获得','",ShopID,"','",ShopID,"',getdate(),0)"
                });
                sqlList.Add(item);
                #endregion

            }
            if (TypeID == "2")
            {
                item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_hv =Score_hv+", Kb,
                    ",AdvancePayment=AdvancePayment-",CNY,",Score_pv_b=Score_pv_b+",CNY*2," WHERE  MemLoginID ='",MemLoginID, "'"
                });
                sqlList.Add(item);
                #region 买家增加额度记录
                item =
               string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_pv_b],[HuoDe_pv_b],[Huo_DeHou_pv_b],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myEdu,",",CNY*2,",",CNY*2+myEdu,",getdate(),'获得','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);

                #endregion
                #region 买家增加K宝记录
                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_hv],HuoDe_hv,[Huo_DeHou_hv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myKb,",",Kb,",",Kb+myKb,",getdate(),'获得','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);
                #endregion
                #region 买家扣除KT记录
                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[CurrentAdvancePayment],[OperateMoney],[LastOperateMoney],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myCNY,",",CNY,",",myCNY-CNY,",getdate(),'扣取','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);
                #endregion
                //卖家卖K宝 获得85%kt
                decimal newVNY = CNY * Convert.ToDecimal(0.85);
                item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  AdvancePayment =AdvancePayment+", newVNY,
                    " WHERE  MemLoginID ='",ShopID, "'"
                });
                sqlList.Add(item);

                #region 卖家增加KT记录
                item =
                    string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[CurrentAdvancePayment],[OperateMoney],[LastOperateMoney],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",shopCNY,",",newVNY,",",newVNY+shopCNY,",getdate(),'获得','",ShopID,"','",ShopID,"',getdate(),0)"
                });
                sqlList.Add(item);
                #endregion
            }


            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //KCE 支付方法

        public int KCE_PayOrderInfo(string OrderNumber, string MemLoginID, string ShopID, DateTime PayTime, string TypeID, decimal NEC, decimal USDT, decimal myUSDT, decimal myNEC, decimal shopUSDT, decimal shopNEC)
        {
            string item = string.Empty;
            var sqlList = new List<string>();

            item =
                string.Concat(new object[]
                {
                    "IF  EXISTS (select * from ShopNum1_OrderInfoTwo where OderStatus=1 and  (OrderNumber='",OrderNumber,"' or TradeID='",OrderNumber,"')) UPDATE  ShopNum1_OrderInfoTwo SET OderStatus=2 , PayTime='",PayTime,"',ServiceAgent='",MemLoginID,"' WHERE MemLoginID='",ShopID,"' and (OrderNumber='",OrderNumber,"' or TradeID='",OrderNumber,"')"
                });
            sqlList.Add(item);



            if (TypeID == "1")
            {
                item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_dv =Score_dv-", NEC,
                    ",AdvancePayment=AdvancePayment+",USDT," WHERE  MemLoginID ='",MemLoginID, "'"
                });
                sqlList.Add(item);


                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_dv],[HuoDe_dv],[Huo_DeHou_sdv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myNEC,",",NEC,",",myNEC-NEC,",getdate(),'买入扣除','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);
                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[CurrentAdvancePayment],[OperateMoney],[LastOperateMoney],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myUSDT,",",USDT,",",USDT+myUSDT,",getdate(),'买入获得','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);



                item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_dv =Score_dv+", NEC,
                    " WHERE  MemLoginID ='",ShopID, "'"
                });
                sqlList.Add(item);

                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[DeDao_Qian_dv],[DeDao_dv],[DeDao_Hou_dv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",shopNEC,",",NEC,",",NEC+shopNEC,",getdate(),'卖出获得','",ShopID,"','",ShopID,"',getdate(),0)"
                });
                sqlList.Add(item);


            }
            if (TypeID == "2")
            {
                item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_dv =Score_dv+", NEC,
                    ",AdvancePayment=AdvancePayment-",USDT," WHERE  MemLoginID ='",MemLoginID, "'"
                });
                sqlList.Add(item);

                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[DeDao_Qian_dv],[DeDao_dv],[DeDao_Hou_dv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myNEC,",",NEC,",",NEC+myNEC,",getdate(),'买入获得','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);

                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[CurrentAdvancePayment],[OperateMoney],[LastOperateMoney],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myUSDT,",",USDT,",",myUSDT-USDT,",getdate(),'买入扣除','",MemLoginID,"','",MemLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);


                item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  AdvancePayment =AdvancePayment+", USDT,
                    " WHERE  MemLoginID ='",ShopID, "'"
                });
                sqlList.Add(item);


                item =
                    string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[CurrentAdvancePayment],[OperateMoney],[LastOperateMoney],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",shopUSDT,",",USDT,",",USDT+shopUSDT,",getdate(),'卖出获得','",ShopID,"','",ShopID,"',getdate(),0)"
                });
                sqlList.Add(item);

            }


            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public DataTable MJC_Search(string orderNumber, string memLoginID, string name, string address, string postalcode,
    string string_0, string mobile, string email, decimal shouldPayPrice1,
    decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted,
    string shopID, string shopName, string orderStatus, string orderType)
        {
            string str = string.Empty;
            str =
                "SELECT distinct ordernumber,c.MemLoginID ,d.mobile,c.CreateTime,PayTime,ShouldpayPrice,ServiceAgent,OderStatus FROM ShopNum1_OrderInfoTwo as c  left join ShopNum1_Member as d on c.MemLoginID=d.MemLoginID  WHERE 0=0  ";
            if (Operator.FormatToEmpty(orderNumber) != string.Empty)
            {
                str = str + " AND A.OrderNumber LIKE '%" + Operator.FilterString(orderNumber) + "%'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND A.Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if (Operator.FormatToEmpty(address) != string.Empty)
            {
                str = str + " AND A.Address LIKE '%" + Operator.FilterString(address) + "%'";
            }
            if (Operator.FormatToEmpty(postalcode) != string.Empty)
            {
                str = str + "AND A.Postalcode LIKE '%" + Operator.FilterString(postalcode) + "%'";
            }
            if (Operator.FormatToEmpty(string_0) != string.Empty)
            {
                str = str + " AND A.Tel LIKE '%" + Operator.FilterString(string_0) + "%'";
            }
            if (Operator.FormatToEmpty(mobile) != string.Empty)
            {
                str = str + " AND A.Mobile LIKE '%" + Operator.FilterString(mobile) + "%'";
            }
            if (Operator.FormatToEmpty(email) != string.Empty)
            {
                str = str + " AND A.Email LIKE '%" + Operator.FilterString(email) + "%'";
            }
            if (orderType != "-1")
            {
                str = str + " AND A.OrderType=" + orderType + " ";
            }
            if (orderStatus != "-1")
            {
                str = str + " AND A.OderStatus=" + orderStatus;
            }
            if (Operator.FormatToEmpty(createTime1) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(createTime1) + "' ";
            }
            if (Operator.FormatToEmpty(createTime2) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(createTime2) + "' ";
            }
            if (shouldPayPrice1 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.ShouldPayPrice>='", shouldPayPrice1, "' " });
            }
            if (shouldPayPrice2 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.ShouldPayPrice<='", shouldPayPrice2, "' " });
            }
            if (Operator.FormatToEmpty(shopID) != string.Empty)
            {
                str = str + " AND A.ShopID  Like'" + Operator.FilterString(shopID) + "' ";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                str = str + " AND A.ShopName  Like'" + Operator.FilterString(shopName) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY A.CreateTime DESC");
        }



        public DataTable NEC_Search(string orderNumber, string memLoginID, string name, string address, string postalcode,
    string string_0, string mobile, string email, decimal shouldPayPrice1,
    decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted,
    string shopID, string shopName, string orderStatus, string orderType)
        {
            string str = string.Empty;
            str =
                "SELECT distinct ordernumber,c.MemLoginID ,d.mobile,c.CreateTime,PayTime,ShouldpayPrice,ServiceAgent,OderStatus FROM ShopNum1_OrderInfo as c  left join ShopNum1_Member as d on c.MemLoginID=d.MemLoginID  WHERE 0=0  ";
            if (Operator.FormatToEmpty(orderNumber) != string.Empty)
            {
                str = str + " AND A.OrderNumber LIKE '%" + Operator.FilterString(orderNumber) + "%'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND A.Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if (Operator.FormatToEmpty(address) != string.Empty)
            {
                str = str + " AND A.Address LIKE '%" + Operator.FilterString(address) + "%'";
            }
            if (Operator.FormatToEmpty(postalcode) != string.Empty)
            {
                str = str + "AND A.Postalcode LIKE '%" + Operator.FilterString(postalcode) + "%'";
            }
            if (Operator.FormatToEmpty(string_0) != string.Empty)
            {
                str = str + " AND A.Tel LIKE '%" + Operator.FilterString(string_0) + "%'";
            }
            if (Operator.FormatToEmpty(mobile) != string.Empty)
            {
                str = str + " AND A.Mobile LIKE '%" + Operator.FilterString(mobile) + "%'";
            }
            if (Operator.FormatToEmpty(email) != string.Empty)
            {
                str = str + " AND A.Email LIKE '%" + Operator.FilterString(email) + "%'";
            }
            if (orderType != "-1")
            {
                str = str + " AND A.OrderType=" + orderType + " ";
            }
            if (orderStatus != "-1")
            {
                str = str + " AND A.OderStatus=" + orderStatus;
            }
            if (Operator.FormatToEmpty(createTime1) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(createTime1) + "' ";
            }
            if (Operator.FormatToEmpty(createTime2) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(createTime2) + "' ";
            }
            if (shouldPayPrice1 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.ShouldPayPrice>='", shouldPayPrice1, "' " });
            }
            if (shouldPayPrice2 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.ShouldPayPrice<='", shouldPayPrice2, "' " });
            }
            if (Operator.FormatToEmpty(shopID) != string.Empty)
            {
                str = str + " AND A.ShopID  Like'" + Operator.FilterString(shopID) + "' ";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                str = str + " AND A.ShopName  Like'" + Operator.FilterString(shopName) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY A.CreateTime DESC");
        }

        public DataTable MJC_SearchOrderInfoByOrdernum(string ordernum, string orderType, string strCondition)
        {
            string str = string.Empty;
            str =
                "  SELECT distinct ordernumber,c.MemLoginID as MemLoginID ,d.mobile as mobile,c.CreateTime as CreateTime,PayTime,ShouldpayPrice,ServiceAgent,OderStatus FROM ShopNum1_OrderInfoTwo as c  left join ShopNum1_Member as d on c.MemLoginID=d.MemLoginID  WHERE 0=0 ";
            if (ordernum != "-1")
            {
                str = str + " AND OrderNumber in (" + ordernum.Trim() + ") ";
            }
            if (orderType == "-2")
            {
                str = str + " AND feetype=2 ";
            }
            else if (orderType != "-1")
            {
                str = str + " AND OrderType =" + orderType + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + strCondition + " ORDER BY PayTime DESC");
        }

        public DataTable NEC_SearchOrderInfoByOrdernum(string ordernum, string orderType, string strCondition)
        {
            string str = string.Empty;
            str =
                "  SELECT distinct ordernumber,c.MemLoginID as MemLoginID ,d.mobile as mobile,c.CreateTime as CreateTime,PayTime,ShouldpayPrice,ServiceAgent,OderStatus FROM ShopNum1_OrderInfo as c  left join ShopNum1_Member as d on c.MemLoginID=d.MemLoginID  WHERE 0=0 ";
            if (ordernum != "-1")
            {
                str = str + " AND OrderNumber in (" + ordernum.Trim() + ") ";
            }
            if (orderType == "-2")
            {
                str = str + " AND feetype=2 ";
            }
            else if (orderType != "-1")
            {
                str = str + " AND OrderType =" + orderType + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + strCondition + " ORDER BY PayTime DESC");
        }

        /// <summary>
        /// 交易大厅查询买单
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="MemLoginID"></param>
        /// <param name="StartPage"></param>
        /// <param name="EndPage"></param>
        /// <returns></returns>
        //public DataTable SelectOrderNumberBuy(string MemLoginID, string Number, string StartPage, string EndPage, string code)
        //{
        //    DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

        //    parms[0].ParameterName = "@MemLoginID";
        //    parms[0].Value = MemLoginID;
        //    parms[1].ParameterName = "@StartPage";
        //    parms[1].Value = StartPage;
        //    parms[2].ParameterName = "@EndPage";
        //    parms[2].Value = EndPage;
        //    parms[3].ParameterName = "@Number";
        //    parms[3].Value = Number;


        //    return
        //        DatabaseExcetue.ReturnDataTable("select * from ( select b.Photo,b.Name,a.MemLoginID,OrderNumber,OderStatus,ShipmentStatus,ShouldPayPrice,a.CreateTime,ConfirmTime,PayTime,a.Score_pv_b,ServiceAgent , ROW_NUMBER()OVER( Order by a.CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfoTwo  as a left join ShopNum1_Member as b on b.MemLoginID=a.MemLoginID where   a.MemLoginID!=@MemLoginID and ShipmentStatus=1 and OderStatus=1 and ShouldPayPrice=@Number  and a.MemLoginID in(select  MemLoginID  from ShopNum1_Member  where RecoCode like '" + code + "%'))as a where RowNumber BETWEEN @StartPage and @EndPage", parms);
        //}
        public DataTable SelectOrderNumberBuy(string MemLoginID, string Number, string StartPage, string EndPage, string code)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@StartPage";
            parms[1].Value = StartPage;
            parms[2].ParameterName = "@EndPage";
            parms[2].Value = EndPage;
            parms[3].ParameterName = "@Number";
            parms[3].Value = Number;


            return
                DatabaseExcetue.ReturnDataTable("select * from ( select b.Photo,b.Name,a.MemLoginID,OrderNumber,OderStatus,ShipmentStatus,ShouldPayPrice,a.CreateTime,ConfirmTime,PayTime,a.Score_pv_b,ServiceAgent , ROW_NUMBER()OVER( Order by a.CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfoTwo  as a left join ShopNum1_Member as b on b.MemLoginID=a.MemLoginID where   a.MemLoginID!=@MemLoginID and ShipmentStatus=1 and OderStatus=1 and ShouldPayPrice=@Number  )as a where RowNumber BETWEEN @StartPage and @EndPage", parms);
        }


        /// <summary>
        /// 交易大厅查询卖单
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="MemLoginID"></param>
        /// <param name="StartPage"></param>
        /// <param name="EndPage"></param>
        /// <returns></returns>
        //public DataTable SelectOrderNumberSell(string MemLoginID, string Number, string StartPage, string EndPage, string code)
        //{
        //    DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

        //    parms[0].ParameterName = "@MemLoginID";
        //    parms[0].Value = MemLoginID;
        //    parms[1].ParameterName = "@StartPage";
        //    parms[1].Value = StartPage;
        //    parms[2].ParameterName = "@EndPage";
        //    parms[2].Value = EndPage;
        //    parms[3].ParameterName = "@Number";
        //    parms[3].Value = Number;


        //    return
        //        DatabaseExcetue.ReturnDataTable("select * from ( select b.Photo,b.Name,a.MemLoginID,OrderNumber,OderStatus,ShipmentStatus,ShouldPayPrice,a.CreateTime,ConfirmTime,PayTime,a.Score_pv_b,ServiceAgent , ROW_NUMBER()OVER( Order by a.CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfoTwo  as a left join ShopNum1_Member as b on b.MemLoginID=a.MemLoginID where   a.MemLoginID!=@MemLoginID and ShipmentStatus=2 and OderStatus=1 and ShouldPayPrice=@Number and a.MemLoginID in(select  MemLoginID  from ShopNum1_Member  where RecoCode like '" + code + "%'))as a where RowNumber BETWEEN @StartPage and @EndPage", parms);
        //}
        public DataTable SelectOrderNumberSell(string MemLoginID, string Number, string StartPage, string EndPage, string code)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@StartPage";
            parms[1].Value = StartPage;
            parms[2].ParameterName = "@EndPage";
            parms[2].Value = EndPage;
            parms[3].ParameterName = "@Number";
            parms[3].Value = Number;


            return
                DatabaseExcetue.ReturnDataTable("select * from ( select b.Photo,b.Name,a.MemLoginID,OrderNumber,OderStatus,ShipmentStatus,ShouldPayPrice,a.CreateTime,ConfirmTime,PayTime,a.Score_pv_b,ServiceAgent , ROW_NUMBER()OVER( Order by a.CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfoTwo  as a left join ShopNum1_Member as b on b.MemLoginID=a.MemLoginID where   a.MemLoginID!=@MemLoginID and ShipmentStatus=2 and OderStatus=1 and ShouldPayPrice=@Number )as a where RowNumber BETWEEN @StartPage and @EndPage", parms);
        }









        public int MobileRefund(string strOrderGuId, string MemlogInId, string strOrderState, string strShipState,
string strPayState, string strRefundState, string strIsShop, string oplGuid, string oplMemo, string oplMsg, string oplNextMsg, ShopNum1_Refund Refund)
        {
            var paraName = new string[17];
            var paraValue = new string[17];
            paraName[0] = "@OrderGuid";
            paraValue[0] = strOrderGuId;
            paraName[1] = "@MemLoginID";
            paraValue[1] = MemlogInId;
            paraName[2] = "@OrderState";
            paraValue[2] = strOrderState;
            paraName[3] = "@ShipState";
            paraValue[3] = strShipState;
            paraName[4] = "@PayState";
            paraValue[4] = strPayState;
            paraName[5] = "@RefundState";
            paraValue[5] = strRefundState;
            paraName[6] = "@IsShop";
            paraValue[6] = strIsShop;
            paraName[7] = "@OrderOperateLogGuid";
            paraValue[7] = oplGuid;
            paraName[8] = "@OrderOperateLogMemo";
            paraValue[8] = oplMemo;
            paraName[9] = "@OrderOperateLogCurrentStateMsg";
            paraValue[9] = oplMsg;
            paraName[10] = "@RefundID";
            paraValue[10] = Refund.RefundID;
            paraName[11] = "@RefundType";
            paraValue[11] = Refund.RefundType.ToString();
            paraName[12] = "@RefundMoney";
            paraValue[12] = Refund.RefundMoney.ToString();
            paraName[13] = "@RefundContent";
            paraValue[13] = Refund.RefundContent;
            paraName[14] = "@RefundReason";
            paraValue[14] = Refund.OnPassReason;
            paraName[15] = "@ShopID";
            paraValue[15] = Refund.ShopID;
            paraName[16] = "@OrderOperateLogNextStateMsg";
            paraValue[16] = oplNextMsg;

            return DatabaseExcetue.RunProcedure("[MobileRefund]", paraName, paraValue);
        }
        public DataTable SelectOrderOfAllRefund(string OrderNo)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNo";
            parms[0].Value = OrderNo;
            return
                DatabaseExcetue.ReturnDataTable("Select * from shopnum1_orderinfo where (OrderNumber=@OrderNo or TradeID=@OrderNo) and OderStatus in (1,2)", parms);
        }






        public DataTable Select_AllOrder15()
        {

            return DatabaseExcetue.ReturnDataTable("select OrderNumber from ShopNum1_OrderInfo where OderStatus=2 and refundStatus=0 and PaymentStatus=1 and DATEADD(day,-7,GETDATE())> DispatchTime and shopid <> 'C0000001' and OrderNumber like '2%'");
        }

        //付款成功修改状态

        public int UpdateOrderStateTJ(string ordernumber, string memLoginID, decimal shouldPay, DateTime paytime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@ordernumber";
            parms[0].Value = ordernumber;
            parms[1].ParameterName = "@memLoginID";
            parms[1].Value = memLoginID;
            parms[2].ParameterName = "@shouldPay";
            parms[2].Value = shouldPay;
            parms[3].ParameterName = "@paytime";
            parms[3].Value = paytime;

            return
                DatabaseExcetue.RunNonQuery("IF  EXISTS (select * from ShopNum1_OrderInfo where OderStatus=0 and  (OrderNumber=@ordernumber or TradeID=@ordernumber)) UPDATE  ShopNum1_OrderInfo SET OderStatus=1 , PaymentStatus=1, ShipmentStatus= 0,AlreadPayPrice=@shouldPay,PayTime=@paytime WHERE MemLoginID=@memLoginID and (OrderNumber=@ordernumber or TradeID=@ordernumber)", parms);
        }
        /// <summary>
        /// 查询物流信息
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public DataTable SelectOrderInfoWL(string OrderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;

            return DatabaseExcetue.ReturnDataTable("  SELECT LogisticsCompany,LogisticsCompanyCode,ShipmentNumber FROM [ShopNum1_OrderInfo] where [OrderNumber]=@Ordernumber", parms);

        }
        public int Push3Gorder(string ordernumber, string MemLoginNO, string CreateTime, string paytime, decimal ShouldPayPrice, decimal pv)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@ordernumber";
            paraValue[0] = ordernumber;
            paraName[1] = "@MemLoginNO";
            paraValue[1] = MemLoginNO;
            paraName[2] = "@CreateTime";
            paraValue[2] = CreateTime;
            paraName[3] = "@paytime";
            paraValue[3] = paytime;
            paraName[4] = "@ShouldPayPrice";
            paraValue[4] = ShouldPayPrice.ToString();
            paraName[5] = "@pv";
            paraValue[5] = pv.ToString();


            return DatabaseExcetue.RunProcedure("[47.52.115.221].[TJPS].[dbo].[pro_AddPVAShopnun1]", paraName, paraValue);
        }


        public int ReFund3Gorder(string ordernumber, string MemLoginNO, decimal pv)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@ordernumber";
            paraValue[0] = ordernumber;
            paraName[1] = "@MemLoginNO";
            paraValue[1] = MemLoginNO;
            paraName[2] = "@pv";
            paraValue[2] = pv.ToString();




            return DatabaseExcetue.RunProcedureGetInt("[47.52.115.221].[TJPS].[dbo].[pro_JianPVA]", paraName, paraValue);

        }

        public int NoReFund3Gorder(string ordernumber, string MemLoginNO, decimal pv)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@ordernumber";
            paraValue[0] = ordernumber;
            paraName[1] = "@MemLoginNO";
            paraValue[1] = MemLoginNO;
            paraName[2] = "@pv";
            paraValue[2] = pv.ToString();


            return DatabaseExcetue.RunProcedure("[47.52.115.221].[TJPS].[dbo].[pro_TuiKuanJuJueaDDPVA]", paraName, paraValue);
        }


        //付款成功修改状态

        //public int UpdateOrderStateTJ(string ordernumber, string memLoginID, decimal shouldPay,DateTime paytime)
        //{
        //    DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

        //    parms[0].ParameterName = "@ordernumber";
        //    parms[0].Value = ordernumber;
        //    parms[1].ParameterName = "@memLoginID";
        //    parms[1].Value = memLoginID;
        //    parms[2].ParameterName = "@shouldPay";
        //    parms[2].Value = shouldPay;
        //    parms[3].ParameterName = "@paytime";
        //    parms[3].Value = paytime;

        //    return
        //        DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_OrderInfo SET OderStatus=1 , PaymentStatus=1, ShipmentStatus= 0,AlreadPayPrice=@shouldPay,PayTime=@paytime WHERE MemLoginID=@memLoginID and (OrderNumber=@ordernumber or TradeID=@ordernumber)", parms);
        //}   


        //退款成功修改状态

        public int UpdateOrderState(string ordernumber, string OderStatus, string PaymentStatus, string refundStatus)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@ordernumber";
            parms[0].Value = ordernumber;
            parms[1].ParameterName = "@OderStatus";
            parms[1].Value = OderStatus;
            parms[2].ParameterName = "@PaymentStatus";
            parms[2].Value = PaymentStatus;
            parms[3].ParameterName = "@refundStatus";
            parms[3].Value = refundStatus;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_OrderInfo set OderStatus=@OderStatus,PaymentStatus=@PaymentStatus,refundStatus=@refundStatus where (OrderNumber=@ordernumber or TradeID=@ordernumber)", parms);
        }

        /// <summary>
        /// 推荐顾客订单
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="ShopName"></param>
        /// <returns></returns>
        public DataTable Select_ListOrder(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "a.* ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_OrderInfo as a left join ShopNum1_Member as b on b.MemLoginID=a.MemLoginID ";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "RegeDate";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int UpdatePTScore_pv_b(string TradeID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@TradeID";
            parms[0].Value = TradeID;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_OrderInfo set Score_pv_b=0 where TradeID=@TradeID", parms);
        }
        /// <summary>
        /// 修改使用掉的红包
        /// </summary>
        /// <param name="ordernumber"></param>
        /// <returns></returns>
        public int UpdateOrderSYhv(string ordernumber, decimal hv)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ordernumber";
            parms[0].Value = ordernumber;
            parms[1].ParameterName = "@hv";
            parms[1].Value = hv;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_OrderInfo set Deduction_hv=@hv where (OrderNumber=@ordernumber or TradeID=@ordernumber)", parms);
        }
        /// <summary>
        /// 修改区代首购价格
        /// </summary>
        /// <param name="ordernumber"></param>
        /// <returns></returns>
        public int UpdateOrderPriceQD(string ordernumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ordernumber";
            parms[0].Value = ordernumber;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_OrderInfo set ShouldPayPrice=48000 where (OrderNumber=@ordernumber or TradeID=@ordernumber)", parms);
        }
        /// <summary>
        /// 修改社区店首购价格
        /// </summary>
        /// <param name="ordernumber"></param>
        /// <returns></returns>
        public int UpdateOrderPriceSQ(string ordernumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ordernumber";
            parms[0].Value = ordernumber;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_OrderInfo set ShouldPayPrice=18000 where (OrderNumber=@ordernumber or TradeID=@ordernumber)", parms);
        }
        public int AddLiCai(ShopNum1_OrderInfo oderInfo, List<ShopNum1_OrderProduct> listOrderProduct,string startDay,string endDay,decimal myNEC,string EnglishName)
        {
            var sqlList = new List<string>();
            string str = "等待付款";

            if ((oderInfo.PaymentName.IndexOf("货到付款") == -1) || (oderInfo.PaymentName.IndexOf("线下支付") == -1))
            {
                if (oderInfo.FeeType == 666)
                {
                    str = "理财基金已付款";
                }
                else
                {
                    str = "等待付款";
                }
            }

            string item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_OrderOperateLog(Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,CurrentStateMsg,NextStateMsg,Memo,OperateDateTime,IsDeleted)VALUES('"
                , oderInfo.Guid, "','", oderInfo.Guid, "','", oderInfo.MemLoginID, "','", oderInfo.OderStatus, "','"
                , oderInfo.ShipmentStatus, "','", oderInfo.PaymentStatus, "','已经下单','", str, "','','",
                DateTime.Now.ToString(),
                "','0');"
            });

            sqlList.Add(item);


            string str1 =
            string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_dv =Score_dv-", oderInfo.ShouldPayPrice,",Score_pv_a=Score_pv_a+",oderInfo.ShouldPayPrice," WHERE  MemLoginID ='",oderInfo.MemLoginID, "'"
                });
            sqlList.Add(str1);


            string str4 =
            string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_dv],[HuoDe_dv],[Huo_DeHou_sdv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myNEC,",",oderInfo.ShouldPayPrice,",",myNEC-oderInfo.ShouldPayPrice,",getdate(),'购买理财基金','",oderInfo.MemLoginID,"','",oderInfo.MemLoginID,"',getdate(),0)"
                });
            sqlList.Add(str4);


            string str7 = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_OrderInfo( Guid,PayMentMemLoginID,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,ProductPv_b,DispatchPrice,DispatchType,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,ShopID,ReceivedDays,IsMemdelay,ShopName,FeeType,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,OrderType,RecommendCommision,IsMinus,IdentifyCode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,Score_cv,Score_max_hv,shop_category_id,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,ServiceAgent,Score_pv_cv,ProductLastPrice,SuperiorRank,SuanLiDaySum,SuanLiUnitPrice,PayTime,CalculationTime,CalculationEndTime) VALUES ( '"
                , oderInfo.Guid, "','", oderInfo.PayMentMemLoginID, "','", oderInfo.MemLoginID, "','",
                oderInfo.OrderNumber, "','", oderInfo.TradeID, "',", oderInfo.OderStatus, ",",
                oderInfo.ShipmentStatus, ",", oderInfo.PaymentStatus,
                ",'", Operator.FilterString(oderInfo.Name), "','", Operator.FilterString(oderInfo.Email), "','",
                Operator.FilterString(oderInfo.Address), "','", Operator.FilterString(oderInfo.Postalcode), "','",
                Operator.FilterString(oderInfo.Tel), "','", Operator.FilterString(oderInfo.Mobile), "','",
                Operator.FilterString(oderInfo.ClientToSellerMsg), "','",
                Operator.FilterString(oderInfo.SellerToClientMsg),
                "','", oderInfo.PaymentGuid, "','", Operator.FilterString(oderInfo.PaymentName), "','",
                Operator.FilterString(oderInfo.OutOfStockOperate), "','", oderInfo.PackGuid, "','",
                Operator.FilterString(oderInfo.PackName), "','", oderInfo.BlessCardGuid, "','",
                Operator.FilterString(oderInfo.BlessCardName), "','",
                Operator.FilterString(oderInfo.BlessCardContent),
                "','", Operator.FilterString(oderInfo.InvoiceTitle), "','",
                Operator.FilterString(oderInfo.InvoiceContent), "',", oderInfo.ProductPrice,",",oderInfo.ProductPv_b, ",",
                oderInfo.DispatchPrice, ",", oderInfo.DispatchType, ",", oderInfo.PaymentPrice, ",",
                oderInfo.PackPrice, ",", oderInfo.BlessCardPrice,
                ",", oderInfo.AlreadPayPrice, ",", oderInfo.SurplusPrice, ",", oderInfo.UseScore, ",",
                oderInfo.ScorePrice, ",", oderInfo.ShouldPayPrice, ",'", Operator.FilterString(oderInfo.FromAd),
                "','", Operator.FilterString(oderInfo.FromUrl), "','", Operator.FilterString(oderInfo.CreateTime),
                "','", oderInfo.ConfirmTime, "','", Operator.FilterString(oderInfo.ShipmentNumber), "','",
                Operator.FilterString(oderInfo.BuyType), "','", oderInfo.ActivityGuid, "','",
                Operator.FilterString(oderInfo.PayMemo), "','", Operator.FilterString(oderInfo.InvoiceType), "',",
                oderInfo.InvoiceTax, ",", oderInfo.Discount,
                ",", oderInfo.Deposit, ",'", oderInfo.ShopID, "', ", oderInfo.ReceivedDays, ", ",
                oderInfo.IsMemdelay, ",'", oderInfo.ShopName, "',", oderInfo.FeeType, ",'", oderInfo.RegionCode,
                "',", oderInfo.JoinActiveType,
                ",'", oderInfo.ActvieContent, "','", oderInfo.UsedFavourTicket, "',", oderInfo.OrderType, ",",
                oderInfo.RecommendCommision, ",", oderInfo.IsMinus, ",'", oderInfo.IdentifyCode, "',", oderInfo.Score_pv_b, ",", oderInfo.Score_hv, ",", oderInfo.Score_dv, ",", oderInfo.Score_pv_a, ",", oderInfo.Score_cv, ",", oderInfo.Score_max_hv, ",", oderInfo.shop_category_id,",",oderInfo.score_reduce_pv_b,",",oderInfo.score_reduce_hv,",",oderInfo.score_reduce_dv,",",oderInfo.score_reduce_pv_a,",'",oderInfo.ServiceAgent,"',",oderInfo.score_pv_cv,",", oderInfo.ShouldPayPrice,",'",oderInfo.SuperiorRank,"',",oderInfo.SuanLiDaySum,",",oderInfo.SuanLiUnitPrice,",'",DateTime.Now,"','",startDay,"','",endDay,"');"

            });

            sqlList.Add(str7);

            if (listOrderProduct.Count > 0)
            {
                
                for (int i = 0; i < listOrderProduct.Count; i++)
                {
                    string str2 = string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_OrderProduct( Guid,OrderInfoGuid,ProductGuid,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,GroupPrice,IsJoinActivity,DetailedSpecifications,MemLoginID,ShopID,CreateTime,ProductImg,OrderType,ProductName,shop_category_id,Size,Color,ProductName_EN ) VALUES ( '"
                        , listOrderProduct[i].Guid, "','", oderInfo.Guid, "','", listOrderProduct[i].ProductGuid,
                        "','", Operator.FilterString(listOrderProduct[i].RepertoryNumber), "',",
                        listOrderProduct[i].BuyNumber, ",", listOrderProduct[i].MarketPrice, ",",
                        listOrderProduct[i].ShopPrice, ",", listOrderProduct[i].BuyPrice,
                        ",'", Operator.FilterString(listOrderProduct[i].Attributes), "','",
                        Operator.FilterString(listOrderProduct[i].SpecificationName), "','",
                        Operator.FilterString(listOrderProduct[i].SpecificationValue), "',",
                        listOrderProduct[i].IsShipment, ",", listOrderProduct[i].IsReal, ",'",
                        Operator.FilterString(listOrderProduct[i].ExtensionAttriutes), "',",
                        listOrderProduct[i].GroupPrice, ",", listOrderProduct[i].IsJoinActivity,
                        ",'", listOrderProduct[i].DetailedSpecifications, "','", listOrderProduct[i].MemLoginID,
                        "','", listOrderProduct[i].ShopID, "','",
                        Convert.ToDateTime(listOrderProduct[i].CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "','",
                        listOrderProduct[i].ProductImg, "','", listOrderProduct[i].OrderType, "','",
                        listOrderProduct[i].ProductName,"',",listOrderProduct[i].shop_category_id,",'",listOrderProduct[i].Size,"','",listOrderProduct[i].Color,"','",EnglishName,"');"
                    });

                    sqlList.Add(str2);

                    if (listOrderProduct[i].setStock == "0")
                    {
                        string str3 = "UPDATE Nec_LiCaiJiJin SET SurplusTotal=SurplusTotal-" + listOrderProduct[i].BuyNumber + " WHERE ProductId ='" + listOrderProduct[i].ProductGuid + "' And SurplusTotal>=" + listOrderProduct[i].BuyNumber + ";";

                        sqlList.Add(str3);

                        
                    }

                    //若订单包含消费积分, 应该在下单时候扣除
                }
            }

            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int AddZuLin(ShopNum1_OrderInfo oderInfo, List<ShopNum1_OrderProduct> listOrderProduct,string ProductName_EN)
        {
            var sqlList = new List<string>();
            string str = "等待付款";

            if ((oderInfo.PaymentName.IndexOf("货到付款") == -1) || (oderInfo.PaymentName.IndexOf("线下支付") == -1))
            {
                if (oderInfo.FeeType == 2)
                {
                    str = "等待消费";
                }
                else
                {
                    str = "等待付款";
                }
            }

            string item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_OrderOperateLog(Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,CurrentStateMsg,NextStateMsg,Memo,OperateDateTime,IsDeleted)VALUES('"
                , oderInfo.Guid, "','", oderInfo.Guid, "','", oderInfo.MemLoginID, "','", oderInfo.OderStatus, "','"
                , oderInfo.ShipmentStatus, "','", oderInfo.PaymentStatus, "','已经下单','", str, "','','",
                DateTime.Now.ToString(),
                "','0');"
            });

            sqlList.Add(item);

            string str7 = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_OrderInfo( Guid,PayMentMemLoginID,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,ProductPv_b,DispatchPrice,DispatchType,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,ShopID,ReceivedDays,IsMemdelay,ShopName,FeeType,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,OrderType,RecommendCommision,IsMinus,IdentifyCode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,Score_cv,Score_max_hv,shop_category_id,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,ServiceAgent,Score_pv_cv,ProductLastPrice,SuperiorRank,SuanLiDaySum,SuanLiUnitPrice) VALUES ( '"
                , oderInfo.Guid, "','", oderInfo.PayMentMemLoginID, "','", oderInfo.MemLoginID, "','",
                oderInfo.OrderNumber, "','", oderInfo.TradeID, "',", oderInfo.OderStatus, ",",
                oderInfo.ShipmentStatus, ",", oderInfo.PaymentStatus,
                ",'", Operator.FilterString(oderInfo.Name), "','", Operator.FilterString(oderInfo.Email), "','",
                Operator.FilterString(oderInfo.Address), "','", Operator.FilterString(oderInfo.Postalcode), "','",
                Operator.FilterString(oderInfo.Tel), "','", Operator.FilterString(oderInfo.Mobile), "','",
                Operator.FilterString(oderInfo.ClientToSellerMsg), "','",
                Operator.FilterString(oderInfo.SellerToClientMsg),
                "','", oderInfo.PaymentGuid, "','", Operator.FilterString(oderInfo.PaymentName), "','",
                Operator.FilterString(oderInfo.OutOfStockOperate), "','", oderInfo.PackGuid, "','",
                Operator.FilterString(oderInfo.PackName), "','", oderInfo.BlessCardGuid, "','",
                Operator.FilterString(oderInfo.BlessCardName), "','",
                Operator.FilterString(oderInfo.BlessCardContent),
                "','", Operator.FilterString(oderInfo.InvoiceTitle), "','",
                Operator.FilterString(oderInfo.InvoiceContent), "',", oderInfo.ProductPrice,",",oderInfo.ProductPv_b, ",",
                oderInfo.DispatchPrice, ",", oderInfo.DispatchType, ",", oderInfo.PaymentPrice, ",",
                oderInfo.PackPrice, ",", oderInfo.BlessCardPrice,
                ",", oderInfo.AlreadPayPrice, ",", oderInfo.SurplusPrice, ",", oderInfo.UseScore, ",",
                oderInfo.ScorePrice, ",", oderInfo.ShouldPayPrice, ",'", Operator.FilterString(oderInfo.FromAd),
                "','", Operator.FilterString(oderInfo.FromUrl), "','", Operator.FilterString(oderInfo.CreateTime),
                "','", oderInfo.ConfirmTime, "','", Operator.FilterString(oderInfo.ShipmentNumber), "','",
                Operator.FilterString(oderInfo.BuyType), "','", oderInfo.ActivityGuid, "','",
                Operator.FilterString(oderInfo.PayMemo), "','", Operator.FilterString(oderInfo.InvoiceType), "',",
                oderInfo.InvoiceTax, ",", oderInfo.Discount,
                ",", oderInfo.Deposit, ",'", oderInfo.ShopID, "', ", oderInfo.ReceivedDays, ", ",
                oderInfo.IsMemdelay, ",'", oderInfo.ShopName, "',", oderInfo.FeeType, ",'", oderInfo.RegionCode,
                "',", oderInfo.JoinActiveType,
                ",'", oderInfo.ActvieContent, "','", oderInfo.UsedFavourTicket, "',", oderInfo.OrderType, ",",
                oderInfo.RecommendCommision, ",", oderInfo.IsMinus, ",'", oderInfo.IdentifyCode, "',", oderInfo.Score_pv_b, ",", oderInfo.Score_hv, ",", oderInfo.Score_dv, ",", oderInfo.Score_pv_a, ",", oderInfo.Score_cv, ",", oderInfo.Score_max_hv, ",", oderInfo.shop_category_id,",",oderInfo.score_reduce_pv_b,",",oderInfo.score_reduce_hv,",",oderInfo.score_reduce_dv,",",oderInfo.score_reduce_pv_a,",'",oderInfo.ServiceAgent,"',",oderInfo.score_pv_cv,",", oderInfo.ShouldPayPrice,",'",oderInfo.SuperiorRank,"',",oderInfo.SuanLiDaySum,",",oderInfo.SuanLiUnitPrice,");"
            
            });

            sqlList.Add(str7);

            if (listOrderProduct.Count > 0)
            {
                sqlList.Add("Update ShopNum1_Shop_Product set buycount=buycount+1 where guid='" +
                            listOrderProduct[0].ProductGuid + "';");
                for (int i = 0; i < listOrderProduct.Count; i++)
                {
                    string str2 = string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_OrderProduct( Guid,OrderInfoGuid,ProductGuid,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,GroupPrice,IsJoinActivity,DetailedSpecifications,MemLoginID,ShopID,CreateTime,ProductImg,OrderType,ProductName,shop_category_id,Size,Color,ProductName_EN ) VALUES ( '"
                        , listOrderProduct[i].Guid, "','", oderInfo.Guid, "','", listOrderProduct[i].ProductGuid,
                        "','", Operator.FilterString(listOrderProduct[i].RepertoryNumber), "',",
                        listOrderProduct[i].BuyNumber, ",", listOrderProduct[i].MarketPrice, ",",
                        listOrderProduct[i].ShopPrice, ",", listOrderProduct[i].BuyPrice,
                        ",'", Operator.FilterString(listOrderProduct[i].Attributes), "','",
                        Operator.FilterString(listOrderProduct[i].SpecificationName), "','",
                        Operator.FilterString(listOrderProduct[i].SpecificationValue), "',",
                        listOrderProduct[i].IsShipment, ",", listOrderProduct[i].IsReal, ",'",
                        Operator.FilterString(listOrderProduct[i].ExtensionAttriutes), "',",
                        listOrderProduct[i].GroupPrice, ",", listOrderProduct[i].IsJoinActivity,
                        ",'", listOrderProduct[i].DetailedSpecifications, "','", listOrderProduct[i].MemLoginID,
                        "','", listOrderProduct[i].ShopID, "','",
                        Convert.ToDateTime(listOrderProduct[i].CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "','",
                        listOrderProduct[i].ProductImg, "','", listOrderProduct[i].OrderType, "','",
                        listOrderProduct[i].ProductName,"',",listOrderProduct[i].shop_category_id,",'",listOrderProduct[i].Size,"','",listOrderProduct[i].Color,"','",ProductName_EN,"');"
                    });

                    sqlList.Add(str2);

                    if (listOrderProduct[i].setStock == "0")
                    {
                        string str3 = "UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount-" + listOrderProduct[i].BuyNumber + " WHERE Guid ='" + listOrderProduct[i].ProductGuid + "' And repertorycount>=" + listOrderProduct[i].BuyNumber + ";";

                        sqlList.Add(str3);

                        string str4 = "UPDATE ShopNum1_Group_Product SET groupstock=groupstock-" + listOrderProduct[i].BuyNumber + " WHERE productguid='" + listOrderProduct[i].ProductGuid + "' And groupstock>=" +
                                      listOrderProduct[i].BuyNumber + ";";

                        sqlList.Add(str4);

                        string str5 = "UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock-" + listOrderProduct[i].BuyNumber + " WHERE  SpecDetail ='" + listOrderProduct[i].SpecificationValue + "' And goodsstock>=" + listOrderProduct[i].BuyNumber + ";";

                        sqlList.Add(str5);
                    }

                    //若订单包含消费积分, 应该在下单时候扣除
                }
            }

            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Add(ShopNum1_OrderInfo oderInfo, List<ShopNum1_OrderProduct> listOrderProduct)
        {
            var sqlList = new List<string>();
            string str = "等待付款";

            if ((oderInfo.PaymentName.IndexOf("货到付款") == -1) || (oderInfo.PaymentName.IndexOf("线下支付") == -1))
            {
                if (oderInfo.FeeType == 2)
                {
                    str = "等待消费";
                }
                else
                {
                    str = "等待付款";
                }
            }

            string item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_OrderOperateLog(Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,CurrentStateMsg,NextStateMsg,Memo,OperateDateTime,IsDeleted)VALUES('"
                , oderInfo.Guid, "','", oderInfo.Guid, "','", oderInfo.MemLoginID, "','", oderInfo.OderStatus, "','"
                , oderInfo.ShipmentStatus, "','", oderInfo.PaymentStatus, "','已经下单','", str, "','','",
                DateTime.Now.ToString(),
                "','0');"
            });

            sqlList.Add(item);

            string str7 = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_OrderInfo( Guid,PayMentMemLoginID,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,ProductPv_b,DispatchPrice,DispatchType,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,ShopID,ReceivedDays,IsMemdelay,ShopName,FeeType,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,OrderType,RecommendCommision,IsMinus,IdentifyCode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,Score_cv,Score_max_hv,shop_category_id,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,ServiceAgent,Score_pv_cv,ProductLastPrice,SuperiorRank) VALUES ( '"
                , oderInfo.Guid, "','", oderInfo.PayMentMemLoginID, "','", oderInfo.MemLoginID, "','",
                oderInfo.OrderNumber, "','", oderInfo.TradeID, "',", oderInfo.OderStatus, ",",
                oderInfo.ShipmentStatus, ",", oderInfo.PaymentStatus,
                ",'", Operator.FilterString(oderInfo.Name), "','", Operator.FilterString(oderInfo.Email), "','",
                Operator.FilterString(oderInfo.Address), "','", Operator.FilterString(oderInfo.Postalcode), "','",
                Operator.FilterString(oderInfo.Tel), "','", Operator.FilterString(oderInfo.Mobile), "','",
                Operator.FilterString(oderInfo.ClientToSellerMsg), "','",
                Operator.FilterString(oderInfo.SellerToClientMsg),
                "','", oderInfo.PaymentGuid, "','", Operator.FilterString(oderInfo.PaymentName), "','",
                Operator.FilterString(oderInfo.OutOfStockOperate), "','", oderInfo.PackGuid, "','",
                Operator.FilterString(oderInfo.PackName), "','", oderInfo.BlessCardGuid, "','",
                Operator.FilterString(oderInfo.BlessCardName), "','",
                Operator.FilterString(oderInfo.BlessCardContent),
                "','", Operator.FilterString(oderInfo.InvoiceTitle), "','",
                Operator.FilterString(oderInfo.InvoiceContent), "',", oderInfo.ProductPrice,",",oderInfo.ProductPv_b, ",",
                oderInfo.DispatchPrice, ",", oderInfo.DispatchType, ",", oderInfo.PaymentPrice, ",",
                oderInfo.PackPrice, ",", oderInfo.BlessCardPrice,
                ",", oderInfo.AlreadPayPrice, ",", oderInfo.SurplusPrice, ",", oderInfo.UseScore, ",",
                oderInfo.ScorePrice, ",", oderInfo.ShouldPayPrice, ",'", Operator.FilterString(oderInfo.FromAd),
                "','", Operator.FilterString(oderInfo.FromUrl), "','", Operator.FilterString(oderInfo.CreateTime),
                "','", oderInfo.ConfirmTime, "','", Operator.FilterString(oderInfo.ShipmentNumber), "','",
                Operator.FilterString(oderInfo.BuyType), "','", oderInfo.ActivityGuid, "','",
                Operator.FilterString(oderInfo.PayMemo), "','", Operator.FilterString(oderInfo.InvoiceType), "',",
                oderInfo.InvoiceTax, ",", oderInfo.Discount,
                ",", oderInfo.Deposit, ",'", oderInfo.ShopID, "', ", oderInfo.ReceivedDays, ", ",
                oderInfo.IsMemdelay, ",'", oderInfo.ShopName, "',", oderInfo.FeeType, ",'", oderInfo.RegionCode,
                "',", oderInfo.JoinActiveType,
                ",'", oderInfo.ActvieContent, "','", oderInfo.UsedFavourTicket, "',", oderInfo.OrderType, ",",
                oderInfo.RecommendCommision, ",", oderInfo.IsMinus, ",'", oderInfo.IdentifyCode, "',", oderInfo.Score_pv_b, ",", oderInfo.Score_hv, ",", oderInfo.Score_dv, ",", oderInfo.Score_pv_a, ",", oderInfo.Score_cv, ",", oderInfo.Score_max_hv, ",", oderInfo.shop_category_id,",",oderInfo.score_reduce_pv_b,",",oderInfo.score_reduce_hv,",",oderInfo.score_reduce_dv,",",oderInfo.score_reduce_pv_a,",'",oderInfo.ServiceAgent,"',",oderInfo.score_pv_cv,",", oderInfo.ShouldPayPrice,",'",oderInfo.SuperiorRank,"');"
            
            });

            sqlList.Add(str7);

            if (listOrderProduct.Count > 0)
            {
                sqlList.Add("Update ShopNum1_Shop_Product set buycount=buycount+1 where guid='" +
                            listOrderProduct[0].ProductGuid + "';");
                for (int i = 0; i < listOrderProduct.Count; i++)
                {
                    string str2 = string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_OrderProduct( Guid,OrderInfoGuid,ProductGuid,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,GroupPrice,IsJoinActivity,DetailedSpecifications,MemLoginID,ShopID,CreateTime,ProductImg,OrderType,ProductName,shop_category_id,Size,Color ) VALUES ( '"
                        , listOrderProduct[i].Guid, "','", oderInfo.Guid, "','", listOrderProduct[i].ProductGuid,
                        "','", Operator.FilterString(listOrderProduct[i].RepertoryNumber), "',",
                        listOrderProduct[i].BuyNumber, ",", listOrderProduct[i].MarketPrice, ",",
                        listOrderProduct[i].ShopPrice, ",", listOrderProduct[i].BuyPrice,
                        ",'", Operator.FilterString(listOrderProduct[i].Attributes), "','",
                        Operator.FilterString(listOrderProduct[i].SpecificationName), "','",
                        Operator.FilterString(listOrderProduct[i].SpecificationValue), "',",
                        listOrderProduct[i].IsShipment, ",", listOrderProduct[i].IsReal, ",'",
                        Operator.FilterString(listOrderProduct[i].ExtensionAttriutes), "',",
                        listOrderProduct[i].GroupPrice, ",", listOrderProduct[i].IsJoinActivity,
                        ",'", listOrderProduct[i].DetailedSpecifications, "','", listOrderProduct[i].MemLoginID,
                        "','", listOrderProduct[i].ShopID, "','",
                        Convert.ToDateTime(listOrderProduct[i].CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "','",
                        listOrderProduct[i].ProductImg, "','", listOrderProduct[i].OrderType, "','",
                        listOrderProduct[i].ProductName,"',",listOrderProduct[i].shop_category_id,",'",listOrderProduct[i].Size,"','",listOrderProduct[i].Color,"');"
                    });

                    sqlList.Add(str2);

                    if (listOrderProduct[i].setStock == "0")
                    {
                        string str3 = "UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount-" + listOrderProduct[i].BuyNumber + " WHERE Guid ='" + listOrderProduct[i].ProductGuid + "' And repertorycount>=" + listOrderProduct[i].BuyNumber + ";";

                        sqlList.Add(str3);

                        string str4 = "UPDATE ShopNum1_Group_Product SET groupstock=groupstock-" + listOrderProduct[i].BuyNumber + " WHERE productguid='" + listOrderProduct[i].ProductGuid + "' And groupstock>=" +
                                      listOrderProduct[i].BuyNumber + ";";

                        sqlList.Add(str4);

                        string str5 = "UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock-" + listOrderProduct[i].BuyNumber + " WHERE  SpecDetail ='" + listOrderProduct[i].SpecificationValue + "' And goodsstock>=" + listOrderProduct[i].BuyNumber + ";";

                        sqlList.Add(str5);
                    }

                    //若订单包含消费积分, 应该在下单时候扣除
                }
            }

            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Add(List<ShopNum1_OrderInfo> listoderinfo, List<ShopNum1_OrderProduct> listOrderProduct)
        {
            var sqlList = new List<string>();
            if (listoderinfo.Count > 0)
            {
                for (int i = 0; i < listoderinfo.Count; i++)
                {
                    string item =
                        string.Concat(new object[]
                        {
                            "INSERT INTO ShopNum1_OrderOperateLog(Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,CurrentStateMsg,NextStateMsg,Memo,OperateDateTime,IsDeleted)VALUES('"
                            , listoderinfo[i].Guid, "','", listoderinfo[i].Guid, "','", listoderinfo[i].MemLoginID,
                            "','", listoderinfo[i].OderStatus, "','", listoderinfo[i].ShipmentStatus, "','",
                            listoderinfo[i].PaymentStatus, "','已经下单','等待付款','','",
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "','0');"
                        });

                    sqlList.Add(item);

                    string str6 = string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_OrderInfo( Guid,PayMentMemLoginID,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,ProductPv_b,DispatchPrice,DispatchType,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,ShopID,ReceivedDays,IsMemdelay,ShopName,FeeType,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,OrderType,IsMinus,Score_pv_b,Score_hv,Score_dv,Score_pv_a,Score_max_hv,Score_cv,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,shop_category_id,ServiceAgent,Score_pv_cv,ProductLastPrice,SuperiorRank) VALUES ( '"
                        , listoderinfo[i].Guid, "','", Operator.FilterString(listoderinfo[i].PayMentMemLoginID),
                        "','", Operator.FilterString(listoderinfo[i].MemLoginID), "','", listoderinfo[i].OrderNumber
                        , "','", listoderinfo[i].TradeID, "',", listoderinfo[i].OderStatus, ",",
                        listoderinfo[i].ShipmentStatus, ",", listoderinfo[i].PaymentStatus,
                        ",'", Operator.FilterString(listoderinfo[i].Name), "','",
                        Operator.FilterString(listoderinfo[i].Email), "','",
                        Operator.FilterString(listoderinfo[i].Address), "','",
                        Operator.FilterString(listoderinfo[i].Postalcode), "','",
                        Operator.FilterString(listoderinfo[i].Tel), "','",
                        Operator.FilterString(listoderinfo[i].Mobile), "','",
                        Operator.FilterString(listoderinfo[i].ClientToSellerMsg), "','",
                        Operator.FilterString(listoderinfo[i].SellerToClientMsg),
                        "','", listoderinfo[i].PaymentGuid, "','",
                        Operator.FilterString(listoderinfo[i].PaymentName), "','",
                        Operator.FilterString(listoderinfo[i].OutOfStockOperate), "','", listoderinfo[i].PackGuid,
                        "','", Operator.FilterString(listoderinfo[i].PackName), "','", listoderinfo[i].BlessCardGuid
                        , "','", Operator.FilterString(listoderinfo[i].BlessCardName), "','",
                        Operator.FilterString(listoderinfo[i].BlessCardContent),
                        "','", Operator.FilterString(listoderinfo[i].InvoiceTitle), "','",
                        Operator.FilterString(listoderinfo[i].InvoiceContent), "',", listoderinfo[i].ProductPrice,",",listoderinfo[i].ProductPv_b,
                        ",", listoderinfo[i].DispatchPrice, ",", listoderinfo[i].DispatchType, ",",
                        listoderinfo[i].PaymentPrice, ",", listoderinfo[i].PackPrice, ",",
                        listoderinfo[i].BlessCardPrice,
                        ",", listoderinfo[i].AlreadPayPrice, ",", listoderinfo[i].SurplusPrice, ",",
                        listoderinfo[i].UseScore, ",", listoderinfo[i].ScorePrice, ",",
                        listoderinfo[i].ShouldPayPrice, ",'", Operator.FilterString(listoderinfo[i].FromAd), "','",
                        Operator.FilterString(listoderinfo[i].FromUrl), "','",
                        Convert.ToDateTime(listoderinfo[i].CreateTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        "','", listoderinfo[i].ConfirmTime, "','",
                        Operator.FilterString(listoderinfo[i].ShipmentNumber), "','",
                        Operator.FilterString(listoderinfo[i].BuyType), "','", listoderinfo[i].ActivityGuid, "','",
                        Operator.FilterString(listoderinfo[i].PayMemo), "','",
                        Operator.FilterString(listoderinfo[i].InvoiceType), "',", listoderinfo[i].InvoiceTax, ",",
                        listoderinfo[i].Discount,
                        ",", listoderinfo[i].Deposit, ",'", listoderinfo[i].ShopID, "', ",
                        listoderinfo[i].ReceivedDays, ", ", listoderinfo[i].IsMemdelay, ",'",
                        listoderinfo[i].ShopName, "',", listoderinfo[i].FeeType, ",'", listoderinfo[i].RegionCode,
                        "',", listoderinfo[i].JoinActiveType,
                        ",'", listoderinfo[i].ActvieContent, "','", listoderinfo[i].UsedFavourTicket, "',",
                        listoderinfo[i].OrderType, ",", listoderinfo[i].IsMinus, ",", listoderinfo[i].Score_pv_b, ",", listoderinfo[i].Score_hv, ",", listoderinfo[i].Score_dv, ",", listoderinfo[i].Score_pv_a, ",", listoderinfo[i].Score_max_hv, ",", listoderinfo[i].Score_cv,",",listoderinfo[i].score_reduce_pv_b,",",listoderinfo[i].score_reduce_hv,",",listoderinfo[i].score_reduce_dv,",",listoderinfo[i].score_reduce_pv_a,",",listoderinfo[i].shop_category_id,",'",listoderinfo[i].ServiceAgent,"',",listoderinfo[i].score_pv_cv,",", listoderinfo[i].ShouldPayPrice,",'",listoderinfo[i].SuperiorRank,"')"
                    });
                    sqlList.Add(str6);
                }
            }

            if (listOrderProduct.Count > 0)
            {
                for (int j = 0; j < listOrderProduct.Count; j++)
                {
                    string str = string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_OrderProduct( Guid,OrderInfoGuid,ProductGuid,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,GroupPrice,IsJoinActivity,DetailedSpecifications,MemLoginID,ShopID,CreateTime,ProductImg,OrderType,ProductName,shop_category_id,Size,Color ) VALUES ( '"
                        , listOrderProduct[j].Guid, "','", listOrderProduct[j].OrderInfoGuid, "','",
                        listOrderProduct[j].ProductGuid, "','",
                        Operator.FilterString(listOrderProduct[j].RepertoryNumber), "',",
                        listOrderProduct[j].BuyNumber, ",", listOrderProduct[j].MarketPrice, ",",
                        listOrderProduct[j].ShopPrice, ",", listOrderProduct[j].BuyPrice,
                        ",'", Operator.FilterString(listOrderProduct[j].Attributes), "','",
                        Operator.FilterString(listOrderProduct[j].SpecificationName), "','",
                        Operator.FilterString(listOrderProduct[j].SpecificationValue), "',",
                        listOrderProduct[j].IsShipment, ",", listOrderProduct[j].IsReal, ",'",
                        Operator.FilterString(listOrderProduct[j].ExtensionAttriutes), "',",
                        listOrderProduct[j].GroupPrice, ",", listOrderProduct[j].IsJoinActivity,
                        ",'", listOrderProduct[j].DetailedSpecifications, "','", listOrderProduct[j].MemLoginID,
                        "','", listOrderProduct[j].ShopID, "','",
                        Convert.ToDateTime(listOrderProduct[j].CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "','",
                        listOrderProduct[j].ProductImg, "','", listOrderProduct[j].OrderType, "','",
                        listOrderProduct[j].ProductName,"',",listOrderProduct[j].shop_category_id,",'",listOrderProduct[j].Size,"','",listOrderProduct[j].Color,"');"
                    });
                    sqlList.Add(str);

                    //修改库存
                    if (listOrderProduct[j].setStock == "0")
                    {
                        string str2 = "UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount-" +
                                      listOrderProduct[j].BuyNumber + " WHERE Guid ='" +
                                      listOrderProduct[j].ProductGuid + "' And repertorycount>=" +
                                      listOrderProduct[j].BuyNumber + ";";
                        sqlList.Add(str2);
                        string str3 = "UPDATE ShopNum1_Group_Product SET groupstock=groupstock-" +
                                      listOrderProduct[j].BuyNumber + " WHERE productguid='" +
                                      listOrderProduct[j].ProductGuid + "' And groupstock>=" +
                                      listOrderProduct[j].BuyNumber + ";";
                        sqlList.Add(str3);
                        string str4 = "UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock-" +
                                      listOrderProduct[j].BuyNumber + " WHERE  SpecDetail ='" +
                                      listOrderProduct[j].SpecificationValue + "' And goodsstock>=" +
                                      listOrderProduct[j].BuyNumber + ";";
                        sqlList.Add(str4);
                    }
                }
            }

            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }



        public int AddOrder(ShopNum1_OrderInfo orderInfo)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "insert into ShopNum1_OrderInfo(Guid,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,DispatchType,PaymentPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,OrderType,IsDeleted,BuyIsDeleted,SellIsDeleted,ShopID,RegionCode,ShopName,JoinActiveType,ActvieContent,UsedFavourTicket,FeeType,CancelReason,EndTime,IsBuyComment,IsSellComment,ReceiptTime,MemLoginID,TradeID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,refundStatus,Name,Email,Address,PackPrice,BlessCardPrice,PayMentMemLoginID,Postalcode)Values('"
                , orderInfo.Guid, "','", orderInfo.Tel, "','", orderInfo.Mobile, "','", orderInfo.ClientToSellerMsg,
                "','", orderInfo.SellerToClientMsg, "','", orderInfo.PaymentGuid, "','", orderInfo.PaymentName,
                "','", orderInfo.OutOfStockOperate,
                "','", orderInfo.InvoiceTitle, "','", orderInfo.InvoiceContent, "','", orderInfo.ProductPrice, "','"
                , orderInfo.DispatchPrice, "',", orderInfo.DispatchType, ",'", orderInfo.PaymentPrice, "','",
                orderInfo.AlreadPayPrice, "','", orderInfo.SurplusPrice,
                "',", orderInfo.UseScore, ",'", orderInfo.ScorePrice, "','", orderInfo.ShouldPayPrice, "','",
                orderInfo.FromAd, "','", orderInfo.FromUrl, "','",
                Convert.ToDateTime(orderInfo.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "','",
                Convert.ToDateTime(orderInfo.ConfirmTime).ToString("yyyy-MM-dd HH:mm:ss"), "','",
                Convert.ToDateTime(orderInfo.PayTime).ToString("yyyy-MM-dd HH:mm:ss"),
                "','", Convert.ToDateTime(orderInfo.DispatchTime).ToString("yyyy-MM-dd HH:mm:ss"), "','",
                orderInfo.ShipmentNumber, "','", orderInfo.BuyType, "','", orderInfo.ActivityGuid, "','",
                orderInfo.PayMemo, "','", orderInfo.InvoiceType, "','", orderInfo.InvoiceTax, "','",
                orderInfo.Discount,
                "','", orderInfo.Deposit, "',", orderInfo.OrderType, ",", orderInfo.IsDeleted, ",",
                orderInfo.BuyIsDeleted, ",", orderInfo.SellIsDeleted, ",'", orderInfo.ShopID, "','",
                orderInfo.RegionCode, "','", orderInfo.ShopName,
                "',", orderInfo.JoinActiveType, ",'", orderInfo.ActvieContent, "','", orderInfo.UsedFavourTicket,
                "',", orderInfo.FeeType, ",'", orderInfo.CancelReason, "','",
                Convert.ToDateTime(orderInfo.EndTime).ToString("yyyy-MM-dd HH:mm:ss"), "',", orderInfo.IsBuyComment,
                ",", orderInfo.IsSellComment,
                ",'", orderInfo.ReceiptTime, "','", orderInfo.MemLoginID, "','", orderInfo.TradeID, "','",
                orderInfo.OrderNumber, "',", orderInfo.OderStatus, ",", orderInfo.ShipmentStatus, ",",
                orderInfo.PaymentStatus, ",", orderInfo.refundStatus,
                ",'", orderInfo.Name, "','", orderInfo.Email, "','", orderInfo.Address, "',", orderInfo.PackPrice,
                ",", orderInfo.BlessCardPrice, ",'", orderInfo.PayMentMemLoginID, "','", orderInfo.Postalcode, "')"
            }));
        }

        public int AddOrderCode(ShopNum1_MemberActivate MemberActivate)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "insert into ShopNum1_MemberActivate([Guid],Phone,[key],MemberID,pwd ,Email,extireTime,isinvalid,type)Values('"
                , MemberActivate.Guid, "','", MemberActivate.Phone, "','", MemberActivate.Key, "','",
                MemberActivate.MemberID, "','", MemberActivate.Pwd, "','", MemberActivate.Email, "','",
                Convert.ToDateTime(MemberActivate.extireTime).ToString("yyyy-MM-dd HH:mm:ss"), "',",
                MemberActivate.isinvalid,
                ",", MemberActivate.type, ")"
            }));
        }

        public int AddOtherOrderInfo(ShopNum1_Shop_OtherOrderInfo shopNum1_Shop_OtherOrderInfo)
        {
            var paraName = new string[15];
            var paraValue = new string[15];
            paraName[0] = "@guid";
            paraValue[0] = shopNum1_Shop_OtherOrderInfo.Guid.ToString();
            paraName[1] = "@tradeid";
            paraValue[1] = shopNum1_Shop_OtherOrderInfo.TradeID;
            paraName[2] = "@relevanceid";
            paraValue[2] = shopNum1_Shop_OtherOrderInfo.RelevanceID;
            paraName[3] = "@unitprice";
            paraValue[3] = shopNum1_Shop_OtherOrderInfo.UnitPrice.ToString();
            paraName[4] = "@buynumber";
            paraValue[4] = shopNum1_Shop_OtherOrderInfo.BuyNumber.ToString();
            paraName[5] = "@totalprice";
            paraValue[5] = shopNum1_Shop_OtherOrderInfo.TotalPrice.ToString();
            paraName[6] = "@memloginid";
            paraValue[6] = shopNum1_Shop_OtherOrderInfo.MemLoginID;
            paraName[7] = "@orderstatus";
            paraValue[7] = shopNum1_Shop_OtherOrderInfo.OrderStatus.ToString();
            paraName[8] = "@type";
            paraValue[8] = shopNum1_Shop_OtherOrderInfo.Type;
            paraName[9] = "@description";
            paraValue[9] = shopNum1_Shop_OtherOrderInfo.Description;
            paraName[10] = "@createtime";
            paraValue[10] = Convert.ToDateTime(shopNum1_Shop_OtherOrderInfo.CreateTime).ToString("yyyy-MM-dd HH:mm:ss");
            paraName[11] = "@paymentstatus";
            paraValue[11] = shopNum1_Shop_OtherOrderInfo.PaymentStatus.ToString();
            paraName[12] = "@Name";
            paraValue[12] = shopNum1_Shop_OtherOrderInfo.Name;
            paraName[13] = "@PaymentType";
            paraValue[13] = shopNum1_Shop_OtherOrderInfo.PaymentType.ToString();
            paraName[14] = "@PaymentName";
            paraValue[14] = shopNum1_Shop_OtherOrderInfo.PaymentName;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddOtherOrderInfo", paraName, paraValue);
        }

        public int BackNormalProudctRepertoryCount(string productguid, string buycount)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@productguid";
            parms[0].Value = productguid;
            parms[1].ParameterName = "@buycount";
            parms[1].Value = buycount;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  dbo.ShopNum1_Product SET RepertoryCount=RepertoryCount+@buycount WHERE Guid=@productguid", parms);
        }

        public int BackSpecificationProudctRepertoryCount(string productguid, string detail, string buycount)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@productguid";
            parms[0].Value = productguid;
            parms[1].ParameterName = "@detail";
            parms[1].Value = detail;
            parms[2].ParameterName = "@buycount";
            parms[2].Value = buycount;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  dbo.ShopNum1_SpecificationProudct SET RepertoryCount=RepertoryCount+@buycount WHERE ProductGuid=@productguid and Detail=@detail ", parms);
        }

        public int BackUsedFavourTicket(string usercode, string memberloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@usercode";
            parms[0].Value = usercode;
            parms[1].ParameterName = "@memberloginid";
            parms[1].Value = memberloginid;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_MemberFavourTicket set LimitTimes=LimitTimes+1 where FavourTicketCode=@usercode  and MemLoginID=@memberloginid", parms);
        }

        public int CancelOrder(string guid, string cancelreason, int oderstatus)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@cancelreason";
            paraValue[1] = cancelreason;
            paraName[2] = "@oderstatus";
            paraValue[2] = oderstatus.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_CancelOrder", paraName, paraValue);
        }

        public DataSet CheckOrderState(string ordernumber, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ordernumber";
            paraValue[0] = ordernumber;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_OrderInfoCheckOrderState", paraName,
                paraValue);
        }

        public DataSet CheckTradeState(string TradeID, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@TradeID";
            paraValue[0] = TradeID;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_OrderInfoCheckMultOrderState", paraName,
                paraValue);
        }

        public string ComputeInvoicePrice(string invoiceTax)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@invoiceTax";
            parms[0].Value = invoiceTax;

            return
                DatabaseExcetue.ReturnDataTable("SELECT @invoiceTax AS InvoiceTax", parms).Rows[0]["InvoiceTax"]
                    .ToString();
        }

        public string ComputeOderPrice(string orderPrice)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@orderPrice";
            parms[0].Value = orderPrice;
            return
                DatabaseExcetue.ReturnDataTable("SELECT @orderPrice AS OrderPrice", parms).Rows[0]["OrderPrice"]
                    .ToString();
        }

        public string ComputeShouldPayPrice(string shouldPayPrice)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@shouldPayPrice";
            parms[0].Value = shouldPayPrice;
            return
                DatabaseExcetue.ReturnDataTable("SELECT @shouldPayPrice AS ShouldPayPrice", parms).Rows[0][
                    "ShouldPayPrice"].ToString();
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public int Delete(string guid)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = "DELETE FROM ShopNum1_OrderInfo WHERE orderNumber IN (" + guid + ")";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_OrderProduct WHERE orderNumber IN (" + guid + ")";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_OrderOperateLog WHERE orderNumber IN (" + guid + ")";
            sqlList.Add(item);

            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除订单 (标记)
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public int DeleteOrderInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteOrderInfo", paraName, paraValue);
        }

        public int DeleteOrderInfoByAdminOrdernum(string ordernum, int Type, string memloginId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ordernum";
            parms[0].Value = ordernum.Trim();
            parms[1].ParameterName = "@memloginId";
            parms[1].Value = memloginId;
            string strSql = "delete from ShopNum1_OrderInfo where OrderNumber in (@ordernum) ";
            if (memloginId != "admin")
            {
                if (Type == 1)
                {
                    strSql = strSql + " and memloginId=@memloginId";
                }
                else
                {
                    strSql = strSql + " and shopid=@memloginId";
                }
            }
            return DatabaseExcetue.RunNonQuery(strSql, parms);
        }

        public int DeleteOrderInfoByOrdernum(string ordernum, int Type, string memloginId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ordernum";
            parms[0].Value = ordernum.Trim();
            parms[1].ParameterName = "@memloginId";
            parms[1].Value = memloginId;
            string strSql = "update ShopNum1_OrderInfo set BuyIsDeleted=1 where OrderNumber in (@ordernum) ";
            if (memloginId != "admin")
            {
                if (Type == 1)
                {
                    strSql = strSql + " and memloginId=@memloginId";
                }
                else
                {
                    strSql = strSql + " and shopid=@memloginId";
                }
            }
            return DatabaseExcetue.RunNonQuery(strSql, parms);
        }

        public int DeleteOrderInfoByOrdernumtwo(string ordernum, int Type, string memloginId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ordernum";
            parms[0].Value = ordernum.Trim();
            parms[1].ParameterName = "@memloginId";
            parms[1].Value = memloginId;
            string strSql = "update ShopNum1_OrderInfoTwo set BuyIsDeleted=1 where OrderNumber in (@ordernum) ";
            if (memloginId != "admin")
            {
                if (Type == 1)
                {
                    strSql = strSql + " and memloginId=@memloginId";
                }
                else
                {
                    strSql = strSql + " and shopid=@memloginId";
                }
            }
            return DatabaseExcetue.RunNonQuery(strSql, parms);
        }

        public DataTable SelectOrdernumber(string ordernumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ordernumber";
            parms[0].Value = ordernumber;

            string sql = "select MemLoginID,OderStatus,CreateTime,paytime,ShouldPayPrice,Score_pv_a   FROM [ShopNum1_OrderInfo] where OrderNumber=@ordernumber";
            return DatabaseExcetue.ReturnDataTable(sql, parms);
        }

        public DataTable SelectOrdernumberTwo(string ordernumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ordernumber";
            parms[0].Value = ordernumber;

            string sql = "select MemLoginID,OderStatus,CreateTime,paytime,ShouldPayPrice,Score_pv_a   FROM [ShopNum1_OrderInfoTwo] where OrderNumber=@ordernumber";
            return DatabaseExcetue.ReturnDataTable(sql, parms);
        }

        public DataTable GetMemLoginNo(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            string sql = "select MemLoginNo  FROM [Shopnum1].[dbo].[ShopNum1_Member] where MemLoginID=@MemLoginID";
            return DatabaseExcetue.ReturnDataTable(sql, parms);
        }

        public int AddProductByBTC(string ordernumber, string MemLoginNO, string CreateTime, string paytime, string ShouldPayPrice, string pv)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@ordernumber";
            paraValue[0] = ordernumber;
            paraName[1] = "@MemLoginNO";
            paraValue[1] = MemLoginNO;
            paraName[2] = "@CreateTime";
            paraValue[2] = CreateTime;
            paraName[3] = "@paytime";
            paraValue[3] = paytime;
            paraName[4] = "@ShouldPayPrice";
            paraValue[4] = ShouldPayPrice;
            paraName[5] = "@pv";
            paraValue[5] = pv;
            return DatabaseExcetue.RunProcedureGetInt("[47.52.115.221].[TJPS].[dbo].[pro_AddPVAShopnun1]", paraName, paraValue);
        }


        public DataTable SelectOrderOfAll(string OrderNo)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNo";
            parms[0].Value = OrderNo;
            return
                DatabaseExcetue.ReturnDataTable("Select * from shopnum1_orderinfo where (OrderNumber=@OrderNo or TradeID=@OrderNo)", parms);
        }

        public DataTable SearchOrderUpgrade(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("Select a.MemLoginNO,b.* from shopnum1_member as a left join shopnum1_orderinfo as b on a.MemLoginID=b.MemLoginID where b.PaymentStatus=1 and (b.Score_pv_a+a.[Score_record _pv_a])>=12000 and b.MemLoginID=@MemLoginID and b.PayTime>a.[Score_record _time] order by b.PayTime", parms);
        }

        public DataTable SearchOrderUpgradeSQ(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("Select a.MemLoginNO,a.RealName,b.* from shopnum1_member as a left join shopnum1_orderinfo as b on a.MemLoginID=b.MemLoginID where b.PaymentStatus=1 and b.ShouldPayPrice>=18000 and b.ShouldPayPrice<48000 and b.MemLoginID=@MemLoginID  order by b.PayTime", parms);
        }

        public DataTable SearchOrderUpgradeQD(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("Select a.MemLoginNO,a.RealName,b.* from shopnum1_member as a left join shopnum1_orderinfo as b on a.MemLoginID=b.MemLoginID where b.PaymentStatus=1 and b.ShouldPayPrice>=48000 and b.MemLoginID=@MemLoginID  order by b.PayTime", parms);
        }





        public DataTable GetAllStatus(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable("SELECT OderStatus,ShipmentStatus,PaymentStatus,IsDeleted   FROM ShopNum1_OrderInfo  WHERE Guid =@guid", parms);
        }


        public DataTable GetAllStatusByOrdernumber(string Ordernumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Ordernumber";
            parms[0].Value = Ordernumber.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable("SELECT MemLoginID,Guid,OderStatus,ShipmentStatus,PaymentStatus,IsDeleted   FROM ShopNum1_OrderInfo  WHERE OrderNumber =@Ordernumber", parms);
        }

        public string GetCode(string strOrderGuId)
        {
            return
                DatabaseExcetue.ReturnString("select IdentifyCode from shopnum1_orderinfo where guid='" + strOrderGuId + "'");
        }

        public DataTable GetCode(string member, int isinvalid, string code)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@member";
            parms[0].Value = member;
            parms[1].ParameterName = "@code";
            parms[1].Value = code;

            return
                DatabaseExcetue.ReturnDataTable("SELECT [key] from ShopNum1_MemberActivate Where MemberID=@membe And isinvalid=1 And [key]=@code", parms);
        }

        public DataTable GetCommentInfoAndSaleNumber(string guid, string shopid, string datatime)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@shopid";
            paraValue[1] = shopid;
            paraName[2] = "@datatime";
            paraValue[2] = datatime;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCommentInfoAndSaleNumber", paraName, paraValue);
        }

        public DataTable GetGroupPriceTotalByOrderInfoGuid(string orderinfoguid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@orderinfoguid";
            paraValue[0] = orderinfoguid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetGroupPriceTotalByOrderInfoGuid", paraName, paraValue);
        }

        public DataTable GetLifeOrderCount(string strMemLoginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemLoginID";
            paraValue[0] = strMemLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetLifeOrderCount_YueTao", paraName, paraValue);
        }

        public DataTable GetMemberBuyProductCount(string strmemberLoginID, string productguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@strmemberLoginID";
            parms[0].Value = strmemberLoginID;
            parms[1].ParameterName = "@productguid";
            parms[1].Value = productguid;
            return
                DatabaseExcetue.ReturnDataTable(("select isNull(count(a.guid),0) from  dbo.ShopNum1_OrderInfo  as a ,ShopNum1_OrderProduct as b  where a.Guid=b.OrderInfoGuid   and a.MemLoginID=@strmemberLoginID and b.ProductGuid=@productguid"), parms);
        }

        public DataTable GetOrderCountByGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_shop_GetOrderCountByGuid", paraName, paraValue);
        }

        public DataTable GetOrderCountByOrderNumber(string orderNumber)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@orderNumber";
            paraValue[0] = orderNumber;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_shop_GetOrderCountByOrderNumber", paraName, paraValue);
        }

        public DataSet GetOrderDetail(string strOrderGuId, string strMemloginId, string strOrderType, string strIsShop)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@OrderGuId";
            paraValue[0] = strOrderGuId;
            paraName[1] = "@MemloginId";
            paraValue[1] = strMemloginId;
            paraName[2] = "@OrderType";
            paraValue[2] = strOrderType;
            paraName[3] = "@IsShop";
            paraValue[3] = strIsShop;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetOrderDetail", paraName, paraValue);
        }
        /// <summary>
        /// 自己所有1245的订单
        /// </summary>
        /// <param name="strMemloginNO"></param>
        /// <returns></returns>
        public DataTable GetOrderLastInfoIsMy(string strMemloginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strMemloginId";
            parms[0].Value = strMemloginNO;

            return DatabaseExcetue.ReturnDataTable("select a.*, c.MemLoginNO,b.MemberRankGuid,b.MemLoginNO as lishuNO,b.ShopNames FROM ShopNum1_OrderInfo as a left join ShopNum1_Member as b on b.MemLoginNO=a.ServiceAgent left join ShopNum1_Member as c on c.MemLoginID=a.MemLoginID  where a.MemLoginID=@strMemloginId and a.shop_category_id in (1,4,2,5) and a.PaymentStatus=1", parms);
        }

        public DataTable GetOrderLastInfo(string strMemloginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strMemloginId";
            parms[0].Value = strMemloginNO;

            return DatabaseExcetue.ReturnDataTable("select a.*, c.MemLoginNO,b.MemberRankGuid,b.MemLoginNO as lishuNO,b.ShopNames FROM ShopNum1_OrderInfo as a left join ShopNum1_Member as b on b.MemLoginNO=a.ServiceAgent left join ShopNum1_Member as c on c.MemLoginID=a.MemLoginID  where c.Superior=@strMemloginId and a.shop_category_id in (1,4,2,5) and a.PaymentStatus=1", parms);
        }
        public DataTable GetOrderLastInfoShopName(string strMemloginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strMemloginId";
            parms[0].Value = strMemloginNO;

            return DatabaseExcetue.ReturnDataTable("select distinct(a.ServiceAgent),b.ShopNames FROM ShopNum1_OrderInfo as a left join ShopNum1_Member as b on b.MemLoginNO=a.ServiceAgent left join ShopNum1_Member as c on c.MemLoginID=a.MemLoginID  where c.Superior=@strMemloginId and a.shop_category_id in (1,4,2,5) and a.PaymentStatus=1", parms);
        }

        public DataTable SelectSuperior(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return DatabaseExcetue.ReturnDataTable("select Superior from ShopNum1_Member where MemLoginID=@MemLoginID", parms);
        }


        public DataTable GetAllApprovalReferral(string Referral)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Referral";
            parms[0].Value = Referral;

            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Referral where IsDelete=0 and Referral=@Referral", parms);
        }

        public DataTable GetAllApprovalReferralAndMemloginID(string Referral, string MemloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Referral";
            parms[0].Value = Referral;
            parms[1].ParameterName = "@MemloginID";
            parms[1].Value = MemloginID;
            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Referral where IsDelete=0 and Referral=@Referral and MemloginID=@MemloginID", parms);
        }

        public int DeleteShopNum1_Referral(string Referral, string MemloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@Referral";
            parms[0].Value = Referral;
            parms[1].ParameterName = "@MemloginID";
            parms[1].Value = MemloginID;

            try
            {
                return DatabaseExcetue.RunNonQuery("update  ShopNum1_Referral set IsDelete=1 where Referral=@Referral and MemloginID=@MemloginID", parms);

            }
            catch
            {
                return 0;
            }
        }

        public DataTable GetOrderGuidAndTypeByOrderNum(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            return
                DatabaseExcetue.ReturnDataTable("SELECT OrderType,Guid FROM ShopNum1_OrderInfo WHERE OrderNumber=@string_0", parms);
        }

        public DataTable GetOrderGuidByOrderNumberAndMemloginid(string ordernumber, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ordernumber";
            paraValue[0] = ordernumber;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderGuidByOrderNumberAndMemloginid", paraName, paraValue);
        }
        //根据ID查找所有订单
        public DataTable SearchOrderInfo_ID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT * FROM ShopNum1_OrderInfo where MemLoginID=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable GetOrderGuIdByTradeId(string strTradeid)
        {
            return
                DatabaseExcetue.ReturnDataTable("select A.guid,ordernumber,A.PaymentGuid,feeType,IdentifyCode,Mobile,a.score_reduce_pv_a,a.score_reduce_dv,a.score_reduce_hv,a.ShopID,a.score_reduce_pv_b,a.Score_pv_a,a.Score_hv,a.Score_dv,a.Score_cv,a.Score_max_hv,A.Score_pv_cv,a.Score_pv_b,A.MemloginId,A.shop_category_id from ShopNum1_orderinfo A  where tradeid='" + strTradeid + "'");
        }
        public DataTable GetOrderGuIdByordernumber(string strTradeid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strTradeid";
            parms[0].Value = strTradeid;
            return
                DatabaseExcetue.ReturnDataTable("select A.guid,ordernumber,feeType,IdentifyCode,Mobile,a.score_reduce_pv_a,a.score_reduce_dv,a.score_reduce_hv,a.score_reduce_pv_b,a.Score_pv_a,a.Score_dv,a.Score_hv,a.Score_cv,a.Score_max_hv,A.Score_pv_cv,a.Score_pv_b,A.MemloginId,A.shop_category_id from ShopNum1_orderinfo A where ordernumber=@strTradeid", parms);
        }
        /// <summary>
        /// 查询是否有交易成功的catrgory为1的订单
        /// </summary>
        /// <param name="strTradeid"></param>
        /// <returns></returns>
        public DataTable GetOrderByMemberIDFirst(string MemberID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemberID";
            parms[0].Value = MemberID;
            return
                DatabaseExcetue.ReturnDataTable("select Guid from ShopNum1_orderinfo where shop_category_id='1' and OderStatus in (1,2,3) and refundStatus=0 and MemLoginId=@MemberID", parms);
        }

        public DataTable GetOrderGuidByTradeIDAndMemloginid(string tradeid, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@tradeid";
            paraValue[0] = tradeid;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderGuidByTradeIDAndMemloginid", paraName, paraValue);
        }

        public int GetOrderIdentifyCodeIsEqual(string strOrderNumber, string strIdentifyCode)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@strOrderNumber";
            parms[0].Value = strOrderNumber;
            parms[1].ParameterName = "@strIdentifyCode";
            parms[1].Value = Operator.FilterString(strIdentifyCode);
            return
                ((DatabaseExcetue.ReturnDataTable("SELECT COUNT(0) FROM ShopNum1_OrderInfo WHERE OrderNumber=@strOrderNumbe AND IdentifyCode=@strIdentifyCode", parms).Rows.Count > 0)
                    ? 1 : 0);
        }

        public DataTable GetOrderInfo(string guid, string paymentmemloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@paymentmemloginid";
            paraValue[1] = paymentmemloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfo", paraName, paraValue);
        }

        public DataTable GetOrderInfoAndProductInfo(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.BuyPrice,A.BuyNumber,B.MinusFee,B.FeeType,B.FeeTemplateID,B.Post_fee,B.Ems_fee,B.Express_fee FROM ShopNum1_OrderProduct AS A,ShopNum1_Shop_Product AS B WHERE A.ProductGuid=B.Guid AND A.OrderInfoGuid=@guid";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SerchLiCaiOrderInfoAll(string OrderNumber)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT WorkDay,Profit,c.ProductName_EN,c.ProductName,ProductGuid,BuyNumber,ShouldPayPrice from ShopNum1_OrderInfo as b left join ShopNum1_OrderProduct as a on a.OrderInfoGuid=b.Guid left join Nec_LiCaiJiJin as c on c.ProductId=a.ProductGuid where b.OrderNumber=@OrderNumber";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@OrderNumber";
            paraValue[0] = OrderNumber;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SerchOrderInfoAll(string Guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT a.MemLoginNO,b.* from ShopNum1_OrderInfo as b left join ShopNum1_Member as a on a.MemLoginID=b.MemLoginID where b.TradeID=@Guid";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@Guid";
            paraValue[0] = Guid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SerchOrderInfoKCEAll(string Guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT * from ShopNum1_OrderInfoTwo  where OrderNumber=@Guid";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@Guid";
            paraValue[0] = Guid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SelectOrderRefund(string orderid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@orderid";
            paraValue[0] = orderid;
            string strSql = string.Empty;
            strSql =
                "select * from ShopNum1_OrderRefund where Ordernumber=@orderid";

            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }


        public DataTable SelectShopNum1_Member(string MemberID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemberID";
            paraValue[0] = MemberID;
            string strSql = string.Empty;
            strSql =
                "select * from ShopNum1_Member where MemLoginID=@MemberID";

            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }



        public DataTable GetOrderInfoByCode(string strMemLoginID, string strCode)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@MemLoginID";
            paraValue[0] = strMemLoginID;
            paraName[1] = "@LifeCode";
            paraValue[1] = strCode;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetOrderInfoByCode_YueTao", paraName, paraValue);
        }

        public DataTable GetOrderInfoByGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfoByGuid", paraName, paraValue);
        }

        public DataTable GetOrderInfoByGuidShop(string guid, string shopid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@shopid";
            paraValue[1] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfoByGuidShop", paraName,
                paraValue);
        }

        public DataTable GetOrderInfoByMemloginID(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfoByMemloginID", paraName,
                paraValue);
        }

        public string GetOrderNumberByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable("SELECT OrderNumber,Guid  FROM ShopNum1_OrderInfo  WHERE Guid=@guid", parms).Rows[0]["OrderNumber"].ToString();
        }

        public DataTable GetOrderProductGuidAndByNumber(string orderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@orderNumber";
            parms[0].Value = Operator.FilterString(orderNumber);
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT ProductGuid,BuyNumber  FROM ShopNum1_OrderProduct  WHERE OrderInfoGuid In (SELECT Guid FROM ShopNum1_OrderInfo Where OrderNumber =@orderNumber)", parms);
        }

        public DataTable GetOrderStatusAndNumberByGuid(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));
            string str = string.Empty;
            str = "SELECT OrderNumber,OderStatus   FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guids != "-1")
            {
                str = str + " AND Guid" + andSql;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC", parms.ToArray());
        }

        public DataTable GetOtherOrderInfoByTradeID(string tradeid, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@tradeid";
            paraValue[0] = tradeid;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOtherOrderInfoByTradeID", paraName,
                paraValue);
        }

        public string GetPayMentMemLoginIDByOrderGuid(string orderguid)
        {
            return
                DatabaseExcetue.ReturnString("SELECT PayMentMemLoginID FROM ShopNum1_OrderInfo WHERE guid='" + orderguid +
                                             "'");
        }

        public DataTable GetProductGuidAndBuyNum(string orderGuid)
        {
            string strSql = "SELECT ProductGuid,BuyNumber FROM dbo.ShopNum1_OrderProduct WHERE OrderInfoGuid=@orderGuid";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@orderGuid";
            paraValue[0] = orderGuid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable GetProductInfoAndOrderProductInfo(string guid, string shopid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.PayMentGuid,A.ShouldPayPrice,A.DispatchType,C.FeeTemplateID,C.FeeType,C.Post_fee,C.Express_fee,C.Ems_fee,B.BuyNumber FROM ShopNum1_OrderInfo AS A, ShopNum1_OrderProduct AS B,ShopNum1_Shop_Product AS C WHERE A.Guid=B.OrderInfoGuid AND B.ProductGuid=C.Guid AND B.OrderInfoGuid=@guid AND B.ShopID=@ShopID";
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@ShopID";
            paraValue[1] = shopid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataSet getProductOrderRecord(string ProductGuid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ProductGuid";
            paraValue[0] = ProductGuid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", paraName, paraValue);
        }

        public DataSet getProductOrderRecord(string ProductGuid, string OderStatus)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ProductGuid";
            paraValue[0] = ProductGuid;
            paraName[1] = "@OderStatus";
            paraValue[1] = OderStatus;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", paraName, paraValue);
        }

        public DataSet getProductOrderRecord(string productguid, string oderstatus, string memloginid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@productguid";
            paraValue[0] = productguid;
            paraName[1] = "@oderstatus";
            paraValue[1] = oderstatus;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", paraName, paraValue);
        }

        public DataTable GetProductTypeByOrderGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT IsPanicBuy,IsSpellBuy FROM dbo.ShopNum1_Shop_Product WHERE Guid=(SELECT ProductGuid FROM ShopNum1_OrderProduct WHERE OrderInfoGuid=@guid)", parms);
        }

        public DataTable GetRestoreOrderByMemLoginID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable(
                    ("SELECT distinct A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.ShipmentStatus,A.PaymentStatus,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.ProductPrice,A.AlreadPayPrice,A.ShopID,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchTime,A.ShipmentNumber,A.PayMemo,A.BuyIsDeleted  FROM ShopNum1_OrderInfo AS A  WHERE A.BuyIsDeleted=1 AND MemloginId=@memLoginID") + " ORDER BY CreateTime DESC", parms);
        }

        public string GetShopIDByOrderGuid(string orderguid)
        {
            return DatabaseExcetue.ReturnString("SELECT ShopID FROM ShopNum1_OrderInfo WHERE guid='" + orderguid + "'");
        }

        public int MemberDelete(string guids, string filedName, string filedvalue)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guids";
            paraValue[0] = guids;
            paraName[1] = "@filedvalue";
            paraValue[1] = filedvalue;
            paraName[2] = "@filedName";
            paraValue[2] = filedName;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_OrderInfoMemberDel", paraName, paraValue);
        }

        public DataTable OrderInfoApplyCheck(string OrderNumber)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@OrderNumber";
            paraValue[0] = OrderNumber;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_OrderInfoApplyCheck", paraName, paraValue);
        }

        public DataSet OrderInfoGetSimpleByTradeID(string tradeid, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@tradeid";
            paraValue[0] = tradeid;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_OrderInfoGetSimpleByTradeID", paraName,
                paraValue);
        }

        public int OrderInfoLogistics(string guid, string islogistics, string logisticscompany,
            string logisticscompanycode, string shipmentnumber)
        {
            string str = "0";
            if (ShopSettings.GetValue("DecreaseRepertory") == "1")
            {
                str = "1";
            }
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@islogistics";
            paraValue[1] = islogistics;
            paraName[2] = "@logisticscompany";
            paraValue[2] = logisticscompany;
            paraName[3] = "@logisticscompanycode";
            paraValue[3] = logisticscompanycode;
            paraName[4] = "@shipmentnumber";
            paraValue[4] = shipmentnumber;
            paraName[5] = "@isDecreaseRepertory";
            paraValue[5] = str;
            paraName[6] = "@DispatchTime";
            paraValue[6] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return DatabaseExcetue.RunProcedure("Pro_Shop_OrderInfoLogistics", paraName, paraValue);
        }

        public DataTable Search(int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT Guid,Name,Memo,Charge,IsPercent  FROM ShopNum1_Payment  WHERE 1=1 ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By OrderID Desc");
        }

        public DataTable Search(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.shop_category_id,A.ShipmentStatus,A.PaymentStatus,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.PackGuid,A.PackName,A.BlessCardGuid,A.BlessCardName,A.BlessCardContent,A.InvoiceTitle,A.InvoiceContent,A.ProductPrice,A.DispatchPrice,A.PaymentPrice,A.PackPrice,A.BlessCardPrice,A.AlreadPayPrice,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.FromAd,A.FromUrl,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchType,A.DispatchTime,A.ShipmentNumber,A.BuyType,A.ActivityGuid,A.PayMemo,A.InvoiceType,A.InvoiceTax,A.Discount,A.Deposit,A.JoinActiveType,A.ActvieContent,A.UsedFavourTicket,A.IsDeleted,A.ShopID,A.ShopName,A.RegionCode  FROM ShopNum1_OrderInfo AS A  WHERE 1=1 ";
            if (guid != "-1")
            {
                strSql = string.Concat(new object[] { strSql, " AND A.Guid='", new Guid(guid), "'" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string orderNumber, string memLoginID, string name, string address, string postalcode,
            string string_0, string mobile, string email, decimal shouldPayPrice1,
            decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted,
            string shopID, string shopName, string orderStatus, string orderType)
        {
            string str = string.Empty;
            str =
                "SELECT DISTINCT A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.OrderType,A.ShipmentStatus,A.PaymentStatus,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.PackGuid,A.PackName,A.BlessCardGuid,A.BlessCardName,A.BlessCardContent,A.InvoiceTitle,A.InvoiceContent,A.ProductPrice,A.DispatchPrice,A.PaymentPrice,A.PackPrice,A.BlessCardPrice,A.AlreadPayPrice,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.FromAd,A.FromUrl,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchTime,A.ShipmentNumber,A.BuyType,A.ActivityGuid,A.PayMemo,A.InvoiceType,A.InvoiceTax,A.Discount,A.ShopID,A.ShopName,A.IsDeleted,B.IsPanicBuy,B.IsSpellBuy,A.shop_category_id,c.BuyNumber ,c.ProductName,c.ShopPrice,(A.ShouldPayPrice-A.Offset_pv_b) as PaidPrice,(A.ShouldPayPrice-A.DispatchPrice) as ProductAllPrice,A.Score_pv_a,A.Score_pv_b  FROM ShopNum1_OrderInfo AS A,ShopNum1_Shop_Product AS B,ShopNum1_OrderProduct AS C  WHERE A.Guid=C.OrderInfoGuid AND C.ProductGuid=B.Guid ";
            if (Operator.FormatToEmpty(orderNumber) != string.Empty)
            {
                str = str + " AND A.OrderNumber LIKE '%" + Operator.FilterString(orderNumber) + "%'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND A.Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if (Operator.FormatToEmpty(address) != string.Empty)
            {
                str = str + " AND A.Address LIKE '%" + Operator.FilterString(address) + "%'";
            }
            if (Operator.FormatToEmpty(postalcode) != string.Empty)
            {
                str = str + "AND A.Postalcode LIKE '%" + Operator.FilterString(postalcode) + "%'";
            }
            if (Operator.FormatToEmpty(string_0) != string.Empty)
            {
                str = str + " AND A.Tel LIKE '%" + Operator.FilterString(string_0) + "%'";
            }
            if (Operator.FormatToEmpty(mobile) != string.Empty)
            {
                str = str + " AND A.Mobile LIKE '%" + Operator.FilterString(mobile) + "%'";
            }
            if (Operator.FormatToEmpty(email) != string.Empty)
            {
                str = str + " AND A.Email LIKE '%" + Operator.FilterString(email) + "%'";
            }
            if (orderType != "-1")
            {
                str = str + " AND A.OrderType=" + orderType + " ";
            }
            if (orderStatus != "-1")
            {
                str = str + " AND A.OderStatus=" + orderStatus;
            }
            if (Operator.FormatToEmpty(createTime1) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(createTime1) + "' ";
            }
            if (Operator.FormatToEmpty(createTime2) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(createTime2) + "' ";
            }
            if (shouldPayPrice1 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.ShouldPayPrice>='", shouldPayPrice1, "' " });
            }
            if (shouldPayPrice2 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.ShouldPayPrice<='", shouldPayPrice2, "' " });
            }
            if (Operator.FormatToEmpty(shopID) != string.Empty)
            {
                str = str + " AND A.ShopID  Like'" + Operator.FilterString(shopID) + "' ";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                str = str + " AND A.ShopName  Like'" + Operator.FilterString(shopName) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY A.CreateTime DESC");
        }

        public DataTable Search(string orderNumber, string memLoginID, string name, string address, string postalcode,
            string string_0, string mobile, string email, decimal shouldPayPrice1,
            decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted,
            string shopID, string shopName, string orderStatus, string orderType,
            string paymentStatus, string shipmentStatus)
        {
            string str = string.Empty;
            str =
                "SELECT DISTINCT A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.OrderType,A.ShipmentStatus,A.PaymentStatus,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.PackGuid,A.PackName,A.BlessCardGuid,A.BlessCardName,A.BlessCardContent,A.InvoiceTitle,A.InvoiceContent,A.ProductPrice,A.DispatchPrice,A.PaymentPrice,A.PackPrice,A.BlessCardPrice,A.AlreadPayPrice,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.FromAd,A.FromUrl,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchTime,A.ShipmentNumber,A.BuyType,A.ActivityGuid,A.PayMemo,A.InvoiceType,A.InvoiceTax,A.Discount,A.ShopID,A.ShopName,A.IsDeleted,B.IsPanicBuy,B.IsSpellBuy  FROM ShopNum1_OrderInfo AS A,ShopNum1_Shop_Product AS B,ShopNum1_OrderProduct AS C  WHERE A.Guid=C.OrderInfoGuid AND C.ProductGuid=B.Guid ";
            if (Operator.FormatToEmpty(orderNumber) != string.Empty)
            {
                str = str + " AND A.OrderNumber LIKE '%" + Operator.FilterString(orderNumber) + "%'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND A.Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if (Operator.FormatToEmpty(address) != string.Empty)
            {
                str = str + " AND A.Address LIKE '%" + Operator.FilterString(address) + "%'";
            }
            if (Operator.FormatToEmpty(postalcode) != string.Empty)
            {
                str = str + "AND A.Postalcode LIKE '%" + Operator.FilterString(postalcode) + "%'";
            }
            if (Operator.FormatToEmpty(string_0) != string.Empty)
            {
                str = str + " AND A.Tel LIKE '%" + Operator.FilterString(string_0) + "%'";
            }
            if (Operator.FormatToEmpty(mobile) != string.Empty)
            {
                str = str + " AND A.Mobile LIKE '%" + Operator.FilterString(mobile) + "%'";
            }
            if (Operator.FormatToEmpty(email) != string.Empty)
            {
                str = str + " AND A.Email LIKE '%" + Operator.FilterString(email) + "%'";
            }
            if (orderType != "-1")
            {
                str = str + " AND A.OrderType=" + orderType + " ";
            }
            if (orderStatus != "-1")
            {
                str = str + " AND A.OderStatus=" + orderStatus;
            }
            if (Operator.FormatToEmpty(createTime1) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(createTime1) + "' ";
            }
            if (Operator.FormatToEmpty(createTime2) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(createTime2) + "' ";
            }
            if (shouldPayPrice1 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.ShouldPayPrice>='", shouldPayPrice1, "' " });
            }
            if (shouldPayPrice2 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.ShouldPayPrice<='", shouldPayPrice2, "' " });
            }
            if (Operator.FormatToEmpty(shopID) != string.Empty)
            {
                str = str + " AND A.ShopID  Like'" + Operator.FilterString(shopID) + "' ";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                str = str + " AND A.ShopName  Like'" + Operator.FilterString(shopName) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=", isDeleted, " " });
            }
            if (paymentStatus != "-1")
            {
                str = str + " AND A.paymentStatus=" + paymentStatus + " ";
            }
            if (shipmentStatus != "-1")
            {
                str = str + " AND A.shipmentStatus=" + shipmentStatus + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY A.CreateTime DESC");
        }

        public DataTable Search1(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            string strSql = string.Empty;
            strSql =
                "SELECT Guid,PayMentMemLoginID,Name,Email,Address,Postalcode,Tel,Mobile,RegionCode,OrderNumber,TradeID,OderStatus,CreateTime,PaymentStatus,ShipmentStatus,PaymentGuid,PaymentName,DispatchPrice,DispatchType,ProductPrice,PaymentPrice,ShouldPayPrice,IsDeleted,ShopID,ShopName,AlipayTradeId  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guid != "-1")
            {
                strSql = strSql + " AND Guid=@guid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchAddressByGuid(string guid)
        {
            string strSql = string.Empty;
            strSql = "SELECT Guid,Name,Email,Address,Postalcode,Tel,Mobile  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guid != "-1")
            {
                strSql = string.Concat(new object[] { strSql, " AND Guid='", new Guid(guid), "'" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchByMemLoginID(string memLoginID, int type)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = Operator.FilterString(memLoginID);
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT Guid,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,ProductPrice,AlreadPayPrice,ShopID,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,PayMemo,BuyIsDeleted  FROM ShopNum1_OrderInfo  WHERE  MemLoginID=@memLoginID AND BuyIsDeleted=0 AND OrderType=@type ORDER BY CreateTime DESC"
                    }), parms);
        }

        public DataTable SearchByMemLoginID(string productname, string orderstatus, string ordernumber, string timestart,
            string timeend, string shopid, string memLoginID, int type)
        {
            string str = string.Empty;
            str =
                "SELECT distinct A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.ShipmentStatus,A.PaymentStatus,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.ProductPrice,A.AlreadPayPrice,A.ShopID,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchTime,A.ShipmentNumber,A.PayMemo,A.BuyIsDeleted  FROM ShopNum1_OrderInfo AS A ,ShopNum1_OrderProduct AS B  WHERE A.Guid=B.OrderInfoGuid AND A.BuyIsDeleted=0 ";
            if (productname != "-1")
            {
                str = str + " AND B.Name LIKE '" + productname + "%' ";
            }
            if (orderstatus != "-1")
            {
                str = str + " AND A.OderStatus=" + orderstatus + " ";
            }
            if (ordernumber != "-1")
            {
                str = str + " AND A.OrderNumber='" + ordernumber + "' ";
            }
            if (timestart != "")
            {
                str = str + " AND A.CreateTime>='" + timestart + "' ";
            }
            if (timeend != "")
            {
                str = str + " AND A.CreateTime<='" + timeend + "' ";
            }
            if (shopid != "-1")
            {
                str = str + " AND A.ShopID='" + shopid + "' ";
            }
            if (memLoginID != "-1")
            {
                str = str + " AND A.MemLoginID='" + memLoginID + "' ";
            }
            if (type != -1)
            {
                object obj2 = str;
                str = string.Concat(new[] { obj2, " AND A.OrderType=", type, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC");
        }

        public DataTable SearchNewOrderByMemLoginID(string memloginID, string showcount)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@showcount";
            parms[1].Value = showcount;
            return
                DatabaseExcetue.ReturnDataTable("SELECT TOP  @showcount Guid,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,IsDeleted  FROM ShopNum1_OrderInfo  WHERE MemLoginID=@memloginID ORDER BY CreateTime DESC", parms);
        }

        public DataTable SearchOrder(string orderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@orderNumber";
            parms[0].Value = Operator.FilterString(orderNumber);
            string strSql = string.Empty;
            strSql =
                "SELECT OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Guid ,memloginID ,createtime ,PaymentName ,PayTime ,ShipmentNumber ,FromUrl ,InvoiceType ,InvoiceTitle ,InvoiceContent ,ClientToSellerMsg ,SellerToClientMsg ,Name ,Email ,Address, Postalcode ,Tel ,Mobile, InvoiceTax,DispatchPrice,PaymentPrice,AlreadPayPrice,SurplusPrice,ScorePrice  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (Operator.FormatToEmpty(orderNumber) != string.Empty)
            {
                strSql = strSql + " AND OrderNumber=@orderNumber";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchOrderInfo(string orderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@orderNumber";
            parms[0].Value = orderNumber;
            string str = string.Empty;
            str =
                "SELECT A.*,ProductName,BuyNumber  FROM ShopNum1_OrderInfo A inner Join ShopNum1_OrderProduct B on B.orderinfoguid=A.guid   WHERE 0=0 ";
            return DatabaseExcetue.ReturnDataTable(str + " AND TradeId=@orderNumber", parms);
        }

        public DataTable SearchOrderInfoByGuid(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));
            string str = string.Empty;
            str =
                "SELECT Guid,MemLoginID,OrderNumber,OderStatus,PayMentMemLoginID,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,BuyIsDeleted  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guids != "-1")
            {
                str = str + " AND Guid" + andSql;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC", parms.ToArray());
        }

        public DataTable SearchOrderInfoByGuid(string guids, string OrderType)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@OrderType";
            parm.Value = OrderType;
            parms.Add(parm);
            string str = string.Empty;
            str =
                "SELECT Guid,ShopID,ShopName,OrderType,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,BuyIsDeleted  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guids != "-1")
            {
                str = str + " AND Guid in " + andSql;
            }
            if (OrderType != "-1")
            {
                str = str + " AND OrderType =@OrderType";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC", parms.ToArray());
        }

        public string SearchOrderInfoByOrderId(string strorderId, string strcolumn)
        {
            string strSql = "select " + strcolumn + " from ShopNum1_OrderInfo where 1=1";
            if (strorderId != "")
            {
                strSql = strSql + " and guid='" + strorderId + "'";
            }
            return DatabaseExcetue.ReturnString(strSql);
        }

        public DataTable SelectOrderTime(string ordernumber)
        {
            string strSql = "select * from ShopNum1_OrderInfo where 1=1 and guid='" + ordernumber + "'";

            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchOrderInfoByOrdernum(string ordernum, string orderType)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ordernum";
            parms[0].Value = ordernum.Trim();
            parms[1].ParameterName = "@orderType";
            parms[1].Value = orderType;
            string str = string.Empty;
            str =
                "SELECT Guid,ShopID,ShopName,OrderType,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,BuyIsDeleted,Feetype   FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (ordernum != "-1")
            {
                str = str + " AND OrderNumber in (@ordernum) ";
            }
            if (orderType == "-2")
            {
                str = str + " AND feetype=2 ";
            }
            else if (orderType != "-1")
            {
                str = str + " AND OrderType =@orderType";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC", parms);

        }

        public DataTable selectSuperior(string memberloginid)
        {


            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memberloginid";
            parms[0].Value = memberloginid;
            return DatabaseExcetue.ReturnDataTable("select Superior,MemberRankGuid FROM [ShopNum1].[dbo].[ShopNum1_Member] where MemLoginID=@memberloginid", parms);
        }

        public DataTable SearchOrderInfoByOrdernum(string ordernum, string orderType, string strCondition)
        {
            string str = string.Empty;
            str =
                "  SELECT distinct c.Guid,d.BuyNumber ,d.ProductName,c.refundstatus as Rec,ds.RefundType,c.ShopID,c.ShopName,c.OrderType,c.MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,c.CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,BuyIsDeleted,Feetype,d.shop_category_id,(d.ShopPrice*d.BuyNumber) as ShopTotal,(d.ShopPrice*d.BuyNumber) as ShopTotal,d.ShopPrice,(c.ShouldPayPrice-c.Offset_pv_b) as PaidPrice,(c.ShouldPayPrice-c.DispatchPrice) as ProductAllPrice,c.Score_pv_a,c.Score_pv_b  FROM ShopNum1_OrderInfo as c Left   Outer  join [ShopNum1_OrderProduct] as d  on d.OrderInfoGuid=c.guid  left join  [ShopNum1_Refund] as ds on c.Guid=ds.[OrderID]  WHERE 0=0  ";
            if (ordernum != "-1")
            {
                str = str + " AND OrderNumber in (" + ordernum.Trim() + ") ";
            }
            if (orderType == "-2")
            {
                str = str + " AND feetype=2 ";
            }
            else if (orderType != "-1")
            {
                str = str + " AND OrderType =" + orderType + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + strCondition + " ORDER BY PayTime DESC");
        }

        public DataTable SearchOrderInfoByOrdernumFinance(string ordernum, string orderType, string strCondition)
        {
            string str = string.Empty;
            str =
                "SELECT distinct soi.[Guid] as [Guid],refundstatus as Rec,soi.ShopID,soi.ShopName,soi.OrderType,soi.MemLoginID,OrderNumber,soi.OderStatus as OderStatus,soi.ShipmentStatus as ShipmentStatus,soi.PaymentStatus as PaymentStatus,soi.Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,soi.CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,BuyIsDeleted,soi.Feetype,(ShouldPayPrice-Offset_pv_b) as PaidPrice,(ShouldPayPrice-DispatchPrice) as ProductAllPrice,soi.Score_pv_a,(soi.Score_pv_b-Deduction_hv) as Score_pv_b,soi.shop_category_id,sol.OperateDateTime as OperateDateTime,Deduction_hv ,(select sum(myprice * k.buynumber) from ShopNum1_Shop_ProductPrice left join (select id,ShopNum1_OrderProduct.BuyNumber from ShopNum1_OrderInfo left join ShopNum1_OrderProduct on ShopNum1_OrderInfo.Guid = ShopNum1_OrderProduct.OrderInfoGuid left join ShopNum1_Shop_Product on ShopNum1_OrderProduct.ProductGuid = ShopNum1_Shop_Product.Guid where ShopNum1_OrderInfo.Guid = soi.guid  ) as k on productId = k.id where ShopNum1_Shop_ProductPrice.shop_category_id=soi.shop_category_id)as myprice FROM ShopNum1_OrderInfo as soi left join ShopNum1_OrderOperateLog as sol on soi.Guid=sol.Guid left join  ShopNum1_OrderProduct as a on a.[OrderInfoGuid]=soi.[Guid] left join ShopNum1_Shop_Product as b on b.[Guid]=a.ProductGuid left join ShopNum1_Shop_ProductPrice as c on c.productId=b.Id  WHERE 0=0 ";
            if (ordernum != "-1")
            {
                str = str + " AND soi.OrderNumber in (" + ordernum.Trim() + ") ";
            }
            if (orderType == "-2")
            {
                str = str + " AND soi.feetype=2 ";
            }
            else if (orderType != "-1")
            {
                str = str + " AND soi.OrderType =" + orderType + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + strCondition + " ORDER BY soi.PayTime DESC");
        }


        public DataTable SearchOrderInfoByOrdernumFinanceeeeeeeeeeeeeeeeee(string ordernum, string orderType, string strCondition)
        {
            string str = string.Empty;
            str = "  select OrderNumber,ShopID,MemLoginID,ShouldPayPrice,ShopName,PayTime,shop_category_id,Mobile,CreateTime,OrderType,Feetype ,'0' as MemberRankGuid,OderStatus,PaymentName,DispatchPrice,(ShouldPayPrice-DispatchPrice) as ProductAllPrice,ShouldPayPrice,Deduction_hv,(ShouldPayPrice-Offset_pv_b) as PaidPrice,Score_pv_a,Score_pv_b,0 as myprice FROM  [Shopnum1].[dbo].[ShopNum1_OrderInfo] WHERE    [refundStatus]!=1 and  OderStatus in (1,2,3) and guid not in ( select OrderID from [Shopnum1].[dbo].[ShopNum1_Refund] where RefundStatus  not in (2)) ";
            if (ordernum != "-1")
            {
                str = str + " AND OrderNumber in (" + ordernum.Trim() + ") ";
            }
            if (orderType == "-2")
            {
                str = str + " AND feetype=2 ";
            }
            else if (orderType != "-1")
            {
                str = str + " AND OrderType =" + orderType + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + strCondition + " ORDER BY PayTime DESC");
        }
        public int insertcomputer(string guid, string EnterName, decimal LabelOrderPriceValue, string LabelOrderNumberValue, string LabelMemLoginIDValueShow)
        {
            var array = new string[5];
            var array2 = new string[5];
            array[0] = "@guid";
            array2[0] = guid;
            array[1] = "@EnterName";
            array2[1] = EnterName;
            array[2] = "@LabelOrderPriceValue";
            array2[2] = LabelOrderPriceValue.ToString();
            array[3] = "@LabelOrderNumberValue";
            array2[3] = LabelOrderNumberValue;
            array[4] = "@LabelMemLoginIDValueShow";
            array2[4] = LabelMemLoginIDValueShow;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_insertcomputer ", array, array2);
        }
        public DataTable ststus(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            string strSql = string.Empty;
            strSql =
                "select shop_category_id, OderStatus from [ShopNum1_OrderInfo] where guid=@guid";

            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }
        public DataTable SearchOrderInfoByOrdernumFinanceTK(string ordernum, string orderType, string strCondition)
        {
            string str = string.Empty;
            str =
                " SELECT distinct soi.Guid as Guid,refundstatus as Rec,ShopID,ShopName,OrderType,MemLoginID,OrderNumber,soi.OderStatus as OderStatus,soi.ShipmentStatus as ShipmentStatus,soi.PaymentStatus as PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,BuyIsDeleted,Feetype,(ShouldPayPrice-Offset_pv_b) as PaidPrice,(ShouldPayPrice-DispatchPrice) as ProductAllPrice,Score_pv_a,(Score_pv_b-Deduction_hv) as Score_pv_b,shop_category_id,sol.OperateDateTime as OperateDateTime,Deduction_hv FROM ShopNum1_OrderInfo as soi left join ShopNum1_OrderOperateLog as sol on soi.Guid=sol.OrderInfoGuid  WHERE 0=0  and (sol.OderStatus=2 and (CurrentStateMsg='卖家同意退款' or  CurrentStateMsg='平台介入同意退款'))";
            if (ordernum != "-1")
            {
                str = str + " AND soi.OrderNumber in (" + ordernum.Trim() + ") ";
            }
            if (orderType == "-2")
            {
                str = str + " AND soi.feetype=2 ";
            }
            else if (orderType != "-1")
            {
                str = str + " AND soi.OrderType =" + orderType + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + strCondition + " ORDER BY soi.PayTime DESC");
        }

        public DataTable SearchOrderInfoByProductGuid(string productguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@productguid";
            parms[0].Value = productguid;

            string str = string.Empty;
            str = "SELECT MemLoginID  FROM ShopNum1_OrderProduct  WHERE 0=0 ";
            if (productguid != "-1")
            {
                str = str + " AND ProductGuid in (@productguid)";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC", parms);
        }

        public DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus,
            string timebegin, string timeend, string PaymentTypeGuid)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@ordernumber";
            paraValue[1] = ordernumber;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            paraName[3] = "@oderstatus";
            paraValue[3] = oderstatus;
            paraName[4] = "@timebegin";
            paraValue[4] = timebegin;
            paraName[5] = "@timeend";
            paraValue[5] = timeend;
            paraName[6] = "@paymentGuid";
            paraValue[6] = PaymentTypeGuid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchOrderInfoList", paraName, paraValue);
        }

        public DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus,
            string ordertype, string timebegin, string timeend, string PaymentTypeGuid)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@ordernumber";
            paraValue[1] = ordernumber;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            paraName[3] = "@oderstatus";
            paraValue[3] = oderstatus;
            paraName[4] = "@timebegin";
            paraValue[4] = timebegin;
            paraName[5] = "@timeend";
            paraValue[5] = timeend;
            paraName[6] = "@paymentGuid";
            paraValue[6] = PaymentTypeGuid;
            paraName[7] = "@ordertype";
            paraValue[7] = ordertype;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchOrderInfoList2", paraName, paraValue);
        }

        public DataTable SearchOrderPayInfo(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.Guid,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.RegionCode,A.OrderNumber,A.TradeID,A.OderStatus,A.CreateTime,A.PaymentStatus,A.ShipmentStatus,A.PaymentGuid,A.PaymentName,B.IsPercent,B.Charge,A.DispatchPrice,A.DispatchType,A.ProductPrice,A.PaymentPrice,A.ShouldPayPrice,A.IsDeleted,A.ShopID,A.ShopName  FROM ShopNum1_OrderInfo  AS A,ShopNum1_Payment AS B  WHERE A.PaymentGuid=B.Guid AND a.Guid =@guid";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SearchOrderPayInfo(string guid, string memLoginID)
        {
            string str = string.Empty;
            if (memLoginID.ToLower() == "admin")
            {
                str = "ShopNum1_Payment";
            }
            else
            {
                str = "ShopNum1_ShopPayment";
            }
            string strSql = string.Empty;
            strSql =
                "SELECT C.Email AS ShopEmail,C.Tel AS ShopTel,C.AddressValue AS ShopAddress,A.Guid,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.RegionCode,A.OrderNumber,A.TradeID,A.OderStatus,A.CreateTime,A.PayTime,A.DispatchTime,A.ReceiptTime,A.ReceivedDays,A.IsMemdelay,A.PaymentStatus,A.ShipmentStatus,A.PaymentGuid,A.PaymentName,B.IsPercent,B.Charge,A.DispatchPrice,A.DispatchType,A.ProductPrice,A.PaymentPrice,A.ShouldPayPrice,A.ClientToSellerMsg,A.SellerToClientMsg,A.IsDeleted,A.ShopID,A.FeeType,A.IsMinus,A.IsLogistics,A.LogisticsCompanyCode,A.ShipmentNumber,A.LogisticsCompany,A.ShopName  FROM ShopNum1_ShopInfo AS C, ShopNum1_OrderInfo  AS A left join " +
                str + " AS B on A.PaymentGuid=B.Guid WHERE a.Guid =@guid AND C.MemLoginID=A.ShopID";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SearchOrderProductByOrderGuid(string orderguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@orderguid";
            parms[0].Value = orderguid;
            string strSql = string.Empty;
            strSql =
                "SELECT a.ProductGuid,a.Name,a.ShopID,a.MemLoginID,b.OriginalImage  FROM ShopNum1_OrderProduct as a,ShopNum1_Shop_Product as b  WHERE a.ProductGuid=b.Guid";
            if (orderguid != "-1")
            {
                strSql = strSql + " AND a.OrderInfoGuid in (@orderguid)";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchOrderShouldPrice(string guid)
        {
            string strSql = string.Empty;
            strSql = "SELECT ShouldPayPrice,ShopID ,ProductPrice FROM ShopNum1_OrderInfo WHERE Guid =@guid";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SearchOrderSimpleProduct(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT  A.ProductGuid,B.ThumbImage,A.MemLoginID,B.MemLoginID AS ShopMemLoginID,A.[ProductName],A.BuyPrice,A.BuyNumber,B.MinusFee,B.FeeType,C.DispatchPrice,C.IsMinus,C.DispatchType FROM ShopNum1_OrderProduct AS A, ShopNum1_Shop_Product AS B,ShopNum1_OrderInfo AS C WHERE A.ProductGuid=B.Guid AND A.OrderInfoGuid=C.Guid AND A.OrderInfoGuid=@guid";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SearchOrderSimpleProduct(string guid, string shopid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            parms[1].ParameterName = "@shopid";
            parms[1].Value = shopid;
            string strSql = string.Empty;
            strSql =
                "SELECT b.ProductName, b.BuyPrice, b.BuyNumber,a.Score_dv,a.score_reduce_pv_a   FROM ShopNum1_OrderInfo a,ShopNum1_OrderProduct b  WHERE a.Guid=b.OrderInfoGuid ";
            if (guid != "-1")
            {
                strSql = strSql + " AND a.Guid=@guid";
            }
            if (guid != string.Empty)
            {
                strSql = strSql + " AND a.ShopID=@shopid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchOtherByGuid(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT Guid,ClientToSellerMsg,SellerToClientMsg,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,OutOfStockOperate,InvoiceType   FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guid != "-1")
            {
                strSql = string.Concat(new object[] { strSql, " AND Guid='", new Guid(guid), "'" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchPriceByGuid(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT Guid,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,InvoiceTax,Discount,InvoiceType  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guid != "-1")
            {
                strSql = string.Concat(new object[] { strSql, " AND Guid='", new Guid(guid), "'" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataSet SearchProductOrderRecord(string productguid, string memloginid, int category)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@productguid";
            paraValue[0] = productguid;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            paraName[2] = "@category";
            paraValue[2] = category.ToString();
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchProductOrderRecord", paraName,
                paraValue);
        }

        public DataTable SearchShipmentStatus1(string dispatchTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@dispatchTime";
            parms[0].Value = Operator.FilterString(dispatchTime);

            string strSql = string.Empty;
            strSql =
                "SELECT OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,ShipmentNumber, DispatchTime   FROM ShopNum1_OrderInfo  WHERE 0=0 AND  ShipmentStatus =1 ";
            if (Operator.FormatToEmpty(dispatchTime) != string.Empty)
            {
                strSql = strSql + " AND DispatchTime>=@dispatchTime";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchStatus(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            string strSql = string.Empty;
            strSql = "SELECT Guid,OderStatus,ShipmentStatus,PaymentStatus  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
            if (guid != "-1")
            {
                strSql = strSql + " AND ordernumber=@guid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SelectList(string strcondition)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strcondition";
            parms[0].Value = strcondition;
            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_OrderInfo where  1=1  @strcondition", parms);
        }

        public DataTable SelectListMJC(string pagesize, string currentpage, string condition, string resultnum,
    string strOrderColumn, string strSortV)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_OrderInfoTwo as c";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = strOrderColumn;
            paraName[6] = "@sortvalue";
            paraValue[6] = strSortV;
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two_MJC", paraName, paraValue);
        }
        public DataTable SelectList_order(string pagesize, string currentpage, string condition, string resultnum,
            string strOrderColumn, string strSortV)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_OrderInfo as c";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = strOrderColumn;
            paraName[6] = "@sortvalue";
            paraValue[6] = strSortV;
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two_order", paraName, paraValue);
        }
        public DataTable SelectList(string pagesize, string currentpage, string condition, string resultnum,
            string strOrderColumn, string strSortV)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_OrderInfo as c";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = strOrderColumn;
            paraName[6] = "@sortvalue";
            paraValue[6] = strSortV;
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectOrderList(string pagesize, string currentpage, string condition, string resultnum,
            string strProName)
        {
            string str =
                "SELECT A.paytime,c.category_name,d.refundstatus as vrefund,d.refundtype,A.shop_category_id,A.Guid,A.shouldpayprice,A.memloginid,A.ordernumber,A.oderstatus,A.shipmentstatus,A.paymentstatus,A.refundstatus,A.ordertype,A.shopid,A.shopname,A.createtime,A.paymentname,A.BuyIsDeleted,A.dispatchprice,(select top 1 ID from ShopNum1_OrderComplaint e where  e.orderid=A.ordernumber ) as ocid,a.IsBuyComment,a.FeeType,a.Score_dv,a.score_reduce_pv_a  FROM shopnum1_orderinfo A left join ShopNum1_Shop_CustomerCategory c on c.id=A.shop_category_id left join shopnum1_refund d on d.productguid=A.guid  where 1=1";
            if (strProName.Trim() != "")
            {
                str = str + " and GuId in(select orderinfoguid from shopnum1_orderproduct where productname like '%" +
                      strProName + "%')";
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "createtime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectOrderListTwo(string pagesize, string currentpage, string condition, string resultnum,
           string strProName)
        {
            string str =
                "SELECT A.paytime,c.category_name,d.refundstatus as vrefund,d.refundtype,A.shop_category_id,A.Guid,A.shouldpayprice,A.memloginid,A.ordernumber,A.oderstatus,A.shipmentstatus,A.paymentstatus,A.refundstatus,A.ordertype,A.shopid,A.shopname,A.createtime,A.paymentname,A.BuyIsDeleted,A.dispatchprice,(select top 1 ID from ShopNum1_OrderComplaint e where  e.orderid=A.ordernumber ) as ocid,a.IsBuyComment,a.FeeType,a.Score_dv,a.score_reduce_pv_a  FROM ShopNum1_OrderInfoTwo A left join ShopNum1_Shop_CustomerCategory c on c.id=A.shop_category_id left join shopnum1_refund d on d.productguid=A.guid  where 1=1";
            if (strProName.Trim() != "")
            {
                str = str + " and GuId in(select orderinfoguid from ShopNum1_OrderProductTwo where productname like '%" +
                      strProName + "%')";
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "createtime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectOrderListGZ(string pagesize, string currentpage, string condition, string resultnum,
    string strProName)
        {
            string str =
                "SELECT A.paytime,c.category_name,d.refundstatus as vrefund,d.refundtype,A.shop_category_id,A.Guid,A.shouldpayprice,A.memloginid,A.ordernumber,A.oderstatus,A.shipmentstatus,A.paymentstatus,A.refundstatus,A.ordertype,A.shopid,A.shopname,A.createtime,A.paymentname,A.BuyIsDeleted,A.dispatchprice,(select top 1 ID from ShopNum1_OrderComplaint e where  e.orderid=A.ordernumber ) as ocid,a.IsBuyComment,a.FeeType,a.Score_dv,a.score_reduce_pv_a  FROM shopnum1_orderinfo A left join ShopNum1_Shop_CustomerCategory c on c.id=A.shop_category_id left join shopnum1_refund d on d.productguid=A.guid  where 1=1";
            if (strProName.Trim() != "")
            {
                str = str + " and GuId in(select orderinfoguid from shopnum1_orderproduct where productname like '%" +
                      strProName + "%')";
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "paytime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
        public DataTable SelectOrderListGZTwo(string pagesize, string currentpage, string condition, string resultnum,
  string strProName)
        {
            string str =
                "SELECT A.paytime,c.category_name,d.refundstatus as vrefund,d.refundtype,A.shop_category_id,A.Guid,A.shouldpayprice,A.memloginid,A.ordernumber,A.oderstatus,A.shipmentstatus,A.paymentstatus,A.refundstatus,A.ordertype,A.shopid,A.shopname,A.createtime,A.paymentname,A.BuyIsDeleted,A.dispatchprice,(select top 1 ID from ShopNum1_OrderComplaint e where  e.orderid=A.ordernumber ) as ocid,a.IsBuyComment,a.FeeType,a.Score_dv,a.score_reduce_pv_a  FROM shopnum1_orderinfoTwo A left join ShopNum1_Shop_CustomerCategory c on c.id=A.shop_category_id left join shopnum1_refund d on d.productguid=A.guid  where 1=1";
            if (strProName.Trim() != "")
            {
                str = str + " and GuId in(select orderinfoguid from ShopNum1_OrderProductTwo where productname like '%" +
                      strProName + "%')";
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "paytime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SearchOrderInfos(string personname, string startdate, string enddate)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@personname";
            paraValue[0] = personname;
            paraName[1] = "@startdate";
            paraValue[1] = startdate;
            paraName[2] = "@enddate";
            paraValue[2] = enddate;
            string strSql = "select a.OrderNumber,a.Name,a.Email,a.Address,a.Mobile,a.ConfirmTime from ShopNum1_OrderInfo a where 1=1 ";

            if (!string.IsNullOrEmpty(personname))
            {
                strSql += "and a.Name=@personname ";
            }
            if (!string.IsNullOrEmpty(startdate))
            {
                strSql += "and a.ConfirmTime > @startdate ";

            }
            if (!string.IsNullOrEmpty(enddate))
            {
                strSql += "and a.ConfirmTime < @enddate ";
            }


            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SearchCusOrder(string startdate, string enddate)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@startdate";
            paraValue[0] = startdate;
            paraName[1] = "@enddate";
            paraValue[1] = enddate;

            string strSql = "select b.DispatchTime, b.OrderNumber as number,  b.MemLoginID,a.ProductName as ProductName,SUM(a.BuyNumber) as BuyNumber,b.Name as Name ,b.Address as Address,b.Mobile as Mobile from ShopNum1_OrderProduct a left join ShopNum1_OrderInfo b on a.OrderInfoGuid=b.Guid where 1=1 and b.OrderNumber is not null ";

            if (!string.IsNullOrEmpty(startdate))
            {
                strSql += "and b.ConfirmTime > @startdate ";

            }
            if (!string.IsNullOrEmpty(enddate))
            {
                strSql += "and b.ConfirmTime < @enddate ";
            }
            strSql += "group by b.OrderNumber, b.MemLoginID, a.ProductName , b.Name,b.Address ,b.Mobile,b.DispatchTime order by OrderNumber ";

            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SeachStoreOrder(string startdate, string enddate)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@startdate";
            paraValue[0] = startdate;
            paraName[1] = "@enddate";
            paraValue[1] = enddate;
            string strSql = "select  a.ProductName as ProductName,SUM(a.BuyNumber) as BuyNumber from ShopNum1_OrderProduct a left join ShopNum1_OrderInfo b on a.OrderInfoGuid=b.Guid where 1=1 ";
            if (!string.IsNullOrEmpty(startdate))
            {
                strSql += "and b.ConfirmTime > @startdate ";

            }
            if (!string.IsNullOrEmpty(enddate))
            {
                strSql += "and b.ConfirmTime < @enddate ";
            }
            strSql += "group by a.ProductName ";
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }



        public int SetOderStatus1(string guid, int oderStatus, int paymentStatus, int shipmentStatus,
            DateTime confirmTime)
        {
            string str = string.Empty;
            str =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_OrderInfo SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus,
                    ", ShipmentStatus=", shipmentStatus
                });
            if ((paymentStatus == 1) && (shipmentStatus == 0))
            {
                str = str + ",PayTime='" + Convert.ToDateTime(confirmTime).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (shipmentStatus == 1)
            {
                str = str + ",DispatchTime='" + Convert.ToDateTime(confirmTime).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (shipmentStatus == 2)
            {
                str = str + ",ReceiptTime='" + Convert.ToDateTime(confirmTime).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            return DatabaseExcetue.RunNonQuery(str + " WHERE Guid='" + guid + "'");
        }

        public int SetOderStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus,
            decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus,
                        ", ShipmentStatus=", shipmentStatus, ",AlreadPayPrice=", alreadPayPrice, ",ShouldPayPrice=",
                        shouldPayPrice, ",ShipmentNumber='", Operator.FilterString(shipmentNumber), "' WHERE Guid='"
                        , guid, "'"
                    }));
        }

        public int SetOderStatus3(string guid, int oderStatus, int paymentStatus, int shipmentStatus,
            decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus,
                        ", ShipmentStatus=", shipmentStatus, ",AlreadPayPrice=", alreadPayPrice, ",ShouldPayPrice=",
                        shouldPayPrice, ",ShipmentNumber='", Operator.FilterString(shipmentNumber), "' WHERE Guid='"
                        , guid, "'"
                    }));
        }

        public int SetOderStatus4(string guid, int oderStatus, int paymentStatus, int shipmentStatus,
            decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus,
                        ", ShipmentStatus=", shipmentStatus, ",AlreadPayPrice=", alreadPayPrice, ",ShouldPayPrice=",
                        shouldPayPrice, ",ShipmentNumber='", Operator.FilterString(shipmentNumber), "' WHERE Guid='"
                        , guid, "'"
                    }));
        }

        public int SetPaymentStatus0(string guid, int oderStatus, int paymentStatus, int shipmentStatus,
            decimal alreadPayPrice, decimal shouldPayPrice)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo  SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus
                        ,
                        ", ShipmentStatus=", shipmentStatus, ",AlreadPayPrice=", alreadPayPrice, ",ShouldPayPrice=",
                        shouldPayPrice, "  WHERE Guid='", guid, "'"
                    }));
        }

        public int SetPaymentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime payTime, decimal alreadPayPrice, decimal shouldPayPrice)
        {
            return
                DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_OrderInfo SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus, ", ShipmentStatus=", shipmentStatus, ",AlreadPayPrice=", alreadPayPrice, ",ShouldPayPrice=", shouldPayPrice, ", PayTime='", Convert.ToDateTime(payTime).ToString("yyyy-MM-dd HH:mm:ss"), "' WHERE tradeid='", guid, "'" }));
        }

        public int SetPaymentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime payTime, decimal alreadPayPrice, decimal shouldPayPrice, string strTrade_no)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_OrderInfo SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus,
                ", ShipmentStatus=", shipmentStatus, ",AlreadPayPrice=", alreadPayPrice, ",ShouldPayPrice=",
                shouldPayPrice, ", PayTime='", Convert.ToDateTime(payTime).ToString("yyyy-MM-dd HH:mm:ss"),
                "',AlipayTradeId='", strTrade_no, "' WHERE TradeId='", guid,
                "'"
            }));
        }

        public int SetShipmentStatus0(string guid, int oderStatus, int paymentStatus, int shipmentStatus,
            string shipmentNumber)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus,
                        ", ShipmentStatus=", shipmentStatus, ",ShipmentNumber='",
                        Operator.FilterString(shipmentNumber), "' WHERE Guid='", guid, "'"
                    }));
        }

        public int SetShipmentStatus1(string guid, int oderStatus, int paymentStatus, int shipmentStatus,
            DateTime dispatchTime, string shipmentNumber)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET OderStatus=", oderStatus, ", PaymentStatus=", paymentStatus,
                        ", ShipmentStatus=", shipmentStatus, ",DispatchTime='",
                        Convert.ToDateTime(dispatchTime).ToString("yyyy-MM-dd HH:mm:ss"), "',ShipmentNumber='",
                        Operator.FilterString(shipmentNumber), "' WHERE Guid='", guid, "'"
                    }));
        }

        public int SetShipmentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            parms[1].ParameterName = "@oderStatus";
            parms[1].Value = oderStatus;
            parms[2].ParameterName = "@paymentStatus";
            parms[2].Value = paymentStatus;
            parms[3].ParameterName = "@shipmentStatus";
            parms[3].Value = shipmentStatus;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET OderStatus=@oderStatus, PaymentStatus=@paymentStatus, ShipmentStatus=@shipmentStatus WHERE Guid=@guid"
                    }), parms);
        }

        public int SetShipmentStatus3(string guid, int oderStatus, int paymentStatus, int shipmentStatus)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            parms[1].ParameterName = "@oderStatus";
            parms[1].Value = oderStatus;
            parms[2].ParameterName = "@paymentStatus";
            parms[2].Value = paymentStatus;
            parms[3].ParameterName = "@shipmentStatus";
            parms[3].Value = shipmentStatus;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET OderStatus=@oderStatus, PaymentStatus=@paymentStatus, ShipmentStatus=@shipmentStatus WHERE Guid=@guid"
                    }), parms);
        }

        public int SetWaitBuyerPay(string strOderStatus, string ShipmentStatus, string PaymentStatus, string strGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@strOderStatus";
            parms[0].Value = strOderStatus;
            parms[1].ParameterName = "@ShipmentStatus";
            parms[1].Value = ShipmentStatus;
            parms[2].ParameterName = "@PaymentStatus";
            parms[2].Value = PaymentStatus;
            parms[3].ParameterName = "@strGuid";
            parms[3].Value = strGuid;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_OrderInfo Set PaymentStatus =@PaymentStatus,OderStatus=@strOderStatu,ShipmentStatus=@ShipmentStatus where guid=@strGuid", parms);
        }

        public int UpdateRefunType(string OrderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;

            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_OrderRefund Set RefundType=1 where Ordernumber=@OrderNumber", parms);
        }

        public DataSet SingleTradePayMent(string OrderNumber, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@OrderNumber";
            paraValue[0] = OrderNumber;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_OrderInfoSingleTradePayMent", paraName,
                paraValue);
        }

        public int UpdataOrderInfoIsMinus(ShopNum1_OrderInfo shopNum1_OrderInfo)
        {
            string strSql = string.Empty;
            strSql =
                "UPDATE ShopNum1_OrderInfo SET Name=@Name,Email=@Email,Address=@Address,Postalcode=@Postalcode,Tel=@Tel,Mobile=@Mobile,RegionCode=@RegionCode,IsMinus=@IsMinus,ShouldPayPrice=@ShouldPayPrice,DispatchType=@DispatchType,DispatchPrice=@DispatchPrice WHERE Guid=@Guid";
            var paraName = new string[12];
            var paraValue = new string[12];
            paraName[0] = "@Name";
            paraValue[0] = shopNum1_OrderInfo.Name;
            paraName[1] = "@Email";
            paraValue[1] = shopNum1_OrderInfo.Email;
            paraName[2] = "@Address";
            paraValue[2] = shopNum1_OrderInfo.Address;
            paraName[3] = "@Postalcode";
            paraValue[3] = shopNum1_OrderInfo.Postalcode;
            paraName[4] = "@Tel";
            paraValue[4] = shopNum1_OrderInfo.Tel;
            paraName[5] = "@Mobile";
            paraValue[5] = shopNum1_OrderInfo.Mobile;
            paraName[6] = "@RegionCode";
            paraValue[6] = shopNum1_OrderInfo.RegionCode;
            paraName[7] = "@IsMinus";
            paraValue[7] = shopNum1_OrderInfo.IsMinus.ToString();
            paraName[8] = "@DispatchType";
            paraValue[8] = shopNum1_OrderInfo.DispatchType.ToString();
            paraName[9] = "@ShouldPayPrice";
            paraValue[9] = shopNum1_OrderInfo.ShouldPayPrice.ToString();
            paraName[10] = "@Guid";
            paraValue[10] = shopNum1_OrderInfo.Guid.ToString();
            paraName[11] = "@DispatchPrice";
            paraValue[11] = shopNum1_OrderInfo.DispatchPrice.ToString();
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UpdataOrderInfoIsMinus(string IsMinus, string DispatchType, string ShouldPayPrice, string Guid,
            string DispatchPrice)
        {
            string strSql = string.Empty;
            strSql =
                "UPDATE ShopNum1_OrderInfo SET IsMinus=@IsMinus,ShouldPayPrice=@ShouldPayPrice,DispatchType=@DispatchType,DispatchPrice=@DispatchPrice WHERE Guid=@Guid";
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@IsMinus";
            paraValue[0] = IsMinus;
            paraName[1] = "@DispatchType";
            paraValue[1] = DispatchType;
            paraName[2] = "@ShouldPayPrice";
            paraValue[2] = ShouldPayPrice;
            paraName[3] = "@Guid";
            paraValue[3] = Guid;
            paraName[4] = "@DispatchPrice";
            paraValue[4] = DispatchPrice;
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UpdataReceivedDays(string orderguid, string shopid, string ismember, string days)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@orderguid";
            parms[0].Value = orderguid;
            parms[1].ParameterName = "@shopid";
            parms[1].Value = shopid;

            parms[2].ParameterName = "@days";
            parms[2].Value = days;
            string str = "UPDATE dbo.ShopNum1_OrderInfo SET ReceivedDays=ReceivedDays+@days";
            if (ismember == "1")
            {
                str = str + " , IsMemdelay=1 ";
            }
            string str2 = str;
            return DatabaseExcetue.RunNonQuery(str2 + " WHERE Guid=@orderguid AND ShopID=@shopid", parms);
        }

        public int UpdateAddress(ShopNum1_OrderInfo orderInfo, string orderguid)
        {
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_OrderInfo SET Name='" + orderInfo.Name + "',Email='" +
                                            orderInfo.Email + "',Address='" + orderInfo.Address + "',Postalcode='" +
                                            orderInfo.Postalcode + "',Tel='" + orderInfo.Tel + "',Mobile='" +
                                            orderInfo.Mobile + "',RegionCode='" + orderInfo.RegionCode +
                                            "' WHERE Guid='" + orderguid + "'");
        }

        public int UpdateAddressByGuid(string guid, string name, string email, string address, string postalcode,
            string string_0, string mobile)
        {
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_OrderInfo SET Name='" + Operator.FilterString(name) +
                                            "', Email='" + Operator.FilterString(email) + "', Address='" +
                                            Operator.FilterString(address) + "',Postalcode='" +
                                            Operator.FilterString(postalcode) + "', Tel='" +
                                            Operator.FilterString(string_0) + "',Mobile='" +
                                            Operator.FilterString(mobile) + "' WHERE Guid='" + guid + "'");
        }

        public int UpdateByConfirmPay(string strordernum, string strname)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ordernum";
            paraValue[0] = strordernum;
            paraName[1] = "@name";
            paraValue[1] = strname;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateByConfirmPay", paraName, paraValue);
        }

        public int UpdateCancelOrderInfo(string strCanDate)
        {
            string strSql = "select createtime,guid from shopnum1_orderinfo  where oderstatus=0 and isdeleted=0";
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            if (table.Rows.Count > 0)
            {
                var sqlList = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(table.Rows[i]["createtime"]).AddDays(double.Parse(strCanDate)) <=
                        DateTime.Now)
                    {
                        string str2 = table.Rows[i]["guid"].ToString();
                        sqlList.Add("Update ShopNum1_OrderInfo set Oderstatus=6 where guid='" + str2 + "'");
                        DataTable table2 =
                            DatabaseExcetue.ReturnDataTable(
                                "select productguid,buynumber,specificationvalue,attributes from shopnum1_orderproduct where orderinfoGuId='" +
                                str2 + "' ");
                        if (table2.Rows.Count > 0)
                        {
                            for (int j = 0; j < table2.Rows.Count; j++)
                            {
                                if (table2.Rows[j]["attributes"].ToString() == "1")
                                {
                                    sqlList.Add(
                                        string.Concat(new[]
                                        {
                                            "UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount+",
                                            table2.Rows[j]["buynumber"], " WHERE Guid ='",
                                            table2.Rows[j]["productguid"], "';"
                                        }));
                                    sqlList.Add(
                                        string.Concat(new[]
                                        {
                                            "UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock+",
                                            table2.Rows[j]["buynumber"], " WHERE  SpecDetail ='",
                                            table2.Rows[j]["specificationvalue"], "';"
                                        }));
                                }
                                sqlList.Add(
                                    string.Concat(new[]
                                    {
                                        "UPDATE ShopNum1_Group_Product SET groupstock=groupstock+",
                                        table2.Rows[j]["buynumber"], " WHERE productguid='",
                                        table2.Rows[j]["productguid"], "';"
                                    }));
                            }
                        }
                    }
                }
                try
                {
                    DatabaseExcetue.RunTransactionSql(sqlList);
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }

        public int UpdateDelete(string guid)
        {


            string item = string.Empty;
            var sqlList = new List<string>();
            item = "UPDATE ShopNum1_OrderInfo SET ISDELETED=1 WHERE Guid IN (" + guid + ")";
            sqlList.Add(item);
            item = "UPDATE ShopNum1_OrderProduct SET ISDELETED=1 WHERE OrderInfoGuid IN (" + guid + ")";
            sqlList.Add(item);
            item = "UPDATE ShopNum1_OrderOperateLog SET ISDELETED=1 WHERE OrderInfoGuid IN (" + guid + ")";
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateDispatchInfo(string guid, string dispatchModeGuid, string dispatchModeName,
            string dispatchPrice, string insurePrice, string regionCode)
        {
            DataTable table = SearchPriceByGuid(guid);
            string str = table.Rows[0]["ProductPrice"].ToString();
            string orderPrice = "0";
            orderPrice = str + "-0.00+" + table.Rows[0]["InvoiceTax"] + "+" + dispatchPrice + "+" + insurePrice + "+" +
                         table.Rows[0]["PaymentPrice"] + "+" + table.Rows[0]["PackPrice"] + "+" +
                         table.Rows[0]["BlessCardPrice"];
            orderPrice = ComputeOderPrice(orderPrice);
            string shouldPayPrice = orderPrice + "-" + table.Rows[0]["AlreadPayPrice"] + "-" +
                                    table.Rows[0]["SurplusPrice"] + "-" + table.Rows[0]["ScorePrice"];
            shouldPayPrice = ComputeShouldPayPrice(shouldPayPrice);
            if (dispatchModeGuid == string.Empty)
            {
                dispatchModeGuid = Guid.Empty.ToString();
            }
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET DispatchPrice=", Convert.ToDecimal(dispatchPrice),
                        ",ShouldPayPrice=", Convert.ToDecimal(shouldPayPrice), "RegionCode=", regionCode,
                        " WHERE Guid='", guid, "'"
                    }));
        }

        public int UpdateFeePriceByGuid(string dispatchprice, string ispercent, string guid, string IsMinus)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@dispatchprice";
            paraValue[0] = dispatchprice;
            paraName[1] = "@ispercent";
            paraValue[1] = ispercent;
            paraName[2] = "@guid";
            paraValue[2] = guid;
            paraName[3] = "@IsMinus";
            paraValue[3] = IsMinus;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateFeePriceByGuid", paraName, paraValue);
        }

        public int UpdateOrderMessage(string guid, string message, string messagetype)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@message";
            paraValue[1] = message;
            paraName[2] = "@messagetype";
            paraValue[2] = messagetype;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderMessage", paraName, paraValue);
        }

        public int UpdateOrderPrice(string strOrderNumber, string strMemloginId, string strNewPrice)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@strOrderNumber";
            parms[0].Value = strOrderNumber;
            parms[1].ParameterName = "@strMemloginId";
            parms[1].Value = strMemloginId;
            parms[2].ParameterName = "@strNewPrice";
            parms[2].Value = strNewPrice;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_orderinfo SET shouldpayPrice=@strNewPrice where ordernumber=@strOrderNumber and shopid=@strMemloginId", parms);
        }

        public int UpdateOrderPvbHv(string strOrderNumber, string strMemloginId, string strHv, string strPva)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@strOrderNumber";
            parms[0].Value = strOrderNumber;
            parms[1].ParameterName = "@strMemloginId";
            parms[1].Value = strMemloginId;
            parms[2].ParameterName = "@strHv";
            parms[2].Value = strHv;
            parms[3].ParameterName = "@strPvb";
            parms[3].Value = strPva;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_orderinfo SET Score_hv=@strHv,Score_pv_a=@strPvb where ordernumber=@strOrderNumber and shopid=@strMemloginId", parms);
        }

        public int UpdateOrderPrice(string guid, string productPrice, string dispatchPrice, string insurePrice,
            string paymentPrice, string packPrice, string blessCardPrice, string alreadPayPrice,
            string surplusPrice, string useScore, string scorePrice, string invoiceTax,
            string discount, string shouldPayPrice)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_OrderInfo SET ProductPrice=", Convert.ToDecimal(productPrice), ", DispatchPrice=",
                Convert.ToDecimal(dispatchPrice), ", InsurePrice=", Convert.ToDecimal(insurePrice),
                ", PaymentPrice=", Convert.ToDecimal(paymentPrice), ", PackPrice=", Convert.ToDecimal(packPrice),
                ", BlessCardPrice=", Convert.ToDecimal(blessCardPrice), ", AlreadPayPrice=",
                Convert.ToDecimal(alreadPayPrice), ", SurplusPrice=", Convert.ToDecimal(surplusPrice),
                ", UseScore=", Convert.ToInt32(useScore), ", ScorePrice=", Convert.ToDecimal(scorePrice),
                ", InvoiceTax=", Convert.ToDecimal(invoiceTax), ",Discount=", Convert.ToDecimal(discount),
                ",ShouldPayPrice=", Convert.ToDecimal(shouldPayPrice), " WHERE Guid='", guid, "'"
            }));
        }

        public int UpdateOrderState(string strOrderGuId, string MemlogInId, string strOrderState, string strShipState,
            string strPayState, string strRefundState, string strIsShop)
        {
            string strSql = "UPDATE Shopnum1_orderinfo SET ";
            if (strOrderState != "")
            {
                strSql = strSql + "oderstatus='" + strOrderState + "',";
            }
            if (strShipState != "")
            {
                strSql = strSql + "ShipmentStatus='" + strShipState + "',";
            }
            if (strPayState != "")
            {
                strSql = strSql + "PaymentStatus='" + strPayState + "',";
            }
            if (strRefundState != "")
            {
                strSql = strSql + "refundstatus='" + strRefundState + "',";
            }
            strSql = strSql + "guid=guid where GuId='" + strOrderGuId + "'";
            if (strIsShop == "1")
            {
                strSql = strSql + " and ShopId='" + MemlogInId + "'";
            }
            else
            {
                strSql = strSql + " and MemloginId='" + MemlogInId + "'";
            }
            return DatabaseExcetue.RunNonQuery(strSql);
        }

        public int UpdateOtherInfo(string guid, string blessCardPrice, string blessCardGuid, string blessCardName,
            string blessCardContent, string invoiceType, string invoic, string invoiceTitle,
            string invoiceContent, string clientToSellerMsg, string outOfStockOperate,
            string sellerToClientMsg)
        {
            DataTable table = SearchPriceByGuid(guid);
            string str = table.Rows[0]["ProductPrice"].ToString();
            string invoiceTax = "(" + invoic + "/100)*" + str;
            invoiceTax = ComputeInvoicePrice(invoiceTax);
            string orderPrice = "0";
            orderPrice = str + "-0.00+" + invoiceTax + "+" + table.Rows[0]["DispatchPrice"] + "+" +
                         table.Rows[0]["InsurePrice"] + "+" + table.Rows[0]["PaymentPrice"] + "+" +
                         table.Rows[0]["PackPrice"] + "+" + blessCardPrice;
            orderPrice = ComputeOderPrice(orderPrice);
            string shouldPayPrice = orderPrice + "-" + table.Rows[0]["AlreadPayPrice"] + "-" +
                                    table.Rows[0]["SurplusPrice"] + "-" + table.Rows[0]["ScorePrice"];
            shouldPayPrice = ComputeShouldPayPrice(shouldPayPrice);
            if (blessCardGuid == string.Empty)
            {
                blessCardGuid = Guid.Empty.ToString();
            }
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_OrderInfo SET BlessCardContent='", Operator.FilterString(blessCardContent),
                "', BlessCardGuid='", blessCardGuid, "', BlessCardName='", Operator.FilterString(blessCardName),
                "', InvoiceType='", Operator.FilterString(invoiceType), "', InvoiceTitle='",
                Operator.FilterString(invoiceTitle), "',InvoiceContent='", Operator.FilterString(invoiceContent),
                "', ClientToSellerMsg='", Operator.FilterString(clientToSellerMsg), "',OutOfStockOperate='",
                Operator.FilterString(outOfStockOperate),
                "',SellerToClientMsg='", Operator.FilterString(sellerToClientMsg), "',ProductPrice=",
                Convert.ToDecimal(str), ",InvoiceTax=", Convert.ToDecimal(invoiceTax), ",ShouldPayPrice=",
                Convert.ToDecimal(shouldPayPrice), ",BlessCardPrice=", Convert.ToDecimal(blessCardPrice),
                "  WHERE Guid='", guid, "'"
            }));
        }

        public int UpdatePaymentInfo(string guid, string paymentGuid, string paymentName, decimal pPrice)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            parms[1].ParameterName = "@paymentGuid";
            parms[1].Value = paymentGuid;
            parms[2].ParameterName = "@paymentName";
            parms[2].Value = Operator.FilterString(paymentName);
            parms[3].ParameterName = "@pPrice";
            parms[3].Value = pPrice;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET PaymentGuid=@paymentGuid, PaymentName=@paymentName, PaymentPrice=@pPrice  WHERE Guid=@guid"
                    }), parms);
        }

        public int UpdatePaymentInfo(string guid, string paymentGuid, string paymentName, decimal pPrice, int ispercent)
        {
            string str = SearchPriceByGuid(guid).Rows[0]["ShouldPayPrice"].ToString();
            if (paymentGuid == string.Empty)
            {
                paymentGuid = Guid.Empty.ToString();
            }
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_OrderInfo SET PaymentGuid='" + paymentGuid +
                                            "', PaymentName='" + Operator.FilterString(paymentName) +
                                            "', PaymentPrice=0.00,ShouldPayPrice=" + str + " WHERE Guid='" + guid + "'");
        }

        public int UpdatePostFee(string postFee, string orderguid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@DispatchPrice";
            paraValue[0] = postFee;
            paraName[1] = "@orderguid";
            paraValue[1] = orderguid;
            return DatabaseExcetue.RunProcedure("[Pro_ShopNum1_UpdateOrderDispatchPrice]", paraName, paraValue);
        }

        public int UpdateProduct(string guid, string productPrice, string shopSettingPath,
            List<ShopNum1_OrderProduct> listOrderProduct)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "DELETE FROM ShopNum1_OrderProduct WHERE OrderInfoGuid='" + guid + "'";
            sqlList.Add(item);
            if (listOrderProduct.Count > 0)
            {
                for (int j = 0; j < listOrderProduct.Count; j++)
                {
                    string str6 = string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_OrderProduct( Guid,OrderInfoGuid,ProductGuid,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ExtensionAttriutes,IsJoinActivity,CreateTime ) VALUES ( '"
                        , listOrderProduct[j].Guid, "','", guid, "','", listOrderProduct[j].ProductGuid, "','",
                        Operator.FilterString(listOrderProduct[j].Name), "','",
                        Operator.FilterString(listOrderProduct[j].RepertoryNumber), "',",
                        listOrderProduct[j].BuyNumber, ",", listOrderProduct[j].MarketPrice, ",",
                        listOrderProduct[j].ShopPrice,
                        ",", listOrderProduct[j].BuyPrice, ",'",
                        Operator.FilterString(listOrderProduct[j].Attributes), "',", listOrderProduct[j].IsShipment,
                        ",", listOrderProduct[j].IsReal, ",'",
                        Operator.FilterString(listOrderProduct[j].ExtensionAttriutes), "',",
                        listOrderProduct[j].IsJoinActivity, ",'",
                        Convert.ToDateTime(listOrderProduct[j].CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "')"
                    });
                    sqlList.Add(str6);
                }
            }
            DataTable table = SearchPriceByGuid(guid);
            var settings = new ShopSettings();
            string str2 = "0.00";
            var valueAllInvoice = new List<string>();
            valueAllInvoice = settings.GetValueAllInvoice(shopSettingPath);
            for (int i = 0; i < valueAllInvoice.Count; i++)
            {
                string[] strArray2 = valueAllInvoice[i].Split(new[] { '|' });
                if (strArray2[0] == table.Rows[0]["InvoiceType"].ToString())
                {
                    str2 = strArray2[1];
                }
            }
            string invoiceTax = "(" + str2 + "/100)*" + productPrice;
            invoiceTax = ComputeInvoicePrice(invoiceTax);
            string orderPrice = "0";
            orderPrice = productPrice + "-0.00+" + invoiceTax + "+" + table.Rows[0]["DispatchPrice"] + "+" +
                         table.Rows[0]["InsurePrice"] + "+" + table.Rows[0]["Paymentprice"] + "+" +
                         table.Rows[0]["PackPrice"] + "+" + table.Rows[0]["BlessCardPrice"];
            orderPrice = ComputeOderPrice(orderPrice);
            string shouldPayPrice = orderPrice + "-" + table.Rows[0]["AlreadPayPrice"] + "-" +
                                    table.Rows[0]["SurplusPrice"] + "-" + table.Rows[0]["ScorePrice"];
            shouldPayPrice = ComputeShouldPayPrice(shouldPayPrice);
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_OrderInfo SET InvoiceTax=", Convert.ToDecimal(invoiceTax), ", ProductPrice=",
                    Convert.ToDecimal(productPrice), ",ShouldPayPrice=", Convert.ToDecimal(shouldPayPrice),
                    " WHERE Guid='", guid, "'"
                });
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateSaleNumAndRepertCtByOrderGuid(string OrderGuid)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            foreach (DataRow row in GetProductGuidAndBuyNum(OrderGuid).Rows)
            {
                item =
                    string.Concat(new[]
                    {
                        "UPDATE dbo.ShopNum1_Shop_Product SET SaleNumber=SaleNumber+", row["BuyNumber"],
                        ", RepertoryCount=RepertoryCount-", row["BuyNumber"], " WHERE Guid='", row["ProductGuid"],
                        "'"
                    });
                sqlList.Add(item);
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UserDelete(string guids)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guids";
            paraValue[0] = guids;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_OrderInfoUserDel", paraName, paraValue);
        }

        public DataTable GetOrderInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfo", paraName, paraValue);
        }

        public int UpdateIsPayDeposit(string guid, string isPayDeposit)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            parms[1].ParameterName = "@isPayDeposit";
            parms[1].Value = isPayDeposit;

            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_OrderInfo SET IsPayDeposit=@isPayDeposit WHERE Guid=@guid", parms);
        }

        public int UpdateOrderInfoStatus(string guid, string statusname, string statusvalues)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@statusname";
            paraValue[1] = statusname;
            paraName[2] = "@statusvalues";
            paraValue[2] = statusvalues;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderInfoStatus", paraName, paraValue);
        }

        public int UpdateOrderInfoStatus_tenpay(string guid, string statusname, string statusvalues)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@statusname";
            paraValue[1] = statusname;
            paraName[2] = "@statusvalues";
            paraValue[2] = statusvalues;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderInfoStatus_tenpay", paraName, paraValue);
        }
    }
}
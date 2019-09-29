﻿using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_OrderProduct_Action : IShopNum1_OrderProduct_Action
    {
        public DataTable GetNewSaleOrder(string strTopCount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@top";
            paraValue[0] = strTopCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetNewSaleOrder", paraName, paraValue);
        }

        public DataTable GetOrderProductList(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderProductList", paraName, paraValue);
        }

        public DataTable GetPackOrderShopInfo(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetPackShopInfo", paraName, paraValue);
        }

        public string GetWeight(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            
            string strSql = string.Empty;
            strSql = "SELECT Weight FROM ShopNum1_Product WHERE Guid=@guid";
            if (DatabaseExcetue.ReturnDataTable(strSql,parms).Rows.Count > 0)
            {
                return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Weight"].ToString();
            }
            return "0.00";
        }

        public DataTable Search(string orderInfoGuid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.Guid,A.OrderInfoGuid,A.ProductGuid,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.IsShipment,A.IsReal,A.ExtensionAttriutes,A.IsJoinActivity,A.CreateTime,B.PanicPrice,B.SpellPrice,B.GroupPrice,B.memloginid  FROM ShopNum1_OrderProduct AS A,ShopNum1_Shop_Product AS B  WHERE A.ProductGuid=B.Guid ";
            if (orderInfoGuid != "-1")
            {
                strSql = string.Concat(new object[] {strSql, " AND A.OrderInfoGuid='", new Guid(orderInfoGuid), "'"});
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchOrderProduct(string ordernum, string productname, string shopname, string startdate,
            string enddate)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@ordernum";
            paraValue[0] = ordernum;
            paraName[1] = "@pname";
            paraValue[1] = productname;
            paraName[2] = "@shopname";
            paraValue[2] = shopname;
            paraName[3] = "@startdate";
            paraValue[3] = startdate;
            paraName[4] = "@enddate";
            paraValue[4] = enddate;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchOrderProduct", paraName, paraValue);
        }

        public DataTable SearchRankingSellHot(string ShowCount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ShowCount";
            paraValue[0] = ShowCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchRankingSellHot", paraName, paraValue);
        }

        public DataTable SelectOrderProductByGuIdorAll(string OrderGuId, string KeyWord)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@OrderGuId";
            paraValue[0] = OrderGuId;
            paraName[1] = "@KeyWord";
            paraValue[1] = KeyWord;

            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderProductByGuIdorAll", paraName,
                paraValue);
        }

        public DataTable SelectOrderProductByGuIdorAllAndMemloginId(string memLoginId, string OrderGuId, string KeyWord)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@OrderGuId";
            paraValue[0] = OrderGuId;
            paraName[1] = "@KeyWord";
            paraValue[1] = KeyWord;
            paraName[2] = "@MemLoginId";
            paraValue[2] = memLoginId;

            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderProductByGuIdorAllAndMemloginId", paraName,
                paraValue);
        }

        public DataTable Pro_Shop_GetOrderProductByGuIdorAllAndMemloginIdTwo(string memLoginId, string OrderGuId, string KeyWord)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@OrderGuId";
            paraValue[0] = OrderGuId;
            paraName[1] = "@KeyWord";
            paraValue[1] = KeyWord;
            paraName[2] = "@MemLoginId";
            paraValue[2] = memLoginId;

            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderProductByGuIdorAllAndMemloginIdTwo", paraName,
                paraValue);
        }

        public DataTable SelectOrderProductByGuIdorAllAndBuyerId(string memLoginId, string OrderGuId, string KeyWord)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@OrderGuId";
            paraValue[0] = OrderGuId;
            paraName[1] = "@KeyWord";
            paraValue[1] = KeyWord;
            paraName[2] = "@MemLoginId";
            paraValue[2] = memLoginId;

            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderProductByGuIdorAllAndBuyerId", paraName,
                paraValue);
        }
        public DataTable SelectOrderProductByGuIdorAllAndBuyerIdTwo(string memLoginId, string OrderGuId, string KeyWord)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@OrderGuId";
            paraValue[0] = OrderGuId;
            paraName[1] = "@KeyWord";
            paraValue[1] = KeyWord;
            paraName[2] = "@MemLoginId";
            paraValue[2] = memLoginId;

            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderProductByGuIdorAllAndBuyerIdTwo", paraName,
                paraValue);
        }

        public int UpdateOrderProductBuyNum(string guid, string buynumber, string productPrice)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@buynumber";
            paraValue[1] = buynumber;
            paraName[2] = "@BuyPrice";
            paraValue[2] = productPrice;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderProductBuyNum", paraName, paraValue);
        }

        public int UpdateOrderProductInfo(string guid, string buyprice, string groupprice, string buynumber)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@buyprice";
            paraValue[1] = buyprice;
            paraName[2] = "@groupprice";
            paraValue[2] = groupprice;
            paraName[3] = "@buynumber";
            paraValue[3] = buynumber;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderProductInfo", paraName, paraValue);
        }

        public int UpdateReduceStock(string strOrderGuId, string strSaleType)
        {
            var sqlList = new List<string>();
            DataTable table =
                DatabaseExcetue.ReturnDataTable(
                    "select productguid,buynumber,specificationvalue,attributes,b.oderstatus from shopnum1_orderproduct A inner Join ShopNum1_Orderinfo B on B.guid=A.orderinfoGuId  where orderinfoGuId='" +
                    strOrderGuId + "' ");
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i]["attributes"].ToString() == "0")
                    {
                        sqlList.Add(
                            string.Concat(new[]
                            {
                                "UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount+",
                                table.Rows[i]["buynumber"], " WHERE Guid ='", table.Rows[i]["productguid"], "';"
                            }));
                        sqlList.Add(
                            string.Concat(new[]
                            {
                                "UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock+", table.Rows[i]["buynumber"]
                                ,
                                " WHERE  SpecDetail ='", table.Rows[i]["specificationvalue"], "';"
                            }));
                        if (strSaleType == "1")
                        {
                            sqlList.Add(
                                string.Concat(new[]
                                {
                                    "UPDATE ShopNum1_Shop_Product SET salenumber=salenumber-",
                                    table.Rows[i]["buynumber"], " WHERE  Guid ='", table.Rows[i]["productguid"],
                                    "';"
                                }));
                        }
                    }
                    sqlList.Add(
                        string.Concat(new[]
                        {
                            "UPDATE ShopNum1_Group_Product SET groupstock=groupstock+", table.Rows[i]["buynumber"],
                            " WHERE productguid='", table.Rows[i]["productguid"], "';"
                        }));
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

        /// <summary>
        /// 更新产品销售数量
        /// </summary>
        /// <param name="strOrderGuId"></param>
        /// <returns></returns>
        public int UpdateStock(string strOrderGuId)
        {
            var sqlList = new List<string>();
            DataTable table =
                DatabaseExcetue.ReturnDataTable(
                    "select productguid,buynumber,specificationvalue,attributes from shopnum1_orderproduct where orderinfoGuId='" +
                    strOrderGuId + "' ");
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sqlList.Add(
                        string.Concat(new[]
                        {
                            "UPDATE ShopNum1_Shop_Product SET salenumber=salenumber+", table.Rows[i]["buynumber"],
                            " WHERE  Guid ='", table.Rows[i]["productguid"], "';"
                        }));
                    sqlList.Add(
                        string.Concat(new[]
                        {
                            "UPDATE ShopNum1_Group_Product SET groupcount=groupcount+", table.Rows[i]["buynumber"],
                            " WHERE productguid='", table.Rows[i]["productguid"], "' and state=1;"
                        }));
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
    }
}

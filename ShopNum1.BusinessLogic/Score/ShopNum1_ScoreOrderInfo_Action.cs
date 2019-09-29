using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ScoreOrderInfo_Action : IShopNum1_ScoreOrderInfo_Action
    {
        public int Add(ShopNum1_ScoreOrderInfo ScoreOrderInfo, List<ShopNum1_ScoreOrderProduct> ScoreOrderProduct)
        {
            string item = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "insert ShopNum1_ScoreOrderInfo(  Guid, OrderNumber, MemLoginID, ShopMemLoginID, ShopName, OderStatus, Name, Email, Address, Postalcode, Tel, Mobile, UserMsg, TotalScore, CreateTime, ConfirmTime, ModifyUser, ModifyTime, IsDeleted ) VALUES (  '"
                , Operator.FilterString(ScoreOrderInfo.Guid), "',  '",
                Operator.FilterString(ScoreOrderInfo.OrderNumber), "',  '",
                Operator.FilterString(ScoreOrderInfo.MemLoginID), "',  '",
                Operator.FilterString(ScoreOrderInfo.ShopMemLoginID), "',  '",
                Operator.FilterString(ScoreOrderInfo.ShopName), "',  '",
                Operator.FilterString(ScoreOrderInfo.OderStatus), "',  '",
                Operator.FilterString(ScoreOrderInfo.Name), "',  '", Operator.FilterString(ScoreOrderInfo.Email),
                "',  '", Operator.FilterString(ScoreOrderInfo.Address), "',  '",
                Operator.FilterString(ScoreOrderInfo.Postalcode), "',  '", Operator.FilterString(ScoreOrderInfo.Tel)
                , "',  '", Operator.FilterString(ScoreOrderInfo.Mobile), "',  '",
                Operator.FilterString(ScoreOrderInfo.UserMsg), "',  '",
                Operator.FilterString(ScoreOrderInfo.TotalScore), "',  '",
                Operator.FilterString(ScoreOrderInfo.CreateTime), "',  '",
                Operator.FilterString(ScoreOrderInfo.ConfirmTime),
                "',  '", Operator.FilterString(ScoreOrderInfo.ModifyUser), "',  '",
                Operator.FilterString(ScoreOrderInfo.ModifyTime), "',  ", ScoreOrderInfo.IsDeleted, " )"
            });
            sqlList.Add(item);
            if (ScoreOrderProduct.Count > 0)
            {
                for (int i = 0; i < ScoreOrderProduct.Count; i++)
                {
                    str2 =
                        "insert ShopNum1_ScoreOrderProduct(  Guid, OrderNumber, ProductGuid, Name, RepertoryNumber, BuyNumber, Score ) VALUES (  '" +
                        Operator.FilterString(ScoreOrderProduct[i].Guid) + "',  '" +
                        Operator.FilterString(ScoreOrderProduct[i].OrderNumber) + "',  '" +
                        Operator.FilterString(ScoreOrderProduct[i].ProductGuid) + "',  '" +
                        Operator.FilterString(ScoreOrderProduct[i].Name) + "',  '" +
                        Operator.FilterString(ScoreOrderProduct[i].RepertoryNumber) + "',  '" +
                        Operator.FilterString(ScoreOrderProduct[i].BuyNumber) + "',  '" +
                        Operator.FilterString(ScoreOrderProduct[i].Score) + "' )";
                    sqlList.Add(str2);
                    str3 =
                        string.Concat(new object[]
                        {
                            " update  ShopNum1_Shop_ScoreProduct set RepertoryCount=RepertoryCount-",
                            ScoreOrderProduct[i].BuyNumber, ",HaveSale=HaveSale+", ScoreOrderProduct[i].BuyNumber
                        });
                    sqlList.Add(str3);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            
            return DatabaseExcetue.RunNonQuery("   delete ShopNum1_ScoreOrderInfo where  Guid in (@guids)  ",parms);
        }

        public DataTable GetInfoByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@str";
            parms[0].Value = guid.Replace("'", ""); 
            
            return
                DatabaseExcetue.ReturnDataTable("   select  * from  ShopNum1_ScoreOrderInfo  where Guid =@str",parms);
        }

        public int Update(ShopNum1_ScoreOrderInfo ScoreOrderInfo)
        {
            throw new NotImplementedException();
        }

        public int ChangeOderStatus(string Guid, string OderStatus)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'","");
            parms[1].ParameterName = "@OderStatus";
            parms[1].Value = OderStatus; 
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "   update ShopNum1_ScoreOrderInfo  set   OderStatus=@OderStatus,ConfirmTime='",
                        DateTime.Now, "'   where  Guid=@Guid "
                    }),parms);
        }

        public int DeleteByOrderNumber(string OrderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;
            
            return
                DatabaseExcetue.RunNonQuery("   delete ShopNum1_ScoreOrderInfo where  OrderNumber in (@OrderNumbe)  ",parms);
        }

        public int DeleteProduct(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return
                DatabaseExcetue.RunNonQuery((string.Empty +
                                             "   DELETE  ShopNum1_ScoreOrderProduct WHERE   OrderNumber     IN(  ") +
                                            "   SELECT OrderNumber FROM ShopNum1_ScoreOrderInfo  WHERE  Guid=@guids)  ",parms);
        }

        public int DeleteProductNew(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return
                DatabaseExcetue.RunNonQuery((string.Empty +
                                             "   DELETE  ShopNum1_ScoreOrderProduct WHERE   OrderNumber     IN(  ") +
                                            "   SELECT OrderNumber FROM ShopNum1_ScoreOrderInfo  WHERE  Guid=@guids)  ",parms);
        }

        public DataTable GetAdressNameByCode(string Code)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Code";
            parms[0].Value = Code;
            return
                DatabaseExcetue.ReturnDataTable("   select  * from  ShopNum1_Region  where   Code=@Code     ",parms);
        }

        public DataTable GetInfoAdmin(string OrderNumber, string Name, int OderStatus, string ShopMemLoginID)
        {
            string str = string.Empty;
            str = "   select  * from  ShopNum1_ScoreOrderInfo  where 1=1    ";
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + " and   OrderNumber  ='" + OrderNumber + "'   ";
            }
            if (!string.IsNullOrEmpty(Name))
            {
                str = str + " and    Name  like '%" + Name + "%'   ";
            }
            if (OderStatus != -1)
            {
                object obj2 = str;
                str = string.Concat(new[] {obj2, "   and     OderStatus=", OderStatus, "   "});
            }
            if (!string.IsNullOrEmpty(ShopMemLoginID))
            {
                str = str + "   and      ShopMemLoginID='" + ShopMemLoginID + "'   ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "   order  by  CreateTime  desc     ");
        }

        public DataTable GetInfoByOrderNumber(string OrderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;
            return
                DatabaseExcetue.ReturnDataTable("   select  * from  ShopNum1_ScoreOrderInfo  where OrderNumber =@OrderNumber",parms);
        }

        public DataTable GetInfoInManage(string strWhere)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strWhere";
            parms[0].Value = strWhere;
            return
                DatabaseExcetue.ReturnDataTable("   select  * from  ShopNum1_ScoreOrderInfo  where 1=1  @strWhere",parms);
        }

        public DataTable GetOrder(string OrderNumber, int OderStatus, string MemLoginID, int IsDeleted)
        {
            object obj2;
            string str = string.Empty;
            str = "    select * from   ShopNum1_ScoreOrderInfo where 1=1     ";
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + "   and   OrderNumber='" + Operator.FilterString(OrderNumber) + "' ";
            }
            if ((OderStatus == 1) || (OderStatus == 0))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "   and   OderStatus='", OderStatus, "' "});
            }
            if (!string.IsNullOrEmpty(MemLoginID))
            {
                str = str + "   and   MemLoginID='" + MemLoginID + "' ";
            }
            if ((IsDeleted == 0) || (IsDeleted == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "   and   IsDeleted=", IsDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "  order  by  CreateTime desc    ");
        }

        public DataTable GetProductByOrderNumber(string OrderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;
            string strSql = string.Empty;
            strSql =
                "    select A.*,B.Name as ProductName,B.OriginalImge,B.MemLoginID as IsShopMemLoginID,B.RepertoryNumber,B.MarketPrice,B.Score as ProductScore  from ShopNum1_ScoreOrderProduct as A left join ShopNum1_Shop_ScoreProduct as B on A.ProductGuid=B.Guid     ";
            strSql = strSql + "   where 1=1 ";
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                strSql = strSql + "   and   A.OrderNumber=@OrderNumber";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable GetShopInfo(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string str = string.Empty;
            str =
                "   select A.*,B.Mobile as UserMobile,B.Email as UserEmail from ShopNum1_ShopInfo as A left join ShopNum1_Member as B     ";
            return
                DatabaseExcetue.ReturnDataTable((str + "   on A.MemLoginID=B.MemLoginID  ") + "   where A.MemLoginID=@MemLoginID",parms);
        }

        public DataTable Select_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_ScoreOrderInfo";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;

            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);

        }

        public int UseUserScore(string MemLoginID, string Score)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Score";
            parms[1].Value = Score;
            return
                DatabaseExcetue.RunNonQuery("   update ShopNum1_Member  set  Score=Score-@Score where  MemLoginID=@MemLoginID",parms);
        }

        public int UseUserScoreAdd(string MemLoginID, string Score)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Score";
            parms[1].Value = Score;
            return
                DatabaseExcetue.RunNonQuery("   update ShopNum1_Member  set  Score=Score+@Score where  MemLoginID=@MemLoginID",parms);
        }
    }
}
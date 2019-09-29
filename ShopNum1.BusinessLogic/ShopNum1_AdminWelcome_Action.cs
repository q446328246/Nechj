using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_AdminWelcome_Action : IShopNum1_AdminWelcome_Action
    {
        public string SearchActivityProductCount(string strPanicBuy, string strSpellBuy, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strPanicBuy";
            parms[0].Value = strPanicBuy;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql =
                "Select count(guid) from ShopNum1_Shop_Product  where 1=1 And MemloginId in(Select memloginid from ShopNum1_ShopInfo) And IsAudit=1 ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted =@isDeleted";
            }
            else
            {
                strSql = strSql + " And ProductState =@strPanicBuy";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchAdminInfo(string strloginID, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "Select  LastLoginTime  from ShopNum1_User where 1=1";
            if (Operator.FormatToEmpty(strloginID) != string.Empty)
            {
                strSql = strSql + " And LoginId ='" + Operator.FilterString(strloginID) + "'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted =@isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchAllMemberCount(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "Select Count(guid) from ShopNum1_Member WHERE 1=1 ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted =@isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchAllShopCount(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " And IsDeleted =@isDeleted And IsAudit=1" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchArticleCommentCount(int isAudit, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@isAudit";
            parms[1].Value = isAudit;
            string strSql = string.Empty;
            strSql = "Select count(guid) from ShopNum1_ArticleComment  where 1=1";
            if ((isAudit == 0) || (isAudit == 1))
            {
                strSql = strSql + " And IsAudit =@isAudit" ;
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted =@isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchAuditProductCount(int IsAudit, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@IsAudit";
            parms[1].Value = IsAudit;
            string strSql = string.Empty;
            strSql = "select count(Guid) from ShopNum1_Shop_Product  where 1=1";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " And IsDeleted=@isDeleted " });
            }
            if ((IsAudit == 0) || (IsAudit == 1))
            {
                strSql = string.Concat(new object[] { strSql, " And IsAudit=@IsAudit " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchGroupProduct()
        {
            string strSql = string.Empty;
            strSql =
                "select *from ShopNum1_Group_Product A  INNER JOIN ShopNum1_Product_Activity B ON A.AID=B.Id where a.state=1";
            return DatabaseExcetue.ReturnDataTable(strSql).Rows.Count.ToString();
        }

        public string SearchMessageBoardCount()
        {
            string strSql = string.Empty;
            strSql = "select count(Guid) from ShopNum1_MessageBoard  where IsDeleted=0 and IsReply=0";
            return DatabaseExcetue.ReturnDataTable(strSql).Rows[0][0].ToString();
        }

        public string SearchMessageBoardCount(int isAudit, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@IsAudit";
            parms[1].Value = isAudit;
            string strSql = string.Empty;
            strSql = "Select count(guid) from ShopNum1_MessageBoard  where 1=1";
            if ((isAudit == 0) || (isAudit == 1))
            {
                strSql = strSql + " And IsAudit =@IsAudit" ;
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted =@isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchMessageCount(int isRead, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@isRead";
            parms[1].Value = isRead;
            string strSql = string.Empty;
            strSql = "Select count(MessageInfoGuid) from ShopNum1_UserMessage  where 1=1";
            if ((isRead == 0) || (isRead == 1))
            {
                strSql = strSql + " And IsRead =@isRead" ;
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted =@isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchOrderForDispatch(string strOderStatus, string strShipmentStatus, string strPaymentStatus,
            int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(4);
            parms[0].ParameterName = "@strOderStatus";
            parms[0].Value = Operator.FilterString(strOderStatus);
            parms[1].ParameterName = "@strShipmentStatus";
            parms[1].Value = Operator.FilterString(strShipmentStatus);
            parms[2].ParameterName = "@strPaymentStatus";
            parms[2].Value = Operator.FilterString(strPaymentStatus);
            parms[3].ParameterName = "@isDeleted";
            parms[3].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "select count(guid) from ShopNum1_OrderInfo  where 1=1";
            if (Operator.FilterString(strOderStatus) != string.Empty)
            {
                strSql = strSql + " And OderStatus=@strOderStatus";
            }
            if (Operator.FilterString(strShipmentStatus) != string.Empty)
            {
                strSql = strSql + " And ShipmentStatus=@strShipmentStatus";
            }
            if (Operator.FilterString(strPaymentStatus) != string.Empty)
            {
                strSql = strSql + " And PaymentStatus=@strPaymentStatus";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted=@isDeleted";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchOrderNowCount()
        {
            string str = string.Empty;
            str = "Select Count(guid) from ShopNum1_OrderInfo WHERE 1=1 ";
            return
                DatabaseExcetue.ReturnDataTable(str + " And   DATEDIFF(day,CreateTime,GETDATE())=0" +
                                                " And IsDeleted =0").Rows[0][0].ToString();
        }

        public string SearchOutOfStockRecordCount(int isReply, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@isReply";
            parms[1].Value = isReply;
            string strSql = string.Empty;
            strSql = "select count(Guid) from ShopNum1_OutOfStock  where 1=1";
            if ((isReply == 0) || (isReply == 1))
            {
                strSql = string.Concat(new object[] {strSql, " And IsReply=@isReply "});
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " And IsDeleted=@isDeleted " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchProductCommentCount()
        {
            string strSql = string.Empty;
            strSql =
                "select count(*) from ShopNum1_Shop_ProductComment A   inner join ShopNum1_Shop_Product B on b.guid=a.productguid where a.IsAudit=0 ";
            return DatabaseExcetue.ReturnDataTable(strSql).Rows[0][0].ToString();
        }

        public string SearchProductCommentCount(int isAudit, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            parms[1].ParameterName = "@isAudit";
            parms[1].Value = isAudit;
            string strSql = string.Empty;
            strSql = "Select count(guid) from ShopNum1_Shop_ProductComment  where 1=1";
            if ((isAudit == 0) || (isAudit == 1))
            {
                strSql = strSql + " And IsAudit =@isAudit" ;
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDelete =@isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchProductCount(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
           
            string strSql = string.Empty;
            strSql =
                "select count(A.Guid) from ShopNum1_Shop_Product A inner Join  ShopNum1_ShopInfo B on B.memloginId=A.memloginId   where 1=1 And A.IsAudit=1 And ProductState=0  ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " And A.IsDeleted=@isDeleted " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchProuductCheckedCount()
        {
            string strSql = string.Empty;
            strSql = "select count(Guid) from ShopNum1_Shop_Product  where IsDeleted=0 and IsAudit=0";
            return DatabaseExcetue.ReturnDataTable(strSql).Rows[0][0].ToString();
        }

        public string SearchRecommendCount(string strBest, string strHot, string strRecommend, string strNew,
            int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(5);
            parms[0].ParameterName = "@strBest";
            parms[0].Value = Operator.FilterString(strBest);
            parms[1].ParameterName = "@strHot";
            parms[1].Value = Operator.FilterString(strHot);
            parms[2].ParameterName = "@strRecommend";
            parms[2].Value = Operator.FilterString(strRecommend);
            parms[3].ParameterName = "@isDeleted";
            parms[3].Value = isDeleted;
            parms[4].ParameterName = "@strNew";
            parms[4].Value =Operator.FilterString( strNew);
            string strSql = string.Empty;
            strSql = "Select count(guid) from ShopNum1_Shop_Product  where 1=1";
            if (Operator.FormatToEmpty(strBest) != string.Empty)
            {
                strSql = strSql + " And IsShopGood =@strBes";
            }
            if (Operator.FormatToEmpty(strHot) != string.Empty)
            {
                strSql = strSql + " And IsHot =@strHot and productstate=0";
            }
            if (Operator.FormatToEmpty(strRecommend) != string.Empty)
            {
                strSql = strSql + " And IsRecommend =@strRecommend";
            }
            if (Operator.FormatToEmpty(strNew) != string.Empty)
            {
                strSql = strSql + " And IsNew =@strNew";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " And IsDeleted =@isDeleted And IsAudit=1" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchRegisterMemberCount(string strRegDate, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "Select Count(guid) from ShopNum1_Member WHERE 1=1 ";
            if (Operator.FormatToEmpty(strRegDate) != string.Empty)
            {
                strSql = strSql + " And   DATEDIFF(day,RegeDate,GETDATE())=0";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted =@isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchRegisterShopCount(int isAudit, string strApplyTime, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@isAudit";
            parms[0].Value = isAudit;
           
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
            if ((isAudit == 0) || (isAudit == 1))
            {
                strSql = strSql + " And IsAudit =@isAudit";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = strSql + " And IsDeleted =isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchRepertoryAlertCount(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "Select count(guid) from ShopNum1_Shop_Product  where 1=1";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql =
                    string.Concat(new object[]
                    {
                        strSql, " And IsDeleted =@isDeleted",
                        " and ( RepertoryCount < RepertoryAlertCount or RepertoryCount = RepertoryAlertCount) "
                    });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms).Rows[0][0].ToString();
        }

        public string SearchSaleInfo(string strDispatchTime, int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "Select sum(AlreadPayPrice) from ShopNum1_OrderInfo  where 1=1";
            if (Operator.FormatToEmpty(strDispatchTime) != string.Empty)
            {
                strSql = strSql + " And  DATEDIFF(day,DispatchTime,GETDATE())=0";
            }
            return DatabaseExcetue.ReturnDataTable(strSql).Rows[0][0].ToString();
        }

        public string SearchSaleProductCount(string strDispatchTime, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            
            string str = string.Empty;
            str =
                "Select Count(BuyNumber) from ShopNum1_OrderProduct WHERE OrderInfoGuid IN (Select Guid from ShopNum1_OrderInfo  where 1=1";
            if (Operator.FormatToEmpty(strDispatchTime) != string.Empty)
            {
                str = str + " And  DATEDIFF(day,DispatchTime,GETDATE())=0";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = str + " And IsDeleted =@isDeleted" ;
            }
            return DatabaseExcetue.ReturnDataTable(str + ")",parms).Rows[0][0].ToString();
        }

        public string SearchShopNowCount()
        {
            string str = string.Empty;
            str = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
            return
                DatabaseExcetue.ReturnDataTable(str + " And   DATEDIFF(day,OpenTime,GETDATE())=0" + " And IsDeleted =0")
                    .Rows[0][0].ToString();
        }
    }
}
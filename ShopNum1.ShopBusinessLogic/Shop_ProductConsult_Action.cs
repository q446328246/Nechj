using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_ProductConsult_Action : IShop_ProductConsult_Action
    {
        public int Add(ShopNum1_ShopProductConsult ProductConsult)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_ShopProductConsult( \tGuid\t, \tProductGuid\t, \tTitle\t, \tContent\t, \tConsultPeople\t, \tMemLoginID\t, \tIsReply\t, \tIsAudit\t, \tSendTime\t, \tIsDeleted\t, \tShopID\t, \tIPAddress\t, \tshop_category_id\t  ) VALUES (  '"
                , ProductConsult.Guid, "',  '", ProductConsult.ProductGuid, "',  '", ProductConsult.Title, "',  '",
                ProductConsult.Content, "',  '", ProductConsult.ConsultPeople, "',  '", ProductConsult.MemLoginID,
                "',  ", ProductConsult.IsReply, ",  ", ProductConsult.IsAudit,
                ",  '", ProductConsult.SendTime, "',  ", ProductConsult.IsDeleted, ",  '", ProductConsult.ShopID,
                "',  '", ProductConsult.IPAddress, "',",ProductConsult.shop_category_id," )"
            }));
        }

        public int DeleteByGuid(string guids)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopProductConsult WHERE Guid IN (" + guids + ")");
        }

        public int DeleteByProductGuid(string ProductGuids)
        {
            return
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopProductConsult WHERE ProductGuid IN (" +
                                            ProductGuids + ")");
        }

        public DataTable Search(string MemLoginID, int IsDelete, string ShopID)
        {
            string strSql = string.Empty;
            strSql =
                string.Concat(new object[]
                {
                    "SELECT A.ProductGuid,B.Guid,B.Name,A.MemLoginID,A.SendTime,A.Title,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ShopProductConsult AS A,ShopNum1_Shop_Product AS B   WHERE A.ProductGuid = B.Guid AND A.ShopID ='"
                    , ShopID, "' AND A.IsDeleted =", IsDelete
                });
            if (Operator.FormatToEmpty(MemLoginID) != "-1")
            {
                strSql = strSql + " AND A.MemLoginID = '" + MemLoginID + "' order by A.SendTime desc ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string guid, int IsDeleted, int IsAudit, string ShopID,int category)
        {
            string str = string.Empty;
            str =
                "SELECT ProductGuid,MemLoginID,SendTime,Content,Title,IPAddress,ReplyUser,ReplyTime,ReplyContent,IsReply,IsDeleted,ShopID,ConsultPeople  FROM ShopNum1_ShopProductConsult  WHERE shop_category_id="+category+" and IsDeleted = 0 AND ShopID ='" +
                ShopID + "'";
            if (guid != "-1")
            {
                str = str + " AND ProductGuid = '" + guid + "' ";
            }
            if (IsAudit != -1)
            {
                str = string.Concat(new object[] {str, " AND IsAudit=", IsAudit, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY SendTime  DESC ");
        }

        public DataTable Search(string ProductName, string IsAudit, string IsReply, string ConsultPeople,
            string SendTime1, string SendTime2, string ShopID)
        {
            string str = string.Empty;
            str =
                "SELECT A.ProductGuid,A.Guid,B.Name,B.IsPanicBuy,B.IsSpellBuy,A.MemLoginID,A.SendTime,A.Content,A.Title,A.IsAudit,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.ShopID,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ShopProductConsult AS A,ShopNum1_Shop_Product AS B   WHERE A.ProductGuid = B.Guid AND A.ShopID ='" +
                ShopID + "'  ";
            if (Operator.FormatToEmpty(ProductName) != "-1")
            {
                str = str + " AND B.Name LIKE '" + ProductName.Trim() + "%'";
            }
            if (IsAudit != "-1")
            {
                str = str + " AND A.IsAudit=" + IsAudit;
            }
            if (IsReply != "-1")
            {
                str = str + " AND A.IsReply=" + IsReply;
            }
            if (Operator.FormatToEmpty(ConsultPeople) != "-1")
            {
                str = str + " AND A.ConsultPeople like '%" + ConsultPeople + "%' ";
            }
            if (Operator.FormatToEmpty(SendTime1) != "-1")
            {
                str = str + " AND A.SendTime>='" + Operator.FilterString(SendTime1) + "' ";
            }
            if (Operator.FormatToEmpty(SendTime2) != "-1")
            {
                str = str + " AND A.SendTime<='" + Operator.FilterString(SendTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by A.sendtime desc");
        }

        public DataTable SearchByGuid(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.ProductGuid,A.Guid,B.Name,A.MemLoginID,A.SendTime,A.Title,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ShopID,A.ConsultPeople  FROM ShopNum1_ShopProductConsult AS A,ShopNum1_Shop_Product AS B   WHERE A.ProductGuid = B.Guid ";
            if (Operator.FormatToEmpty(guid) != "-1")
            {
                strSql = strSql + " AND A.Guid =" + guid;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Update(ShopNum1_ShopProductConsult ProductConsult)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_ShopProductConsult   SET \tReplyUser\t='", ProductConsult.ReplyUser,
                        "',\tReplyTime\t='", ProductConsult.ReplyTime, "',\tReplyContent\t='",
                        ProductConsult.ReplyContent, "',\tIsAudit\t=", ProductConsult.IsAudit, ", \tIsReply\t=",
                        ProductConsult.IsReply, "   WHERE Guid='", ProductConsult.Guid, "'"
                    }));
        }

        public int MessageBoardReply(ShopNum1_ShopProductConsult ShopProductConsult)
        {
            object obj2 = string.Empty;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new[]
                    {
                        obj2, "   UPDATE   ShopNum1_ShopProductConsult  SET  ReplyTime ='",
                        ShopProductConsult.ReplyTime, "'  ,  ReplyContent ='", ShopProductConsult.ReplyContent,
                        "'  ,  IsReply=1     "
                    }) + "   WHERE   Guid ='" + ShopProductConsult.Guid +
                    "'    ");
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
            paraValue[3] = "ShopNum1_ShopProductConsult";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "SendTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
    }
}
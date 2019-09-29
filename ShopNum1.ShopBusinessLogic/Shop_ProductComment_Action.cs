using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_ProductComment_Action : IShop_ProductComment_Action
    {
        public DataTable CommentList(string memberid, string commenttype, string guid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memberid";
            paraValue[0] = memberid;
            paraName[1] = "@commenttype";
            paraValue[1] = commenttype;
            paraName[2] = "@guid";
            paraValue[2] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CommentList", paraName, paraValue);
        }

        public DataTable CommentListStatReport(string shopid, string guid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@guid";
            paraValue[1] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CommentListStatReport", paraName, paraValue);
        }

        public DataTable GetCommentDetail(string strOrderguId, string strMemloingId)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select shoploginid,productguid,commenttype,comment,commenttime,productname,(select originalimage from shopnum1_shop_product where guid=t.productguid)img from shopnum1_shop_productcomment as t \r\nwhere orderguid='" +
                    strOrderguId + "' and memloginId='" + strMemloingId + "'");
        }

        public string GetGoodRate(string strShopLoginId, string strType)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shoploginid";
            paraValue[0] = strShopLoginId;
            paraName[1] = "@type";
            paraValue[1] = strType;
            return DatabaseExcetue.ReturnProcedureString("Pro_shop_GetGoodRate", paraName, paraValue).ToString();
        }

        public DataTable GetShopCommentCount(string strMemloginId, string strIsShop)
        {
            string strSql =
                "select CommentTime,CommentType,isAudit from ShopNum1_Shop_ProductComment where 1=1 and isaudit=1 ";
            if (strIsShop == "0")
            {
                strSql = strSql + " and memloginid='" + strMemloginId + "'";
            }
            else
            {
                strSql = strSql + " and shoploginid='" + strMemloginId + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public string GetShopIDByName(string name)
        {
            return
                DatabaseExcetue.ReturnString(" select ShopID from ShopNum1_ShopInfo where MemLoginID='" + name +
                                             "' and isaudit=1");
        }

        public DataSet ProductCommentList(string productguid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@productguid";
            paraValue[0] = productguid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ProductCommentList", paraName, paraValue);
        }

        public DataSet ProductCommentListByGuidAndMemLoginID(string productguid, string memloginid, string strType)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@productguid";
            paraValue[0] = productguid;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            paraName[2] = "@type";
            paraValue[2] = strType;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ProductCommentListShow", paraName, paraValue);
        }

        public int ReplyComment(string guid, string reply)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@reply";
            paraValue[1] = reply;
            return DatabaseExcetue.RunProcedure("Pro_Shop_ReplyComment", paraName, paraValue);
        }

        public DataTable SelectShopComment(string strPageSize, string strCurrentPage, string strCondition,
            string strResultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = strPageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = strCurrentPage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_ProductComment";
            paraName[4] = "@condition";
            paraValue[4] = strCondition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "commenttime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = strResultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectShopDetailComment(string strPageSize, string strCurrentPage, string strCondition,
            string strResultnum, string strShopID, string strType,
            string strProductGuID)
        {
            string str =
                "select (select photo from shopnum1_member where memloginid=t.memloginid)pic,* from ShopNum1_Shop_ProductComment as t where shopid='" +
                strShopID + "' and productguid='" + strProductGuID + "' and isaudit=1";
            if (strType == "2")
            {
                str =
                    ("select (select photo from shopnum1_member where memloginid=t.memloginid)pic,* from ShopNum1_Shop_ProductComment as t where shopid='" +
                     strShopID + "' ") + "and productguid in(select productguid from ShopNum1_Group_Product where id='" +
                    strProductGuID + "') and isaudit=1 ";
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = strPageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = strCurrentPage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = strCondition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "commenttime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = strResultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public DataTable ShopComment(string type, string shopid)
        {
            string strSql = string.Empty;
            strSql =
                "select  a.CommentType, a.Comment, a.ProductName, b.BuyPrice, a.MemLoginID, a.CommentTime  from ShopNum1_Shop_ProductComment as a , ShopNum1_OrderProduct as b  where a.ShopID='" +
                shopid + "' and a.ProductGuid=b.ProductGuid and  a.OrderGuid=b.OrderInfoGuid and a.IsAudit=1";
            if (type != string.Empty)
            {
                strSql = strSql + " and a.CommentType=" + type;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable ShopComment(string type, string timetype, string shopid)
        {
            string strSql = string.Empty;
            strSql = "select count(Guid) from ShopNum1_Shop_ProductComment where ShopID='" + shopid + "' AND IsAudit=1 ";
            if (type != string.Empty)
            {
                strSql = strSql + " and CommentType=" + type;
            }
            if (timetype != string.Empty)
            {
                string str2 = timetype;
                switch (str2)
                {
                    case null:
                        goto Label_014C;

                    case "1":
                        strSql = strSql + " and CommentTime>='" +
                                 DateTime.Now.AddDays(-7.0).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        goto Label_014C;

                    case "2":
                        strSql = strSql + " and CommentTime>='" +
                                 DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        goto Label_014C;
                }
                if (!(str2 == "3"))
                {
                    if (str2 == "4")
                    {
                        strSql = strSql + " and CommentTime<'" +
                                 DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    }
                }
                else
                {
                    strSql = strSql + " and CommentTime>='" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd HH:mm:ss") +
                             "'";
                }
            }
            Label_014C:
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable ShopCommentInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ShopCommentInfo", paraName, paraValue);
        }

        public DataSet ShopCommentNew(string shopid, string type, string ordertype, string sort, string perpagenum,
            string current_page, string isreturcount)
        {
            string str = string.Empty;
            if (type == "0")
            {
                str = " AND A.continuecomment!='' and A.isaudit=1";
            }
            else if (type != string.Empty)
            {
                str = " AND A.CommentType='" + type + "' and A.isaudit=1";
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@columnnames";
            paraValue[1] =
                " a.Comment,a.CommentType,a.ProductName,a.MemLoginID,a.CommentTime,a.productprice as BuyPrice,A.isaudit,a.continuecomment  ";
            paraName[2] = "@searchname";
            paraValue[2] = str;
            paraName[3] = "@ordertype";
            paraValue[3] = ordertype;
            paraName[4] = "@sort";
            paraValue[4] = sort;
            paraName[5] = "@perpagenum";
            paraValue[5] = perpagenum;
            paraName[6] = "@current_page";
            paraValue[6] = current_page;
            paraName[7] = "@isreturcount";
            paraValue[7] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ShopCommentNew", paraName, paraValue);
        }

        public int UpdateContinueComment(string strOrderguId, string strMemloingId, string strComment,
            string strProductGuID)
        {
            return
                DatabaseExcetue.RunNonQuery(("update shopnum1_shop_productcomment set continuecomment='" + strComment +
                                             "',continuetime='" +
                                             DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") +
                                             "' where orderguid='" + strOrderguId + "' and memloginId='" + strMemloingId +
                                             "' And ProductGuId='" + strProductGuID + "';") +
                                            "update shopnum1_orderinfo set isbuycomment=2 where guid='" + strOrderguId +
                                            "';");
        }
    }
}
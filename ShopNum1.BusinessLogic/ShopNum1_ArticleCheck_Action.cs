using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ArticleCheck_Action : IShopNum1_ArticleCheck_Action
    {
        public int Delete(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_News WHERE Guid IN (@guids) ",parms);
        }

        public DataTable GetEditInfo(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guid;
            string strSql =
                "SELECT Guid, Title, [Content], IsShow, OrderID, CreateTime, SEOTitle, Keywords, Description, NewsCategoryGuid, MemLoginID, IsAudit   FROM ShopNum1_Shop_News  Where 0=0";
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND  Guid= @guids ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable Search(string title, string shopID, string startdate, string enddate, int IsAudit,
            int isDeleted)
        {
            object obj2;
            string str = string.Empty;
            str =
                "SELECT   A.Guid, A.Title, A.[Content], A.IsShow, A.OrderID, A.CreateTime, A.SEOTitle, A.Keywords, A.Description, A.NewsCategoryGuid, A.MemLoginID, A.IsAudit,B.Name  FROM ShopNum1_Shop_News A LEFT JOIN ShopNum1_Shop_NewsCategory B on A.NewsCategoryGuid=B.Guid  Where 0=0";
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            if (Operator.FormatToEmpty(shopID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + shopID + "%'";
            }
            if (Operator.FormatToEmpty(startdate) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(startdate) + "' ";
            }
            if (Operator.FormatToEmpty(enddate) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(enddate) + "' ";
            }
            if (IsAudit != -1)
            {
                if (IsAudit == -2)
                {
                    str = str + " AND A.IsAudit IN (0,2) ";
                }
                else if (IsAudit == -3)
                {
                    str = str + " AND A.IsAudit IN (1,3) ";
                }
                else
                {
                    obj2 = str;
                    str = string.Concat(new[] {obj2, " AND A.IsAudit =", IsAudit, " "});
                }
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsDeleted =", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY A.OrderID DESC");
        }

        public DataTable SearchDetailsByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guid;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT A.CreateTime,A.Title,A.Content,A.Keywords,A.MemLoginID,B.Name FROM ShopNum1_Shop_News AS A, ShopNum1_Shop_NewsCategory AS B WHERE A.NewsCategoryGuid=B.Guid AND A.Guid=@guids",parms);
        }

        public int UpdateAudit(string guids, int isAudit)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            parms[1].ParameterName = "@isAudit";
            parms[1].Value = isAudit;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[] { "UPDATE ShopNum1_Shop_News SET  IsAudit\t=@isAudit WHERE Guid in (@guids)" }),parms);
        }

        public int DeleteArticleComment(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ArticleComment  WHERE Guid IN (@guids) ",parms);
        }

        public DataTable GetTitleByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable("    SELECT  Title  FROM  ShopNum1_Article  WHERE  Guid =@guid",parms);
        }

        public DataSet Search(string pageindex, string pagesize, string addresscode, string articlecategory,
            string startTime, string endTime, string keywords, string title)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@pageindex";
            paraValue[0] = pageindex;
            paraName[1] = "@pagesize";
            paraValue[1] = pagesize;
            paraName[2] = "@articlecategory";
            paraValue[2] = articlecategory;
            paraName[3] = "@createtime1";
            paraValue[3] = startTime;
            paraName[4] = "@createtime2";
            paraValue[4] = endTime;
            paraName[5] = "@keywords";
            paraValue[5] = keywords;
            paraName[6] = "@title";
            paraValue[6] = title;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetArticleInfoSearch", paraName, paraValue);
        }

        public DataTable SearchCommentDetailByGuid(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable((string.Empty +
                                                 "     SELECT A.* ,B.Title  AS ArticleTitle  FROM ShopNum1_ArticleComment AS  A  LEFT JOIN ShopNum1_Article AS B       " +
                                                 "     ON A.ArticleGuid=B.Guid      ") + "     WHERE A.Guid='@guid",parms);
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
            paraValue[2] = " *  ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_ArticleComment";
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
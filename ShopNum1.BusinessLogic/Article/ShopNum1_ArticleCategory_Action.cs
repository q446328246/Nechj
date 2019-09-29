using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ArticleCategory_Action : IShopNum1_ArticleCategory_Action
    {
        private static DataTable dt;

        public static DataTable ArticleCategoryTable
        {
            get
            {
                if (dt == null)
                {
                    string strSql =
                        "SELECT ID,Name,OrderID,FatherID FROM ShopNum1_ArticleCategory where IsShow =1 and IsDeleted=0 ORDER BY OrderID DESC";
                    dt = DatabaseExcetue.ReturnDataTable(strSql);
                }
                return dt;
            }
            set { dt = value; }
        }

        public int Add(ShopNum1_ArticleCategory articleCategory)
        {
            ArticleCategoryTable = null;
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_ArticleCategory( \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  ) VALUES (  '"
                , Operator.FilterString(articleCategory.Name), "',  '",
                Operator.FilterString(articleCategory.Keywords), "',  '",
                Operator.FilterString(articleCategory.Description), "',  ", articleCategory.OrderID, ",  ",
                articleCategory.IsShow, ",  ", articleCategory.CategoryLevel, ",  ", articleCategory.FatherID,
                ",  '", articleCategory.Family,
                "',  '", articleCategory.CreateUser, "', '", articleCategory.CreateTime, "',  '",
                articleCategory.ModifyUser, "' , '", articleCategory.ModifyTime, "',  ", articleCategory.IsDeleted,
                ")"
            }));
        }

        public int Delete(string string_0)
        {
            ArticleCategoryTable = null;
            if (DatabaseExcetue.CheckExists("Select Count(*) from ShopNum1_ArticleCategory where fatherid =" + string_0))
            {
                return 2;
            }
            if (
                DatabaseExcetue.CheckExists("Select  Count(*)  from ShopNum1_Article where ArticleCategoryID =" +
                                            string_0))
            {
                return -1;
            }
            string strSql = "Delete from ShopNum1_ArticleCategory where ID = " + string_0;
            try
            {
                DatabaseExcetue.RunNonQuery(strSql);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable GetArticleCategory(string FatherId)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@FatherID";
            paraValue[0] = FatherId;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetArticleCategory", paraName, paraValue);
        }

        public DataTable GetArticleCategoryMeto(string strID)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tID, \tName\t, \tKeywords,\tDescription\t FROM ShopNum1_ArticleCategory WHERE ID ='" +
                    strID + "'");
        }

        public DataTable GetArticleInfoByID(string string_0)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetArticleInfoByID", paraName, paraValue);
        }

        public DataTable GetEditInfo(string strID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            string strSql =
                "SELECT \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_ArticleCategory  Where 0=0";
            if (Operator.FormatToEmpty(strID) != string.Empty)
            {
                strSql = strSql + " AND  ID=@strID";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int GetMaxID()
        {
            return (DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_ArticleCategory") + 1);
        }

        public string GetNameByID(int int_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@int_0";
            parms[0].Value = int_0;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tID\t, \tName\t  FROM ShopNum1_ArticleCategory  WHERE 1=1 And ID =@int_0",parms).Rows[0]["Name"
                    ].ToString();
        }

        public DataTable Search(int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tID AS GUID, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ArticleCategory WHERE IsDeleted =@isDeleted ORDER BY OrderID DESC",parms);
        }

        public DataTable Search(int fatherID, int isDeleted)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ArticleCategory  WHERE FatherID ="
                        , fatherID, " AND  IsDeleted =", isDeleted
                    }) + " ORDER BY OrderID DESC");
        }

        public DataTable SearchByFatherID(string fatherID, string showcount, string isDeleted)
        {
            string str = string.Empty;
            str = "SELECT ";
            if (!string.IsNullOrEmpty(showcount))
            {
                str = str + " TOP   " + showcount;
            }
            str = str +
                  "\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ArticleCategory  WHERE 1=1 ";
            if (!string.IsNullOrEmpty(fatherID))
            {
                str = str + " AND FatherID =" + fatherID;
            }
            if (!string.IsNullOrEmpty(isDeleted))
            {
                str = str + " AND isDeleted =" + isDeleted;
            }
            return DatabaseExcetue.ReturnDataTable(str + " AND IsShow=1  ORDER BY OrderID DESC");
        }

        public DataTable SearchID(int int_0)
        {
            return DatabaseExcetue.ReturnDataTable("select [ID] from ShopNum1_ArticleCategory where FatherID=" + int_0);
        }

        public DataTable SearchShow(int fatherID, int isDeleted)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ArticleCategory  WHERE IsShow=1 AND FatherID ="
                        , fatherID, " AND  IsDeleted =", isDeleted
                    }) + " ORDER BY OrderID DESC");
        }

        public int Update(ShopNum1_ArticleCategory articleCategory)
        {
            ArticleCategoryTable = null;
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_ArticleCategory   SET    [Name]\t='", Operator.FilterString(articleCategory.Name),
                "', \tKeywords\t='", Operator.FilterString(articleCategory.Keywords), "',\tDescription\t='",
                Operator.FilterString(articleCategory.Description), "',\tOrderID\t='", articleCategory.OrderID,
                "',\tIsShow\t=", articleCategory.IsShow, ",\tCategoryLevel\t=", articleCategory.CategoryLevel,
                ",\tFatherID\t=", articleCategory.FatherID, ",\tFamily\t='", articleCategory.Family,
                "',\tModifyUser='", articleCategory.ModifyUser, "' ,\tModifyTime\t='", articleCategory.ModifyTime,
                "', \tIsDeleted =", articleCategory.IsDeleted, "   WHERE ID=", articleCategory.ID
            }));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Article_Action : IShopNum1_Article_Action
    {
        /// <summary>
        ///     添加新闻
        /// </summary>
        /// <param name="article"></param>
        /// <param name="strRelateArticleList"></param>
        /// <param name="strRelateProductList"></param>
        /// <returns></returns>
        public int Add(ShopNum1_Article article, List<string> strRelateArticleList, List<string> strRelateProductList)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Article(  Guid ,  Title ,  ArticleCategoryID ,  Publisher ,  Source ,  Content ,  Keywords ,  Description ,  IsShow ,  IsAllowComment ,  OrderID ,  IsHot ,  IsRecommend ,  IsHead ,  CreateUser ,  CreateTime ,  ModifyUser ,  ModifyTime ,  IsDeleted , ClickCount , IsAudit  ) VALUES (  '"
                , article.Guid, "',  '", Operator.FilterString(article.Title), "',  ", article.ArticleCategoryID,
                ",  '", Operator.FilterString(article.Publisher), "',  '", Operator.FilterString(article.Source),
                "',  '", article.Content, "',  '", Operator.FilterString(article.Keywords), "',  '",
                Operator.FilterString(article.Description),
                "',  ", article.IsShow, ",  ", article.IsAllowComment, ",  ", article.OrderID, ",  ", article.IsHot,
                ",  ", article.IsRecommend, ",  ", article.IsHead, ",  '", Operator.FilterString(article.CreateUser)
                , "', '", article.CreateTime,
                "',  '", Operator.FilterString(article.ModifyUser), "' , '", article.ModifyTime, "',  ",
                article.IsDeleted, " , ", article.ClickCount, " , ", article.IsAudit, " )"
            });
            sqlList.Add(item);
            for (int i = 0; i < strRelateArticleList.Count; i++)
            {
                string[] strArray = strRelateArticleList[i].Split(new[] {';'});
                string str3 =
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_RelatedArticle( ArticleGuid, IsBoth, SubArticleGuid, CreateUser, CreateTime  ) VALUES (  '"
                        , article.Guid, "',  '", strArray[1], "',  '", strArray[0], "',  '", article.CreateUser,
                        "', '", article.CreateTime, "' )"
                    });
                sqlList.Add(str3);
            }
            for (int j = 0; j < strRelateProductList.Count; j++)
            {
                string str2 =
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_ProductArticle( ArticleGuid, ProductGuid, CreateUser, CreateTime  ) VALUES (  '"
                        , article.Guid, "',  '", strRelateProductList[j], "',  '", article.CreateUser, "', '",
                        article.CreateTime, "' )"
                    });
                sqlList.Add(str2);
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
        ///     删除新闻
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public int Delete(string guids)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = "delete from ShopNum1_RelatedArticle  WHERE ArticleGuid IN (" + guids + ") ";
            sqlList.Add(item);
            item = "delete from ShopNum1_Article  WHERE Guid IN (" + guids + ") ";
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
        ///     新闻类别
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public DataTable GetArticleCategoryInfo(int isDeleted)
        {
            string strSql = "SELECT  ID as Code,  Name  as Name FROM ShopNum1_ArticleCategory  where 1=1";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                object obj2 = strSql;
                strSql = string.Concat(new[] {obj2, " AND IsDeleted =", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetArticleIsHotorIsRecommend(string showCount, string categoryID, string type)
        {
            string strSql = string.Empty;
            if (string.IsNullOrEmpty(showCount))
            {
                strSql = "SELECT  Top 10";
            }
            else
            {
                strSql = "SELECT  top " + showCount;
            }
            strSql = strSql +
                     "  Guid, Title ,  Keywords ,  Description   FROM ShopNum1_Article  Where ArticleCategoryID=" +
                     categoryID;
            if (type == "Ishot")
            {
                strSql = strSql + " and  IsHot=1 ";
            }
            else
            {
                strSql = strSql + " and  IsRecommend=1 ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetArticleMeto(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  Title ,  Keywords ,  Description   FROM ShopNum1_Article  Where Guid=@guid",parms);
        }

        public DataTable GetArticleOnAndNext(string guid, string onArticleName, string nextArticleName)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @modifyTime datetime ");
            builder.Append("SELECT @modifyTime = ModifyTime FROM ShopNum1_Article ");
            builder.Append("WHERE Guid = '" + guid + "' ");
            builder.Append("SELECT * FROM(");
            builder.Append("SELECT TOP 1 Guid,Title,'" + onArticleName + "' as [Name] FROM ShopNum1_Article ");
            builder.Append("WHERE ModifyTime < @modifyTime ");
            builder.Append("ORDER BY ModifyTime DESC");
            builder.Append(") as a ");
            builder.Append("UNION ");
            builder.Append("SELECT * FROM(");
            builder.Append("SELECT TOP 1 Guid,Title,'" + nextArticleName + "' as [Name] FROM ShopNum1_Article ");
            builder.Append("WHERE ModifyTime > @modifyTime ");
            builder.Append("ORDER BY ModifyTime ASC ");
            builder.Append(") as b");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetChildCategory(string showcount, string fatherId)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(showcount))
            {
                str = "SELECT  Top 10";
            }
            else
            {
                str = "SELECT  top " + showcount;
            }
            return
                DatabaseExcetue.ReturnDataTable(str + "  ID, Name  FROM ShopNum1_ArticleCategory  Where FatherID=" +
                                                fatherId);
        }

        public DataTable GetEditInfo(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");

            string strSql =
                "SELECT  Guid ,  Title ,  ArticleCategoryID ,  Publisher ,  Source ,  Content ,  Keywords ,  Description ,  IsShow ,  IsAllowComment ,  OrderID ,  IsHot ,  IsRecommend ,  IsHead ,  CreateUser ,  CreateTime ,  ModifyUser ,  ModifyTime ,  ClickCount ,  IsDeleted  FROM ShopNum1_Article  Where 0=0 ";
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND  Guid=@guid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public string GetNameByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable("SELECT Guid,Title FROM ShopNum1_Article  WHERE Guid =@guid",parms)
                    .Rows[0][1].ToString();
        }

        public DataTable GetProductCategoryInfo(int isDeleted)
        {
            string strSql = "SELECT  ID as Code,  Name  as Name FROM dbo.ShopNum1_ProductCategory  where 1=1";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                object obj2 = strSql;
                strSql = string.Concat(new[] {obj2, " AND IsDeleted =", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetRelatedArticleInfo(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  ArticleGuid ,  IsBoth ,  SubArticleGuid ,  CreateUser ,  CreateTime  FROM ShopNum1_RelatedArticle  Where ArticleGuid=@guid",parms);
        }

        public DataTable GetRelatedProductInfo(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  ArticleGuid ,  ProductGuid ,  CreateUser ,  CreateTime  FROM ShopNum1_ProductArticle  Where ArticleGuid=@guid",parms);
        }

        public DataTable GetTitleByID(string ID, string type, string ShowCount)
        {
            var builder = new StringBuilder();
            builder.Append("select top (" + ShowCount + ") ");
            builder.Append(" Title,[Guid] ");
            builder.Append("FROM ShopNum1_Article ");
            builder.Append("WHERE ArticleCategoryID in " + ID + " ");
            if (type == "IsHead")
            {
                builder.Append(" AND IsHead = 1 ");
            }
            else if (type == "IsHot")
            {
                builder.Append(" AND IsHot = 1 ");
            }
            else if (type == "IsRecommend")
            {
                builder.Append(" AND IsRecommend = 1");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable Search(string Title, int articleCategoryID)
        {
            string strSql = "SELECT  Guid ,  Title ,  ArticleCategoryID   FROM ShopNum1_Article  Where IsDeleted = 0 ";
            if (Operator.FormatToEmpty(Title) != string.Empty)
            {
                strSql = strSql + " AND Title='" + Operator.FilterString(Title) + "'";
            }
            if (articleCategoryID != -1)
            {
                strSql = strSql + " AND ArticleCategoryID=" + articleCategoryID;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string title, string publisher, int articlecategoryid, string startdate, string enddate,
            int isshow, int ishot, int isrecommand, int ishead, int isallowcomment, int isDeleted)
        {
            object obj2;
            string str = string.Empty;
            str =
                "SELECT    Guid ,  A.Title ,  B.Name ,  A.Publisher ,  A.Source ,  A.Content ,  A.Keywords ,  A.Description ,  A.IsShow ,  A.IsAllowComment ,  A.OrderID ,  A.IsHot ,  A.IsRecommend ,  A.IsHead ,  A.CreateUser ,  A.CreateTime ,  A.ModifyUser ,  A.ModifyTime ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0";
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            if (Operator.FormatToEmpty(publisher) != string.Empty)
            {
                str = str + " AND A.Publisher LIKE '%" + Operator.FilterString(publisher) + "%'";
            }
            if (articlecategoryid != -1)
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.ArticleCategoryID =", articlecategoryid, " "});
            }
            if (Operator.FormatToEmpty(startdate) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(startdate) + "' ";
            }
            if (Operator.FormatToEmpty(enddate) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(enddate) + "' ";
            }
            if ((isshow == 0) || (isshow == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsShow =", isshow, " "});
            }
            if ((ishot == 0) || (ishot == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsHot =", ishot, " "});
            }
            if ((isrecommand == 0) || (isrecommand == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsRecommend =", isrecommand, " "});
            }
            if ((ishead == 0) || (ishead == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsHead =", ishead, " "});
            }
            if ((isallowcomment == 0) || (isallowcomment == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsAllowComment =", isallowcomment, " "});
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.IsDeleted =", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY A.OrderID DESC");
        }

        public DataTable SearchArticle(string title)
        {
            string str = string.Empty;
            str =
                "SELECT   Guid ,  Title ,  Publisher ,  CreateTime ,  IsDeleted  FROM ShopNum1_Article Where 0=0 AND IsShow = 1 AND IsDeleted=0 ";
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime Desc");
        }

        public DataTable SearchArticle(string articlename, string articlecode, string pageindex, string pagesize,
            string isreturcount)
        {
            string str = string.Empty;
            if (!(string.IsNullOrEmpty(articlename) || !(articlename != "-1")))
            {
                str = str + " AND A.title like '%" + articlename + "%' ";
            }
            if (!(string.IsNullOrEmpty(articlecode) || !(articlecode != "-1")))
            {
                string str2 = str;
                str = str2 + " AND A.ArticleCategoryID  in(select id from ShopNum1_ArticleCategory where fatherid='" +
                      articlecode + "' union all select " + articlecode + " as id) ";
            }
            str = str + " AND A.IsShow=1 AND A.IsAudit=1 AND A.IsDeleted=0 ";
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@perpagenum";
            paraValue[0] = pagesize;
            paraName[1] = "@current_page";
            paraValue[1] = pageindex;
            paraName[2] = "@columnnames";
            paraValue[2] =
                " A.Guid,A.ClickCount,A.Title,A.Description,A.Publisher,A.Source,A.Content,A.Keywords,A.CreateTime,B.Name ";
            paraName[3] = "@searchname";
            paraValue[3] = str;
            paraName[4] = "@isreturcount";
            paraValue[4] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonArticles", paraName, paraValue);
        }

        public DataTable SearchArticleList(string guid, int articleCategoryID)
        {
            string strSql = string.Empty;
            if (articleCategoryID != -1)
            {
                object obj2 = strSql + " Create TABLE #Temp(ID INT) ";
                obj2 =
                    string.Concat(new[]
                    {
                        obj2, " INSERT #Temp SELECT ID  FROM ShopNum1_ArticleCategory WHERE FatherID=",
                        articleCategoryID, " OR ID=", articleCategoryID, " "
                    });
                strSql =
                    string.Concat(new[]
                    {
                        obj2,
                        " INSERT #Temp SELECT ID  FROM ShopNum1_ArticleCategory WHERE FatherID IN (SELECT ID FROM ShopNum1_ArticleCategory WHERE FatherID="
                        , articleCategoryID, ") "
                    });
            }
            strSql = strSql +
                     "select  Title,  Publisher,  Keywords,  CreateTime,  OrderID,  Guid  From ShopNum1_Article  where 1=1";
            if (Operator.FormatToEmpty(guid) != "0")
            {
                strSql = strSql + " AND Guid='" + guid + "'";
            }
            if (articleCategoryID != -1)
            {
                strSql = strSql + " AND ArticleCategoryID IN(SELECT * FROM  #Temp) ";
            }
            strSql = strSql + " ORDER BY OrderID DESC";
            if (articleCategoryID != -1)
            {
                strSql = strSql + " DROP TABLE #Temp";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchArticleList(string guid, int articleCategoryID, int count)
        {
            object obj2;
            string strSql = string.Empty;
            if (articleCategoryID != -1)
            {
                obj2 = strSql + " Create TABLE #Temp(ID INT) ";
                obj2 =
                    string.Concat(new[]
                    {
                        obj2, " INSERT #Temp SELECT ID  FROM ShopNum1_ArticleCategory WHERE FatherID=",
                        articleCategoryID, " OR ID=", articleCategoryID, " "
                    });
                strSql =
                    string.Concat(new[]
                    {
                        obj2,
                        " INSERT #Temp SELECT ID  FROM ShopNum1_ArticleCategory WHERE FatherID IN (SELECT ID FROM ShopNum1_ArticleCategory WHERE FatherID="
                        , articleCategoryID, ") "
                    });
            }
            obj2 = strSql;
            strSql =
                string.Concat(new[]
                {
                    obj2, "select top ", count,
                    " Title,  Publisher,  Keywords,  CreateTime,  OrderID,  Guid  From ShopNum1_Article  where 1=1"
                });
            if (Operator.FormatToEmpty(guid) != "0")
            {
                strSql = strSql + " AND Guid='" + guid + "'";
            }
            if (articleCategoryID != -1)
            {
                strSql = strSql + " AND ArticleCategoryID IN(SELECT * FROM  #Temp) ";
            }
            strSql = strSql + " ORDER BY OrderID DESC";
            if (articleCategoryID != -1)
            {
                strSql = strSql + " DROP TABLE #Temp";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchArticleRelatedArticle(string guid, int count)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@count";
            parms[1].Value = count;
            string str = string.Empty;
            if (count > 0)
            {
                str = "SELECT top @count";
            }
            else
            {
                str = "SELECT ";
            }
            return
                DatabaseExcetue.ReturnDataTable(str +
                                                " Guid,Title FROM ShopNum1_Article AS A,(SELECT ArticleGuid,SubArticleGuid FROM ShopNum1_RelatedArticle WHERE ArticleGuid=@guid ) AS B WHERE A.Guid=B.SubArticleGuid",parms);
        }

        public DataTable SearchByArticleCategoryID(int articleCategoryID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@articleCategoryID";
            parms[0].Value = articleCategoryID;
            string strSql = "SELECT  Guid ,  Title ,  ArticleCategoryID   FROM ShopNum1_Article  Where IsDeleted = 0 ";
            if (articleCategoryID != -1)
            {
                strSql = strSql + " AND ArticleCategoryID=@articleCategoryID";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchByArticleCategoryID(int articleCategoryID, int showCount)
        {
            string str = "SELECT  TOP " + showCount +
                         " Guid ,  Title ,  ArticleCategoryID   FROM ShopNum1_Article  Where IsDeleted = 0 ";
            if (articleCategoryID != -1)
            {
                str = str + " AND ArticleCategoryID=" + articleCategoryID;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID DESC");
        }

        public DataTable SearchByCategoryIDFrist(int articleCategoryID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@articleCategoryID";
            parms[0].Value = articleCategoryID;
            var builder = new StringBuilder();
            builder.Append("SELECT  TOP 1 Guid,Title,Description FROM ShopNum1_Article where ArticleCategoryID =@articleCategoryID ");
            builder.Append(" ORDER BY CreateTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchByCategoryIDOther(int articleCategoryID, string guid, string showCount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT TOP " + showCount +
                           " ShopNum1_Article.Guid,ShopNum1_Article.CreateTime,ShopNum1_Article.Title,ShopNum1_ArticleCategory.ID,");
            builder.Append("ShopNum1_Article.Description,ShopNum1_ArticleCategory.Name FROM ShopNum1_Article,");
            builder.Append(
                "ShopNum1_ArticleCategory where ShopNum1_ArticleCategory.ID = ShopNum1_Article.ArticleCategoryID");
            builder.Append(" and ShopNum1_Article.ArticleCategoryID = " + articleCategoryID);
            builder.Append(" and guid not in ('" + guid + "') ORDER BY ShopNum1_Article.CreateTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchNewArticle(int count)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@count";
            parms[0].Value = count;
            string strSql = string.Empty;
            if (count > 0)
            {
                strSql = "SELECT  top  " + count + "  Guid ,  A.Title ,  B.Name ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0 AND A.IsShow = 1 AND A.IsDeleted=0  ORDER BY A.CreateTime Desc";
            }
            else
            {
                strSql =
                    "SELECT   Guid ,  A.Title ,  B.Name ,  A.IsDeleted  FROM ShopNum1_Article A LEFT JOIN ShopNum1_ArticleCategory B on A.ArticleCategoryID=B.ID  Where 0=0 AND A.IsShow = 1 AND A.IsDeleted=0  ORDER BY A.CreateTime Desc";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int Update(ShopNum1_Article article, List<string> strRelateArticleList, List<string> strRelateProductList)
        {
            int num;
            string[] strArray;
            string str2;
            var sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[]
            {
                "UPDATE ShopNum1_Article SET  Title='", Operator.FilterString(article.Title),
                "', ArticleCategoryID='", article.ArticleCategoryID, "', Publisher='",
                Operator.FilterString(article.Publisher), "', Source='", Operator.FilterString(article.Source),
                "', Content='", article.Content, "', Keywords='", Operator.FilterString(article.Keywords),
                "', Description='", Operator.FilterString(article.Description), "', IsShow=", article.IsShow,
                ", IsAllowComment=", article.IsAllowComment, ", OrderID=", article.OrderID, ", IsHot=",
                article.IsHot, ", IsRecommend=", article.IsRecommend, ", IsHead=", article.IsHead, ", ModifyUser='",
                article.ModifyUser, "', ModifyTime='", article.ModifyTime, "', IsDeleted='", article.IsDeleted,
                "'WHERE Guid='", article.Guid, "'"
            });
            sqlList.Add(item);
            item = "Delete from ShopNum1_RelatedArticle where ArticleGuid='" + article.Guid + "'";
            sqlList.Add(item);
            for (num = 0; num < strRelateArticleList.Count; num++)
            {
                strArray = strRelateArticleList[num].Split(new[] {';'});
                str2 =
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_RelatedArticle( ArticleGuid, IsBoth, SubArticleGuid, CreateUser, CreateTime  ) VALUES (  '"
                        , article.Guid, "',  '", strArray[1], "',  '", strArray[0], "',  '", article.ModifyUser,
                        "', '", article.ModifyTime, "' )"
                    });
                sqlList.Add(str2);
            }
            for (num = 0; num < strRelateProductList.Count; num++)
            {
                strArray = strRelateProductList[num].Split(new[] {';'});
                str2 =
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_ProductArticle( ArticleGuid, ProductGuid,CreateUser, CreateTime  ) VALUES (  '"
                        , article.Guid, "',  '", new Guid(strArray[0]), "',  '", article.ModifyUser, "', '",
                        article.ModifyTime, "' )"
                    });
                sqlList.Add(str2);
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

        public int UpdateClickCount(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.RunNonQuery(" UPDATE ShopNum1_Article SET ClickCount=ClickCount+1 WHERE GUID=@guid",parms);
        }

        public DataTable GetAnnouncementByTypeName(string Name, int int_0)
        {
            object obj2 = string.Empty;
            string str2 =
                string.Concat(new[]
                {
                    obj2, "    SELECT  TOP   ", int_0,
                    "    A.* FROM ShopNum1_Announcement AS A LEFT JOIN ShopNum1_AnnouncementCategory AS B      "
                }) +
                "    ON A.AnnouncementCategoryID =B.ID     ";
            return
                DatabaseExcetue.ReturnDataTable(str2 + "    WHERE B.Name='" + Name + "'   AND   A.CreateTime <='" +
                                                DateTime.Now + "'         ORDER  BY   A.CreateTime  DESC    ");
        }
    }
}
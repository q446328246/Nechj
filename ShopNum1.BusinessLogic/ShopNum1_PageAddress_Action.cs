using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_PageAddress_Action : IShopNum1_PageAddress_Action
    {
        public DataTable GetArticleCategoryPageAddress(string ArticleCategoryID)
        {
            var builder = new StringBuilder();
            builder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
            builder.Append(" SET @id=" + ArticleCategoryID);
            builder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ArticleCategory WHERE ID = @id");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_ArticleCategory WHERE ID = @fatherid) > 0) ");
            builder.Append(" BEGIN ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ArticleCategory WHERE ID = @fatherid");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" END");
            builder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetArticlePageAddress(string guid)
        {
            var builder = new StringBuilder();
            builder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
            builder.Append(
                " SELECT @id = B.ID FROM ShopNum1_Article AS A,ShopNum1_ArticleCategory AS B where A.[Guid]='" + guid +
                "' AND A.ArticleCategoryID=B.ID");
            builder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ArticleCategory WHERE ID = @id");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_ArticleCategory WHERE ID = @fatherid) > 0) ");
            builder.Append(" BEGIN ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ArticleCategory WHERE ID = @fatherid");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" END");
            builder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetHelpCategoryPageAddress(string guid)
        {
            var builder = new StringBuilder();
            builder.Append(" DECLARE @HelpTypeGuid Uniqueidentifier");
            builder.Append(" SELECT @HelpTypeGuid=HelpTypeGuid FROM ShopNum1_Help WHERE [guid]='" + guid + "'");
            builder.Append(" SELECT [guid],[name] FROM ShopNum1_HelpType WHERE [guid]=@HelpTypeGuid");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetProductCategoryPageAddress(string ProductCategoryID)
        {
            var builder = new StringBuilder();
            builder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
            builder.Append(" SET @id=" + ProductCategoryID);
            builder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ProductCategory WHERE ID = @id");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE ID = @fatherid) > 0) ");
            builder.Append(" BEGIN ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ProductCategory WHERE ID = @fatherid");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" END");
            builder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetProductPageAddress(string guid)
        {
            var builder = new StringBuilder();
            builder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
            builder.Append(
                " SELECT @id = B.ID FROM ShopNum1_Product AS A,ShopNum1_ProductCategory AS B WHERE A.[Guid]='" + guid +
                "' AND A.ProductCategoryID=B.ID");
            builder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ProductCategory WHERE ID = @id");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE ID = @fatherid) > 0) ");
            builder.Append(" BEGIN ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_ProductCategory WHERE ID = @fatherid");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" END");
            builder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetVideoCategoryPageAddress(string categoryID)
        {
            var builder = new StringBuilder();
            builder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
            builder.Append(" SET @id=" + categoryID);
            builder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_VideoCategory WHERE ID = @id");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_VideoCategory WHERE ID = @fatherid) > 0) ");
            builder.Append(" BEGIN ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_VideoCategory WHERE ID = @fatherid");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" END");
            builder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetVideoPageAddress(string guid)
        {
            var builder = new StringBuilder();
            builder.Append(" DECLARE @id int,@fatherid int,@name nvarchar(50) ");
            builder.Append(" SELECT @id = B.ID FROM ShopNum1_Video AS A,ShopNum1_VideoCategory AS B WHERE A.[Guid]='" +
                           guid + "' AND A.CategoryID=B.ID");
            builder.Append(" CREATE TABLE #temp(ID int,FatherID int,[Name] nvarchar(50)) ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_VideoCategory WHERE ID = @id");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" WHILE ((SELECT COUNT(1) FROM ShopNum1_VideoCategory WHERE ID = @fatherid) > 0) ");
            builder.Append(" BEGIN ");
            builder.Append(
                " SELECT @id = ID,@fatherid = FatherID,@name = [Name] FROM ShopNum1_VideoCategory WHERE ID = @fatherid");
            builder.Append(" INSERT INTO #temp(ID,FatherID,[Name]) VALUES(@id,@fatherid,@name)");
            builder.Append(" END");
            builder.Append(" SELECT * FROM #temp ORDER BY FatherID ASC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }
    }
}
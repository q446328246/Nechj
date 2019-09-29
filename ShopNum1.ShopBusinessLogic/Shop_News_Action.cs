using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_News_Action : IShop_News_Action
    {
        public int AddNews(ShopNum1_Shop_News shop_News)
        {
            var paraName = new string[10];
            var paraValue = new string[10];
            paraName[0] = "@title";
            paraValue[0] = shop_News.Title;
            paraName[1] = "@content";
            paraValue[1] = shop_News.Content;
            paraName[2] = "@isshow";
            paraValue[2] = shop_News.IsShow.ToString();
            paraName[3] = "@orderid";
            paraValue[3] = shop_News.OrderID.ToString();
            paraName[4] = "@createtime";
            paraValue[4] = shop_News.CreateTime.ToShortDateString();
            paraName[5] = "@seotitle";
            paraValue[5] = shop_News.SEOTitle;
            paraName[6] = "@keywords";
            paraValue[6] = shop_News.Keywords;
            paraName[7] = "@description";
            paraValue[7] = shop_News.Description;
            paraName[8] = "@newscategoryguid";
            paraValue[8] = shop_News.NewsCategoryGuid;
            paraName[9] = "@memloginid";
            paraValue[9] = shop_News.MemLoginID;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddNews", paraName, paraValue);
        }

        public int DeleteNews(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteNews", paraName, paraValue);
        }

        public DataTable GetCountNewsByMemLoginID(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCountNewsByMemLoginID", paraName, paraValue);
        }

        public DataTable GetNews(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNews", paraName, paraValue);
        }

        public DataTable GetNewsByGuidAndMemLoginID(string guid, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNewsByGuidAndMemLoginID", paraName,
                paraValue);
        }

        public DataTable GetNewsList(string memloginid, string isshow)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@isshow";
            paraValue[1] = isshow;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNewsList", paraName, paraValue);
        }

        public DataTable GetShopArticleDetailMeto(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopArticleDetailMeto", paraName, paraValue);
        }

        public DataTable GetShopMetaByNewsguid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopMetaByNewsguid", paraName, paraValue);
        }

        public DataTable MetaGetNews(string memloginid, string guid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@guid";
            paraValue[1] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_MetaGetNews", paraName, paraValue);
        }

        public DataSet SearchNewsListNew(string memloginid, string newscategoryguid, string ordertype, string sort,
            string perpagenum, string current_page, string isreturcount)
        {
            string str = string.Empty;
            var paraName = new string[9];
            var paraValue = new string[9];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@newscategoryguid";
            paraValue[1] = newscategoryguid;
            paraName[2] = "@columnnames";
            paraValue[2] =
                " A.Guid,A.ClickCount,A.Title,A.Content,A.OrderID,A.CreateTime,A.Keywords,A.Description,A.NewsCategoryGuid,A.MemLoginID,B.Name ";
            paraName[3] = "@searchname";
            paraValue[3] = str;
            paraName[4] = "@ordertype";
            paraValue[4] = ordertype;
            paraName[5] = "@sort";
            paraValue[5] = sort;
            paraName[6] = "@perpagenum";
            paraValue[6] = perpagenum;
            paraName[7] = "@current_page";
            paraValue[7] = current_page;
            paraName[8] = "@isreturcount";
            paraValue[8] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchNewsListNew", paraName, paraValue);
        }

        public int UpdateNews(ShopNum1_Shop_News shop_News)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@guid";
            paraValue[0] = shop_News.Guid.ToString();
            paraName[1] = "@title";
            paraValue[1] = shop_News.Title;
            paraName[2] = "@content";
            paraValue[2] = shop_News.Content;
            paraName[3] = "@isshow";
            paraValue[3] = shop_News.IsShow.ToString();
            paraName[4] = "@seotitle";
            paraValue[4] = shop_News.SEOTitle;
            paraName[5] = "@keywords";
            paraValue[5] = shop_News.Keywords;
            paraName[6] = "@description";
            paraValue[6] = shop_News.Description;
            paraName[7] = "@newscategoryguid";
            paraValue[7] = shop_News.NewsCategoryGuid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateNews", paraName, paraValue);
        }

        public int DeleteNewsComment(string guids)
        {
            return
                DatabaseExcetue.RunNonQuery("      DELETE FROM ShopNum1_Shop_NewsComment  WHERE   Guid IN (" + guids +
                                            ")       ");
        }

        public DataTable GetNewsCommentDetail(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable((string.Empty +
                                                 "       SELECT  A.*,B.Title AS ShopNewsTitle FROM  ShopNum1_Shop_NewsComment AS A LEFT JOIN ShopNum1_Shop_News AS B    " +
                                                 "       ON A.ArticleGuid=B.Guid        ") + "       WHERE A.Guid='" +
                                                guid + "'      ");
        }

        public DataTable GetTitleByGuid(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable("     SELECT  Title  FROM  ShopNum1_Shop_News  WHERE  Guid='" + guid +
                                                "'         ");
        }

        public DataTable SearchNewsList(string memloginid, string newscategoryguid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@newscategoryguid";
            paraValue[1] = newscategoryguid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchNewsList", paraName, paraValue);
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
            paraValue[3] = "ShopNum1_Shop_NewsComment";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CommentTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectNews_List(CommonPageModel commonModel)
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
            paraValue[3] = "ShopNum1_Shop_News";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpdateClickCountByGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateNewsClickCountByGuid", paraName, paraValue);
        }
    }
}
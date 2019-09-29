using System.Data;

namespace ShopNum1.ShopInterface
{
    public interface IShop_ProductComment_Action
    {
        DataTable CommentList(string memberid, string commenttype, string guid);
        DataTable CommentListStatReport(string shopid, string guid);
        DataTable GetCommentDetail(string strOrderguId, string strMemloingId);
        string GetGoodRate(string strShopLoginId, string strType);
        DataTable GetShopCommentCount(string strMemloginId, string strIsShop);
        string GetShopIDByName(string name);
        DataSet ProductCommentList(string productguid);
        DataSet ProductCommentListByGuidAndMemLoginID(string productguid, string memloginid, string strType);
        int ReplyComment(string guid, string reply);
        DataTable SelectShopComment(string strPageSize, string strCurrentPage, string strCondition, string strResultnum);

        DataTable SelectShopDetailComment(string strPageSize, string strCurrentPage, string strCondition,
            string strResultnum, string strShopID, string strType, string strProductGuID);

        DataTable ShopComment(string type, string shopid);
        DataTable ShopComment(string type, string timetype, string shopid);
        DataTable ShopCommentInfo(string guid);

        DataSet ShopCommentNew(string shopid, string type, string ordertype, string sort, string perpagenum,
            string current_page, string isreturcount);

        int UpdateContinueComment(string strOrderguId, string strMemloingId, string strComment, string strProductGuID);
    }
}
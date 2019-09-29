using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ArticleComment_Action
    {
        int Add(ShopNum1_ArticleComment articleComment);
        int Delete(string guids);
        DataTable GetArticleCommentInfoByGuid(string guid);
        DataTable Search(string memLoginID, int isDeleted);
        DataTable Search(string articleGuid, int isReply, int isAudit, int count);

        DataTable Search(string guid, string ArticleTitle, string memLoginID, string title, string sendTime1,
            string sendTime2, string replyTime1, string replyTime2, int isReply, int isAudit, int isDeleted,
            string IP);

        DataTable SearchArticleCommentInfo(string memberloginid, string commenttitle, string articletitle,
            string isaudit, string createtime1, string createtime2);

        DataTable SearchByGuid(string guid);
        int Update(ShopNum1_ArticleComment articleComment);
        int UpdateAudit(string guids, int isAudit);
        int UpdateScoreByCommentArticle(string memloginid, string rankscore, string score);
    }
}
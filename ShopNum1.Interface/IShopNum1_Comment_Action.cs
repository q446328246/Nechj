using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Comment_Action
    {
        int AddComment(ShopNum1_Comment comment);
        DataTable CommentListStatReport(string memberid);
        int DeleteComment(string guid);
        DataTable SearchCommentList(string memberid, string membertype, string commenttype);
    }
}
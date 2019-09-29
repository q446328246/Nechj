using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_CategoryComment_Action
    {
        int Add(ShopNum1_CategoryComment categoryComment);
        int CategoryCommentReply(string guid, string content);
        int DeleteCategoryComment(string guids);
        DataTable GetCateGoryAssociatedMemberID(string guid);

        DataTable GetCategoryCommentAll(string commentTitle, string CategoryTitle, string CategoryInfoGuid,
            string createMember, string isAudit, string CreateTime1, string CreateTime2);

        DataTable GetCategoryCommentAll(string commentTitle, string CategoryTitle, string CategoryInfoGuid,
            string createMember, string isAudit, string createTime1, string createTime2,
            string CreateMember);

        DataTable GetCategoryCommentByGuid(string guid);
        string GetCategoryGuid(string guid);
        DataTable GetCommentList(string guid);

        DataSet GetCommentList(string perpagenum, string current_page, string guid, string ordername,
            string isreturcount);

        DataTable MemberCategoryComment(string memberloginid, string commenttitle, string categorytitle,
            string createmember, string isaudit, string createtime1, string createtime2);

        int UpdateCategoryCommentAudit(string guids, string state);
    }
}
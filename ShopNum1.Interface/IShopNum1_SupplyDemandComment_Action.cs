using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SupplyDemandComment_Action
    {
        int AddSupplyDemandComment(ShopNum1_SupplyDemandComment shopNum1_SupplyDemandComment);
        int DeleteSupplyDemandComment(string guids);
        DataTable GetSupplyDemandAssociatedMemberID(string guid);

        DataTable GetSupplyDemandCommentAll(string commentTitle, string SupplyDemandName, string SupplyDemandGuid,
            string createMember, string isAudit, string CreateTime1, string CreateTime2);

        DataTable GetSupplyDemandCommentAll(string commentTitle, string SupplyDemandName, string SupplyDemandGuid,
            string createMember, string isAudit, string createTime1, string createTime2,
            string createMerber);

        DataTable GetSupplyDemandCommentList(string guid);

        DataSet GetSupplyDemandCommentList(string perpagenum, string current_page, string guid, string ordername,
            string isreturcount);

        string GetSupplyDemandGuid(string guid);

        DataTable MemberSupplyDemandComment(string memberloginid, string commenttitle, string supplydemandname,
            string publishMemLoginID, string isaudit, string createtime1,
            string createtime2);

        int ReplySupplyDemandComment(string guid, string content);
        int UpdateSupplyDemandCommentAudit(string guids, string state);
    }
}
using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ProductComment_Action
    {
        int Add(ShopNum1_Shop_ProductComment productcomment);
        int Add(List<ShopNum1_Shop_ProductComment> listProductComment);
        DataTable CheckIsComment(string orderguid, string menlogin);
        int DeleteProduct(string guids);
        int DeleteProductComment(string guids);
        DataTable GetCommentTypeByGuid(string guid);

        DataTable GetProductAll(string ProductName, string ShopID, string createMember, string isaudit,
            string createTime1, string createTime2);

        DataTable GetProductAll(string ProductName, string ProductGuid, string createMember, string isAudit,
            string createTime1, string createTime2, string memLoginID);

        DataTable GetProductCommentMemberID(string guid);
        string GetShopIDByName(string name);

        DataTable MemberProductComment(string memloginid, string commenttitle, string productname, string shopid,
            string isaudit, string createtime1, string createtime2);

        DataTable Search(string guid);
        int Search(string orderguid, string menlogin);

        DataTable ShopProductComment(string shopid, string commenttitle, string productname, string productguid,
            string createmember, string isaudit, string createtime1, string createtime2);

        DataTable ShopProductCommentList(string shopid, string commenttitle, string productname, string isreply,
            string createmember, string isaudit, string createtime1, string createtime2);

        int UpdateComment(string guid, string reply, string replytime, string BuyerAttitude);
        int UpdateComment(string guid, string reply, string replytime, string BuyerAttitude, bool IsContinueComment);
        int UpdateProductAudit(string guids, string state);
        int UpdateProductComment(string guid, string content);
    }
}
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_OrderComplaintsReplyList_Action
    {
        int Add(ShopNum1_OrderComplaint OrderComplaint);
        int addReply(ShopNum1_OrderComplaint OrderComplaint);
        DataTable CheckIsOrderComplainByID(string string_0);
        DataTable GetComplainListByComplainShop(string shopid);
        DataTable GetOrderComplainDetailByID(string string_0);
        DataTable Search(string memberLoginID);
        DataTable Search(string memLoginID, string type);
        DataTable SearchComplaint(string string_0);
        int UpdateOrderComplainInfoByID(string string_0, string appealimage, string appealcontent);
        int UpdateProcessingStatus(int ProcessingStatus, string ID);
    }
}
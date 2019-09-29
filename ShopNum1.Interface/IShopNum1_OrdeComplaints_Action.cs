using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_OrdeComplaints_Action
    {
        int AddOrderComplaints(string orderguid, string complaintsnum, string orderid, string shopid, string memloginid,
            string reporttype, string evidence);

        int CancelComplaints(string guid);
        int ComplaintsResult(string guid, string resultes);
        int Delete(string string_0);
        DataTable GetOrderComplaints(string ComplaintShop, string type);
        DataTable GetOrderComplaintsDetails(string guid);
        DataTable Search(string memLoginID, string type, string State);
    }
}
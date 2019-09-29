using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MemberReport_Action
    {
        int Add(ShopNum1_MemberReport MemberReport);
        DataTable CheckIsComplainByID(string string_0);
        DataTable GetReportDetailByID(string string_0);
        DataTable GetReportListByReportShop(string shopid);
        DataTable Search(string memLoginID);
        DataTable Search(string memLoginID, string type);
        DataTable SearchReport(string string_0);
        bool SearchReportName(string name);
        bool SearchReportProduct(string product, string name);
        int UpdateComplainInfoByID(string string_0, string complainimage, string complaintcontent);
    }
}
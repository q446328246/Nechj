using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Consult_Action
    {
        int Add();
        int Delete(string guids);
        DataTable Search(string MemLoginID, int IsDelete);
        DataTable Search(string guid, int IsDeleted, int IsReply);
        DataTable Search(string ProductName, int IsReply, string ConsultPeople, string SendTime1, string SendTime2);
        DataTable SearchByConsultGuid(string guid);
        DataTable SearchByGuid(string guid);
    }
}
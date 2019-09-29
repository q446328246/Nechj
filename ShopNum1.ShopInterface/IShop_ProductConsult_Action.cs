using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_ProductConsult_Action
    {
        int Add(ShopNum1_ShopProductConsult ProductConsult);
        int DeleteByGuid(string guids);
        int DeleteByProductGuid(string guids);
        DataTable Search(string MemLoginID, int IsDelete, string ShopID);
        DataTable Search(string guid, int IsDeleted, int IsReply, string ShopID,int category);

        DataTable Search(string ProductName, string IsAudit, string IsReply, string ConsultPeople, string SendTime1,
            string SendTime2, string ShopID);

        DataTable SearchByGuid(string guid);
        int Update(ShopNum1_ShopProductConsult ProductConsult);
    }
}
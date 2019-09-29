using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Help_Action
    {
        int Add(ShopNum1_Help shopNum1_Help);
        int Delete(string guids);
        DataTable GetEditInfo(string guid);
        DataTable GetHelpMeto(string guid);
        DataTable Search(string helpTypeGuid, int isDeleted);
        DataTable Search(string title, string type);
        DataTable Search(string helpTypeGuid, int showCount, int isDeleted);

        DataSet Search(string productName, string ordername, string soft, string perpagenum, string current_page,
            string isreturcount);

        DataTable SearchRemark(string guid, int isDeleted);
        int Update(ShopNum1_Help shopNum1_Help);
    }
}
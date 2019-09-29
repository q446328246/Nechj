using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_CategoryChecked_Action
    {
        int Add(ShopNum1_CategoryInfo categoryInfo);
        int AddCategoryInfo(ShopNum1_CategoryInfo categoryInfo);
        int Delete(string guids);
        DataTable EditCategoryInfo(string guid);
        DataTable GetCategoryByCode(string code);
        DataTable GetCategoryDetails(string guid);
        DataTable GetCategoryInfoMeto(string guid);
        DataTable GetCategoryNewList(string showCount);
        DataTable GetCategoryOnAndNext(string guid, string onCategoryName, string nextCategoryName);
        DataTable GetList(string categoryID);
        string GetMemberID(string guid);
        DataTable Search(string MemberID);
        DataTable Search(string strCode, string isAudit);
        DataTable Search(int fatherID, int isDeleted, string ShowCount);

        DataSet Search(string perpagenum, string current_page, string supplyName, string supplyCategoryCode,
            string supplyAddressCode, string ordername, string isreturcount);

        DataSet Search(string pageindex, string pagesize, string addresscode, string associatedcategoryguid,
            string createtime1, string createtime2, string keywords, string title);

        DataTable SearchByCategoryIDFrist(string CategoryCode);
        DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount);
        DataTable SearchByType(string code, string showCount);
        DataTable SearchCategoryInfo(string memloginid, string isaudit);
        int Update(ShopNum1_CategoryInfo shopNum1_CategoryInfo);
        int Update(string guids, string state);
        int UpdateCategoryInfo(ShopNum1_CategoryInfo categoryInfo);
    }
}
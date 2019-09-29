using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_AnnouncementCategory_Action
    {
        int Add(ShopNum1_AnnouncementCategory AnnouncementCategory);
        int Delete(string string_0);
        DataTable GetAnnouncementCategory(string FatherId);
        DataTable GetAnnouncementCategoryMeto(string strID);
        DataTable GetEditInfo(string strID);
        int GetMaxID();
        string GetNameByID(int int_0);
        DataTable Search(int isDeleted);
        DataTable Search(int fatherID, int isDeleted);
        DataTable SearchID(int int_0);
        DataTable SearchShow(int fatherID, int isDeleted);
        int Update(ShopNum1_AnnouncementCategory AnnouncementCategory);
    }
}
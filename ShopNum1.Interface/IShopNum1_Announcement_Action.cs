using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Announcement_Action
    {
        int Add(ShopNum1_Announcement announcement);
        int Delete(string guids);
        DataTable GetAnnoucementDetails(string guid);
        DataTable GetAnnoucementList();
        DataTable GetAnnoucementMeto(string guid);
        DataTable GetAnnoucementNew(string showCount);
        DataTable GetAnnouncementOnAndNext(string guid, string onAnnouncementName, string nextAnnouncementName);
        DataTable GetEditInfo(string guid, int isDeleted);
        DataTable GetShopAnnouncementNew(string showCount, string AnnouncementCategoryID);
        DataTable Search(string title, string creater, string startDate, string endDate, int isDeleted, string category);
        DataTable SearchTitle(int isDeleted);
        DataTable SearchTitle(int isDeleted, int count);
        int Update(string guid, ShopNum1_Announcement announcement);
    }
}
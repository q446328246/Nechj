using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Group_Action
    {
        int Add(ShopNum1_Group group);
        int Add(List<ShopNum1_GroupPage> strPagelList);

        int Add(ShopNum1_Group group, List<string> pageList, List<string> userList,
            List<ShopNum1_GroupPageWebControl> groupPageWebControlList);

        int CheckOperatePage(string userGuid, string pageName);
        int CheckShotName(string shortName);
        int Delete(string guids);
        DataTable GetGroupByGuid(string GroupGuid);
        DataTable GetGroupByGuid(string guid, int IsDeleted);
        DataTable GetOperateControl(string userGuid, string pageName);
        DataTable GetPageByGroupGuid(string guid, int IsDeleted);
        DataTable GetPageWebControlByGroupGuidPageGuid(string groupGuid, string pageGuid, int IsDeleted);
        DataTable GetPageWebControlByGuid(string guid, int isDeleted);
        DataTable GetPageWebControlByPageGuid(string pageGuid, int isDeleted);
        DataTable GetUserByGroupGuid(string guid, int IsDeleted);
        DataTable Search(int IsDeleted);

        int Update(ShopNum1_Group group, List<string> pageList, List<string> userList,
            List<ShopNum1_GroupPageWebControl> groupPageWebControlList);
    }
}
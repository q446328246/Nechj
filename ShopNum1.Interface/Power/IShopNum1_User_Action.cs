using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_User_Action
    {
        int Add(ShopNum1_User user, List<string> strGrouplList);
        int Add(ShopNum1_User user, ShopNum1_GroupUser GroupUser, List<string> strGrouplList);
        int CheckLogin(string loginID, string string_0, int isDeleted);
        int Delete(string guids);
        DataTable GetUserByDept(string deptGuid, int IsDeleted);
        DataTable GetUserByGuid(string guid, int IsDeleted);
        DataTable GetUserByLoginID(string loginID, int IsDeleted);
        DataTable Search(string realName, string deptGuid, int isFrobid, int IsDeleted);
        string SearchSupperAdminName();
        int Update(ShopNum1_User user, List<string> strGrouplList);
        int UpdateLoginInfo(ShopNum1_User user);
        int UpdatePwd(string name, string oldPwd, string newPwd);
    }
}
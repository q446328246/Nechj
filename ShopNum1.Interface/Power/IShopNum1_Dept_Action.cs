using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Dept_Action
    {
        int Add(ShopNum1_Dept dept);
        int Add(ShopNum1_Dept dept, string userGuid);
        int Delete(string guids);
        DataTable Search(int IsDeleted);
        DataTable Search(string deptGuid, int IsDeleted);
        int Update(ShopNum1_Dept dept, List<string> strUserList);
    }
}
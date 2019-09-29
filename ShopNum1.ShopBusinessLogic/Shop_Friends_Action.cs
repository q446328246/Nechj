using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Friends_Action : IShop_Friends_Action
    {
        public int AddFriend(string memloginid, string memberfriends)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@memberfriends";
            paraValue[1] = memberfriends;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddFriend", paraName, paraValue);
        }

        public DataTable GetFriendList(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetFriendList", paraName, paraValue);
        }

        public int UpdateFriend(string memloginid, string memberfriends)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@memberfriends";
            paraValue[1] = memberfriends;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateFriend", paraName, paraValue);
        }
    }
}
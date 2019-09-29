using System.Data;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Friends_Action
    {
        int AddFriend(string memloginid, string memberfriends);
        DataTable GetFriendList(string memloginid);
        int UpdateFriend(string memloginid, string memberfriends);
    }
}
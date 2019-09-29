using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MemberMessage_Action
    {
        int Add_MemberMsg(ShopNum1_MemberMessage shopNum1_MemberMessage);
        int Delete_Msg(string strArray);
        DataTable SelectMsg(ShopNum1_MemberMessage shopNum1_MemberMessage);
        DataTable SelectMsg_List(CommonPageModel commonModel);
        int Update_MsgIsRead(string strGuid);
    }
}
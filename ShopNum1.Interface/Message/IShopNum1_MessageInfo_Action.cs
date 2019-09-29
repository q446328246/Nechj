using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MessageInfo_Action
    {
        int Add(ShopNum1_MessageInfo messageInfo, List<string> usermessage);
        int Delete_SysMsg(string strArray);
        int DeleteReceive(string guids);
        int DeleteSend(string guids);
        DataTable Search(string guid);

        DataTable SearchReceive(string loginID, string memLoginID, string startDate, string endDate, string title,
            string type, int isRead, int isReply, int isDelete);

        DataTable SearchSend(string loginID, string memLoginID, string startDate, string endDate, string title,
            string type, int isRead, int isDelete);

        DataTable SelectSysMsg_Detail(ShopNum1_MessageInfo shopNum1_MessageInfo);
        DataTable SelectSysMsg_List(CommonPageModel commonModel);
        int Update(ShopNum1_MemberMessage memberMessage);
        int Update_SysMsgIsRead(string strGuid);
    }
}
using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_MessageInfo_Action
    {
        int Add(ShopNum1_MessageInfo agentMessageInfo, List<string> receiveMemLoginID, string sendMemLoginID,
            string receiveMemType, string sendMemType);

        int DeleteReceive(string guids);
        int DeleteSend(string guids);
        string GetMessageInfoGuid(string memberMessageGuid);
        void IsRead(string memberMessageGuid);

        DataTable SearchReceive(string sendMemLoginID, string isRead, string title, string createTime1,
            string createTime2, string sendMemType, string receiveMemLoginID);

        DataTable SearchSend(string receiveIsDeleted, string isRead, string title, string createTime1,
            string createTime2, string receiveMemType, string sendMemLoginID);

        DataTable SelectByGuid(string guid);
        DataTable SelectMemberByGuid(string guid);
        int UpdateReadState(string guid);
    }
}
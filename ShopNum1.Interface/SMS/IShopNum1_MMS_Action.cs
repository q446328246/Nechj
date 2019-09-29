using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MMS_Action
    {
        int Add(ShopNum1_MMS email);
        int Add(ShopNum1_MMSMemberGroup memberGroup, List<string> memberAssignGroup);
        int AddMMSGroupSend(ShopNum1_MMSGroupSend emailGroupSend);
        int Delete(string guids);
        int Deleted(string guids);
        int DeleteMemberGroup(string guids);
        DataTable GetEditInfo(string guid, int isDeleted);
        DataTable GetMMSGroupSendInfo(string guid);
        DataTable Search(int isDeleted);
        DataTable Search(string title, string typename, int isDeleted);
        DataTable SearchByMemLoginID(string memLoginID);
        DataTable SearchMemberAssignGroup(string guid);
        DataTable SearchMemberGroup(int isDeleted);
        DataTable SearchMemberGroup(string guid);
        DataTable SearchMMSContent(string guid);

        DataTable SearchMMSGroupSend(string emailtitle, string strtime1, string strtime2, string sendObjectMMS,
            int state, int istime);

        int Update(ShopNum1_MMSGroupSend emailGroupSend);
        int Update(string guid, ShopNum1_MMS email);
        int UpdateMemberAssignGroup(ShopNum1_MMSMemberGroup memberGroup, List<string> memberAssignGroup);
    }
}
using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Email_Action
    {
        int Add(ShopNum1_Email email);
        int AddEmailGroupSend(ShopNum1_EmailGroupSend emailGroupSend);
        int Delete(string guids);
        int Deleted(string guids);
        int DeleteMemberGroup(string guids);
        int Email_Group_Add(ShopNum1_MemberGroup memberGroup, List<string> EmailmemberAssignGroup);
        DataTable GetEditInfo(string guid, int isDeleted);
        DataTable GetEmailGroupSendInfo(string guid);
        DataTable Search(int isDeleted);
        DataTable Search(string title, string typename, int isDeleted);
        DataTable SearchByMemLoginID(string memLoginID);
        DataTable SearchEmailContent(string guid);

        DataTable SearchEmailGroupSend(string emailtitle, string strtime1, string strtime2, string sendObjectEmail,
            int state, int istime);

        DataTable SearchEmailMemberAssignGroup(string guid);
        DataTable SearchMemberGroup(int isDeleted);
        DataTable SearchMemberGroup(string guid);
        int Update(ShopNum1_EmailGroupSend emailGroupSend);
        int Update(string guid, ShopNum1_Email email);
        int UpdateEmailMemberAssignGroup(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup);
    }
}
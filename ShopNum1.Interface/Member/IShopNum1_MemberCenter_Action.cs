using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MemberCenter_Action
    {
        int Add(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup);
        bool CheckEmailUserRepaeat(string userId, string email);
        DataTable CheckIsAgent(string memberloginID);
        int CheckPassword(string memLoginID, string string_0);
        string CompareMemberRankGuid(string memberRankGuid1, string memberRankGuid2);
        int DeleteMemberGroup(string guids);
        decimal GetCostMoney(string memLoginID);
        string GetPayPwd(string memLoginID);
        DataTable MemberCheckScore(string memloginid, string score);
        DataTable MemberFavourTicketCode(string memberLoginID, string FavourTicketCode);
        DataTable MemberFindPwdPro(string question, string emial);
        int ReduceMemberFavourTichet(string memberLoginID, string FavourTicketCode);
        DataTable Search(string memLoginID);
        DataTable Search(string guid, int isDeleted);

        DataTable Search(string memLoginID, string realName, string email, string regDate1, string regDate2,
            decimal creditMoney1, decimal creditMoney2, int score1, int score2, int int_0, int isForbid,
            string memberRankGuid, int isDeleted, string agentID);

        DataTable SearchBookMember(int state, int isDeleted);
        DataTable SearchByMemLoginID(string memLoginID);
        DataTable SearchCurentScoreOrPrice(string memLoginID);
        DataTable SearchInfoByGuid(string guid);
        DataTable SearchMember(int isDeleted);
        DataTable SearchMemberAssignGroup(string guid);
        DataTable SearchMemberByMemberRank(string guid);
        DataTable SearchMemberCookieInfo(string memLoginID);
        DataTable SearchMemberFavourTicket(string memLoginID, int isDeleted);
        DataTable SearchMemberGroup(int isDeleted);
        DataTable SearchMemberGroup(string guid);
        DataTable SearchMemberName(string memLoginID, string realName, string memberRankGuid);
        DataTable SearchMemberRank(int isDeleted);
        DataTable SearchPasswordByInfo(string question, string answer, string email, int isDeleted);
        DataTable SearchReport(string guids);
        DataTable SearchWelcomeBaseInfo(string memLoginID);
        int UpdateMemberAssignGroup(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup);
        int UpdatePayPwd(string memLoginID, string oldPayPwd, string newPayPwd);
        int UpdatePwd(string memLoginID, string oldPwd, string newPwd);
    }
}
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SupplyDemandCheck_Action
    {
        int AddSupplyDemandComment(ShopNum1_SupplyDemandComment shopNum1_SupplyDemandComment);
        int Delete(string guids);
        DataTable GetSupplyDemandCommentList(string guid);
        DataTable GetSupplyDemandDetail(string guid);
        DataTable GetSupplyDemandDetailOnAndNext(string guid, string onSupplyDemandName, string nextSupplyDemandName);
        DataTable GetSupplyDemandNewList(string showcount);
        DataTable GetSupplyDemandNewList(string guid, string showCount, string code);
        DataTable GetSupplyDemandRecommendList(string showcount, string TradeType);
        DataTable GetTitleByCodeRecommend(string code, string cout);
        DataTable GetTitleByCodeTrade(int TradeType, string code, string cout);
        DataTable Search(int fatherID, int isDeleted, string ShowCount);
        DataTable Search(string addressCode, string associatedMemberID, string isAudit);
        DataTable Search1(string code, string associatedMemberID, int IsAudit);
        DataTable SearchByCategoryIDFrist(string CategoryCode);
        DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount);
        DataTable SearchByType(string code, string showCount);

        DataTable SearchList(string codes, string associatedMemberIDs, string titles, string types, string startTimes,
            string endtimes, string isAudits);

        DataSet SearchSupply(string perpagenum, string current_page, string supplyName, string supplyCategoryCode,
            string supplyAddressCode, string ordername, string isreturcount);

        int Update(string guids, string state);
    }
}
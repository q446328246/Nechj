using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberProfitBonusLog_Action : IShopNum1_MemberProfitBonusLog_Action
    {
        public int Add(ShopNum1_MemberProfitBonusLog MemberProfitBonusLog)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "insert into ShopNum1_MemberProfitBonusLog ([Guid], ProductGuid,ProductName,OrderNumber,MemberLoginID,IsDeleted,GroupPrice,RecordTime,InstructorGuid,InstructorName)VALUES('"
                , MemberProfitBonusLog.Guid, "','", MemberProfitBonusLog.ProductGuid, "','",
                MemberProfitBonusLog.ProductName, "','", MemberProfitBonusLog.OrderNumber, "','",
                MemberProfitBonusLog.MemberLoginID, "', ", MemberProfitBonusLog.IsDeleted, ",'",
                MemberProfitBonusLog.GroupPrice, "','", MemberProfitBonusLog.RecordTime,
                "','", MemberProfitBonusLog.InstructorGuid, "','", MemberProfitBonusLog.InstructorName, "')"
            }));
        }
    }
}
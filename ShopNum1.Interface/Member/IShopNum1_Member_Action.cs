using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Member_Action
    {
        int AgreeSave(string savecode, string saveurl = "");
        int AnySave(string saveid);
        int ApplySave(string MemLoginID, string saveid, string savecode);
        DataTable GetSaveInfo(string memLoginID);
        DataTable SearchMembertwoone(string memLoginID);
        int UpdateRankbyMemLoginID(string Rank, string MemLoginID);



        int UpdateMemberRankGuid(string memLoginID, string memRankGuid);
        int Add(ShopNum1_Member member);
        int Add(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup);
        int AddByAdmin(ShopNum1_Member Member);
        int CategoryAdPay(string memLoginID, decimal shouldPay, decimal advancePayment, string tradeID);
        int CheckBindMobile(string Mobile, string memloginid);
        int CheckEmail(string email, string memloginid);
        DataTable SearchMemberGuid(string guid);
        /// <summary>
        /// 检查身份证是否存在
        /// </summary>
        /// <param name="identifycard"></param>
        /// <returns></returns>
        int CheckIdentityCard(string identifycard);
        
        DataTable CheckIsForbid(string MemLoginID);
        int CheckmemEmail(string Email);
        DataTable CheckMemEmailByEmail(string Email);
        int CheckmemLoginIDtwo(string memLoginID, string realname);
        int CheckmemLoginID(string memLoginID);


        DataTable CheckMemMobileByMobile(string Mobile);
        int CheckMemMobileByMobile1(string Mobile);
        int CheckMobile(string Mobile);
        int CheckPassword(string memLoginID, string string_0);
        DataTable CheckSafeRank(string MemLoginID, string where);
        string CompareMemberRankGuid(string memberRankGuid1, string memberRankGuid2);
        int Delete(string guids);
        int DeleteMemberActivate(string strMobile);
        int DeleteRealName(string strGuId);
        DataTable FindPwdEamil(string MemLoginID, string Email);
        DataTable GetAllShopInfoByGuid(string guids);
        decimal GetCostMoney(string memLoginID);
        DataTable GetMemberAccount(string MemberLogin);
        int GetMemberCountByCode(string code, string isother);
        DataTable GetMemberIdentificationInfo(string member);
        DataTable GetMemberInfoByGuID(string strGuId);
        DataTable GetMemberInfoByMemLoginID(string memLoignID);
        DataTable GetMemberPassWord(string loginID, string string_0);
        decimal GetMemberPriceByGuid(string ProudctGuid, string MemLoginID);
        DataTable GetMemberQuery(string memLoginID);
        DataTable GetMemInfo(string strMemberId);
        DataTable GetMemInfoByMemberloginId(string memberloginid);
        string GetMemLoginIDByGuid(string guid);
        DataTable GetMemTypeByGuid(string guid);
        string GetMemTypeByMemberId(string strMemberId);
        string GetMemTypeByMemLoginID(string memloginID);
        string GetPayPwd(string memLoginID);
        DataTable LoginByEmail(string email, string string_0);
        DataTable LoginByMobile(string mobile, string string_0);
        DataTable MemberCreditRankSearch(string memberrank);
        DataTable MemberFindPwdPro(string email);
        int OtherOrderIDPay(string memLoginID, decimal shouldPay, decimal advancePayment, string tradeID);

        int PreDepositsPay(string memLoginID, decimal shouldPay, decimal advancePayment, string orderNumber,
            string IsAllPay);

        int RefundUpdateAdvancePayment(string memloginid, string shopid, decimal payprice, decimal shopAdvancePayment,
            string orderguid, string productguid, int status);

        int RefundUpdateAdvancePaymentMem(string memloginid, decimal payprice);
        DataTable Search(string memLoginID);
        DataTable Search(string guid, int isDeleted);

        DataTable Search(string MemLoginID, string ZfbCode, string RealName, string IdentityCard, string ApplyDate1,
            string ApplyDate2, string IsAudit);

        DataTable Search1(string memLoginID, string name, string email, string regDate1, string regDate2, int int_0,
            int isForbid, string AreaCode, string MemberType, string MemberRank, string MemberRankGuid, string CreditMoney,
            string Mobile,string isadmin);

        DataTable SearchAgentByAreacode(string areacode, string showcount);
        DataTable SearchAgentByAreacodeProp(string areacode, string showcount);
        DataTable SearchAgentCountOfAreacode();
        DataTable SearchByMemLoginID(string memLoginID);
        DataTable SearchInfoByGuid(string guid);

        DataTable SearchIsAudit(string MemLoginID, string RealName, string IdentityCard, string StartTime,
            string EndTime, string IdentificationIsAudit);

        DataTable SearchMember(int isDeleted);
        DataTable SearchMemberAssignGroup(string guid);
        DataTable SearchMemberByMemberRank(string guid);
        DataTable SearchMemberCookieInfo(string memLoginID);
        DataTable SearchMemberGetPromentionMembers(string memberloginid, string ispromentiontop);
        DataTable SearchMemberGroup(string guid);
        DataTable SearchMemberInfoByGuid(string Guid);
        DataTable SearchMemberName(string memLoginID, string realName, int Type);
        DataTable SearchMemberName(string memLoginID, string realName, string memberRankGuid);

        DataTable SearchPassMemberInfo(string MemLoginID, string RealName, string IdentityCard, string StartTime,
            string EndTime);

        DataTable SearchPasswordByInfo(string question, string answer, string email, int isDeleted);
        DataTable SearchWelcomeBaseInfo(string memLoginID);
        int Transfer(string transferMember, string toTransferMember, string money);
        int UpdataIsMobileActivation(string MemberLogin, string Mobile);
        int UpdataMemberIdentificationInfo(ShopNum1_Member shopNum1_Member);
        int Update(ShopNum1_Member member);
        
        int UpdateAdvancePayment(int type, string memberloginid, decimal payprice);
        int UpdateCostMoney(string memLoginID, decimal costMoney);
        int UpdateIdentificationIsAudit(string Guid, string IdentificationIsAudit, string strAuditFailedReason);

        int UpdateIdentificationIsAudit(string Guid, string IdentificationIsAudit, string strAuditFailedReason,
            string memLoginID);

        int UpdateLoginTime(string memloginid, string lastloginip);
        int UpdateMember(string RealName, string Name, string memLoginID);
        
        int UpdateMemberAssignGroup(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup);
        int UpdateMemberRealNameByMemberLoginID(string RealName, string MemLoginID);
        int UpdateMemberScore(string memloginID, int rankscore, int score);
        int UpdateMemberType(string guids, int memberType);
        int UpdateMemInfo(string strMemberId, ShopNum1_Member Member);
        int UpdateMemInfoDetail(string strMemberId, ShopNum1_Member Member);
        int UpdatePayPwd(string MemberLogin, string PayPwd);
        int UpdatePayPwd(string memLoginID, string oldPayPwd, string newPayPwd);
        int UpdatePhoto(string MemLoginID, string Photo);
        int UpdatePwd(string memLoginID, string oldPwd, string newPwd);
        int UpdateScore(ShopNum1_Member member);
        int UpdateScore(string Score, string MemberRank, string CreditScore, string MemLoginID);
        int UpdtateMemberAdvancePayment(string memloginid, string ChangeAdvancPayment);

        int UploadingCardPic(string MemLoginID, string IdentityCardImg, string IdentityCard, string RealName,
            string IdentificationTime);

        int UploadingCardPic(string MemLoginID, string IdentityCardImg, string IdentityCardBackImg, string IdentityCard,
            string RealName, string IdentificationTime);
        DataTable SelectGoodsByNum(int startNum, int overNum, int cate_id);
        DataTable SelecetImgByGoods_id(int goods_id);
        DataTable SelectAllByGoods_id(int goods_id, int cate_id);
        /// <summary>
        /// 生成会员编号
        /// </summary>
        /// <returns></returns>
        string GetMemberNumber();

        /// <summary>
        /// 检查会员编号是否存在
        /// </summary>
        /// <param name="distributorId"></param>
        /// <returns></returns>
        int getNumber(string distributorId);
    }
}
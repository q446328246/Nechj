namespace ShopNum1.Interface
{
    public interface IShopNum1_AdminWelcome_Action
    {
        string SearchActivityProductCount(string strPanicBuy, string strSpellBuy, int isDeleted);
        string SearchAdminInfo(string strloginID, int isDeleted);
        string SearchAllMemberCount(int isDeleted);
        string SearchAllShopCount(int isDeleted);
        string SearchArticleCommentCount(int isAudit, int isDeleted);
        string SearchAuditProductCount(int IsAudit, int isDeleted);
        string SearchGroupProduct();
        string SearchMessageBoardCount();
        string SearchMessageBoardCount(int isAudit, int isDeleted);
        string SearchMessageCount(int isRead, int isDeleted);

        string SearchOrderForDispatch(string strOderStatus, string strShipmentStatus, string strPaymentStatus,
            int isDeleted);

        string SearchOrderNowCount();
        string SearchOutOfStockRecordCount(int isReply, int isDeleted);
        string SearchProductCommentCount();
        string SearchProductCommentCount(int isAudit, int isDeleted);
        string SearchProductCount(int isDeleted);
        string SearchProuductCheckedCount();
        string SearchRecommendCount(string strBest, string strHot, string strRecommend, string strNew, int isDeleted);
        string SearchRegisterMemberCount(string strRegDate, int isDeleted);
        string SearchRegisterShopCount(int isAudit, string strApplyTime, int isDeleted);
        string SearchRepertoryAlertCount(int isDeleted);
        string SearchSaleInfo(string strDispatchTime, int isDeleted);
        string SearchSaleProductCount(string strDispatchTime, int isDeleted);
        string SearchShopNowCount();
    }
}
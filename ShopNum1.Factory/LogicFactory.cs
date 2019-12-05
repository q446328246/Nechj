using System.Configuration;
using System.Reflection;
using ShopNum1.Cache;
using ShopNum1.Interface;

namespace ShopNum1.Factory
{
    public sealed class LogicFactory
    {
        private static readonly string BusinessLogic = ConfigurationManager.AppSettings["BusinessLogic"];


        public static IShopNum1_Order_Refuse_Action CreateShopNum1_Order_Refuse_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Order_Refuse_Action";
            return (IShopNum1_Order_Refuse_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }
        public static IShopNum1_FreezeRelease_Action CreateShopNum1_FreezeRelease_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_FreezeRelease_Action";
            return (IShopNum1_FreezeRelease_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MobileService_Action CreateShopNum1_MobileService_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MobileService_Action";
            return (IShopNum1_MobileService_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }



        public static IShopNum1_MemberShip_Action CreateShopNum1_MemberShip_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberShip_Action";
            return (IShopNum1_MemberShip_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ShopUserRecommend_Action CreateShopNum1_ShopUserRecommend_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopUserRecommend_Action";
            return (IShopNum1_ShopUserRecommend_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Activity_Action CreateShopNum1_Activity_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Activity_Action";
            return (IShopNum1_Activity_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Address_Action CreateShopNum1_Address_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Address_Action";
            return (IShopNum1_Address_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }


        public static IShopNum1_AdvancePaymentApplyLog_Action CreateShopNum1_AdvancePaymentApplyLog_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_AdvancePaymentApplyLog_Action";
            return
                (IShopNum1_AdvancePaymentApplyLog_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_AdvancePaymentFreezeLog_Action CreateShopNum1_AdvancePaymentFreezeLog_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_AdvancePaymentFreezeLog_Action";
            return
                (IShopNum1_AdvancePaymentFreezeLog_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_AdvancePaymentModifyLog_Action CreateShopNum1_AdvancePaymentModifyLog_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_AdvancePaymentModifyLog_Action";
            return
                (IShopNum1_AdvancePaymentModifyLog_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_OrderRefund_Action CreateShopNum1_OrderRefund_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_OrderRefund_Action";
            return
                (IShopNum1_OrderRefund_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Advertisement_Action CreateShopNum1_Advertisement_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Advertisement_Action";
            return (IShopNum1_Advertisement_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Announcement_Action CreateShopNum1_Announcement_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Announcement_Action";
            return (IShopNum1_Announcement_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_AnnouncementCategory_Action CreateShopNum1_AnnouncementCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_AnnouncementCategory_Action";
            return (IShopNum1_AnnouncementCategory_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Article_Action CreateShopNum1_Article_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Article_Action";
            return (IShopNum1_Article_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ArticleCategory_Action CreateShopNum1_ArticleCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ArticleCategory_Action";
            return
                (IShopNum1_ArticleCategory_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ArticleCheck_Action CreateShopNum1_ArticleCheck_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ArticleCheck_Action";
            return (IShopNum1_ArticleCheck_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ArticleComment_Action CreateShopNum1_ArticleComment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ArticleComment_Action";
            return
                (IShopNum1_ArticleComment_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_AttachMent_Action CreateShopNum1_AttachMent_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_AttachMent_Action";
            return
                (IShopNum1_AttachMent_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_AttachMentCategory_Action CreateShopNum1_AttachMentCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_AttachMentCategory_Action";
            return
                (IShopNum1_AttachMentCategory_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_BadWord_Action CreateShopNum1_BadWord_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_BadWord_Action";
            return (IShopNum1_BadWord_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }
        public static IShopNum1_Shop_Product_Action CreateShopNum1_Shop_Product_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Shop_Product_Action";
            return (IShopNum1_Shop_Product_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }
        public static IShopNum1_Brand_Action CreateShopNum1_Brand_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Brand_Action";
            return (IShopNum1_Brand_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Cart_Action CreateShopNum1_Cart_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Cart_Action";
            return (IShopNum1_Cart_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_CategoryAdID_Action CreateShopNum1_CategoryAdID_Action()
        {
            string str = BusinessLogic + ".ShopNum1_CategoryAdID_Action";
            return (IShopNum1_CategoryAdID_Action) smethod_1("ShopNum1.BusinessLogic", str);
        }

        public static IShopNum1_CategoryAdPayMent_Action CreateShopNum1_CategoryAdPayMent_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_CategoryAdPayMent_Action";
            return
                (IShopNum1_CategoryAdPayMent_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_CategoryAdvertisement_Action CreateShopNum1_CategoryAdvertisement_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_CategoryAdvertisement_Action";
            return
                (IShopNum1_CategoryAdvertisement_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_CategoryChecked_Action CreateShopNum1_CategoryChecked_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_CategoryChecked_Action";
            return (IShopNum1_CategoryChecked_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_CategoryComment_Action CreateShopNum1_CategoryComment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_CategoryComment_Action";
            return (IShopNum1_CategoryComment_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_CategoryType_Action CreateShopNum1_CategoryType_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_CategoryType_Action";
            return (IShopNum1_CategoryType_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_City_Action CreateShopNum1_City_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_City_Action";
            return (IShopNum1_City_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Collect_Action CreateShopNum1_Collect_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Collect_Action";
            return (IShopNum1_Collect_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Comment_Action CreateShopNum1_Comment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Comment_Action";
            return (IShopNum1_Comment_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Common_Action CreateShopNum1_Common_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Common_Action";
            return (IShopNum1_Common_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ComplaintsManagement_Action CreateShopNum1_ComplaintsManagement_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ComplaintsManagement_Action";
            return (IShopNum1_ComplaintsManagement_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Control_Action CreateShopNum1_Control_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Control_Action";
            return (IShopNum1_Control_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ControlData_Action CreateShopNum1_ControlData_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ControlData_Action";
            return (IShopNum1_ControlData_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Coupon_Action CreateShopNum1_Coupon_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Coupon_Action";
            return (IShopNum1_Coupon_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_CouponType_Action CreateShopNum1_CouponType_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_CouponType_Action";
            return (IShopNum1_CouponType_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_DefaultAdImg_Action CreateShopNum1_DefaultAdImg_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_DefaultAdImg_Action";
            return (IShopNum1_DefaultAdImg_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Dept_Action CreateShopNum1_Dept_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Dept_Action";
            return (IShopNum1_Dept_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_DispatchRegion_Action CreateShopNum1_DispatchRegion_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_DispatchRegion_Action";
            return
                (IShopNum1_DispatchRegion_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Email_Action CreateShopNum1_Email_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Email_Action";
            return (IShopNum1_Email_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Ensure_Action CreateShopNum1_Ensure_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Ensure_Action";
            return (IShopNum1_Ensure_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ExtendOrderStatistics_Action CreateShopNum1_ExtendOrderStatistics_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ExtendOrderStatistics_Action";
            return
                (IShopNum1_ExtendOrderStatistics_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ExtendSiteMapXml_Action CreateShopNum1_ExtendSiteMapXml_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ExtendSiteMapXml_Action";
            return
                (IShopNum1_ExtendSiteMapXml_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ExtendSiteMota_Action CreateShopNum1_ExtendSiteMota_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ExtendSiteMota_Action";
            return
                (IShopNum1_ExtendSiteMota_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Group_Action CreateShopNum1_Group_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Group_Action";
            return (IShopNum1_Group_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_GroupProduct_Action CreateShopNum1_GroupProduct_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_GroupProduct_Action";
            return (IShopNum1_GroupProduct_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Help_Action CreateShopNum1_Help_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Help_Action";
            return (IShopNum1_Help_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_HelpType_Action CreateShopNum1_HelpType_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_HelpType_Action";
            return (IShopNum1_HelpType_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Image_Action CreateShopNum1_Image_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Image_Action";
            return (IShopNum1_Image_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Image_Type_Action CreateShopNum1_Image_Type_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Image_Type_Action";
            return (IShopNum1_Image_Type_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ImageCategory_Action CreateShopNum1_ImageCategory_Action()
        {
            string str = BusinessLogic + ".ShopNum1_ImageCategory_Action";
            return (IShopNum1_ImageCategory_Action) smethod_1(BusinessLogic, str);
        }

        public static IShopNum1_KeyWords_Action CreateShopNum1_KeyWords_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_KeyWords_Action";
            return (IShopNum1_KeyWords_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Link_Action CreateShopNum1_Link_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Link_Action";
            return (IShopNum1_Link_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Logistic_Action CreateShopNum1_Logistic_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Logistic_Action";
            return (IShopNum1_Logistic_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Member_Action CreateShopNum1_Member_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Member_Action";
            return (IShopNum1_Member_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Referral_Action CreateShopNum1_Referral_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Referral_Action";
            return (IShopNum1_Referral_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MemberActivate_Action CreateShopNum1_MemberActivate_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberActivate_Action";
            return
                (IShopNum1_MemberActivate_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MemberCenter_Action CreateShopNum1_MemberCenter_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberCenter_Action";
            return
                (IShopNum1_MemberCenter_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MemberEmailExec_Action CreateShopNum1_MemberEmailExec_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberEmailExec_Action";
            return
                (IShopNum1_MemberEmailExec_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MemberMessage_Action CreateShopNum1_MemberMessage_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberMessage_Action";
            return
                (IShopNum1_MemberMessage_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MemberProfitBonusLog_Action CreateShopNum1_MemberProfitBonusLog_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberProfitBonusLog_Action";
            return
                (IShopNum1_MemberProfitBonusLog_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MemberPwd_Action CreateShopNum1_MemberPwd_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberPwd_Action";
            return (IShopNum1_MemberPwd_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

       


        public static IShopNum1_MemberRank_Action CreateShopNum1_MemberRank_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberRank_Action";
            return (IShopNum1_MemberRank_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MemberReport_Action CreateShopNum1_MemberReport_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberReport_Action";
            return
                (IShopNum1_MemberReport_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Menu_Action CreateShopNum1_Menu_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Menu_Action";
            return (IShopNum1_Menu_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MessageBoard_Action CreateShopNum1_MessageBoard_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MessageBoard_Action";
            return
                (IShopNum1_MessageBoard_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MessageInfo_Action CreateShopNum1_MessageInfo_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MessageInfo_Action";
            return
                (IShopNum1_MessageInfo_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MMS_Action CreateShopNum1_MMS_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MMS_Action";
            return (IShopNum1_MMS_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MMSGroupSend_Action CreateShopNum1_MMSGroupSend_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MMSGroupSend_Action";
            return (IShopNum1_MMSGroupSend_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MMSType_Action CreateShopNum1_MMSType_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MMSType_Action";
            return (IShopNum1_MMSType_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_OnLineService_Action CreateShopNum1_OnLineService_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_OnLineService_Action";
            return (IShopNum1_OnLineService_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_OperateLog_Action CreateShopNum1_OperateLog_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_OperateLog_Action";
            return (IShopNum1_OperateLog_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_OrdeComplaints_Action CreateShopNum1_OrdeComplaints_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_OrdeComplaints_Action";
            return (IShopNum1_OrdeComplaints_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_OrderComplaintsReplyList_Action CreateShopNum1_OrderComplaintsReplyList_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_OrderComplaintsReplyList_Action";
            return
                (IShopNum1_OrderComplaintsReplyList_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_OrderInfo_Action CreateShopNum1_OrderInfo_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_OrderInfo_Action";
            return (IShopNum1_OrderInfo_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_OrderOperateLog_Action CreateShopNum1_OrderOperateLog_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_OrderOperateLog_Action";
            return
                (IShopNum1_OrderOperateLog_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_OrderProduct_Action CreateShopNum1_OrderProduct_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_OrderProduct_Action";
            return (IShopNum1_OrderProduct_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Page_Action CreateShopNum1_Page_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Page_Action";
            return (IShopNum1_Page_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_PageAddress_Action CreateShopNum1_PageAddress_Action()
        {
            string str = BusinessLogic + ".ShopNum1_PageAddress_Action";
            return (IShopNum1_PageAddress_Action) smethod_1(BusinessLogic, str);
        }

        public static IShopNum1_PageAdID_Action CreateShopNum1_PageAdID_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_PageAdID_Action";
            return (IShopNum1_PageAdID_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_PageInfo_Action CreateShopNum1_PageInfo_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_PageInfo_Action";
            return (IShopNum1_PageInfo_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_PageWebControl_Action CreateShopNum1_PageWebControl_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_PageWebControl_Action";
            return
                (IShopNum1_PageWebControl_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Payment_Action CreateShopNum1_Payment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Payment_Action";
            return (IShopNum1_Payment_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_PreTransfer_Action CreateShopNum1_PreTransfer_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_PreTransfer_Action";
            return
                (IShopNum1_PreTransfer_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_PreventIp_Action CreateShopNum1_PreventIp_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_PreventIp_Action";
            return (IShopNum1_PreventIp_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ProductCategory_Action CreateShopNum1_ProductCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ProductCategory_Action";
            return (IShopNum1_ProductCategory_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ProductComment_Action CreateShopNum1_ProductComment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ProductComment_Action";
            return (IShopNum1_ProductComment_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ProuductChecked_Action CreateShopNum1_ProuductChecked_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ProuductChecked_Action";
            return (IShopNum1_ProuductChecked_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_RankScoreModifyLog_Action CreateShopNum1_RankScoreModifyLog_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_RankScoreModifyLog_Action";
            return
                (IShopNum1_RankScoreModifyLog_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Refund_Action CreateShopNum1_Refund_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Refund_Action";
            return (IShopNum1_Refund_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Region_Action CreateShopNum1_Region_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Region_Action";
            return (IShopNum1_Region_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Report_Action CreateShopNum1_Report_Action()
        {
            string str = BusinessLogic + ".ShopNum1_Report_Action";
            return (IShopNum1_Report_Action) smethod_1("ShopNum1.BusinessLogic", str);
        }

        public static IShopNum1_Reputation_Action CreateShopNum1_Reputation_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Reputation_Action";
            return (IShopNum1_Reputation_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ScoreModifyLog_Action CreateShopNum1_ScoreModifyLog_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ScoreModifyLog_Action";
            return
                (IShopNum1_ScoreModifyLog_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ScoreOrderInfo_Action CreateShopNum1_ScoreOrderInfo_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ScoreOrderInfo_Action";
            return
                (IShopNum1_ScoreOrderInfo_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ScoreProductCategory_Action CreateShopNum1_ScoreProductCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ScoreProductCategory_Action";
            return
                (IShopNum1_ScoreProductCategory_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_Shop_ScoreProduct_Action CreateShopNum1_Shop_ScoreProduct_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Shop_ScoreProduct_Action";
            return
                (IShopNum1_Shop_ScoreProduct_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ShopArticleComment_Action CreateShopNum1_ShopArticleComment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopArticleComment_Action";
            return (IShopNum1_ShopArticleComment_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ShopCategory_Action CreateShopNum1_ShopCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopCategory_Action";
            return (IShopNum1_ShopCategory_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ShopInfoList_Action CreateShopNum1_ShopInfoList_Action()
        {
            string str = BusinessLogic + ".ShopNum1_ShopInfoList_Action";
            return (IShopNum1_ShopInfoList_Action) smethod_1(BusinessLogic, str);
        }

        public static IShopNum1_ShopPayment_Action CreateShopNum1_ShopPayment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopPayment_Action";
            return
                (IShopNum1_ShopPayment_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ShopProduct_Browse_Action CreateShopNum1_ShopProduct_Browse_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopProduct_Browse_Action";
            return
                (IShopNum1_ShopProduct_Browse_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ShopProductProp_Action CreateShopNum1_ShopProductProp_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopProductProp_Action";
            return
                (IShopNum1_ShopProductProp_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ShopProductPropValue_Action CreateShopNum1_ShopProductPropValue_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopProductPropValue_Action";
            return
                (IShopNum1_ShopProductPropValue_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ShopProductRelationProp_Action CreateShopNum1_ShopProductRelationProp_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopProductRelationProp_Action";
            return
                (IShopNum1_ShopProductRelationProp_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ShopProRelateProp_Action CreateShopNum1_ShopProRelateProp_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopProRelateProp_Action";
            return
                (IShopNum1_ShopProRelateProp_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ShopTemplate_Action CreateShopNum1_ShopTemplate_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopTemplate_Action";
            return (IShopNum1_ShopTemplate_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ShopURLManage_Action CreateShopNum1_ShopURLManage_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ShopURLManage_Action";
            return (IShopNum1_ShopURLManage_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_SiteMap_Action CreateShopNum1_SiteMap_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Site_Action";
            return (IShopNum1_SiteMap_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Spec_Action CreateShopNum1_Spec_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Spec_Action";
            return (IShopNum1_Spec_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_SpecificationProductImage_Action CreateShopNum1_SpecificationProductImage_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SpecificationProductImage_Action";
            return
                (IShopNum1_SpecificationProductImage_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_SpecificationProudctCategory_Action CreateShopNum1_SpecificationProudctCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SpecificationProudctCategory_Action";
            return
                (IShopNum1_SpecificationProudctCategory_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_SpecProudct_Action CreateShopNum1_SpecProudct_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SpecProudct_Action";
            return (IShopNum1_SpecProudct_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_SpecProudctDetail_Action CreateShopNum1_SpecProudctDetail_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SpecProudctDetail_Action";
            return
                (IShopNum1_SpecProudctDetail_Action)
                    Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_SupplyDemandCategory_Action CreateShopNum1_SupplyDemandCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SupplyDemandCategory_Action";
            return
                (IShopNum1_SupplyDemandCategory_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_SupplyDemandCheck_Action CreateShopNum1_SupplyDemandCheck_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SupplyDemandCheck_Action";
            return (IShopNum1_SupplyDemandCheck_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_SupplyDemandComment_Action CreateShopNum1_SupplyDemandComment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SupplyDemandComment_Action";
            return (IShopNum1_SupplyDemandComment_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_SurveyOption_Action CreateShopNum1_SurveyOption_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SurveyOption_Action";
            return (IShopNum1_SurveyOption_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_SurveyTheme_Action CreateShopNum1_SurveyTheme_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_SurveyTheme_Action";
            return (IShopNum1_SurveyTheme_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_User_Action CreateShopNum1_User_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_User_Action";
            return (IShopNum1_User_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_UserDefinedColumn_Action CreateShopNum1_UserDefinedColumn_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_UserDefinedColumn_Action";
            return (IShopNum1_UserDefinedColumn_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Vedio_List_Action CreateShopNum1_Vedio_List_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Vedio_List_Action";
            return (IShopNum1_Vedio_List_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_VedioCommentChecked_Action CreateShopNum1_VedioCommentChecked_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_VedioCommentChecked_Action";
            return (IShopNum1_VedioCommentChecked_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_Video_Action CreateShopNum1_Video_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_Video_Action";
            return (IShopNum1_Video_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_VideoCategory_Action CreateShopNum1_VideoCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_VideoCategory_Action";
            return
                (IShopNum1_VideoCategory_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_VideoComment_Action CreateShopNum1_VideoComment_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_VideoComment_Action";
            return (IShopNum1_VideoComment_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_WebSite_Action CreateShopNum1_WebSite_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_WebSite_Action";
            return (IShopNum1_WebSite_Action) Assembly.Load(BusinessLogic).CreateInstance(typeName);
        }

        public static IShopNum1_ZtcApply_Action CreateShopNum1_ZtcApply_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ZtcApply_Action";
            return (IShopNum1_ZtcApply_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_ZtcGoods_Action CreateShopNum1_ZtcGoods_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_ZtcGoods_Action";
            return (IShopNum1_ZtcGoods_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_MemberRank_LinkCategory_Action CreateMemberRank_LinkCategory_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_MemberRank_LinkCategory_Action";
            return (IShopNum1_MemberRank_LinkCategory_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }
        public static IShopNum1_PostageSettings_Action CreateShopNum1_PostageSettings_Action()
        {
            string typeName = BusinessLogic + ".ShopNum1_PostageSettings_Action";
            return (IShopNum1_PostageSettings_Action)Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }
        private static object smethod_0(string string_1, string string_2)
        {
            try
            {
                return Assembly.Load(string_1).CreateInstance(string_2);
            }
            catch
            {
                return null;
            }
        }

        private static object smethod_1(string string_1, string string_2)
        {
            object cache = FactoryDataCache.GetCache(string_2);
            if (cache == null)
            {
                try
                {
                    cache = Assembly.Load(string_1).CreateInstance(string_2);
                    FactoryDataCache.SetCache(string_2, cache);
                }
                catch
                {
                }
            }
            return cache;
        }

     
    }
}
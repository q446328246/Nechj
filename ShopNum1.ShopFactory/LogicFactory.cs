using System.Configuration;
using System.Reflection;
using ShopNum1.Cache;
using ShopNum1.Interface;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopFactory
{
    public sealed class LogicFactory
    {
        private static readonly string ShopBusinessLogic = ConfigurationManager.AppSettings["ShopBusinessLogic"];

       
        public static IShop_Advertisement_Action CreateShop_Advertisement_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Advertisement_Action";
            return (IShop_Advertisement_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Category_Action CreateShop_Category_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Category_Action";
            return (IShop_Category_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_CategoryInfo_Action CreateShop_CategoryInfo_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_CategoryInfo_Action";
            return (IShop_CategoryInfo_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Collect_Action CreateShop_Collect_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Collect_Action";
            return (IShop_Collect_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Common_Action CreateShop_Common_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Common_Action";
            return (IShop_Common_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Coupon_Action CreateShop_Coupon_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Coupon_Action";
            return (IShop_Coupon_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_CouponType_Action CreateShop_CouponType_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_CouponType_Action";
            return (IShop_CouponType_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Ensure_Action CreateShop_Ensure_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Ensure_Action";
            return (IShop_Ensure_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Friends_Action CreateShop_Friends_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Friends_Action";
            return (IShop_Friends_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Image_Action CreateShop_Image_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Image_Action";
            return (IShop_Image_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_ImageCategory_Action CreateShop_ImageCategory_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_ImageCategory_Action";
            return (IShop_ImageCategory_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_LimtProduct_Action CreateShop_LimtProduct_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_LimtProduct_Action";
            return (IShop_LimtProduct_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_MessageBoard_Action CreateShop_MessageBoard_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_MessageBoard_Action";
            return (IShop_MessageBoard_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_MessageInfo_Action CreateShop_MessageInfo_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_MessageInfo_Action";
            return (IShop_MessageInfo_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_News_Action CreateShop_News_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_News_Action";
            return (IShop_News_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_NewsCategory_Action CreateShop_NewsCategory_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_NewsCategory_Action";
            return (IShop_NewsCategory_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_OnLineService_Action CreateShop_OnLineService_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_OnLineService_Action";
            return (IShop_OnLineService_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_OrderInfo_Action CreateShop_OrderInfo_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_OrderInfo_Action";
            return (IShop_OrderInfo_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_PackAge_Action CreateShop_PackAge_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_PackAge_Action";
            return (IShop_PackAge_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_PageInfo_Action CreateShop_PageInfo_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_PageInfo_Action";
            return (IShop_PageInfo_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Photo_Action CreateShop_Photo_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Photo_Action";
            return (IShop_Photo_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }
       

        public static IShop_Product_Action CreateShop_Product_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Product_Action";
            return (IShop_Product_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_ProductBooking_Action CreateShop_ProductBooking_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_ProductBooking_Action";
            return (IShop_ProductBooking_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_ProductCategory_Action CreateShop_ProductCategory_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_ProductCategory_Action";
            return (IShop_ProductCategory_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_ProductComment_Action CreateShop_ProductComment_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_ProductComment_Action";
            return (IShop_ProductComment_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_ProductConsult_Action CreateShop_ProductConsult_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_ProductConsult_Action";
            return (IShop_ProductConsult_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Rank_Action CreateShop_Rank_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Rank_Action";
            return (IShop_Rank_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Report_Action CreateShop_Report_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Report_Action";
            return (IShop_Report_Action) Assembly.Load("ShopNum1.ShopBusinessLogic").CreateInstance(typeName);
        }

        public static IShop_Reputation_Action CreateShop_Reputation_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Reputation_Action";
            return (IShop_Reputation_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_ShopApplyRank_Action CreateShop_ShopApplyRank_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_ShopApplyRank_Action";
            return (IShop_ShopApplyRank_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_ShopInfo_Action CreateShop_ShopInfo_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_ShopInfo_Action";
            return (IShop_ShopInfo_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_ShopLink_Action CreateShop_ShopLink_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_ShopLink_Action";
            return (IShop_ShopLink_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_StarGuide_Action CreateShop_StarGuide_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_StarGuide_Action";
            return (IShop_StarGuide_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_SupplyDemand_Action CreateShop_SupplyDemand_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_SupplyDemand_Action";
            return (IShop_SupplyDemand_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_SupplyDemandCategory_Action CreateShop_SupplyDemandCategory_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_SupplyDemandCategory_Action";
            return (IShop_SupplyDemandCategory_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_URLManage_Action CreateShop_URLManage_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_URLManage_Action";
            return (IShop_URLManage_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_UserDefinedColumn_Action CreateShop_UserDefinedColumn_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_UserDefinedColumn_Action";
            return (IShop_UserDefinedColumn_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_Video_Action CreateShop_Video_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_Video_Action";
            return (IShop_Video_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_VideoCategory_Action CreateShop_VideoCategory_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_VideoCategory_Action";
            return (IShop_VideoCategory_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
        }

        public static IShop_VideoComment_Action CreateShop_VideoComment_Action()
        {
            string typeName = ShopBusinessLogic + ".Shop_VideoComment_Action";
            return (IShop_VideoComment_Action) Assembly.Load(ShopBusinessLogic).CreateInstance(typeName);
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
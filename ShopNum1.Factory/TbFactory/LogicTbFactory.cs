using System.Reflection;
using ShopNum1.Interface;

namespace ShopNum1.Factory
{
    public sealed class LogicTbFactory
    {
        private static readonly string string_0 = "ShopNum1.BusinessLogic";

        public static IShopNum1_TbAddress_Action CreateShopNum1_TbAddress_Action()
        {
            string typeName = string_0 + ".ShopNum1_TbAddress_Action";
            return (IShopNum1_TbAddress_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_TbItem_Action CreateShopNum1_TbItem_Action()
        {
            string typeName = string_0 + ".ShopNum1_TbItem_Action";
            return (IShopNum1_TbItem_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_TbItemImg_Action CreateShopNum1_TbItemImg_Action()
        {
            string typeName = string_0 + ".ShopNum1_TbItemImg_Action";
            return (IShopNum1_TbItemImg_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_TbSellCat_Action CreateShopNum1_TbSellCat_Action()
        {
            string typeName = string_0 + ".ShopNum1_TbSellCat_Action";
            return (IShopNum1_TbSellCat_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_TbSku_Action CreateShopNum1_TbSku_Action()
        {
            string typeName = string_0 + ".ShopNum1_TbSku_Action";
            return (IShopNum1_TbSku_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_TbSystem_Action CreateShopNum1_TbSystem_Action()
        {
            string typeName = string_0 + ".ShopNum1_TbSystem_Action";
            return (IShopNum1_TbSystem_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }

        public static IShopNum1_TbTopKey_Action CreateShopNum1_TbTopKey_Action()
        {
            string typeName = string_0 + ".ShopNum1_TbTopKey_Action";
            return (IShopNum1_TbTopKey_Action) Assembly.Load("ShopNum1.BusinessLogic").CreateInstance(typeName);
        }
    }
}
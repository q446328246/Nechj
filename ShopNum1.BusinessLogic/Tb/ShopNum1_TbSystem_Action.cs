using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_TbSystem_Action : IShopNum1_TbSystem_Action
    {
        private static
            Func<Pro_ShopNum1_TbSystemCheckBindResult, Pro_ShopNum1_TbSystemCheckBindResult> func_0;

        private readonly ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext_0 =
            new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());

        public bool CheckTbUserBind(string tbShopName, string memlogid, out string shopName)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@tbshopname";
            paraValue[0] = tbShopName;
            paraName[1] = "@Memlogid";
            paraValue[1] = memlogid;
            DataSet set = DatabaseExcetue.RunProcedureReturnDataSet("[Pro_ShopNum1_TbSystemCheckBind]", paraName,
                paraValue);
            if (int.Parse(set.Tables[0].Rows[0]["TotalCount"].ToString()) > 0)
            {
                shopName = set.Tables[1].Rows[0]["tbShopName"].ToString();
                return true;
            }
            shopName = set.Tables[1].Rows[0]["tbShopName"].ToString();
            return false;
        }

        public ShopNum1_TbSystem GetTbSysem(string memlogid, string shopname)
        {
            var class2 = new Class5
            {
                string_0 = memlogid,
                string_1 = shopname
            };
            try
            {
                using (
                    IEnumerator<ShopNum1_TbSystem> enumerator =
                        (from v in shopNum1_TbLinqDataContext_0.ShopNum1_TbSystems
                            where (v.Memlogid == class2.string_0) && (v.tbShopName == class2.string_1)
                            select v).GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        return enumerator.Current;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool InsertTbSystem(string memglogid, string shopname)
        {
            try
            {
                return (shopNum1_TbLinqDataContext_0.Pro_ShopNum1_TbSystem_Insert(shopname, memglogid) > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(string memlogid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@Memlogid";
            paraValue[0] = memlogid;
            return (DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbSystem_RemoveBind", paraName, paraValue) > 0);
        }

        public bool UpdateTbSystem(ShopNum1_TbSystem tbSystem)
        {
            var class2 = new Class6
            {
                shopNum1_TbSystem_0 = tbSystem
            };
            try
            {
                foreach (ShopNum1_TbSystem system in from v in shopNum1_TbLinqDataContext_0.ShopNum1_TbSystems
                    where
                        (v.Memlogid == class2.shopNum1_TbSystem_0.Memlogid) &&
                        (v.tbShopName == class2.shopNum1_TbSystem_0.tbShopName)
                    select v)
                {
                    system.hasTbOrder = class2.shopNum1_TbSystem_0.hasTbOrder;
                    system.hasTbRate = class2.shopNum1_TbSystem_0.hasTbRate;
                    system.isOpen = class2.shopNum1_TbSystem_0.isOpen;
                    system.siteCount = class2.shopNum1_TbSystem_0.siteCount;
                    system.siteDesc = class2.shopNum1_TbSystem_0.siteDesc;
                    system.siteImg = class2.shopNum1_TbSystem_0.siteImg;
                    system.siteItemName = class2.shopNum1_TbSystem_0.siteItemName;
                    system.siteItemPrice = class2.shopNum1_TbSystem_0.siteItemPrice;
                    system.siteSellCat = class2.shopNum1_TbSystem_0.siteSellCat;
                    system.tbCount = class2.shopNum1_TbSystem_0.tbCount;
                    system.tbDesc = class2.shopNum1_TbSystem_0.tbDesc;
                    system.tbImg = class2.shopNum1_TbSystem_0.tbImg;
                    system.tbItemName = class2.shopNum1_TbSystem_0.tbItemName;
                    system.tbItemPrice = class2.shopNum1_TbSystem_0.tbItemPrice;
                    system.tbSellCat = class2.shopNum1_TbSystem_0.tbSellCat;
                }
                shopNum1_TbLinqDataContext_0.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckShopBind(string shopName, string memlgoid, out string Name)
        {
            Name = string.Empty;
            if (func_0 == null)
            {
                func_0 = smethod_0;
            }
            Enumerable.Select(shopNum1_TbLinqDataContext_0.Pro_ShopNum1_TbSystemCheckBind(shopName, memlgoid), func_0);
            return true;
        }


        private static Pro_ShopNum1_TbSystemCheckBindResult smethod_0(
            Pro_ShopNum1_TbSystemCheckBindResult pro_ShopNum1_TbSystemCheckBindResult_0)
        {
            return pro_ShopNum1_TbSystemCheckBindResult_0;
        }


        private sealed class Class5
        {
            public string string_0;
            public string string_1;
        }


        private sealed class Class6
        {
            public ShopNum1_TbSystem shopNum1_TbSystem_0;
        }
    }
}
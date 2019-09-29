using System;
using System.Collections.Generic;
using System.Linq;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_TbTopKey_Action : IShopNum1_TbTopKey_Action
    {
        private readonly ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext_0 =
            new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());

        public bool AddTbTopKey(ShopNum1_TbTopKey tbtopkey)
        {
            bool flag;
            try
            {
                shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys.InsertOnSubmit(tbtopkey);
                shopNum1_TbLinqDataContext_0.SubmitChanges();
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool Delete(string memlogid)
        {
            var class2 = new Class1
            {
                string_0 = memlogid
            };
            try
            {
                IQueryable<ShopNum1_TbTopKey> entities = from v in shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys
                    where v.MemloginID == class2.string_0
                    select v;
                shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys.DeleteAllOnSubmit(entities);
                shopNum1_TbLinqDataContext_0.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ShopNum1_TbTopKey SearchTopKey(string memlogid)
        {
            var class2 = new Class2
            {
                string_0 = memlogid
            };
            try
            {
                using (
                    IEnumerator<ShopNum1_TbTopKey> enumerator =
                        (from v in shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys
                            where v.MemloginID == class2.string_0
                            select v).GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        return enumerator.Current;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public bool UpdateTopKey(ShopNum1_TbTopKey tbtopkey)
        {
            var class2 = new Class3
            {
                shopNum1_TbTopKey_0 = tbtopkey
            };
            try
            {
                foreach (ShopNum1_TbTopKey key in from v in shopNum1_TbLinqDataContext_0.ShopNum1_TbTopKeys
                    where v.MemloginID == class2.shopNum1_TbTopKey_0.MemloginID
                    select v)
                {
                    key.AppKey = class2.shopNum1_TbTopKey_0.AppKey;
                    key.AppSecret = class2.shopNum1_TbTopKey_0.AppSecret;
                    key.IsForbid = class2.shopNum1_TbTopKey_0.IsForbid;
                    key.ModifyTime = class2.shopNum1_TbTopKey_0.ModifyTime;
                    key.URL = class2.shopNum1_TbTopKey_0.URL;
                }
                shopNum1_TbLinqDataContext_0.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        private sealed class Class1
        {
            public string string_0;
        }


        private sealed class Class2
        {
            public string string_0;
        }


        private sealed class Class3
        {
            public ShopNum1_TbTopKey shopNum1_TbTopKey_0;
        }
    }
}
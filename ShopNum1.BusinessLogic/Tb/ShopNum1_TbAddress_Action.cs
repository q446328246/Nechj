using System;
using System.Collections.Generic;
using System.Linq;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_TbAddress_Action : IShopNum1_TbAddress_Action
    {
        public List<ShopNum1_TbAddress> GetAllProvince()
        {
            var context = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
            var list = new List<ShopNum1_TbAddress>();
            try
            {
                foreach (ShopNum1_TbAddress address in from v in context.ShopNum1_TbAddresses
                    where v.parent_Id == 0
                    select v)
                {
                    list.Add(address);
                }
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        public List<ShopNum1_TbAddress> GetCitysByParent(int parentId)
        {
            var class2 = new Class0
            {
                int_0 = parentId
            };
            var context = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
            var list = new List<ShopNum1_TbAddress>();
            try
            {
                foreach (ShopNum1_TbAddress address in from v in context.ShopNum1_TbAddresses
                    where v.parent_Id == class2.int_0
                    orderby v.Id descending
                    select v)
                {
                    list.Add(address);
                }
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        public bool InsertTbAreas(ShopNum1_TbAddress tbAreas)
        {
            var context = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
            try
            {
                context.ShopNum1_TbAddresses.InsertOnSubmit(tbAreas);
                context.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private sealed class Class0
        {
            public int int_0;
        }
    }
}
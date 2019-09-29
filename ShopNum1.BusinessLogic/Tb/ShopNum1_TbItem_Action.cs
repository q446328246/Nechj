using System;
using System.Data;
using System.Linq;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_TbItem_Action : IShopNum1_TbItem_Action
    {
        public string CheckItemByTb(string num_iid, string Memlogid, string shopName)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@num_iid";
            paraValue[0] = num_iid;
            paraName[1] = "@Memlogid";
            paraValue[1] = Memlogid;
            paraName[2] = "@shopname";
            paraValue[2] = shopName;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbItemCheck", paraName,
                paraValue);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return "0";
            }
            return table.Rows[0]["site_Id"].ToString();
        }

        public string checkItemExists(decimal numiid)
        {
            var class2 = new Class4
            {
                decimal_0 = numiid
            };
            var context = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
            try
            {
                IQueryable<string> queryable = from v in context.ShopNum1_TbItems
                    where v.num_iid == Convert.ToDecimal(class2.decimal_0)
                    select v.site_Id;
                if (queryable == null)
                {
                    return "";
                }
                var table = (DataTable) queryable;
                if (table.Rows.Count == 0)
                {
                    return "";
                }
                return table.Rows[0]["site_Id"].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public DataSet checkItemSiteExists(string siteCid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@site_id";
            paraValue[0] = siteCid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_TbItemCheckSite", paraName, paraValue);
        }

        public DataTable GetAllItem(string shopname, string memlogid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memlogid";
            paraValue[0] = memlogid;
            paraName[1] = "@shopname";
            paraValue[1] = shopname;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbItem_GetAll", paraName, paraValue);
        }

        public bool InsertItem(ShopNum1_TbItem tbitem)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@num_iid";
            paraValue[0] = tbitem.num_iid.ToString();
            paraName[1] = "@site_id";
            paraValue[1] = tbitem.site_Id;
            paraName[2] = "@memlogid";
            paraValue[2] = tbitem.Memlogid;
            paraName[3] = "@shopname";
            paraValue[3] = tbitem.ShopName;
            paraName[4] = "@istaobao";
            paraValue[4] = tbitem.isTaobao.ToString();
            return (DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbItem_InsertS", paraName, paraValue) > 0);
        }

        public bool InsertItemSimplify(decimal numiid, string siteId, decimal decimal_0, bool isTaobao)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@num_iid";
            paraValue[0] = numiid.ToString();
            paraName[1] = "@site_id";
            paraValue[1] = siteId;
            paraName[2] = "@cid";
            paraValue[2] = decimal_0.ToString();
            paraName[3] = "@isTaobao";
            paraValue[3] = isTaobao.ToString();
            return (DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbItem_InsertS", paraName, paraValue) > 0);
        }

        public bool UpdateProductCount(string num_iid, string memlogid, string string_0)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@num_iid";
            paraValue[0] = num_iid;
            paraName[1] = "@memlogid";
            paraValue[1] = memlogid;
            paraName[2] = "@num";
            paraValue[2] = string_0;
            return (DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbItem_UpdateProductCount", paraName, paraValue) > 0);
        }

        public bool UpdateProductItems(string num_iid, string memlogid, string string_0, string title, string price)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@num_iid";
            paraValue[0] = num_iid;
            paraName[1] = "@memlogid";
            paraValue[1] = memlogid;
            paraName[2] = "@num";
            paraValue[2] = string_0;
            paraName[3] = "@title";
            paraValue[3] = title;
            paraName[4] = "@price";
            paraValue[4] = price;
            return (DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbItem_UpdateProductItem", paraName, paraValue) > 0);
        }


        private sealed class Class4
        {
            public decimal decimal_0;
        }
    }
}
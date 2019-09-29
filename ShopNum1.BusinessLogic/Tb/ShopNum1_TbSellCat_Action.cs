using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_TbSellCat_Action : IShopNum1_TbSellCat_Action
    {
        private readonly ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext_0 =
            new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());

        public decimal CheckSellCatByTb(string shopname, string string_0, string MemloginId)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopname";
            paraValue[0] = shopname;
            paraName[1] = "@cid";
            paraValue[1] = string_0;
            paraName[2] = "@memloginId";
            paraValue[2] = MemloginId;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbSellCat_Check", paraName,
                paraValue);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return 0M;
            }
            return Convert.ToDecimal(table.Rows[0]["site_cid"]);
        }

        public bool DeleteSellCat(string shopname, string memlogid, decimal decimal_0, decimal sitecid)
        {
            return (shopNum1_TbLinqDataContext_0.Pro_ShopNum1_TbSellCat_Delete(shopname, memlogid, decimal_0, sitecid) >
                    0);
        }

        public DataTable GetAllCidByShopName(string shopName, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shopname";
            paraValue[0] = shopName;
            paraName[1] = "@MemloginId";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbSellCat_GetAllcid", paraName, paraValue);
        }

        public DataTable GetSellCat(decimal siteCid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@site_cid";
            paraValue[0] = siteCid.ToString();
            DataSet set = DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_TbSellCat_CheckSiteCid", paraName,
                paraValue);
            if (set.Tables.Count == 2)
            {
                return set.Tables[1];
            }
            return null;
        }

        public bool InsertSellCat(ShopNum1_TbSellCat sellCat)
        {
            try
            {
                shopNum1_TbLinqDataContext_0.ShopNum1_TbSellCats.InsertOnSubmit(sellCat);
                shopNum1_TbLinqDataContext_0.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSellCat(ShopNum1_TbSellCat sellCat)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@cid";
            paraValue[0] = sellCat.cid.ToString();
            paraName[1] = "@name";
            paraValue[1] = sellCat.name;
            paraName[2] = "@pic_url";
            paraValue[2] = sellCat.pic_url;
            paraName[3] = "@sort_order";
            paraValue[3] = sellCat.sort_order.ToString();
            paraName[4] = "@site_cid";
            paraValue[4] = sellCat.site_cid.ToString();
            paraName[5] = "@shopname";
            paraValue[5] = sellCat.shopname;
            paraName[6] = "@MemloginId";
            paraValue[6] = sellCat.MemloginId;
            return (DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbSellCat_Update", paraName, paraValue) > 0);
        }

        public decimal CheckSellCat(string shopname, string string_0, string memloginid, string site_cid)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@shopname";
            paraValue[0] = shopname;
            paraName[1] = "@cid";
            paraValue[1] = string_0;
            paraName[2] = "@memloginid";
            paraValue[2] = memloginid;
            paraName[3] = "@site_cid";
            paraValue[3] = site_cid;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbSellCat_Check", paraName,
                paraValue);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return 0M;
            }
            object obj2 = table.Rows[0][0];
            if (obj2 == null)
            {
                return 0M;
            }
            return Convert.ToInt32(obj2);
        }

        public decimal CheckSiteSellCat(decimal siteCid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@site_cid";
            paraValue[0] = siteCid.ToString();
            DataSet set = DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_TbSellCat_CheckSiteCid", paraName,
                paraValue);
            if (set == null)
            {
                return 0M;
            }
            if ((set.Tables[0] == null) || (set.Tables[0].Rows.Count == 0))
            {
                return 0M;
            }
            if (set.Tables[0].Rows[0]["TotalCount"].ToString() == "0")
            {
                return 0M;
            }
            return Convert.ToDecimal(set.Tables[1].Rows[0]["cid"]);
        }
    }
}
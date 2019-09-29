using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Rank_Action : IShop_Rank_Action
    {
        public int Add(ShopNum1_ShopRank shopRank)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_ShopRank( \tGuid, \tName,    MaxProductCount ,   MaxFileCount ,   StartTime ,\tvalidityDate, \tprice, \tPic,    shopTemplate ,   IsOverrideDomain ,\tMaxSpellBuyCount, \tMaxPanicBuyCount,    MaxArticleCout,\tMaxVedioCount, \tIsDefault, \tIsSetSEO, \tCreateUser, \tCreateTime\t, \tRankValue\t, \tIsDeleted  ) VALUES (  '"
                , shopRank.Guid, "',  '", Operator.FilterString(shopRank.Name), "',  ",
                Operator.FilterString(shopRank.MaxProductCount), ",  ", Operator.FilterString(shopRank.MaxFileCount)
                , ",  '", Operator.FilterString(shopRank.StartTime), "',  '",
                Operator.FilterString(shopRank.validityDate), "',  '", Operator.FilterString(shopRank.price), "', '"
                , shopRank.Pic,
                "', '", Operator.FilterString(shopRank.shopTemplate), "',  ", shopRank.IsOverrideDomain, ",  ",
                Operator.FilterString(shopRank.MaxSpellBuyCount), ",  ",
                Operator.FilterString(shopRank.MaxPanicBuyCount), ",  ",
                Operator.FilterString(shopRank.MaxArticleCout), ", ", Operator.FilterString(shopRank.MaxVedioCount),
                ",  ", shopRank.IsDefault, ", ", shopRank.IsSetSEO,
                ", '", shopRank.CreateUser, "', '", shopRank.CreateTime, "',  '", shopRank.RankValue, "',  ",
                shopRank.IsDeleted, ")"
            });
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(string guids)
        {
            DataTable table =
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  COUNT(*) AS NUM FROM ShopNum1_ShopRank WHERE IsDefault=0 AND Guid IN(" + guids + ")");
            if (((table != null) && (table.Rows.Count > 0)) && (table.Rows[0]["NUM"].ToString() != "0"))
            {
                return -1;
            }
            DataTable table2 =
                DatabaseExcetue.ReturnDataTable("SELECT COUNT(*) AS NUM FROM ShopNum1_ShopInfo WHERE ShopRank in (" +
                                                guids + ")");
            if (((table2 != null) && (table2.Rows.Count > 0)) && (table2.Rows[0]["NUM"].ToString() != "0"))
            {
                return -2;
            }
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ShopRank  WHERE  Guid IN(" + guids + ")");
        }

        public int EditIsDefault()
        {
            string strSql = string.Empty;
            strSql = "update ShopNum1_ShopRank set IsDefault=1 where IsDefault=0";
            return DatabaseExcetue.RunNonQuery(strSql);
        }

        public DataTable GetDefaultRank()
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopDefaultRank");
        }

        public DataTable GetShopRank()
        {
            string strSql = string.Empty;
            strSql = "SELECT Guid,NAME,price FROM ShopNum1_ShopRank ";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetShopRankByGuid(string guid)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT NAME,pic FROM ShopNum1_ShopRank WHERE GUID=" + guid);
        }

        public DataTable GetShopRankInfoByMemLoginID(string memloginid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT A.Guid,A.Name,A.price,B.IsPayMent FROM ShopNum1_ShopRank AS A LEFT JOIN ShopNum1_Shop_ApplyShopRank AS B ON A.Guid=B.RankGuid AND B.MemberLoginID='" +
                    memloginid + "'");
        }


        public DataTable SlecetLeveleIDByMengoinID(string memloginid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select LevelID from ShopNum1_ShopInfo left join ShopNum1_ShopRank on ShopNum1_ShopInfo.ShopRank=ShopNum1_ShopRank,guid where ShopNum1_ShopInfo.MemLoginID='" + memloginid + "'");
        }





        public DataTable GetTemplateByRankGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetTemplateByRankGuid", paraName, paraValue);
        }

        public DataTable Search(int isDeleted)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT \tGuid, \tName, \tRankValue,    MaxProductCount ,   MaxFileCount ,   StartTime ,\tvalidityDate, \tprice, \tPic,    shopTemplate ,   IsOverrideDomain ,\tMaxSpellBuyCount, \tMaxPanicBuyCount,   MaxArticleCout,\tMaxVedioCount, \tIsDefault, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopRank   WHERE IsDeleted = " +
                    isDeleted + " Order By RankValue ASC ");
        }

        public DataTable Search(string guid, int isDeleted)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tGuid, \tName, \tRankValue,    MaxProductCount ,   MaxFileCount ,   StartTime ,\tvalidityDate, \tprice, \tPic,    shopTemplate ,   IsOverrideDomain ,\tMaxSpellBuyCount, \tMaxPanicBuyCount,   MaxArticleCout,\tMaxVedioCount, \tIsDefault, \tIsSetSEO, \tCreateUser, \tCreateTime\t, \tModifyUser, \tRankValue\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ShopRank   WHERE 0=0 ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted = ", isDeleted, " "});
            }
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND Guid = " + guid + " ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable ShopRankSearch(string name)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@name";
            paraValue[0] = name;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopRankSearch", paraName, paraValue);
        }

        public int Update(ShopNum1_ShopRank shopRank)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "UPDATE ShopNum1_ShopRank SET  Name='", Operator.FilterString(shopRank.Name), "', MaxProductCount=",
                Operator.FilterString(shopRank.MaxProductCount), ", MaxFileCount=",
                Operator.FilterString(shopRank.MaxFileCount), ", StartTime='",
                Operator.FilterString(shopRank.StartTime), "', validityDate='",
                Operator.FilterString(shopRank.validityDate), "', price='", Operator.FilterString(shopRank.price),
                "', Pic='", shopRank.Pic, "', shopTemplate='", Operator.FilterString(shopRank.shopTemplate),
                "', IsOverrideDomain=", Operator.FilterString(shopRank.IsOverrideDomain), ", MaxSpellBuyCount=",
                Operator.FilterString(shopRank.MaxSpellBuyCount), ", MaxPanicBuyCount=",
                Operator.FilterString(shopRank.MaxPanicBuyCount), ", MaxArticleCout=",
                Operator.FilterString(shopRank.MaxArticleCout), ", MaxVedioCount=",
                Operator.FilterString(shopRank.MaxVedioCount), ", IsDefault=",
                Operator.FilterString(shopRank.IsDefault), ", IsSetSEO=", Operator.FilterString(shopRank.IsSetSEO),
                ", ModifyUser='", shopRank.ModifyUser,
                "', RankValue='", shopRank.RankValue, "', ModifyTime='", shopRank.ModifyTime, "' WHERE Guid='",
                shopRank.Guid, "'"
            });
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int ClearApplyShopRank(string MemberLoginID)
        {
            return
                DatabaseExcetue.RunNonQuery("      DELETE  ShopNum1_Shop_ApplyShopRank    WHERE   MemberLoginID='" +
                                            MemberLoginID + "'     ");
        }

        public DataTable GetDefaultTemplate()
        {
            string strSql = string.Empty;
            strSql = "SELECT *  FROM ShopNum1_Shop_Template WHERE   IsDefault=1";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetShopRankPrice(string Guid)
        {
            return
                DatabaseExcetue.ReturnDataTable("   SELECT   price     FROM  ShopNum1_ShopRank  WHERE  Guid='" + Guid +
                                                "'    ");
        }

        public DataTable GetTemplateByPath(string Path)
        {
            return
                DatabaseExcetue.ReturnDataTable("   SELECT * FROM  ShopNum1_Shop_Template  WHERE  Path='" + Path +
                                                "'    ");
        }

        public int UpdateUserRank(string ShopRank, string MemLoginID)
        {
            return
                DatabaseExcetue.RunNonQuery("   UPDATE  ShopNum1_ShopInfo  SET  ShopRank='" + ShopRank +
                                            "'  WHERE  MemLoginID='" + MemLoginID + "'  ");
        }
    }
}
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberRank_LinkCategory_Action : IShopNum1_MemberRank_LinkCategory_Action
    {
        private static DataTable dt;

        public static DataTable RankLinkCategoryTable
        {
            get
            {
                if (dt == null)
                {
                    string strSql =
                        "select id , Rank_ID , Category_ID , IsReadOrBuy from ShopNum1_MemberRank_LinkCategory  ORDER BY OrderID DESC";
                    dt = DatabaseExcetue.ReturnDataTable(strSql);
                }
                return dt;
            }
            set { dt = null; }
        }

        public int Add(ShopNum1_MemberRank_LinkCategory shopNum1_MemberRank_LinkCategory)
        {
            RankLinkCategoryTable = null;
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MemberRank_LinkCategory (  Rank_ID  , Category_ID  , IsReadOrBuy   ) VALUES (  '"
                , shopNum1_MemberRank_LinkCategory.RankID, "',  '", Operator.FilterString(shopNum1_MemberRank_LinkCategory.Categories),
                "',  ", shopNum1_MemberRank_LinkCategory.IsReadOrBuy, " )"
            }));
        }

        public int Delete(int id)
        {
            RankLinkCategoryTable = null;
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "delete from ShopNum1_MemberRank_LinkCategory  WHERE ID =" + id + " ";
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

        public int Update(int id, ShopNum1_MemberRank_LinkCategory shopNum1_MemberRank_LinkCategory)
        {
            RankLinkCategoryTable = null;
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_MemberRank_LinkCategory SET  Category_ID  ='", Operator.FilterString(shopNum1_MemberRank_LinkCategory.Categories), "' WHERE id=", id
            }));
        }

        public DataTable GetRankLinkCategoryByID(string rank_ID, string isReadorBuy)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            
            parms[0].ParameterName = "@rank_ID";
            parms[0].Value = rank_ID;
            parms[1].ParameterName = "@isReadorBuy";
            parms[1].Value = isReadorBuy;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select * from ShopNum1_MemberRank_LinkCategory where Rank_ID=@rank_ID and IsReadOrBuy =@isReadorBuy " ,parms);
        }
    }
}

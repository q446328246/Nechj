using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Collections.Generic;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Collect_Action : IShopNum1_Collect_Action
    {
        public int Add(ShopNum1_ShopCollect collect)
        {
            return 0;
        }

        public int Delete(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Collect WHERE  Guid" + andSql, parms.ToArray());
        }

        public int DeleteMemberProductCollect(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteMemberProductCollect", paraName, paraValue);
        }

        public int DeleteMemberShopCollect(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid.Replace("'", "");
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteMemberShopCollect", paraName, paraValue);
        }

        public DataTable GetMemberCollectList(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberCollectList", paraName, paraValue);
        }

        public DataTable GetProductByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable("SELECT *    FROM ShopNum1_Shop_Product    WHERE  Guid =@guid",parms);
        }

        public DataTable Search(string memberLoginID, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT A.Guid, A.MemLoginID, A.ProductGuid, B.Name As ProductName, B.ShopPrice, A.CollectTime, A.IsDeleted  FROM ShopNum1_Collect AS A,ShopNum1_Product AS B   WHERE  A.ProductGuid = B.Guid ";
            if (memberLoginID != string.Empty)
            {
                str = str + " AND A.MemLoginID='" + memberLoginID + "'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND A.IsDeleted=", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by CollectTime Desc");
        }

        public int AddProductCollect(string memloginid, string productguid, string collecttime, string shopid,
            string isattention, string shopprice, string productname)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@productguid";
            paraValue[1] = productguid;
            paraName[2] = "@collecttime";
            paraValue[2] = collecttime;
            paraName[3] = "@shopid";
            paraValue[3] = shopid;
            paraName[4] = "@isattention";
            paraValue[4] = isattention;
            paraName[5] = "@shopprice";
            paraValue[5] = shopprice;
            paraName[6] = "@productname";
            paraValue[6] = productname;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddProductCollect", paraName, paraValue);
        }

        public DataTable GetMemberShopCollectList(string memLoginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memLoginID";
            paraValue[0] = memLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberShopCollectList", paraName,
                paraValue);
        }
    }
}
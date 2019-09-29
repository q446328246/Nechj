using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_SupplyDemand_Action : IShop_SupplyDemand_Action
    {
        public int Delete(string guid)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_SupplyDemand WHERE ID in(" + guid + ")");
        }

        public string GetAddressCode(string commerceMemLoginID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("AddressCode ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_Member ");
            builder.Append("WHERE ");
            builder.Append("MemLoginID = '" + commerceMemLoginID + "'");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public string GetAddressValue(string shopid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("AddressValue ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_Member ");
            builder.Append("WHERE ");
            builder.Append("MemLoginID = '" + shopid + "'");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }

        public DataTable GetSupplyDemandMeto(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandMeto", paraName, paraValue);
        }

        public DataTable Search(string commerceMemLoginID, string IsAudit)
        {
            string str = string.Empty;
            str =
                "SELECT \ta.Guid\t, \ta.Title\t, \ta.Content\t, \ta.TradeType\t, \ta.Description\t, \ta.Keywords\t, \ta.ReleaseTime\t, \ta.ValidTime\t, \ta.OrderID\t, \ta.Image\t, \ta.ShopNum1OrderID\t, \ta.AssociatedCategoryGuid\t, \ta.AssociatedMemberID\t, \ta.IsAudit, \tb.Name \tFROM \tShopNum1_SupplyDemand as a, \tShopNum1_SupplyDemandCategory  as b WHERE   a.AssociatedCategoryGuid = b.Code and a.AssociatedMemberID = '" +
                commerceMemLoginID + "'";
            if (IsAudit != "-1")
            {
                str = str + "and a.IsAudit = " + IsAudit;
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY a.Guid DESC ");
        }

        public int SupplyDemandCommentAdd(ShopNum1_SupplyDemandComment supplyDemandComment)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@title";
            paraValue[0] = supplyDemandComment.Title;
            paraName[1] = "@content";
            paraValue[1] = supplyDemandComment.Content;
            paraName[2] = "@createtime";
            paraValue[2] = supplyDemandComment.CreateTime.ToString();
            paraName[3] = "@createmerber";
            paraValue[3] = supplyDemandComment.CreateMerber;
            paraName[4] = "@createip";
            paraValue[4] = supplyDemandComment.CreateIP;
            paraName[5] = "@supplydemandguid";
            paraValue[5] = supplyDemandComment.SupplyDemandGuid;
            paraName[6] = "@associatememberid";
            paraValue[6] = supplyDemandComment.AssociateMemberID;
            paraName[7] = "@isaudit";
            paraValue[7] = supplyDemandComment.IsAudit.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_SupplyDemandCommentAdd", paraName, paraValue);
        }

        public DataTable SupplyDemandCommentList(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SupplyDemandCommentList", paraName,
                paraValue);
        }

        public DataTable SupplyDemandDetail(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SupplyDemandDetail", paraName, paraValue);
        }

        public DataRow UpdateSearch(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("  *   ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand");
            builder.Append(" WHERE ");
            builder.Append(" ID = '" + guid + "'");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0];
        }
    }
}
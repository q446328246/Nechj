using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_SupplyDemandCategory_Action : IShop_SupplyDemandCategory_Action
    {
        public int Delete(string guid)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_CategoryInfo WHERE [Guid] in (" + guid + ")");
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
            if (DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows.Count > 0)
            {
                return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
            }
            return "-1";
        }

        public string GetAddressValue(string addressCode)
        {
            if (
                DatabaseExcetue.RunProcedureReturnDataTable("Pro_AddressValue", "@addresscode", addressCode).Rows.Count >
                0)
            {
                return
                    DatabaseExcetue.RunProcedureReturnDataTable("Pro_AddressValue", "@addresscode", addressCode).Rows[0]
                        [0].ToString();
            }
            return "-1";
        }

        public int Insert(ShopNum1_CategoryInfo shopNum1_CategoryInfo)
        {
            string addressCode = GetAddressCode(shopNum1_CategoryInfo.AssociatedMemberID);
            string memberType = GetMemberType(shopNum1_CategoryInfo.AssociatedMemberID);
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_CategoryInfo(");
            builder.Append("Guid,");
            builder.Append("Title,");
            builder.Append("Type,");
            builder.Append("Content,");
            builder.Append("Keywords,");
            builder.Append("ValidTime,");
            builder.Append("CreateTime,");
            builder.Append("Tel,");
            builder.Append("Email,");
            builder.Append("OtherContactWay,");
            builder.Append("AssociatedCategoryGuid,");
            builder.Append("AddressCode,");
            builder.Append("AddressValue,");
            builder.Append("MemberType,");
            builder.Append("AssociatedMemberID)");
            builder.Append(" VALUES(");
            builder.Append("'" + shopNum1_CategoryInfo.Guid + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Title + "',");
            builder.Append(shopNum1_CategoryInfo.Type + ",");
            builder.Append("'" + shopNum1_CategoryInfo.Content + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Keywords + "',");
            builder.Append("'" + shopNum1_CategoryInfo.ValidTime + "',");
            builder.Append("getdate(),");
            builder.Append("'" + shopNum1_CategoryInfo.Tel + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Email + "',");
            builder.Append("'" + shopNum1_CategoryInfo.OtherContactWay + "',");
            builder.Append(shopNum1_CategoryInfo.AssociatedCategoryGuid + ",");
            builder.Append("'" + addressCode + "',");
            builder.Append("'" + GetAddressValue(addressCode) + "',");
            builder.Append("'" + memberType + "',");
            builder.Append("'" + shopNum1_CategoryInfo.AssociatedMemberID + "')");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable Search(string commerceMemLoginID, string IsAudit)
        {
            string str = string.Empty;
            str =
                "SELECT \ta.Guid\t, \ta.Title\t, \ta.Type\t, \ta.Content\t, \ta.Keywords\t, \ta.ValidTime\t, \ta.CreateTime\t, \ta.Tel, \ta.Email\t, \ta.OtherContactWay\t, \ta.IsAudit\t, \ta.AssociatedCategoryGuid\t, \ta.AssociatedMemberID\t, \ta.IsAudit, \tb.Name\tFROM \tShopNum1_CategoryInfo as a, \tChina315_CategoryCs as b WHERE   a.AssociatedCategoryGuid =b.ID and a.AssociatedMemberID = '" +
                commerceMemLoginID + "'";
            if (IsAudit != "-1")
            {
                str = str + "and a.IsAudit = " + IsAudit;
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY a.Guid DESC");
        }

        public int Update(ShopNum1_CategoryInfo shopNum1_CategoryInfo)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_CategoryInfo");
            builder.Append(" SET ");
            builder.Append("Title = '" + shopNum1_CategoryInfo.Title + "',");
            builder.Append("Type = '" + shopNum1_CategoryInfo.Type + "',");
            builder.Append("Content = '" + shopNum1_CategoryInfo.Content + "',");
            builder.Append("Keywords = '" + shopNum1_CategoryInfo.Keywords + "',");
            builder.Append("ValidTime = '" + shopNum1_CategoryInfo.ValidTime + "',");
            builder.Append("Tel = '" + shopNum1_CategoryInfo.Tel + "',");
            builder.Append("Email = '" + shopNum1_CategoryInfo.Email + "',");
            builder.Append("OtherContactWay = '" + shopNum1_CategoryInfo.OtherContactWay + "',");
            builder.Append("AssociatedCategoryGuid = '" + shopNum1_CategoryInfo.AssociatedCategoryGuid + "'");
            builder.Append(" WHERE ");
            builder.Append(" Guid = '" + shopNum1_CategoryInfo.Guid + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataRow UpdateSearch(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.Guid,");
            builder.Append("a.Title,");
            builder.Append("a.Type,");
            builder.Append("a.Content,");
            builder.Append("a.Keywords,");
            builder.Append("a.ValidTime,");
            builder.Append("a.CreateTime,");
            builder.Append("a.Tel,");
            builder.Append("a.Email,");
            builder.Append("a.OtherContactWay,");
            builder.Append("a.AssociatedCategoryGuid,");
            builder.Append("b.CategoryCfID");
            builder.Append(" FROM ShopNum1_CategoryInfo as a,");
            builder.Append("ShopNum1_SupplyDemandCategory as b");
            builder.Append(" WHERE Guid = " + guid);
            builder.Append(" and a.AssociatedCategoryGuid = b.ID");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0];
        }

        public string GetMemberType(string memLoginID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("MemberType ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_Member ");
            builder.Append("WHERE ");
            builder.Append("MemLoginID = '" + memLoginID + "'");
            return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
        }
    }
}
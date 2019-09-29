using System;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_CategoryInfo_Action : IShop_CategoryInfo_Action
    {
        public DataTable CategoryCommentList(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CategoryCommentList", paraName, paraValue);
        }

        public DataTable CategoryInfoDetail(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CategoryInfoDetail", paraName, paraValue);
        }

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
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("AddressValue ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_Member ");
            builder.Append("WHERE ");
            builder.Append("AddressCode = '" + addressCode + "'");
            if (DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows.Count > 0)
            {
                return DatabaseExcetue.ReturnDataTable(builder.ToString()).Rows[0][0].ToString();
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
            builder.Append("AssociatedCategoryName,");
            builder.Append("AddressCode,");
            builder.Append("AddressValue,");
            builder.Append("MemberType,");
            builder.Append("AssociatedMemberID)");
            builder.Append(" VALUES(");
            builder.Append("'" + shopNum1_CategoryInfo.Guid + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Title + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Type + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Content + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Keywords + "',");
            builder.Append("'" + shopNum1_CategoryInfo.ValidTime + "',");
            builder.Append("'" + DateTime.Now + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Tel + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Email + "',");
            builder.Append("'" + shopNum1_CategoryInfo.OtherContactWay + "',");
            builder.Append(shopNum1_CategoryInfo.AssociatedCategoryGuid + ",");
            builder.Append(shopNum1_CategoryInfo.AssociatedCategoryName + ",");
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
                "SELECT \ta.Guid\t, \ta.Title\t, \ta.Type\t, \ta.Content\t, \ta.Keywords\t, \ta.ValidTime\t, \ta.CreateTime\t, \ta.Tel, \ta.Email\t, \ta.OtherContactWay\t, \ta.IsAudit\t, \ta.AssociatedCategoryGuid\t, \ta.AssociatedMemberID\t, \ta.IsAudit, \tb.Name\tFROM \tShopNum1_CategoryInfo as a, \tShopNum1_Category as b WHERE   a.AssociatedCategoryGuid =b.Code and a.AssociatedMemberID = '" +
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
            builder.Append("Description = '" + shopNum1_CategoryInfo.Description + "',");
            builder.Append("ValidTime = '" + shopNum1_CategoryInfo.ValidTime + "',");
            builder.Append("AddressCode = '" + shopNum1_CategoryInfo.AddressCode + "',");
            builder.Append("AddressValue = '" + shopNum1_CategoryInfo.AddressValue + "',");
            builder.Append("Tel = '" + shopNum1_CategoryInfo.Tel + "',");
            builder.Append("IsAudit = " + shopNum1_CategoryInfo.IsAudit + ",");
            builder.Append("Email = '" + shopNum1_CategoryInfo.Email + "',");
            builder.Append("OtherContactWay = '" + shopNum1_CategoryInfo.OtherContactWay + "',");
            builder.Append("AssociatedCategoryName = '" + shopNum1_CategoryInfo.AssociatedCategoryName + "',");
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
            builder.Append("a.Description,");
            builder.Append("a.ValidTime,");
            builder.Append("a.CreateTime,");
            builder.Append("a.AssociatedMemberID,");
            builder.Append("a.AddressCode,");
            builder.Append("a.Tel,");
            builder.Append("a.Email,");
            builder.Append("a.OtherContactWay,");
            builder.Append("a.AssociatedCategoryGuid,");
            builder.Append("b.Name");
            builder.Append(" FROM ShopNum1_CategoryInfo as a,");
            builder.Append("ShopNum1_Category as b");
            builder.Append(" WHERE Guid = '" + guid + "'");
            builder.Append(" and a.AssociatedCategoryGuid = b.code");
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

        public int InsertAdd(ShopNum1_CategoryInfo shopNum1_CategoryInfo)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_CategoryInfo(");
            builder.Append("Guid,");
            builder.Append("Title,");
            builder.Append("Type,");
            builder.Append("Content,");
            builder.Append("Keywords,");
            builder.Append("Description,");
            builder.Append("ValidTime,");
            builder.Append("Tel,");
            builder.Append("IsAudit,");
            builder.Append("Email,");
            builder.Append("OtherContactWay,");
            builder.Append("AssociatedCategoryGuid,");
            builder.Append("AssociatedCategoryName,");
            builder.Append("AddressCode,");
            builder.Append("AddressValue,");
            builder.Append("AssociatedMemberID)");
            builder.Append(" VALUES(");
            builder.Append("'" + shopNum1_CategoryInfo.Guid + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Title + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Type + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Content + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Keywords + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Description + "',");
            builder.Append("'" + shopNum1_CategoryInfo.ValidTime + "',");
            builder.Append("'" + shopNum1_CategoryInfo.Tel + "',");
            builder.Append(shopNum1_CategoryInfo.IsAudit + ",");
            builder.Append("'" + shopNum1_CategoryInfo.Email + "',");
            builder.Append("'" + shopNum1_CategoryInfo.OtherContactWay + "',");
            builder.Append("'" + shopNum1_CategoryInfo.AssociatedCategoryGuid + "',");
            builder.Append("'" + shopNum1_CategoryInfo.AssociatedCategoryName + "',");
            builder.Append("'" + shopNum1_CategoryInfo.AddressCode + "',");
            builder.Append("'" + shopNum1_CategoryInfo.AddressValue + "',");
            builder.Append("'" + shopNum1_CategoryInfo.AssociatedMemberID + "')");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}
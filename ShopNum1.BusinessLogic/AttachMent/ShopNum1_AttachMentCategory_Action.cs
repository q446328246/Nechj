using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_AttachMentCategory_Action : IShopNum1_AttachMentCategory_Action
    {
        public int Delete(string guid)
        {
            var list = new List<string>();
            string item = "DELETE FROM ShopNum1_AttachMent WHERE AssociatedCategoryGuid in (" + guid + ")";
            list.Add(item);
            item = "DELETE FROM ShopNum1_AttachMentCateGory WHERE [Guid] in (" + guid + ")";
            list.Add(item);
            try
            {
                DatabaseExcetue.CheckExists(item);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataRow EditShow(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("CategoryName,");
            builder.Append("Description");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_AttachMentCateGory");
            builder.Append(" WHERE ");
            builder.Append("Guid =@guid");
            builder.Append(" AND Isdeleted = 0");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms).Rows[0];
        }

        public int Insert(ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ");
            builder.Append("ShopNum1_AttachMentCateGory(");
            builder.Append("Guid,");
            builder.Append("CateGoryName,");
            builder.Append("[Description],");
            builder.Append("[Isdeleted] )");
            builder.Append("VALUES(");
            builder.Append("'" + shopNum1_AttachMentCateGory.Guid + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_AttachMentCateGory.CateGoryName) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_AttachMentCateGory.Description) + "',");
            builder.Append("0 )");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable Search()
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("CategoryName,");
            builder.Append("Description,");
            builder.Append("Isdeleted ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_AttachMentCateGory");
            builder.Append(" WHERE ");
            builder.Append(" Isdeleted = 0");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Update(ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_AttachMentCateGory");
            builder.Append(" SET ");
            builder.Append("CateGoryName = '" + Operator.FilterString(shopNum1_AttachMentCateGory.CateGoryName) + "',");
            builder.Append("[Description] ='" + Operator.FilterString(shopNum1_AttachMentCateGory.Description) + "'");
            builder.Append(" WHERE ");
            builder.Append("[Guid] = '" + shopNum1_AttachMentCateGory.Guid + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}
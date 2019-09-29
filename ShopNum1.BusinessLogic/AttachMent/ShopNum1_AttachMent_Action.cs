﻿using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_AttachMent_Action : IShopNum1_AttachMent_Action
    {
        public int Delete(string Guid)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_AttachMent WHERE [Guid] in (" + Guid + ")");
        }

        public int Insert(ShopNum1_AttachMent shopNum1_AttachMent)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_AttachMent(");
            builder.Append("Guid,");
            builder.Append("Title,");
            builder.Append("AttachmentURL,");
            builder.Append("Description,");
            builder.Append("UploadTime,");
            builder.Append("AssociatedCategoryGuid )");
            builder.Append(" VALUES(");
            builder.Append("'" + shopNum1_AttachMent.Guid + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_AttachMent.Title) + "',");
            builder.Append("'" + shopNum1_AttachMent.AttachmentURL + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_AttachMent.Description) + "',");
            builder.Append("getdate(),");
            builder.Append("'" + shopNum1_AttachMent.AssociatedCategoryGuid + "' )");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable Search(string AssociatedCategoryGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@AssociatedCategoryGuid";
            parms[0].Value = AssociatedCategoryGuid;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.Guid,");
            builder.Append("a.Title,");
            builder.Append("a.AttachmentURL,");
            builder.Append("a.Description,");
            builder.Append("a.UploadTime,");
            builder.Append("b.CategoryName");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_AttachMent as a,");
            builder.Append("ShopNum1_AttachMentCateGory as b");
            builder.Append(" WHERE ");
            builder.Append("a.AssociatedCategoryGuid = b.Guid ");
            if (AssociatedCategoryGuid != "-1")
            {
                builder.Append(" and a.AssociatedCategoryGuid =@AssociatedCategoryGuid");
            }
            builder.Append(" ORDER BY a.UploadTime DESC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataRow SearchAttachMent(string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("Title,");
            builder.Append("AttachmentURL,");
            builder.Append("Description,");
            builder.Append("AssociatedCategoryGuid");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_AttachMent");
            builder.Append(" WHERE ");
            builder.Append("Guid =@Guid");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms).Rows[0];
        }
    }
}
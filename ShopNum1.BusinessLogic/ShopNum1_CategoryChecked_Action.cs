using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_CategoryChecked_Action : IShopNum1_CategoryChecked_Action
    {
        private static DataTable dt;

        public static DataTable CategoryTable
        {
            get
            {
                if (dt == null)
                {
                    string strSql =
                        "SELECT ID,[Name],[Code],OrderID,FatherID FROM ShopNum1_Category WHERE IsDeleted=0 and isshow=1 ORDER BY OrderID DESC";
                    dt = DatabaseExcetue.ReturnDataTable(strSql);
                }
                return dt;
            }
            set { dt = null; }
        }

        public int Add(ShopNum1_CategoryInfo categoryInfo)
        {
            throw new NotImplementedException();
        }

        public int AddCategoryInfo(ShopNum1_CategoryInfo categoryInfo)
        {
            var paraName = new string[11];
            var paraValue = new string[11];
            paraName[0] = "@title";
            paraValue[0] = categoryInfo.Title;
            paraName[1] = "@type";
            paraValue[1] = categoryInfo.Type;
            paraName[2] = "@content";
            paraValue[2] = categoryInfo.Content;
            paraName[3] = "@keywords";
            paraValue[3] = categoryInfo.Keywords;
            paraName[4] = "@validtime";
            paraValue[4] = categoryInfo.ValidTime;
            paraName[5] = "@createtime";
            paraValue[5] = categoryInfo.CreateTime.ToString();
            paraName[6] = "@tel";
            paraValue[6] = categoryInfo.Tel;
            paraName[7] = "@email";
            paraValue[7] = categoryInfo.Email;
            paraName[8] = "@othercontactway";
            paraValue[8] = categoryInfo.OtherContactWay;
            paraName[9] = "@associatedcategoryguid";
            paraValue[9] = categoryInfo.AssociatedCategoryGuid;
            paraName[10] = "@associatedmemberid";
            paraValue[10] = categoryInfo.AssociatedMemberID;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddCategoryInfo", paraName, paraValue);
        }

        public int Delete(string guids)
        {
            var builder = new StringBuilder();
            builder.Append("DELETE ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_CategoryInfo ");
            builder.Append("WHERE ");
            builder.Append("[Guid] IN ");
            builder.Append("(" + guids + ") ");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable EditCategoryInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid.Replace("'","");
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_EditCategoryInfo", paraName, paraValue);
        }

        public DataTable GetCategoryByCode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryByCode", paraName, paraValue);
        }

        public DataTable GetCategoryDetails(string guid)
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CategoryInfoDetail", "@guid", guid);
        }

        public DataTable GetCategoryInfoMeto(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid.Replace("'","");
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryInfoMeto", paraName, paraValue);
        }

        public DataTable GetCategoryNewList(string showCount)
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetNewShopNum1CategoryInfo", "@showCount",
                showCount);
        }

        public DataTable GetCategoryOnAndNext(string guid, string onCategoryName, string nextCategoryName)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @CreateTime datetime ");
            builder.Append("SELECT @CreateTime = CreateTime FROM ShopNum1_CategoryInfo ");
            builder.Append("WHERE Guid = '" + guid + "' ");
            builder.Append("SELECT * FROM(");
            builder.Append("SELECT TOP 1 Guid,Title,'" + onCategoryName + "' as [Name] FROM ShopNum1_CategoryInfo ");
            builder.Append("WHERE CreateTime < @CreateTime ");
            builder.Append("ORDER BY CreateTime DESC");
            builder.Append(") as a ");
            builder.Append("UNION ");
            builder.Append("SELECT * FROM(");
            builder.Append("SELECT TOP 1 Guid,Title,'" + nextCategoryName + "' as [Name] FROM ShopNum1_CategoryInfo ");
            builder.Append("WHERE CreateTime > @CreateTime and IsAudit=1");
            builder.Append(" ORDER BY CreateTime ASC ");
            builder.Append(") as b");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetList(string categoryID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("[ID],");
            builder.Append("[Name],");
            builder.Append("[code]");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Category");
            builder.Append(" WHERE fatherID=" + categoryID);
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public string GetMemberID(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("select AssociatedMemberID from dbo.ShopNum1_CategoryInfo WHERE guid=" + guid);
            return DatabaseExcetue.ReturnString(builder.ToString());
        }

        public DataTable Search(string MemberID)
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryInfo", "@memberID", MemberID);
        }

        public DataTable Search(string Code, string isAudit)
        {
            return null;
        }

        public DataTable Search(int fatherID, int isDeleted, string ShowCount)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT TOP  ", ShowCount,
                        "\t[ID]\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_Category  WHERE  FatherID =@fatherID AND  IsDeleted =@isDeleted ORDER BY OrderID ASC"
                    }),parms);
        }

        public DataSet Search(string perpagenum, string current_page, string supplyName, string supplyCategoryCode,
            string supplyAddressCode, string ordername, string isreturcount)
        {
            string str = string.Empty;
            if (supplyCategoryCode != "-1")
            {
                str = " AND A.AssociatedCategoryGuid like '" + Operator.FilterString(supplyCategoryCode) + "%'";
            }
            if (supplyName != "-1")
            {
                str = str + " AND A.Title LIKE '%" + Operator.FilterString(supplyName) + "%'";
            }
            if (supplyAddressCode != "-1")
            {
                str = str + " AND A.AddressCode LIKE '%" + Operator.FilterString(supplyAddressCode) + "%'";
            }
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@perpagenum";
            paraValue[0] = perpagenum;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@ColumnNames";
            paraValue[2] =
                " A.Guid,A.Title,A.Content,A.Description,A.Keywords,A.CreateTime,A.ValidTime,A.AssociatedCategoryGuid,A.AddressCode,A.AddressValue,A.AssociatedCategoryName,A.AssociatedMemberID ";
            paraName[3] = "@OrderName";
            paraValue[3] = " A.CreateTime ";
            paraName[4] = "@searchName";
            paraValue[4] = str;
            paraName[5] = "@sDesc";
            paraValue[5] = "";
            paraName[6] = "@isReturCount";
            paraValue[6] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetCategoryListSearch", paraName, paraValue);
        }

        public DataSet Search(string pageindex, string pagesize, string addresscode, string associatedcategoryguid,
            string createtime1, string createtime2, string keywords, string title)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pageindex";
            paraValue[0] = pageindex;
            paraName[1] = "@pagesize";
            paraValue[1] = pagesize;
            paraName[2] = "@addresscode";
            paraValue[2] = addresscode;
            paraName[3] = "@associatedcategoryguid";
            paraValue[3] = associatedcategoryguid;
            paraName[4] = "@createtime1";
            paraValue[4] = createtime1;
            paraName[5] = "@createtime2";
            paraValue[5] = createtime2;
            paraName[6] = "@keywords";
            paraValue[6] = keywords;
            paraName[7] = "@title";
            paraValue[7] = title;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetCategoryInfoSearch", paraName, paraValue);
        }

        public DataTable SearchByCategoryIDFrist(string CategoryCode)
        {
            var builder = new StringBuilder();
            builder.Append(
                "SELECT  TOP 1 Guid,Title,Description,Content FROM ShopNum1_CategoryInfo where AssociatedCategoryGuid like  '" +
                CategoryCode + "%'");
            builder.Append("AND IsAudit = 1 ");
            builder.Append("AND SUBSTRING(ValidTime,0,CHARINDEX('/',ValidTime)) > GETDATE()");
            builder.Append(" ORDER BY ValidTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT TOP " + showCount + " Guid,Title,Description,Content, ValidTime,CreateTime ");
            builder.Append(" FROM ShopNum1_CategoryInfo ");
            builder.Append(" where AssociatedCategoryGuid like  '" + CategoryCode + "%'");
            builder.Append("AND IsAudit = 1 ");
            builder.Append("AND SUBSTRING(ValidTime,0,CHARINDEX('/',ValidTime)) > GETDATE()");
            builder.Append(" ORDER BY ShopNum1_CategoryInfo.CreateTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchByType(string code, string showCount)
        {
            var paraName = new[] {"@code", "@showCount"};
            var paraValue = new[] {code, showCount};
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryInfoByType", paraName, paraValue);
        }

        public DataTable SearchCategoryInfo(string memloginid, string isaudit)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@isaudit";
            paraValue[1] = isaudit;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCategoryInfo", paraName, paraValue);
        }

        public int Update(ShopNum1_CategoryInfo shopNum1_CategoryInfo)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_CategoryInfo");
            builder.Append(" SET ");
            builder.Append("Title = '" + Operator.FilterString(shopNum1_CategoryInfo.Title) + "',");
            builder.Append("Type = '" + Operator.FilterString(shopNum1_CategoryInfo.Type) + "',");
            builder.Append("Content = '" + Operator.FilterString(shopNum1_CategoryInfo.Content) + "',");
            builder.Append("Keywords = '" + Operator.FilterString(shopNum1_CategoryInfo.Keywords) + "',");
            builder.Append("ValidTime = '" + Operator.FilterString(shopNum1_CategoryInfo.ValidTime) + "',");
            builder.Append("Tel = '" + Operator.FilterString(shopNum1_CategoryInfo.Tel) + "',");
            builder.Append("Email = '" + Operator.FilterString(shopNum1_CategoryInfo.Email) + "',");
            builder.Append("OtherContactWay = '" + Operator.FilterString(shopNum1_CategoryInfo.OtherContactWay) + "',");
            builder.Append("AssociatedCategoryGuid = '" + shopNum1_CategoryInfo.AssociatedCategoryGuid + "'");
            builder.Append(" WHERE ");
            builder.Append(" Guid = '" + shopNum1_CategoryInfo.Guid + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Update(string guids, string state)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_CategoryInfo");
            builder.Append(" SET ");
            builder.Append("IsAudit = " + state);
            builder.Append(" WHERE ");
            builder.Append("[Guid] in (" + guids + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdateCategoryInfo(ShopNum1_CategoryInfo categoryInfo)
        {
            var paraName = new string[10];
            var paraValue = new string[10];
            paraName[0] = "@guid";
            paraName[1] = "@title";
            paraName[2] = "@type";
            paraName[3] = "@content";
            paraName[4] = "@keywords";
            paraName[5] = "@validTime";
            paraName[6] = "@tel";
            paraName[7] = "@email";
            paraName[8] = "@otherContactWay";
            paraName[9] = "@associatedCategoryGuid";
            paraValue[0] = categoryInfo.Guid.ToString();
            paraValue[1] = categoryInfo.Title;
            paraValue[2] = categoryInfo.Type;
            paraValue[3] = categoryInfo.Content;
            paraValue[4] = categoryInfo.Keywords;
            paraValue[5] = categoryInfo.ValidTime;
            paraValue[6] = categoryInfo.Tel;
            paraValue[7] = categoryInfo.Email;
            paraValue[8] = categoryInfo.OtherContactWay;
            paraValue[9] = categoryInfo.AssociatedCategoryGuid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateCategoryInfo", paraName, paraValue);
        }

        public int Update(string guids)
        {
            var builder = new StringBuilder();
            builder.Append(" SELECT AssociatedMemberID ");
            builder.Append("FROM  ShopNum1_CategoryInfo");
            builder.Append(" WHERE ");
            builder.Append("[Guid] = '" + guids + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}
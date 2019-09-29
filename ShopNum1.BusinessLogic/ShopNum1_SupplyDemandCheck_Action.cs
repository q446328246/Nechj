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
    public class ShopNum1_SupplyDemandCheck_Action : IShopNum1_SupplyDemandCheck_Action
    {
        private static DataTable dt;

        public static DataTable SupplyDemandCategoryTable
        {
            get
            {
                if (dt == null)
                {
                    string strSql =
                        "SELECT ID,[Name],[Code],OrderID,FatherID FROM ShopNum1_SupplyDemandCategory WHERE IsDeleted=0 and IsShow=1 ORDER BY OrderID DESC";
                    dt = DatabaseExcetue.ReturnDataTable(strSql);
                }
                return dt;
            }
            set { dt = null; }
        }

        public int AddSupplyDemandComment(ShopNum1_SupplyDemandComment shopNum1_SupplyDemandComment)
        {
            string strProcedureName = "Pro_ShopNum1_SupplyDemandCommentAdd";
            var paraName = new[]
            {
                "@Title", "@Content", "@CreateTime", "@CreateMerber", "@CreateIP", "@SupplyDemandGuid",
                "@AssociateMemberID", "@IsAudit"
            };
            var paraValue = new[]
            {
                shopNum1_SupplyDemandComment.Title, shopNum1_SupplyDemandComment.Content,
                Convert.ToString(shopNum1_SupplyDemandComment.CreateTime), shopNum1_SupplyDemandComment.CreateMerber
                , shopNum1_SupplyDemandComment.CreateIP,
                Convert.ToString(shopNum1_SupplyDemandComment.SupplyDemandGuid),
                Convert.ToString(shopNum1_SupplyDemandComment.AssociateMemberID),
                shopNum1_SupplyDemandComment.IsAudit.ToString()
            };
            return DatabaseExcetue.RunProcedure(strProcedureName, paraName, paraValue);
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            var builder = new StringBuilder();
            builder.Append("DELETE ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_SupplyDemand ");
            builder.Append("WHERE ");
            builder.Append("[ID] IN ");
            builder.Append("(@guids) ");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public DataTable GetSupplyDemandCommentList(string guid)
        {
            string strProcedureName = "Pro_ShopNum1_SupplyDemandCommentList";
            return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, "@guid", guid);
        }

        public DataTable GetSupplyDemandDetail(string guid)
        {
            string strProcedureName = "[Pro_ShopNum1_GetSupplyDemandDetail]";
            return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, "@Guid", guid);
        }

        public DataTable GetSupplyDemandDetailOnAndNext(string guid, string onSupplyDemandName,
            string nextSupplyDemandName)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@onSupplyDemandName";
            parms[1].Value = onSupplyDemandName;
            parms[2].ParameterName = "@nextSupplyDemandName";
            parms[2].Value = nextSupplyDemandName;
            var builder = new StringBuilder();
            builder.Append("DECLARE @ReleaseTime datetime ");
            builder.Append("SELECT @ReleaseTime = ReleaseTime FROM ShopNum1_SupplyDemand ");
            builder.Append("WHERE ID = @guid ");
            builder.Append("SELECT * FROM(");
            builder.Append("SELECT TOP 1 ID,Title,@onSupplyDemandName as [Name] FROM ShopNum1_SupplyDemand ");
            builder.Append("WHERE ReleaseTime < @ReleaseTime ");
            builder.Append("ORDER BY ReleaseTime DESC");
            builder.Append(") as a ");
            builder.Append("UNION ");
            builder.Append("SELECT * FROM(");
            builder.Append("SELECT TOP 1 ID,Title,@nextSupplyDemandName as [Name] FROM ShopNum1_SupplyDemand ");
            builder.Append("WHERE ReleaseTime > @ReleaseTime ");
            builder.Append("ORDER BY ReleaseTime ASC ");
            builder.Append(") as b");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetSupplyDemandNewList(string showcount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@showcount";
            paraValue[0] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandNewList", paraName,
                paraValue);
        }

        public DataTable GetSupplyDemandNewList(string guid, string showCount, string tradeType)
        {
            string strProcedureName = "Pro_ShopNum1_GetSupplyDemandList";
            var paraName = new[] {"@guid", "@showCount", "@tradeType"};
            var paraValue = new[] {guid, showCount, tradeType};
            return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
        }

        public DataTable GetSupplyDemandRecommendList(string showcount, string TradeType)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@showcount";
            paraValue[0] = showcount;
            paraName[1] = "@TradeType";
            paraValue[1] = TradeType;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandRecommendList", paraName,
                paraValue);
        }

        public DataTable GetTitleByCodeRecommend(string code, string cout)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@code";
            parms[0].Value = code;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("top (" + cout + ")  ");
            builder.Append("[Title], ");
            builder.Append("[Guid] ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand ");
            builder.Append(" WHERE AssociatedCategoryGuid like  '@code%' ");
            builder.Append("AND IsRecommend = 1");
            builder.Append("AND IsAudit = 1 ");
            builder.Append("AND SUBSTRING(ValidTime,0,CHARINDEX('/',ValidTime)) > GETDATE()");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable GetTitleByCodeTrade(int TradeType, string code, string cout)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@code";
            parms[0].Value = code;
            parms[1].ParameterName = "@TradeType";
            parms[1].Value = TradeType;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("top (" + cout + ")  ");
            builder.Append("[Title], ");
            builder.Append("[Guid] ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand ");
            builder.Append(" WHERE AssociatedCategoryGuid like  '@code%' ");
            builder.Append("AND TradeType = @TradeType ");
            builder.Append("AND IsAudit = 1 ");
            builder.Append("AND SUBSTRING(ValidTime,0,CHARINDEX('/',ValidTime)) > GETDATE()");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
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
                        "\t[ID]\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_SupplyDemandCategory  WHERE  FatherID =@fatherID AND  IsDeleted =@isDeleted ORDER BY OrderID ASC"
                    }),parms);
        }

        public DataTable Search(string code, string associatedMemberID, string isAudit)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@code";
            parms[0].Value = code;
            parms[1].ParameterName = "@associatedMemberID";
            parms[1].Value = associatedMemberID;
            parms[2].ParameterName = "@isAudit";
            parms[2].Value = isAudit;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.ID,");
            builder.Append("a.Title,");
            builder.Append("a.MemberID,");
            builder.Append("a.CategoryName,");
            builder.Append("a.TradeType,");
            builder.Append("a.Description,");
            builder.Append("a.Keywords,");
            builder.Append("a.ValidTime,");
            builder.Append("a.IsAudit,");
            builder.Append("a.OrderID,");
            builder.Append("b.Name");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand as a,");
            builder.Append("ShopNum1_SupplyDemandCategory as b");
            builder.Append(" WHERE A.CategoryCode=B.Code ");
            if (!string.IsNullOrEmpty(associatedMemberID))
            {
                builder.Append(" AND a.MemberID=@associatedMemberID");
            }
            if (Operator.FormatToEmpty(code) != "-1")
            {
                builder.Append(" AND  a.CategoryCode LIKE '@code%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder.Append(" AND a.IsAudit IN (0,2) ");
                }
                else
                {
                    builder.Append(" AND a.IsAudit =@isAudit" );
                }
            }
            builder.Append(" ORDER BY a.ReleaseTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable Search1(string code, string associatedMemberID, int IsAudit)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@code";
            parms[0].Value = code;
            parms[1].ParameterName = "@associatedMemberID";
            parms[1].Value = associatedMemberID;
            
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.ID,");
            builder.Append("a.Title,");
            builder.Append("a.MemberID,");
            builder.Append("a.CategoryName,");
            builder.Append("a.TradeType,");
            builder.Append("a.Description,");
            builder.Append("a.Keywords,");
            builder.Append("a.ValidTime,");
            builder.Append("a.IsAudit,");
            builder.Append("a.OrderID,");
            builder.Append("b.Name");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand as a,");
            builder.Append("ShopNum1_SupplyDemandCategory as b");
            builder.Append(" WHERE A.CategoryCode=B.Code ");
            if (!string.IsNullOrEmpty(associatedMemberID))
            {
                builder.Append(" AND a.MemberID= @associatedMemberID");
            }
            if (Operator.FormatToEmpty(code) != "-1")
            {
                builder.Append(" AND  a.CategoryCode LIKE '@code%'");
            }
            if (IsAudit == 0)
            {
                builder.Append(" AND a.IsAudit=0");
            }
            else
            {
                builder.Append(" AND a.IsAudit in (0,1,2)");
            }
            builder.Append(" ORDER BY a.ReleaseTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchByCategoryIDFrist(string CategoryCode)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@CategoryCode";
            parms[0].Value = CategoryCode;
           
            var builder = new StringBuilder();
            builder.Append(
                "SELECT  TOP 1 ID,Title,Description,Content,TradeType,Image FROM ShopNum1_SupplyDemand where CategoryCode like  '@CategoryCode%'");
            builder.Append("AND IsAudit = 3 ");
            builder.Append("AND ValidTime >= GETDATE()");
            builder.Append(" ORDER BY ReleaseTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@CategoryCode";
            parms[0].Value = CategoryCode;
           
            var builder = new StringBuilder();
            builder.Append("SELECT TOP " + showCount + " ID,Title,TradeType,Description,Content,Image, ReleaseTime ");
            builder.Append(" FROM ShopNum1_SupplyDemand ");
            builder.Append(" where CategoryCode like  '@CategoryCode%'");
            builder.Append("AND IsAudit = 3  AND ValidTime >= GETDATE()   ");
            builder.Append(" ORDER BY ShopNum1_SupplyDemand.ReleaseTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchByType(string code, string showcount)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@code";
            paraValue[0] = code;
            paraName[1] = "@showcount";
            paraValue[1] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandByType", paraName, paraValue);
        }

        public DataTable SearchList(string codes, string associatedMemberIDs, string titles, string types,
            string startTimes, string endtimes, string isAudits)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.ID,");
            builder.Append("a.Title,");
            builder.Append("a.MemberID,");
            builder.Append("a.TradeType,");
            builder.Append("a.Description,");
            builder.Append("a.Keywords,");
            builder.Append("a.ReleaseTime,");
            builder.Append("a.ValidTime,");
            builder.Append("a.IsAudit,");
            builder.Append("a.OrderID,");
            builder.Append("a.CategoryName,");
            builder.Append("b.Name");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand as a,");
            builder.Append("ShopNum1_SupplyDemandCategory as b");
            builder.Append(" WHERE A.CategoryCode=B.Code ");
            if (Operator.FormatToEmpty(associatedMemberIDs) != "-1")
            {
                builder.Append(" AND a.MemberID= '" + associatedMemberIDs + "'");
            }
            if (Operator.FormatToEmpty(codes) != "-1")
            {
                builder.Append(" AND  a.CategoryCode LIKE '" + codes + "%'");
            }
            if (Operator.FormatToEmpty(titles) != "-1")
            {
                builder.Append(" AND a.Title LIKE '%" + titles + "%'");
            }
            if (Operator.FormatToEmpty(types) != "-1")
            {
                builder.Append(" AND a.TradeType= " + types + " ");
            }
            if (Operator.FormatToEmpty(startTimes) != string.Empty)
            {
                builder.Append(" AND substring(a.ValidTime,0,10) >= '" + Operator.FilterString(startTimes) + "'");
            }
            if (Operator.FormatToEmpty(endtimes) != string.Empty)
            {
                builder.Append(" AND substring(a.ValidTime,0,10) <= '" + Operator.FilterString(endtimes) + "'");
            }
            builder.Append(" AND a.IsAudit =3");
            builder.Append(" ORDER BY a.OrderID DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataSet SearchSupply(string perpagenum, string current_page, string supplyName, string supplyCategoryCode,
            string supplyAddressCode, string ordername, string isreturcount)
        {
            string str = string.Empty;
            if (supplyCategoryCode != "-1")
            {
                str = " AND A.CategoryCode like '" + Operator.FilterString(supplyCategoryCode) + "%'";
            }
            if (!(!(supplyName != "-1") || string.IsNullOrEmpty(supplyName)))
            {
                str = str + " AND A.Title LIKE '%" + Operator.FilterString(supplyName) + "%'";
            }
            if ((supplyAddressCode != "-1") && (supplyAddressCode != "000"))
            {
                str = str + " AND A.AddressCode LIKE  '" + Operator.FilterString(supplyAddressCode) + "%'";
            }
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@perpagenum";
            paraValue[0] = perpagenum;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@ColumnNames";
            paraValue[2] =
                " A.ID,A.Title,A.Content,A.Description,A.Keywords,A.ReleaseTime,A.ValidTime,A.CategoryCode,A.AddressCode,A.AddressValue,A.CategoryName,A.Image,A.MemberID ";
            paraName[3] = "@OrderName";
            paraValue[3] = ordername;
            paraName[4] = "@searchName";
            paraValue[4] = str;
            paraName[5] = "@sDesc";
            paraValue[5] = "";
            paraName[6] = "@isReturCount";
            paraValue[6] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SupplySearchList", paraName, paraValue);
        }

        public int Update(string guids, string state)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@state";
            parms[0].Value = state;
            parms[1].ParameterName = "@guids";
            parms[1].Value = guids;
            SupplyDemandCategoryTable = null;
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_SupplyDemand");
            builder.Append(" SET ");
            builder.Append("IsAudit = @state" );
            builder.Append(" WHERE ");
            builder.Append("[ID] in (@guids)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public int Add(ShopNum1_SupplyDemand SupplyDemand)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_SupplyDemand( Title, Content, TradeType,Description, Keywords, ReleaseTime, ValidTime, OrderID, IsAudit, Image, AddressCode, AddressValue, IsRecommend, Tel, Email, OtherContactWay, ContactName, CategoryCode, CategoryName,  MemberID  ) VALUES (  '"
                , Operator.FilterString(SupplyDemand.Title), "',  '", SupplyDemand.Content, "',  '",
                SupplyDemand.TradeType, "',  '", Operator.FilterString(SupplyDemand.Description), "',  '",
                Operator.FilterString(SupplyDemand.Keywords), "',  '",
                Operator.FilterString(SupplyDemand.ReleaseTime), "',  '",
                Operator.FilterString(SupplyDemand.ValidTime), "',  '", SupplyDemand.OrderID,
                "',  '", SupplyDemand.IsAudit, "',  '", SupplyDemand.Image, "',  '", SupplyDemand.AddressCode,
                "',  '", SupplyDemand.AddressValue, "',  '", Operator.FilterString(SupplyDemand.IsRecommend),
                "',  '", Operator.FilterString(SupplyDemand.Tel), "',  '", Operator.FilterString(SupplyDemand.Email)
                , "',  '", Operator.FilterString(SupplyDemand.OtherContactWay),
                "',  '", Operator.FilterString(SupplyDemand.ContactName), "',  '",
                Operator.FilterString(SupplyDemand.CategoryCode), "',  '", SupplyDemand.CategoryName, "',  '",
                SupplyDemand.MemberID, "' )"
            }));
        }

        public DataTable GetList(string categoryID)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@categoryID";
            parms[0].Value = categoryID;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("[ID],");
            builder.Append("[Name],");
            builder.Append("[code]");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemandCategory ");
            builder.Append(" WHERE fatherID=@categoryID" );
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public string GetMemberID(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("select AssociatedMemberID from  dbo.ShopNum1_SupplyDemand where guid=" + guid);
            return DatabaseExcetue.ReturnString(builder.ToString());
        }

        public DataTable Search(string code, string associatedMemberID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@code";
            parms[0].Value = code;
            parms[1].ParameterName = "@associatedMemberID";
            parms[1].Value = associatedMemberID;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.ID,");
            builder.Append("a.Title,");
            builder.Append("a.MemberID,");
            builder.Append("a.CategoryName,");
            builder.Append("a.TradeType,");
            builder.Append("a.Description,");
            builder.Append("a.Keywords,");
            builder.Append("a.ValidTime,");
            builder.Append("a.IsAudit,");
            builder.Append("a.OrderID,");
            builder.Append("b.Name");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand as a,");
            builder.Append("ShopNum1_SupplyDemandCategory as b");
            builder.Append(" WHERE A.CategoryCode=B.Code ");
            if (!string.IsNullOrEmpty(associatedMemberID))
            {
                builder.Append(" AND a.MemberID= @associatedMemberID");
            }
            if (Operator.FormatToEmpty(code) != "-1")
            {
                builder.Append(" AND  a.CategoryCode LIKE '@code%'");
            }
            builder.Append(" AND a.IsAudit in (0,1,2)");
            builder.Append(" ORDER BY a.ReleaseTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable Search(string code, string associatedMemberID, string MemberID, int TradeType, string Audit)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);
            parms[0].ParameterName = "@code";
            parms[0].Value = code;
            parms[1].ParameterName = "@associatedMemberID";
            parms[1].Value = associatedMemberID;
            parms[2].ParameterName = "@MemberID";
            parms[2].Value = MemberID;
            parms[3].ParameterName = "@TradeType";
            parms[3].Value = TradeType;
            parms[4].ParameterName = "@Audit";
            parms[4].Value = Audit;
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("a.ID,");
            builder.Append("a.Title,");
            builder.Append("a.MemberID,");
            builder.Append("a.CategoryName,");
            builder.Append("a.TradeType,");
            builder.Append("a.Description,");
            builder.Append("a.Keywords,");
            builder.Append("a.ValidTime,");
            builder.Append("a.IsAudit,");
            builder.Append("a.OrderID,");
            builder.Append("b.Name");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand as a,");
            builder.Append("ShopNum1_SupplyDemandCategory as b");
            builder.Append(" WHERE A.CategoryCode=B.Code ");
            if (!string.IsNullOrEmpty(associatedMemberID))
            {
                builder.Append(" AND a.MemberID= @associatedMemberID");
            }
            if (Operator.FormatToEmpty(code) != "-1")
            {
                builder.Append(" AND  a.CategoryCode LIKE '@code%'");
            }
            if (!string.IsNullOrEmpty(MemberID))
            {
                builder.Append(" AND a.MemberID  LIKE   '%@MemberID%'");
            }
            if (TradeType != -1)
            {
                builder.Append(" AND a.TradeType  =  @TradeType");
            }
            if (Audit == "")
            {
                builder.Append(" AND a.IsAudit in (0,1,2)");
            }
            else
            {
                builder.Append(" AND a.IsAudit in (@Audit)");
            }
            builder.Append(" ORDER BY a.ReleaseTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchByID(string ID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            return
                DatabaseExcetue.ReturnDataTable(string.Empty + "     SELECT *  FROM  ShopNum1_SupplyDemand  WHERE  ID=@ID",parms);
        }

        public DataTable Select_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_SupplyDemand";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ReleaseTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int Update(ShopNum1_SupplyDemand SupplyDemand)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_SupplyDemand");
            builder.Append(" SET ");
            builder.Append("Title = '" + Operator.FilterString(SupplyDemand.Title) + "',");
            builder.Append("Content = '" + SupplyDemand.Content + "',");
            builder.Append("TradeType = '" + Operator.FilterString(SupplyDemand.TradeType) + "',");
            builder.Append("Description = '" + Operator.FilterString(SupplyDemand.Description) + "',");
            builder.Append("Keywords = '" + Operator.FilterString(SupplyDemand.Keywords) + "',");
            builder.Append("ValidTime = '" + Operator.FilterString(SupplyDemand.ValidTime) + "',");
            builder.Append("Image = '" + SupplyDemand.Image + "',");
            builder.Append("AddressCode = '" + Operator.FilterString(SupplyDemand.AddressCode) + "',");
            builder.Append("AddressValue = '" + SupplyDemand.AddressValue + "',");
            builder.Append("Tel = '" + Operator.FilterString(SupplyDemand.Tel) + "',");
            builder.Append("Email = '" + Operator.FilterString(SupplyDemand.Email) + "',");
            builder.Append("OtherContactWay = '" + Operator.FilterString(SupplyDemand.OtherContactWay) + "',");
            builder.Append("ContactName = '" + Operator.FilterString(SupplyDemand.ContactName) + "',");
            builder.Append("CategoryCode = '" + SupplyDemand.CategoryCode + "',");
            builder.Append("CategoryName = '" + SupplyDemand.CategoryName + "'");
            builder.Append(" WHERE ");
            builder.Append("[ID] =  '" + SupplyDemand.ID + "'   ");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdateIsAudit(string ID, int IsAudit)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            parms[0].ParameterName = "@IsAudit";
            parms[0].Value = IsAudit;
            object obj2 = string.Empty;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new[]
                    {
                        obj2, "     UPDATE   ShopNum1_SupplyDemand    SET   IsAudit=@IsAudit     WHERE  ID=@ID "
                    }),parms);
        }

        public DataRow UpdateSearch(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("Title,");
            builder.Append("Content,");
            builder.Append("TradeType,");
            builder.Append("Description,");
            builder.Append("ReleaseTime,");
            builder.Append("Image,");
            builder.Append("Keywords,");
            builder.Append("ValidTime,");
            builder.Append("OrderID,");
            builder.Append("China315OrderID,");
            builder.Append("AssociatedCategoryGuid,");
            builder.Append("AssociatedMemberID,");
            builder.Append("IsAudit");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_SupplyDemand");
            builder.Append(" WHERE ");
            builder.Append(" Guid = @guid");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms).Rows[0];
        }
    }
}
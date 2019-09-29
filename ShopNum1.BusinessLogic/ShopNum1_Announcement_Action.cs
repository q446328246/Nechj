using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Announcement_Action : IShopNum1_Announcement_Action
    {
        public int Add(ShopNum1_Announcement announcement)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Announcement( Guid, Title, Remark, Keywords, Description, AnnouncementCategoryID, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                , announcement.Guid, "',  '", Operator.FilterString(announcement.Title), "',  '",
                announcement.Remark, "',  '", announcement.Keywords, "',  '", announcement.Description, "',  ",
                announcement.AnnouncementCategoryID, ",  '", Operator.FilterString(announcement.CreateUser), "', '",
                announcement.CreateTime,
                "',  '", Operator.FilterString(announcement.ModifyUser), "' , '", announcement.ModifyTime, "',  ",
                announcement.IsDeleted, ")"
            }));
        }

        public int Delete(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids.Replace("'", "");
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_Announcement  WHERE Guid IN (@guids) ", parms);
        }

        public DataTable GetAnnoucementDetails(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT Title, Remark, CreateUser, CreateTime FROM ShopNum1_Announcement Where Guid =@guid and IsDeleted = 0", parms);
        }

        public DataTable GetAnnoucementList()
        {
            string strSql = string.Empty;
            strSql = "SELECT Guid , Title ,  Remark   FROM ShopNum1_Announcement  Where IsDeleted= 0";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetAnnoucementMeto(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  Title ,  Keywords,   Description   FROM ShopNum1_Announcement  Where Guid='" +
                    Operator.FilterString(guid) + "'");
        }

        public DataTable GetAnnoucementNew(string showCount)
        {
            return
                DatabaseExcetue.ReturnDataTable(("SELECT top " + showCount +
                                                 "Guid,Title  FROM ShopNum1_Announcement  Where IsDeleted= 0 ORDER BY CreateTime Desc"));
        }

        public DataTable GetAnnouncementOnAndNext(string guid, string onAnnouncementName, string nextAnnouncementName)
        {
            var builder = new StringBuilder();
            builder.Append("DECLARE @modifyTime datetime ");
            builder.Append("SELECT @modifyTime = ModifyTime FROM ShopNum1_Announcement ");
            builder.Append("WHERE Guid = '" + guid + "' ");
            builder.Append("SELECT * FROM(");
            builder.Append("SELECT TOP 1 Guid,Title,'" + onAnnouncementName + "' as [Name] FROM ShopNum1_Announcement ");
            builder.Append("WHERE ModifyTime < @modifyTime ");
            builder.Append("ORDER BY ModifyTime DESC");
            builder.Append(") as a ");
            builder.Append("UNION ");
            builder.Append("SELECT * FROM(");
            builder.Append("SELECT TOP 1 Guid,Title,'" + nextAnnouncementName +
                           "' as [Name] FROM ShopNum1_Announcement ");
            builder.Append("WHERE ModifyTime > @modifyTime ");
            builder.Append("ORDER BY ModifyTime ASC ");
            builder.Append(") as b");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetEditInfo(string guid, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql =
                "SELECT Guid,Title,Description,Keywords, Remark,AnnouncementCategoryID,CreateUser,CreateTime,ModifyUser, ModifyTime,IsDeleted  FROM ShopNum1_Announcement Where 0=0";
            if (guid != string.Empty)
            {
                strSql = strSql + " AND  Guid= @guid ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted=@isDeleted " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable GetShopAnnouncementNew(string showCount, string AnnouncementCategoryID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@AnnouncementCategoryID";
            parms[0].Value = AnnouncementCategoryID;
            
            return
                DatabaseExcetue.ReturnDataTable("select top " + showCount +
                                                "Guid, Title  FROM ShopNum1_Announcement  Where IsDeleted= 0 And AnnouncementCategoryID=@AnnouncementCategoryID",parms);
        }

        public DataTable Search(string title, string creater, string startDate, string endDate, int isDeleted,
            string category)
        {
            string str = string.Empty;
            str =
                "SELECT Guid,Title, Remark,CreateUser,CreateTime,ModifyUser,announcementcategoryid, ModifyTime,IsDeleted  FROM ShopNum1_Announcement Where 0=0";
            if (Operator.FormatToEmpty(title) != null)
            {
                str = str + " AND Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            if (Operator.FormatToEmpty(creater) != null)
            {
                str = str + " AND CreateUser LIKE '%" + Operator.FilterString(creater) + "%'";
            }
            if (Operator.FormatToEmpty(startDate) != string.Empty)
            {
                str = str + " AND CreateTime>='" + Operator.FilterString(startDate) + "' ";
            }
            if (Operator.FormatToEmpty(endDate) != string.Empty)
            {
                str = str + " AND CreateTime<='" + Operator.FilterString(endDate) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND IsDeleted=", isDeleted, " "});
            }
            if (category != "-1")
            {
                str = str + " AND AnnouncementCategoryID=" + category + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC");
        }

        public DataTable SearchTitle(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string str = string.Empty;
            str = "SELECT Guid,Title,IsDeleted,CreateTime FROM ShopNum1_Announcement Where 0=0";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND IsDeleted=@isDeleted "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC",parms);
        }

        public DataTable SearchTitle(int isDeleted, int count)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string str = string.Empty;
            if (count > 0)
            {
                str = "SELECT top " + count;
            }
            else
            {
                str = "SELECT ";
            }
            str = str + " Guid,Title,IsDeleted,CreateTime FROM ShopNum1_Announcement Where 0=0";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND IsDeleted=@isDeleted " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC",parms);
        }

        public int Update(string guid, ShopNum1_Announcement announcement)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_Announcement SET  Title='", Operator.FilterString(announcement.Title),
                "', Remark='", announcement.Remark, "', Keywords='", announcement.Keywords, "', Description='",
                announcement.Description, "', AnnouncementCategoryID=", announcement.AnnouncementCategoryID,
                ", ModifyUser='", Operator.FilterString(announcement.ModifyUser), "', ModifyTime='",
                announcement.ModifyTime, "',  CreateTime='", announcement.CreateTime,
                "'WHERE Guid=", guid
            }));
        }
    }
}
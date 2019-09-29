using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Help_Action : IShopNum1_Help_Action
    {
        public int Add(ShopNum1_Help shopNum1_Help)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_Help( Guid, Title, HelpTypeGuid, Remark, OrderID, CreateUser, CreateTime, ModifyUser, ModifyTime  ) VALUES (  '"
                        , shopNum1_Help.Guid, "',  '", Operator.FilterString(shopNum1_Help.Title), "',  '",
                        shopNum1_Help.HelpTypeGuid, "',  '", Operator.FilterString(shopNum1_Help.Remark), "',  ",
                        shopNum1_Help.OrderID.ToString(), ",  '", shopNum1_Help.CreateUser, "', getdate(),  '",
                        shopNum1_Help.ModifyUser, "' , getdate())"
                    }));
        }

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_Help  WHERE Guid IN (" + guids + ") ");
        }

        public DataTable GetEditInfo(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
           
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT A.Guid, A.Title, A.Remark,A.OrderID,B.Name,A.HelpTypeGuid,B.Name As Type, A.CreateUser,A.CreateTime,A.ModifyUser,A.ModifyTime,A.IsDeleted  FROM ShopNum1_Help A left join ShopNum1_HelpType B on A.HelpTypeGuid=B.Guid Where A.Guid= @guid",parms);
        }

        public DataTable GetHelpMeto(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return DatabaseExcetue.ReturnDataTable("SELECT Title,Remark from ShopNum1_Help where Guid= @guid ",parms);
        }

        public DataTable Search(string helpTypeGuid, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@helpTypeGuid";
            parms[0].Value = helpTypeGuid;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "SELECT  Guid, Title, HelpTypeGuid, OrderID, ModifyTime,  IsDeleted FROM ShopNum1_Help Where 0=0  ";
            if (helpTypeGuid != "-1")
            {
                strSql = strSql + " AND HelpTypeGuid = @helpTypeGuid";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted=@isDeleted " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable Search(string title, string type)
        {
            string str = string.Empty;
            str =
                "SELECT A.Guid, A.Title,B.Name, A.CreateUser,A.CreateTime,A.ModifyUser,A.ModifyTime FROM ShopNum1_Help A left join ShopNum1_HelpType B on A.HelpTypeGuid=B.Guid Where";
            str = str + " A.IsDeleted=0";
            if (Operator.FormatToEmpty(title) != "")
            {
                str = str + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
            }
            if (type != "-1")
            {
                str = str + " AND A.HelpTypeGuid = '" + type + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY A.OrderID DESC");
        }

        public DataTable Search(string helpTypeGuid, int showCount, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@helpTypeGuid";
            parms[0].Value = helpTypeGuid;
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "SELECT  TOP " + showCount +
                     " Guid, Title, HelpTypeGuid, OrderID, ModifyTime,  IsDeleted FROM ShopNum1_Help Where 0=0 ";
            if (helpTypeGuid != "-1")
            {
                strSql = strSql + " AND HelpTypeGuid = @helpTypeGuid";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted=@isDeleted " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataSet Search(string productName, string ordername, string soft, string perpagenum, string current_page,
            string isreturcount)
        {
            string str = string.Empty;
            if (!(!(productName != "-1") || string.IsNullOrEmpty(productName)))
            {
                str = "  A.Title like '%" + Operator.FilterString(productName) + "%' ";
            }
            else
            {
                str = "1=1";
            }
            if (ordername == "-1")
            {
                ordername = "A.Guid ";
            }
            else
            {
                ordername = "A." + ordername;
            }
            if (string.IsNullOrEmpty(soft))
            {
                soft = "desc";
            }
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@perpagenum";
            paraValue[0] = perpagenum;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@columnnames";
            paraValue[2] = " A.Guid,A.Title,A.Remark ";
            paraName[3] = "@ordername";
            paraValue[3] = ordername;
            paraName[4] = "@searchname";
            paraValue[4] = str;
            paraName[5] = "@sdesc";
            paraValue[5] = soft;
            paraName[6] = "@isreturcount";
            paraValue[6] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageHelpLists", paraName, paraValue);
        }

        public DataTable SearchRemark(string guid, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string strSql = string.Empty;
            strSql = "SELECT  Guid, Title, CreateUser, CreateTime, Remark, IsDeleted FROM ShopNum1_Help Where 0=0  ";
            if ((guid != "-1") && (Operator.FormatToEmpty(guid) != string.Empty))
            {
                strSql = strSql + " AND Guid = @guid";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted=@isDeleted" });
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int Update(ShopNum1_Help shopNum1_Help)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Help SET  Title='", Operator.FilterString(shopNum1_Help.Title),
                        "', HelpTypeGuid='", shopNum1_Help.HelpTypeGuid, "', OrderID=",
                        shopNum1_Help.OrderID.ToString(), ", Remark='", Operator.FilterString(shopNum1_Help.Remark),
                        "', ModifyUser='", shopNum1_Help.ModifyUser, "', ModifyTime=getdate() WHERE Guid='",
                        shopNum1_Help.Guid, "'"
                    }));
        }
    }
}
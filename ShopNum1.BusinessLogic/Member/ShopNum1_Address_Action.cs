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
    public class ShopNum1_Address_Action : IShopNum1_Address_Action
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Add(ShopNum1_Address address)
        {
            if (
                (DatabaseExcetue.ReturnDataTable(
                    "SELECT Count(*) FROM ShopNum1_Address WHERE IsDefault=1 AND MemLoginID ='" + address.MemLoginID +
                    "'").Rows.Count > 0) && (address.IsDefault == 1))
            {
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Address SET  IsDefault =", 0, "  WHERE IsDefault =", 1, " AND MemLoginID ='",
                        address.MemLoginID, "'"
                    }));
            }
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Address( \tGuid\t, \tName\t, \tEmail\t, \tAddress\t, \tArea\t, \tAddressCode\t  ,    AddressValue  ,\tPostalcode\t, \tTel\t, \tMobile\t, \tIsDefault\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  ) VALUES (  '"
                , address.Guid, "',  '", Operator.FilterString(address.Name), "',  '",
                Operator.FilterString(address.Email), "',  '", Operator.FilterString(address.Address), "',  '",
                Operator.FilterString(address.Area), "',  '", Operator.FilterString(address.AddressCode), "',  '",
                Operator.FilterString(address.AddressValue), "|',  '", Operator.FilterString(address.Postalcode),
                "',  '", Operator.FilterString(address.Tel), "',  '", Operator.FilterString(address.Mobile), "',  ",
                address.IsDefault, ",  '", address.MemLoginID, "', '", Operator.FilterString(address.CreateUser),
                "', '", Convert.ToDateTime(address.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"), "',  '",
                Operator.FilterString(address.ModifyUser), "' , '",
                Convert.ToDateTime(address.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                "',  ", address.IsDeleted, ")"
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="Guid"></param>
        /// <returns></returns>
        public int ChangeDefaultAddress(string MemLoginID, string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Guid";
            parms[1].Value = Guid.Replace("'", "");
            StringBuilder builder;
            var action = new ShopNum1_Address_Action();
            if (action.SearchDefault(Guid) == "0")
            {
                builder = new StringBuilder();
                builder.Append(" UPDATE ShopNum1_Address SET IsDefault=" + 1 + "");
                builder.Append(" WHERE Guid=@Guid");
                builder.Append(" and  MemLoginID=@MemLoginID");
                DatabaseExcetue.RunNonQuery(builder.ToString(), parms);
                try
                {
                    if (DatabaseExcetue.RunNonQuery(builder.ToString()) > 0)
                    {
                        var builder2 = new StringBuilder();
                        builder2.Append(" UPDATE ShopNum1_Address set IsDefault=0  ");
                        builder2.Append(" WHERE Guid not in (@Guid)");
                        builder2.Append(" and  MemLoginID=@MemLoginID");
                        return DatabaseExcetue.RunNonQuery(builder2.ToString(),parms);
                    }
                    return 0;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            builder = new StringBuilder();
            builder.Append(" UPDATE ShopNum1_Address SET IsDefault='" + 0 + "'");
            builder.Append(" WHERE Guid=@Guid");
            builder.Append(" and  MemLoginID=@MemLoginID");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <returns></returns>
        public int CheckDefaultAddress(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("select IsDefault From ShopNum1_Address WHERE MemLoginID =@MemLoginID AND IsDefault =1 AND IsDeleted =0",parms).Rows.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids.Replace("'", "");
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Address WHERE  Guid IN (@guids)",parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetAreaByCode(string code)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tArea  FROM ShopNum1_Address   WHERE  0=0";
            if (code != string.Empty)
            {
                strSql = strSql + " AND AddressCode='" + Operator.FilterString(code) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetRegionCode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetRegionCode", paraName, paraValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public DataTable Search(string guid)
        {
            string str = string.Empty;
            str =
                "SELECT Guid, Name\t, Email\t, Area\t, Address\t, AddressCode , AddressValue , Postalcode\t, Tel\t, Mobile\t, IsDefault\t, MemLoginID\t, CreateUser\t, CreateTime\t, ModifyUser\t, ModifyTime\t, IsDeleted  FROM ShopNum1_Address ";
            if (guid != string.Empty)
            {
                str = str + " WHERE Guid='" + Operator.FilterString(guid) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + "order by IsDefault desc  ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberLoginID"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public DataTable Search(string memberLoginID, int isDeleted)
        {
            string str = string.Empty;
            str =
                "SELECT \tGuid\t, \tName\t, \tEmail\t, \tAddress\t, \tAddressCode\t,    AddressValue, \tArea\t, \tPostalcode\t, \tTel\t, \tMobile\t, \tIsDefault\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_Address   WHERE  0=0";
            if (memberLoginID != string.Empty)
            {
                str = str + " AND MemLoginID='" + memberLoginID + "'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND IsDeleted=", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by IsDefault desc ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public string SearchDefault(string guid)
        {
            
            return DatabaseExcetue.ReturnString("Select  isdefault from ShopNum1_Address where guid='" + guid + "'");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonModel"></param>
        /// <returns></returns>
        public DataTable SelectAddress_List(CommonPageModel commonModel)
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
            paraValue[3] = commonModel.Tablename;
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Update(ShopNum1_Address address)
        {
            if (
                (DatabaseExcetue.ReturnDataTable(
                    "SELECT Count(*) FROM ShopNum1_Address WHERE IsDefault=1 AND MemLoginID ='" + address.MemLoginID +
                    "'").Rows.Count > 0) && (address.IsDefault == 1))
            {
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Address SET  IsDefault =", 0, "  WHERE IsDefault =", 1, " AND MemLoginID ='",
                        address.MemLoginID, "'"
                    }));
            }
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_Address SET  Name ='", Operator.FilterString(address.Name), "', Email\t='",
                Operator.FilterString(address.Email), "', Address ='", Operator.FilterString(address.Address),
                "', Postalcode ='", Operator.FilterString(address.Postalcode), "', AddressCode='",
                Operator.FilterString(address.AddressCode), "', AddressValue ='",
                Operator.FilterString(address.AddressValue), "', Tel\t= '", Operator.FilterString(address.Tel),
                "', Mobile ='", Operator.FilterString(address.Mobile),
                "', Area ='", Operator.FilterString(address.Area), "', ModifyUser ='",
                Operator.FilterString(address.ModifyUser), "', ModifyTime ='",
                Convert.ToDateTime(address.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss"), "' WHERE Guid ='",
                address.Guid, "' AND MemLoginID ='", address.MemLoginID, "'"
            }));
        }
    }
}
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MMSType_Action : IShopNum1_MMSType_Action
    {
        public int Add(ShopNum1_MMSType mMSType)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MMSType( Guid, TypeName, Description, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                , mMSType.Guid, "',  '", Operator.FilterString(mMSType.TypeName), "',  '",
                Operator.FilterString(mMSType.Description), "',  '", mMSType.CreateUser, "', '", mMSType.CreateTime,
                "',  '", mMSType.ModifyUser, "' , '", mMSType.ModifyTime, "',  ", mMSType.IsDeleted,
                ")"
            }));
        }

        public int Delete(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "Delete from ShopNum1_MMS where TypeName in ( " + guids + " )";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_MMSType WHERE  Guid in ( " + guids + " )";
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
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
                "select Guid,TypeName,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_MMSType where Guid=@guid";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsDeleted=@isDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable Search(string typename, int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@typename";
            parms[0].Value = Operator.FilterString(typename);
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            string str = string.Empty;
            str =
                "select Guid,TypeName,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_MMSType where 0=0";
            if (typename != string.Empty)
            {
                str = str + " AND TypeName Like '%@typename%'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND IsDeleted=@isDeleted"});
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By CreateTime Desc",parms);
        }

        public int Update(string guid, ShopNum1_MMSType mMSType)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_MMSType SET  TypeName='", Operator.FilterString(mMSType.TypeName),
                        "', Description='", Operator.FilterString(mMSType.Description), "', ModifyUser='",
                        mMSType.ModifyUser, "', ModifyTime='", mMSType.ModifyTime, "'WHERE Guid=", guid
                    }));
        }
    }
}
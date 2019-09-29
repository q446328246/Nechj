using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ShopTemplate_Action : IShopNum1_ShopTemplate_Action
    {
        public int Add(ShopNum1_Shop_Template shopNum1_Shop_Template)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Shop_Template( \tName\t, \tPath\t, \tMeto\t, \tMoney\t, \tValidDay\t, \tIsDefault\t, \tIsForbid\t, \tTemplateImg\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted\t  ) VALUES (  '"
                , Operator.FilterString(shopNum1_Shop_Template.Name), "',  '", shopNum1_Shop_Template.Path, "',  '",
                Operator.FilterString(shopNum1_Shop_Template.Meto), "',  '",
                Operator.FilterString(shopNum1_Shop_Template.Money), "',  ",
                Operator.FilterString(shopNum1_Shop_Template.ValidDay), ",  ",
                Operator.FilterString(shopNum1_Shop_Template.IsDefault), ",  ", shopNum1_Shop_Template.IsForbid,
                ", '", shopNum1_Shop_Template.TemplateImg,
                "', '", shopNum1_Shop_Template.CreateUser, "', '", shopNum1_Shop_Template.CreateTime, "',  '",
                shopNum1_Shop_Template.ModifyUser, "' , '", shopNum1_Shop_Template.ModifyTime, "',  ",
                shopNum1_Shop_Template.IsDeleted, " )"
            }));
        }

        public int CheckTemplateName(string name)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@name";
            parms[0].Value = name;
            if (
                DatabaseExcetue.ReturnDataTable(
                    "SELECT COUNT(name) AS CountName FROM ShopNum1_Shop_Template WHERE Name=@name", parms).Rows[0][
                        "CountName"].ToString() == "0")
            {
                return 0;
            }
            return 1;
        }

        public int Delete(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_Template WHERE ID = @guid" ,parms);
        }

        public DataTable Edit(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "select Name,Meto,Money,ValidDay,IsDefault,IsForbid,Path,TemplateImg from ShopNum1_Shop_Template WHERE ID=@guid" ,parms);
        }

        public DataTable GetTemplateByID(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            return
                DatabaseExcetue.ReturnDataTable("SELECT TemplateImg,Name FROM ShopNum1_Shop_Template WHERE ID IN (@string_0)",parms);
        }

        public DataTable GetTemplatePathAndImg(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable("SELECT path,TemplateImg FROM ShopNum1_Shop_Template WHERE ID=@guid ",parms);
        }

        public DataTable GetTemplateType()
        {
            return DatabaseExcetue.ReturnDataTable("SELECT ID,Name,Path FROM ShopNum1_Shop_Template WHERE IsForbid=" + 0);
        }

        public DataTable Search()
        {
            string strSql = string.Empty;
            strSql =
                "SELECT ID,Name,Money,Path,ValidDay,IsDefault,Meto,TemplateImg,IsForbid FROM ShopNum1_Shop_Template";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Updata(ShopNum1_Shop_Template shopNum1_Shop_Template)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_Shop_Template SET  Name='", Operator.FilterString(shopNum1_Shop_Template.Name),
                "', Meto='", Operator.FilterString(shopNum1_Shop_Template.Meto), "', Money='",
                Operator.FilterString(shopNum1_Shop_Template.Money), "', ValidDay=",
                Operator.FilterString(shopNum1_Shop_Template.ValidDay), ", IsDefault=",
                Operator.FilterString(shopNum1_Shop_Template.IsDefault), ", IsForbid=",
                shopNum1_Shop_Template.IsForbid, ", TemplateImg='", shopNum1_Shop_Template.TemplateImg,
                "', ModifyUser='", shopNum1_Shop_Template.ModifyUser,
                "', ModifyTime='", shopNum1_Shop_Template.ModifyTime, "'WHERE ID='", shopNum1_Shop_Template.ID, "'"
            }));
        }

        public bool UpdateIsDefault()
        {
            DataTable table =
                DatabaseExcetue.ReturnDataTable("SELECT ID FROM ShopNum1_Shop_Template WHERE IsDefault=" + 0);
            if (table.Rows.Count > 0)
            {
                string str2 = string.Empty;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    str2 = str2 + ",'" + table.Rows[0]["ID"] + "'";
                }
                return
                    (DatabaseExcetue.RunNonQuery(
                        string.Concat(new object[]
                        {"UPDATE ShopNum1_Shop_Template SET IsDefault=", 1, "WHERE ID=", str2.Substring(1)})) > 0);
            }
            return true;
        }

        public int Delete1(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_Template WHERE ID in (@string_0 )",parms);
        }

        public DataTable GetTemplatePathAndImg1(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            return
                DatabaseExcetue.ReturnDataTable("SELECT path,TemplateImg FROM ShopNum1_Shop_Template WHERE ID in (@string_0)",parms);
        }
    }
}
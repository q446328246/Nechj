using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Menu_Action : IShopNum1_Menu_Action
    {
        public int Add(ShopNum1_Menu shopnum1_menu)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Menu( Guid, Name, Code, OrderID, TypeCode, State, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '"
                , shopnum1_menu.Guid, "',  '", Operator.FilterString(shopnum1_menu.Name), "',  '",
                Operator.FilterString(shopnum1_menu.Code), "',  ", shopnum1_menu.OrderID, ",  '",
                Operator.FilterString(shopnum1_menu.TypeCode), "',  ", shopnum1_menu.State, ",  '",
                shopnum1_menu.CreateUser, "', '", shopnum1_menu.CreateTime,
                "',  '", shopnum1_menu.ModifyUser, "' , '", shopnum1_menu.ModifyTime, "',  ",
                shopnum1_menu.IsDeleted, ")"
            }));
        }

        public int Delete(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            
            DataTable table =
                DatabaseExcetue.ReturnDataTable("select state from ShopNum1_Menu where guid in (@guids)",parms);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["state"].ToString() == "0")
                {
                    return -1;
                }
            }
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_Menu  WHERE Guid IN (@guids) ",parms);
        }

        public DataTable GetEditInfo(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guid;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  Name, Code,OrderID,TypeCode,State,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted FROM ShopNum1_Menu where guid=@guids",parms);
        }

        public DataTable GetMenuInfo()
        {
            string strSql = string.Empty;
            strSql = "select typename as name ,typecode as code from ShopNum1_MenuType ";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string type)
        {
            return
                DatabaseExcetue.ReturnDataTable("select name,code from ShopNum1_Menu where TypeCode='" +
                                                Operator.FilterString(type) + "'");
        }

        public DataTable Search(string name, int state, string typecode)
        {
            string str = string.Empty;
            str =
                "SELECT A.Guid, A.Name, A.Code,A.OrderID,B.TypeName,A.State FROM ShopNum1_Menu A left join ShopNum1_MenuType B on A.TypeCode=B.TypeCode Where 0=0";
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND A.Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if (state != -1)
            {
                object obj2 = str;
                str = string.Concat(new[] {obj2, " AND A.state LIKE '%", state, "%'"});
            }
            if (typecode != "-1")
            {
                str = str + " AND a.TypeCode LIKE '%" + Operator.FilterString(typecode) + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By OrderID Desc");
        }

        public int Update(string guid, ShopNum1_Menu shopnum1_menu)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Menu SET  Name='", Operator.FilterString(shopnum1_menu.Name), "', Code='",
                        Operator.FilterString(shopnum1_menu.Code), "', OrderID=", shopnum1_menu.OrderID,
                        ", Typecode='", Operator.FilterString(shopnum1_menu.TypeCode), "', State=",
                        shopnum1_menu.State, ", ModifyUser='", shopnum1_menu.ModifyUser, "', ModifyTime='",
                        shopnum1_menu.ModifyTime, "'WHERE Guid=", guid
                    }));
        }
    }
}
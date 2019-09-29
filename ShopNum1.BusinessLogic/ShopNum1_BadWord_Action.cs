using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_BadWord_Action : IShopNum1_BadWord_Action
    {
        public int Add(ShopNum1_BadWords shopNum1_BadWord)
        {
            var builder = new StringBuilder();
            builder.Append("insert into ShopNum1_BadWords(");
            builder.Append(" CreateUser,");
            builder.Append(" find,");
            builder.Append(" replacement ");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + shopNum1_BadWord.CreateUser + "',");
            builder.Append("'" + shopNum1_BadWord.find + "',");
            builder.Append("'" + shopNum1_BadWord.replacement + "'");
            builder.Append(")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable CheckIsExists(string find, string replacement)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@find";
            parms[0].Value = find;
            parms[1].ParameterName = "@replacement";
            parms[1].Value = replacement;
            var builder = new StringBuilder();
            builder.Append("SELECT COUNT(*) FROM ShopNum1_BadWords WHERE find=@find AND replacement='@replacement");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public int Delete(string string_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            var builder = new StringBuilder();
            builder.Append("DELETE FROM ShopNum1_BadWords WHERE ID IN(@string_0)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public DataTable Edit(int int_0)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@int_0";
            parms[0].Value = int_0;
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_BadWords WHERE ID=@int_0" );
            return DatabaseExcetue.ReturnDataTable(builder.ToString(),parms);
        }

        public DataTable SearchByName(string name)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT * FROM ShopNum1_BadWords WHERE 0=0");
            if (Operator.FilterString(name) != "")
            {
                builder.Append(" AND find like '%" + name + "%'");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Updata(ShopNum1_BadWords shopNum1_BadWord)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_BadWords set ");
            builder.Append("CreateUser='" + shopNum1_BadWord.CreateUser + "', ");
            builder.Append("find='" + shopNum1_BadWord.find + "', ");
            builder.Append("replacement='" + shopNum1_BadWord.replacement + "' ");
            builder.Append(" where id=" + shopNum1_BadWord.id + " ");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Logistic_Action : IShopNum1_Logistic_Action
    {
        public int Add(ShopNum1_Logistic shopNum1_Logistic)
        {
            var builder = new StringBuilder();
            builder.Append("insert into ShopNum1_Logistics(");
            builder.Append("Name,ValueCode,Description,IsShow");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + shopNum1_Logistic.Name + "',");
            builder.Append("'" + shopNum1_Logistic.ValueCode + "',");
            builder.Append("'" + shopNum1_Logistic.Description + "',");
            builder.Append(" " + shopNum1_Logistic.IsShow + " ");
            builder.Append(")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Delete(string string_0)
        {
            var builder = new StringBuilder();
            builder.Append("delete from ShopNum1_Logistics ");
            builder.Append(" where ID IN(" + string_0 + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public bool Exists(string code)
        {
            var builder = new StringBuilder();
            builder.Append("select count(1) from ShopNum1_Logistics");
            builder.Append(" where ValueCode='" + code + "'");
            if (int.Parse(DatabaseExcetue.ReturnString(builder.ToString())) != 0)
            {
                return false;
            }
            return true;
        }

        public DataTable GetLogistic(int ID)
        {
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(" ID,Name,ValueCode,Description,IsShow ");
            builder.Append(" from ShopNum1_Logistics ");
            if (ID != -1)
            {
                builder.Append(" where ID=" + ID);
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetLogistic(string name)
        {
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(" ID,Name,ValueCode,Description,IsShow ");
            builder.Append(" from ShopNum1_Logistics where 0=0 ");
            if (name != "-1")
            {
                builder.Append(" AND [Name] like '%" + name + "%'");
            }
            builder.Append(" ORDER BY ID DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable Search(int isshow)
        {
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(" Name,ValueCode ");
            builder.Append(" from ShopNum1_Logistics where 0=0 ");
            if (isshow != -1)
            {
                builder.Append(" AND IsShow=" + isshow + " ");
            }
            builder.Append(" ORDER BY ID DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Update(ShopNum1_Logistic shopNum1_Logistic)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_Logistics set ");
            builder.Append("Name='" + shopNum1_Logistic.Name + "',");
            builder.Append("ValueCode='" + shopNum1_Logistic.ValueCode + "',");
            builder.Append("Description='" + shopNum1_Logistic.Description + "',");
            builder.Append("IsShow= " + shopNum1_Logistic.IsShow + " ");
            builder.Append(" where ID=" + shopNum1_Logistic.ID);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Control_Action : IShopNum1_Control_Action
    {
        public int Delete(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            var builder = new StringBuilder();
            builder.Append("DELETE FROM ShopNum1_Control WHERE [Guid] in (@guid)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public DataTable GetControlGuid(string controlKey)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@controlKey";
            parms[0].Value = controlKey;
            return
                DatabaseExcetue.ReturnDataTable("Select Guid from ShopNum1_Control where PageFileName='" +
                                                HttpContext.Current.Request.Path.Substring(
                                                    HttpContext.Current.Request.Path.LastIndexOf('/') + 1) +
                                                "' and ControlKey=@controlKey",parms);
        }

        public DataTable GetEditInfo(string guid)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("PageName,");
            builder.Append("PageFileName,");
            builder.Append("ControlName,");
            builder.Append("ControlFileName,");
            builder.Append("ControlKey,");
            builder.Append("ControlImg,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime,");
            builder.Append("IsShow");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Control");
            builder.Append(" WHERE ");
            builder.Append("Guid = " + guid);
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Insert(ShopNum1_Control shopNum1_Control)
        {
            var builder = new StringBuilder();
            builder.Append("INSERT INTO ShopNum1_Control(");
            builder.Append("Guid,");
            builder.Append("PageName,");
            builder.Append("PageFileName,");
            builder.Append("ControlName,");
            builder.Append("ControlFileName,");
            builder.Append("ControlKey,");
            builder.Append("ControlImg,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime,");
            builder.Append("IsShow)");
            builder.Append(" VALUES(");
            builder.Append("'" + shopNum1_Control.Guid + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_Control.PageName) + "',");
            builder.Append("'" + shopNum1_Control.PageFileName + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_Control.ControlName) + "',");
            builder.Append("'" + shopNum1_Control.ControlFileName + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_Control.ControlKey) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_Control.ControlImg) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_Control.CreateUser) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_Control.CreateTime) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_Control.ModifyUser) + "',");
            builder.Append("'" + Operator.FilterString(shopNum1_Control.ModifyTime) + "',");
            builder.Append(Operator.FilterString(shopNum1_Control.IsShow) ?? "");
            builder.Append(")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable Search(string PageName)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("Guid,");
            builder.Append("PageName,");
            builder.Append("PageFileName,");
            builder.Append("ControlName,");
            builder.Append("ControlFileName,");
            builder.Append("ControlKey,");
            builder.Append("ControlImg,");
            builder.Append("CreateUser,");
            builder.Append("CreateTime,");
            builder.Append("ModifyUser,");
            builder.Append("ModifyTime,");
            builder.Append("IsShow");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Control");
            builder.Append(" WHERE ");
            builder.Append(" PageName like '%" + Operator.FilterString(PageName) + "%'");
            builder.Append(" ORDER BY CreateTime DESC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Update(ShopNum1_Control shopNum1_Control)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_Control");
            builder.Append(" SET ");
            builder.Append("PageName = '" + Operator.FilterString(shopNum1_Control.PageName) + "',");
            builder.Append("PageFileName = '" + shopNum1_Control.PageFileName + "',");
            builder.Append("ControlName = '" + Operator.FilterString(shopNum1_Control.ControlName) + "',");
            builder.Append("ControlFileName = '" + shopNum1_Control.ControlFileName + "',");
            builder.Append("ControlKey = '" + Operator.FilterString(shopNum1_Control.ControlKey) + "',");
            builder.Append("ControlImg = '" + Operator.FilterString(shopNum1_Control.ControlImg) + "',");
            builder.Append("IsShow = '" + shopNum1_Control.IsShow + "',");
            builder.Append("ModifyUser = '" + shopNum1_Control.ModifyUser + "',");
            builder.Append("ModifyTime = '" + Operator.FilterString(shopNum1_Control.ModifyTime) + "'");
            builder.Append(" WHERE ");
            builder.Append("Guid = '" + shopNum1_Control.Guid + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}
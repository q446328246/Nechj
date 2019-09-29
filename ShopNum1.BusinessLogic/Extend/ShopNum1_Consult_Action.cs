using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Consult_Action : IShopNum1_Consult_Action
    {
        public int Add()
        {
            return 0;
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_ProductConsult WHERE ProductGuid IN (@guids)",parms);
        }

        public DataTable Search(string MemLoginID, int IsDelete)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@IsDelete";
            parms[1].Value = IsDelete;
            string strSql = string.Empty;
            strSql =
                "SELECT A.ProductGuid,B.Guid,B.Name,A.MemLoginID,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ProductConsult AS A,ShopNum1_Product AS B   WHERE A.ProductGuid = B.Guid AND A.IsDeleted =@IsDelete";
            if (Operator.FormatToEmpty(MemLoginID) != "0")
            {
                strSql = strSql + " AND A.MemLoginID =@MemLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string guid, int IsDeleted, int IsReply)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT ProductGuid,MemLoginID,SendTime,Content,IPAddress,ReplyUser,ReplyTime,ReplyContent,IsReply,IsDeleted,ConsultPeople  FROM ShopNum1_ProductConsult  WHERE IsDeleted = 0";
            if (Operator.FormatToEmpty(guid) != "0")
            {
                strSql = strSql + " AND ProductGuid = '" + guid + "' ";
            }
            if ((IsReply == 0) || (IsReply == 1))
            {
                strSql = string.Concat(new object[] {strSql, " AND IsReply=", IsReply, " "});
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string ProductName, int IsReply, string ConsultPeople, string SendTime1,
            string SendTime2)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.ProductGuid,A.Guid,B.Name,A.MemLoginID,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ProductConsult AS A,ShopNum1_Product AS B   WHERE A.ProductGuid = B.Guid ";
            if (!string.IsNullOrEmpty(ProductName))
            {
                strSql = strSql + " AND B.Name = '" + ProductName + "'";
            }
            if ((IsReply == 0) || (IsReply == 1))
            {
                strSql = strSql + " AND IsReply=" + IsReply;
            }
            if (Operator.FormatToEmpty(ConsultPeople) != string.Empty)
            {
                strSql = strSql + " AND A.ConsultPeople like '%" + ConsultPeople + "%' ";
            }
            if (!string.IsNullOrEmpty(SendTime1))
            {
                strSql = strSql + " AND A.SendTime>='" + Operator.FilterString(SendTime1) + "' ";
            }
            if (Operator.FormatToEmpty(SendTime2) != string.Empty)
            {
                strSql = strSql + " AND A.SendTime<='" + Operator.FilterString(SendTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchByConsultGuid(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.ProductGuid,B.Guid,B.Name,A.MemLoginID,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ProductConsult AS A,ShopNum1_Product AS B   WHERE A.ProductGuid = B.Guid ";
            if (!string.IsNullOrEmpty(guid))
            {
                strSql = strSql + " AND A.Guid = " + guid;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchByGuid(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT A.ProductGuid,B.Guid,B.Name,A.MemLoginID,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ProductConsult AS A,ShopNum1_Product AS B   WHERE A.ProductGuid = B.Guid ";
            if (!string.IsNullOrEmpty(guid))
            {
                strSql = strSql + " AND A.ProductGuid = " + guid;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }
    }
}
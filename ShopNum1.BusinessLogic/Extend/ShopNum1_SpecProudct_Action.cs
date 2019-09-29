using System.Collections.Generic;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_SpecProudct_Action : IShopNum1_SpecProudct_Action
    {
        public int DeleteSpecProduct(string strPGuID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strPGuID";
            parms[0].Value = strPGuID;
            return DatabaseExcetue.RunNonQuery("Delete from ShopNum1_SpecProudct where ProductGuid=@strPGuID",parms);
        }

        public DataTable dt_SpecProducts(string strPid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strPid";
            parms[0].Value = strPid;
            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM dbo.ShopNum1_SpecProudct where productguid=@strPid",parms);
        }

        public DataTable dt_SpecProducts(string strPid, string strSpecDetail)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strPid";
            parms[0].Value = strPid;
            parms[1].ParameterName = "@strSpecDetail";
            parms[1].Value = strSpecDetail;
            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM dbo.ShopNum1_SpecProudct where productguid=@strPid and specdetail=@strSpecDetail",parms);
        }

        public DataTable dt_SpecProducts(string strPid, string strCtype, string strV)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@strPid";
            parms[0].Value = strPid;
            parms[1].ParameterName = "@strCtype";
            parms[1].Value = strCtype;
            parms[2].ParameterName = "@strV";
            parms[2].Value = strV;
            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM dbo.ShopNum1_SpecProudct where productguid=@strPid And productguid in (select productguid from ShopNum1_SpecProudctDetails where productguid=@strPid And typeid=@strCtype)",parms);
        }

        public DataTable GetSpecificationByProduct(string productGuid, string Detail)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@productguid";
            paraValue[0] = productGuid;
            paraName[1] = "@SpecDetailDetail";
            paraValue[1] = Detail;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecProudctPriceChange", paraName,
                paraValue);
        }

        public int AddListSpecProducts(List<ShopNum1_SpecProudct> SpecProudcts)
        {
            var sqlList = new List<string>();
            if (SpecProudcts != null)
            {
                sqlList.Add("delete from ShopNum1_SpecProudct where productguid='" + SpecProudcts[0].ProductGuid + "'");
                for (int i = 0; i < SpecProudcts.Count; i++)
                {
                    string item = string.Concat(new object[]
                    {
                        "INSERT INTO dbo.ShopNum1_SpecProudct \r\n        ( ProductGuid ,\r\n          SpecDetail ,\r\n          SpecTotalId ,\r\n          GoodsPrice,\r\n          GoodsStock ,\r\n          GoodsNumber ,\r\n          GoodColor,\r\n          TbProp,\r\n          ShopId,\r\n          CreateTime  \r\n        ) Values('"
                        , SpecProudcts[i].ProductGuid, "','", SpecProudcts[i].SpecDetail, "','",
                        SpecProudcts[i].SpecTotalId, "','", SpecProudcts[i].GoodsPrice, "','",
                        SpecProudcts[i].GoodsStock, "','", SpecProudcts[i].GoodsNumber, "','",
                        SpecProudcts[i].GoodColor, "','", SpecProudcts[i].TbProp,
                        "','", SpecProudcts[i].ShopID, "','", SpecProudcts[i].CreateTime, "')"
                    });
                    sqlList.Add(item);
                }
            }
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

        public int UpdateListSpecProducts(List<ShopNum1_SpecProudct> SpecificationProudcts)
        {
            var sqlList = new List<string>();
            if (SpecificationProudcts != null)
            {
                for (int i = 0; i < SpecificationProudcts.Count; i++)
                {
                    string item =
                        string.Format(
                            "update dbo.ShopNum1_SpecProudct set SpecDetail='{0}',SpecTotalId='{1}',\r\nSpecTotalId='{2}',GoodsPrice='{3}',GoodsStock='{4}',GoodsNumber='{5}',GoodColor='{6}' where ProductGuid='{7}'",
                            new object[]
                            {
                                SpecificationProudcts[i].SpecDetail, SpecificationProudcts[i].SpecTotalId,
                                SpecificationProudcts[i].GoodsPrice, SpecificationProudcts[i].GoodsStock,
                                SpecificationProudcts[i].GoodsNumber, SpecificationProudcts[i].GoodColor,
                                SpecificationProudcts[i].ProductGuid
                            });
                    sqlList.Add(item);
                }
            }
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

        public DataTable Get(string productGuid, string Detail)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@productguid";
            paraValue[0] = productGuid;
            paraName[1] = "@SpecDetailDetail";
            paraValue[1] = Detail;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecProudctPriceChange", paraName,
                paraValue);
        }
    }
}
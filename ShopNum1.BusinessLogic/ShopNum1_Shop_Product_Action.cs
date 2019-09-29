using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.ShopInterface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Shop_Product_Action : IShopNum1_Shop_Product_Action
    {
        public DataTable GetProductSalesOfFinventory(string productid, string startdate, string enddate) 
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@id";
            paraValue[0] = productid;
            paraName[1] = "@startdate";
            paraValue[1] = startdate;
            paraName[2] = "@enddate";
            paraValue[2] = enddate;
            string strSql = "select a.Id,a.Name,a.UnitName,a.SaleNumber,a.ModifyTime from ShopNum1_Shop_Product a where CreateUser='C0000001' ";

            if (!string.IsNullOrEmpty(productid))
            {
                strSql += "and a.Id=@id ";
            }
            if (!string.IsNullOrEmpty(startdate))
            {
                strSql += "and a.ModifyTime > @startdate ";

            }
            if (!string.IsNullOrEmpty(enddate))
            {
                strSql += "and a.ModifyTime < @enddate ";
            }


            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);

        }


        public DataTable SelectWeixinShopName(string Gudi)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Gudi";
            parms[0].Value = Gudi;

            return DatabaseExcetue.ReturnDataTable("  SELECT MemLoginID,ShopName FROM [ShopNum1_Shop_Product] where Guid=@Gudi", parms);

        }
    }
}

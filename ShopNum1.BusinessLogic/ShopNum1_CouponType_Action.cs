using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_CouponType_Action : IShopNum1_CouponType_Action
    {
        public DataTable search(int int_0, int isshow)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@int_0";
            parms[0].Value = int_0;
            parms[1].ParameterName = "@isshow";
            parms[1].Value = isshow;
            string str = string.Empty;
            str = "SELECT * FROM ShopNum1_Shop_CouponType WHERE 1=1 ";
            if (int_0 != -1)
            {
                str = str + " and ID=@int_0" ;
            }
            if (isshow != -1)
            {
                str = str + " and IsShow=@isshow" ;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID",parms);
        }
    }
}
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ShopNum1.BusinessLogic
{
    public class Shop_CustomerCategory_Action : IShopNum1_CustomerCategory_Action
    {
        public DataTable GetAll()
        {
            string strSql = string.Empty;
            strSql = "select *   from ShopNum1_Shop_CustomerCategory";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetAllNEC()
        {
            string strSql = string.Empty;
            strSql = "select *   from QLX_NEC_BiLi";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }
    }
}

using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Address_Action : IShop_Address_Action
    {
        /// <summary>
        /// </summary>
        /// <param name="guid">用户名</param>
        /// <param name="isdefault">是否默认</param>
        /// <returns></returns>
        public DataTable GetAddress(string guid, string isdefault)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@isdefault";
            paraValue[1] = isdefault;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetAddress", paraName, paraValue);
        }
    }
}
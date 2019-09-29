using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Category_Action : IShop_Category_Action
    {
        public string TableName { get; set; }

        /// <summary>
        ///     取行政区域
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetRegionCode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetRegionCode", paraName, paraValue);
        }

        /// <summary>
        ///     取下级区域
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetRegionFatherID(string fatherid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@fatherid";
            paraValue[0] = fatherid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetRegionFatherID", paraName, paraValue);
        }

        /// <summary>
        /// </summary>
        /// <param name="memberloiid"></param>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public DataTable GetShopBrand(string memberloiid, string categoryid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memberloiid";
            paraValue[0] = memberloiid;
            paraName[1] = "@categoryid";
            paraValue[1] = categoryid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopBrand", paraName, paraValue);
        }

        /// <summary>
        ///     取店销产品的分类
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetShopCategoryCode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductCategoryCode", paraName,
                paraValue);
        }

        /// <summary>
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetShopCategoryFatherID(string fatherid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@fatherid";
            paraValue[0] = fatherid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopCategoryFatherID", paraName,
                paraValue);
        }
    }
}
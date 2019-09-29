using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_NewsCategory_Action : IShop_NewsCategory_Action
    {
        public int AddNewsCategory(ShopNum1_Shop_NewsCategory shop_NewsCategory)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@name";
            paraValue[0] = shop_NewsCategory.Name;
            paraName[1] = "@keywords";
            paraValue[1] = shop_NewsCategory.Keywords;
            paraName[2] = "@description";
            paraValue[2] = shop_NewsCategory.Description;
            paraName[3] = "@orderid";
            paraValue[3] = shop_NewsCategory.OrderID.ToString();
            paraName[4] = "@isshow";
            paraValue[4] = shop_NewsCategory.IsShow.ToString();
            paraName[5] = "@memloginid";
            paraValue[5] = shop_NewsCategory.MemLoginID;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddNewsCategory", paraName, paraValue);
        }

        public int DeleteNewsCategory(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteNewsCategory", paraName, paraValue);
        }

        public DataTable GetNewsCategory(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNewsCategory", paraName, paraValue);
        }

        public DataTable GetNewsCategoryList(string memloginid, string isshow)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@isshow";
            paraValue[1] = isshow;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNewsCategoryList", paraName, paraValue);
        }

        public int UpdateNewsCategory(ShopNum1_Shop_NewsCategory shop_NewsCategory)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@guid";
            paraValue[0] = shop_NewsCategory.Guid.ToString();
            paraName[1] = "@name";
            paraValue[1] = shop_NewsCategory.Name;
            paraName[2] = "@keywords";
            paraValue[2] = shop_NewsCategory.Keywords;
            paraName[3] = "@description";
            paraValue[3] = shop_NewsCategory.Description;
            paraName[4] = "@orderid";
            paraValue[4] = shop_NewsCategory.OrderID.ToString();
            paraName[5] = "@isshow";
            paraValue[5] = shop_NewsCategory.IsShow.ToString();
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateNewsCategory", paraName, paraValue);
        }

        public DataTable Select_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_NewsCategory";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "OrderID";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }
    }
}
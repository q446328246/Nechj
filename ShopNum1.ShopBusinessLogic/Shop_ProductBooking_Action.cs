using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_ProductBooking_Action : IShop_ProductBooking_Action
    {
        public int AddProductBooking(ShopNum1_Shop_ProductBooking productBooking)
        {
            var paraName = new string[11];
            var paraValue = new string[11];
            paraName[0] = "@name";
            paraValue[0] = productBooking.Name;
            paraName[1] = "@email";
            paraValue[1] = productBooking.Email;
            paraName[2] = "@address";
            paraValue[2] = productBooking.Address;
            paraName[3] = "@postalcode";
            paraValue[3] = productBooking.Postalcode;
            paraName[4] = "@tel";
            paraValue[4] = productBooking.Tel;
            paraName[5] = "@mobile";
            paraValue[5] = productBooking.Mobile;
            paraName[6] = "@senddate";
            paraValue[6] = productBooking.SendDate.ToString();
            paraName[7] = "@rank";
            paraValue[7] = productBooking.Rank;
            paraName[8] = "@isaudit";
            paraValue[8] = productBooking.IsAudit.ToString();
            paraName[9] = "@memloginid";
            paraValue[9] = productBooking.MemLoginID;
            paraName[10] = "@shopid";
            paraValue[10] = productBooking.ShopID;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddProductBooking", paraName, paraValue);
        }

        public int DeleteProductBooking(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteProductBooking", paraName, paraValue);
        }

        public DataTable GetProductBooking(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductBooking", paraName, paraValue);
        }

        public DataTable SelectProductBookingList(string shopid, string name, string isaudit, string productname)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@name";
            paraValue[1] = name;
            paraName[2] = "@isaudit";
            paraValue[2] = isaudit;
            paraName[3] = "@productname";
            paraValue[3] = productname;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SelectProductBookingList", paraName, paraValue);
        }

        public int UpdateProductBooking(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateProductBooking", paraName, paraValue);
        }

        public DataTable SelectProductBook_List(CommonPageModel commonModel)
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
            paraValue[3] = commonModel.Tablename;
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "SendDate";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }
    }
}
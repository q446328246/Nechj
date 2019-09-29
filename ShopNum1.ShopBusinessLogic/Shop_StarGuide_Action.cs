using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_StarGuide_Action : IShop_StarGuide_Action
    {
        public int AddStarGuide(ShopNum1_Shop_StarGuide starGuide)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@name";
            paraValue[0] = starGuide.Name;
            paraName[1] = "@imagepath";
            paraValue[1] = starGuide.ImagePath;
            paraName[2] = "@orderid";
            paraValue[2] = starGuide.OrderID.ToString();
            paraName[3] = "@remark";
            paraValue[3] = starGuide.Remark;
            paraName[4] = "@memloginid";
            paraValue[4] = starGuide.MemLoginID;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddStarGuide", paraName, paraValue);
        }

        public int DeleteStarGuide(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteStarGuide", paraName, paraValue);
        }

        public DataTable GetStarGuide(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetStarGuide", paraName, paraValue);
        }

        public int UpdateStarGuide(ShopNum1_Shop_StarGuide starGuide)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@guid";
            paraValue[0] = starGuide.Guid.ToString();
            paraName[1] = "@name";
            paraValue[1] = starGuide.Name;
            paraName[2] = "@imagepath";
            paraValue[2] = starGuide.ImagePath;
            paraName[3] = "@orderid";
            paraValue[3] = starGuide.OrderID.ToString();
            paraName[4] = "@remark";
            paraValue[4] = starGuide.Remark;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateStarGuide", paraName, paraValue);
        }

        public DataTable GetStarGuideList(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetStarGuideList", paraName, paraValue);
        }
    }
}
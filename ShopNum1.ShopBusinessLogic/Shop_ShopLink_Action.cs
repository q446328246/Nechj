using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_ShopLink_Action : IShop_ShopLink_Action
    {
        public int Add(ShopNum1_Shop_Link shopNum1_Shop_Link)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@guid";
            paraValue[0] = shopNum1_Shop_Link.Guid.ToString();
            paraName[1] = "@shopname";
            paraValue[1] = shopNum1_Shop_Link.ShopName;
            paraName[2] = "@shopurl";
            paraValue[2] = shopNum1_Shop_Link.ShopUrl;
            paraName[3] = "@shopmemloginid";
            paraValue[3] = shopNum1_Shop_Link.ShopMemLoginID;
            paraName[4] = "@memloginid";
            paraValue[4] = shopNum1_Shop_Link.MemLoginID;
            paraName[5] = "@note";
            paraValue[5] = shopNum1_Shop_Link.Note;
            paraName[6] = "@isshow";
            paraValue[6] = shopNum1_Shop_Link.IsShow.ToString();
            paraName[7] = "@createtime";
            paraValue[7] = shopNum1_Shop_Link.CreateTime.ToString();
            return DatabaseExcetue.RunProcedure("Pro_AddShop_ShopLink", paraName, paraValue);
        }

        public DataTable CheckMemLoginID(string memLoginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memLoginID";
            paraValue[0] = memLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckShopMemLoginID", paraName, paraValue);
        }

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("delete from dbo.ShopNum1_Shop_Link where guid in(" + guids + ")");
        }

        public DataTable Edit(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_EditShop_ShopLink", paraName, paraValue);
        }

        public DataTable GetAllShopMemLoginID()
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetAllShopMemLoginID");
        }

        public DataTable Search(string showCount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@showCount";
            paraValue[0] = showCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_SerachShop_ShopLink", paraName, paraValue);
        }

        public DataTable Show(string MemLoginID, string showCount)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@showCount";
            paraValue[0] = showCount;
            paraName[1] = "@memLoginID";
            paraValue[1] = MemLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ShopLinkShow", paraName, paraValue);
        }

        public int Updata(ShopNum1_Shop_Link shopNum1_Shop_Link)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@guid";
            paraValue[0] = shopNum1_Shop_Link.Guid.ToString();
            paraName[1] = "@shopname";
            paraValue[1] = shopNum1_Shop_Link.ShopName;
            paraName[2] = "@shopurl";
            paraValue[2] = shopNum1_Shop_Link.ShopUrl;
            paraName[3] = "@shopmemloginid";
            paraValue[3] = shopNum1_Shop_Link.ShopMemLoginID;
            paraName[4] = "@memloginid";
            paraValue[4] = shopNum1_Shop_Link.MemLoginID;
            paraName[5] = "@note";
            paraValue[5] = shopNum1_Shop_Link.Note;
            paraName[6] = "@isshow";
            paraValue[6] = shopNum1_Shop_Link.IsShow.ToString();
            paraName[7] = "@modifytime";
            paraValue[7] = shopNum1_Shop_Link.ModifyTime.ToString();
            return DatabaseExcetue.RunProcedure("Pro_UpdataShop_ShopLink", paraName, paraValue);
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
            paraValue[2] =
                "*,(select shopurl from shopnum1_shopinfo where memloginid=ShopNum1_Shop_Link.ShopMemLoginID)vshopurl";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_Link";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ModifyTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }
    }
}
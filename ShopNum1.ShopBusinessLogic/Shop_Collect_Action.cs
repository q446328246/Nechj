using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Collect_Action : IShop_Collect_Action
    {
        public int AddProductCollect(string memloginid, string productguid, string shopID, string isAttention,
            string shopPrice, string productName, string sellLoginID, int tr_shop_category_id)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@productguid";
            paraValue[1] = productguid;
            paraName[2] = "@shopID";
            paraValue[2] = shopID;
            paraName[3] = "@isAttention";
            paraValue[3] = isAttention;
            paraName[4] = "@shopPrice";
            paraValue[4] = shopPrice;
            paraName[5] = "@productName";
            paraValue[5] = productName;
            paraName[6] = "@sellLoginID";
            paraValue[6] = sellLoginID;
            paraName[7] = "@shop_category_id";
            paraValue[7] = tr_shop_category_id.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddProductCollect", paraName, paraValue);
        }
        
        public DataTable  SelectBuyNumber(string  guid)
        {


            string strSql = "select Name,BuyNumber,shop_category_id from ShopNum1_Shop_Cart where guid='" + guid + "'";
      return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable MaxNumber(string guid)
        {

            string strSql = " select MaxNumber,RepertoryCount from ShopNum1_Shop_Product as cc left  join  ShopNum1_Shop_ProductPrice as cs on cc.id=cs.productid where guid='" + guid + "'";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int AddShopCollect(string memloginid, string shopid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@shopid";
            paraValue[1] = shopid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddShopCollect", paraName, paraValue);
        }

        public int ProductCollectNum(string guid)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    "UPDATE  ShopNum1_Shop_Product SET  CollectCount=CollectCount+1  WHERE Guid='" + guid + "' ");
        }

        public int ShopCollectNum(string memLoginID)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    "UPDATE  ShopNum1_ShopInfo SET  CollectCount=CollectCount+1  WHERE MemLoginID='" + memLoginID + "' ");
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
            paraValue[2] = " Guid,MemLoginID,ShopID,CollectTime ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_ShopCollect";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CollectTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable Select_ListMemberProductCollect(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                " Guid,ProductName,ProductGuid,ShopPrice,ShopID,MemLoginID,CollectTime,IsAttention,IsDeleted,SellLoginID,shop_category_id ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_MemberProductCollect";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CollectTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
    }
}
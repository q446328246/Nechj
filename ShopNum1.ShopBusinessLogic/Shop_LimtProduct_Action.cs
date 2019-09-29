using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_LimtProduct_Action : IShop_LimtProduct_Action
    {
        public int AddLimitProduct(ShopNum1_Limt_Product shopNum1_Limt_Product)
        {
            string str = "INSERT INTO ShopNum1_Limt_Product(ProductGuid,Lid,Discount,ShopName,MemloginID)";
            object obj2 = str;
            obj2 =
                string.Concat(new[]
                {obj2, "VALUES('", shopNum1_Limt_Product.ProductGuid, "','", shopNum1_Limt_Product.Lid, "',"});
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new[]
                    {
                        obj2, "'", shopNum1_Limt_Product.DisCount, "','", shopNum1_Limt_Product.ShopName, "','",
                        shopNum1_Limt_Product.MemLoginId, "');"
                    }));
        }

        public int DeleteLimitProduct(string strId)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Limt_Product WHERE ID='" + strId + "'");
        }

        public DataTable GetLimtProdcut(string pagesize, string currentpage, string condition, string resultnum,
            string strLid)
        {
            string str =
                "select starttime,guid,name,originalImage,smallimage,shopprice,(select top 1 id from ShopNum1_Limt_Product where ProductGuid=t.guid and state=1)isget,memloginid,ProductState from shopnum1_shop_product as t where issell=1 and issaled=1 and isaudit=1";
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "starttime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public DataTable SelectLimtProdcut(string pagesize, string currentpage, string condition, string resultnum)
        {
            string str =
                "SELECT b.guid,A.id,name,originalImage,smallimage,shopprice,discount,lid,state,A.memloginid FROM ShopNum1_Limt_Product A \r\nINNER JOIN ShopNum1_shop_product B on a.productguid=b.guid WHERE B.starttime<getdate() AND issell=1";
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "id";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpdateDisCount(string strDisCount, string strId)
        {
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Limt_Product SET DISCOUNT='" + strDisCount + "' WHERE Id='" +
                                            strId + "'");
        }

        public int UpdateLimitProductStae(string strId, string strState)
        {
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Limt_Product SET state='" + strState + "' WHERE Id='" +
                                            strId + "'");
        }
    }
}
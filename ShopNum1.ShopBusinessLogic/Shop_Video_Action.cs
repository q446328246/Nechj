using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Video_Action : IShop_Video_Action
    {
        public int AddVideoInfo(ShopNum1_Shop_Video shop_Video)
        {
            var paraName = new string[13];
            var paraValue = new string[13];
            paraName[0] = "@title";
            paraValue[0] = shop_Video.Title;
            paraName[1] = "@imgadd";
            paraValue[1] = shop_Video.ImgAdd;
            paraName[2] = "@videoadd";
            paraValue[2] = shop_Video.VideoAdd;
            paraName[3] = "@categoryguid";
            paraValue[3] = shop_Video.CategoryGuid;
            paraName[4] = "@keywords";
            paraValue[4] = shop_Video.KeyWords;
            paraName[5] = "@content";
            paraValue[5] = shop_Video.Content;
            paraName[6] = "@createuser";
            paraValue[6] = shop_Video.CreateUser;
            paraName[7] = "@orderid";
            paraValue[7] = shop_Video.OrderID.ToString();
            paraName[8] = "@isrecommend";
            paraValue[8] = shop_Video.IsRecommend.ToString();
            paraName[9] = "@shopid";
            paraValue[9] = shop_Video.ShopID;
            paraName[10] = "@description";
            paraValue[10] = shop_Video.Description;
            paraName[11] = "@memLoginID";
            paraValue[11] = shop_Video.MemLoginID;
            paraName[12] = "@BroadcastCount";
            paraValue[12] = shop_Video.BroadcastCount.ToString();
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddVideoInfo", paraName, paraValue);
        }

        public int DeleteVideoInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteVideoInfo", paraName, paraValue);
        }

        public DataTable GetCountVedioByMemLoginID(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCountVedioByMemLoginID", paraName, paraValue);
        }

        public DataTable GetShopVedioDetailMeto(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopVedioDetailMeto", paraName, paraValue);
        }

        public DataTable GetVideoInfo(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetVideoInfo", paraName, paraValue);
        }

        public DataTable GetVideoInfoByGuidAndMemLoginID(string guid, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetVideoInfoByGuidAndMemLoginID", paraName,
                paraValue);
        }

        public DataTable MetaGetVideo(string memloginid, string guid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@guid";
            paraValue[1] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_MetaGetVideo", paraName, paraValue);
        }

        public DataTable SearchVideoList(string shopid, string categoryguid, string showcount, string title,
            string order)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@categoryguid";
            paraValue[1] = categoryguid;
            paraName[2] = "@showcount";
            paraValue[2] = showcount;
            paraName[3] = "@title";
            paraValue[3] = title;
            paraName[4] = "@order";
            paraValue[4] = order;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchVideoList", paraName, paraValue);
        }

        public DataSet SearchVideoListNew(string shopid, string ordertype, string sort, string perpagenum,
            string current_page, string isreturcount)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@ordertype";
            paraValue[1] = ordertype;
            paraName[2] = "@sort";
            paraValue[2] = sort;
            paraName[3] = "@perpagenum";
            paraValue[3] = perpagenum;
            paraName[4] = "@current_page";
            paraValue[4] = current_page;
            paraName[5] = "@isreturcount";
            paraValue[5] = isreturcount;
            paraName[6] = "@columnnames";
            paraValue[6] =
                " A.Guid,A.Title,A.ImgAdd,A.VideoAdd,A.CategoryGuid,A.KeyWords,A.Content,A.IsRecommend,A.ShopID,A.BroadcastCount,B.Name ";
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchVideoListNew", paraName, paraValue);
        }

        public int UpdateVideoInfo(ShopNum1_Shop_Video shop_Video)
        {
            var paraName = new string[12];
            var paraValue = new string[12];
            paraName[0] = "@guid";
            paraValue[0] = shop_Video.Guid.ToString();
            paraName[1] = "@title";
            paraValue[1] = shop_Video.Title;
            paraName[2] = "@imgadd";
            paraValue[2] = shop_Video.ImgAdd;
            paraName[3] = "@videoadd";
            paraValue[3] = shop_Video.VideoAdd;
            paraName[4] = "@categoryguid";
            paraValue[4] = shop_Video.CategoryGuid;
            paraName[5] = "@keywords";
            paraValue[5] = shop_Video.KeyWords;
            paraName[6] = "@content";
            paraValue[6] = shop_Video.Content;
            paraName[7] = "@modifyuser";
            paraValue[7] = shop_Video.ModifyUser;
            paraName[8] = "@orderid";
            paraValue[8] = shop_Video.OrderID.ToString();
            paraName[9] = "@isrecommend";
            paraValue[9] = shop_Video.IsRecommend.ToString();
            paraName[10] = "@shopid";
            paraValue[10] = shop_Video.ShopID;
            paraName[11] = "@description";
            paraValue[11] = shop_Video.Description;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateVideoInfo", paraName, paraValue);
        }

        public int AddBroadcastCount(int BroadcastCount, string guid)
        {
            return
                DatabaseExcetue.RunNonQuery("   UPDATE  ShopNum1_Shop_Video  SET    BroadcastCount=BroadcastCount+" +
                                            BroadcastCount + "  WHERE   Guid ='" + guid + "'   ");
        }

        public string GetMaxOrderID(string MemLoginID)
        {
            DataTable table =
                DatabaseExcetue.ReturnDataTable(
                    "     SELECT MAX(OrderID)  FROM   ShopNum1_Shop_Video  WHERE 1=1   AND    MemLoginID='" + MemLoginID +
                    "'     ");
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (!string.IsNullOrEmpty(table.Rows[0][0].ToString()))
                {
                    return table.Rows[0][0].ToString();
                }
                return "0";
            }
            return "0";
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
            paraValue[3] = "ShopNum1_Shop_Video";
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
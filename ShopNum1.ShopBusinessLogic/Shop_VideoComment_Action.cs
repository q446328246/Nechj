using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_VideoComment_Action : IShop_VideoComment_Action
    {
        public int Add(ShopNum1_Shop_VideoComment videoComment_Action)
        {
            string strSql = string.Empty;
            strSql = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Shop_VideoComment( \tGuid\t, \tTitle\t, \tCommentType\t, \tComment\t, \tCommentTime\t, \tIsDelete\t, \tVideoGuid\t, \tShopID\t, \tMemLoginID\t, \tIPAddress\t, \tIsReply\t, \tIsAudit\t  ) VALUES (  '"
                , videoComment_Action.Guid, "',  '", videoComment_Action.Title, "',   ",
                videoComment_Action.CommentType, ",  '", Operator.FilterString(videoComment_Action.Comment), "',  '"
                , videoComment_Action.CommentTime, "',   0, '", videoComment_Action.VideoGuid, "',  '",
                videoComment_Action.ShopID, "',  '", videoComment_Action.MemLoginID,
                "',  '", videoComment_Action.IPAddress, "',   ", videoComment_Action.IsReply, ",   ",
                videoComment_Action.IsAudit, " )"
            });
            try
            {
                DatabaseExcetue.RunNonQuery(strSql);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_Shop_VideoComment  WHERE Guid IN (" + guids + ") ");
        }

        public DataTable GetVideoCommentList(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable("SELECT * from ShopNum1_Shop_VideoComment where VideoGuid ='" + guid +
                                                "' AND IsAudit = 1 ORDER BY CommentTime DESC");
        }

        public DataTable Search(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable("SELECT * from ShopNum1_Shop_VideoComment where VideoGuid =" + guid +
                                                " ORDER BY CommentTime DESC");
        }

        public DataTable Search(string MemLoginID, string VideoTitle, int IsAudit, string SendTime1, string SendTime2)
        {
            string str = string.Empty;
            str =
                "select A.*,B.Title from ShopNum1_Shop_VideoComment as a Left join  ShopNum1_Shop_Video as b on a.VideoGuid =b.Guid where 1=1 ";
            if (Operator.FormatToEmpty(VideoTitle) != string.Empty)
            {
                str = str + " AND B.Title Like '%" + Operator.FilterString(VideoTitle) + "%'";
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID = '" + MemLoginID + "'";
            }
            if (IsAudit != -1)
            {
                str = str + " AND A.IsAudit =" + IsAudit;
            }
            if (Operator.FormatToEmpty(SendTime1) != string.Empty)
            {
                str = str + " AND A.CommentTime>='" + Operator.FilterString(SendTime1) + "' ";
            }
            if (Operator.FormatToEmpty(SendTime2) != string.Empty)
            {
                str = str + " AND A.CommentTime<='" + Operator.FilterString(SendTime2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY A.CommentTime DESC");
        }

        public DataTable SearchByGuid(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable("SELECT * from ShopNum1_Shop_VideoComment where Guid =" + guid +
                                                " ORDER BY CreateTime DESC");
        }

        public int UpdateAudit(string StrGuids)
        {
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Shop_VideoComment SET IsAudit= 1 WHERE Guid in ('" +
                                            StrGuids + "')");
        }

        public int UpdateAuditNot(string StrGuids)
        {
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Shop_VideoComment SET IsAudit= 0 WHERE Guid in ('" +
                                            StrGuids + "')");
        }

        public DataTable GetTitleByGuid(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable("    SELECT   Title  FROM  ShopNum1_Shop_Video  WHERE  Guid ='" + guid +
                                                "'       ");
        }

        public DataTable GetVideoCommentDetail(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable(((string.Empty + "  SELECT  A.*,B.Title AS VideoTitle ") +
                                                 "  FROM ShopNum1_Shop_VideoComment AS A LEFT JOIN ShopNum1_Shop_Video AS B" +
                                                 "  ON A.VideoGuid=B.Guid") + "  WHERE  A.Guid='" + guid + "'  ");
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
            paraValue[2] = " *  ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_VideoComment";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CommentTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
    }
}
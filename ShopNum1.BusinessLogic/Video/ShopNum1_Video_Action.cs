using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Video_Action : IShopNum1_Video_Action
    {
        public int Add(ShopNum1_Video video)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Video( Guid,Title,ImgAdd,VideoAdd,CategoryID,[Content],Keywords,IsRecommend,OrderID,CreateUser,CreateTime,ModifyUser,KeyWordsSeo,Description,BroadcastCount,ModifyTime ) VALUES ( '"
                , video.Guid, "','", Operator.FilterString(video.Title), "','", Operator.FilterString(video.ImgAdd),
                "','", video.VideoAdd, "','", Operator.FilterString(video.CategoryID), "','",
                Operator.FilterString(video.Content), "','", Operator.FilterString(video.KeyWords), "',",
                video.IsRecommend,
                ",", video.OrderID, ",'", video.CreateUser, "','", video.CreateTime, "','", video.ModifyUser, "','",
                video.KeyWordsSeo, "','", video.Description, "','", video.BroadcastCount, "','", video.ModifyTime,
                "')"
            }));
        }

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("delete  from ShopNum1_Video where Guid in(" + guids + ")");
        }

        public DataTable GetVideoAll(string title, string categoryCode, string publisher, int IsRecommend, string time1,
            string time2, int isDeleted)
        {
            string str = string.Empty;
            str =
                "select A.*,B.Name from ShopNum1_Video as a Left join  ShopNum1_VideoCategory as b on a.CategoryID =b.ID where 1=1 ";
            if (Operator.FormatToEmpty(title) != string.Empty)
            {
                str = str + " AND A.Title Like '%" + Operator.FilterString(title) + "%'";
            }
            if (categoryCode != "-1")
            {
                str = str + " AND A.CategoryID =" + categoryCode;
            }
            if (Operator.FormatToEmpty(publisher) != string.Empty)
            {
                str = str + " AND A.CreateUser='" + Operator.FilterString(publisher) + "' ";
            }
            if (IsRecommend.ToString().Trim() != "-1")
            {
                str = str + " AND A.IsRecommend=" + Operator.FilterString(IsRecommend) + " ";
            }
            if (Operator.FormatToEmpty(time1) != string.Empty)
            {
                str = str + " AND A.CreateTime>='" + Operator.FilterString(time1) + "' ";
            }
            if (Operator.FormatToEmpty(time2) != string.Empty)
            {
                str = str + " AND A.CreateTime<='" + Operator.FilterString(time2) + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY A.OrderID DESC");
        }

        public DataTable GetVideoByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            
            return
                DatabaseExcetue.ReturnDataTable(
                    "select A.*,B.Name from ShopNum1_Video as a Left join  ShopNum1_VideoCategory as b on a.CategoryID =b.ID   where Guid=@guid",parms);
        }

        public DataTable GetVideoDetail(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return DatabaseExcetue.ReturnDataTable("SELECT   *  FROM ShopNum1_Video  where [Guid]=@guid ",parms);
        }

        public DataTable GetVideoHotList(int showcount)
        {
            string str = string.Empty;
            if (showcount > 0)
            {
                str = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
            }
            else
            {
                str = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY BroadcastCount DESC");
        }

        public DataTable GetVideoList(int showcount, string isrecommend)
        {
            string str = string.Empty;
            if (showcount > 0)
            {
                str = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
            }
            else
            {
                str = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
            }
            if (isrecommend != "-1")
            {
                str = str + " AND IsRecommend=" + isrecommend;
            }
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY CreateTime DESC");
        }

        public DataTable GetVideoRelativelyList(string guid, int showcount)
        {
            string str = string.Empty;
            if (showcount > 0)
            {
                str = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
            }
            else
            {
                str = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
            }
            return
                DatabaseExcetue.ReturnDataTable(((str +
                                                  " AND CategoryID =(SELECT CategoryID FROM ShopNum1_Video WHERE Guid='" +
                                                  guid + "')") + " AND  Guid not in('" + guid + "')") +
                                                "  ORDER BY BroadcastCount DESC");
        }

        public DataTable SearchVideoList(string resultnum, string pagesize, string currentpage, string strType,
            string strCategory)
        {
            string str = string.Empty;
            string str2 = "ModifyTime";
            string str3 = "desc";
            string str4 = strType;
            if (str4 != null)
            {
                if (!(str4 == "0"))
                {
                    if (str4 == "2")
                    {
                        str2 = "BroadcastCount";
                        str3 = "Desc";
                    }
                }
                else
                {
                    str = " And isRecommend = 1";
                }
            }
            if (strCategory != "")
            {
                str = str + " And CategoryID='" + strCategory + "'";
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "Title,GuId,ImgAdd,BroadcastCount,CategoryID";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Video";
            paraName[4] = "@condition";
            paraValue[4] = str;
            paraName[5] = "@ordercolumn";
            paraValue[5] = str2;
            paraName[6] = "@sortvalue";
            paraValue[6] = str3;
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpDateVideo(string guid, ShopNum1_Video video)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_Video SET Title='", Operator.FilterString(video.Title), "',ImgAdd='",
                Operator.FilterString(video.ImgAdd), "',VideoAdd='", video.VideoAdd, "',CategoryID='",
                video.CategoryID, "',Keywords='", Operator.FilterString(video.KeyWords), "',Content='",
                Operator.FilterString(video.Content), "',IsRecommend=", video.IsRecommend, ",OrderID=",
                video.OrderID,
                ",KeyWordsSeo='", video.KeyWordsSeo, "',Description='", video.Description, "',ModifyUser='",
                video.ModifyUser, "',ModifyTime='", video.ModifyTime, "' where Guid=", guid
            }));
        }

        public int AddVideoCout(string keyname, string videoguid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@keyname";
            parms[0].Value = keyname;
            parms[1].ParameterName = "@videoguid";
            parms[1].Value = videoguid;
            return
                DatabaseExcetue.RunNonQuery(("update dbo.ShopNum1_Video set @keyname=@keyname+1 where guid=@videoguid"),parms);
        }

        public int GetVideoComment(string VideoGuid)
        {
            try
            {
                DataTable table =
                    DatabaseExcetue.ReturnDataTable("    SELECT COUNT(Guid)  FROM ShopNum1_VideoComment       " +
                                                    "   WHERE VideoGuid='" + VideoGuid + "'    AND   IsAudit=1    ");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    if (!string.IsNullOrEmpty(table.Rows[0][0].ToString()))
                    {
                        return Convert.ToInt32(table.Rows[0][0].ToString());
                    }
                    return 0;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public DataTable GetVideoList(int showcount, string isrecommend, int CategoryID)
        {
            string str = string.Empty;
            if (showcount > 0)
            {
                str = "SELECT top " + showcount + "  *  FROM ShopNum1_Video  where 1=1 ";
            }
            else
            {
                str = "SELECT * FROM ShopNum1_Video  WHERE 1=1 ";
            }
            if (isrecommend != "-1")
            {
                str = str + " AND IsRecommend=" + isrecommend;
            }
            if (CategoryID != -1)
            {
                str = str + " AND  CategoryID=" + CategoryID;
            }
            return DatabaseExcetue.ReturnDataTable(str + "  ORDER BY CreateTime DESC");
        }
    }
}
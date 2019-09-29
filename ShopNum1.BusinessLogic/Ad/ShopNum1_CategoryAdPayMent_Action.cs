using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_CategoryAdPayMent_Action : IShopNum1_CategoryAdPayMent_Action
    {
        public int Add(ShopNum1_CategoryAdPayMent shopNum1_CategoryAdPayMent)
        {
            var builder = new StringBuilder();
            builder.Append("insert into ShopNum1_CategoryAdPayMent(");
            builder.Append(
                "AdvertisementID,CategoryAdID,CategoryType,CategoryCode,CategoryName,TradeID,MemLoginID,BuyTime,StartTime,EndTime,ShowPayMentPrice,PayMentTime,IsPayMent,AdvertisementPic,FailCause,AdvertisementLike,AdvertisementContent,PayMentType,PayMentName,IsAudit,IsEffective");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + shopNum1_CategoryAdPayMent.AdvertisementID + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.CategoryAdID + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.CategoryType + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.CategoryCode + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.CategoryName + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.TradeID + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.MemLoginID + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.BuyTime + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.StartTime + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.EndTime + "',");
            builder.Append(shopNum1_CategoryAdPayMent.ShowPayMentPrice + ",");
            builder.Append("'" + shopNum1_CategoryAdPayMent.PayMentTime + "',");
            builder.Append(shopNum1_CategoryAdPayMent.IsPayMent + ",");
            builder.Append("'" + shopNum1_CategoryAdPayMent.AdvertisementPic + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.FailCause + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.AdvertisementLike + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.AdvertisementContent + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.PayMentType + "',");
            builder.Append("'" + shopNum1_CategoryAdPayMent.PayMentName + "',");
            builder.Append(shopNum1_CategoryAdPayMent.IsAudit + ", ");
            builder.Append(shopNum1_CategoryAdPayMent.IsEffective + " ");
            builder.Append(")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Delete(string string_0)
        {
            var builder = new StringBuilder();
            builder.Append("delete from ShopNum1_CategoryAdPayMent ");
            builder.Append(" where ID IN (" + string_0 + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable GetBuyCategoryAdByMemloginId(string memloginid, string advertisementname, string categorytype,
            string categoryid, string categorycode)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@advertisementname";
            paraValue[1] = advertisementname;
            paraName[2] = "@categorytype";
            paraValue[2] = categorytype;
            paraName[3] = "@categoryid";
            paraValue[3] = categoryid;
            paraName[4] = "@categorycode";
            paraValue[4] = categorycode;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetBuyCategoryAdByMemloginId", paraName,
                paraValue);
        }

        public DataTable GetCategoryAdInfo(string memloginid, string advertisementid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@advertisementid";
            paraValue[1] = advertisementid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCategoryAdInfo", paraName, paraValue);
        }

        public DataTable GetEndTime(string categoryType, string categroyID, string categoryCode)
        {
            return
                DatabaseExcetue.ReturnDataTable("SELECT EndTime FROM ShopNum1_CategoryAdPayMent WHERE CategoryAdID='" +
                                                categroyID + "' AND CategoryType='" + categoryType +
                                                "' AND CategoryCode='" + categoryCode + "' AND IsAudit=1 AND EndTime>'" +
                                                DateTime.Now + "' ORDER BY EndTime DESC");
        }

        public DataTable GetEndTimeByAdID(string AdvertisementID)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT EndTime FROM ShopNum1_CategoryAdPayMent WHERE AdvertisementID=" + AdvertisementID +
                    " AND IsAudit=1 AND EndTime>'" + DateTime.Now + "' ORDER BY EndTime DESC");
        }

        public DataSet PayCategoryAdPrice(string tradeid, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@tradeid";
            paraValue[0] = tradeid;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_PayCategoryAdPrice", paraName, paraValue);
        }

        public DataTable Search(string name)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@name";
            parms[0].Value = name;
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(
                " A.ID,A.IsAudit,A.AdvertisementID,A.CategoryAdID,A.CategoryType,A.CategoryCode,A.CategoryName,A.TradeID,A.MemLoginID,A.BuyTime,A.StartTime,A.EndTime,A.ShowPayMentPrice,A.PayMentTime,A.IsPayMent,A.AdvertisementPic,A.AdvertisementLike,A.AdvertisementContent,A.PayMentType,A.PayMentName,B.AdvertisementName ");
            builder.Append(
                " from ShopNum1_CategoryAdPayMent AS A LEFT JOIN ShopNum1_CategoryAdvertisement AS B ON  A.AdvertisementID=B.ID ");
            builder.Append(" where A.ID=@name");
            return DatabaseExcetue.ReturnDataTable(builder.ToString(), parms);
        }

        public DataTable SearchAdInfo(string categoryid, string categorytype)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@categoryid";
            paraValue[0] = categoryid;
            paraName[1] = "@categorytype";
            paraValue[1] = categorytype;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchAdInfo2", paraName, paraValue);
        }

        public DataTable SearchAdInfo(string categoryid, string categorycode, string categorytype)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@categoryid";
            paraValue[0] = categoryid;
            paraName[1] = "@categorycode";
            paraValue[1] = categorycode;
            paraName[2] = "@categorytype";
            paraValue[2] = categorytype;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchAdInfo", paraName, paraValue);
        }

        public DataTable SearchBuyAdInfo(string isAudit, string categoryid, string categorycode, string categorytype,
            string MemloginID, string isPayMent, string AdvertisementName,
            string IsEffective)
        {
            string str = string.Empty;
            str =
                "SELECT A.*,B.AdvertisementName FROM ShopNum1_CategoryAdPayMent AS A LEFT JOIN ShopNum1_CategoryAdvertisement AS B ON  A.AdvertisementID=B.ID WHERE 0=0";
            if (Operator.FilterString(categoryid) != "-1")
            {
                str = str + " AND A.CategoryAdID='" + categoryid + "' ";
            }
            if (Operator.FilterString(categorycode) != "-1")
            {
                str = str + " AND A.CategoryCode='" + categorycode + "' ";
            }
            if (Operator.FilterString(categorytype) != "-1")
            {
                str = str + " AND A.CategoryType='" + categorytype + "' ";
            }
            if (Operator.FilterString(MemloginID) != "-1")
            {
                str = str + " AND A.MemLoginID='" + MemloginID + "' ";
            }
            if (Operator.FilterString(isPayMent) != "-1")
            {
                str = str + " AND A.IsPayMent=" + isPayMent + " ";
            }
            if (Operator.FilterString(isAudit) != "-1")
            {
                if (Operator.FilterString(isAudit) == "-2")
                {
                    str = str + " AND A.IsAudit IN (0,2) ";
                }
                else
                {
                    str = str + " AND A.IsAudit=" + isAudit + " ";
                }
            }
            if (Operator.FilterString(AdvertisementName) != "-1")
            {
                str = str + " AND B.AdvertisementName LIKE '" + AdvertisementName + "%' ";
            }
            if (Operator.FilterString(IsEffective) != "-1")
            {
                if (Operator.FilterString(IsEffective) == "0")
                {
                    str = str + " AND A.EndTime <= '" + DateTime.Now + "' or IsEffective=0 ";
                }
                else
                {
                    str = str + " AND A.EndTime >= '" + DateTime.Now + "' AND IsEffective=1 ";
                }
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY BuyTime DESC");
        }

        public int Updata(ShopNum1_CategoryAdPayMent shopNum1_CategoryAdPayMent)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_CategoryAdPayMent set ");
            builder.Append("AdvertisementID='" + shopNum1_CategoryAdPayMent.AdvertisementID + "',");
            builder.Append("CategoryAdID='" + shopNum1_CategoryAdPayMent.CategoryAdID + "',");
            builder.Append("CategoryType='" + shopNum1_CategoryAdPayMent.CategoryType + "',");
            builder.Append("CategoryCode='" + shopNum1_CategoryAdPayMent.CategoryCode + "',");
            builder.Append("CategoryName='" + shopNum1_CategoryAdPayMent.CategoryName + "',");
            builder.Append("TradeID='" + shopNum1_CategoryAdPayMent.TradeID + "',");
            builder.Append("MemLoginID='" + shopNum1_CategoryAdPayMent.MemLoginID + "',");
            builder.Append("BuyTime='" + shopNum1_CategoryAdPayMent.BuyTime + "',");
            builder.Append("StartTime='" + shopNum1_CategoryAdPayMent.StartTime + "',");
            builder.Append("EndTime='" + shopNum1_CategoryAdPayMent.EndTime + "',");
            builder.Append("ShowPayMentPrice=" + shopNum1_CategoryAdPayMent.ShowPayMentPrice + ",");
            builder.Append("PayMentTime='" + shopNum1_CategoryAdPayMent.PayMentTime + "',");
            builder.Append("IsPayMent=" + shopNum1_CategoryAdPayMent.IsPayMent + ",");
            builder.Append("AdvertisementPic='" + shopNum1_CategoryAdPayMent.AdvertisementPic + "',");
            builder.Append("FailCause='" + shopNum1_CategoryAdPayMent.FailCause + "',");
            builder.Append("AdvertisementLike='" + shopNum1_CategoryAdPayMent.AdvertisementLike + "',");
            builder.Append("AdvertisementContent='" + shopNum1_CategoryAdPayMent.AdvertisementContent + "',");
            builder.Append("PayMentType='" + shopNum1_CategoryAdPayMent.PayMentType + "',");
            builder.Append("PayMentName='" + shopNum1_CategoryAdPayMent.PayMentName + "',");
            builder.Append("IsAudit=" + shopNum1_CategoryAdPayMent.IsAudit + ",");
            builder.Append("IsEffective=" + shopNum1_CategoryAdPayMent.IsEffective + " ");
            builder.Append(" where ID=" + shopNum1_CategoryAdPayMent.ID);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Updata(string ImageName, string AdvertisementLike, string AdvertisementTitle, string PayMentType,
            string PayMentName, string AdID, string MemloginID)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_CategoryAdPayMent set ");
            builder.Append("AdvertisementPic='" + ImageName + "',");
            builder.Append("AdvertisementLike='" + AdvertisementLike + "',");
            builder.Append("AdvertisementContent='" + AdvertisementTitle + "',");
            builder.Append("PayMentType='" + PayMentType + "',");
            builder.Append("PayMentName='" + PayMentName + "',");
            builder.Append("IsAudit=0 ");
            builder.Append(" where ID=" + AdID + " AND MemLoginID='" + MemloginID + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdataCategoryAdInfo(string memloginid, string adID, string isAudit, string FailCause)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@adID";
            parms[1].Value = adID;
            parms[2].ParameterName = "@isAudit";
            parms[2].Value = isAudit;
            parms[3].ParameterName = "@FailCause";
            parms[3].Value = FailCause;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_CategoryAdPayMent set  IsAudit= @isAudit,  FailCause=@FailCause  WHERE MemLoginID=@memloginid AND ID=@adID",parms);
        }

        public int UpdateIsEffective(string time)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@time";
            paraValue[0] = time;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateIsEffective", paraName, paraValue);
        }
    }
}
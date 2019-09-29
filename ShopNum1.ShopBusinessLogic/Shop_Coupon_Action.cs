using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Coupon_Action : IShop_Coupon_Action
    {
        public int Add(ShopNum1_Shop_Coupon shopNum1_Shop_Coupon)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Shop_Coupon (\tGuid\t,\tCouponName\t,\tShopName\t,\tMemLoginID\t,\tType  \t,\tStartTime\t,\tEndTime \t,\tIsEffective\t,\tImgPath\t,\tContent\t,\tAdressCode\t,\tAdressName\t,\tSaleTitle\t,\tIsAudit\t,\tCreateUser\t,\tCreateTime\t,\tIsDeleted\t,\tIsShow\t,\tIsHot\t,\tIsNew\t,\tIsRecommend\t) VALUES ('"
                , shopNum1_Shop_Coupon.Guid, "', '", shopNum1_Shop_Coupon.CouponName, "' , '",
                shopNum1_Shop_Coupon.ShopName, "' ,'", shopNum1_Shop_Coupon.MemLoginID, "', ",
                shopNum1_Shop_Coupon.Type, " ,'", shopNum1_Shop_Coupon.StartTime, "','",
                shopNum1_Shop_Coupon.EndTime, "', ", shopNum1_Shop_Coupon.IsEffective,
                " , '", shopNum1_Shop_Coupon.ImgPath, "' ,'", shopNum1_Shop_Coupon.Content, "','",
                shopNum1_Shop_Coupon.AdressCode, "','", shopNum1_Shop_Coupon.AdressName, "','",
                shopNum1_Shop_Coupon.SaleTitle, "',", shopNum1_Shop_Coupon.IsAudit, ", '",
                shopNum1_Shop_Coupon.CreateUser, "' , '", shopNum1_Shop_Coupon.CreateTime,
                "' ,", shopNum1_Shop_Coupon.IsDeleted, ",", shopNum1_Shop_Coupon.IsShow, ",",
                shopNum1_Shop_Coupon.IsHot, ",", shopNum1_Shop_Coupon.IsNew, ", ", shopNum1_Shop_Coupon.IsRecommend,
                " )"
            }));
        }

        public int Delete(string ID)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_Coupon WHERE Guid IN (" + ID + ")");
        }

        public DataTable GetCouponInfoById(string guid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT A.SaleTitle,A.CouponName,A.Type,A.StartTime,A.EndTime,A.ImgPath,A.Content,A.MemLoginID,A.AdressCode,A.AdressName,A.IsShow,A.IsHot,A.IsNew,A.IsRecommend,C.Name FROM ShopNum1_Shop_Coupon AS A,ShopNum1_Shop_CouponType AS C WHERE A.Type=C.id AND A.Guid='" +
                    guid + "'");
        }

        public DataTable GetCouponTitleByAdressCode(string adresscode, string showcount)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@adresscode";
            paraValue[0] = adresscode;
            paraName[1] = "@showcount";
            paraValue[1] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByAdressCode", paraName,
                paraValue);
        }

        public DataTable GetCouponTitleByBrowserCount(string showcount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@showcount";
            paraValue[0] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByBrowserCount", paraName,
                paraValue);
        }

        public DataTable SearchCoupon(string name, string type, string isshow, string starttime1, string starttime2,
            string endtime1, string endtime2, string memloginid)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@name";
            paraValue[0] = name;
            paraName[1] = "@type";
            paraValue[1] = type;
            paraName[2] = "@isshow";
            paraValue[2] = isshow;
            paraName[3] = "@starttime1";
            paraValue[3] = starttime1;
            paraName[4] = "@starttime2";
            paraValue[4] = starttime2;
            paraName[5] = "@endtime1";
            paraValue[5] = endtime1;
            paraName[6] = "@endtime2";
            paraValue[6] = endtime2;
            paraName[7] = "@memloginid";
            paraValue[7] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchCoupon", paraName, paraValue);
        }

        public DataSet SearchCouponByCategory(string category, string pagesize, string current_page)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@category";
            paraValue[0] = category;
            paraName[1] = "@pagesize";
            paraValue[1] = pagesize;
            paraName[2] = "@current_page";
            paraValue[2] = current_page;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchCouponByCategory", paraName, paraValue);
        }

        public DataTable SearchCouponByGuid(string guid, string shopid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@shopid";
            paraValue[1] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchCouponByGuid", paraName, paraValue);
        }

        public DataTable SearchCouponByMemloginID(string showcount, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@showcount";
            paraValue[0] = showcount;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchCouponByMemloginID", paraName, paraValue);
        }

        public DataSet SearchCouponByMemloginID(string shopid, string ordertype, string sort, string perpagenum,
            string current_page, string isreturcount)
        {
            string str = string.Empty;
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@columnnames";
            paraValue[0] =
                " CouponName,Guid,ImgPath,BrowserCount,UseCount,DownloadCount,IsEffective,StartTime,MemLoginID,EndTime ";
            paraName[1] = "@searchname";
            paraValue[1] = str;
            paraName[2] = "@ordertype";
            paraValue[2] = ordertype;
            paraName[3] = "@shopid";
            paraValue[3] = shopid;
            paraName[4] = "@sort";
            paraValue[4] = sort;
            paraName[5] = "@perpagenum";
            paraValue[5] = perpagenum;
            paraName[6] = "@current_page";
            paraValue[6] = current_page;
            paraName[7] = "@isreturcount";
            paraValue[7] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchCouponByMemloginIDNew", paraName, paraValue);
        }

        public DataTable SearchCouponByType(string category, string addcode, string ordername, string sDesc,
            string pagesize, string current_page, string isReturCount)
        {
            string str = "";
            if (!(string.IsNullOrEmpty(category) || !(category != "-1")))
            {
                str = " AND A.type=" + category;
            }
            if (!(string.IsNullOrEmpty(addcode) || !(addcode != "-1")))
            {
                str = str + " AND A.AdressCode like '" + addcode + "%' ";
            }
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@perPageNum";
            paraValue[0] = pagesize;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@ColumnNames";
            paraValue[2] = " A.Guid,A.CouponName,A.MemLoginID,A.BrowserCount,A.Type,A.SaleTitle,A.ImgPath,B.shopID ";
            paraName[3] = "@OrderName";
            paraValue[3] = ordername;
            paraName[4] = "@searchName";
            paraValue[4] = str;
            paraName[5] = "@sDesc";
            paraValue[5] = sDesc;
            paraName[6] = "@isReturCount";
            paraValue[6] = isReturCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCouponByType", paraName, paraValue);
        }

        public DataTable SearchCouponInfo(string name, string type, string isshow, string starttime1, string starttime2,
            string endtime1, string endtime2, string shopid, string adresscode)
        {
            var paraName = new string[9];
            var paraValue = new string[9];
            paraName[0] = "@name";
            paraValue[0] = name;
            paraName[1] = "@type";
            paraValue[1] = type;
            paraName[2] = "@isshow";
            paraValue[2] = isshow;
            paraName[3] = "@starttime1";
            paraValue[3] = starttime1;
            paraName[4] = "@starttime2";
            paraValue[4] = starttime2;
            paraName[5] = "@endtime1";
            paraValue[5] = endtime1;
            paraName[6] = "@endtime2";
            paraValue[6] = endtime2;
            paraName[7] = "@shopid";
            try
            {
                if (string.IsNullOrEmpty(shopid))
                {
                    shopid = "-1";
                }
            }
            catch
            {
                shopid = "-1";
            }
            paraValue[7] = shopid;
            paraName[8] = "@adresscode";
            paraValue[8] = adresscode;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCouponInfo", paraName, paraValue);
        }

        public int UpdataDownloadCountByGuid(string guid, string count)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@count";
            paraValue[1] = count;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataDownloadCountByGuid", paraName, paraValue);
        }

        public int UpdateAudit(string field, string value, string guids)
        {
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Shop_Coupon set " + field + "=" + value +
                                            " where guid in (" + guids + ")");
        }

        public int UpdateBrowserCount(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateBrowserCount", paraName, paraValue);
        }

        public int UpdateCoupon(ShopNum1_Shop_Coupon shopNum1_Shop_Coupon)
        {
            var paraName = new string[0x13];
            var paraValue = new string[0x13];
            paraName[0] = "@guid";
            paraValue[0] = shopNum1_Shop_Coupon.Guid.ToString();
            paraName[1] = "@name";
            paraValue[1] = shopNum1_Shop_Coupon.CouponName;
            paraName[2] = "@shopname";
            paraValue[2] = shopNum1_Shop_Coupon.ShopName;
            paraName[3] = "@memloginid";
            paraValue[3] = shopNum1_Shop_Coupon.MemLoginID;
            paraName[4] = "@type";
            paraValue[4] = shopNum1_Shop_Coupon.Type.ToString();
            paraName[5] = "@adresscode";
            paraValue[5] = shopNum1_Shop_Coupon.AdressCode;
            paraName[6] = "@adressname";
            paraValue[6] = shopNum1_Shop_Coupon.AdressName;
            paraName[7] = "@isshow";
            paraValue[7] = shopNum1_Shop_Coupon.IsShow.ToString();
            paraName[8] = "@statrtime";
            paraValue[8] = shopNum1_Shop_Coupon.StartTime.ToString();
            paraName[9] = "@endtime";
            paraValue[9] = shopNum1_Shop_Coupon.EndTime.ToString();
            paraName[10] = "@imagepath";
            paraValue[10] = shopNum1_Shop_Coupon.ImgPath;
            paraName[11] = "@content";
            paraValue[11] = shopNum1_Shop_Coupon.Content;
            paraName[12] = "@isnew";
            paraValue[12] = shopNum1_Shop_Coupon.IsNew.ToString();
            paraName[13] = "@ishot";
            paraValue[13] = shopNum1_Shop_Coupon.IsHot.ToString();
            paraName[14] = "@isrecommend";
            paraValue[14] = shopNum1_Shop_Coupon.IsRecommend.ToString();
            paraName[15] = "@modifyuser";
            paraValue[15] = shopNum1_Shop_Coupon.ModifyUser;
            paraName[0x10] = "@modifytime";
            paraValue[0x10] = shopNum1_Shop_Coupon.ModifyTime.ToString();
            paraName[0x11] = "@isaudit";
            paraValue[0x11] = shopNum1_Shop_Coupon.IsAudit.ToString();
            paraName[0x12] = "@SaleTitle";
            paraValue[0x12] = shopNum1_Shop_Coupon.SaleTitle;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateCoupon", paraName, paraValue);
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
            paraValue[3] = "ShopNum1_Shop_Coupon";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public DataTable Select_List_two(CommonPageModel commonModel)
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
            paraValue[3] = "ShopNum1_Shop_Coupon";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int UpdateCoupon1(ShopNum1_Shop_Coupon shopNum1_Shop_Coupon)
        {
            var paraName = new string[14];
            var paraValue = new string[14];
            paraName[0] = "@guid";
            paraValue[0] = shopNum1_Shop_Coupon.Guid.ToString();
            paraName[1] = "@name";
            paraValue[1] = shopNum1_Shop_Coupon.CouponName;
            paraName[2] = "@shopname";
            paraValue[2] = shopNum1_Shop_Coupon.ShopName;
            paraName[3] = "@type";
            paraValue[3] = shopNum1_Shop_Coupon.Type.ToString();
            paraName[4] = "@adresscode";
            paraValue[4] = shopNum1_Shop_Coupon.AdressCode;
            paraName[5] = "@adressname";
            paraValue[5] = shopNum1_Shop_Coupon.AdressName;
            paraName[6] = "@isshow";
            paraValue[6] = shopNum1_Shop_Coupon.IsShow.ToString();
            paraName[7] = "@statrtime";
            paraValue[7] = shopNum1_Shop_Coupon.StartTime.ToString();
            paraName[8] = "@endtime";
            paraValue[8] = shopNum1_Shop_Coupon.EndTime.ToString();
            paraName[9] = "@imagepath";
            paraValue[9] = shopNum1_Shop_Coupon.ImgPath;
            paraName[10] = "@content";
            paraValue[10] = shopNum1_Shop_Coupon.Content;
            paraName[11] = "@modifyuser";
            paraValue[11] = shopNum1_Shop_Coupon.ModifyUser;
            paraName[12] = "@modifytime";
            paraValue[12] = shopNum1_Shop_Coupon.ModifyTime.ToString();
            paraName[13] = "@SaleTitle";
            paraValue[13] = shopNum1_Shop_Coupon.SaleTitle;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateCoupon1", paraName, paraValue);
        }
    }
}
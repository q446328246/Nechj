using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_ShopInfo_Action : IShop_ShopInfo_Action
    {
        public int AddApplyCateGory(ShopNum1_Shop_ApplyCateGory shopApplyCateGory)
        {
            var paraName = new string[11];
            var paraValue = new string[11];
            paraName[0] = "@guid";
            paraValue[0] = shopApplyCateGory.Guid.ToString();
            paraName[1] = "@shopcategoryname";
            paraValue[1] = shopApplyCateGory.ShopCategoryName;
            paraName[2] = "@newshopcategorycode";
            paraValue[2] = shopApplyCateGory.NewShopCateGoryCode;
            paraName[3] = "@brandname";
            paraValue[3] = shopApplyCateGory.BrandName;
            paraName[4] = "@newbrandguid";
            paraValue[4] = shopApplyCateGory.NewBrandGuid.ToString();
            paraName[5] = "@Remarks";
            paraValue[5] = shopApplyCateGory.Remarks;
            paraName[6] = "@shopid";
            paraValue[6] = shopApplyCateGory.ShopID;
            paraName[7] = "@OldShopCategoryName";
            paraValue[7] = shopApplyCateGory.OldShopCategoryName;
            paraName[8] = "@OldBrandName";
            paraValue[8] = shopApplyCateGory.OldBrandName;
            paraName[9] = "@OldShopCategoryCode";
            paraValue[9] = shopApplyCateGory.OldShopCategoryCode;
            paraName[10] = "@OldBrandGuid";
            paraValue[10] = shopApplyCateGory.OldBrandGuid.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_Shop_ApplyCateGory", paraName, paraValue);
        }

        public int DelApplyCatetoryByGuid(string guid, string memloginId)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@shopid";
            paraValue[1] = memloginId;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DelApplyCatetoryByGuid", paraName, paraValue);
        }

        public DataTable GetApplyCatetoryList(string shopid, string state, string audtitetime1, string audtitetime2)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@state";
            paraValue[1] = state;
            paraName[2] = "@audtitetime1";
            paraValue[2] = audtitetime1;
            paraName[3] = "@audtitetime2";
            paraValue[3] = audtitetime2;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetApplyCatetoryList", paraName, paraValue);
        }

        public DataTable GetCateGoryNameBycode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCateGoryNameBycode", paraName, paraValue);
        }

        public DataTable GetCatetoryNamebycode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCatetoryNamebycode", paraName, paraValue);
        }

        public DataTable GetMaxCountByShopRank(string shoprank, string file)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shoprank";
            paraValue[0] = shoprank;
            paraName[1] = "@file";
            paraValue[1] = file;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetMaxProductCountByShopRank", paraName,
                paraValue);
        }

        public string GetMemberLoginidByShopid(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetMemberLoginidByShopid", paraName,
                paraValue);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["MemLoginID"].ToString();
            }
            return "";
        }

        public DataTable GetMemInfoByShopID(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemInfoByShopID", paraName, paraValue);
        }

        public DataTable GetMemLoginInfo(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemLoginInfo", paraName, paraValue);
        }

        public DataTable GetMemSimpleByShopID(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemSimpleByShopID", paraName, paraValue);
        }

        public DataTable GetOpenTimeByShopID(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOpenTimeByShopID", paraName, paraValue);
        }

        public DataTable GetShopCategoryInfoByMemLoginID(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopCategoryInfoByMemLoginID", paraName,
                paraValue);
        }

        public DataTable GetShopIDAndOpenTimeByMemLoginID(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopIDAndOpenTimeByMemLoginID", paraName,
                paraValue);
        }

        public DataTable GetShopInfo(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopInfo", paraName, paraValue);
        }

        public DataTable GetShopMetaInfo(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopMetaInfo", paraName, paraValue);
        }

        public DataTable GetShopNameByMemloginID(string memLoginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopNameByMemloginID", paraName, paraValue);
        }

        public DataTable GetShopOpentimeByProductGuid(string ProductGuid)
        {
            var builder = new StringBuilder();
            builder.Append(
                "select B.opentime,B.ShopID,A.FeeTemplateID,A.Post_fee,A.Express_fee,A.Ems_fee from shopnum1_shop_product A,shopnum1_shopinfo B ");
            builder.Append(" where A.memloginid=B.memloginid ");
            builder.Append(" and A.guid='" + ProductGuid + "'");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetShopRank(string memberloginid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select B.Name,A.ShopReputation,A.ShopRank,B.Pic from ShopNum1_ShopInfo AS A,ShopNum1_ShopRank AS B where A.ShopRank=B.Guid AND MemLoginID='" +
                    memberloginid + "'");
        }

        public DataTable GetShopRankByMemLoginID(string MemLoginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = MemLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopRankByMemLoginID", paraName, paraValue);
        }

        public DataTable GetShopRankImage(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopRankImage", paraName, paraValue);
        }

        public DataTable GetShopRankScoreScope()
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopRankImg");
        }

        public DataTable GetShopSimpleByMemID(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopSimpleByMemID", paraName, paraValue);
        }

        public DataTable GetShopUrlByAddressCode(string AddressCode)
        {
            return
                DatabaseExcetue.ReturnDataTable(("select ShopUrl from  ShopNum1_ShopInfo where AddressCode ='" +
                                                 AddressCode + "'"));
        }

        public DataTable GetStarGuide(string shopid, int int_0)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@num";
            paraValue[1] = int_0.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShop_StarGuide", paraName, paraValue);
        }

        public DataSet GetWelcome(string memberloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memberloginid";
            paraValue[0] = memberloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetWelcome", paraName, paraValue);
        }

        public string IsAllowToAddProduct(string memloginid, string rankguid, string type)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@rankguid";
            paraValue[1] = rankguid;
            paraName[2] = "@type";
            paraValue[2] = type;
            return
                DatabaseExcetue.ReturnProcedureString("Pro_Shop_GetAddProductCountByMemLoginID", paraName, paraValue)
                    .ToString();
        }

        public DataTable SearchIsAudit(string shopID, string shopName, string legalPerson, string registrationNum)
        {
            var builder = new StringBuilder();
            builder.Append("select ");
            builder.Append("GUID,ShopID,ShopName,LegalPerson,RegistrationNum,MemLoginID ");
            builder.Append("from ");
            builder.Append("ShopNum1_ShopInfo");
            builder.Append(" where CompanIsAudit=0");
            if (Operator.FormatToEmpty(shopID) != string.Empty)
            {
                builder.Append(" AND shopID LIKE '%" + Operator.FilterString(shopID) + "%'");
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                builder.Append(" AND shopName LIKE '%" + Operator.FilterString(shopName) + "%'");
            }
            if (Operator.FormatToEmpty(legalPerson) != string.Empty)
            {
                builder.Append(" AND legalPerson = '" + Operator.FilterString(legalPerson) + "'");
            }
            if (Operator.FormatToEmpty(registrationNum) != string.Empty)
            {
                builder.Append(" AND registrationNum = '" + Operator.FilterString(registrationNum) + "'");
            }
            builder.Append(" ORDER BY ApplyTime DESC ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int UpdateClickCount(string strShopId)
        {
            return
                DatabaseExcetue.RunNonQuery("Update ShopNum1_ShopInfo set ClickCount=ClickCount+1 where shopid='" +
                                            strShopId + "'");
        }

        public int UpdateCompanAudit(string Guid, string CompanIsAudit, string strCompanAuditFailedReason)
        {
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_ShopInfo set CompanIsAudit=" +
                                            Operator.FilterString(CompanIsAudit) + ",CompanAuditFailedReason='" +
                                            Operator.FilterString(strCompanAuditFailedReason) + "', CompanAuditTime='" +
                                            DateTime.Now + "' where Guid in('" + Guid + "')");
        }

        public int UpdateCompanyIsAudit(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateCompanyIsAudit", paraName, paraValue);
        }

        public int UpdateLoginDate(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateLoginDate", paraName, paraValue);
        }

        public int UpdateLongLat(string Longitude, string Latitude, string MemberLoginID)
        {
            return
                DatabaseExcetue.RunNonQuery("Update ShopNum1_ShopInfo set Longitude='" + Longitude + "' ,Latitude='" +
                                            Latitude + "'  where MemLoginID='" + MemberLoginID + "'");
        }

        public int UpdateShopCategory(string shopcategory, string memloginid, string brandguid, string brandname)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@shopcategory";
            paraValue[0] = shopcategory;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            paraName[2] = "@brandguid";
            paraValue[2] = brandguid;
            paraName[3] = "@brandname";
            paraValue[3] = brandname;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateShopCategory", paraName, paraValue);
        }

        public int UpdateShopInfo(ShopNum1_ShopInfo shopInfo)
        {
            var paraName = new string[15];
            var paraValue = new string[15];
            paraName[0] = "@name";
            paraValue[0] = shopInfo.Name;
            paraName[1] = "@shopname";
            paraValue[1] = shopInfo.ShopName;
            paraName[2] = "@salesrange";
            paraValue[2] = shopInfo.SalesRange;
            paraName[3] = "@tel";
            paraValue[3] = shopInfo.Tel;
            paraName[4] = "@address";
            paraValue[4] = shopInfo.Address;
            paraName[5] = "@addresscode";
            paraValue[5] = shopInfo.AddressCode;
            paraName[6] = "@addressvalue";
            paraValue[6] = shopInfo.AddressValue;
            paraName[7] = "@companyintroduce";
            paraValue[7] = shopInfo.CompanyIntroduce;
            paraName[8] = "@banner";
            paraValue[8] = shopInfo.Banner;
            paraName[9] = "@modifyuser";
            paraValue[9] = shopInfo.ModifyUser;
            paraName[10] = "@modifytime";
            paraValue[10] = shopInfo.ModifyTime.ToString();
            paraName[11] = "@memloginid";
            paraValue[11] = shopInfo.MemLoginID;
            paraName[12] = "@email";
            paraValue[12] = shopInfo.Email;
            paraName[13] = "@phone";
            paraValue[13] = shopInfo.Phone;
            paraName[14] = "@ShopIntroduce";
            paraValue[14] = shopInfo.ShopIntroduce;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateShopInfo", paraName, paraValue);
        }

        public int UploadingCardPic(ShopNum1_ShopInfo shopNum1_ShopInfo)
        {
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_ShopInfo SET RegistrationNum='" +
                                            shopNum1_ShopInfo.RegistrationNum + "',CompanName='" +
                                            shopNum1_ShopInfo.CompanName + "',LegalPerson='" +
                                            shopNum1_ShopInfo.LegalPerson + "',BusinessTerm='" +
                                            shopNum1_ShopInfo.BusinessTerm + "',BusinessScope='" +
                                            shopNum1_ShopInfo.BusinessScope + "',CompanIsAudit=0  WHERE MemLoginID='" +
                                            shopNum1_ShopInfo.MemLoginID + "'");
        }

        public DataTable CheckMemLoginName(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CheckMemLoginID", paraName, paraValue);
        }

        public DataTable GetDataInfoByMemLoginID(string MemLoginID)
        {
            return
                DatabaseExcetue.ReturnDataTable("   SELECT * FROM   ShopNum1_ShopInfo  WHERE  MemLoginID ='" +
                                                MemLoginID + "'  ");
        }

        public DataTable GetMyBuyShop(string MemLoginID, int rows)
        {
            object obj2 = (string.Empty +
                           "   SELECT * FROM (SELECT Guid,ShopName,Phone,AddressValue ,MemLoginID, Banner,  ROW_NUMBER() over(order by ApplyTime) as rows    " +
                           "   FROM (SELECT Guid,ShopName,Phone,AddressValue,ApplyTime ,MemLoginID ,Banner  ") +
                          "   FROM  ShopNum1_ShopInfo WHERE  MemLoginID IN   " +
                          "   (SELECT ShopID FROM  ShopNum1_OrderInfo   ";
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new[]
                    {
                        obj2, "    WHERE MemLoginID='", MemLoginID,
                        "' GROUP  BY ShopID ) ) AS A ) AS  B WHERE B.rows="
                        , rows, "  "
                    }));
        }

        public DataTable GetMyBuyShopProduct(string MemLoginID, string ShopID, int int_0)
        {
            object obj2 = string.Empty;
            string str2 =
                string.Concat(new[]
                {
                    obj2, "   SELECT TOP ", int_0,
                    "  Name,OriginalImage,Guid,c.ShopPrice,MemLoginID    FROM  ShopNum1_Shop_Product  as d left join ShopNum1_Shop_ProductPrice as c on c.productId=d.id"
                }) +
                "   WHERE Guid  ";
            return
                DatabaseExcetue.ReturnDataTable(str2 +
                                                "   IN(SELECT ProductGuid FROM  ShopNum1_OrderProduct WHERE  ShopID='" +
                                                ShopID + "'and MemLoginID='" + MemLoginID + "')  ");
        }

        public string GetShopNameByShopid(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return
                DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopNameByShopid", paraName, paraValue).Rows[0]
                    ["ShopName"].ToString();
        }

        public bool IsClose(string MemLoginID)
        {
            string strSql = string.Empty;
            strSql = "   SELECT IsClose FROM ShopNum1_ShopInfo WHERE MemLoginID='" + MemLoginID + "'  ";
            try
            {
                DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
                return (((table != null) && (table.Rows.Count > 0)) &&
                        (!string.IsNullOrEmpty(table.Rows[0][0].ToString()) &&
                         ((table.Rows[0][0].ToString() != "1") && (table.Rows[0][0].ToString() == "0"))));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int UpdateMemberPwd(string memloginid, string oldpwd, string string_0)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@oldpwd";
            paraValue[1] = oldpwd;
            paraName[2] = "@pwd";
            paraValue[2] = string_0;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMemberPwd", paraName, paraValue);
        }

        public int UpdateShop(ShopNum1_ShopInfo ShopInfo)
        {
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_ShopInfo set   Name='" +
                                            Operator.FilterString(ShopInfo.Name) + "',      Tel='" +
                                            Operator.FilterString(ShopInfo.Tel) + "',      Phone='" +
                                            Operator.FilterString(ShopInfo.Phone) + "',      ShopName='" +
                                            Operator.FilterString(ShopInfo.ShopName) + "',      MainGoods='" +
                                            Operator.FilterString(ShopInfo.MainGoods) + "',      Banner='" +
                                            ShopInfo.Banner + "',      IdentityCard='" +
                                            Operator.FilterString(ShopInfo.IdentityCard) + "',      Address='" +
                                            Operator.FilterString(ShopInfo.Address) + "',      Memo='" +
                                            Operator.FilterString(ShopInfo.Memo) + "',      ShopIntroduce='" +
                                            Operator.FilterString(ShopInfo.ShopIntroduce) + "',      AddressCode='" +
                                            Operator.FilterString(ShopInfo.AddressCode) + "',      AddressValue='" +
                                            Operator.FilterString(ShopInfo.AddressValue) + "',      ModifyTime='" +
                                            Operator.FilterString(ShopInfo.ModifyTime) + "'     where MemLoginID ='" +
                                            ShopInfo.MemLoginID + "'");
        }
    }
}
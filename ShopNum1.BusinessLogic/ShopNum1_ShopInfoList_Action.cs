using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ShopInfoList_Action : IShopNum1_ShopInfoList_Action
    {
        public int Add(ShopNum1_ShopInfo shopNum1_ShopInfo)
        {
            throw new NotImplementedException();
        }

        public int Delete(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string text = string.Empty;
            text = "delete from ShopNum1_ShopInfo  WHERE Guid = @guid";
            return DatabaseExcetue.RunNonQuery(text,parms);
        }

        public DataTable GetEditInfo(string memberLoginId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@memberLoginId";
            parms[0].Value = memberLoginId;
            string text = string.Empty;
            text = "select * from ShopNum1_ShopInfo  WHERE MemLoginID =@memberLoginId";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public DataTable SearchInfoList(string ShopName, string Name, string memberLoginID, string type,
            string addressCode, string Ishot, string IsVisits, string IsRecommend, string IsExpires,
            string IdentityIsAudit, string CompanIsAudit, string shoprank, string shoprepution, string shopensure,
            string IsAudit, string startTime, string endTime)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "select A.*,C.Name as CName,B.Name AS RankName,IsVisits from ShopNum1_ShopInfo AS A inner join ShopNum1_ShopRank AS B on A.ShopRank=B.Guid ");
            if (Operator.FormatToEmpty(ShopName) != string.Empty)
            {
                stringBuilder.Append(" AND A.ShopName like '%" + Operator.FilterString(ShopName) + "%'");
            }
            if (Operator.FormatToEmpty(Name) != string.Empty)
            {
                stringBuilder.Append(" AND A.Name like '%" + Operator.FilterString(Name) + "%'");
            }
            if (Operator.FormatToEmpty(memberLoginID) != string.Empty)
            {
                stringBuilder.Append(" AND A.MemLoginID like '%" + memberLoginID + "%'");
            }
            if (type != "-1")
            {
                stringBuilder.Append(" AND A.ShopCategoryID like '" + type + "%'");
            }
            if (Operator.FormatToEmpty(addressCode) != "-1")
            {
                stringBuilder.Append(" AND A.AddressCode like '" + Operator.FilterString(addressCode) + "%'");
            }
            if (Operator.FormatToEmpty(Ishot) != "-1")
            {
                stringBuilder.Append(" AND A.Ishot = " + Ishot + " ");
            }
            if (Operator.FormatToEmpty(IsVisits) != "-1")
            {
                stringBuilder.Append(" AND A.IsVisits = " + IsVisits + " ");
            }
            if (Operator.FormatToEmpty(IsRecommend) != "-1")
            {
                stringBuilder.Append(" AND A.IsRecommend = " + IsRecommend + " ");
            }
            if (Operator.FormatToEmpty(IsExpires) != "-1")
            {
                stringBuilder.Append(" AND A.IsExpires = " + IsExpires + " ");
            }
            if (Operator.FormatToEmpty(IdentityIsAudit) != "-1")
            {
                stringBuilder.Append(" AND A.IdentityIsAudit = " + IdentityIsAudit + " ");
            }
            if (Operator.FormatToEmpty(CompanIsAudit) != "-1")
            {
                stringBuilder.Append(" AND A.CompanIsAudit = " + CompanIsAudit + " ");
            }
            if (Operator.FormatToEmpty(shoprank) != "-1")
            {
                stringBuilder.Append(" AND A.shoprank like '%" + Operator.FilterString(shoprank) + "%'");
            }
            switch (IsAudit)
            {
                case "-1":
                    stringBuilder.Append(" AND A.IsAudit= 1");
                    break;
                case "0":
                    stringBuilder.Append(" AND A.IsAudit= 0");
                    break;
                case "1":
                    stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 0");
                    break;
                case "2":
                    stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 1 AND A.IsClose = 0");
                    break;
                case "3":
                    stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 1");
                    break;
                case "-2":
                    stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
                    break;
            }
            if (Operator.FormatToEmpty(startTime) != string.Empty)
            {
                stringBuilder.Append(" AND   A.OpenTime >='" + startTime + "'");
            }
            if (Operator.FormatToEmpty(endTime) != string.Empty)
            {
                stringBuilder.Append("  AND A.OpenTime<='" + endTime + "'");
            }
            if (Operator.FormatToEmpty(shoprepution) != "-1")
            {
                stringBuilder.Append(string.Concat(new[]
                {
                    " AND A.ShopReputation BETWEEN ",
                    shoprepution.Split(new[]
                    {
                        '/'
                    })[0],
                    " AND ",
                    shoprepution.Split(new[]
                    {
                        '/'
                    })[1],
                    " "
                }));
            }
            stringBuilder.Append(" left join ShopNum1_ShopCategory AS C ON a.shopcategoryid=c.code  ");
            if (Operator.FormatToEmpty(shopensure) != "-1")
            {
                stringBuilder.Append(
                    " inner join  ShopNum1_Shop_ApplyEnsure AS D on a.MemLoginID=d.MemberLoginID AND d.IsPayMent=1 AND D.EnsureID = '" +
                    Operator.FilterString(shopensure) + "'");
            }
            stringBuilder.Append("  ORDER BY A.ApplyTime DESC  ");
            return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
        }

        public DataTable Search(string ShopName, string Name, string memberLoginID, string type, string addressCode,
            string Ishot, string IsVisits, string IsRecommend, string IsExpires, string IdentityIsAudit,
            string CompanIsAudit, string shoprank, string shoprepution, string shopensure, string IsAudit,
            string startTime, string endTime)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "select A.*,C.Name as CName,IsVisits from ShopNum1_ShopInfo AS A inner join ShopNum1_ShopCategory AS C ON a.shopcategoryid=c.code  ");
            if (Operator.FormatToEmpty(ShopName) != string.Empty)
            {
                stringBuilder.Append(" AND A.ShopName like '%" + Operator.FilterString(ShopName) + "%'");
            }
            if (Operator.FormatToEmpty(Name) != string.Empty)
            {
                stringBuilder.Append(" AND A.Name like '%" + Operator.FilterString(Name) + "%'");
            }
            if (Operator.FormatToEmpty(memberLoginID) != string.Empty)
            {
                stringBuilder.Append(" AND A.MemLoginID like '%" + memberLoginID + "%'");
            }
            if (type != "-1")
            {
                stringBuilder.Append(" AND A.ShopCategoryID like '" + type + "%'");
            }
            if (Operator.FormatToEmpty(addressCode) != "-1")
            {
                stringBuilder.Append(" AND A.AddressCode like '" + Operator.FilterString(addressCode) + "%'");
            }
            if (Operator.FormatToEmpty(Ishot) != "-1")
            {
                stringBuilder.Append(" AND A.Ishot = " + Ishot + " ");
            }
            if (Operator.FormatToEmpty(IsVisits) != "-1")
            {
                stringBuilder.Append(" AND A.IsVisits = " + IsVisits + " ");
            }
            if (Operator.FormatToEmpty(IsRecommend) != "-1")
            {
                stringBuilder.Append(" AND A.IsRecommend = " + IsRecommend + " ");
            }
            if (Operator.FormatToEmpty(IsExpires) != "-1")
            {
                stringBuilder.Append(" AND A.IsExpires = " + IsExpires + " ");
            }
            if (Operator.FormatToEmpty(IdentityIsAudit) != "-1")
            {
                stringBuilder.Append(" AND A.IdentityIsAudit = " + IdentityIsAudit + " ");
            }
            if (Operator.FormatToEmpty(CompanIsAudit) != "-1")
            {
                stringBuilder.Append(" AND A.CompanIsAudit = " + CompanIsAudit + " ");
            }
            if (Operator.FormatToEmpty(shoprank) != "-1")
            {
                stringBuilder.Append(" AND A.shoprank like '%" + Operator.FilterString(shoprank) + "%'");
            }
            switch (IsAudit)
            {
                case "-1":
                    stringBuilder.Append(" AND A.IsAudit= 1");
                    break;
                case "0":
                    stringBuilder.Append(" AND A.IsAudit= 0");
                    break;
                case "1":
                    stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 0");
                    break;
                case "2":
                    stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 1 AND A.IsClose = 0");
                    break;
                case "3":
                    stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 1");
                    break;
                case "-2":
                    stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
                    break;
            }
            if (Operator.FormatToEmpty(startTime) != string.Empty)
            {
                stringBuilder.Append(" AND   A.OpenTime >='" + startTime + "'");
            }
            if (Operator.FormatToEmpty(endTime) != string.Empty)
            {
                stringBuilder.Append("  AND A.OpenTime<='" + endTime + "'");
            }
            if (Operator.FormatToEmpty(shoprepution) != "-1")
            {
                stringBuilder.Append(string.Concat(new[]
                {
                    " AND A.ShopReputation BETWEEN ",
                    shoprepution.Split(new[]
                    {
                        '/'
                    })[0],
                    " AND ",
                    shoprepution.Split(new[]
                    {
                        '/'
                    })[1],
                    " "
                }));
            }
            if (Operator.FormatToEmpty(shopensure) != "-1")
            {
                stringBuilder.Append(
                    " inner join  ShopNum1_Shop_ApplyEnsure AS D on a.MemLoginID=d.MemberLoginID AND d.IsPayMent=1 AND D.EnsureID = '" +
                    Operator.FilterString(shopensure) + "'");
            }
            stringBuilder.Append("  ORDER BY A.ApplyTime DESC  ");
            return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
        }

        public int Update(string guid, ShopNum1_ShopInfo shopNum1_ShopInfo)
        {
            string text = string.Empty;
            text = string.Concat(new object[]
            {
                "UPDATE  ShopNum1_ShopInfo SET  Name  ='",
                Operator.FilterString(shopNum1_ShopInfo.Name),
                "', SalesRange  ='",
                Operator.FilterString(shopNum1_ShopInfo.SalesRange),
                "', Address  ='",
                Operator.FilterString(shopNum1_ShopInfo.Address),
                "', ShopCategoryID  ='",
                shopNum1_ShopInfo.ShopCategoryID,
                "', AddressCode  ='",
                shopNum1_ShopInfo.AddressCode,
                "', ModifyUser  ='",
                shopNum1_ShopInfo.ModifyUser,
                "', ModifyTime  ='",
                shopNum1_ShopInfo.ModifyTime,
                "', IsAudit  ='",
                shopNum1_ShopInfo.IsAudit,
                "'  IsDeleted  ='",
                shopNum1_ShopInfo.IsDeleted,
                "' WHERE Guid=",
                guid
            });
            return DatabaseExcetue.RunNonQuery(text);
        }

        public int Update(string guid, string string_0, string field)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string text = string.Empty;
            text = string.Concat(new[]
            {
                "UPDATE  ShopNum1_ShopInfo SET ",
                field,
                "=",
                string_0,
                " where Guid IN (@guid)"
            });
            return DatabaseExcetue.RunNonQuery(text,parms);
        }

        public DataTable SearchShopClickCount(string shophost, string shopname, string startdate, string enddate)
        {
            var array = new string[4];
            var array2 = new string[4];
            array[0] = "@shophost";
            array2[0] = shophost;
            array[1] = "@shopname";
            array2[1] = shopname;
            array[2] = "@startdate";
            array2[2] = startdate;
            array[3] = "@enddate";
            array2[3] = enddate;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopClickCount", array, array2);
        }

        public DataTable SearchShopAmount(string startdate, string enddate)
        {
            var array = new string[2];
            var array2 = new string[2];
            array[0] = "@startdate";
            array2[0] = startdate;
            array[1] = "@enddate";
            array2[1] = enddate;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopAmount", array, array2);
        }

        public int GetShopIdMax()
        {
            return DatabaseExcetue.ReturnMaxID("ShopId", "ShopNum1_ShopInfo");
        }

        public string GetOpenTime(string memLoginID)
        {
            string text = string.Empty;
            text = "select OpenTime from ShopNum1_ShopInfo  WHERE MemLoginID ='" + memLoginID + "'";
            return DatabaseExcetue.ReturnString(text);
        }

        public string GetMemberType(string memLoginID)
        {
            string text = string.Empty;
            text = "select MemberType from ShopNum1_Member  WHERE MemLoginID ='" + memLoginID + "'";
            return DatabaseExcetue.ReturnString(text);
        }

        public DataTable GetShopInfoByGuid(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string text = string.Empty;
            text = "select ShopID,OpenTime,MemLoginID from ShopNum1_ShopInfo WHERE Guid=@guid" ;
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public DataTable GetShopNameByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            string text = string.Empty;
            text = "select MemLoginID,ShopName from ShopNum1_ShopInfo WHERE Guid=@guid";
            return DatabaseExcetue.ReturnDataTable(text, parms);
        }

        public DataTable GetScore_sv(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string text = string.Empty;
            text = "select Score_sv from ShopNum1_Member WHERE MemLoginID=@MemLoginID";
            return DatabaseExcetue.ReturnDataTable(text, parms);
        }

        public int AddProductByBTC(string MemloginID, string ShopName)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@MemloginID";
            paraValue[0] = MemloginID;
            paraName[1] = "@ShopName";
            paraValue[1] = ShopName;
            return DatabaseExcetue.RunProcedure("pro_AddProductByBTC", paraName, paraValue);
        }

        public int UpdateMemberRankGuid(string MemloginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemloginID";
            paraValue[0] = MemloginID;
            string text = "update [ShopNum1_Member] set MemberRankGuid='49844669-3893-413E-951E-77B2EBE4FE28' where MemLoginID=@MemloginID";
            return DatabaseExcetue.RunNonQuery(text,paraName,paraValue);
        }

        public int UpdateScore_sv(string MemloginID, decimal Score_sv)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@MemloginID";
            paraValue[0] = MemloginID;
            paraName[1] = "@Score_sv";
            paraValue[1] = Score_sv.ToString();
            string text = "update [ShopNum1_Member] set Score_sv=@Score_sv where MemLoginID=@MemloginID";
            return DatabaseExcetue.RunNonQuery(text, paraName, paraValue);
        }

        public int UpdateMemberType(string guids, int memberType)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memberType";
            parm.Value = memberType;
            parms.Add(parm);

            
            string text = string.Empty;
            text = string.Concat(new object[]
            {
                "UPDATE ShopNum1_Member SET MemberType=@memberType WHERE MemLoginID in(select MemLoginID from dbo.ShopNum1_ShopInfo where Guid"+andSql+")"
            });
            return DatabaseExcetue.RunNonQuery(text,parms.ToArray());
        }
        public DataTable SelectMemberloginIDQuantity(string memberloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@memberloginID";
            parms[0].Value = memberloginID;
            return DatabaseExcetue.ReturnDataTable("select MemLoginID from ShopNum1_Member where MemLoginID=@memberloginID", parms);
        }

        public int RegistShopMember(ShopNum1_ShopInfo shopNum1_ShopInfo)
        {
            string text = "Pro_ShopNum1_RegistShopMember";
            var array = new string[43];
            var array2 = new string[43];
            array[0] = "@ShopName";
            array[1] = "@salesRange";
            array[2] = "@addressValue";
            array[3] = "@banner";
            array[4] = "@collectCount";
            array[5] = "@applyTime";
            array[6] = "@openTime";
            array[7] = "@modifyUser";
            array[8] = "@modifyTime";
            array[9] = "@shopCategoryID";
            array[10] = "@memberLoginID";
            array[11] = "@IsAudit";
            array[12] = "@IsDeleted";
            array[13] = "@regionCode";
            array[14] = "@shopID";
            array[15] = "@Name";
            array[16] = "@IdentityCard";
            array[17] = "@DetailAddress";
            array[18] = "@PostalCode";
            array[19] = "@Tel";
            array[20] = "@shopTemplateType";
            array[21] = "@CardImage";
            array[22] = "@shopRank";
            array[23] = "@RegistrationNum";
            array[24] = "@CompanName";
            array[25] = "@LegalPerson";
            array[26] = "@RegisteredCapital";
            array[27] = "@BusinessTerm";
            array[28] = "@BusinessScope";
            array[29] = "@BusinessLicense";
            array[30] = "@OrderID";
            array[31] = "@ShopUrl";
            array[32] = "@IdentityIsAudit";
            array[33] = "@CompanIsAudit";
            array[34] = "@Phone";
            array[35] = "@IsIntegralShop";
            array[36] = "@ShopType";
            array[37] = "@MainGoods";
            array[38] = "@Longitude";
            array[39] = "@Latitude";
            array2[0] = shopNum1_ShopInfo.ShopName;
            array2[1] = shopNum1_ShopInfo.SalesRange;
            array2[2] = shopNum1_ShopInfo.AddressValue;
            array2[3] = shopNum1_ShopInfo.Banner;
            array2[4] = shopNum1_ShopInfo.CollectCount.ToString();
            array2[5] = shopNum1_ShopInfo.ApplyTime.ToString();
            array2[6] = shopNum1_ShopInfo.OpenTime.ToString();
            array2[7] = shopNum1_ShopInfo.ModifyUser;
            array2[8] = shopNum1_ShopInfo.ModifyTime.ToString();
            array2[9] = shopNum1_ShopInfo.ShopCategoryID;
            array2[10] = shopNum1_ShopInfo.MemLoginID;
            array2[11] = shopNum1_ShopInfo.IsAudit.ToString();
            array2[12] = shopNum1_ShopInfo.IsDeleted.ToString();
            array2[13] = shopNum1_ShopInfo.AddressCode;
            array2[14] = shopNum1_ShopInfo.ShopID.ToString();
            array2[15] = shopNum1_ShopInfo.Name;
            array2[16] = shopNum1_ShopInfo.IdentityCard;
            array2[17] = shopNum1_ShopInfo.Address;
            array2[18] = shopNum1_ShopInfo.PostalCode;
            array2[19] = shopNum1_ShopInfo.Tel;
            array2[20] = shopNum1_ShopInfo.TemplateType;
            array2[21] = shopNum1_ShopInfo.CardImage;
            array2[22] = shopNum1_ShopInfo.ShopRank.ToString();
            array2[23] = shopNum1_ShopInfo.RegistrationNum;
            array2[24] = shopNum1_ShopInfo.CompanName;
            array2[25] = shopNum1_ShopInfo.LegalPerson;
            array2[26] = shopNum1_ShopInfo.RegisteredCapital.ToString();
            array2[27] = shopNum1_ShopInfo.BusinessTerm;
            array2[28] = shopNum1_ShopInfo.BusinessScope;
            array2[29] = shopNum1_ShopInfo.BusinessLicense;
            array2[30] = shopNum1_ShopInfo.OrderID.ToString();
            array2[31] = shopNum1_ShopInfo.ShopUrl;
            array2[32] = shopNum1_ShopInfo.IdentityIsAudit.ToString();
            array2[33] = shopNum1_ShopInfo.CompanIsAudit.ToString();
            array2[34] = shopNum1_ShopInfo.Phone;
            array2[35] = shopNum1_ShopInfo.IsIntegralShop.ToString();
            array2[36] = shopNum1_ShopInfo.ShopType.ToString();
            array2[37] = shopNum1_ShopInfo.MainGoods;
            array2[38] = shopNum1_ShopInfo.Longitude;
            array2[39] = shopNum1_ShopInfo.Latitude;
            array[40] = "@TaxRegistration";
            array2[40] = shopNum1_ShopInfo.TaxRegistration;
            array[41] = "@Organization";
            array2[41] = shopNum1_ShopInfo.Organization;
            array[42] = "@Referral";
            array2[42] = shopNum1_ShopInfo.TextBoxReferral;

            return DatabaseExcetue.RunProcedure(text, array, array2);
        }

        public int UpdateShopInfo(ShopNum1_ShopInfo shopNum1_ShopInfo)
        {
            var array = new string[22];
            var array2 = new string[22];
            array[0] = "@shopname";
            array2[0] = shopNum1_ShopInfo.ShopName;
            array[1] = "@addressvalue";
            array2[1] = shopNum1_ShopInfo.AddressValue;
            array[2] = "@modifyuser";
            array2[2] = shopNum1_ShopInfo.ModifyUser;
            array[3] = "@modifytime";
            array2[3] = shopNum1_ShopInfo.ModifyTime.ToString();
            array[4] = "@shopcategory";
            array2[4] = shopNum1_ShopInfo.ShopCategory;
            array[5] = "@shopcategoryid";
            array2[5] = shopNum1_ShopInfo.ShopCategoryID;
            array[6] = "@addresscode";
            array2[6] = shopNum1_ShopInfo.AddressCode;
            array[7] = "@isaudit";
            array2[7] = shopNum1_ShopInfo.IsAudit.ToString();
            array[8] = "@name";
            array2[8] = shopNum1_ShopInfo.Name;
            array[9] = "@identitycard";
            array2[9] = shopNum1_ShopInfo.IdentityCard;
            array[10] = "@detailaddress";
            array2[10] = shopNum1_ShopInfo.Address;
            array[11] = "@postalcode";
            array2[11] = shopNum1_ShopInfo.PostalCode;
            array[12] = "@tel";
            array2[12] = shopNum1_ShopInfo.Tel;
            array[13] = "@cardimage";
            array2[13] = shopNum1_ShopInfo.CardImage;
            array[14] = "@memloginid";
            array2[14] = shopNum1_ShopInfo.MemLoginID;
            array[15] = "@RegistrationNum";
            array[16] = "@CompanName";
            array[17] = "@LegalPerson";
            array[18] = "@RegisteredCapital";
            array[19] = "@BusinessTerm";
            array[20] = "@BusinessScope";
            array[21] = "@BusinessLicense";
            array2[15] = shopNum1_ShopInfo.RegistrationNum;
            array2[16] = shopNum1_ShopInfo.CompanName;
            array2[17] = shopNum1_ShopInfo.LegalPerson;
            array2[18] = shopNum1_ShopInfo.RegisteredCapital.ToString();
            array2[19] = shopNum1_ShopInfo.BusinessTerm;
            array2[20] = shopNum1_ShopInfo.BusinessScope;
            array2[21] = shopNum1_ShopInfo.BusinessLicense;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateShopInfo", array, array2);
        }

        public int UpdateShopInfoDetail(ShopNum1_ShopInfo shopNum1_ShopInfo)
        {
            var array = new string[21];
            var array2 = new string[21];
            array[0] = "@Name";
            array2[0] = shopNum1_ShopInfo.Name;
            array[1] = "@ShopName";
            array2[1] = shopNum1_ShopInfo.ShopName;
            array[2] = "@SalesRange";
            array2[2] = shopNum1_ShopInfo.SalesRange;
            array[3] = "@Email";
            array2[3] = shopNum1_ShopInfo.Email;
            array[4] = "@Tel";
            array2[4] = shopNum1_ShopInfo.Tel;
            array[5] = "@Phone";
            array2[5] = shopNum1_ShopInfo.Phone;
            array[6] = "@PostalCode";
            array2[6] = shopNum1_ShopInfo.PostalCode;
            array[7] = "@IdentityCard";
            array2[7] = shopNum1_ShopInfo.IdentityCard;
            array[8] = "@RegistrationNum";
            array2[8] = shopNum1_ShopInfo.RegistrationNum;
            array[9] = "@CompanName";
            array2[9] = shopNum1_ShopInfo.CompanName;
            array[10] = "@LegalPerson";
            array2[10] = shopNum1_ShopInfo.LegalPerson;
            array[11] = "@RegisteredCapital";
            array2[11] = shopNum1_ShopInfo.RegisteredCapital.ToString();
            array[12] = "@BusinessTerm";
            array2[12] = shopNum1_ShopInfo.BusinessTerm;
            array[13] = "@BusinessScope";
            array2[13] = shopNum1_ShopInfo.BusinessScope;
            array[14] = "@Address";
            array2[14] = shopNum1_ShopInfo.Address;
            array[15] = "@IsExpires";
            array2[15] = shopNum1_ShopInfo.IsExpires.ToString();
            array[16] = "@IsClose";
            array2[16] = shopNum1_ShopInfo.IsClose.ToString();
            array[17] = "@CompanyIntroduce";
            array2[17] = shopNum1_ShopInfo.CompanyIntroduce;
            array[18] = "@ShopIntroduce";
            array2[18] = shopNum1_ShopInfo.ShopIntroduce;
            array[19] = "@MemLoginID";
            array2[19] = shopNum1_ShopInfo.MemLoginID;
            array[20] = "@MainGoods";
            array2[20] = shopNum1_ShopInfo.MainGoods;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateShopInfoDetail", array, array2);
        }

        public int CheckShopName(string name)
        {
            string text = "Pro_ShopNum1_CheckShopName";
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@name";
            array2[0] = name;
            DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable(text, array, array2);
            int result;
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                result = 0;
            }
            else
            {
                result = 1;
            }
            return result;
        }

        public DataTable SearchEspecialShopList(string pagesize, string field)
        {
            var array = new string[2];
            var array2 = new string[2];
            array[0] = "@pagesize";
            array2[0] = pagesize;
            array[1] = "@field";
            array2[1] = field;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialShopList", array, array2);
        }

        public DataTable SearchNewsShopList(string pagesize)
        {
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@pagesize";
            array2[0] = pagesize;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchNewsShopList", array, array2);
        }
        public int UpdateShopMemberState(string guid, string num)
        {
            var array = new string[2];
            var array2 = new string[2];
            array[0] = "@guid";
            array2[0] = guid;
            array[1] = "@num";
            array2[1] = num;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateShopMemberState", array, array2);
        }

        public int UpdateShopState(string guid, string field, string string_0)
        {
            var array = new string[3];
            var array2 = new string[3];
            array[0] = "@guid";
            array2[0] = guid;
            array[1] = "@field";
            array2[1] = field;
            array[2] = "@num";
            array2[2] = string_0;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateShopState ", array, array2);
        }

        public DataTable GetShopIDByMemLoginID(string MemLogin)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLogin";
            parms[0].Value = MemLogin;
            string text = string.Empty;
            text = "select ShopID,ShopUrl,OpenTime from ShopNum1_ShopInfo WHERE MemLoginID =@MemLogin";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public DataTable GetEnsureImagePathBymemberLoginID(string memberLoginID)
        {
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@memberLoginID";
            array2[0] = memberLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetEnsureImagePathBymemberLoginID", array,
                array2);
        }

        public DataTable GetAllMemberShipByMembershipID(string MembershipID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MembershipID";
            parms[0].Value = MembershipID;
            string text = string.Empty;
            text = "  select * from ShopNum1_MemberShip  where MembershipID=@MembershipID";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }
        public DataTable GetAllMemberShipByMembershipIDNEC(string MembershipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MembershipID";
            parms[0].Value = MembershipID;
            string text = string.Empty;
            text = "select * from [Nec_ShenQinShangJia]  where [ID]=@MembershipID";
            return DatabaseExcetue.ReturnDataTable(text, parms);
        }
        public DataTable GetAllShopInfoByGuid(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            
            string text = string.Empty;
            text = "select * from ShopNum1_ShopInfo where Guid"+andSql;
            return DatabaseExcetue.ReturnDataTable(text,parms.ToArray());
        }

        public DataTable GetNewShopInfoByShowCount(string ShowCount)
        {
            string text = string.Empty;
            text = "Select Top " + ShowCount +
                   "  ShopID,ShopName,Banner,ShopReputation from ShopNum1_ShopInfo Where IsAudit=1 And IsDeleted=0 Order by OrderID";
            return DatabaseExcetue.ReturnDataTable(text);
        }

        public int UpdateShopReputationByMemLoginID(string memLoginID, int score)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@score";
            parms[1].Value = score;
            string text = string.Empty;
            text = string.Concat(new object[]
            {
                "UPDATE dbo.ShopNum1_ShopInfo SET ShopReputation=ShopReputation+(@score) WHERE MemLoginID=@memLoginID"
            });
            return DatabaseExcetue.RunNonQuery(text,parms);
        }

        public DataTable GetMemberInfoByGuid(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string text = string.Empty;
            text =
                "select A.Name,A.MemLoginID,A.MemberType from ShopNum1_Member AS A,ShopNum1_ShopInfo AS B where A.MemLoginID=B.MemLoginID AND B.Guid=@guid";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public void UpdateDate(string guid, string time)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guid, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@time";
            parm.Value = time;
            parms.Add(parm);

            
            string text = string.Empty;
            text = string.Concat(new[]
            {
                "UPDATE ShopNum1_ShopInfo SET OpenTime =@time where Guid"+andSql
            });
            DatabaseExcetue.RunNonQuery(text,parms.ToArray());
        }

        public DataTable CheckShopURLIsRepeat(string shopurl)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@shopurl";
            parms[0].Value = shopurl;
            string text = string.Empty;
            text = "SELECT COUNT(*) AS ShopUrl FROM ShopNum1_ShopInfo WHERE IsAudit=1 and ShopUrl =@shopurl";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public int UpdataShopURLByGuid(string guid, string shopurl)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@shopurl";
            parms[0].Value = shopurl;
            parms[1].ParameterName = "@guid";
            parms[1].Value = guid.Replace("'","");
            string text = string.Empty;
            text = string.Concat(new[]
            {
                "UPDATE ShopNum1_ShopInfo SET ShopUrl =@shopurl where Guid =@guid"
            });
            return DatabaseExcetue.RunNonQuery(text,parms);
        }

        public DataTable GetShopCategoryApplyInfo(string ShopName, string memberLoginID, string ShopCategoryCode,
            string IsAudit, string StartTime, string EndTime)
        {
            string text = string.Empty;
            text =
                "SELECT A.*,B.ShopName,B.ShopUrl FROM ShopNum1_Shop_ApplyCateGory AS A,ShopNum1_ShopInfo AS B WHERE B.MemLoginID=A.ShopID ";
            if (!string.IsNullOrEmpty(ShopName))
            {
                text = text + " AND B.ShopName='" + ShopName.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(memberLoginID))
            {
                text = text + " AND A.ShopID='" + memberLoginID.Trim() + "'";
            }
            if (ShopCategoryCode.Trim() != "-1")
            {
                text = text + " AND A.OldShopCategoryCode='" + ShopCategoryCode.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(IsAudit))
            {
                if (IsAudit == "-2")
                {
                    text += " AND A.IsAudit IN (0,2) ";
                }
                else
                {
                    text = text + " AND A.IsAudit=" + IsAudit.Trim();
                }
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                text = text + " AND A.ApplyTime>='" + StartTime.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                text = text + " AND A.ApplyTime<='" + EndTime.Trim() + "'";
            }
            text += " ORDER BY A.ApplyTime DESC";
            return DatabaseExcetue.ReturnDataTable(text);
        }

        public int DeleteShopCategoryApply(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            string text = string.Empty;
            text = "DELETE FROM ShopNum1_Shop_ApplyCateGory WHERE GUID IN (@guids)";
            return DatabaseExcetue.RunNonQuery(text);
        }

        public int UpdataShopCategoryApplyIsAudit(string guids, string isAudit)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            parms[1].ParameterName = "@isAudit";
            parms[1].Value = isAudit;
            string text = string.Empty;
            text = string.Concat(new[]
            {
                "UPDATE ShopNum1_Shop_ApplyCateGory SET IsAudit=@isAudit WHERE Guid IN (@guids)"
            });
            return DatabaseExcetue.RunNonQuery(text,parms);
        }

        public DataTable GetShopCategoryInfoByGuid(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            string text = string.Empty;
            text =
                "SELECT A.*,B.ShopName FROM ShopNum1_Shop_ApplyCateGory AS A,ShopNum1_ShopInfo AS B WHERE B.MemLoginID=A.ShopID AND A.Guid IN (@guids)";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public int UpdateShopCategoryAndBrandByGuids(string guids, string ShopCategoryName, string ShopCategoryCode,
            string BrandName, string BrandGuid)
        {
            string text = string.Empty;
            text = string.Concat(new[]
            {
                "UPDATE  ShopNum1_ShopInfo SET ShopBrandName='",
                BrandName,
                "', ShopBrandGuid='",
                BrandGuid,
                "', ShopCategory='",
                ShopCategoryName,
                "', ShopCategoryID='",
                ShopCategoryCode,
                "' where MemLoginID = (SELECT ShopID FROM ShopNum1_Shop_ApplyCateGory WHERE Guid =",
                guids,
                ")"
            });
            return DatabaseExcetue.RunNonQuery(text);
        }

        public string GetShopURLByShopID(string shopid)
        {
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@shopid";
            array2[0] = shopid;
            DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopURLByShopID", array,
                array2);
            string result;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                result = dataTable.Rows[0]["ShopUrl"].ToString();
            }
            else
            {
                result = "";
            }
            return result;
        }

        public string GetShopPayMentType(string memloginid)
        {
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@memloginid";
            array2[0] = memloginid;
            return DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_GetShopPayMentType", array, array2).ToString();
        }

        public int InsertShopNav(string shopid)
        {
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@shopid";
            array2[0] = shopid;
            return Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_InsertShopNav", array, array2));
        }

        public string GetShopGuid(string memLoginID)
        {
            string text = string.Empty;
            text = "select Guid from ShopNum1_ShopInfo  WHERE MemLoginID ='" + memLoginID + "'";
            return DatabaseExcetue.ReturnString(text);
        }

        public int Delete(string guid, string memLoginID)
        {
            var list = new List<string>();
            string item = string.Empty;
            item = "Update Shopnum1_Member set membertype=1 where MemloginId='" + memLoginID + "'";
            item = "delete from ShopNum1_ShopProductRelationProp  WHERE Memlogid = '" + memLoginID + "'";
            item = "delete from ShopNum1_ShopInfo  WHERE Guid = '" + guid + "'";
            list.Add(item);
            item = "delete from ShopNum1_OrderInfo  WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_OrderOperateLog WHERE CreateUser = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_OrderProduct WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Refund WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_ApplyCateGory WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_ApplyEnsure WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_ApplyShopRank WHERE MemberLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_Cart WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_Coupon WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_Image WHERE CreateUser = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_ImageCategory WHERE CreateUser = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_Link WHERE ShopMemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_MessageBoard WHERE ReplyUser = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_News WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_NewsCategory WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_OnlineService WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_OtherOrderInfo WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_Product WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_ProductCategory WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_ProductComment WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_ScoreProduct WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_ScoreProductCategory WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_StarGuide WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_UserDefinedColumn WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_Video WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_Shop_VideoCategory WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_ShopCollect WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_ShopPayment WHERE memloginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_ShopProductConsult WHERE ShopID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_ShopURLManage WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_SpecificationProductImage WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_SpecificationProudct WHERE MemLoginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_SpecificationProudctPropName WHERE memloginID = " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_ZtcApply    WHERE   MemberID= " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_ZtcGoods    WHERE   MemberID= " + memLoginID;
            list.Add(item);
            item = "delete from ShopNum1_ScoreOrderInfo    WHERE   ShopMemLoginID= " + memLoginID;
            list.Add(item);
            int result;
            try
            {
                DatabaseExcetue.RunTransactionSql(list);
                result = 1;
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public int GetShopCountByCode(string code)
        {
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@code";
            array2[0] = code;
            object value = DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_ShopInfoGetShopCountByCode", array,
                array2);
            return Convert.ToInt32(value);
        }

        public DataTable Search(string memberLoginID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@memberLoginID";
            parms[0].Value = memberLoginID;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "select A.*, B.Name AS RankName,B.MaxFileCount as BmaxFileCount  from ShopNum1_ShopInfo AS A inner join ShopNum1_ShopRank AS B on A.ShopRank=B.Guid ");
            stringBuilder.Append(" AND A.MemLoginID = @memberLoginID");
            return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString(),parms);
        }

        public DataTable GetShopOpentimeByMemLoginID(string MemLoginID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string text = string.Empty;
            text = "select ShopID,OpenTime from ShopNum1_ShopInfo WHERE MemLoginID =@MemLoginID";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public string GetShopURLByAddressCode(string addressCode)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@addressCode";
            parms[0].Value = addressCode;
            string text = string.Empty;
            text = "SELECT  ShopUrl  FROM  ShopNum1_ShopInfo where 1=1 ";
            if (!string.IsNullOrEmpty(addressCode))
            {
                text = text + "  AND AddressCode=@addressCode";
            }
            DataTable dataTable = DatabaseExcetue.ReturnDataTable(text,parms);
            string result;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                result = dataTable.Rows[0]["ShopUrl"].ToString();
            }
            else
            {
                result = "";
            }
            return result;
        }

        public DataSet SearchShopList(string pageindex, string pagesize, string regioncode, string shopcategoryid,
            string name, string memberloginid)
        {
            var array = new string[6];
            var array2 = new string[6];
            array[0] = "@pageindex";
            array2[0] = pageindex;
            array[1] = "@pagesize";
            array2[1] = pagesize;
            array[2] = "@AddressCode";
            array2[2] = regioncode;
            array[3] = "@ShopCategoryID";
            array2[3] = shopcategoryid;
            array[4] = "@Name";
            array2[4] = name;
            array[5] = "@MemLoginID";
            array2[5] = memberloginid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchShopList", array, array2);
        }

        public DataSet SearchShopList(string addresscode, string ShopCategoryID, string ordername, string soft,
            string shopName, string memberid, string perpagenum, string current_page, string isreturcount)
        {
            string text = string.Empty;
            if (ordername == "-1")
            {
                ordername = "A.orderid";
            }
            if (ordername == "SaleSum")
            {
                ordername = "B.SaleSum";
            }
            if (ordername == "CreateTime")
            {
                ordername = "A.CreateTime";
            }
            if (ordername == "ClickCount")
            {
                ordername = "A.ClickCount";
            }
            if (ordername == "ShopReputation")
            {
                ordername = "A.ShopReputation";
            }
            if (ShopCategoryID != "-1")
            {
                text = " A.ShopCategoryID like '" + Operator.FilterString(ShopCategoryID) + "%'";
            }
            else
            {
                text = "1=1";
            }
            if (addresscode != "-1" && addresscode != "000")
            {
                text = text + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
            }
            if (string.IsNullOrEmpty(soft))
            {
                soft = "desc";
            }
            if (shopName != "-1" && !string.IsNullOrEmpty(shopName))
            {
                text = text + " And A.ShopName like '%" + Operator.FilterString(shopName) + "%' ";
            }
            if (memberid != "-1")
            {
                text = text + " And A.MemLoginID like '%" + Operator.FilterString(memberid) + "%' ";
            }
            var array = new string[7];
            var array2 = new string[7];
            array[0] = "@perpagenum";
            array2[0] = perpagenum;
            array[1] = "@current_page";
            array2[1] = current_page;
            array[2] = "@columnnames";
            array2[2] =
                "(select pic from ShopNum1_ShopRank where guid=a.ShopRank)AS mrankpic,1 AS HaoPingLV,null as ShopSpeed,null as ShopAttitude,null as ShopCharacter,0 AS SpeedBL,0 AS AttitudeBL,0 AS CharacterBL,ProductNum,SaleSum,ordersum,A.Guid,A.ShopName,A.ShopUrl,A.SalesRange,A.ShopID,A.Name,A.Banner,A.MemLoginID,A.AddressValue,A.AddressCode,A.MainGoods ";
            array[3] = "@ordername";
            array2[3] = ordername;
            array[4] = "@searchname";
            array2[4] = text;
            array[5] = "@sdesc";
            array2[5] = soft;
            array[6] = "@isreturcount";
            array2[6] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageShops", array, array2);
        }


        public DataTable SearchEspecialShop(string pagesize, string field)
        {
            var array = new string[2];
            var array2 = new string[2];
            array[0] = "@pagesize";
            array2[0] = pagesize;
            array[1] = "@field";
            array2[1] = field;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialShop", array, array2);
        }

        public string GetShopid(string memLoginID)
        {
            string text = string.Empty;
            text = "select Shopid from ShopNum1_ShopInfo  WHERE MemLoginID ='" + memLoginID + "'";
            return DatabaseExcetue.ReturnString(text);
        }

        public DataTable GetShopUrlByAddressCode(string AddressCode)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@AddressCode";
            parms[0].Value = AddressCode;
            string text = string.Empty;
            text = "select ShopUrl from  ShopNum1_ShopInfo where AddressCode =@AddressCode";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public DataTable GetShopRankByMemLoginID(string MemLoginID)
        {
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@memloginid";
            array2[0] = MemLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopRankByMemLoginID", array, array2);
        }

        public DataTable GetOpenTimeByShopID(string shopid)
        {
            var array = new string[1];
            var array2 = new string[1];
            array[0] = "@shopid";
            array2[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOpenTimeByShopID", array, array2);
        }

        public DataTable SearchShopSalesClickCount(string shophost, string shopname, string startdate, string enddate)
        {
            var array = new string[4];
            var array2 = new string[4];
            array[0] = "@shophost";
            array2[0] = shophost;
            array[1] = "@shopname";
            array2[1] = shopname;
            array[2] = "@startdate";
            array2[2] = startdate;
            array[3] = "@enddate";
            array2[3] = enddate;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopSalesClickCount", array, array2);
        }

        public int DeleteMore(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string text = string.Empty;
            text = "delete from ShopNum1_ShopInfo  WHERE   Guid    IN (@guid)";
            return DatabaseExcetue.RunNonQuery(text,parms);
        }

        public bool SearchShop(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            string text = string.Empty;
            text = "select MemLoginID from ShopNum1_ShopInfo  WHERE MemLoginID =@memloginID";
            DataTable dataTable = DatabaseExcetue.ReturnDataTable(text,parms);
            return dataTable != null && dataTable.Rows.Count != 0;
        }

        public string CheckType(string strtype)
        {
            string text = "select shopcategoryid from ShopNum1_ShopInfo  WHERE  shopcategoryid  = '" + strtype + "'";
            return DatabaseExcetue.ReturnString(text);
        }

        public DataTable GetTypeCategoryId()
        {
            string text = "select shopcategoryid from ShopNum1_ShopInfo";
            return DatabaseExcetue.ReturnDataTable(text);
        }

        public DataTable Search(string ShopName, string memberLoginID, string IsAudit, string ShopType)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "select A.*,C.Name as CName,IsVisits from ShopNum1_ShopInfo AS A inner join ShopNum1_ShopCategory AS C ON a.shopcategoryid=c.code  ");
            if (Operator.FormatToEmpty(ShopName) != string.Empty)
            {
                stringBuilder.Append(" AND A.ShopName like '%" + Operator.FilterString(ShopName) + "%'");
            }
            if (Operator.FormatToEmpty(memberLoginID) != string.Empty)
            {
                stringBuilder.Append(" AND A.MemLoginID like '%" + memberLoginID + "%'");
            }
            stringBuilder.Append(" AND A.IsAudit=" + IsAudit);
            if (ShopType != "-1")
            {
                stringBuilder.Append(" AND A.ShopType =" + ShopType);
            }
            stringBuilder.Append("  ORDER BY A.ApplyTime DESC  ");
            return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
        }

        public int UpdateShopState(string guid, string AuditFailedReason, string OperateUser, string AuditTime,
            int IsAudit)
        {
            string text = string.Empty;
            text = text + "   UPDATE    ShopNum1_ShopInfo    SET  AuditFailedReason='" +
                   Operator.FilterString(AuditFailedReason) + "',   ";
            text = text + "   OperateUser='" + OperateUser + "',     ";
            object obj = text;
            text = string.Concat(new[]
            {
                obj,
                "   IsAudit='",
                IsAudit,
                "',     "
            });
            text = text + "   AuditTime='" + AuditTime + "'     ";
            text = text + "   WHERE   Guid='" + guid + "'       ";
            return DatabaseExcetue.RunNonQuery(text);
        }

        public DataTable GetShopByMemLoginID(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string text = string.Empty;
            text = "SELECT  *   FROM  ShopNum1_ShopInfo WHERE     MemLoginID =@MemLoginID";
            return DatabaseExcetue.ReturnDataTable(text,parms);
        }

        public int UpdateShop(string MemLoginID, ShopNum1_ShopInfo shopNum1_ShopInfo)
        {
            string text = string.Empty;
            text = string.Concat(new object[]
            {
                "UPDATE  ShopNum1_ShopInfo   SET  AddressCode  ='",
                Operator.FilterString(shopNum1_ShopInfo.AddressCode),
                "', ShopCategoryID  ='",
                Operator.FilterString(shopNum1_ShopInfo.ShopCategoryID),
                "', ShopName  ='",
                Operator.FilterString(shopNum1_ShopInfo.ShopName),
                "', SalesRange  ='",
                Operator.FilterString(shopNum1_ShopInfo.SalesRange),
                "', AddressValue  ='",
                Operator.FilterString(shopNum1_ShopInfo.AddressValue),
                "', ModifyUser  ='",
                shopNum1_ShopInfo.ModifyUser,
                "', ModifyTime  ='",
                shopNum1_ShopInfo.ModifyTime,
                "', ShopCategory  ='",
                shopNum1_ShopInfo.ShopCategory,
                "',  IdentityCard  ='",
                shopNum1_ShopInfo.IdentityCard,
                "',  Address  ='",
                Operator.FilterString(shopNum1_ShopInfo.Address),
                "',  MainGoods  ='",
                Operator.FilterString(shopNum1_ShopInfo.MainGoods),
                "',  PostalCode  ='",
                Operator.FilterString(shopNum1_ShopInfo.PostalCode),
                "',  CardImage  ='",
                shopNum1_ShopInfo.CardImage,
                "',  TemplateType  ='",
                shopNum1_ShopInfo.TemplateType,
                "',  BusinessLicense  ='",
                shopNum1_ShopInfo.BusinessLicense,
                "',  Phone  ='",
                Operator.FilterString(shopNum1_ShopInfo.Phone),
                "',  Tel  ='",
                Operator.FilterString(shopNum1_ShopInfo.Tel),
                "',  TaxRegistration  ='",
                shopNum1_ShopInfo.TaxRegistration,
                "',  Organization  ='",
                shopNum1_ShopInfo.Organization,
                "',  ShopType  ='",
                shopNum1_ShopInfo.ShopType,
               "',  AuditFailedReason  ='',  OperateUser  ='',  IsAudit  =0 WHERE MemLoginID='",
                MemLoginID,
                "'"
            });
            return DatabaseExcetue.RunNonQuery(text);
        }


        #region 会员等级修改
        public int UpdateShip(ShopNum1_MemberShip shopNum1_MemberShip, string MembershipID)
        {
            string text = string.Empty;
            text = string.Concat(new object[]
            {
                "UPDATE ShopNum1_MemberShip SET RealName='",shopNum1_MemberShip.RealName,
                    // "',LastRankID='", shopNum1_MemberShip.LastRankID,
                    //"',NewRankID='",shopNum1_MemberShip.NewRankID,
                    "',[MemLoginID]='",shopNum1_MemberShip.MemLoginID,
                    "',[MemLoginNO]='",shopNum1_MemberShip.MemLoginNO,
                    "',BirthdayTime='",shopNum1_MemberShip.BirthdayTime,
                    "',IdentityCard='",shopNum1_MemberShip.IdentityCard,
                    "',Sex='",shopNum1_MemberShip.Sex,
                    "',Phone='",shopNum1_MemberShip.Phone,
                    "',Mobile='",shopNum1_MemberShip.Mobile,
                    "',Adress='",shopNum1_MemberShip.Adress,
                    "',Area='",shopNum1_MemberShip.Area,
                    "',Occupation='",shopNum1_MemberShip.Occupation,
                    "',RERealName='",shopNum1_MemberShip.RERealName,
                    "',REMemLoginNO='",shopNum1_MemberShip.REMemLoginNO,
                    "',REAddTime='",shopNum1_MemberShip.REAddTime,
                    "',REBirthdayTime='",shopNum1_MemberShip.REBirthdayTime,
                    "',REIdentityCard='",shopNum1_MemberShip.REIdentityCard,
                    "',RESex='",shopNum1_MemberShip.RESex,
                    "',REPhone='",shopNum1_MemberShip.REPhone,
                    "',REMobile='",shopNum1_MemberShip.REMobile,
                    "',REAdress='",shopNum1_MemberShip.REAdress,
                    "',Belongs='",shopNum1_MemberShip.Belongs,
                    "',ShopNames='",shopNum1_MemberShip.ShopNames,
                    "' where MemberShipID='",MembershipID,"'"
            });
            return DatabaseExcetue.RunNonQuery(text);
        }

        #endregion


        #region 会员删除

        public int DeleteShip(string MembershipID)
        {
            string text = string.Empty;

            text = string.Concat(new object[]
            {
                "Delete from ShopNum1_MemberShip  where MemberShipID='",MembershipID,"'"
            });

            return DatabaseExcetue.RunNonQuery(text); 
        }

        #endregion
    }
}
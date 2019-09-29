using System;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Ensure_Action : IShop_Ensure_Action
    {
        public int Add(ShopNum1_ShopEnsure shopNum1_ShopEnsure)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    "INSERT INTO ShopNum1_ShopEnsure( Name, ImagePath, Href, Remark, EnsureMoney  ) VALUES (  '" +
                    Operator.FilterString(shopNum1_ShopEnsure.Name) + "',  '" + shopNum1_ShopEnsure.ImagePath + "',  '" +
                    Operator.FilterString(shopNum1_ShopEnsure.Href) + "',  '" +
                    Operator.FilterString(shopNum1_ShopEnsure.Remark) + "',  '" +
                    Operator.FilterString(shopNum1_ShopEnsure.EnsureMoney) + "' )");
        }

        public int ApplyShopEnsure(ShopNum1_Shop_ApplyEnsure applyEnsure)
        {
            var paraName = new string[11];
            var paraValue = new string[11];
            paraName[0] = "@guid";
            paraValue[0] = applyEnsure.Guid.ToString();
            paraName[1] = "@ensureid";
            paraValue[1] = applyEnsure.EnsureID.ToString();
            paraName[2] = "@applytime";
            paraValue[2] = applyEnsure.ApplyTime.ToString();
            paraName[3] = "@createuser";
            paraValue[3] = applyEnsure.CreateUser;
            paraName[4] = "@shopid";
            paraValue[4] = applyEnsure.ShopID;
            paraName[5] = "@memberLoginID";
            paraValue[5] = applyEnsure.MemberLoginID;
            paraName[6] = "@ispayment";
            paraValue[6] = applyEnsure.IsPayMent.ToString();
            paraName[7] = "@IsAudit";
            paraValue[7] = applyEnsure.IsAudit.ToString();
            paraName[8] = "@paymentname";
            paraValue[8] = applyEnsure.PaymentName;
            paraName[9] = "@paymenttype";
            paraValue[9] = applyEnsure.PaymentType.ToString();
            paraName[10] = "@remarks";
            paraValue[10] = applyEnsure.Remarks;
            return DatabaseExcetue.RunProcedure("Pro_Shop_ApplyShopEnsure", paraName, paraValue);
        }

        public int CheckIsPayMentByID(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = new Guid(guid).ToString();
            return DatabaseExcetue.RunProcedure("Pro_Shop_CheckEnsureIsPayMentByGuid", paraName, paraValue);
        }

        public int Del(string string_0)
        {
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_ShopEnsure where ID IN (" + string_0 + ") ");
        }

        public int DelShopEnsureList(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DelShopEnsureList", paraName, paraValue);
        }

        public DataTable GetCheckedShopEnsureList(string ensureid, string shopid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ensureid";
            paraValue[0] = ensureid;
            paraName[1] = "@shopid";
            paraValue[1] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCheckedShopEnsureList", paraName, paraValue);
        }

        public DataTable GetEnsureMoney(Guid guid)
        {
            var builder = new StringBuilder();
            builder.Append("  SELECT   a.EnsureID ,a.MemberLoginID , b.EnsureMoney  ");
            builder.Append("  FROM  ShopNum1_Shop_ApplyEnsure  as a ,");
            builder.Append("   ShopNum1_ShopEnsure as b ");
            builder.Append("  where a.Guid='" + guid + "'");
            builder.Append("  and a.EnsureID=b.id   ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetShopapplyEnsure(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopApplyEnsure", paraName, paraValue);
        }

        public DataTable GetShopapplyEnsureList(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopapplyEnsureList", paraName, paraValue);
        }

        public DataTable GetShopapplyNoRegShopEnsureList(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopapplyNoRegShopEnsureList", paraName,
                paraValue);
        }

        public DataTable GetShopEnsure(int int_0)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = int_0.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopEnsure", paraName, paraValue);
        }

        public DataTable GetShopEnsureList(string name)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@name";
            paraValue[0] = name;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopEnsureList", paraName, paraValue);
        }

        public DataTable GetShopEnsureListByMemberLoginID(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopEnsureListByMemberLoginID", paraName,
                paraValue);
        }

        public DataTable GetShopEnsureListNew(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopEnsureListNew", paraName, paraValue);
        }

        public DataTable GetShopNotApplyEnsure(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopNotApplyEnsure", paraName, paraValue);
        }

        public DataTable SearchEnsureApply(string shopid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT b.Name, b.ImagePath, a.ShopID FROM ShopNum1_Shop_ApplyEnsure AS a ,ShopNum1_ShopEnsure AS b  WHERE a.EnsureID=b.ID AND IsAudit=1 AND ShopID='" +
                    shopid + "'");
        }

        public DataTable SearchEnsureApply_List(string name, string isAudit, string shopid)
        {
            string str = string.Empty;
            str =
                "SELECT a.Guid, b.Name, a.ApplyTime, a.IsAudit, a.Remarks, a.PaymentName, a.IsPayMent, a.ShopID, c.ShopID as ShopUrlID from ShopNum1_Shop_ApplyEnsure as a  left join ShopNum1_ShopEnsure as b on a.EnsureID=b.ID  left join shopnum1_shopinfo as c on a.MemberLoginID=c.MemLoginID WHERE 1=1 ";
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + "AND B.Name='" + name + "'";
            }
            if (isAudit != "-1")
            {
                if (isAudit == "-2")
                {
                    str = str + "AND A.IsAudit IN ('0','2') ";
                }
                else
                {
                    str = str + "AND A.IsAudit='" + isAudit + "'";
                }
            }
            if (Operator.FormatToEmpty(shopid) != string.Empty)
            {
                str = str + " AND A.ShopID='" + shopid + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY ApplyTime DESC");
        }

        public DataTable SearchShopEnsureListNew(string memberLoginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memberLoginID";
            paraValue[0] = memberLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("[Pro_Shop_GetShopapplyEnsureListNew]", paraName,
                paraValue);
        }

        public int Updata(ShopNum1_ShopEnsure shopNum1_ShopEnsure)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_ShopEnsure SET  Name='", Operator.FilterString(shopNum1_ShopEnsure.Name),
                        "', ImagePath='", shopNum1_ShopEnsure.ImagePath, "', Href='",
                        Operator.FilterString(shopNum1_ShopEnsure.Href), "', Remark='",
                        Operator.FilterString(shopNum1_ShopEnsure.Remark), "', EnsureMoney='",
                        Operator.FilterString(shopNum1_ShopEnsure.EnsureMoney), "'WHERE id=", shopNum1_ShopEnsure.ID
                    }));
        }

        public int UpdataEnsurePayMentByGuid(string guid, string PayMentType, string PayMentName)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@PayMentType";
            paraValue[1] = PayMentType;
            paraName[2] = "@PayMentName";
            paraValue[2] = PayMentName;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataEnsurePayMentByGuid", paraName, paraValue);
        }

        public int UpdataEnsurePayStatusByGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataEnsurePayStatusByGuid", paraName, paraValue);
        }

        public int UpdataIsAuditByGuid(string guid, int isAudit)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {"UPDATE ShopNum1_Shop_ApplyEnsure SET IsAudit=", isAudit, " WHERE Guid in (", guid, ")"}));
        }

        public int UpdateShopEnsureList(string memloginid, string ensureid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@ensureid";
            paraValue[1] = ensureid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateShopEnsureList", paraName, paraValue);
        }

        public DataTable GetShopapplyEnsureListNew(string shopid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopapplyEnsureListNew", paraName, paraValue);
        }

        public DataTable SearchEnsureApply_List(string name, string MemberLoginID, string isAudit, string shopid)
        {
            string str = string.Empty;
            str =
                "SELECT a.Guid, b.Name, a.ApplyTime, a.IsAudit, a.Remarks, a.PaymentName, a.IsPayMent, a.ShopID, c.ShopID as ShopUrlID from ShopNum1_Shop_ApplyEnsure as a  left join ShopNum1_ShopEnsure as b on a.EnsureID=b.ID  left join shopnum1_shopinfo as c on a.MemberLoginID=c.MemLoginID WHERE 1=1 ";
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + "AND B.Name='" + name + "'";
            }
            if (Operator.FormatToEmpty(MemberLoginID) != string.Empty)
            {
                str = str + "AND  a.MemberLoginID='" + MemberLoginID + "'";
            }
            if (isAudit != "-1")
            {
                if (isAudit == "-2")
                {
                    str = str + "AND A.IsAudit IN ('0','2') ";
                }
                else
                {
                    str = str + "AND A.IsAudit='" + isAudit + "'";
                }
            }
            if (Operator.FormatToEmpty(shopid) != string.Empty)
            {
                str = str + " AND A.ShopID='" + shopid + "' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY ApplyTime DESC");
        }

        public DataTable SearchShopEnsureList(string string_0)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchShopEnsureList", paraName, paraValue);
        }
    }
}
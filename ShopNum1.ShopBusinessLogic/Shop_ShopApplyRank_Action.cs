using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_ShopApplyRank_Action : IShop_ShopApplyRank_Action
    {
        public DataTable Add(ShopNum1_Shop_ApplyShopRank shopNum1_Shop_ApplyShopRank)
        {
            var paraName = new string[9];
            var paraValue = new string[9];
            paraName[0] = "@rankguid";
            paraValue[0] = shopNum1_Shop_ApplyShopRank.RankGuid.ToString();
            paraName[1] = "@memberloginid";
            paraValue[1] = shopNum1_Shop_ApplyShopRank.MemberLoginID;
            paraName[2] = "@isaudit";
            paraValue[2] = shopNum1_Shop_ApplyShopRank.IsAudit.ToString();
            paraName[3] = "@applytime";
            paraValue[3] = shopNum1_Shop_ApplyShopRank.ApplyTime.ToString();
            paraName[4] = "@ispayment";
            paraValue[4] = shopNum1_Shop_ApplyShopRank.IsPayMent.ToString();
            paraName[5] = "@paymentname";
            paraValue[5] = shopNum1_Shop_ApplyShopRank.PaymentName;
            paraName[6] = "@paymenttype";
            paraValue[6] = shopNum1_Shop_ApplyShopRank.PaymentType.ToString();
            paraName[7] = "@RankName";
            paraValue[7] = shopNum1_Shop_ApplyShopRank.RankName;
            paraName[8] = "@VerifyTime";
            paraValue[8] = shopNum1_Shop_ApplyShopRank.VerifyTime.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ApplyShopRankAdd", paraName, paraValue);
        }

        public int Check(string ID, string isaudit)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@id";
            paraValue[0] = ID;
            paraName[1] = "@isaudit";
            paraValue[1] = isaudit;
            return DatabaseExcetue.RunProcedure("Pro_Shop_ApplyShopRankCheck", paraName, paraValue);
        }

        public DataTable CheckIsApply(string guid, string memloginID)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT IsPayMent,ID FROM ShopNum1_Shop_ApplyShopRank WHERE RankGuid='" + guid +
                    "' AND MemberLoginID='" + memloginID + "'");
        }

        public int CheckIsPayMentByID(string string_0)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedure("Pro_Shop_CheckShopRankIsPayMentByID", paraName, paraValue);
        }

        public int Delete(string ID)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_ApplyShopRank WHERE ID IN(" + ID + ")");
        }

        public DataTable GetShopRankApply(string memLoginID, int isaudit)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memLoginID;
            paraName[1] = "@isaudit";
            paraValue[1] = isaudit.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ApplyShopRankList", paraName, paraValue);
        }

        public DataTable GetShopRankByGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopRankByGuid", paraName, paraValue);
        }

        public DataTable ShopRankPayInfoByGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ShopRankPayInfoByGuid", paraName, paraValue);
        }

        public int UpdataShopRank(string ID)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    "update dbo.ShopNum1_ShopInfo SET ShopRank=(select RankGuid from dbo.ShopNum1_Shop_ApplyShopRank where ID in(" +
                    ID + "))  where MemLoginID=(select MemberLoginID from dbo.ShopNum1_Shop_ApplyShopRank where ID in(" +
                    ID + ")) ");
        }

        public int UpdataShopRankPayMentByID(string string_0, string PayMentType, string PayMentName)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            paraName[1] = "@PayMentType";
            paraValue[1] = PayMentType;
            paraName[2] = "@PayMentName";
            paraValue[2] = PayMentName;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataShopRankPayMentByID", paraName, paraValue);
        }

        public int UpdataShopRankPayStatusByID(string string_0)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataShopRankPayStatusByID", paraName, paraValue);
        }

        public int Check(int ID, int isaudit)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@id";
            paraValue[0] = ID.ToString();
            paraName[1] = "@isaudit";
            paraValue[1] = isaudit.ToString();
            return DatabaseExcetue.RunProcedure("Pro_Shop_ApplyShopRankCheck", paraName, paraValue);
        }

        public DataTable CheckIsApplyMax(string memloginID)
        {
            string str = string.Empty;
            str =
                "  SELECT MAX(B.RankValue) FROM ShopNum1_Shop_ApplyShopRank AS A  LEFT JOIN ShopNum1_ShopRank AS  B    ";
            object obj2 = str + "  ON A.RankGuid=b.Guid    ";
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new[]
                    {
                        obj2, "  WHERE  A.MemberLoginID ='", memloginID, "'  AND  A.VerifyTime >'", DateTime.Now,
                        "'    "
                    }));
        }

        public DataTable CheckIsApplyOk(string guid, string memloginID)
        {
            return
                DatabaseExcetue.ReturnDataTable("SELECT *   FROM ShopNum1_Shop_ApplyShopRank WHERE RankGuid='" + guid +
                                                "' AND MemberLoginID='" + memloginID + "'");
        }

        public int DeleteOutRankGuid(string RankGuid, string MemberLoginID)
        {
            return
                DatabaseExcetue.RunNonQuery("   DELETE   ShopNum1_Shop_ApplyShopRank  WHERE  MemberLoginID='" +
                                            MemberLoginID + "' AND  RankGuid NOT IN ('" + RankGuid + "')      ");
        }

        public DataTable GetNowLv(string memloginID)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "  SELECT *   FROM ShopNum1_Shop_ApplyShopRank  WHERE  MemberLoginID='" + memloginID + "'    ");
        }

        public int UpdataShopRank(int ID)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "update dbo.ShopNum1_ShopInfo SET ShopRank=(select RankGuid from dbo.ShopNum1_Shop_ApplyShopRank where ID="
                        , ID,
                        ")  where MemLoginID=(select MemberLoginID from dbo.ShopNum1_Shop_ApplyShopRank where ID=",
                        ID, ") "
                    }));
        }

        public int UpdataShopRank(string RankGuid, string MemberLoginID)
        {
            return
                DatabaseExcetue.RunNonQuery("    UPDATE    ShopNum1_ShopInfo  SET  ShopRank='" + RankGuid +
                                            "'   WHERE     MemLoginID='" + MemberLoginID + "'      ");
        }

        public int UpdataVerifyTime(string VerifyTime, string MemberLoginID)
        {
            return
                DatabaseExcetue.RunNonQuery("    UPDATE    ShopNum1_Shop_ApplyShopRank  SET  VerifyTime='" + VerifyTime +
                                            "'   WHERE    MemberLoginID='" + MemberLoginID + "'      ");
        }
    }
}
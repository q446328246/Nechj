using System;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Ensure_Action
    {
        int Add(ShopNum1_ShopEnsure shopNum1_ShopEnsure);
        int ApplyShopEnsure(ShopNum1_Shop_ApplyEnsure applyEnsure);
        int CheckIsPayMentByID(string guid);
        int Del(string string_0);
        int DelShopEnsureList(string guid);
        DataTable GetCheckedShopEnsureList(string ensureid, string shopid);
        DataTable GetEnsureMoney(Guid guid);
        DataTable GetShopapplyEnsure(string shopid);
        DataTable GetShopapplyEnsureList(string shopid);
        DataTable GetShopapplyNoRegShopEnsureList(string shopid);
        DataTable GetShopEnsure(int int_0);
        DataTable GetShopEnsureList(string name);
        DataTable GetShopEnsureListByMemberLoginID(string memloginid);
        DataTable GetShopEnsureListNew(string shopid);
        DataTable GetShopNotApplyEnsure(string shopid);
        DataTable SearchEnsureApply(string shopid);
        DataTable SearchEnsureApply_List(string name, string isAudit, string shopid);
        DataTable SearchShopEnsureListNew(string memberLoginID);
        int Updata(ShopNum1_ShopEnsure shopNum1_ShopEnsure);
        int UpdataEnsurePayMentByGuid(string guid, string PayMentType, string PayMentName);
        int UpdataEnsurePayStatusByGuid(string guid);
        int UpdataIsAuditByGuid(string guid, int isAudit);
        int UpdateShopEnsureList(string memloginid, string ensureid);
    }
}
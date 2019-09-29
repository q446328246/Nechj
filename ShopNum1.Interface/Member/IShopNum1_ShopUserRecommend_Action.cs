using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;
using System;

namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopUserRecommend_Action
	{
        int Add(ShopNum1_ShopUserRecommend ShopUserRecommend);
        DataTable Search(string memLoginID);
        DataTable SearchMember(string memLoginID);
        int Delete(string RecommendGuid);
        int DeleteBindProductone(string Guid);
        int DeleteBindProduct(string Guid);
        DataTable SearchProduct(string ProductName);
        DataTable SearchBindProduct(string memLoginID);
        int SearchAddBindProduct(string peoductid, string memloginid, ShopNum1_ShopUserRecommendBindProduct ShopUserRecommendBindProduct, string datetime);
        DataTable SelectProdectIDBymenberId(string ProdectID);
        DataTable SelectMoneyByTime(int ID, DateTime StartTime, DateTime OverTime);
        DataTable SelectTimeByMenberId(string memberId);
        DataTable SelectMoneyByMerberTable(string memberID);
        int UpdateMoneyByMerberTable(string memberID, decimal money);
        int UpdateBindProductDate(string memloginid, string datetime);
	}
}

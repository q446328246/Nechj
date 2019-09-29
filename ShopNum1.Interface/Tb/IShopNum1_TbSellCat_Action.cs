using System.Data;
using ShopNum1.TbLinq;

namespace ShopNum1.Interface
{
    public interface IShopNum1_TbSellCat_Action
    {
        decimal CheckSellCatByTb(string shopname, string string_0, string MemloginId);
        bool DeleteSellCat(string shopname, string memlogid, decimal decimal_0, decimal sitecid);
        DataTable GetAllCidByShopName(string shopName, string memlogid);
        DataTable GetSellCat(decimal siteCid);
        bool InsertSellCat(ShopNum1_TbSellCat sellCat);
        bool UpdateSellCat(ShopNum1_TbSellCat sellCat);
    }
}
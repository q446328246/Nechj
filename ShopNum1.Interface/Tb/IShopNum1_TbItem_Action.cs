using System.Data;
using ShopNum1.TbLinq;

namespace ShopNum1.Interface
{
    public interface IShopNum1_TbItem_Action
    {
        string CheckItemByTb(string num_iid, string Memlogid, string shopName);
        string checkItemExists(decimal numiid);
        DataSet checkItemSiteExists(string siteCid);
        DataTable GetAllItem(string shopname, string memlogid);
        bool InsertItem(ShopNum1_TbItem tbitem);
        bool InsertItemSimplify(decimal num_iid, string site_Id, decimal decimal_0, bool isTaobao);
        bool UpdateProductCount(string num_iid, string memlogid, string string_0);
        bool UpdateProductItems(string num_iid, string memlogid, string string_0, string title, string price);
    }
}
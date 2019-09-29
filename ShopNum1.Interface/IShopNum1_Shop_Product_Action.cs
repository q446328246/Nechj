using System.Data;

namespace ShopNum1.Interface
{
	public interface IShopNum1_Shop_Product_Action
	{
        DataTable GetProductSalesOfFinventory(string productid, string startdate, string enddate);
	}
}

namespace ShopNum1.ShopInterface
{
    public interface IShop_Common_Action
    {
        string ComputeDiscountPrice(string discount);
        string ComputeDispatchPrice(string formula);
        string ComputeInvoicePrice(string invoiceTax);
        string ComputeOderPrice(string orderPrice);
        int ReturnMaxID(string orderID, string tableName);
        int ReturnMaxID(string columnName, string shopID, string shopIDValue, string tableName);
        int ReturnMaxIDByMemLoginID(string MemLoginID);
    }
}
using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Common_Action
    {
        DataTable CommonGetPageContent(string perpagenum, string current_page, string tablename, string columnnames,
            string ordername, string searchname, int sdesc);

        DataSet CommonGetPageCount(string perpagenum, string tablename, string searchname);
        string ComputeDiscountPrice(string discount);
        string ComputeDispatchPrice(string formula);
        string ComputeInvoicePrice(string invoiceTax);
        string ComputeOderPrice(string orderPrice);
        int Insert(string strTab, string strColumn, string strInsertValue);
    }
}
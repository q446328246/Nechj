using System.Data;

namespace ShopNum1.Interface
{
    public interface IShopNum1_GroupProduct_Action
    {
        int DeleteButch(string strId);
        DataTable GetGroupProductData(int start, int int_0);
        DataTable SelectGroupByAId(string pagesize, string currentpage, string condition, string resultnum);

        DataTable SelectGroupList(string pagesize, string currentpage, string condition, string resultnum,
            string strordercolumn, string strsortvalue);

        int UpdateGroupAState(string strId, string strState);
        int UpdateGroupState(string strId, string strState);
    }
}
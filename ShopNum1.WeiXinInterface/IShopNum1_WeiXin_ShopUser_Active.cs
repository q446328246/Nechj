using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.WeiXinInterface
{
    public interface IShopNum1_WeiXin_ShopUser_Active
    {
        int AddWeiXinHao(ShopNum1_WeiXin_ShopUser ShopUser);
        DataTable SelectWeiXinHao(string shoploginid);

        DataTable SelectWeiXinStore(string pagesize, string pageid, string resultnum, string condition,
            string ordercolumn, string sortvalue);

        int UpdateWeiXinHao(ShopNum1_WeiXin_ShopUser ShopUser);
    }
}
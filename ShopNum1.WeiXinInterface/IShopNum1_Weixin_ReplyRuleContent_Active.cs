using System.Data;

namespace ShopNum1.WeiXinInterface
{
    public interface IShopNum1_Weixin_ReplyRuleContent_Active
    {
        string Get_Article(string id);
        DataTable GetContentByKey(string shopmemloginid, string keyword);
        DataSet GetContentByMenuId(string id, string menu_type);
        DataTable Select_ContentByRuleId(int ruleid, int msgtype);
    }
}
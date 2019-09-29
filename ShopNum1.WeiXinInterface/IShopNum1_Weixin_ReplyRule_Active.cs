using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.WeiXinInterface
{
    public interface IShopNum1_Weixin_ReplyRule_Active
    {
        bool Delete_ReplyRule(string rules);

        bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist,
            ShopNum1_Weixin_ReplyRuleContent content);

        bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist,
            ShopNum1_Weixin_ReplyRuleContent content, string contentchirlds);

        bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist,
            ShopNum1_Weixin_ReplyRuleContent content, ShopNum1_Weixin_ReplyRuleContentArticle article,
            string contentchirlds);

        bool KeyExists(string shopmemloginid, string keys, string ruleid);
        DataTable Select_AllKeys(string shopmemloginid);
        DataTable SelectArticle(string contentid);
        DataTable SelectContent(string contentid);
        DataSet SelectReplyRule(string ruleid);
        DataSet SelectReplyRule(string shopmemloginid, int msgtype);
        DataTable SelectReplyRule(string shopmemloginid, int msgtype, string ruleid);
    }
}
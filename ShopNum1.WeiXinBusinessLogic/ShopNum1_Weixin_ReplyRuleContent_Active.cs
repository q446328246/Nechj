using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.WeiXinBusinessLogic
{
    public class ShopNum1_Weixin_ReplyRuleContent_Active : IShopNum1_Weixin_ReplyRuleContent_Active
    {
        public string Get_Article(string id)
        {
            return
                DatabaseExcetue.ReturnString(
                    string.Format(
                        "SELECT [ArticleContent] FROM [dbo].[ShopNum1_Weixin_ReplyRuleContentArticle] WHERE ID ='{0}'",
                        id));
        }

        public DataTable GetContentByKey(string shopmemloginid, string keyword)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "with taba as\r\n                                            (\r\n\t                                            select id,RepMsgType from dbo.ShopNum1_Weixin_ReplyRule where [type] = 3 and ShopMemLoginId = '{0}'\r\n                                            )\r\n                                            select RepMsgType,KeyWord,RepMsgContent,Title,Description,Url,Adv_Url from taba \r\n                                            left join dbo.ShopNum1_Weixin_ReplyRuleKey as tabb on taba.id = tabb.ruleid\r\n                                            left join dbo.ShopNum1_Weixin_ReplyRuleContent as tabc on taba.id = tabc.ruleid\r\n                                            where KeyWord = '{1}'\r\n                                            ",
                        shopmemloginid, keyword));
        }

        public DataSet GetContentByMenuId(string id, string menu_type)
        {
            string strSql = string.Empty;
            if (menu_type == "click")
            {
                strSql =
                    string.Format(
                        "select RepMsgType from dbo.ShopNum1_Weixin_ReplyRule where id = (\r\n                                            select ruleid from ShopNum1_Weixin_ReplyRuleKey where keyword = (\r\n                                            select [key] from [ShopNum1_Weixin_ShopMenu] where id = '{0}'));\r\n\r\n                                            select [ID],[RuleId],[RepMsgContent],[Title],[Description],[Url],[Adv_Url] from ShopNum1_Weixin_ReplyRuleContent where ruleid = (\r\n                                            select ruleid from ShopNum1_Weixin_ReplyRuleKey where keyword = (\r\n                                            select [key] from [ShopNum1_Weixin_ShopMenu] where id = '{0}'))",
                        id);
            }
            else if (menu_type == "view")
            {
                strSql = string.Format("select url from [ShopNum1_Weixin_ShopMenu] where id = '{0}'", id);
            }
            return DatabaseExcetue.ReturnDataSet(strSql);
        }

        public DataTable Select_ContentByRuleId(int ruleid, int msgtype)
        {
            string strSql = string.Empty;
            if (msgtype == 0)
            {
                strSql =
                    string.Format(
                        "select RepMsgContent from dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid = '{0}'", ruleid);
            }
            else
            {
                strSql =
                    string.Format(
                        "select ID,ruleid,Title,Description,ImgSrc from dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid = '{0}'\r\n\r\n                                         union \r\n\r\n                                         select ID,ruleid,Title,Description,ImgSrc from dbo.ShopNum1_Weixin_ReplyRuleContent where Id in (\r\n\t                                         select ContentChirldId from dbo.ShopNum1_Weixin_ReplyRuleChirldContent \r\n\t                                         where ContentId = (select ID from dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid = '{0}')\r\n                                         )",
                        ruleid);
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }
    }
}
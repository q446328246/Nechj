using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.WeiXinBusinessLogic
{
    public class ShopNum1_Weixin_ReplyRule_Active : IShopNum1_Weixin_ReplyRule_Active
    {
        public bool Delete_ReplyRule(string rules)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
            builder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
            builder.AppendFormat("delete ShopNum1_Weixin_ReplyRule where [ID] in({0})", rules).AppendLine();
            builder.AppendFormat("delete ShopNum1_Weixin_ReplyRuleKey where [RuleId] in({0})", rules).AppendLine();
            builder.AppendFormat(
                "delete ShopNum1_Weixin_ReplyRuleContentArticle where ContentId in (select ID from ShopNum1_Weixin_ReplyRuleContent where [RuleId] in({0}))",
                rules).AppendLine();
            builder.AppendFormat(
                "delete ShopNum1_Weixin_ReplyRuleChirldContent where ContentId in (select ID from ShopNum1_Weixin_ReplyRuleContent where [RuleId] in({0}))",
                rules).AppendLine();
            builder.AppendFormat("delete ShopNum1_Weixin_ReplyRuleContent where [RuleId] in({0})", rules).AppendLine();
            builder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
            return (DatabaseExcetue.RunNonQuery(builder.ToString()) > 0);
        }

        public bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist,
            ShopNum1_Weixin_ReplyRuleContent content)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
            builder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
            builder.AppendFormat("declare @ruleid int;", new object[0]).AppendLine();
            if (rulemdl.ID == 0)
            {
                builder.AppendFormat(
                    "insert dbo.ShopNum1_Weixin_ReplyRule([Type],[RepMsgType],[Matching],[ShopMemLoginId],[CreateTime]) values('{0}','{1}','{2}','{3}',GetDate())",
                    new object[] {rulemdl.Type, rulemdl.RepMsgType, rulemdl.Matching, rulemdl.ShopMemLoginId})
                    .AppendLine();
                builder.AppendFormat("SELECT @ruleid = @@IDENTITY", new object[0]).AppendLine();
            }
            else
            {
                builder.AppendFormat(
                    "update dbo.ShopNum1_Weixin_ReplyRule set [Type] = '{0}',RepMsgType ='{1}',Matching ='{2}' where ID = '{3}'",
                    new object[] {rulemdl.Type, rulemdl.RepMsgType, rulemdl.Matching, rulemdl.ID}).AppendLine();
                builder.AppendFormat("set @ruleid = '{0}'", rulemdl.ID).AppendLine();
            }
            builder.AppendFormat("delete ShopNum1_Weixin_ReplyRuleKey where [RuleId] = @ruleid", new object[0])
                .AppendLine();
            builder.AppendFormat("delete ShopNum1_Weixin_ReplyRuleContent where [RuleId] = @ruleid", new object[0])
                .AppendLine();
            foreach (ShopNum1_Weixin_ReplyRuleKey key in keylist)
            {
                builder.AppendFormat(
                    "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleKey]([RuleId],[KeyWord])     \r\n                                              VALUES(@ruleid,'{0}')",
                    key.KeyWord).AppendLine();
            }
            builder.AppendFormat(
                "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleContent]([RuleId],[RepMsgContent],[Title],[Description],[ImgSrc])\r\n                                            VALUES(@ruleid,'{0}','{1}','{2}','{3}')",
                new object[] {content.RepMsgContent, content.Title, content.Description, content.ImgSrc}).AppendLine();
            builder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
            return (DatabaseExcetue.RunNonQuery(builder.ToString()) > 0);
        }

        public bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist,
            ShopNum1_Weixin_ReplyRuleContent content, string contentchirlds)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
            builder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
            builder.AppendFormat("declare @ruleid int;", new object[0]).AppendLine();
            builder.AppendFormat("declare @rulecontentid int;", new object[0]).AppendLine();
            if (rulemdl.ID == 0)
            {
                builder.AppendFormat(
                    "insert dbo.ShopNum1_Weixin_ReplyRule([Type],[RepMsgType],[Matching],[ShopMemLoginId],[CreateTime]) values('{0}','{1}','{2}','{3}',GetDate())",
                    new object[] {rulemdl.Type, rulemdl.RepMsgType, rulemdl.Matching, rulemdl.ShopMemLoginId})
                    .AppendLine();
                builder.AppendFormat("SELECT @ruleid = @@IDENTITY", new object[0]).AppendLine();
            }
            else
            {
                builder.AppendFormat(
                    "update dbo.ShopNum1_Weixin_ReplyRule set [Type] = '{0}',RepMsgType ='{1}',Matching ='{2}' where ID = '{3}'",
                    new object[] {rulemdl.Type, rulemdl.RepMsgType, rulemdl.Matching, rulemdl.ID}).AppendLine();
                builder.AppendFormat("set @ruleid = '{0}'", rulemdl.ID).AppendLine();
            }
            builder.AppendFormat("delete ShopNum1_Weixin_ReplyRuleKey where [RuleId] = @ruleid", new object[0])
                .AppendLine();
            builder.AppendFormat(
                "delete ShopNum1_Weixin_ReplyRuleChirldContent where [ContentId] = (select id from dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid = @ruleid)",
                new object[0]).AppendLine();
            builder.AppendFormat("delete ShopNum1_Weixin_ReplyRuleContent where [RuleId] = @ruleid", new object[0])
                .AppendLine();
            foreach (ShopNum1_Weixin_ReplyRuleKey key in keylist)
            {
                builder.AppendFormat(
                    "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleKey]([RuleId],[KeyWord])     \r\n                                              VALUES(@ruleid,'{0}')",
                    key.KeyWord).AppendLine();
            }
            builder.AppendFormat(
                "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleContent]([RuleId],[RepMsgContent],[Title],[Description],[ImgSrc])\r\n                                            VALUES(@ruleid,'{0}','{1}','{2}','{3}')",
                new object[] {content.RepMsgContent, content.Title, content.Description, content.ImgSrc}).AppendLine();
            builder.AppendFormat("SELECT @rulecontentid = @@IDENTITY", new object[0]).AppendLine();
            foreach (string str in contentchirlds.Split(new[] {','}))
            {
                builder.AppendFormat(
                    "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleChirldContent]\r\n                                      ([ContentId],[ContentChirldId]) VALUES(@rulecontentid,'{0}')",
                    str).AppendLine();
            }
            builder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
            return (DatabaseExcetue.RunNonQuery(builder.ToString()) > 0);
        }

        public bool InsertRule(ShopNum1_Weixin_ReplyRule rulemdl, List<ShopNum1_Weixin_ReplyRuleKey> keylist,
            ShopNum1_Weixin_ReplyRuleContent content, ShopNum1_Weixin_ReplyRuleContentArticle article,
            string contentchirlds)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
            builder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
            builder.AppendFormat("declare @ruleid int;", new object[0]).AppendLine();
            builder.AppendFormat("declare @rulecontentid int;", new object[0]).AppendLine();
            if (rulemdl.ID == 0)
            {
                builder.AppendFormat(
                    "insert dbo.ShopNum1_Weixin_ReplyRule([Type],[RepMsgType],[Matching],[ShopMemLoginId],[CreateTime]) values('{0}','{1}','{2}','{3}',GetDate())",
                    new object[] {rulemdl.Type, rulemdl.RepMsgType, rulemdl.Matching, rulemdl.ShopMemLoginId})
                    .AppendLine();
                builder.AppendFormat("SELECT @ruleid = @@IDENTITY", new object[0]).AppendLine();
            }
            else
            {
                builder.AppendFormat(
                    "update dbo.ShopNum1_Weixin_ReplyRule set [Type] = '{0}',RepMsgType ='{1}',Matching ='{2}' where ID = '{3}'",
                    new object[] {rulemdl.Type, rulemdl.RepMsgType, rulemdl.Matching, rulemdl.ID}).AppendLine();
                builder.AppendFormat("set @ruleid = '{0}'", rulemdl.ID).AppendLine();
            }
            foreach (ShopNum1_Weixin_ReplyRuleKey key in keylist)
            {
                if (rulemdl.ID == 0)
                {
                    builder.AppendFormat(
                        "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleKey]([RuleId],[KeyWord])     \r\n                                              VALUES(@ruleid,'{0}')",
                        key.KeyWord).AppendLine();
                }
                else
                {
                    builder.AppendFormat(
                        "Update [dbo].[ShopNum1_Weixin_ReplyRuleKey] set [KeyWord]='{0}' where [RuleId]=@ruleid",
                        key.KeyWord).AppendLine();
                }
            }
            if (rulemdl.ID == 0)
            {
                builder.AppendFormat(
                    "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleContent]([RuleId],[RepMsgContent],[Title],[Description],[ImgSrc])\r\n                                            VALUES(@ruleid,'{0}','{1}','{2}','{3}')",
                    new object[] {content.RepMsgContent, content.Title, content.Description, content.ImgSrc})
                    .AppendLine();
                builder.AppendFormat("SELECT @rulecontentid = @@IDENTITY", new object[0]).AppendLine();
            }
            else
            {
                builder.AppendFormat(
                    "Update ShopNum1_Weixin_ReplyRuleContent set Title='" + content.Title + "',RepMsgContent='" +
                    content.RepMsgContent + "',Description='" + content.Description + "',ImgSrc='" + content.ImgSrc +
                    "'  where [RuleId] = @ruleid", new object[0]).AppendLine();
                builder.AppendFormat("set @rulecontentid =@ruleid ", new object[0]).AppendLine();
            }
            if (article.ID == 0)
            {
                builder.AppendFormat(
                    "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleContentArticle]([ContentID],[Type],[ArticleContent])\r\n                                      VALUES(@rulecontentid,'{0}','{1}')",
                    article.Type, article.ArticleContent).AppendLine();
            }
            else
            {
                builder.AppendFormat(
                    "update [dbo].[ShopNum1_Weixin_ReplyRuleContentArticle] set [Type] = '{0}',[ContentID] = @rulecontentid, [ArticleContent] = '{1}' where ID = '{2}'",
                    article.Type, article.ArticleContent, article.ID).AppendLine();
            }
            if (!string.IsNullOrEmpty(contentchirlds))
            {
                builder.AppendFormat(
                    "Delete [dbo].[ShopNum1_Weixin_ReplyRuleChirldContent] where ContentId=@rulecontentid",
                    new object[0]).AppendLine();
                foreach (string str in contentchirlds.Split(new[] {','}))
                {
                    builder.AppendFormat(
                        "INSERT INTO [dbo].[ShopNum1_Weixin_ReplyRuleChirldContent]\r\n                                      ([ContentId],[ContentChirldId]) VALUES(@rulecontentid,'{0}')",
                        str).AppendLine();
                }
            }
            builder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
            return (DatabaseExcetue.RunNonQuery(builder.ToString()) > 0);
        }

        public bool KeyExists(string shopmemloginid, string keys, string ruleid)
        {
            string strSql =
                string.Format(
                    "select count(1) from ShopNum1_Weixin_ReplyRuleKey \r\n                                            where ruleid in (select id from dbo.ShopNum1_Weixin_ReplyRule where ShopMemLoginId='{0}')\r\n\t                                        and keyword in ({1}) and ruleid <> '{2}'",
                    shopmemloginid, keys, ruleid);
            return (string.IsNullOrEmpty(DatabaseExcetue.ReturnString(strSql)) ||
                    !(DatabaseExcetue.ReturnString(strSql) == "0"));
        }

        public DataTable Select_AllKeys(string shopmemloginid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "select ruleid,keyword,RepMsgType,Matching from dbo.ShopNum1_Weixin_ReplyRuleKey as taba \r\n                                            right join (select id,RepMsgType,Matching from dbo.ShopNum1_Weixin_ReplyRule  where ShopMemLoginId = '{0}') as tabb on taba.ruleid = tabb.id\r\n                                            ",
                        shopmemloginid));
        }

        public DataTable SelectArticle(string contentid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "select ID,ContentID,[Type],ArticleContent from dbo.ShopNum1_Weixin_ReplyRuleContentArticle where ContentID = '{0}'",
                        contentid));
        }

        public DataTable SelectContent(string contentid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "SELECT [ID],[RuleId],[RepMsgContent],[Title],[Description],[ImgSrc] FROM [dbo].[ShopNum1_Weixin_ReplyRuleContent]\r\n                                            WHERE [ID] IN (SELECT ContentChirldId FROM ShopNum1_Weixin_ReplyRuleChirldContent WHERE ContentId = '{0}')",
                        contentid));
        }

        public DataSet SelectReplyRule(string ruleid)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(
                "select [ID],[Type],[RepMsgType],[Matching],[ShopMemLoginId],[CreateTime] from dbo.ShopNum1_Weixin_ReplyRule where id = '{0}'",
                ruleid).AppendLine();
            builder.AppendFormat(
                "select [ID],[RuleId],[KeyWord] from dbo.ShopNum1_Weixin_ReplyRuleKey where ruleid = '{0}'", ruleid)
                .AppendLine();
            builder.AppendFormat(
                "select [ID],[RuleId],[RepMsgContent],[Title],[Description],[ImgSrc] from dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid = '{0}'",
                ruleid).AppendLine();
            return DatabaseExcetue.ReturnDataSet(builder.ToString());
        }

        public DataSet SelectReplyRule(string shopmemloginid, int msgtype)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(
                "select ID into #temp from dbo.ShopNum1_Weixin_ReplyRule where [ShopMemLoginId] = '{0}' and RepMsgType = '{1}'",
                shopmemloginid, msgtype).AppendLine();
            builder.AppendFormat(
                "select [ID],[Type],[RepMsgType],[Matching],[ShopMemLoginId],[CreateTime] from dbo.ShopNum1_Weixin_ReplyRule where id in (select ID from #temp) order by CreateTime desc",
                new object[0]).AppendLine();
            builder.AppendFormat(
                "select [ID],[RuleId],[KeyWord] from dbo.ShopNum1_Weixin_ReplyRuleKey where ruleid in (select ID from #temp)",
                new object[0]).AppendLine();
            builder.AppendFormat(
                "select [ID],[RuleId],[RepMsgContent],[Title],[Description],[ImgSrc] from dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid in (select ID from #temp)",
                new object[0]).AppendLine();
            return DatabaseExcetue.ReturnDataSet(builder.ToString());
        }

        public DataTable SelectReplyRule(string shopmemloginid, int msgtype, string ruleid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "select [ID],[RuleId],[RepMsgContent],[Title],[Description],[ImgSrc] from dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid in (select ID from dbo.ShopNum1_Weixin_ReplyRule where [ShopMemLoginId] = '{0}' and RepMsgType = '{1}' and ID <> '{2}') ",
                        shopmemloginid, msgtype, ruleid));
        }
    }
}
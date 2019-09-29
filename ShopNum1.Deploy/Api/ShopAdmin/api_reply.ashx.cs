using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.Common;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinCommon;
using ShopNum1.WeiXinCommon.Enum;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// api_reply 的摘要说明
    /// </summary>
    public class api_reply : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.QueryString["type"] ?? context.Request.Form["type"] ?? string.Empty;

            string shopmemloginid = GetMemLoginId(context);

            //登录验证
            if (string.IsNullOrEmpty(shopmemloginid))
            {
                context.Response.Write("{\"errcode\":-1,\"errmsg\":\"无用户登录!\"}");
                return;
            }

            IShopNum1_Weixin_ReplyRule_Active shopnum1_weixin_replyrule_active = new ShopNum1_Weixin_ReplyRule_Active();

            switch (type.ToLower())
            {
                //操作文字回复
                case "op_replytxt":
                    string op_keys = Operator.FilterString(context.Request["keys"] ?? string.Empty);
                    string op_msgtype = context.Request["msgtype"] ?? string.Empty;
                    string op_content = Operator.FilterString(context.Request["content"] ?? string.Empty);

                    op_content = op_content.Replace("<", "&lt;").Replace(">", "&gt;");

                    string op_ruleid = context.Request["ruleid"] ?? string.Empty;


                    //构建规则实体
                    var rulemodel = new ShopNum1_Weixin_ReplyRule();
                    rulemodel.ID = !string.IsNullOrEmpty(op_ruleid) ? Convert.ToInt32(op_ruleid) : 0;
                    rulemodel.RepMsgType = (int)MsgType.TxtMsg;
                    rulemodel.Matching = Convert.ToByte(op_msgtype);
                    rulemodel.ShopMemLoginId = shopmemloginid;

                    var keys = new StringBuilder();

                    //构建关键字实体
                    var rulekeylist = new List<ShopNum1_Weixin_ReplyRuleKey>();
                    ShopNum1_Weixin_ReplyRuleKey keymodel;
                    foreach (string key in op_keys.Split(' '))
                    {
                        if (!string.IsNullOrEmpty(key) && !rulekeylist.Exists(mdl => mdl.KeyWord == key))
                        {
                            keys.AppendFormat("'{0}',", key);

                            keymodel = new ShopNum1_Weixin_ReplyRuleKey();
                            keymodel.KeyWord = key;
                            rulekeylist.Add(keymodel);
                        }
                    }

                    //构建回复内容实体
                    var contentmodel = new ShopNum1_Weixin_ReplyRuleContent();
                    contentmodel.RepMsgContent = op_content;


                    //检查关键字是否已存在 添加操作时 验证关键字是否存在
                    if (
                        !shopnum1_weixin_replyrule_active.KeyExists(shopmemloginid, StringHelper.RemoveLast(keys.ToString()),
                                                                    op_ruleid))
                    {
                        if (shopnum1_weixin_replyrule_active.InsertRule(rulemodel, rulekeylist, contentmodel))
                        {
                            context.Response.Write("{\"errcode\":0,\"errmsg\":\"操作成功!\"}");
                        }
                        else
                        {
                            context.Response.Write("{\"errcode\":-1,\"errmsg\":\"操作失败!\"}");
                        }
                    }
                    else
                    {
                        context.Response.Write("{\"errcode\":-1,\"errmsg\":\"关键词已存在!\"}");
                    }
                    break;

                case "del_replytxt":

                    string del_ruleid = context.Request["ruleids"] ?? string.Empty;

                    if (shopnum1_weixin_replyrule_active.Delete_ReplyRule(del_ruleid))
                    {
                        context.Response.Write("{\"errcode\":0,\"errmsg\":\"删除成功!\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"errcode\":-1,\"errmsg\":\"删除失败!\"}");
                    }

                    break;

                case "op_replyimgtxt":

                    string opimgtxt_keys = Operator.FilterString(context.Request.Form["keys"] ?? string.Empty);
                    string opimgtxt_msgtype = context.Request.Form["msgtype"] ?? string.Empty;
                    string opimgtxt_title = Operator.FilterString(context.Request.Form["title"] ?? string.Empty);
                    string opimgtxt_image = context.Request.Form["image"] ?? string.Empty;
                    string opimgtxt_desc = Operator.FilterString(context.Request.Form["desc"] ?? string.Empty);
                    string opimgtxt_articltype = context.Request.Form["articltype"] ?? string.Empty;
                    string opimgtxt_articlecontent = context.Request.Form["articlecontent"] ?? string.Empty;
                    opimgtxt_articlecontent = opimgtxt_articlecontent.Replace("'", "");
                    string opimgtxt_ruleid = context.Request.Form["ruleid"] ?? string.Empty;
                    string opimgtxt_article = context.Request.Form["article"] ?? string.Empty;
                    string opimgtxt_chirldids = context.Request.Form["chirldids"] ?? string.Empty;

                    //构建规则实体
                    rulemodel = new ShopNum1_Weixin_ReplyRule();
                    rulemodel.ID = !string.IsNullOrEmpty(opimgtxt_ruleid) ? Convert.ToInt32(opimgtxt_ruleid) : 0;
                    rulemodel.RepMsgType = (int)MsgType.TxtImgMsg;

                    rulemodel.Matching = Convert.ToByte(opimgtxt_msgtype);

                    rulemodel.ShopMemLoginId = shopmemloginid;

                    keys = new StringBuilder();

                    //构建关键字实体
                    rulekeylist = new List<ShopNum1_Weixin_ReplyRuleKey>();
                    foreach (string key in opimgtxt_keys.Split(' '))
                    {
                        if (!string.IsNullOrEmpty(key) && !rulekeylist.Exists(mdl => mdl.KeyWord == key))
                        {
                            keys.AppendFormat("'{0}',", key);

                            keymodel = new ShopNum1_Weixin_ReplyRuleKey();
                            keymodel.KeyWord = key;
                            rulekeylist.Add(keymodel);
                        }
                    }

                    //构建回复内容实体
                    contentmodel = new ShopNum1_Weixin_ReplyRuleContent();
                    contentmodel.Title = opimgtxt_title;
                    contentmodel.Description = opimgtxt_desc;
                    contentmodel.ImgSrc = opimgtxt_image;


                    //检查关键字是否已存在 添加操作时 验证关键字是否存在
                    if (
                        !shopnum1_weixin_replyrule_active.KeyExists(shopmemloginid, StringHelper.RemoveLast(keys.ToString()),
                                                                    opimgtxt_ruleid))
                    {
                        //构建图片链接文章实体
                        var articlemodel = new ShopNum1_Weixin_ReplyRuleContentArticle();
                        articlemodel.ID = Convert.ToInt32(opimgtxt_article);
                        articlemodel.Type = Convert.ToByte(opimgtxt_articltype);
                        articlemodel.ArticleContent = opimgtxt_articlecontent;
                        if (shopnum1_weixin_replyrule_active.InsertRule(rulemodel, rulekeylist, contentmodel, articlemodel,
                                                                        opimgtxt_chirldids))
                        {
                            context.Response.Write("{\"errcode\":0,\"errmsg\":\"操作成功!\"}");
                        }
                        else
                        {
                            context.Response.Write("{\"errcode\":-1,\"errmsg\":\"操作失败!\"}");
                        }
                    }
                    else
                    {
                        context.Response.Write("{\"errcode\":-1,\"errmsg\":\"关键词已存在!\"}");
                    }

                    break;

                case "get_allcontent":

                    string get_ruleid = context.Request["ruleid"] ?? string.Empty;
                    shopnum1_weixin_replyrule_active = new ShopNum1_Weixin_ReplyRule_Active();
                    DataTable dt = shopnum1_weixin_replyrule_active.SelectReplyRule(shopmemloginid, (int)MsgType.TxtImgMsg,
                                                                                    get_ruleid);
                    if (dt.Rows.Count != 0)
                    {
                        context.Response.Write(StringHelper.ReturnJson(getcontentlist(dt)));
                    }
                    else
                    {
                        context.Response.Write(string.Empty);
                    }
                    break;

                default:
                    break;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        //获取登录用户方法
        private string GetMemLoginId(HttpContext context)
        {
            string name = string.Empty;
            HttpCookie cookies = context.Request.Cookies["MemberLoginCookie"];
            if (cookies != null)
            {
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookies);
                name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
            }
            return name;
        }

        /// <summary>
        ///   返回回复实体
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<ShopNum1_Weixin_ReplyRuleContent> getcontentlist(DataTable dt)
        {
            var contentlist = new List<ShopNum1_Weixin_ReplyRuleContent>();
            ShopNum1_Weixin_ReplyRuleContent content;
            foreach (DataRow dr in dt.Rows)
            {
                content = new ShopNum1_Weixin_ReplyRuleContent();
                content.ID = Convert.ToInt32(dr["ID"]);
                content.RuleId = Convert.ToInt32(dr["RuleId"]);
                content.RepMsgContent = Convert.ToString(dr["RepMsgContent"]);
                content.Title = Convert.ToString(dr["Title"]);
                content.Description = Convert.ToString(dr["Description"]);
                content.ImgSrc = Convert.ToString(dr["ImgSrc"]);
                contentlist.Add(content);
            }

            return contentlist;
        }
    }
}
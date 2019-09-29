using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class DiscuzSession
    {
        private readonly string string_1;
        private readonly Util util_0;
        public SessionInfo session_info;
        private string string_0;

        public DiscuzSession(string api_key, SessionInfo session_info, string forum_url)
            : this(api_key, session_info.Secret, forum_url)
        {
            this.session_info = session_info;
            string_1 = forum_url;
        }

        public DiscuzSession(string api_key, string shared_secret, string forum_url)
        {
            util_0 = new Util(api_key, shared_secret, forum_url + "/services/restserver.aspx?");
            string_1 = forum_url;
        }

        internal string SessionKey
        {
            get { return session_info.SessionKey; }
        }

        internal Util Util
        {
            get { return util_0; }
        }

        public bool ChangeUserPassword(long long_0, string originalPassword, string newPassword,
            string confirmNewPassword, string passwordFormat)
        {
            var list = new List<DiscuzParam>
            {
                DiscuzParam.Create("uid", long_0),
                DiscuzParam.Create("original_password", originalPassword),
                DiscuzParam.Create("new_password", newPassword),
                DiscuzParam.Create("confirm_new_password", confirmNewPassword),
                DiscuzParam.Create("password_format", passwordFormat)
            };
            return (util_0.GetResponse<ChangePasswordResponse>("users.changePassword", list.ToArray()).Result == 1);
        }

        public Uri CreateToken()
        {
            return new Uri(string.Format("{0}/login.aspx?api_key={1}", string_1, util_0.ApiKey));
        }

        public string CreateTokenForClient()
        {
            return util_0.GetResponse<TokenInfo>("auth.createToken", new DiscuzParam[0]).Token;
        }

        public TopicCreateResponse CreateTopic(string title, int int_0, string message, int icon_id, string tags)
        {
            return CreateTopic(0, title, int_0, message, icon_id, tags);
        }

        public TopicCreateResponse CreateTopic(int int_0, string title, int int_1, string message, int icon_id,
            string tags)
        {
            var topic = new Topic
            {
                UId = (int_0 == 0) ? ((int) session_info.UId) : int_0,
                Title = title,
                Fid = int_1,
                Message = message,
                Iconid = icon_id,
                Tags = tags
            };
            var list = new List<DiscuzParam>();
            if (int_0 == 0)
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("topic_info", JsonConvert.SerializeObject(topic)));
            return util_0.GetResponse<TopicCreateResponse>("topics.create", list.ToArray());
        }

        public TopicDeleteResponse DeleteTopic(string topicids)
        {
            return DeleteTopic(topicids, 0);
        }

        public TopicDeleteResponse DeleteTopic(string topicids, int forumid)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("topic_ids", topicids));
            if (forumid > 0)
            {
                list.Add(DiscuzParam.Create("fid", forumid));
            }
            return util_0.GetResponse<TopicDeleteResponse>("topics.delete", list.ToArray());
        }

        public TopicDeleteRepliesResponse DeleteTopicReplies(int int_0, string postids)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("tid", int_0));
            list.Add(DiscuzParam.Create("post_ids", postids));
            return util_0.GetResponse<TopicDeleteRepliesResponse>("topics.deletereplies", list.ToArray());
        }

        public TopicEditResponse EditTopic(int int_0, Topic topic)
        {
            return EditTopic(int_0, Util.RemoveJsonNull(JsonConvert.SerializeObject(topic)));
        }

        public TopicEditResponse EditTopic(int int_0, string jsonTopicInfo)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("tid", int_0));
            list.Add(DiscuzParam.Create("topic_info", jsonTopicInfo));
            return util_0.GetResponse<TopicEditResponse>("topics.edit", list.ToArray());
        }

        public string EncodePassword(string password, bool isMD5Passwd)
        {
            var list = new List<DiscuzParam>
            {
                DiscuzParam.Create("password", password)
            };
            if (isMD5Passwd)
            {
                list.Add(DiscuzParam.Create("password_format", "md5"));
            }
            return util_0.GetResponse<EncodePasswordResponse>("auth.encodePassword", list.ToArray()).Password;
        }

        public CreateForumResponse ForumCreate(Forum forum)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("forum_info", JsonConvert.SerializeObject(forum)));
            return util_0.GetResponse<CreateForumResponse>("forums.create", list.ToArray());
        }

        public GetForumResponse ForumGet(int int_0)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("fid", int_0));
            return util_0.GetResponse<GetForumResponse>("forums.get", list.ToArray());
        }

        public GetIndexListResponse ForumGetIndexList()
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            return util_0.GetResponse<GetIndexListResponse>("forums.getindexlist", list.ToArray());
        }

        public ForumTopic[] GetAttentionTopicList(int int_0, int page_size, int page_index)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("fid", int_0));
            list.Add(DiscuzParam.Create("page_size", page_size));
            list.Add(DiscuzParam.Create("page_index", page_index));
            return util_0.GetResponse<TopicGetListResponse>("topics.getAttentionList", list.ToArray()).Topics;
        }

        public Me GetLoggedInUser()
        {
            return new Me(session_info.UId, this);
        }

        public Post[] GetRecentReplies(int int_0, int int_1, int page_size, int page_index)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("fid", int_0));
            list.Add(DiscuzParam.Create("tid", int_1));
            list.Add(DiscuzParam.Create("page_size", page_size));
            list.Add(DiscuzParam.Create("page_index", page_index));
            return util_0.GetResponse<TopicGetRencentRepliesResponse>("topics.getRecentReplies", list.ToArray()).Posts;
        }

        public SessionInfo GetSessionFromToken(string auth_token)
        {
            session_info = util_0.GetResponse<SessionInfo>("auth.getSession",
                new[] {DiscuzParam.Create("auth_token", auth_token)});
            string_0 = string.Empty;
            session_info.Secret = util_0.SharedSecret;
            return session_info;
        }

        public TopicGetResponse GetTopic(int int_0, int pageindex, int pagesize)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("tid", int_0));
            list.Add(DiscuzParam.Create("page_index", pageindex));
            list.Add(DiscuzParam.Create("page_size", pagesize));
            return util_0.GetResponse<TopicGetResponse>("topics.get", list.ToArray());
        }

        public ForumTopic[] GetTopicList(int int_0, int page_size, int page_index)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("fid", int_0));
            list.Add(DiscuzParam.Create("page_size", page_size));
            list.Add(DiscuzParam.Create("page_index", page_index));
            return util_0.GetResponse<TopicGetListResponse>("topics.getList", list.ToArray()).Topics;
        }

        public int GetUserID(string username)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("user_name", username));
            return util_0.GetResponse<GetIDResponse>("users.getID", list.ToArray()).UId;
        }

        public User GetUserInfo(long long_0)
        {
            User[] userInfo = GetUserInfo(new[] {long_0}, User.FIELDS);
            if (userInfo.Length < 1)
            {
                return null;
            }
            return userInfo[0];
        }

        public User[] GetUserInfo(long[] uids, string[] fields)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            if ((uids == null) || (uids.Length == 0))
            {
                throw new Exception("uid not provided");
            }
            list.Add(DiscuzParam.Create("uids", uids));
            list.Add(DiscuzParam.Create("fields", fields));
            return util_0.GetResponse<UserInfoResponse>("users.getInfo", list.ToArray()).Users;
        }

        public MessagesGetResponse GetUserMessages(int int_0, int pagesize, int pageindex)
        {
            var list = new List<DiscuzParam>
            {
                DiscuzParam.Create("uid", int_0),
                DiscuzParam.Create("page_size", pagesize),
                DiscuzParam.Create("page_index", pageindex)
            };
            return util_0.GetResponse<MessagesGetResponse>("messages.get", list.ToArray());
        }

        public void Login(int int_0, string password, bool isMD5Passwd, int expires, string cookieDomain)
        {
            User userInfo = GetUserInfo(int_0);
            var cookie = new HttpCookie("dnt");
            cookie.Values["userid"] = userInfo.UId.ToString();
            cookie.Values["password"] = EncodePassword(password, isMD5Passwd);
            cookie.Values["avatar"] = HttpUtility.UrlEncode(userInfo.Avatar);
            cookie.Values["tpp"] = userInfo.Tpp.ToString();
            cookie.Values["ppp"] = userInfo.Ppp.ToString();
            cookie.Values["invisible"] = userInfo.Invisible.ToString();
            cookie.Values["referer"] = "index.aspx";
            cookie.Values["expires"] = expires.ToString();
            if (expires > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }
            cookie.Domain = cookieDomain;
            cookie.Secure = false;
            cookie.Path = "/";
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public void Logout(string domain)
        {
            var cookie = new HttpCookie("dnt");
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            cookie.Domain = domain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public GetNotiificationResponse NotificationGet()
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
                return util_0.GetResponse<GetNotiificationResponse>("notifications.get", list.ToArray());
            }
            return null;
        }

        public string NotificationSendEmail(string recipients, string subject, string text)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("recipients", recipients));
            list.Add(DiscuzParam.Create("subject", subject));
            list.Add(DiscuzParam.Create("text", text));
            return
                (util_0.GetResponse<SendNotificationEmailResponse>("notifications.sendEmail", list.ToArray()).Recipients
                    = recipients);
        }

        public string NotificationsSend(string notification, string to_ids, int int_0)
        {
            var list = new List<DiscuzParam>();
            if (!(((int_0 >= 1) || (session_info == null)) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("to_ids", to_ids));
            list.Add(DiscuzParam.Create("notification", notification));
            return util_0.GetResponse<SendNotificationResponse>("notifications.send", list.ToArray()).Result;
        }

        public int Register(string username, string password, string email, bool isMD5Passwd)
        {
            var list = new List<DiscuzParam>
            {
                DiscuzParam.Create("user_name", username),
                DiscuzParam.Create("password", password),
                DiscuzParam.Create("email", email)
            };
            if (isMD5Passwd)
            {
                list.Add(DiscuzParam.Create("password_format", "md5"));
            }
            return util_0.GetResponse<RegisterResponse>("auth.register", list.ToArray()).Uid;
        }

        public string SendMessages(string to_uids, string fromid, string subject, string message)
        {
            var list = new List<DiscuzParam>
            {
                DiscuzParam.Create("to_ids", to_uids),
                DiscuzParam.Create("from_id", fromid),
                DiscuzParam.Create("subject", subject),
                DiscuzParam.Create("message", message)
            };
            return util_0.GetResponse<MessagesSendResponse>("messages.send", list.ToArray()).Result;
        }

        public bool SetExtCredits(string uids, string additional_values)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("uids", uids));
            list.Add(DiscuzParam.Create("additional_values", additional_values));
            return (util_0.GetResponse<SetExtCreditsResponse>("users.setExtCredits", list.ToArray()).Successfull == 1);
        }

        public bool SetUserInfo(int int_0, UserForEditing user_for_editing)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("uid", int_0));
            list.Add(DiscuzParam.Create("user_info", JsonConvert.SerializeObject(user_for_editing)));
            return (util_0.GetResponse<SetInfoResponse>("users.setInfo", list.ToArray()).Successfull == 1);
        }

        public TopicReplyResponse TopicReply(Reply reply)
        {
            var list = new List<DiscuzParam>();
            if (!((session_info == null) || string.IsNullOrEmpty(session_info.SessionKey)))
            {
                list.Add(DiscuzParam.Create("session_key", session_info.SessionKey));
            }
            list.Add(DiscuzParam.Create("reply_info", JsonConvert.SerializeObject(reply)));
            return util_0.GetResponse<TopicReplyResponse>("topics.reply", list.ToArray());
        }
    }
}
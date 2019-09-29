using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class User : Friend
    {
        public static readonly string[] FIELDS =
        {
            "uid", "user_name", "nick_name", "password", "space_id", "secques", "gender", "admin_id", "group_id",
            "group_expiry", "reg_ip", "join_date", "last_ip", "last_visit", "last_activity", "last_post",
            "last_post_id", "last_post_title", "post_count", "digest_post_count", "online_time", "page_view_count",
            "credits", "ext_credits_1", "ext_credits_2", "ext_credits_3", "ext_credits_4", "ext_credits_5",
            "ext_credits_6", "ext_credits_7", "ext_credits_8", "email",
            "birthday", "tpp", "ppp", "template_id", "pm_sound", "show_email", "invisible", "has_new_pm",
            "new_pm_count", "access_masks", "online_state", "web_site", "icq", "qq", "yahoo", "msn",
            "skype", "location", "custom_status", "avatar", "avatar_width", "avatar_height", "medals", "about_me",
            "sign_html", "real_name", "id_card", "mobile", "telephone"
        };

        [XmlElement("access_masks", IsNullable = true), JsonProperty("access_masks")] public int? AccessMasks;
        [XmlElement("admin_id", IsNullable = true), JsonProperty("admin_id")] public int? Adminid;
        [XmlIgnore, JsonIgnore] public byte AuthFlag;
        [XmlIgnore, JsonIgnore] public string AuthStr;
        [JsonIgnore, XmlIgnore] public string AuthTime;
        [XmlElement("avatar", IsNullable = true), JsonProperty("avatar")] public string Avatar;
        [XmlElement("avatar_height", IsNullable = true), JsonProperty("avatar_height")] public int? AvatarHeight;
        [XmlIgnore, JsonIgnore] public int? AvatarShowId;
        [JsonProperty("avatar_width"), XmlElement("avatar_width", IsNullable = true)] public int? AvatarWidth;
        [JsonProperty("about_me"), XmlElement("about_me", IsNullable = true)] public string Bio;
        [JsonProperty("birthday"), XmlElement("birthday", IsNullable = true)] public string Birthday;
        [XmlElement("credits", IsNullable = true), JsonProperty("credits")] public int? Credits;
        [XmlElement("custom_status", IsNullable = true), JsonProperty("custom_status")] public string CustomStatus;
        [JsonProperty("digest_post_count"), XmlElement("digest_post_count", IsNullable = true)] public int? DigestPosts;
        [JsonProperty("email"), XmlElement("email", IsNullable = true)] public string Email;
        [XmlElement("ext_credits_1", IsNullable = true), JsonProperty("ext_credits_1")] public float? ExtCredits1;
        [XmlElement("ext_credits_2", IsNullable = true), JsonProperty("ext_credits_2")] public float? ExtCredits2;
        [XmlElement("ext_credits_3", IsNullable = true), JsonProperty("ext_credits_3")] public float? ExtCredits3;
        [XmlElement("ext_credits_4", IsNullable = true), JsonProperty("ext_credits_4")] public float? ExtCredits4;
        [JsonProperty("ext_credits_5"), XmlElement("ext_credits_5", IsNullable = true)] public float? ExtCredits5;
        [JsonProperty("ext_credits_6"), XmlElement("ext_credits_6", IsNullable = true)] public float? ExtCredits6;
        [JsonProperty("ext_credits_7"), XmlElement("ext_credits_7", IsNullable = true)] public float? ExtCredits7;
        [XmlElement("ext_credits_8", IsNullable = true), JsonProperty("ext_credits_8")] public float? ExtCredits8;
        [JsonProperty("ext_groupids"), XmlElement("ext_groupids", IsNullable = true)] public string ExtGroupids;

        [XmlElement("gender", IsNullable = true), JsonProperty("gender")] public int? Gender;
        [XmlElement("group_expiry", IsNullable = true), JsonProperty("group_expiry")] public int? GroupExpiry;
        [XmlElement("group_id", IsNullable = true), JsonProperty("group_id")] public int? GroupId;
        [JsonProperty("icq"), XmlElement("icq", IsNullable = true)] public string Icq;
        [JsonProperty("id_card"), XmlElement("id_card", IsNullable = true)] public string IdCard;
        [JsonProperty("invisible"), XmlElement("invisible", IsNullable = true)] public int? Invisible;
        [XmlElement("join_date", IsNullable = true), JsonProperty("join_date")] public string JoinDate;
        [JsonProperty("last_activity"), XmlElement("last_activity", IsNullable = true)] public string LastActivity;
        [JsonProperty("last_ip"), XmlElement("last_ip", IsNullable = true)] public string LastIp;
        [JsonProperty("last_post"), XmlElement("last_post", IsNullable = true)] public string LastPost;
        [XmlElement("last_post_title", IsNullable = true), JsonProperty("last_post_title")] public string LastPostTitle;
        [XmlElement("last_post_id", IsNullable = true), JsonProperty("last_post_id")] public int? LastPostid;
        [JsonProperty("last_visit"), XmlElement("last_visit", IsNullable = true)] public string LastVisit;
        [JsonProperty("location"), XmlElement("location", IsNullable = true)] public string Location;
        [XmlElement("medals", IsNullable = true), JsonProperty("medals")] public string Medals;
        [XmlElement("mobile", IsNullable = true), JsonProperty("mobile")] public string Mobile;
        [XmlElement("msn", IsNullable = true), JsonProperty("msn")] public string Msn;
        [JsonProperty("has_new_pm"), XmlElement("has_new_pm", IsNullable = true)] public int? NewPm;
        [JsonProperty("new_pm_count"), XmlElement("new_pm_count", IsNullable = true)] public int? NewPmCount;
        [XmlElement("nick_name", IsNullable = true), JsonProperty("nick_name")] public string NickName;
        [XmlElement("online_state", IsNullable = true), JsonProperty("online_state")] public int? OnlineState;
        [JsonProperty("online_time"), XmlElement("online_time", IsNullable = true)] public int? OnlineTime;
        [XmlElement("page_view_count", IsNullable = true), JsonProperty("page_view_count")] public int? PageViews;
        [XmlElement("password", IsNullable = true), JsonProperty("password")] public string Password;
        [XmlElement("telephone", IsNullable = true), JsonProperty("telephone")] public string Phone;
        [JsonProperty("pm_sound"), XmlElement("pm_sound", IsNullable = true)] public int? PmSound;
        [JsonProperty("post_count"), XmlElement("post_count", IsNullable = true)] public int? Posts;
        [JsonProperty("ppp"), XmlElement("ppp", IsNullable = true)] public int? Ppp;
        [XmlElement("qq", IsNullable = true), JsonProperty("qq")] public string Qq;
        [JsonProperty("real_name"), XmlElement("real_name", IsNullable = true)] public string RealName;
        [JsonProperty("reg_ip"), XmlElement("reg_ip", IsNullable = true)] public string RegIp;
        [JsonProperty("secques"), XmlElement("secques", IsNullable = true)] public string Secques;
        [JsonProperty("show_email"), XmlElement("show_email", IsNullable = true)] public int? ShowEmail;
        [XmlIgnore, JsonIgnore] public int? SigStatus;
        [JsonProperty("sign_html"), XmlElement("sign_html", IsNullable = true)] public string Sightml;
        [JsonIgnore, XmlIgnore] public string Signature;
        [XmlElement("skype", IsNullable = true), JsonProperty("skype")] public string Skype;
        [XmlElement("space_id", IsNullable = true), JsonProperty("space_id")] public int? SpaceId;
        [JsonProperty("template_id"), XmlElement("template_id", IsNullable = true)] public int? Templateid;
        [XmlElement("tpp", IsNullable = true), JsonProperty("tpp")] public int? Tpp;
        [XmlElement("user_name", IsNullable = true), JsonProperty("user_name")] public string UserName;
        [JsonProperty("web_site"), XmlElement("web_site", IsNullable = true)] public string WebSite;
        [XmlElement("yahoo", IsNullable = true), JsonProperty("yahoo")] public string Yahoo;
    }
}
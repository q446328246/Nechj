using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class UserForEditing
    {
        [JsonProperty("about_me")] public string Bio;
        [JsonProperty("birthday")] public string Birthday;
        [JsonProperty("email")] public string Email;
        [JsonProperty("ext_credits_1")] public string ExtCredits1;
        [JsonProperty("ext_credits_2")] public string ExtCredits2;
        [JsonProperty("ext_credits_3")] public string ExtCredits3;
        [JsonProperty("ext_credits_4")] public string ExtCredits4;
        [JsonProperty("ext_credits_5")] public string ExtCredits5;
        [JsonProperty("ext_credits_6")] public string ExtCredits6;
        [JsonProperty("ext_credits_7")] public string ExtCredits7;
        [JsonProperty("ext_credits_8")] public string ExtCredits8;
        [JsonProperty("gender")] public string Gender;
        [JsonProperty("icq")] public string Icq;
        [JsonProperty("id_card")] public string IdCard;
        [JsonProperty("location")] public string Location;
        [JsonProperty("mobile")] public string Mobile;
        [JsonProperty("msn")] public string Msn;
        [JsonProperty("nick_name")] public string NickName;
        [JsonProperty("password")] public string Password;
        [JsonProperty("telephone")] public string Phone;
        [JsonProperty("qq")] public string Qq;
        [JsonProperty("real_name")] public string RealName;
        [JsonProperty("skype")] public string Skype;
        [JsonProperty("space_id")] public string SpaceId;
        [JsonProperty("web_site")] public string WebSite;
        [JsonProperty("yahoo")] public string Yahoo;
    }
}
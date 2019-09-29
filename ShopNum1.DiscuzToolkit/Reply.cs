using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class Reply
    {
        [JsonProperty("fid")] public int Fid;
        [JsonProperty("message")] public string Message;
        [JsonProperty("tid")] public int Tid;
        [JsonProperty("title")] public string Title;
    }
}
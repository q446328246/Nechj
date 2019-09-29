using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class Forum
    {
        [JsonProperty("allow_bbcode")] public int AllowBbcode;
        [JsonProperty("allow_edit_rules")] public int AllowEditRules;
        [JsonProperty("allow_imgcode")] public int AllowImgcode;
        [JsonProperty("allow_rss")] public int AllowRss;
        [JsonProperty("allow_smilies")] public int AllowSmilies;
        [JsonProperty("allow_tag")] public int AllowTag;
        [JsonProperty("allow_thumbnail")] public int AllowThumbnail;
        [JsonProperty("auto_close")] public int AutoClose;
        [JsonProperty("description")] public string Description;
        [JsonProperty("disable_watermark")] public int DisableWatermark;
        [JsonProperty("icon")] public string Icon;
        [JsonProperty("inherited_mod")] public int InheritedMod;
        [JsonProperty("jammer")] public int Jammer;
        [JsonProperty("mod_new_posts")] public int ModNewPosts;
        [JsonProperty("moderators")] public string Moderators;
        [JsonProperty("name")] public string Name;
        [JsonProperty("parent_id")] public int ParentId;
        [JsonProperty("recycle_bin")] public int RecycleBin;
        [JsonProperty("rewrite_name")] public string RewriteName;
        [JsonProperty("rules")] public string Rules;
        [JsonProperty("seo_description")] public string SeoDescription;
        [JsonProperty("seo_keywords")] public string SeoKeywords;
        [JsonProperty("status")] public int? Status;
        [JsonProperty("template_id")] public int TemplateId;
    }
}
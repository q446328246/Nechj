using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ShopNum1.DiscuzToolkit
{
    public class AttachmentInfo
    {
        private string string_6 = string.Empty;

        [XmlElement("aid"), JsonProperty("aid")]
        public int Aid { get; set; }

        [JsonProperty("allow_read"), XmlElement("allow_read")]
        public int Allowread { get; set; }

        [JsonProperty("is_image"), XmlElement("is_image")]
        public int Attachimgpost { get; set; }

        [JsonProperty("original_file_name"), XmlElement("original_file_name")]
        public string Attachment { get; set; }

        [XmlElement("price"), JsonProperty("price")]
        public int Attachprice { get; set; }

        [JsonProperty("description"), XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("download_count"), JsonProperty("download_count")]
        public int Downloads { get; set; }

        [XmlElement("file_name"), JsonProperty("file_name")]
        public string Filename { get; set; }

        [JsonProperty("file_size"), XmlElement("file_size")]
        public long Filesize { get; set; }

        [XmlElement("file_type"), JsonProperty("file_type")]
        public string Filetype { get; set; }

        [XmlElement("download_perm"), JsonProperty("download_perm")]
        public int Getattachperm { get; set; }

        [JsonProperty("inserted"), XmlElement("inserted")]
        public int Inserted { get; set; }

        [XmlElement("is_bought"), JsonProperty("is_bought")]
        public int Isbought { get; set; }

        [JsonProperty("pid"), XmlElement("pid")]
        public int Pid { get; set; }

        [JsonProperty("post_date_time"), XmlElement("post_date_time")]
        public string Postdatetime { get; set; }

        [JsonProperty("preview"), XmlElement("preview")]
        public string Preview
        {
            get { return string_6; }
            set { string_6 = value; }
        }

        [XmlElement("read_perm"), JsonProperty("read_perm")]
        public int Readperm { get; set; }

        [XmlIgnore, JsonIgnore]
        public int Sys_index { get; set; }

        [JsonIgnore, XmlIgnore]
        public string Sys_noupload { get; set; }

        [JsonProperty("tid"), XmlElement("tid")]
        public int Tid { get; set; }

        [JsonProperty("uid"), XmlElement("uid")]
        public int Uid { get; set; }
    }
}
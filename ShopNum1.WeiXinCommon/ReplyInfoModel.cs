using System;

namespace ShopNum1.WeiXinCommon
{
    public class ReplyInfoModel
    {
        private string _description = string.Empty;
        private string _hq_music_url = string.Empty;
        private string _imgsrc = string.Empty;
        private string _keyword = string.Empty;
        private DateTime _modifydate = Convert.ToDateTime("1901-01-01 00:00:00");
        private string _music_url = string.Empty;
        private string _repmsgcontent = string.Empty;
        private string _title = string.Empty;
        private string _url = string.Empty;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string HQ_Music_Url
        {
            get { return _hq_music_url; }
            set { _hq_music_url = value; }
        }

        public string ImgSrc
        {
            get { return _imgsrc; }
            set { _imgsrc = value; }
        }

        public bool IsDelete { get; set; }

        public bool IsSinglePicRep { get; set; }

        public string KeyWord
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        public DateTime ModifyDate
        {
            get { return _modifydate; }
            set { _modifydate = value; }
        }

        public string Music_Url
        {
            get { return _music_url; }
            set { _music_url = value; }
        }

        public int RecId { get; set; }

        public string RepMsgContent
        {
            get { return _repmsgcontent; }
            set { _repmsgcontent = value; }
        }

        public int RepMsgType { get; set; }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}
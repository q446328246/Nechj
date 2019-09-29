using System;

namespace ShopNum1.TbTopCommon
{
    public class ItemImgResponse
    {
        private string string_0;

        public string created
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(string_0).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { string_0 = value; }
        }

        public string String_0 { get; set; }

        public string String_1 { get; set; }
    }
}
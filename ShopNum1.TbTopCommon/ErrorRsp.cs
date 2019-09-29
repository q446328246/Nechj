namespace ShopNum1.TbTopCommon
{
    public class ErrorRsp
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;

        public string args
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public string code
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string depict
        {
            get { return string_5; }
            set { string_5 = value; }
        }

        public bool IsError { get; set; }

        public string msg
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string sub_code
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string sub_msg
        {
            get { return string_4; }
            set { string_4 = value; }
        }
    }
}
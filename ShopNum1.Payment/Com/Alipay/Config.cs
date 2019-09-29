namespace Com.Alipay
{
    public class Config
    {
        private static string a;
        private static string b;
        private static string c;
        private static string d;

        static Config()
        {
            a = "";
            b = "";
            c = "";
            d = "";
            a = "";
            b = "";
            c = "utf-8";
            d = "MD5";
        }

        public static string Partner
        {
            get { return a; }
            set { a = value; }
        }

        public static string Key
        {
            get { return b; }
            set { b = value; }
        }

        public static string Input_charset
        {
            get { return c; }
        }

        public static string Sign_type
        {
            get { return d; }
        }
    }
}
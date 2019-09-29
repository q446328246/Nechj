namespace ShopNum1.Second
{
    using System;

    public class ShopNum1_BaiduOAuthMessage
    {
        private int int_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        public string Access_token
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        public int Expires_in
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        public string Scope
        {
            get
            {
                return this.string_3;
            }
            set
            {
                this.string_3 = value;
            }
        }

        public string Session_key
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
            }
        }

        public string Session_secret
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }
    }
}


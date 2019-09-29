namespace ShopNum1.Second
{
    using System;

    public class ShopNum1_XinLanOAuthMessage
    {
        private int int_0;
        private string string_0;
        private string string_1;
        private string string_2;

        public string access_token
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

        public int expires_in
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

        public string refresh_token
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

        public string uid
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
    }
}


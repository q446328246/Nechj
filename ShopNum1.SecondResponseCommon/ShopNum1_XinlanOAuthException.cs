namespace ShopNum1.Second
{
    using System;

    public class ShopNum1_XinlanOAuthException : Exception
    {
        private string string_0;
        private string string_1;
        private string string_2;

        public string error
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

        public string error_code
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

        public string error_description
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


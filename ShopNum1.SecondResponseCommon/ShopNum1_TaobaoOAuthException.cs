namespace ShopNum1.Second
{
    using System;

    public class ShopNum1_TaobaoOAuthException : Exception
    {
        private string string_0;
        private string string_1;

        public string Error
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

        public string Error_description
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


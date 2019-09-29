namespace ShopNum1.Second
{
    using System;
    using System.Configuration;
    using System.Data;

    public class ShopNum1_Alipay_config
    {
        private string a = "";
        private string b = "";
        private string c = "";
        private string d = "";
        private string e = "";
        private string f = "";

        public ShopNum1_Alipay_config()
        {
            DataTable model = null;
            model = new ShopNum1_SecondTypeBussiness().GetModel(4);
            this.a = model.Rows[0]["AppID"].ToString();
            this.b = model.Rows[0]["AppSecret"].ToString();
            this.c = "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Alipay/AlipayReturn.aspx";
            this.d = "utf-8";
            this.e = "MD5";
            this.f = "http";
        }

        public string Input_charset
        {
            get
            {
                return this.d;
            }
            set
            {
                this.d = value;
            }
        }

        public string Key
        {
            get
            {
                return this.b;
            }
            set
            {
                this.b = value;
            }
        }

        public string Partner
        {
            get
            {
                return this.a;
            }
            set
            {
                this.a = value;
            }
        }

        public string Return_url
        {
            get
            {
                return this.c;
            }
            set
            {
                this.c = value;
            }
        }

        public string Sign_type
        {
            get
            {
                return this.e;
            }
            set
            {
                this.e = value;
            }
        }

        public string Transport
        {
            get
            {
                return this.f;
            }
            set
            {
                this.f = value;
            }
        }
    }
}


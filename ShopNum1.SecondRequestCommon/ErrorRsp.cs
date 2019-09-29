namespace ShopNum1.Second
{
    using System;

    public class ErrorRsp
    {
        private bool a = false;
        private string b = string.Empty;
        private string c = string.Empty;
        private string d = string.Empty;
        private string e = string.Empty;
        private string f = string.Empty;
        private string g = string.Empty;

        public string args
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

        public string code
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

        public string depict
        {
            get
            {
                return this.g;
            }
            set
            {
                this.g = value;
            }
        }

        public bool IsError
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

        public string msg
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

        public string sub_code
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

        public string sub_msg
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


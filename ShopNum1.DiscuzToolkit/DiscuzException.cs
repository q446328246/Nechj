using System;

namespace ShopNum1.DiscuzToolkit
{
    public class DiscuzException : Exception
    {
        private readonly int int_0;
        private readonly string string_0;

        public DiscuzException(int error_code, string error_message) : base(smethod_0(error_code, error_message))
        {
            int_0 = error_code;
            string_0 = error_message;
        }

        public int ErrorCode
        {
            get { return int_0; }
        }

        public string ErrorMessage
        {
            get { return string_0; }
        }

        private static string smethod_0(int int_1, string string_1)
        {
            return string.Format("Code: {0}, Message: {1}", int_1, string_1);
        }
    }
}
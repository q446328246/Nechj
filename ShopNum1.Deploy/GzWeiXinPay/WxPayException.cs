using System;
using System.Collections.Generic;
using System.Web;

namespace ShopNum1.Deploy.GzWeiXinPay
{
    public class WxPayException : Exception
    {
        public WxPayException(string msg)
            : base(msg)
        {

        }
    }
}
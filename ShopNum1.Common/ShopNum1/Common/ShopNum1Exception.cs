using System;

namespace ShopNum1.Common
{
    public class ShopNum1Exception : Exception
    {
        public ShopNum1Exception()
        {
        }

        public ShopNum1Exception(string msg) : base(msg)
        {
        }
    }
}
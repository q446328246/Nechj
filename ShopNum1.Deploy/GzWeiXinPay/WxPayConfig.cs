using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopNum1.Deploy.GzWeiXinPay
{
    public class WxPayConfig
    {

        private static volatile IConfig config;
        private static object syncRoot = new object();

        public static IConfig GetConfig()
        {
            if (config == null)
            {
                lock (syncRoot)
                {
                    if (config == null)
                        config = new DemoConfig();
                }
            }
            return config;
        }





    }
}
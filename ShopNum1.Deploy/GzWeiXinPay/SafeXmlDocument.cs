using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace ShopNum1.Deploy.GzWeiXinPay
{
    public class SafeXmlDocument : XmlDocument
    {
        public SafeXmlDocument()
        {
            this.XmlResolver = null;
        }
    }
}
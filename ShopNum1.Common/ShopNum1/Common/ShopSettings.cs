using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Xml;

namespace ShopNum1.Common
{
    public class ShopSettings
    {
        private static bool _IsOverrideUrl;
        private static string _OverrideUrl;
        private static string _overrideUrlName = string.Empty;
        private static string _dinpayurl = "";
        private static string _dinpaynotifr = "";
        private static string _dinpaypage = "";
        private static string _tj520 = "";
        private static string _tj5201 = "";
        private static string _Shop1 = "";
        private static string _Shop2 = "";
        private static string _Shop3 = "";
        private static string _Shopm1 = "";
        private static string _Shopm2 = "";
        private static string _Shopm3 = "";
        private static DataRow _ShopSettingRow;

        private static string _shopsettingXml = (System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                                                 @"\Settings\ShopSetting.xml");

        private static string _siteDomain = "";
        private static string _MobilePayAppID = "";
        private static XmlNodeList _xmlNodes;
        private static string _siteDiscuzCookieDomain="";
        private static string _CookieDomain = "";





        public static string TJ520_two
        {
            get
            {
                if (_tj5201 == string.Empty)
                {
                    _tj5201 = ConfigurationManager.AppSettings["TJ520_two"].Trim().ToLower();
                    return _tj5201;
                }
                return _tj5201;
            }
            set { _tj5201 = value; }
        }

        public static string TJ520
        {
            get
            {
                if (_tj520 == string.Empty)
                {
                    _tj520 = ConfigurationManager.AppSettings["TJ520"].Trim().ToLower();
                    return _tj520;
                }
                return _tj520;
            }
            set { _tj520 = value; }
        }


        public static bool IsOverrideUrl
        {
            get
            {
                if (_OverrideUrl == null)
                {
                    _IsOverrideUrl = bool.Parse(ShopSettingRow["OverrideUrl"].ToString());
                    _OverrideUrl = "true";
                    return _IsOverrideUrl;
                }
                return _IsOverrideUrl;
            }
            set { _IsOverrideUrl = value; }
        }

        public static string overrideUrlName
        {
            get
            {
                if (_overrideUrlName == string.Empty)
                {
                    _overrideUrlName = ShopSettingRow["OverrideUrlName"].ToString();
                    return _overrideUrlName;
                }
                return _overrideUrlName;
            }
            set { _overrideUrlName = value; }
        }



        public static DataRow ShopSettingRow
        {
            get
            {
                if (_ShopSettingRow == null)
                {
                    var set = new DataSet();
                    set.ReadXml(shopsettingXml);
                    _ShopSettingRow = set.Tables["ShopSetting"].Rows[0];
                }
                return _ShopSettingRow;
            }
            set { _ShopSettingRow = value; }
        }

        public static string shopsettingXml
        {
            get { return _shopsettingXml; }
            set { _shopsettingXml = value; }
        }


        public static string Shop1
        {
            get
            {
                if (_Shop1 == string.Empty)
                {
                    _Shop1 = ShopSettingRow["ShopGodds_one"].ToString();
                    return _Shop1;
                }
                return _Shop1;
            }
            set { _Shop1 = value; }
        }
        public static string Shop2
        {
            get
            {
                if (_Shop2 == string.Empty)
                {
                    _Shop2 = ShopSettingRow["ShopGodds_two"].ToString();
                    return _Shop2;
                }
                return _Shop2;
            }
            set { _Shop2 = value; }
        }

        public static string Shop3
        {
            get
            {
                if (_Shop3 == string.Empty)
                {
                    _Shop3 = ShopSettingRow["ShopGodds_free"].ToString();
                    return _Shop3;
                }
                return _Shop3;
            }
            set { _Shop3 = value; }
        }

        public static string Shopm1
        {
            get
            {
                if (_Shopm1 == string.Empty)
                {
                    _Shopm1 = ShopSettingRow["ShopGodds_one"].ToString();
                    return _Shopm1;
                }
                return _Shopm1;
            }
            set { _Shopm1 = value; }
        }
        public static string Shopm2
        {
            get
            {
                if (_Shopm2 == string.Empty)
                {
                    _Shopm2 = ShopSettingRow["ShopGodds_two"].ToString();
                    return _Shopm2;
                }
                return _Shopm2;
            }
            set { _Shopm2 = value; }
        }

        public static string Shopm3
        {
            get
            {
                if (_Shopm3 == string.Empty)
                {
                    _Shopm3 = ShopSettingRow["ShopGodds_free"].ToString();
                    return _Shopm3;
                }
                return _Shopm3;
            }
            set { _Shopm3 = value; }
        }

        public static string dinpayurl
        {
            get
            {
                if (_dinpayurl == string.Empty)
                {
                    _dinpayurl = ConfigurationManager.AppSettings["Dinpay"].Trim().ToLower();
                    return _dinpayurl;
                }
                return _dinpayurl;
            }
            set { _dinpayurl = value; }
        }
        public static string dinpaynotifr
        {
            get
            {
                if (_dinpaynotifr == string.Empty)
                {
                    _dinpaynotifr = ConfigurationManager.AppSettings["Dinpay_notify"].Trim().ToLower();
                    return _dinpaynotifr;
                }
                return _dinpaynotifr;
            }
            set { _dinpaynotifr = value; }
        }
        public static string dinpaypage
        {
            get
            {
                if (_dinpaypage == string.Empty)
                {
                    _dinpaypage = ConfigurationManager.AppSettings["Dinpay_page"].Trim().ToLower();
                    return _dinpaypage;
                }
                return _dinpaypage;
            }
            set { _dinpaypage = value; }
        }
        public static string siteDomain
        {
            get
            {
                if (_siteDomain == string.Empty)
                {
                    _siteDomain = ConfigurationManager.AppSettings["Domain"].Trim().ToLower();
                    return _siteDomain;
                }
                return _siteDomain;
            }
            set { _siteDomain = value; }
        }

        public static string MobilePayAppID
        {
            get
            {
                if (_MobilePayAppID == string.Empty)
                {
                    _MobilePayAppID = ConfigurationManager.AppSettings["MobilePayAppID"].Trim().ToLower();
                    return _MobilePayAppID;
                }
                return _MobilePayAppID;
            }
            set { _MobilePayAppID = value; }
        }

        public static string siteDiscuzCookieDomain
        {
            get
            {
                if (_siteDiscuzCookieDomain == string.Empty)
                {
                    _siteDiscuzCookieDomain = ConfigurationManager.AppSettings["DiscuzCookieDomain"].Trim().ToLower();
                    return _siteDiscuzCookieDomain;
                }
                return _siteDiscuzCookieDomain;
            }
            set { _siteDiscuzCookieDomain = value; }
        }

        public static string CookieDomain
        {
            get
            {
                if (_CookieDomain == string.Empty)
                {
                    _CookieDomain = ConfigurationManager.AppSettings["CookieDomain"].Trim().ToLower();
                    return _CookieDomain;
                }
                return _CookieDomain;
            }
            set { _CookieDomain = value; }
        }

        public static XmlNodeList xmlNodes
        {
            get
            {
                if (_xmlNodes == null)
                {
                    _xmlNodes = XmlOperator.ReadXmlReturnNodeList(shopsettingXml, "ShopSetting");
                }
                return _xmlNodes;
            }
            set { _xmlNodes = value; }
        }

        public static string GetValue(string nodeName)
        {
            foreach (XmlNode node in xmlNodes)
            {
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if (node2.Name == nodeName)
                    {
                        return node2.InnerText;
                    }
                }
            }
            return string.Empty;
        }

        public string GetValue(string fieldXmlPath, string nodeName)
        {
            foreach (XmlNode node in XmlOperator.ReadXmlReturnNodeList(fieldXmlPath, "ShopSetting"))
            {
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if (node2.Name == nodeName)
                    {
                        return node2.InnerText;
                    }
                }
            }
            return string.Empty;
        }

        public static List<string> GetValueAllInvoice()
        {
            return new List<string>
                {
                    GetValueInvoice("InvoiceType1"),
                    GetValueInvoice("InvoiceType2"),
                    GetValueInvoice("InvoiceType3")
                };
        }

        public List<string> GetValueAllInvoice(string fieldXmlPath)
        {
            return new List<string>
                {
                    GetValueInvoice(fieldXmlPath, "InvoiceType1"),
                    GetValueInvoice(fieldXmlPath, "InvoiceType2"),
                    GetValueInvoice(fieldXmlPath, "InvoiceType3")
                };
        }

        public static string GetValueInvoice(string nodeName)
        {
            foreach (XmlNode node in xmlNodes)
            {
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if (node2.Name == nodeName)
                    {
                        return node2.InnerText;
                    }
                }
            }
            return string.Empty;
        }

        public string GetValueInvoice(string fieldXmlPath, string nodeName)
        {
            foreach (XmlNode node in XmlOperator.ReadXmlReturnNodeList(fieldXmlPath, "ShopSetting/InvoiceType"))
            {
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if (node2.Name == nodeName)
                    {
                        return node2.InnerText;
                    }
                }
            }
            return string.Empty;
        }

        public static void ResetShopSetting()
        {
            xmlNodes = null;
            ShopSettingRow = null;
            xmlNodes = null;
            siteDomain = string.Empty;
            overrideUrlName = string.Empty;
            siteDomain = string.Empty;
            _OverrideUrl = string.Empty;
        }
    }
}
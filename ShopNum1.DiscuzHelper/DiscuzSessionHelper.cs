using System.Configuration;
using ShopNum1.DiscuzToolkit;

namespace ShopNum1.DiscuzHelper
{
    public class DiscuzSessionHelper
    {
        private static readonly DiscuzSession discuzSession_0 = new DiscuzSession(string_0, string_1, string_2);
        private static readonly string string_0 = ConfigurationManager.AppSettings["DiscuzApiKey"];
        private static readonly string string_1 = ConfigurationManager.AppSettings["DiscuzSecret"];
        private static readonly string string_2 = ConfigurationManager.AppSettings["DiscuzPostUrl"];

        public static DiscuzSession GetSession()
        {
            return discuzSession_0;
        }

        public static bool IsDiscuzIntegration()
        {
            string str = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
            return (str == "1");
        }
    }
}
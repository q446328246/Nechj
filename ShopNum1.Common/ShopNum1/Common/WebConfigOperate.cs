using System.Configuration;
using System.Web;
using System.Web.Configuration;

namespace ShopNum1.Common
{
    public class WebConfigOperate
    {
        public static string GetAppSetConfigValue(string congName)
        {
            return ConfigurationManager.AppSettings[congName];
        }

        public static bool UpdateAppSetConfigValue(string[] congName, string[] congValue)
        {
            Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var section = (AppSettingsSection) configuration.GetSection("appSettings");
            if ((congName.Length != 0) && (congName.Length == congValue.Length))
            {
                for (int i = 0; i < congName.Length; i++)
                {
                    section.Settings[congName[i]].Value = congValue[i];
                }
            }
            try
            {
                configuration.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
namespace ShopNum1.Common
{
    public class TosUrl
    {
        public static string GetSyPic(object url)
        {
            if (url.ToString().Length > 0)
            {
                int length = url.ToString().LastIndexOf('/') + 1;
                string str = url.ToString().Substring(0, length);
                return (str = str + "sy_" + url.ToString().Substring(length, url.ToString().Length - str.Length));
            }
            return "";
        }

        public static string GosUrl(object url)
        {
            if (url.ToString().Length > 0)
            {
                int length = url.ToString().LastIndexOf('/') + 1;
                string str = url.ToString().Substring(0, length);
                return (str = str + "s_" + url.ToString().Substring(length, url.ToString().Length - str.Length));
            }
            return "";
        }
    }
}
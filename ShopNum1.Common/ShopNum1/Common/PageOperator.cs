using System.Web;

namespace ShopNum1.Common
{
    public static class PageOperator
    {
        public static string GetCurrentPageName()
        {
            string str2 = HttpContext.Current.Request.FilePath.ToLower().Replace("/main/admin", "").Trim();
            string str = str2.Substring(str2.IndexOf("/"));
            if (Operator.Left(str, 1) == "/")
            {
                str = str.Substring(1);
            }
            return str;
        }

        public static string GetListImageStatus(string isshow)
        {
            if (isshow == "0")
            {
                return "images/shopNum1Admin-right.gif";
            }
            return "images/shopNum1Admin-wrong.gif";
        }

        public static string GetListImageStatus22(string isshow)
        {
            if (isshow == "1")
            {
                return "images/shopNum1Admin-right.gif";
            }
            else
            {
                return "images/shopNum1Admin-wrong.gif";
            }
           
        }
    }
}
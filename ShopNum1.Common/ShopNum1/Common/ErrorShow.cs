using System.Text;
using System.Web;

namespace ShopNum1.Common
{
    public static class ErrorShow
    {
        public static void Show(string strMessage)
        {
            StringBuilder builder = null;
            builder = new StringBuilder();
            builder.Append("<html><body>");
            builder.Append(
                "<h3 style=\"color:#6699cc;border-bottom:1px solid #8cb2d9;padding-left:20px;\">【 友情提示 】</h3>");
            builder.Append("<div style=\"padding-left:45px;line-height:35px;color:#666\">");
            builder.Append("很抱歉，您要访问的页面无法正确显示，可能是因为如下原因：<br />");
            builder.Append("1 . 系统过于繁忙，请点击浏览器的“刷新”按钮，或稍后再试。<br />");
            builder.Append("2 . 您输入的网址有误，请重新检查您输入的网址。 <br />");
            builder.Append("3 . 此页面已经删除，请访问其他页面。 <br />");
            builder.Append(strMessage);
            builder.Append("</div>");
            builder.Append("</body>");
            builder.Append("</html>");
            HttpContext.Current.Response.Write(builder.ToString());
            HttpContext.Current.Response.End();
        }
    }
}